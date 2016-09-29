using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterVerifierTests
    {
        private const int Level = 10;
        private const string Environment = "environment";
        private const string Temperature = "temperature";
        private const string TimeOfDay = "time of day";
        private const string Filter = "filter";

        private IEncounterVerifier encounterVerifier;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<IEncounterCollectionSelector> mockEncounterCollectionSelector;
        private Mock<IAmountSelector> mockAmountSelector;
        private List<string> filterGroup;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockEncounterCollectionSelector = new Mock<IEncounterCollectionSelector>();
            mockAmountSelector = new Mock<IAmountSelector>();
            encounterVerifier = new EncounterVerifier(mockCollectionSelector.Object, mockEncounterCollectionSelector.Object, mockAmountSelector.Object);

            filterGroup = new List<string>();
            filterGroup.Add("creature");
            filterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, Filter)).Returns(filterGroup);
        }

        private void SetupCreaturesAndAmounts(int setupLevel, string creatureName = "creature", params string[] additionalCreaturesAndAmounts)
        {
            var encounter = SetUpEncounter(creatureName, "just the right amount");

            for (var i = 0; i < additionalCreaturesAndAmounts.Length; i += 2)
            {
                encounter[additionalCreaturesAndAmounts[i]] = additionalCreaturesAndAmounts[i + 1];
            }

            var creaturesAndAmounts = new List<Dictionary<string, string>>();
            creaturesAndAmounts.Add(encounter);

            mockEncounterCollectionSelector.Setup(s => s.SelectAllWeightedFrom(setupLevel, Environment, Temperature, TimeOfDay)).Returns(creaturesAndAmounts);
        }

        private void SetupCreaturesAndAmountsWithFilters(int setupLevel, params string[] filters)
        {
            var encounter = SetUpEncounter("creature", "just the right amount");

            var creaturesAndAmounts = new List<Dictionary<string, string>>();
            creaturesAndAmounts.Add(encounter);

            mockEncounterCollectionSelector.Setup(s => s.SelectAllWeightedFrom(setupLevel, Environment, Temperature, TimeOfDay, filters)).Returns(creaturesAndAmounts);
        }

        private Dictionary<string, string> SetUpEncounter(params string[] creaturesAndAmounts)
        {
            var encounter = new Dictionary<string, string>();

            for (var i = 0; i < creaturesAndAmounts.Length; i += 2)
                encounter[creaturesAndAmounts[i]] = creaturesAndAmounts[i + 1];

            return encounter;
        }

        [Test]
        public void ValidEncounterExistsIfAnyCreaturesInEncounter()
        {
            SetupCreaturesAndAmounts(Level);
            var isValid = encounterVerifier.ValidEncounterExistsAtLevel(Environment, Level, Temperature, TimeOfDay);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void ValidEncounterExistsIfAnyCreaturesInEncounterWithFilter()
        {
            SetupCreaturesAndAmountsWithFilters(Level, Filter);
            var isValid = encounterVerifier.ValidEncounterExistsAtLevel(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.True);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(31)]
        public void ValidEncounterDoesNotExistAtLevelIfLevelInvalid(int level)
        {
            SetupCreaturesAndAmounts(level);
            var isValid = encounterVerifier.ValidEncounterExistsAtLevel(Environment, level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void ValidEncounterDoesNotExistAtLevelIfNoCreaturesAvailable()
        {
            SetupCreaturesAndAmounts(Level - 1);
            var isValid = encounterVerifier.ValidEncounterExistsAtLevel(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterIsValidIfNoFiltersAreProvided()
        {
            var encounter = SetUpEncounter("creature", "amount");

            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterIsNotValidIfCreatureDoesNotMatchFilter()
        {
            var encounter = SetUpEncounter("bogus creature", "amount");
            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, Filter);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterIsNotValidIfCreatureMatchesAnyFilter()
        {
            var encounter = SetUpEncounter("bogus creature", "amount");
            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, Filter, "other filter");
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterIsValidIfCreatureMatchesAnyFilter()
        {
            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "other filter")).Returns(additionalFilterGroup);

            var encounter = SetUpEncounter("creature", "amount");

            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, Filter, "other filter");
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterIsValidIfAnyCreatureMatchesFilter()
        {
            filterGroup.Remove("creature");
            filterGroup.Add("other creature");

            var encounter = SetUpEncounter("creature", "amount", "other creature", "other amount");

            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterIsValidIfCreatureWithDescriptionMatches()
        {
            var encounter = SetUpEncounter("creature (description)", "amount");
            filterGroup.Remove("creature");
            filterGroup.Add("creature (description)");

            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterIsValidIfCreatureWithLevelMatches()
        {
            var encounter = SetUpEncounter("creature[600]", "amount");
            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterIsValidIfCreatureWithDescriptionAndLevelMatches()
        {
            var encounter = SetUpEncounter("creature (description)[600]", "amount");
            filterGroup.Remove("creature");
            filterGroup.Add("creature (description)");

            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterFromCreaturesIsValidIfNoFiltersAreProvided()
        {
            var creatures = new[]
            {
                new Creature { Name = "creature", Quantity = 9266 },
                new Creature { Name = "other creature", Quantity = 90210 },
            };

            mockAmountSelector.Setup(s => s.SelectEncounterLevel(creatures)).Returns(15);

            var isValid = encounterVerifier.EncounterIsValid(creatures);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterFromCreaturesIsNotValidIfCreatureDoesNotMatchFilter()
        {
            var creatures = new[]
            {
                new Creature { Name = "bogus creature", Quantity = 9266 },
            };

            mockAmountSelector.Setup(s => s.SelectEncounterLevel(creatures)).Returns(15);

            var isValid = encounterVerifier.EncounterIsValid(creatures, Filter);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterFromCreaturesIsValidIfCreatureMatchesAnyFilter()
        {
            var creatures = new[]
            {
                new Creature { Name = "creature", Quantity = 9266 },
            };

            mockAmountSelector.Setup(s => s.SelectEncounterLevel(creatures)).Returns(15);

            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "other filter")).Returns(additionalFilterGroup);

            var isValid = encounterVerifier.EncounterIsValid(creatures, Filter, "other filter");
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterFromCreaturesIsValidIfAnyCreatureMatchesFilter()
        {
            filterGroup.Remove("creature");
            filterGroup.Add("other creature");

            var creatures = new[]
            {
                new Creature { Name = "creature", Quantity = 9266 },
                new Creature { Name = "other creature", Quantity = 90210 },
            };

            mockAmountSelector.Setup(s => s.SelectEncounterLevel(creatures)).Returns(15);

            var isValid = encounterVerifier.EncounterIsValid(creatures, Filter, "other filter");
            Assert.That(isValid, Is.True);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(31)]
        public void EncounterFromCreaturesIsNotValidIfLevelInvalid(int level)
        {
            var creatures = new[]
            {
                new Creature { Name = "creature", Quantity = 9266 },
                new Creature { Name = "other creature", Quantity = 90210 },
            };

            mockAmountSelector.Setup(s => s.SelectEncounterLevel(creatures)).Returns(level);

            var isValid = encounterVerifier.EncounterIsValid(creatures);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterFromCreaturesIsNotValidIfNoCreatures()
        {
            var creatures = Enumerable.Empty<Creature>();
            var isValid = encounterVerifier.EncounterIsValid(creatures);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void CreatureIsValidIfNoFiltersAreProvided()
        {
            var isValid = encounterVerifier.CreatureIsValid("bogus creature");
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfWithinFilterGroup()
        {
            var isValid = encounterVerifier.CreatureIsValid("creature", Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsNotValidIfOutsideFilterGroup()
        {
            var isValid = encounterVerifier.CreatureIsValid("wrong creature", Filter);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void CreatureIsValidIfAnyFilterMatches()
        {
            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "additional filter")).Returns(additionalFilterGroup);

            var isValid = encounterVerifier.CreatureIsValid("creature", Filter, "additional filter");
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsNotValidIfNoFilterMatches()
        {
            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "additional filter")).Returns(additionalFilterGroup);

            var isValid = encounterVerifier.CreatureIsValid("wrong creature", Filter, "additional filter");
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void CreatureIsValidIfCreatureWithDescriptionMatches()
        {
            filterGroup.Remove("creature");
            filterGroup.Add("creature (description)");

            var isValid = encounterVerifier.CreatureIsValid("creature (description)", Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfCreatureWithLevelMatches()
        {
            var isValid = encounterVerifier.CreatureIsValid("creature[600]", Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfCreatureWithDescriptionAndLevelMatches()
        {
            filterGroup.Remove("creature");
            filterGroup.Add("creature (description)");

            var isValid = encounterVerifier.CreatureIsValid("creature (description)[600]", Filter);
            Assert.That(isValid, Is.True);
        }
    }
}
