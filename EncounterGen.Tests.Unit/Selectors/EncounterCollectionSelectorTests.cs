using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class EncounterCollectionSelectorTests
    {
        private const string environment = "environment";
        private const string temperature = "temperature";
        private const string timeOfDay = "time of day";
        private const int level = 9266;

        private IEncounterCollectionSelector creatureCollectionSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private List<string> levelEncounters;
        private List<string> environmentEncounters;
        private List<string> temperatureEncounters;
        private List<string> timeOfDayEncounters;
        private List<string> magicEncounters;
        private List<string> specificEncounters;
        private List<string> landEncounters;
        private List<string> dragonEncounters;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            creatureCollectionSelector = new EncounterCollectionSelector(mockCollectionSelector.Object);

            levelEncounters = new List<string>();
            environmentEncounters = new List<string>();
            temperatureEncounters = new List<string>();
            timeOfDayEncounters = new List<string>();
            magicEncounters = new List<string>();
            specificEncounters = new List<string>();
            landEncounters = new List<string>();
            dragonEncounters = new List<string>();

            environmentEncounters.Add("encounter/amount");
            environmentEncounters.Add("environment encounter/environment amount");
            temperatureEncounters.Add("temperature encounter/temperature amount");
            magicEncounters.Add("magic encounter/amount");
            landEncounters.Add("land encounter/amount");
            dragonEncounters.Add("dragon encounter/amount");

            levelEncounters.Add("encounter/amount");
            levelEncounters.Add("encounter/level amount");
            timeOfDayEncounters.Add("encounter/amount");
            timeOfDayEncounters.Add("time of day encounter/amount");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, level.ToString())).Returns(levelEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, environment)).Returns(environmentEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature)).Returns(temperatureEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, timeOfDay)).Returns(timeOfDayEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic)).Returns(magicEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, string.Empty)).Returns(Enumerable.Empty<string>());
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + environment)).Returns(specificEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land)).Returns(landEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Dragon)).Returns(dragonEncounters);

            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> collection) => collection.Last());
        }

        [Test]
        public void GetEncounterTypesAndAmountsFromSelector()
        {
            var encounterTypesAndAmounts = creatureCollectionSelector.SelectFrom(level, environment, temperature, timeOfDay);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "encounter", "amount");
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
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> collection) => collection.ElementAt(1));

            environmentEncounters.Add("other encounter/other amount");
            environmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("other encounter/other amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("other encounter/other amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            var encounterTypesAndAmounts = creatureCollectionSelector.SelectFrom(level, environment, temperature, timeOfDay);
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

            var encounterTypesAndAmounts = creatureCollectionSelector.SelectFrom(level, environment, temperature, timeOfDay);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "encounter", "amount", "other encounter", "other amount");
        }

        [Test]
        public void SingleWeightMagicalEncounters()
        {
            levelEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[0]);

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "magic encounter", "amount",
                "encounter", "amount",
                "encounter", "amount"
            };

            AssertEncounterWeight(expectedEncounters);
        }

        private void AssertEncounterWeight(IEnumerable<string> expectedEncounters, string targetEnvironment = environment)
        {
            var expectedArray = expectedEncounters.ToArray();

            for (var i = 0; i < expectedArray.Length; i += 2)
            {
                var passedCollection = Enumerable.Empty<string>();
                mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> collection) => GetItem(collection, i / 2, out passedCollection));

                var encounterTypesAndAmounts = creatureCollectionSelector.SelectFrom(level, targetEnvironment, temperature, timeOfDay);
                var failureMessage = $"Index {i / 2}";

                AssertTypesAndAmounts(encounterTypesAndAmounts, failureMessage, expectedArray[i], expectedArray[i + 1]);
                Assert.That(passedCollection.Count, Is.EqualTo(expectedArray.Length / 2), failureMessage);
            }
        }

        private string GetItem(IEnumerable<string> collection, int index, out IEnumerable<string> passedCollection)
        {
            passedCollection = collection;
            return collection.ElementAt(index);
        }

        [Test]
        public void SingleWeightDragonEncounters()
        {
            levelEncounters.Add(dragonEncounters[0]);
            timeOfDayEncounters.Add(dragonEncounters[0]);

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "dragon encounter", "amount",
                "encounter", "amount",
                "encounter", "amount"
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
                "encounter", "amount",
                "land encounter", "amount",
                "encounter", "amount",
                "land encounter", "amount",
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
                "encounter", "amount",
                "environment encounter", "environment amount",
                "encounter", "amount",
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
                "encounter", "amount",
                "temperature encounter", "temperature amount",
                "encounter", "amount",
                "temperature encounter", "temperature amount",
                "encounter", "amount",
                "temperature encounter", "temperature amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void QuadrupleWeightSpecificEncounters()
        {
            specificEncounters.Add("specific encounter/amount");
            levelEncounters.Add("specific encounter/amount");
            timeOfDayEncounters.Add("specific encounter/amount");

            var expectedEncounters = new[]
            {
                "encounter", "amount",
                "specific encounter", "amount",
                "encounter", "amount",
                "specific encounter", "amount",
                "encounter", "amount",
                "specific encounter", "amount",
                "specific encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void IfCivilized_DoNotGetWildlife()
        {
            var civilizedEncounters = new[] { "civilized encounter/amount" };
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Civilized)).Returns(civilizedEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Civilized)).Returns(specificCivilizedEncounters);

            //INFO: Wildlife is found in magic, land, specific (with temperature), and temperature encounters
            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(civilizedEncounters[0]);
            levelEncounters.Add(specificCivilizedEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(dragonEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            var expectedEncounters = new[]
            {
                "civilized encounter", "amount",
                "civilized encounter", "amount",
                "civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized);
        }

        [Test]
        public void IfDungeon_IgnoreTimeOfDayFilter()
        {
            var dungeonEncounters = new[] { "dungeon encounter/amount" };
            var specificDungeonEncounters = new[] { "specific dungeon encounter/amount" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Dungeon)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Dungeon)).Returns(specificDungeonEncounters);

            //INFO: Wildlife is found in magic, land, and temperature encounters
            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(dragonEncounters[0]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(dungeonEncounters[0]);
            levelEncounters.Add(specificDungeonEncounters[0]);

            var expectedEncounters = new[]
            {
                "dungeon encounter", "amount",
                "temperature encounter", "temperature amount",
                "magic encounter", "amount",
                "land encounter", "amount",
                "specific dungeon encounter", "amount",
                "dragon encounter", "amount",
                "dungeon encounter", "amount",
                "temperature encounter", "temperature amount",
                "land encounter", "amount",
                "specific dungeon encounter", "amount",
                "dungeon encounter", "amount",
                "temperature encounter", "temperature amount",
                "specific dungeon encounter", "amount",
                "specific dungeon encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Dungeon);
        }

        [Test]
        public void GetAllPossibleEncounters()
        {
            levelEncounters.Add("other encounter/other amount");
            levelEncounters.Add("other encounter/level amount");
            environmentEncounters.Add("other encounter/other amount");
            environmentEncounters.Add("environment encounter/other amount");
            temperatureEncounters.Add("other encounter/other amount");
            temperatureEncounters.Add("temperature encounter/other amount");
            timeOfDayEncounters.Add("other encounter/other amount");
            timeOfDayEncounters.Add("time of day encounter/other amount");

            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllFrom(level, environment, temperature, timeOfDay);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Null);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Empty);
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(2));

            var first = allEncounterTypesAndAmounts.First();
            AssertTypesAndAmounts(first, string.Empty, "encounter", "amount");

            var last = allEncounterTypesAndAmounts.Last();
            AssertTypesAndAmounts(last, string.Empty, "other encounter", "other amount");
        }

        [Test]
        public void GetAllPossibleCivilizedEncounters()
        {
            var civilizedEncounters = new[] { "civilized encounter/amount" };
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Civilized)).Returns(civilizedEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Civilized)).Returns(specificCivilizedEncounters);

            //INFO: Wildlife is found in magic, land, specific (with temperature), and temperature encounters
            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(civilizedEncounters[0]);
            levelEncounters.Add(specificCivilizedEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllFrom(level, EnvironmentConstants.Civilized, temperature, timeOfDay);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Null);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Empty);
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(1));

            var encounterTypesAndAmounts = allEncounterTypesAndAmounts.Single();
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "civilized encounter", "amount");
        }

        [Test]
        public void GetAllPossibleDungeonEncounters()
        {
            var dungeonEncounters = new[] { "dungeon encounter/amount" };
            var specificDungeonEncounters = new[] { "specific dungeon encounter/amount" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Dungeon)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Dungeon)).Returns(specificDungeonEncounters);

            //INFO: Wildlife is found in magic, land, and temperature encounters
            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(dungeonEncounters[0]);
            levelEncounters.Add(specificDungeonEncounters[0]);

            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllFrom(level, EnvironmentConstants.Dungeon, temperature, timeOfDay);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Null);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Empty);
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(5));

            var allEncounterTypesAndAmountsArray = allEncounterTypesAndAmounts.ToArray();

            AssertTypesAndAmounts(allEncounterTypesAndAmountsArray[0], string.Empty, "dungeon encounter", "amount");
            AssertTypesAndAmounts(allEncounterTypesAndAmountsArray[1], string.Empty, "temperature encounter", "temperature amount");
            AssertTypesAndAmounts(allEncounterTypesAndAmountsArray[2], string.Empty, "magic encounter", "amount");
            AssertTypesAndAmounts(allEncounterTypesAndAmountsArray[3], string.Empty, "land encounter", "amount");
            AssertTypesAndAmounts(allEncounterTypesAndAmountsArray[4], string.Empty, "specific dungeon encounter", "amount");
        }

        [Test]
        public void CacheEncounterGroup()
        {
            environmentEncounters.Add("other encounter/other amount");
            environmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("other encounter/other amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("other encounter/other amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            var calledIndex = 0;
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>()))
                .Returns((IEnumerable<string> collection) => collection.ElementAt(calledIndex++));

            var encounterTypesAndAmounts = creatureCollectionSelector.SelectFrom(level, environment, temperature, timeOfDay);
            var otherEncounterTypesAndAmounts = creatureCollectionSelector.SelectFrom(level, environment, temperature, timeOfDay);

            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, level.ToString()), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, environment), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, timeOfDay), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + environment), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>()), Times.Exactly(2));

            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "encounter", "amount");
            AssertTypesAndAmounts(otherEncounterTypesAndAmounts, string.Empty, "other encounter", "other amount");
        }

        [Test]
        public void CacheDungeon()
        {
            var dungeonEncounters = new[] { "dungeon encounter/amount" };
            var specificDungeonEncounters = new[] { "specific dungeon encounter/amount" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Dungeon)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Dungeon)).Returns(specificDungeonEncounters);

            levelEncounters.Add("dungeon encounter/amount");
            levelEncounters.Add("specific dungeon encounter/amount");
            timeOfDayEncounters.Add("dungeon encounter/amount");
            timeOfDayEncounters.Add("specific dungeon encounter/amount");

            var calledIndex = 0;
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>()))
                .Returns((IEnumerable<string> collection) => collection.ElementAt(calledIndex++));

            var encounterTypesAndAmounts = creatureCollectionSelector.SelectFrom(level, EnvironmentConstants.Dungeon, temperature, timeOfDay);
            var otherEncounterTypesAndAmounts = creatureCollectionSelector.SelectFrom(level, EnvironmentConstants.Dungeon, temperature, "other time of day");

            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, level.ToString()), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Dungeon), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, string.Empty), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Dungeon), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>()), Times.Exactly(2));

            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "dungeon encounter", "amount");
            AssertTypesAndAmounts(otherEncounterTypesAndAmounts, string.Empty, "specific dungeon encounter", "amount");
        }

        [Test]
        public void CacheCivilized()
        {
            var civilizedEncounters = new[] { "civilized encounter/amount", "other civilized encounter/other amount" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Civilized)).Returns(civilizedEncounters);

            levelEncounters.Add("other civilized encounter/other amount");
            levelEncounters.Add("civilized encounter/amount");
            timeOfDayEncounters.Add("other civilized encounter/other amount");
            timeOfDayEncounters.Add("civilized encounter/amount");

            var calledIndex = 0;
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>()))
                .Returns((IEnumerable<string> collection) => collection.ElementAt(calledIndex++));

            var encounterTypesAndAmounts = creatureCollectionSelector.SelectFrom(level, EnvironmentConstants.Civilized, temperature, timeOfDay);
            var otherEncounterTypesAndAmounts = creatureCollectionSelector.SelectFrom(level, EnvironmentConstants.Civilized, "other temperature", timeOfDay);

            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, level.ToString()), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Civilized), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, "other temperature"), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, timeOfDay), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Civilized), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, "other temperature" + environment), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>()), Times.Exactly(2));

            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "civilized encounter", "amount");
            AssertTypesAndAmounts(otherEncounterTypesAndAmounts, string.Empty, "other civilized encounter", "other amount");
        }

        [Test]
        public void CacheAllInEncounterGroup()
        {
            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllFrom(level, environment, temperature, timeOfDay);
            var otherAllEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllFrom(level, environment, temperature, timeOfDay);

            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, level.ToString()), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, environment), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, timeOfDay), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + environment), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land), Times.Once);
            Assert.That(allEncounterTypesAndAmounts, Is.EqualTo(otherAllEncounterTypesAndAmounts));
        }

        [Test]
        public void CacheAllDungeon()
        {
            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllFrom(level, EnvironmentConstants.Dungeon, temperature, timeOfDay);
            var otherAllEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllFrom(level, EnvironmentConstants.Dungeon, temperature, "other time of day");

            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, level.ToString()), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Dungeon), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, timeOfDay), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, "other time of day"), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Dungeon), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land), Times.Once);
            Assert.That(allEncounterTypesAndAmounts, Is.EqualTo(otherAllEncounterTypesAndAmounts));
        }

        [Test]
        public void CacheAllCivilized()
        {
            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllFrom(level, EnvironmentConstants.Civilized, temperature, timeOfDay);
            var otherAllEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllFrom(level, EnvironmentConstants.Civilized, "other temperature", timeOfDay);

            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, level.ToString()), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Civilized), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, "other temperature"), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, timeOfDay), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Civilized), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, "other temperature" + EnvironmentConstants.Civilized), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land), Times.Never);
            Assert.That(allEncounterTypesAndAmounts, Is.EqualTo(otherAllEncounterTypesAndAmounts));
        }

        [Test]
        public void GetAllPossibleWeightedEncounters()
        {
            levelEncounters.Add("other encounter/other amount");
            levelEncounters.Add("other encounter/level amount");
            environmentEncounters.Add("other encounter/other amount");
            environmentEncounters.Add("environment encounter/other amount");
            temperatureEncounters.Add("temperature encounter/other amount");
            timeOfDayEncounters.Add("other encounter/other amount");
            timeOfDayEncounters.Add("time of day encounter/other amount");

            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllWeightedFrom(level, environment, temperature, timeOfDay);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Null);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Empty);
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(6));

            var array = allEncounterTypesAndAmounts.ToArray();
            AssertTypesAndAmounts(array[0], "Index 0", "encounter", "amount");
            AssertTypesAndAmounts(array[1], "Index 1", "other encounter", "other amount");
            AssertTypesAndAmounts(array[2], "Index 2", "encounter", "amount");
            AssertTypesAndAmounts(array[3], "Index 3", "other encounter", "other amount");
            AssertTypesAndAmounts(array[4], "Index 4", "encounter", "amount");
            AssertTypesAndAmounts(array[5], "Index 5", "other encounter", "other amount");
        }

        [Test]
        public void GetAllPossibleWeightedCivilizedEncounters()
        {
            var civilizedEncounters = new[] { "civilized encounter/amount" };
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Civilized)).Returns(civilizedEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Civilized)).Returns(specificCivilizedEncounters);

            //INFO: Wildlife is found in magic, land, specific (with temperature), and temperature encounters
            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(civilizedEncounters[0]);
            levelEncounters.Add(specificCivilizedEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(temperatureEncounters[0]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllWeightedFrom(level, EnvironmentConstants.Civilized, temperature, timeOfDay);
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
            var dungeonEncounters = new[] { "dungeon encounter/amount" };
            var specificDungeonEncounters = new[] { "specific dungeon encounter/amount" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Dungeon)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Dungeon)).Returns(specificDungeonEncounters);

            //INFO: Wildlife is found in magic, land, and temperature encounters
            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(temperatureEncounters[0]);
            levelEncounters.Add(dungeonEncounters[0]);
            levelEncounters.Add(specificDungeonEncounters[0]);

            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllWeightedFrom(level, EnvironmentConstants.Dungeon, temperature, timeOfDay);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Null);
            Assert.That(allEncounterTypesAndAmounts, Is.Not.Empty);
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(13));

            var array = allEncounterTypesAndAmounts.ToArray();
            AssertTypesAndAmounts(array[0], "Index 0", "dungeon encounter", "amount");
            AssertTypesAndAmounts(array[1], "Index 1", "temperature encounter", "temperature amount");
            AssertTypesAndAmounts(array[2], "Index 2", "magic encounter", "amount");
            AssertTypesAndAmounts(array[3], "Index 3", "land encounter", "amount");
            AssertTypesAndAmounts(array[4], "Index 4", "specific dungeon encounter", "amount");
            AssertTypesAndAmounts(array[5], "Index 5", "dungeon encounter", "amount");
            AssertTypesAndAmounts(array[6], "Index 6", "temperature encounter", "temperature amount");
            AssertTypesAndAmounts(array[7], "Index 7", "land encounter", "amount");
            AssertTypesAndAmounts(array[8], "Index 8", "specific dungeon encounter", "amount");
            AssertTypesAndAmounts(array[9], "Index 9", "dungeon encounter", "amount");
            AssertTypesAndAmounts(array[10], "Index 10", "temperature encounter", "temperature amount");
            AssertTypesAndAmounts(array[11], "Index 11", "specific dungeon encounter", "amount");
            AssertTypesAndAmounts(array[12], "Index 12", "specific dungeon encounter", "amount");
        }

        [Test]
        public void CacheAllInWeightedEncounterGroup()
        {
            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllWeightedFrom(level, environment, temperature, timeOfDay);
            var otherAllEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllWeightedFrom(level, environment, temperature, timeOfDay);

            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, level.ToString()), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, environment), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, timeOfDay), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + environment), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land), Times.Once);
            Assert.That(allEncounterTypesAndAmounts, Is.EqualTo(otherAllEncounterTypesAndAmounts));
        }

        [Test]
        public void CacheAllWeightedDungeon()
        {
            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllWeightedFrom(level, EnvironmentConstants.Dungeon, temperature, timeOfDay);
            var otherAllEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllWeightedFrom(level, EnvironmentConstants.Dungeon, temperature, "other time of day");

            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, level.ToString()), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Dungeon), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, timeOfDay), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, "other time of day"), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Dungeon), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land), Times.Once);
            Assert.That(allEncounterTypesAndAmounts, Is.EqualTo(otherAllEncounterTypesAndAmounts));
        }

        [Test]
        public void CacheAllWeightedCivilized()
        {
            var allEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllWeightedFrom(level, EnvironmentConstants.Civilized, temperature, timeOfDay);
            var otherAllEncounterTypesAndAmounts = creatureCollectionSelector.SelectAllWeightedFrom(level, EnvironmentConstants.Civilized, "other temperature", timeOfDay);

            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, level.ToString()), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, EnvironmentConstants.Civilized), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, "other temperature"), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, timeOfDay), Times.Once);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, temperature + EnvironmentConstants.Civilized), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, "other temperature" + EnvironmentConstants.Civilized), Times.Never);
            mockCollectionSelector.Verify(s => s.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land), Times.Never);
            Assert.That(allEncounterTypesAndAmounts, Is.EqualTo(otherAllEncounterTypesAndAmounts));
        }
    }
}
