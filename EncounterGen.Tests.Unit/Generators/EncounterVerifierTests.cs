using DnDGen.Core.Selectors.Collections;
using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

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
        private Mock<IEncounterLevelSelector> mockAmountSelector;
        private List<string> filterGroup;
        private EncounterSpecifications specifications;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockEncounterCollectionSelector = new Mock<IEncounterCollectionSelector>();
            mockAmountSelector = new Mock<IEncounterLevelSelector>();
            encounterVerifier = new EncounterVerifier(mockCollectionSelector.Object, mockEncounterCollectionSelector.Object, mockAmountSelector.Object);

            specifications = new EncounterSpecifications();
            specifications.Environment = Environment;
            specifications.Level = Level;
            specifications.Temperature = Temperature;
            specifications.TimeOfDay = TimeOfDay;

            filterGroup = new List<string>();
            filterGroup.Add("creature");
            filterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, Filter)).Returns(filterGroup);
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

            mockEncounterCollectionSelector.Setup(s => s.SelectAllWeightedFrom(It.Is<EncounterSpecifications>(es => es.Level == setupLevel))).Returns(creaturesAndAmounts);
        }

        private void SetupCreaturesAndAmountsWithFilters(int setupLevel)
        {
            var encounter = SetUpEncounter("creature", "just the right amount");

            var creaturesAndAmounts = new List<Dictionary<string, string>>();
            creaturesAndAmounts.Add(encounter);

            mockEncounterCollectionSelector.Setup(s => s.SelectAllWeightedFrom(It.Is<EncounterSpecifications>(es => es.Level == setupLevel))).Returns(creaturesAndAmounts);
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
            var isValid = encounterVerifier.ValidEncounterExistsAtLevel(specifications);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void ValidEncounterExistsIfAnyCreaturesInEncounterWithFilter()
        {
            specifications.CreatureTypeFilters = new[] { Filter };
            SetupCreaturesAndAmountsWithFilters(Level);

            var isValid = encounterVerifier.ValidEncounterExistsAtLevel(specifications);
            Assert.That(isValid, Is.True);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(31)]
        public void ValidEncounterDoesNotExistAtLevelIfLevelInvalid(int level)
        {
            specifications.CreatureTypeFilters = new[] { Filter };
            SetupCreaturesAndAmounts(level);

            var isValid = encounterVerifier.ValidEncounterExistsAtLevel(specifications);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void ValidEncounterDoesNotExistAtLevelIfNoCreaturesAvailable()
        {
            specifications.CreatureTypeFilters = new[] { Filter };
            SetupCreaturesAndAmounts(Level - 1);

            var isValid = encounterVerifier.ValidEncounterExistsAtLevel(specifications);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterIsValidIfNoFiltersAreProvided()
        {
            var encounter = SetUpEncounter("creature", "amount");

            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, specifications.CreatureTypeFilters);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterIsNotValidIfCreatureDoesNotMatchFilter()
        {
            var encounter = SetUpEncounter("bogus creature", "amount");
            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, new[] { Filter });
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterIsNotValidIfCreatureMatchesAnyFilter()
        {
            var encounter = SetUpEncounter("bogus creature", "amount");
            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, new[] { Filter, "other filter" });
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterIsValidIfCreatureMatchesAnyFilter()
        {
            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "other filter")).Returns(additionalFilterGroup);

            var encounter = SetUpEncounter("creature", "amount");

            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, new[] { Filter, "other filter" });
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterIsValidIfAnyCreatureMatchesFilter()
        {
            filterGroup.Remove("creature");
            filterGroup.Add("other creature");

            var encounter = SetUpEncounter("creature", "amount", "other creature", "other amount");

            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, new[] { Filter });
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterIsValidIfCreatureWithDescriptionMatches()
        {
            var encounter = SetUpEncounter("creature (description)", "amount");
            filterGroup.Remove("creature");
            filterGroup.Add("creature (description)");

            var isValid = encounterVerifier.EncounterIsValid(encounter.Keys, new[] { Filter });
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterFromCreaturesIsValidIfNoFiltersAreProvided()
        {
            var encounter = new Encounter();
            encounter.Creatures = new[]
            {
                new Creature { Type = new CreatureType { Name = "creature" }, Quantity = 9266 },
                new Creature { Type = new CreatureType { Name = "other creature" }, Quantity = 90210 },
            };

            mockAmountSelector.Setup(s => s.Select(encounter)).Returns(15);

            var isValid = encounterVerifier.EncounterIsValid(encounter, specifications.CreatureTypeFilters);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterFromCreaturesIsNotValidIfCreatureDoesNotMatchFilter()
        {
            var encounter = new Encounter();
            encounter.Creatures = new[]
            {
                new Creature { Type = new CreatureType { Name = "bogus creature" }, Quantity = 9266 },
            };

            mockAmountSelector.Setup(s => s.Select(encounter)).Returns(15);

            var isValid = encounterVerifier.EncounterIsValid(encounter, new[] { Filter });
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterFromCreaturesIsValidIfCreatureMatchesAnyFilter()
        {
            var encounter = new Encounter();
            encounter.Creatures = new[]
            {
                new Creature { Type = new CreatureType { Name = "creature" }, Quantity = 9266 },
            };

            mockAmountSelector.Setup(s => s.Select(encounter)).Returns(15);

            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "other filter")).Returns(additionalFilterGroup);

            var isValid = encounterVerifier.EncounterIsValid(encounter, new[] { Filter, "other filter" });
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterFromCreaturesIsValidIfAnyCreatureMatchesFilter()
        {
            filterGroup.Remove("creature");
            filterGroup.Add("other creature");

            var encounter = new Encounter();
            encounter.Creatures = new[]
            {
                new Creature { Type = new CreatureType { Name = "creature" }, Quantity = 9266 },
                new Creature { Type = new CreatureType { Name = "other creature" }, Quantity = 90210 },
            };

            mockAmountSelector.Setup(s => s.Select(encounter)).Returns(15);

            var isValid = encounterVerifier.EncounterIsValid(encounter, new[] { Filter, "other filter" });
            Assert.That(isValid, Is.True);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        [TestCase(31)]
        public void EncounterFromCreaturesIsNotValidIfLevelInvalid(int level)
        {
            var encounter = new Encounter();
            encounter.Creatures = new[]
            {
                new Creature { Type = new CreatureType { Name = "creature" }, Quantity = 9266 },
                new Creature { Type = new CreatureType { Name = "other creature" }, Quantity = 90210 },
            };

            mockAmountSelector.Setup(s => s.Select(encounter)).Returns(level);

            var isValid = encounterVerifier.EncounterIsValid(encounter, specifications.CreatureTypeFilters);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterFromCreaturesIsNotValidIfNoCreatures()
        {
            var encounter = new Encounter();
            var isValid = encounterVerifier.EncounterIsValid(encounter, specifications.CreatureTypeFilters);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void CreatureIsValidIfNoFiltersAreProvided()
        {
            var isValid = encounterVerifier.CreatureIsValid("bogus creature", specifications.CreatureTypeFilters);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfWithinFilterGroup()
        {
            var isValid = encounterVerifier.CreatureIsValid("creature", new[] { Filter });
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsNotValidIfOutsideFilterGroup()
        {
            var isValid = encounterVerifier.CreatureIsValid("wrong creature", new[] { Filter });
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void CreatureIsValidIfAnyFilterMatches()
        {
            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "additional filter")).Returns(additionalFilterGroup);

            var isValid = encounterVerifier.CreatureIsValid("creature", new[] { Filter, "additional filter" });
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsNotValidIfNoFilterMatches()
        {
            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "additional filter")).Returns(additionalFilterGroup);

            var isValid = encounterVerifier.CreatureIsValid("wrong creature", new[] { Filter, "additional filter" });
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void CreatureIsValidIfCreatureWithDescriptionMatches()
        {
            filterGroup.Remove("creature");
            filterGroup.Add("creature (description)");

            var isValid = encounterVerifier.CreatureIsValid("creature (description)", new[] { Filter });
            Assert.That(isValid, Is.True);
        }
    }
}
