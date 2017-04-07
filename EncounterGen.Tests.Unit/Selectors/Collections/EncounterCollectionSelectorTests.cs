using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class EncounterCollectionSelectorTests
    {
        private const string environment = "environment";
        private const string temperature = "temperature";
        private const string timeOfDay = "time of day";
        private const int level = 9266;

        private IEncounterCollectionSelector encounterCollectionSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<IAmountSelector> mockAmountSelector;
        private Mock<IEncounterSelector> mockEncounterSelector;
        private List<string> levelEncounters;
        private List<string> environmentEncounters;
        private List<string> temperatureEncounters;
        private List<string> timeOfDayEncounters;
        private List<string> magicEncounters;
        private List<string> specificEnvironmentEncounters;
        private List<string> landEncounters;
        private List<string> dragonEncounters;
        private Dictionary<string, List<string>> filters;
        private List<string> wildernessEncounters;
        private EncounterSpecifications specifications;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockAmountSelector = new Mock<IAmountSelector>();
            mockEncounterSelector = new Mock<IEncounterSelector>();
            encounterCollectionSelector = new EncounterCollectionSelector(mockCollectionSelector.Object, mockAmountSelector.Object, mockEncounterSelector.Object);

            levelEncounters = new List<string>();
            timeOfDayEncounters = new List<string>();
            environmentEncounters = new List<string> { "environment encounter/environment amount", "other environment encounter/other environment amount" };
            temperatureEncounters = new List<string> { "temperature encounter/temperature amount", "other temperature encounter/other temperature amount" };
            magicEncounters = new List<string> { "magic encounter/magic amount", "other magic encounter/other magic amount" };
            specificEnvironmentEncounters = new List<string> { "specific environment encounter/specific environment amount", "other specific environment encounter/other specific environment amount" };
            landEncounters = new List<string> { "land encounter/land amount", "other land encounter/other land amount" };
            dragonEncounters = new List<string> { "dragon encounter/dragon amount", "other dragon encounter/other dragon amount" };
            filters = new Dictionary<string, List<string>>();
            wildernessEncounters = new List<string>();
            specifications = new EncounterSpecifications();

            levelEncounters.Add(environmentEncounters[0]);
            levelEncounters.Add("level encounter/level amount");

            timeOfDayEncounters.Add(environmentEncounters[0]);
            timeOfDayEncounters.Add("time of day encounter/time of day amount");

            filters["filter"] = new List<string>();
            filters["other filter"] = new List<string>();

            specifications.Environment = environment;
            specifications.Level = level;
            specifications.Temperature = temperature;
            specifications.TimeOfDay = timeOfDay;

            mockAmountSelector.Setup(s => s.SelectAverageEncounterLevel(It.IsAny<string>())).Returns((string e) => GetLevel(e));

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, environment, TableNameConstants.EncounterGroups)).Returns(environmentEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature, TableNameConstants.EncounterGroups)).Returns(temperatureEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, timeOfDay, TableNameConstants.EncounterGroups)).Returns(timeOfDayEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, GroupConstants.Magic, TableNameConstants.EncounterGroups)).Returns(magicEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, string.Empty, TableNameConstants.EncounterGroups)).Returns(Enumerable.Empty<string>());
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + environment, TableNameConstants.EncounterGroups)).Returns(specificEnvironmentEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, GroupConstants.Land, TableNameConstants.EncounterGroups)).Returns(landEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, GroupConstants.Wilderness, TableNameConstants.EncounterGroups)).Returns(wildernessEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, CreatureConstants.Types.Dragon, TableNameConstants.EncounterGroups)).Returns(dragonEncounters);

            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "filter")).Returns(filters["filter"]);
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "other filter")).Returns(filters["other filter"]);

            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>())).Returns((IEnumerable<Dictionary<string, string>> collection) => collection.Last());

            mockEncounterSelector.Setup(s => s.SelectCreaturesAndAmountsFrom(It.IsAny<string>())).Returns((string e) => ParseCreatureAndAmount(e));
        }

        private Dictionary<string, string> ParseCreatureAndAmount(string encounter)
        {
            return encounter.Split(',').ToDictionary(e => e.Split('/')[0], e => e.Split('/')[1]);
        }

        private int GetLevel(string encounter)
        {
            if (levelEncounters.Contains(encounter))
                return level;

            return -1;
        }

        [Test]
        public void SelectingRandomGetsEncounterTypesAndAmountsFromSelector()
        {
            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "environment encounter", "environment amount");
        }

        [Test]
        public void IfSelectingRandomAndNoEncountersExist_ThrowException()
        {
            levelEncounters.Clear();

            Assert.That(() => encounterCollectionSelector.SelectRandomFrom(specifications),
                Throws.ArgumentException.With.Message.EqualTo($"No valid encounters exist for {specifications.Description}"));
        }

        private void AssertTypesAndAmounts(Dictionary<string, string> actual, string failureMessage, params string[] expected)
        {
            Assert.That(expected.Length % 2, Is.EqualTo(0), failureMessage);
            Assert.That(actual, Is.Not.Null, failureMessage);
            Assert.That(actual, Is.Not.Empty, failureMessage);
            Assert.That(actual.Count, Is.EqualTo(expected.Length / 2), failureMessage);

            for (var i = 0; i < expected.Length; i += 2)
            {
                Assert.That(actual.Keys, Contains.Item(expected[i]), failureMessage);
                Assert.That(actual[expected[i]], Is.EqualTo(expected[i + 1]), failureMessage);
            }
        }

        [Test]
        public void GetRandomEncounterTypesAndAmountsFromSelector()
        {
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>())).Returns((IEnumerable<Dictionary<string, string>> collection) => collection.ElementAt(1));

            environmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add(environmentEncounters[1]);
            levelEncounters.Add(environmentEncounters[2]);
            timeOfDayEncounters.Add(environmentEncounters[1]);
            timeOfDayEncounters.Add(environmentEncounters[2]);

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "other environment encounter", "other environment amount");
        }

        [Test]
        public void GetMultipleRandomEncounterTypesAndAmountsFromSelector()
        {
            environmentEncounters.Add("other encounter/other amount,encounter/amount");
            levelEncounters.Add("other encounter/other amount,encounter/amount");
            timeOfDayEncounters.Add("other encounter/other amount,encounter/amount");

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "encounter", "amount", "other encounter", "other amount");
        }

        [Test]
        public void SingleWeightMagicalEncounters()
        {
            levelEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[0]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "environment encounter", "environment amount",
                "environment encounter", "environment amount",
                "environment encounter", "environment amount"
            };

            AssertEncounterWeight(expectedEncounters);
        }

        private void AssertEncounterWeight(IEnumerable<string> expectedEncounters, string targetEnvironment = environment, bool allowAquatic = false)
        {
            specifications.Environment = targetEnvironment;
            specifications.AllowAquatic = allowAquatic;

            var expectedArray = expectedEncounters.ToArray();
            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications).ToArray();

            for (var i = 0; i < expectedArray.Length; i += 2)
            {
                var index = i / 2;
                var failureMessage = $"Index {index}";

                AssertTypesAndAmounts(weightedEncounters[index], failureMessage, expectedArray[i], expectedArray[i + 1]);
            }

            Assert.That(weightedEncounters.Length, Is.EqualTo(expectedArray.Length / 2));
        }

        [Test]
        public void SingleWeightDragonEncounters()
        {
            levelEncounters.Add(dragonEncounters[0]);
            timeOfDayEncounters.Add(dragonEncounters[0]);

            var expectedEncounters = new[]
            {
                "environment encounter", "environment amount",
                "dragon encounter", "dragon amount",
                "environment encounter", "environment amount",
                "environment encounter", "environment amount"
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void DoubleWeightLandEncounters()
        {
            levelEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);

            var expectedEncounters = new[]
            {
                "environment encounter", "environment amount",
                "land encounter", "land amount",
                "environment encounter", "environment amount",
                "land encounter", "land amount",
                "environment encounter", "environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void DoubleWeightAdditionalAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "environment encounter", "environment amount",
                "aquatic encounter", "amount",
                "environment encounter", "environment amount",
                "aquatic encounter", "amount",
                "environment encounter", "environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
        }

        [Test]
        public void TripleWeightAdditionalSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "environment encounter", "environment amount",
                "specific aquatic encounter", "amount",
                "environment encounter", "environment amount",
                "specific aquatic encounter", "amount",
                "environment encounter", "environment amount",
                "specific aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
        }

        [Test]
        public void TripleWeightEnvironmentEncounters()
        {
            var expectedEncounters = new[]
            {
                "environment encounter", "environment amount",
                "environment encounter", "environment amount",
                "environment encounter", "environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void TripleWeightTemperatureEncounters()
        {
            levelEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);

            var expectedEncounters = new[]
            {
                "environment encounter", "environment amount",
                "temperature encounter", "temperature amount",
                "environment encounter", "environment amount",
                "temperature encounter", "temperature amount",
                "environment encounter", "environment amount",
                "temperature encounter", "temperature amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void QuadrupleWeightSpecificEncounters()
        {
            levelEncounters.Add(specificEnvironmentEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            var expectedEncounters = new[]
            {
                "environment encounter", "environment amount",
                "specific environment encounter", "specific environment amount",
                "environment encounter", "environment amount",
                "specific environment encounter", "specific environment amount",
                "environment encounter", "environment amount",
                "specific environment encounter", "specific environment amount",
                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void IfCivilized_DoNotGetWildlife()
        {
            var civilizedEncounters = new[] { "civilized encounter/amount", "other civilized encounter/other amount" };
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(civilizedEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(specificCivilizedEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(temperatureEncounters[1]);
            levelEncounters.Add(civilizedEncounters[0]);
            levelEncounters.Add(specificCivilizedEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(dragonEncounters[0]);
            timeOfDayEncounters.Add(dragonEncounters[1]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(dragonEncounters[0]);
            wildernessEncounters.Add(temperatureEncounters[0]);

            var expectedEncounters = new[]
            {
                "other magic encounter", "other magic amount",
                "civilized encounter", "amount",
                "specific civilized encounter", "amount",
                "other dragon encounter", "other dragon amount",
                "other land encounter", "other land amount",
                "other temperature encounter", "other temperature amount",
                "civilized encounter", "amount",
                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",
                "other temperature encounter", "other temperature amount",
                "civilized encounter", "amount",
                "other temperature encounter", "other temperature amount",
                "specific civilized encounter", "amount",
                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized);
        }

        [Test]
        public void IfDungeon_SetTimeOfDayToNight()
        {
            var dungeonEncounters = new[] { "dungeon encounter/amount", "other dungeon encounter/other amount" };
            var specificDungeonEncounters = new[] { "specific dungeon encounter/amount", "other specific dungeon encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Dungeon, TableNameConstants.EncounterGroups)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Dungeon, TableNameConstants.EncounterGroups)).Returns(specificDungeonEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(temperatureEncounters[1]);
            levelEncounters.Add(dungeonEncounters[0]);
            levelEncounters.Add(specificDungeonEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(dragonEncounters[0]);
            nightEncounters.Add(temperatureEncounters[0]);
            nightEncounters.Add(dungeonEncounters[0]);
            nightEncounters.Add(specificDungeonEncounters[0]);

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
                "dragon encounter", "dragon amount",
                "land encounter", "land amount",
                "temperature encounter", "temperature amount",
                "dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
                "land encounter", "land amount",
                "temperature encounter", "temperature amount",
                "dungeon encounter", "amount",
                "temperature encounter", "temperature amount",
                "specific dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Dungeon);
        }

        [Test]
        public void GetAllPossibleWeightedEncounters()
        {
            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(specificEnvironmentEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(dragonEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "environment encounter", "environment amount",
                "specific environment encounter", "specific environment amount",
                "dragon encounter", "dragon amount",
                "land encounter", "land amount",
                "temperature encounter", "temperature amount",
                "environment encounter", "environment amount",
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "temperature encounter", "temperature amount",
                "environment encounter", "environment amount",
                "temperature encounter", "temperature amount",
                "specific environment encounter", "specific environment amount",
                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void GetAllPossibleWeightedCivilizedEncounters()
        {
            var civilizedEncounters = new[] { "civilized encounter/amount", "other civilized encounter/other amount" };
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(civilizedEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(specificCivilizedEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(temperatureEncounters[1]);
            levelEncounters.Add(civilizedEncounters[0]);
            levelEncounters.Add(specificCivilizedEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(dragonEncounters[0]);
            timeOfDayEncounters.Add(dragonEncounters[1]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(dragonEncounters[0]);
            wildernessEncounters.Add(temperatureEncounters[0]);

            var expectedEncounters = new[]
            {
                "other magic encounter", "other magic amount",
                "civilized encounter", "amount",
                "specific civilized encounter", "amount",
                "other dragon encounter", "other dragon amount",
                "other land encounter", "other land amount",
                "other temperature encounter", "other temperature amount",
                "civilized encounter", "amount",
                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",
                "other temperature encounter", "other temperature amount",
                "civilized encounter", "amount",
                "other temperature encounter", "other temperature amount",
                "specific civilized encounter", "amount",
                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized);
        }

        [Test]
        public void GetAllPossibleWeightedDungeonEncounters()
        {
            var dungeonEncounters = new[] { "dungeon encounter/amount", "other dungeon encounter/other amount" };
            var specificDungeonEncounters = new[] { "specific dungeon encounter/amount", "other specific dungeon encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Dungeon, TableNameConstants.EncounterGroups)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Dungeon, TableNameConstants.EncounterGroups)).Returns(specificDungeonEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(temperatureEncounters[1]);
            levelEncounters.Add(dungeonEncounters[0]);
            levelEncounters.Add(specificDungeonEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(dragonEncounters[0]);
            nightEncounters.Add(temperatureEncounters[0]);
            nightEncounters.Add(dungeonEncounters[0]);
            nightEncounters.Add(specificDungeonEncounters[0]);

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
                "dragon encounter", "dragon amount",
                "land encounter", "land amount",
                "temperature encounter", "temperature amount",
                "dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
                "land encounter", "land amount",
                "temperature encounter", "temperature amount",
                "dungeon encounter", "amount",
                "temperature encounter", "temperature amount",
                "specific dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Dungeon);
        }

        [Test]
        public void SelectAllWeightedReturnsNoEncounters()
        {
            levelEncounters.Clear();
            var allEncounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(allEncounterTypesAndAmounts, Is.Empty);
        }

        [Test]
        public void ApplyFiltersToRandomEncounter()
        {
            environmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            filters["filter"].Add("environment encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "environment encounter", "environment amount");
        }

        [Test]
        public void EncounterMatchesIfAnyCreatureMatchesFilter()
        {
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>())).Returns((IEnumerable<Dictionary<string, string>> collection) => collection.ElementAt(1));

            environmentEncounters.Add("wrong encounter/wrong amount");
            environmentEncounters.Add("other encounter/other amount,encounter/amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("other encounter/other amount,encounter/amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("other encounter/other amount,encounter/amount");

            filters["filter"].Add("encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "other encounter", "other amount", "encounter", "amount");
        }

        [Test]
        public void EncounterMatchesIfCreatureMatchesAnyFilter()
        {
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>())).Returns((IEnumerable<Dictionary<string, string>> collection) => collection.ElementAt(1));

            environmentEncounters.Add("wrong encounter/wrong amount");
            environmentEncounters.Add("other encounter/other amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("other encounter/other amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("other encounter/other amount");

            filters["filter"].Add("encounter");
            filters["other filter"].Add("other encounter");

            specifications.CreatureTypeFilters = new[] { "filter", "other filter" };

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "other encounter", "other amount");
        }

        [Test]
        public void ApplyFiltersToAllWeightedEncounters()
        {
            environmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            filters["filter"].Add("environment encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var allEncounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(specifications).ToArray();
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(3));

            AssertTypesAndAmounts(allEncounterTypesAndAmounts[0], "Index 0", "environment encounter", "environment amount");
            AssertTypesAndAmounts(allEncounterTypesAndAmounts[1], "Index 1", "environment encounter", "environment amount");
            AssertTypesAndAmounts(allEncounterTypesAndAmounts[2], "Index 2", "environment encounter", "environment amount");
        }

        [Test]
        public void AquaticEnvironmentDoesNotHaveNonAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(dragonEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Aquatic);
        }

        [Test]
        public void CanAddAquaticToAnEnvironment()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(specificEnvironmentEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(dragonEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(specifications);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "environment encounter", "environment amount",
                "specific environment encounter", "specific environment amount",
                "dragon encounter", "dragon amount",
                "land encounter", "land amount",
                "temperature encounter", "temperature amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "environment encounter", "environment amount",
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "temperature encounter", "temperature amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "environment encounter", "environment amount",
                "temperature encounter", "temperature amount",
                "specific aquatic encounter", "amount",
                "specific environment encounter", "specific environment amount",
                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
        }

        [Test]
        public void AddingAquaticToAquatic()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(dragonEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Aquatic, true);
        }

        [Test]
        public void AddAquaticToDungeon()
        {
            var dungeonEncounters = new[] { "dungeon encounter/amount", "other dungeon encounter/other amount" };
            var specificDungeonEncounters = new[] { "specific dungeon encounter/amount", "other specific dungeon encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Dungeon, TableNameConstants.EncounterGroups)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Dungeon, TableNameConstants.EncounterGroups)).Returns(specificDungeonEncounters);

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(temperatureEncounters[1]);
            levelEncounters.Add(dungeonEncounters[0]);
            levelEncounters.Add(specificDungeonEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(aquaticEncounters[1]);
            levelEncounters.Add(specificAquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[1]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(dragonEncounters[0]);
            nightEncounters.Add(temperatureEncounters[0]);
            nightEncounters.Add(dungeonEncounters[0]);
            nightEncounters.Add(specificDungeonEncounters[0]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[0]);

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
                "dragon encounter", "dragon amount",
                "land encounter", "land amount",
                "temperature encounter", "temperature amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
                "land encounter", "land amount",
                "temperature encounter", "temperature amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "dungeon encounter", "amount",
                "temperature encounter", "temperature amount",
                "specific aquatic encounter", "amount",
                "specific dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Dungeon, true);
        }

        [Test]
        public void AddAquaticToCivilized()
        {
            var civilizedEncounters = new[] { "civilized encounter/amount", "other civilized encounter/other amount" };
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(civilizedEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(specificCivilizedEncounters);

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(temperatureEncounters[1]);
            levelEncounters.Add(civilizedEncounters[0]);
            levelEncounters.Add(specificCivilizedEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(aquaticEncounters[1]);
            levelEncounters.Add(specificAquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[1]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(dragonEncounters[0]);
            timeOfDayEncounters.Add(dragonEncounters[1]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[1]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[1]);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(dragonEncounters[0]);
            wildernessEncounters.Add(temperatureEncounters[0]);
            wildernessEncounters.Add(aquaticEncounters[0]);
            wildernessEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "other magic encounter", "other magic amount",
                "civilized encounter", "amount",
                "specific civilized encounter", "amount",
                "other dragon encounter", "other dragon amount",
                "other land encounter", "other land amount",
                "other temperature encounter", "other temperature amount",
                "civilized encounter", "amount",
                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",
                "other temperature encounter", "other temperature amount",
                "civilized encounter", "amount",
                "other temperature encounter", "other temperature amount",
                "specific civilized encounter", "amount",
                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized);
        }
    }
}
