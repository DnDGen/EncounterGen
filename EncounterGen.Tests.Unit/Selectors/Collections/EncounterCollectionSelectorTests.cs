using DnDGen.Core.Selectors.Collections;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using EventGen;
using Moq;
using NUnit.Framework;
using System;
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
        private Mock<IEncounterLevelSelector> mockEncounterLevelSelector;
        private Mock<IEncounterFormatter> mockEncounterSelector;
        private Mock<IChallengeRatingSelector> mockChallengeRatingSelector;
        private List<string> levelEncounters;
        private List<string> timeOfDayEncounters;
        private List<string> magicEncounters;
        private List<string> specificEnvironmentEncounters;
        private List<string> landEncounters;
        private Dictionary<string, List<string>> filters;
        private List<string> wildernessEncounters;
        private EncounterSpecifications specifications;
        private Dictionary<string, IEnumerable<string>> encounterGroups;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockEncounterLevelSelector = new Mock<IEncounterLevelSelector>();
            mockEncounterSelector = new Mock<IEncounterFormatter>();
            mockEventQueue = new Mock<GenEventQueue>();
            mockChallengeRatingSelector = new Mock<IChallengeRatingSelector>();
            encounterCollectionSelector = new EncounterCollectionSelector(mockCollectionSelector.Object, mockEncounterLevelSelector.Object, mockEncounterSelector.Object, mockChallengeRatingSelector.Object, mockEventQueue.Object);

            levelEncounters = new List<string>();
            timeOfDayEncounters = new List<string>();
            magicEncounters = new List<string> { "magic encounter/magic amount", "other magic encounter/other magic amount" };
            specificEnvironmentEncounters = new List<string> { "specific environment encounter/specific environment amount", "other specific environment encounter/other specific environment amount" };
            landEncounters = new List<string> { "land encounter/land amount", "other land encounter/other land amount" };
            filters = new Dictionary<string, List<string>>();
            wildernessEncounters = new List<string>();
            specifications = new EncounterSpecifications();
            encounterGroups = new Dictionary<string, IEnumerable<string>>();

            levelEncounters.Add(specificEnvironmentEncounters[0]);
            levelEncounters.Add("level encounter/level amount");

            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);
            timeOfDayEncounters.Add("time of day encounter/time of day amount");

            filters["filter"] = new List<string>();
            filters["other filter"] = new List<string>();

            specifications.Environment = environment;
            specifications.Level = level;
            specifications.Temperature = temperature;
            specifications.TimeOfDay = timeOfDay;

            SetUpEncounterGroup(timeOfDay, timeOfDayEncounters);
            SetUpEncounterGroup(GroupConstants.Magic, magicEncounters);
            SetUpEncounterGroup(string.Empty, Enumerable.Empty<string>());
            SetUpEncounterGroup(specifications.SpecificEnvironment, specificEnvironmentEncounters);
            SetUpEncounterGroup(GroupConstants.Land, landEncounters);
            SetUpEncounterGroup(GroupConstants.Wilderness, wildernessEncounters);

            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "filter")).Returns(filters["filter"]);
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "other filter")).Returns(filters["other filter"]);
            mockCollectionSelector.Setup(s => s.SelectAllFrom(TableNameConstants.EncounterGroups)).Returns(encounterGroups);
            mockCollectionSelector.Setup(s => s.SelectAllFrom(TableNameConstants.AverageEncounterLevels)).Returns(() => GetEncounterLevels());
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>())).Returns((IEnumerable<Dictionary<string, string>> collection) => collection.Last());

            mockEncounterSelector.Setup(s => s.SelectCreaturesAndAmountsFrom(It.IsAny<string>())).Returns((string e) => ParseCreatureAndAmount(e));
        }

        private Dictionary<string, IEnumerable<string>> GetEncounterLevels()
        {
            var encounterLevels = new Dictionary<string, IEnumerable<string>>();
            var allEncounters = encounterGroups.Values.SelectMany(g => g);

            foreach (var encounter in allEncounters)
            {
                if (levelEncounters.Contains(encounter))
                    encounterLevels[encounter] = new[] { level.ToString() };
                else
                    encounterLevels[encounter] = new[] { "-1" };
            }

            return encounterLevels;
        }

        private void SetUpEncounterGroup(string creatureGroup, IEnumerable<string> encounters)
        {
            var creatureCollection = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, creatureGroup)).Returns(creatureCollection);
            mockCollectionSelector.Setup(s => s.Flatten(encounterGroups, creatureCollection)).Returns(encounters);

            encounterGroups[creatureGroup] = encounters;
        }

        private Dictionary<string, string> ParseCreatureAndAmount(string encounter)
        {
            return encounter.Split(',').ToDictionary(e => e.Split('/')[0], e => e.Split('/')[1]);
        }

        [Test]
        public void SelectingRandomGetsEncounterTypesAndAmountsFromSelector()
        {
            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "specific environment encounter", "specific environment amount");

            AssertEvents(1, 1, 1);
        }

        [Test]
        public void IfSelectingRandomAndNoEncountersExist_ThrowException()
        {
            levelEncounters.Clear();

            Assert.That(() => encounterCollectionSelector.SelectRandomFrom(specifications),
                Throws.ArgumentException.With.Message.EqualTo($"No valid encounters exist for {specifications.Description}"));

            AssertEvents(0, 0, 0);
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

            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add(specificEnvironmentEncounters[1]);
            levelEncounters.Add(specificEnvironmentEncounters[2]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[2]);

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "other specific environment encounter", "other specific environment amount");

            AssertEvents(3, 3, 3);
        }

        [Test]
        public void GetMultipleRandomEncounterTypesAndAmountsFromSelector()
        {
            specificEnvironmentEncounters.Add("other encounter/other amount,encounter/amount");
            levelEncounters.Add("other encounter/other amount,encounter/amount");
            timeOfDayEncounters.Add("other encounter/other amount,encounter/amount");

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "encounter", "amount", "other encounter", "other amount");

            AssertEvents(2, 2, 2);
        }

        [Test]
        public void ReturnEmptyWhenNoneMatchLevel()
        {
            levelEncounters.Clear();

            var expectedEncounters = Enumerable.Empty<string>();

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(0, 0, 0);
        }

        [Test]
        public void ReturnEmptyWhenNoneMatchFilter()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var expectedEncounters = Enumerable.Empty<string>();

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(0, 0, 0);
        }

        [Test]
        public void ReturnEmptyWhenCivilizedAndAllAreWilderness()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            levelEncounters.Add(specificCivilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);
            wildernessEncounters.AddRange(levelEncounters);

            var expectedEncounters = Enumerable.Empty<string>();

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized);
            AssertEvents(0, 0, 0);
        }

        [Test]
        public void ReturnEmptyWhenNoneMatchTimeOfDay()
        {
            timeOfDayEncounters.Clear();

            var expectedEncounters = Enumerable.Empty<string>();

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(0, 0, 0);
        }

        [Test]
        public void FilterOutEncountersThatDoNotMatchLevel()
        {
            timeOfDayEncounters.Add(magicEncounters[0]);

            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(1, 1, 1);
        }

        [Test]
        public void FilterOutEncountersThatDoNotMatchTimeOfDay()
        {
            levelEncounters.Add(magicEncounters[0]);

            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(1, 1, 1);
        }

        [Test]
        public void FilterOutEncountersThatDoNotMatchFilter()
        {
            levelEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[0]);

            filters["filter"].Add("specific environment encounter");
            filters["other filter"].Add("magic encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(1, 1, 1);
        }

        [TestCase(1)]
        [TestCase(10)]
        [TestCase(42)]
        [TestCase(66)]
        [TestCase(90)]
        [TestCase(92)]
        [TestCase(100)]
        [TestCase(210)]
        [TestCase(400)]
        [TestCase(500)]
        [TestCase(600)]
        [TestCase(800)]
        [TestCase(1000)]
        [TestCase(1148)]
        [TestCase(1200)]
        [TestCase(1337)]
        [TestCase(1500)]
        public void ShowExtraEventsWhileAssessingAverageEncounterLevel(int encountersTotal)
        {
            while (specificEnvironmentEncounters.Count < encountersTotal)
            {
                var encounter = $"extra encounter {specificEnvironmentEncounters.Count}";
                specificEnvironmentEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(1, 1, 1);
        }

        [Test]
        public void DoNotFilterOutEncountersThatMatchFilter()
        {
            levelEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[0]);

            filters["filter"].Add("specific environment encounter");
            filters["filter"].Add("magic encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(2, 1, 1);
        }

        [Test]
        public void SingleWeightMagicalEncounters()
        {
            levelEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[0]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(2, 1, 1);
        }

        private void AssertEncounterWeight(IEnumerable<string> expectedEncounters, string targetEnvironment = environment, bool allowAquatic = false, bool allowUnderground = false)
        {
            specifications.Environment = targetEnvironment;
            specifications.AllowAquatic = allowAquatic;
            specifications.AllowUnderground = allowUnderground;

            var expectedArray = expectedEncounters.ToArray();
            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications).ToArray();

            if (expectedEncounters.Any())
                Assert.That(weightedEncounters, Is.Not.Empty);
            else
                Assert.That(weightedEncounters, Is.Empty);

            var extras = weightedEncounters.Skip(expectedArray.Length / 2);
            Assert.That(extras, Is.Empty, "Extra encounters");
            Assert.That(weightedEncounters.Length, Is.EqualTo(expectedArray.Length / 2));

            for (var i = 0; i < expectedArray.Length; i += 2)
            {
                var index = i / 2;
                var failureMessage = $"Index {index}";

                AssertTypesAndAmounts(weightedEncounters[index], failureMessage, expectedArray[i], expectedArray[i + 1]);
            }
        }

        private void AssertEvents(int singleWeightCount,
            int doubleWeightCount,
            int specificEnvironmentTripleWeightCount,
            int undergroundAquaticTripleWeightCount = 0,
            IEnumerable<string> timeOfDayEncounters = null,
            IEnumerable<string> aquaticEncounters = null,
            IEnumerable<string> specificAquaticEncounters = null,
            IEnumerable<string> undergroundEncounters = null,
            IEnumerable<string> undergroundAquaticEncounters = null,
            IEnumerable<string> overrideSpecificEnvironmentEncounters = null)
        {
            aquaticEncounters = aquaticEncounters ?? Enumerable.Empty<string>();
            specificAquaticEncounters = specificAquaticEncounters ?? Enumerable.Empty<string>();
            undergroundEncounters = undergroundEncounters ?? Enumerable.Empty<string>();
            undergroundAquaticEncounters = undergroundAquaticEncounters ?? Enumerable.Empty<string>();
            timeOfDayEncounters = timeOfDayEncounters ?? this.timeOfDayEncounters;
            overrideSpecificEnvironmentEncounters = overrideSpecificEnvironmentEncounters ?? specificEnvironmentEncounters;

            var totalEventCount = 10;

            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Getting encounters for Magic"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Magic has {magicEncounters.Count} encounters"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Getting encounters for {specifications.SpecificEnvironment}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"{specifications.SpecificEnvironment} has {overrideSpecificEnvironmentEncounters.Count()} encounters"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Getting encounters for Aquatic"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Aquatic has {aquaticEncounters.Count()} encounters"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Getting encounters for Underground"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Underground has {undergroundEncounters.Count()} encounters"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Getting encounters for UndergroundAquatic"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"UndergroundAquatic has {undergroundAquaticEncounters.Count()} encounters"), Times.Once);

            var validEncounters = new List<string>();
            validEncounters.AddRange(magicEncounters);
            validEncounters.AddRange(overrideSpecificEnvironmentEncounters);

            if (specifications.Environment != EnvironmentConstants.Aquatic)
            {
                totalEventCount += 2;

                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Getting encounters for Land"), Times.Once);
                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Land has {landEncounters.Count} encounters"), Times.Once);

                validEncounters.AddRange(landEncounters);
            }

            if (specifications.Environment == EnvironmentConstants.Aquatic || specifications.AllowAquatic)
            {
                validEncounters.AddRange(aquaticEncounters);

                //INFO: If environment is aquatic, we will already have the sepcific aquatic encounters as part of the specific environment encounters
                if (specifications.Environment != EnvironmentConstants.Aquatic)
                {
                    totalEventCount += 2;

                    mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Getting encounters for temperatureAquatic"), Times.Once);
                    mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"temperatureAquatic has {specificAquaticEncounters.Count()} encounters"), Times.Once);

                    validEncounters.AddRange(specificAquaticEncounters);
                }
            }

            if (specifications.Environment == EnvironmentConstants.Underground || specifications.AllowUnderground)
            {
                validEncounters.AddRange(undergroundEncounters);
            }

            if ((specifications.Environment == EnvironmentConstants.Underground || specifications.AllowUnderground)
                && (specifications.Environment == EnvironmentConstants.Aquatic || specifications.AllowAquatic))
            {
                validEncounters.AddRange(undergroundAquaticEncounters);
            }

            totalEventCount += 1;
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Validating {validEncounters.Count} encounters"), Times.Once);

            totalEventCount += 2;
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Filtering out all encounters that are not (on overage) level {specifications.Level}"), Times.Once);

            validEncounters = validEncounters.Intersect(levelEncounters).ToList();
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Filtered down to {validEncounters.Count} encounters"), Times.AtLeastOnce);

            if (specifications.CreatureTypeFilters.Any() && validEncounters.Any())
            {
                totalEventCount += 2;

                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Filtering out all encounters that do not have at least one of the following creature types: {string.Join(", ", specifications.CreatureTypeFilters)}"), Times.Once);

                var filteredCreatures = filters.Where(kvp => specifications.CreatureTypeFilters.Contains(kvp.Key)).SelectMany(kvp => kvp.Value);
                validEncounters = validEncounters.Where(e => filteredCreatures.Contains(ParseCreatureAndAmount(e).Keys.First())).ToList();
                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Filtered down to {validEncounters.Count} encounters"), Times.AtLeastOnce);
            }

            if (specifications.Environment == EnvironmentConstants.Civilized && validEncounters.Any())
            {
                totalEventCount += 4;

                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Filtering out all wilderness encounters because the environment is civilized"), Times.Once);
                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Getting encounters for Wilderness"), Times.Once);
                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Wilderness has {wildernessEncounters.Count} encounters"), Times.Once);

                validEncounters = validEncounters.Except(wildernessEncounters).ToList();

                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Filtered down to {validEncounters.Count} encounters"), Times.AtLeastOnce);
            }

            if (validEncounters.Any())
            {
                totalEventCount += 4;

                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Filtering out all encounters that cannot occur in the {specifications.TimeOfDay}"), Times.Once);
                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Getting encounters for {specifications.TimeOfDay}"), Times.Once);
                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"{specifications.TimeOfDay} has {timeOfDayEncounters.Count()} encounters"), Times.Once);

                validEncounters = validEncounters.Intersect(timeOfDayEncounters).ToList();
                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Filtered down to {validEncounters.Count} encounters"), Times.AtLeastOnce);
            }

            if (singleWeightCount == 0)
            {
                totalEventCount++;

                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"{specifications.Description} has no valid encounters"), Times.Once);
            }
            else
            {
                totalEventCount += 3;

                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Single-weighting all {singleWeightCount} encounters"), Times.Once);
                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Double-weighting {doubleWeightCount} common encounters"), Times.Once);
                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Triple-weighting {specificEnvironmentTripleWeightCount} encounters in {specifications.SpecificEnvironment}"), Times.Once);
            }

            if (undergroundAquaticTripleWeightCount > 0)
            {
                totalEventCount++;
                mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Triple-weighting {undergroundAquaticTripleWeightCount} underground aquatic encounters"), Times.Once);
            }

            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(totalEventCount));
        }

        [Test]
        public void SingleWeightAdditionalAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            levelEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",
                "aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
            AssertEvents(2, 1, 1, aquaticEncounters: aquaticEncounters, specificAquaticEncounters: specificAquaticEncounters);
        }

        [Test]
        public void SingleWeightAdditionalUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            levelEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.AddRange(timeOfDayEncounters);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",
                "underground encounter", "amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
            AssertEvents(2, 1, 1, timeOfDayEncounters: nightEncounters, undergroundEncounters: undergroundEncounters);
        }

        [Test]
        public void DoubleWeightLandEncounters()
        {
            levelEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);

            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",

                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(2, 2, 1);
        }

        [Test]
        public void DoubleWeightNativeAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "specific aquatic encounter", "amount",
                "aquatic encounter", "amount",

                "specific aquatic encounter", "amount",
                "aquatic encounter", "amount",

                "specific aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Aquatic);
            AssertEvents(2, 2, 1, aquaticEncounters: aquaticEncounters, specificAquaticEncounters: specificAquaticEncounters);
        }

        [Test]
        public void DoubleWeightNativeUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            levelEncounters.Add(undergroundEncounters[0]);
            levelEncounters.Add(specificUndergroundEncounters[0]);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                "specific underground encounter", "amount",
                "underground encounter", "amount",

                "specific underground encounter", "amount",
                "underground encounter", "amount",

                "specific underground encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Underground);
            AssertEvents(2, 2, 1, timeOfDayEncounters: nightEncounters, undergroundEncounters: undergroundEncounters);
        }

        [Test]
        public void DoubleWeightAdditionalSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            levelEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",
                "specific aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",
                "specific aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
            AssertEvents(2, 2, 1, aquaticEncounters: aquaticEncounters, specificAquaticEncounters: specificAquaticEncounters);
        }

        [Test]
        public void DoubleWeightAdditionalUndergroundAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            levelEncounters.Add(undergroundAquaticEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",
                "underground aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",
                "underground aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
            AssertEvents(2, 2, 1, timeOfDayEncounters: nightEncounters, aquaticEncounters: aquaticEncounters, specificAquaticEncounters: specificAquaticEncounters, undergroundEncounters: undergroundEncounters, undergroundAquaticEncounters: undergroundAquaticEncounters);
        }

        [Test]
        public void TripleWeightSpecificEncounters()
        {
            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(1, 1, 1);
        }

        [Test]
        public void TripleWeightNativeSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            levelEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "specific aquatic encounter", "amount",

                "specific aquatic encounter", "amount",

                "specific aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Aquatic);
            AssertEvents(1, 1, 1, aquaticEncounters: aquaticEncounters, specificAquaticEncounters: specificAquaticEncounters);
        }

        [TestCase(EnvironmentConstants.Aquatic, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, true, true)]
        [TestCase(EnvironmentConstants.Underground, true, false)]
        [TestCase(EnvironmentConstants.Underground, true, true)]
        public void TripleWeightNativeUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground)
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            levelEncounters.Clear();
            levelEncounters.Add(undergroundAquaticEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                "underground aquatic encounter", "amount",

                "underground aquatic encounter", "amount",

                "underground aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, environment, allowAquatic, allowUnderground);
            AssertEvents(1, 1, 0, 1, nightEncounters, aquaticEncounters, specificAquaticEncounters, undergroundEncounters, undergroundAquaticEncounters);
        }

        [TestCase("environment", false, false, false)]
        [TestCase("environment", true, false, false)]
        [TestCase("environment", false, true, false)]
        [TestCase("environment", true, true, true)]
        [TestCase(EnvironmentConstants.Aquatic, false, false, false)]
        [TestCase(EnvironmentConstants.Aquatic, true, false, false)]
        [TestCase(EnvironmentConstants.Aquatic, false, true, true)]
        [TestCase(EnvironmentConstants.Aquatic, true, true, true)]
        [TestCase(EnvironmentConstants.Underground, false, false, false)]
        [TestCase(EnvironmentConstants.Underground, true, false, true)]
        [TestCase(EnvironmentConstants.Underground, false, true, false)]
        [TestCase(EnvironmentConstants.Underground, true, true, true)]
        public void ShouldAddUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground, bool hasUndergroundAquatic)
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            levelEncounters.Add(undergroundEncounters[0]);
            levelEncounters.Add(undergroundAquaticEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[0]);
            levelEncounters.Add(specificUndergroundEncounters[0]);
            timeOfDayEncounters.Add(undergroundEncounters[0]);
            timeOfDayEncounters.Add(undergroundAquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificUndergroundEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = environment;
            specifications.AllowAquatic = allowAquatic;
            specifications.AllowUnderground = allowUnderground;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(weightedEncounters, Is.Not.Empty);
            Assert.That(weightedEncounters.Any(e => e.Keys.Contains("underground aquatic encounter")), Is.EqualTo(hasUndergroundAquatic));
        }

        [Test]
        public void IfCivilized_DoNotGetWildlife()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(specificCivilizedEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);

            var expectedEncounters = new[]
            {
                "other magic encounter", "other magic amount",
                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",

                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",

                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized);
            AssertEvents(3, 2, 1);
        }

        [Test]
        public void IfUndergroundEnvironment_SetTimeOfDayToNight()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(undergroundEncounters[0]);
            levelEncounters.Add(specificUndergroundEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific underground encounter", "amount",
                "land encounter", "land amount",
                "underground encounter", "amount",

                "specific underground encounter", "amount",
                "land encounter", "land amount",
                "underground encounter", "amount",

                "specific underground encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Underground);
            AssertEvents(4, 3, 1, timeOfDayEncounters: nightEncounters, undergroundEncounters: undergroundEncounters, overrideSpecificEnvironmentEncounters: specificUndergroundEncounters);
        }

        [Test]
        public void IfAllowingUnderground_SetTimeOfDayToNight()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(specificEnvironmentEncounters[0]);
            levelEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "underground encounter", "amount",

                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
            AssertEvents(4, 2, 1, timeOfDayEncounters: nightEncounters, undergroundEncounters: undergroundEncounters);
        }

        [Test]
        public void GetAllPossibleWeightedEncounters()
        {
            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(specificEnvironmentEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",

                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
            AssertEvents(3, 2, 1);
        }

        [Test]
        public void GetAllPossibleWeightedCivilizedEncounters()
        {
            var civilizedEncounters = new[] { "civilized encounter/amount", "other civilized encounter/other amount" };
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(civilizedEncounters[0]);
            levelEncounters.Add(specificCivilizedEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);

            var expectedEncounters = new[]
            {
                "other magic encounter", "other magic amount",
                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",

                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",

                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized);
            AssertEvents(3, 2, 1);
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
            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            filters["filter"].Add("specific environment encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "specific environment encounter", "specific environment amount");
        }

        [Test]
        public void EncounterMatchesIfAnyCreatureMatchesFilter()
        {
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>())).Returns((IEnumerable<Dictionary<string, string>> collection) => collection.ElementAt(1));

            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            specificEnvironmentEncounters.Add("other encounter/other amount,encounter/amount");
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

            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            specificEnvironmentEncounters.Add("other encounter/other amount");
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
            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            filters["filter"].Add("specific environment encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var allEncounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(specifications).ToArray();
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(3));

            AssertTypesAndAmounts(allEncounterTypesAndAmounts[0], "Index 0", "specific environment encounter", "specific environment amount");
            AssertTypesAndAmounts(allEncounterTypesAndAmounts[1], "Index 1", "specific environment encounter", "specific environment amount");
            AssertTypesAndAmounts(allEncounterTypesAndAmounts[2], "Index 2", "specific environment encounter", "specific environment amount");
        }

        [Test]
        public void AquaticEnvironmentDoesNotHaveNonAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific aquatic encounter", "amount",
                "aquatic encounter", "amount",

                "specific aquatic encounter", "amount",
                "aquatic encounter", "amount",

                "specific aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Aquatic);
            AssertEvents(3, 2, 1, aquaticEncounters: aquaticEncounters, specificAquaticEncounters: specificAquaticEncounters);
        }

        [Test]
        public void CanAddAquaticToAnEnvironment()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(specificEnvironmentEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "specific aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
            AssertEvents(5, 3, 1, aquaticEncounters: aquaticEncounters, specificAquaticEncounters: specificAquaticEncounters);
        }

        [Test]
        public void AddingAquaticToAquatic()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific aquatic encounter", "amount",
                "aquatic encounter", "amount",

                "specific aquatic encounter", "amount",
                "aquatic encounter", "amount",

                "specific aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Aquatic, allowAquatic: true);
            AssertEvents(3, 2, 1, aquaticEncounters: aquaticEncounters, specificAquaticEncounters: specificAquaticEncounters);
        }

        [Test]
        public void AddAquaticToUnderground()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(undergroundEncounters[0]);
            levelEncounters.Add(specificUndergroundEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(aquaticEncounters[1]);
            levelEncounters.Add(specificAquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[1]);
            levelEncounters.Add(undergroundAquaticEncounters[0]);
            levelEncounters.Add(undergroundAquaticEncounters[1]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific underground encounter", "amount",
                "land encounter", "land amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "underground encounter", "amount",
                "underground aquatic encounter", "amount",

                "specific underground encounter", "amount",
                "land encounter", "land amount",
                "specific aquatic encounter", "amount",
                "underground encounter", "amount",
                "underground aquatic encounter", "amount",

                "specific underground encounter", "amount",
                "underground aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Underground, true);
            AssertEvents(7, 5, 1, 1, nightEncounters, aquaticEncounters, specificAquaticEncounters, undergroundEncounters, undergroundAquaticEncounters, specificUndergroundEncounters);
        }

        [Test]
        public void AddAquaticToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(specificCivilizedEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(aquaticEncounters[1]);
            levelEncounters.Add(specificAquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[1]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[1]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[1]);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(aquaticEncounters[0]);
            wildernessEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "other magic encounter", "other magic amount",
                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",
                "other aquatic encounter", "other amount",
                "other specific aquatic encounter", "other amount",

                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",
                "other specific aquatic encounter", "other amount",

                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowAquatic: true);
            AssertEvents(5, 3, 1, aquaticEncounters: aquaticEncounters, specificAquaticEncounters: specificAquaticEncounters);
        }

        [Test]
        public void CanAddUndergroundToAnEnvironment()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(specificEnvironmentEncounters[0]);
            levelEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(magicEncounters[1]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(landEncounters[1]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "underground encounter", "amount",

                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
            AssertEvents(4, 2, 1, timeOfDayEncounters: nightEncounters, undergroundEncounters: undergroundEncounters);
        }

        [Test]
        public void AddingUndergroundToUnderground()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(undergroundEncounters[0]);
            levelEncounters.Add(specificUndergroundEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific underground encounter", "amount",
                "land encounter", "land amount",
                "underground encounter", "amount",

                "specific underground encounter", "amount",
                "land encounter", "land amount",
                "underground encounter", "amount",

                "specific underground encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Underground, allowUnderground: true);
            AssertEvents(4, 3, 1, timeOfDayEncounters: nightEncounters, undergroundEncounters: undergroundEncounters, overrideSpecificEnvironmentEncounters: specificUndergroundEncounters);
        }

        [Test]
        public void AddUndergroundAndAquatic()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(undergroundEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(aquaticEncounters[1]);
            levelEncounters.Add(specificAquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[1]);
            levelEncounters.Add(specificEnvironmentEncounters[0]);
            levelEncounters.Add(undergroundAquaticEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "underground encounter", "amount",
                "underground aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "specific aquatic encounter", "amount",
                "underground aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
            AssertEvents(7, 4, 1, 0, nightEncounters, aquaticEncounters, specificAquaticEncounters, undergroundEncounters, undergroundAquaticEncounters);
        }

        [Test]
        public void AddUndergroundToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };

            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(specificCivilizedEncounters[0]);
            levelEncounters.Add(undergroundEncounters[0]);
            levelEncounters.Add(undergroundEncounters[1]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(magicEncounters[1]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(landEncounters[1]);
            nightEncounters.Add(specificCivilizedEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var expectedEncounters = new[]
            {
                "other magic encounter", "other magic amount",
                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",
                "other underground encounter", "other amount",

                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",

                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowUnderground: true);
            AssertEvents(4, 2, 1, timeOfDayEncounters: nightEncounters, undergroundEncounters: undergroundEncounters, overrideSpecificEnvironmentEncounters: specificCivilizedEncounters);
        }

        [Test]
        public void AddUndergroundAndAquaticToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(specificCivilizedEncounters[0]);
            levelEncounters.Add(undergroundEncounters[0]);
            levelEncounters.Add(undergroundEncounters[1]);
            levelEncounters.Add(undergroundAquaticEncounters[0]);
            levelEncounters.Add(undergroundAquaticEncounters[1]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(aquaticEncounters[1]);
            levelEncounters.Add(specificAquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[1]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(magicEncounters[1]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(landEncounters[1]);
            nightEncounters.Add(specificCivilizedEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[1]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(aquaticEncounters[1]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[1]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            wildernessEncounters.Add(magicEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);
            wildernessEncounters.Add(undergroundAquaticEncounters[0]);
            wildernessEncounters.Add(aquaticEncounters[0]);
            wildernessEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "other magic encounter", "other magic amount",
                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",
                "other aquatic encounter", "other amount",
                "other specific aquatic encounter", "other amount",
                "other underground encounter", "other amount",
                "other underground aquatic encounter", "other amount",

                "specific civilized encounter", "amount",
                "other land encounter", "other land amount",
                "other specific aquatic encounter", "other amount",
                "other underground aquatic encounter", "other amount",

                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowAquatic: true, allowUnderground: true);
            AssertEvents(7, 4, 1, 0, nightEncounters, aquaticEncounters, specificAquaticEncounters, undergroundEncounters, undergroundAquaticEncounters, specificCivilizedEncounters);
        }
    }
}
