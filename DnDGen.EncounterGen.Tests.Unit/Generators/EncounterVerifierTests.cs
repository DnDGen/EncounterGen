using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Selectors.Collections;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Unit.Generators
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
            var isValid = encounterVerifier.ValidEncounterExists(specifications);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void ValidEncounterExistsIfAnyCreaturesInEncounterWithFilter()
        {
            specifications.CreatureTypeFilters = new[] { Filter };
            SetupCreaturesAndAmountsWithFilters(Level);

            var isValid = encounterVerifier.ValidEncounterExists(specifications);
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

            var isValid = encounterVerifier.ValidEncounterExists(specifications);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void ValidEncounterDoesNotExistAtLevelIfNoCreaturesAvailable()
        {
            specifications.CreatureTypeFilters = new[] { Filter };
            SetupCreaturesAndAmounts(Level - 1);

            var isValid = encounterVerifier.ValidEncounterExists(specifications);
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

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void ValidEncounterExists_ReturnsTrue_WhenThereIsAnEncounter(bool aquatic, bool underground)
        {
            mockEncounterCollectionSelector
                .Setup(s => s.SelectPossibleFrom("environment", "temperature", "time of day", 9266, aquatic, underground, "filter 1", "filter 2"))
                .Returns(new[]
                {
                    new Dictionary<string, string>
                    {
                        { "my creature", "my amount" }
                    }
                });

            var exists = encounterVerifier.ValidEncounterExists("environment", "temperature", "time of day", 9266, aquatic, underground, "filter 1", "filter 2");
            Assert.That(exists, Is.True);
        }

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void ValidEncounterExists_ReturnsFalse_WhenThereIsNoEncounter(bool aquatic, bool underground)
        {
            mockEncounterCollectionSelector
                .Setup(s => s.SelectPossibleFrom("environment", "temperature", "time of day", 9266, aquatic, underground, "filter 1", "filter 2"))
                .Returns(Enumerable.Empty<Dictionary<string, string>>());

            var exists = encounterVerifier.ValidEncounterExists("environment", "temperature", "time of day", 9266, aquatic, underground, "filter 1", "filter 2");
            Assert.That(exists, Is.False);
        }

        [Test]
        public void GetValidTemperatues_ReturnsPossibleTemperatures()
        {
            var possibleTemps = new[] { "temp 1", "temp 2" };
            mockEncounterCollectionSelector
                .Setup(s => s.SelectPossibleTemperatures("environment"))
                .Returns(possibleTemps);

            var temperatures = encounterVerifier.GetValidTemperatues("environment");
            Assert.That(temperatures, Is.EqualTo(possibleTemps));
        }

        [Test]
        public void GetValidTimesOfDay_ReturnsPossibleTimesOfDay()
        {
            var possibleTimesOfDay = new[] { "time 1", "time 2" };
            mockEncounterCollectionSelector
                .Setup(s => s.SelectPossibleTimesOfDay("environment", "temperature"))
                .Returns(possibleTimesOfDay);

            var timesOfDay = encounterVerifier.GetValidTimesOfDay("environment", "temperature");
            Assert.That(timesOfDay, Is.EqualTo(possibleTimesOfDay));
        }

        [Test]
        public void GetValidLevels_ReturnsPossibleLevels()
        {
            var possibleLevels = new[] { 9266, 90210 };
            mockEncounterCollectionSelector
                .Setup(s => s.SelectPossibleLevels("environment", "temperature", "time of day"))
                .Returns(possibleLevels);

            var levels = encounterVerifier.GetValidLevels("environment", "temperature", "time of day");
            Assert.That(levels, Is.EqualTo(possibleLevels));
        }

        [TestCase]
        [TestCase(true)]
        [TestCase(false)]
        [TestCase(true, false)]
        public void GetValidAllowAquatic_ReturnsPossibleAllowAquatic(params bool[] possibleAquatic)
        {
            mockEncounterCollectionSelector
                .Setup(s => s.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266))
                .Returns(possibleAquatic);

            var aquatic = encounterVerifier.GetValidAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(aquatic, Is.EqualTo(possibleAquatic));
        }

        [TestCase(true)]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(true, true, false)]
        [TestCase(false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        [TestCase(false, true, false)]
        public void GetValidAllowUnderground_ReturnsPossibleAllowUnderground(bool aquatic, params bool[] possibleUnderground)
        {
            mockEncounterCollectionSelector
                .Setup(s => s.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, aquatic))
                .Returns(possibleUnderground);

            var underground = encounterVerifier.GetValidAllowUnderground("environment", "temperature", "time of day", 9266, aquatic);
            Assert.That(underground, Is.EqualTo(possibleUnderground));
        }

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void GetValidFilters_ReturnsPossibleFilters(bool aquatic, bool underground)
        {
            var possibleFilters = new[] { "filter 1", "filter 2" };
            mockEncounterCollectionSelector
                .Setup(s => s.SelectPossibleFilters("environment", "temperature", "time of day", 9266, aquatic, underground))
                .Returns(possibleFilters);

            var filters = encounterVerifier.GetValidFilters("environment", "temperature", "time of day", 9266, aquatic, underground);
            Assert.That(filters, Is.EqualTo(possibleFilters));
        }

        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public void GetValidFilters_ReturnsPossibleFilters_None(bool aquatic, bool underground)
        {
            var possibleFilters = Enumerable.Empty<string>();
            mockEncounterCollectionSelector
                .Setup(s => s.SelectPossibleFilters("environment", "temperature", "time of day", 9266, aquatic, underground))
                .Returns(possibleFilters);

            var filters = encounterVerifier.GetValidFilters("environment", "temperature", "time of day", 9266, aquatic, underground);
            Assert.That(filters, Is.Empty);
        }
    }
}
