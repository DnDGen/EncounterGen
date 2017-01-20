using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
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
        private List<string> specificEncounters;
        private List<string> landEncounters;
        private List<string> dragonEncounters;
        private Dictionary<string, List<string>> filters;
        private List<string> wildernessEncounters;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockAmountSelector = new Mock<IAmountSelector>();
            mockEncounterSelector = new Mock<IEncounterSelector>();
            encounterCollectionSelector = new EncounterCollectionSelector(mockCollectionSelector.Object, mockAmountSelector.Object, mockEncounterSelector.Object);

            levelEncounters = new List<string>();
            environmentEncounters = new List<string> { "encounter/amount", "environment encounter/environment amount" };
            temperatureEncounters = new List<string> { "encounter/amount", "temperature encounter/temperature amount" };
            timeOfDayEncounters = new List<string> { "encounter/amount", "time of day encounter/time of day amount" };
            magicEncounters = new List<string> { "encounter/amount", "magic encounter/magic amount" };
            specificEncounters = new List<string> { "specific encounter/specific amount", "other specific encounter/other specific amount" };
            landEncounters = new List<string> { "encounter/amount", "land encounter/land amount" };
            dragonEncounters = new List<string> { "encounter/amount", "dragon encounter/dragon amount" };
            filters = new Dictionary<string, List<string>>();
            wildernessEncounters = new List<string>();

            levelEncounters.Add("encounter/amount");
            levelEncounters.Add("encounter/level amount");

            filters["filter"] = new List<string>();
            filters["other filter"] = new List<string>();

            mockAmountSelector.Setup(s => s.SelectAverageEncounterLevel(It.IsAny<string>())).Returns((string e) => GetLevel(e));

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, environment, TableNameConstants.EncounterGroups)).Returns(environmentEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature, TableNameConstants.EncounterGroups)).Returns(temperatureEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, timeOfDay, TableNameConstants.EncounterGroups)).Returns(timeOfDayEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, GroupConstants.Magic, TableNameConstants.EncounterGroups)).Returns(magicEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, string.Empty, TableNameConstants.EncounterGroups)).Returns(Enumerable.Empty<string>());
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + environment, TableNameConstants.EncounterGroups)).Returns(specificEncounters);
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
        public void GetEncounterTypesAndAmountsFromSelector()
        {
            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(level, environment, temperature, timeOfDay);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "encounter", "amount");
        }

        [Test]
        public void ThrowExceptionIfNoEncountersExist()
        {
            levelEncounters.Clear();

            Assert.That(() => encounterCollectionSelector.SelectRandomFrom(level, environment, temperature, timeOfDay),
                Throws.ArgumentException.With.Message.EqualTo($"No valid level {level} encounters exist for {temperature} {environment} {timeOfDay}"));
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

            environmentEncounters.Add("other encounter/other amount");
            environmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("other encounter/other amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("other encounter/other amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(level, environment, temperature, timeOfDay);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "other encounter", "other amount");
        }

        [Test]
        public void GetMultipleEncounterTypesAndAmountsFromSelector()
        {
            levelEncounters.Add("other encounter/other amount,encounter/amount");
            levelEncounters.Add("other encounter/level amount");
            environmentEncounters.Add("other encounter/other amount,encounter/amount");
            environmentEncounters.Add("environment encounter/other amount");
            temperatureEncounters.Add("other encounter/other amount,encounter/amount");
            temperatureEncounters.Add("temperature encounter/other amount");
            timeOfDayEncounters.Add("other encounter/other amount,encounter/amount");
            timeOfDayEncounters.Add("time of day encounter/other amount");

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(level, environment, temperature, timeOfDay);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "encounter", "amount", "other encounter", "other amount");
        }

        [Test]
        public void SelectRandomThrowsExceptionIfNoEncounters()
        {
            levelEncounters.Clear();
            Assert.That(() => encounterCollectionSelector.SelectRandomFrom(level, environment, temperature, timeOfDay), Throws.Exception);
        }

        [Test]
        public void SingleWeightMagicalEncounters()
        {
            levelEncounters.Add(magicEncounters[1]);
            timeOfDayEncounters.Add(magicEncounters[1]);

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "magic encounter", "magic amount",
                "encounter", "amount",
                "encounter", "amount"
            };

            AssertEncounterWeight(expectedEncounters);
        }

        private void AssertEncounterWeight(IEnumerable<string> expectedEncounters, string targetEnvironment = environment)
        {
            var expectedArray = expectedEncounters.ToArray();
            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(level, targetEnvironment, temperature, timeOfDay).ToArray();

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
            levelEncounters.Add(dragonEncounters[1]);
            timeOfDayEncounters.Add(dragonEncounters[1]);

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "dragon encounter", "dragon amount",
                "encounter", "amount",
                "encounter", "amount"
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void DoubleWeightLandEncounters()
        {
            levelEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[1]);

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "land encounter", "land amount",
                "land encounter", "land amount",
                "encounter", "amount",
                "encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void TripleWeightEnvironmentEncounters()
        {
            levelEncounters.Add(environmentEncounters[1]);
            timeOfDayEncounters.Add(environmentEncounters[1]);

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "environment encounter", "environment amount",
                "environment encounter", "environment amount",
                "encounter", "amount",
                "environment encounter", "environment amount",
                "encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void TripleWeightTemperatureEncounters()
        {
            levelEncounters.Add(temperatureEncounters[1]);
            timeOfDayEncounters.Add(temperatureEncounters[1]);

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "temperature encounter", "temperature amount",
                "temperature encounter", "temperature amount",
                "encounter", "amount",
                "encounter", "amount",
                "temperature encounter", "temperature amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void QuadrupleWeightSpecificEncounters()
        {
            levelEncounters.Add(specificEncounters[0]);
            timeOfDayEncounters.Add(specificEncounters[0]);

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "specific encounter", "specific amount",
                "specific encounter", "specific amount",
                "encounter", "amount",
                "encounter", "amount",
                "specific encounter", "specific amount",
                "specific encounter", "specific amount",
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

            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[1]);
            levelEncounters.Add(civilizedEncounters[0]);
            levelEncounters.Add(specificCivilizedEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(dragonEncounters[1]);
            timeOfDayEncounters.Add(temperatureEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(magicEncounters[1]);
            wildernessEncounters.Add(landEncounters[1]);
            wildernessEncounters.Add(dragonEncounters[1]);
            wildernessEncounters.Add(temperatureEncounters[1]);

            var expectedEncounters = new[]
            {
                "civilized encounter", "amount",
                "civilized encounter", "amount",
                "civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized);
        }

        [Test]
        public void IfCivilized_WeightNonWildernessEncountersAppropriately()
        {
            var civilizedEncounters = new[] { "civilized encounter/amount", "other civilized encounter/other amount" };
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(civilizedEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(specificCivilizedEncounters);

            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[1]);
            levelEncounters.Add(civilizedEncounters[0]);
            levelEncounters.Add(specificCivilizedEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(dragonEncounters[1]);
            timeOfDayEncounters.Add(temperatureEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(dragonEncounters[1]);
            wildernessEncounters.Add(temperatureEncounters[1]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "land encounter", "land amount",
                "civilized encounter", "amount",
                "land encounter", "land amount",
                "civilized encounter", "amount",
                "civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized);
        }

        [Test]
        public void IfDungeon_IgnoreTimeOfDayFilter()
        {
            var dungeonEncounters = new[] { "dungeon encounter/amount", "other dungeon encounter/other amount" };
            var specificDungeonEncounters = new[] { "specific dungeon encounter/amount", "other specific dungeon encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Dungeon, TableNameConstants.EncounterGroups)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Dungeon, TableNameConstants.EncounterGroups)).Returns(specificDungeonEncounters);

            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[1]);
            levelEncounters.Add(dungeonEncounters[0]);
            levelEncounters.Add(specificDungeonEncounters[0]);

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "magic encounter", "magic amount",
                "dragon encounter", "dragon amount",
                "land encounter", "land amount",
                "dungeon encounter", "amount",
                "temperature encounter", "temperature amount",
                "specific dungeon encounter", "amount",
                "land encounter", "land amount",
                "dungeon encounter", "amount",
                "temperature encounter", "temperature amount",
                "specific dungeon encounter", "amount",
                "dungeon encounter", "amount",
                "encounter", "amount",
                "temperature encounter", "temperature amount",
                "specific dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Dungeon);
        }

        [Test]
        public void GetAllPossibleWeightedEncounters()
        {
            levelEncounters.Add("other encounter/other amount");
            levelEncounters.Add("other encounter/level amount");
            environmentEncounters.Add("other encounter/other amount");
            temperatureEncounters.Add("temperature encounter/other amount");
            timeOfDayEncounters.Add("other encounter/other amount");

            var allEncounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(level, environment, temperature, timeOfDay);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Null);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Empty);
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(6));

            var array = allEncounterTypesAndAmounts.ToArray();
            AssertTypesAndAmounts(array[0], "Index 0", "encounter", "amount");
            AssertTypesAndAmounts(array[1], "Index 1", "other encounter", "other amount");
            AssertTypesAndAmounts(array[2], "Index 2", "other encounter", "other amount");
            AssertTypesAndAmounts(array[3], "Index 3", "encounter", "amount");
            AssertTypesAndAmounts(array[4], "Index 4", "other encounter", "other amount");
            AssertTypesAndAmounts(array[5], "Index 5", "encounter", "amount");
        }

        [Test]
        public void GetAllPossibleWeightedCivilizedEncounters()
        {
            var civilizedEncounters = new[] { "civilized encounter/amount", "other civilized encounter/other amount" };
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(civilizedEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(specificCivilizedEncounters);

            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(civilizedEncounters[0]);
            levelEncounters.Add(civilizedEncounters[1]);
            levelEncounters.Add(specificCivilizedEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(dragonEncounters[1]);
            timeOfDayEncounters.Add(temperatureEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(magicEncounters[1]);
            wildernessEncounters.Add(landEncounters[1]);
            wildernessEncounters.Add(dragonEncounters[1]);
            wildernessEncounters.Add(temperatureEncounters[1]);

            var allEncounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(level, EnvironmentConstants.Civilized, temperature, timeOfDay);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Null);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Empty);
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(3));

            var array = allEncounterTypesAndAmounts.ToArray();
            AssertTypesAndAmounts(array[0], "Index 0", "civilized encounter", "amount");
            AssertTypesAndAmounts(array[1], "Index 1", "civilized encounter", "amount");
            AssertTypesAndAmounts(array[2], "Index 2", "civilized encounter", "amount");
        }

        [Test]
        public void GetAllPossibleWeightedDungeonEncounters()
        {
            var dungeonEncounters = new[] { "dungeon encounter/amount", "other dungeon encounter/other amount" };
            var specificDungeonEncounters = new[] { "specific dungeon encounter/amount", "other specific dungeon encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Dungeon, TableNameConstants.EncounterGroups)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Dungeon, TableNameConstants.EncounterGroups)).Returns(specificDungeonEncounters);

            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dragonEncounters[1]);
            levelEncounters.Add(temperatureEncounters[1]);
            levelEncounters.Add(dungeonEncounters[0]);
            levelEncounters.Add(specificDungeonEncounters[0]);

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "magic encounter", "magic amount",
                "dragon encounter", "dragon amount",
                "land encounter", "land amount",
                "dungeon encounter", "amount",
                "temperature encounter", "temperature amount",
                "specific dungeon encounter", "amount",
                "land encounter", "land amount",
                "dungeon encounter", "amount",
                "temperature encounter", "temperature amount",
                "specific dungeon encounter", "amount",
                "dungeon encounter", "amount",
                "encounter", "amount",
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
            var allEncounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(level, environment, temperature, timeOfDay);
            Assert.That(allEncounterTypesAndAmounts, Is.Empty);
        }

        [Test]
        public void ApplyFiltersToRandomEncounter()
        {
            environmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            filters["filter"].Add("encounter");

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(level, environment, temperature, timeOfDay, "filter");
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "encounter", "amount");
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

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(level, environment, temperature, timeOfDay, "filter");
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

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(level, environment, temperature, timeOfDay, "filter", "other filter");
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "other encounter", "other amount");
        }

        [Test]
        public void ApplyFiltersToAllWeightedEncounters()
        {
            environmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            filters["filter"].Add("encounter");

            var allEncounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(level, environment, temperature, timeOfDay, "filter").ToArray();
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(3));

            AssertTypesAndAmounts(allEncounterTypesAndAmounts[0], "Index 0", "encounter", "amount");
            AssertTypesAndAmounts(allEncounterTypesAndAmounts[1], "Index 1", "encounter", "amount");
            AssertTypesAndAmounts(allEncounterTypesAndAmounts[2], "Index 2", "encounter", "amount");
        }
    }
}
