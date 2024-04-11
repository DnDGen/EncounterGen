using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Selectors.Collections;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Unit.Selectors.Collections
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
        private Mock<IEncounterFormatter> mockEncounterSelector;
        private List<string> levelEncounters;
        private List<string> timeOfDayEncounters;
        private List<string> magicEncounters;
        private List<string> specificEnvironmentEncounters;
        private List<string> landEncounters;
        private Dictionary<string, List<string>> filters;
        private List<string> wildernessEncounters;
        private EncounterSpecifications specifications;
        private Dictionary<string, IEnumerable<string>> encounterGroups;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockEncounterSelector = new Mock<IEncounterFormatter>();
            encounterCollectionSelector = new EncounterCollectionSelector(mockCollectionSelector.Object, mockEncounterSelector.Object);

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

            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            levelEncounters.Add(specificEnvironmentEncounters[1]);
            levelEncounters.Add(specificEnvironmentEncounters[2]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[2]);

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "other specific environment encounter", "other specific environment amount");
        }

        [Test]
        public void GetMultipleRandomEncounterTypesAndAmountsFromSelector()
        {
            specificEnvironmentEncounters.Add("other encounter/other amount,encounter/amount");
            levelEncounters.Add("other encounter/other amount,encounter/amount");
            timeOfDayEncounters.Add("other encounter/other amount,encounter/amount");

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, string.Empty, "encounter", "amount", "other encounter", "other amount");
        }

        [Test]
        public void ReturnEmptyWhenNoneMatchLevel()
        {
            levelEncounters.Clear();

            var expectedEncounters = Enumerable.Empty<string>();

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void ReturnEmptyWhenNoneMatchFilter()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var expectedEncounters = Enumerable.Empty<string>();

            AssertEncounterWeight(expectedEncounters);
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
        }

        [Test]
        public void ReturnEmptyWhenNoneMatchTimeOfDay()
        {
            timeOfDayEncounters.Clear();

            var expectedEncounters = Enumerable.Empty<string>();

            AssertEncounterWeight(expectedEncounters);
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

        private int ComputeWeight(IEnumerable<string> uncommonEncounters, IEnumerable<string> encountersToWeight)
        {
            return Math.Max(uncommonEncounters.Count() / encountersToWeight.Count(), 1);
        }

        private bool ShouldSpecificWeightUndergroundAquatic(EncounterSpecifications specifications)
        {
            return ShouldGetUndergroundAquatic(specifications)
                && (specifications.Environment == EnvironmentConstants.Aquatic || specifications.Environment == EnvironmentConstants.Underground);
        }

        private bool ShouldGetUndergroundAquatic(EncounterSpecifications specifications)
        {
            return ShouldGetUnderground(specifications) && ShouldGetAquatic(specifications);
        }

        private bool ShouldGetUnderground(EncounterSpecifications specifications)
        {
            return (specifications.Environment == EnvironmentConstants.Underground || specifications.AllowUnderground);
        }

        private bool ShouldGetAquatic(EncounterSpecifications specifications)
        {
            return (specifications.Environment == EnvironmentConstants.Aquatic || specifications.AllowAquatic);
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
        }

        [Test]
        public void DoNotWeightCommonEncountersIfNone()
        {
            levelEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(magicEncounters[0]);

            specificEnvironmentEncounters.Clear();

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void DoNotWeightSpecificEncountersIfNone()
        {
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var nightEncounters = new List<string>();

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            specificEnvironmentEncounters.Clear();

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "land encounter", "land amount",
                "underground aquatic encounter", "amount",

                "land encounter", "land amount",
                "underground aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
        }

        [Test]
        public void DoNotWeightUndergroundAquaticEncountersIfNone()
        {
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var nightEncounters = new List<string>();

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",

                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
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
        }

        [Test]
        public void WeightLandEncounters()
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
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 2)]
        [TestCase(0, 2, 2)]
        [TestCase(0, 10, 2)]
        [TestCase(0, 13, 2)]
        [TestCase(0, 37, 2)]
        [TestCase(0, 42, 2)]
        [TestCase(0, 60, 2)]
        [TestCase(0, 66, 2)]
        [TestCase(0, 90, 2)]
        [TestCase(0, 92, 2)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 10, 2)]
        [TestCase(1, 13, 2)]
        [TestCase(1, 37, 2)]
        [TestCase(1, 42, 2)]
        [TestCase(1, 60, 2)]
        [TestCase(1, 66, 2)]
        [TestCase(1, 90, 2)]
        [TestCase(1, 92, 2)]
        [TestCase(2, 0, 0)]
        [TestCase(2, 1, 3)]
        [TestCase(2, 2, 2)]
        [TestCase(2, 10, 2)]
        [TestCase(2, 13, 2)]
        [TestCase(2, 37, 2)]
        [TestCase(2, 42, 2)]
        [TestCase(2, 60, 2)]
        [TestCase(2, 66, 2)]
        [TestCase(2, 90, 2)]
        [TestCase(2, 92, 2)]
        [TestCase(10, 0, 0)]
        [TestCase(10, 1, 11)]
        [TestCase(10, 2, 6)]
        [TestCase(10, 10, 2)]
        [TestCase(10, 13, 2)]
        [TestCase(10, 37, 2)]
        [TestCase(10, 42, 2)]
        [TestCase(10, 60, 2)]
        [TestCase(10, 66, 2)]
        [TestCase(10, 90, 2)]
        [TestCase(10, 92, 2)]
        [TestCase(13, 0, 0)]
        [TestCase(13, 1, 14)]
        [TestCase(13, 2, 7)]
        [TestCase(13, 10, 2)]
        [TestCase(13, 13, 2)]
        [TestCase(13, 37, 2)]
        [TestCase(13, 42, 2)]
        [TestCase(13, 60, 2)]
        [TestCase(13, 66, 2)]
        [TestCase(13, 90, 2)]
        [TestCase(13, 92, 2)]
        [TestCase(37, 0, 0)]
        [TestCase(37, 1, 38)]
        [TestCase(37, 2, 19)]
        [TestCase(37, 10, 4)]
        [TestCase(37, 13, 3)]
        [TestCase(37, 37, 2)]
        [TestCase(37, 42, 2)]
        [TestCase(37, 60, 2)]
        [TestCase(37, 66, 2)]
        [TestCase(37, 90, 2)]
        [TestCase(37, 92, 2)]
        [TestCase(42, 0, 0)]
        [TestCase(42, 1, 43)]
        [TestCase(42, 2, 22)]
        [TestCase(42, 10, 5)]
        [TestCase(42, 13, 4)]
        [TestCase(42, 37, 2)]
        [TestCase(42, 42, 2)]
        [TestCase(42, 60, 2)]
        [TestCase(42, 66, 2)]
        [TestCase(42, 90, 2)]
        [TestCase(42, 92, 2)]
        [TestCase(60, 0, 0)]
        [TestCase(60, 1, 61)]
        [TestCase(60, 2, 31)]
        [TestCase(60, 10, 7)]
        [TestCase(60, 13, 5)]
        [TestCase(60, 37, 2)]
        [TestCase(60, 42, 2)]
        [TestCase(60, 60, 2)]
        [TestCase(60, 66, 2)]
        [TestCase(60, 90, 2)]
        [TestCase(60, 92, 2)]
        [TestCase(66, 0, 0)]
        [TestCase(66, 1, 67)]
        [TestCase(66, 2, 34)]
        [TestCase(66, 10, 7)]
        [TestCase(66, 13, 6)]
        [TestCase(66, 37, 2)]
        [TestCase(66, 42, 2)]
        [TestCase(66, 60, 2)]
        [TestCase(66, 66, 2)]
        [TestCase(66, 90, 2)]
        [TestCase(66, 92, 2)]
        [TestCase(90, 0, 0)]
        [TestCase(90, 1, 91)]
        [TestCase(90, 2, 46)]
        [TestCase(90, 10, 10)]
        [TestCase(90, 13, 7)]
        [TestCase(90, 37, 3)]
        [TestCase(90, 42, 3)]
        [TestCase(90, 60, 2)]
        [TestCase(90, 66, 2)]
        [TestCase(90, 90, 2)]
        [TestCase(90, 92, 2)]
        [TestCase(92, 0, 0)]
        [TestCase(92, 1, 93)]
        [TestCase(92, 2, 47)]
        [TestCase(92, 10, 10)]
        [TestCase(92, 13, 8)]
        [TestCase(92, 37, 3)]
        [TestCase(92, 42, 3)]
        [TestCase(92, 60, 2)]
        [TestCase(92, 66, 2)]
        [TestCase(92, 90, 2)]
        [TestCase(92, 92, 2)]
        public void DynamicallyWeightLandEncounters(int magicCount, int landCount, int expectedWeighting)
        {
            Assert.That(landCount * expectedWeighting, Is.GreaterThan(magicCount).Or.EqualTo(0));
            if (expectedWeighting > 2)
                Assert.That(landCount * (expectedWeighting - 1), Is.LessThanOrEqualTo(magicCount));

            specificEnvironmentEncounters.Clear();
            magicEncounters.Clear();
            landEncounters.Clear();

            while (magicEncounters.Count < magicCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                magicEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            while (landEncounters.Count < landCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                landEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(magicEncounters.Count, Is.LessThan(weightedEncounters.Count() / 2d).Or.EqualTo(weightedEncounters.Count()));

            foreach (var encounter in magicEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(1), "magic encounter");
            }

            foreach (var encounter in landEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(expectedWeighting), "land encounter");
            }
        }

        [Test]
        public void WeightNativeAquaticEncounters()
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
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 2)]
        [TestCase(0, 2, 2)]
        [TestCase(0, 10, 2)]
        [TestCase(0, 13, 2)]
        [TestCase(0, 37, 2)]
        [TestCase(0, 42, 2)]
        [TestCase(0, 60, 2)]
        [TestCase(0, 66, 2)]
        [TestCase(0, 90, 2)]
        [TestCase(0, 92, 2)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 10, 2)]
        [TestCase(1, 13, 2)]
        [TestCase(1, 37, 2)]
        [TestCase(1, 42, 2)]
        [TestCase(1, 60, 2)]
        [TestCase(1, 66, 2)]
        [TestCase(1, 90, 2)]
        [TestCase(1, 92, 2)]
        [TestCase(2, 0, 0)]
        [TestCase(2, 1, 3)]
        [TestCase(2, 2, 2)]
        [TestCase(2, 10, 2)]
        [TestCase(2, 13, 2)]
        [TestCase(2, 37, 2)]
        [TestCase(2, 42, 2)]
        [TestCase(2, 60, 2)]
        [TestCase(2, 66, 2)]
        [TestCase(2, 90, 2)]
        [TestCase(2, 92, 2)]
        [TestCase(10, 0, 0)]
        [TestCase(10, 1, 11)]
        [TestCase(10, 2, 6)]
        [TestCase(10, 10, 2)]
        [TestCase(10, 13, 2)]
        [TestCase(10, 37, 2)]
        [TestCase(10, 42, 2)]
        [TestCase(10, 60, 2)]
        [TestCase(10, 66, 2)]
        [TestCase(10, 90, 2)]
        [TestCase(10, 92, 2)]
        [TestCase(13, 0, 0)]
        [TestCase(13, 1, 14)]
        [TestCase(13, 2, 7)]
        [TestCase(13, 10, 2)]
        [TestCase(13, 13, 2)]
        [TestCase(13, 37, 2)]
        [TestCase(13, 42, 2)]
        [TestCase(13, 60, 2)]
        [TestCase(13, 66, 2)]
        [TestCase(13, 90, 2)]
        [TestCase(13, 92, 2)]
        [TestCase(37, 0, 0)]
        [TestCase(37, 1, 38)]
        [TestCase(37, 2, 19)]
        [TestCase(37, 10, 4)]
        [TestCase(37, 13, 3)]
        [TestCase(37, 37, 2)]
        [TestCase(37, 42, 2)]
        [TestCase(37, 60, 2)]
        [TestCase(37, 66, 2)]
        [TestCase(37, 90, 2)]
        [TestCase(37, 92, 2)]
        [TestCase(42, 0, 0)]
        [TestCase(42, 1, 43)]
        [TestCase(42, 2, 22)]
        [TestCase(42, 10, 5)]
        [TestCase(42, 13, 4)]
        [TestCase(42, 37, 2)]
        [TestCase(42, 42, 2)]
        [TestCase(42, 60, 2)]
        [TestCase(42, 66, 2)]
        [TestCase(42, 90, 2)]
        [TestCase(42, 92, 2)]
        [TestCase(60, 0, 0)]
        [TestCase(60, 1, 61)]
        [TestCase(60, 2, 31)]
        [TestCase(60, 10, 7)]
        [TestCase(60, 13, 5)]
        [TestCase(60, 37, 2)]
        [TestCase(60, 42, 2)]
        [TestCase(60, 60, 2)]
        [TestCase(60, 66, 2)]
        [TestCase(60, 90, 2)]
        [TestCase(60, 92, 2)]
        [TestCase(66, 0, 0)]
        [TestCase(66, 1, 67)]
        [TestCase(66, 2, 34)]
        [TestCase(66, 10, 7)]
        [TestCase(66, 13, 6)]
        [TestCase(66, 37, 2)]
        [TestCase(66, 42, 2)]
        [TestCase(66, 60, 2)]
        [TestCase(66, 66, 2)]
        [TestCase(66, 90, 2)]
        [TestCase(66, 92, 2)]
        [TestCase(90, 0, 0)]
        [TestCase(90, 1, 91)]
        [TestCase(90, 2, 46)]
        [TestCase(90, 10, 10)]
        [TestCase(90, 13, 7)]
        [TestCase(90, 37, 3)]
        [TestCase(90, 42, 3)]
        [TestCase(90, 60, 2)]
        [TestCase(90, 66, 2)]
        [TestCase(90, 90, 2)]
        [TestCase(90, 92, 2)]
        [TestCase(92, 0, 0)]
        [TestCase(92, 1, 93)]
        [TestCase(92, 2, 47)]
        [TestCase(92, 10, 10)]
        [TestCase(92, 13, 8)]
        [TestCase(92, 37, 3)]
        [TestCase(92, 42, 3)]
        [TestCase(92, 60, 2)]
        [TestCase(92, 66, 2)]
        [TestCase(92, 90, 2)]
        [TestCase(92, 92, 2)]
        public void DynamicallyWeightNativeAquaticEncounters(int magicCount, int aquaticCount, int expectedWeighting)
        {
            Assert.That(aquaticCount * expectedWeighting, Is.GreaterThan(magicCount).Or.EqualTo(0));
            if (expectedWeighting > 2)
                Assert.That(aquaticCount * (expectedWeighting - 1), Is.LessThanOrEqualTo(magicCount));

            specificEnvironmentEncounters.Clear();
            magicEncounters.Clear();

            var aquaticEncounters = new List<string>();
            var specificAquaticEncounters = new List<string>();

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            while (magicEncounters.Count < magicCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                magicEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            while (aquaticEncounters.Count < aquaticCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                aquaticEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            specifications.Environment = EnvironmentConstants.Aquatic;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(magicEncounters.Count, Is.LessThan(weightedEncounters.Count() / 2d).Or.EqualTo(weightedEncounters.Count()));

            foreach (var encounter in magicEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(1), "magic encounter");
            }

            foreach (var encounter in aquaticEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(expectedWeighting), "aquatic encounter");
            }
        }

        [Test]
        public void WeightNativeUndergroundEncounters()
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
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 2)]
        [TestCase(0, 2, 2)]
        [TestCase(0, 10, 2)]
        [TestCase(0, 13, 2)]
        [TestCase(0, 37, 2)]
        [TestCase(0, 42, 2)]
        [TestCase(0, 60, 2)]
        [TestCase(0, 66, 2)]
        [TestCase(0, 90, 2)]
        [TestCase(0, 92, 2)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 10, 2)]
        [TestCase(1, 13, 2)]
        [TestCase(1, 37, 2)]
        [TestCase(1, 42, 2)]
        [TestCase(1, 60, 2)]
        [TestCase(1, 66, 2)]
        [TestCase(1, 90, 2)]
        [TestCase(1, 92, 2)]
        [TestCase(2, 0, 0)]
        [TestCase(2, 1, 3)]
        [TestCase(2, 2, 2)]
        [TestCase(2, 10, 2)]
        [TestCase(2, 13, 2)]
        [TestCase(2, 37, 2)]
        [TestCase(2, 42, 2)]
        [TestCase(2, 60, 2)]
        [TestCase(2, 66, 2)]
        [TestCase(2, 90, 2)]
        [TestCase(2, 92, 2)]
        [TestCase(10, 0, 0)]
        [TestCase(10, 1, 11)]
        [TestCase(10, 2, 6)]
        [TestCase(10, 10, 2)]
        [TestCase(10, 13, 2)]
        [TestCase(10, 37, 2)]
        [TestCase(10, 42, 2)]
        [TestCase(10, 60, 2)]
        [TestCase(10, 66, 2)]
        [TestCase(10, 90, 2)]
        [TestCase(10, 92, 2)]
        [TestCase(13, 0, 0)]
        [TestCase(13, 1, 14)]
        [TestCase(13, 2, 7)]
        [TestCase(13, 10, 2)]
        [TestCase(13, 13, 2)]
        [TestCase(13, 37, 2)]
        [TestCase(13, 42, 2)]
        [TestCase(13, 60, 2)]
        [TestCase(13, 66, 2)]
        [TestCase(13, 90, 2)]
        [TestCase(13, 92, 2)]
        [TestCase(37, 0, 0)]
        [TestCase(37, 1, 38)]
        [TestCase(37, 2, 19)]
        [TestCase(37, 10, 4)]
        [TestCase(37, 13, 3)]
        [TestCase(37, 37, 2)]
        [TestCase(37, 42, 2)]
        [TestCase(37, 60, 2)]
        [TestCase(37, 66, 2)]
        [TestCase(37, 90, 2)]
        [TestCase(37, 92, 2)]
        [TestCase(42, 0, 0)]
        [TestCase(42, 1, 43)]
        [TestCase(42, 2, 22)]
        [TestCase(42, 10, 5)]
        [TestCase(42, 13, 4)]
        [TestCase(42, 37, 2)]
        [TestCase(42, 42, 2)]
        [TestCase(42, 60, 2)]
        [TestCase(42, 66, 2)]
        [TestCase(42, 90, 2)]
        [TestCase(42, 92, 2)]
        [TestCase(60, 0, 0)]
        [TestCase(60, 1, 61)]
        [TestCase(60, 2, 31)]
        [TestCase(60, 10, 7)]
        [TestCase(60, 13, 5)]
        [TestCase(60, 37, 2)]
        [TestCase(60, 42, 2)]
        [TestCase(60, 60, 2)]
        [TestCase(60, 66, 2)]
        [TestCase(60, 90, 2)]
        [TestCase(60, 92, 2)]
        [TestCase(66, 0, 0)]
        [TestCase(66, 1, 67)]
        [TestCase(66, 2, 34)]
        [TestCase(66, 10, 7)]
        [TestCase(66, 13, 6)]
        [TestCase(66, 37, 2)]
        [TestCase(66, 42, 2)]
        [TestCase(66, 60, 2)]
        [TestCase(66, 66, 2)]
        [TestCase(66, 90, 2)]
        [TestCase(66, 92, 2)]
        [TestCase(90, 0, 0)]
        [TestCase(90, 1, 91)]
        [TestCase(90, 2, 46)]
        [TestCase(90, 10, 10)]
        [TestCase(90, 13, 7)]
        [TestCase(90, 37, 3)]
        [TestCase(90, 42, 3)]
        [TestCase(90, 60, 2)]
        [TestCase(90, 66, 2)]
        [TestCase(90, 90, 2)]
        [TestCase(90, 92, 2)]
        [TestCase(92, 0, 0)]
        [TestCase(92, 1, 93)]
        [TestCase(92, 2, 47)]
        [TestCase(92, 10, 10)]
        [TestCase(92, 13, 8)]
        [TestCase(92, 37, 3)]
        [TestCase(92, 42, 3)]
        [TestCase(92, 60, 2)]
        [TestCase(92, 66, 2)]
        [TestCase(92, 90, 2)]
        [TestCase(92, 92, 2)]
        public void DynamicallyWeightNativeUndergroundEncounters(int magicCount, int undergroundCount, int expectedWeighting)
        {
            Assert.That(undergroundCount * expectedWeighting, Is.GreaterThan(magicCount).Or.EqualTo(0));
            if (expectedWeighting > 2)
                Assert.That(undergroundCount * (expectedWeighting - 1), Is.LessThanOrEqualTo(magicCount));

            specificEnvironmentEncounters.Clear();
            magicEncounters.Clear();

            var undergroundEncounters = new List<string>();
            var specificUndergroundEncounters = new List<string>();
            var nightEncounters = new List<string>();

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            while (magicEncounters.Count < magicCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                magicEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                nightEncounters.Add(encounter);
            }

            while (undergroundEncounters.Count < undergroundCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                undergroundEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                nightEncounters.Add(encounter);
            }

            specifications.Environment = EnvironmentConstants.Underground;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(magicEncounters.Count, Is.LessThan(weightedEncounters.Count() / 2d).Or.EqualTo(weightedEncounters.Count()));

            foreach (var encounter in magicEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(1), "magic encounter");
            }

            foreach (var encounter in undergroundEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(expectedWeighting), "underground encounter");
            }
        }

        [Test]
        public void WeightAdditionalSpecificAquaticEncounters()
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
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 2)]
        [TestCase(0, 2, 2)]
        [TestCase(0, 10, 2)]
        [TestCase(0, 13, 2)]
        [TestCase(0, 37, 2)]
        [TestCase(0, 42, 2)]
        [TestCase(0, 60, 2)]
        [TestCase(0, 66, 2)]
        [TestCase(0, 90, 2)]
        [TestCase(0, 92, 2)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 10, 2)]
        [TestCase(1, 13, 2)]
        [TestCase(1, 37, 2)]
        [TestCase(1, 42, 2)]
        [TestCase(1, 60, 2)]
        [TestCase(1, 66, 2)]
        [TestCase(1, 90, 2)]
        [TestCase(1, 92, 2)]
        [TestCase(2, 0, 0)]
        [TestCase(2, 1, 3)]
        [TestCase(2, 2, 2)]
        [TestCase(2, 10, 2)]
        [TestCase(2, 13, 2)]
        [TestCase(2, 37, 2)]
        [TestCase(2, 42, 2)]
        [TestCase(2, 60, 2)]
        [TestCase(2, 66, 2)]
        [TestCase(2, 90, 2)]
        [TestCase(2, 92, 2)]
        [TestCase(10, 0, 0)]
        [TestCase(10, 1, 11)]
        [TestCase(10, 2, 6)]
        [TestCase(10, 10, 2)]
        [TestCase(10, 13, 2)]
        [TestCase(10, 37, 2)]
        [TestCase(10, 42, 2)]
        [TestCase(10, 60, 2)]
        [TestCase(10, 66, 2)]
        [TestCase(10, 90, 2)]
        [TestCase(10, 92, 2)]
        [TestCase(13, 0, 0)]
        [TestCase(13, 1, 14)]
        [TestCase(13, 2, 7)]
        [TestCase(13, 10, 2)]
        [TestCase(13, 13, 2)]
        [TestCase(13, 37, 2)]
        [TestCase(13, 42, 2)]
        [TestCase(13, 60, 2)]
        [TestCase(13, 66, 2)]
        [TestCase(13, 90, 2)]
        [TestCase(13, 92, 2)]
        [TestCase(37, 0, 0)]
        [TestCase(37, 1, 38)]
        [TestCase(37, 2, 19)]
        [TestCase(37, 10, 4)]
        [TestCase(37, 13, 3)]
        [TestCase(37, 37, 2)]
        [TestCase(37, 42, 2)]
        [TestCase(37, 60, 2)]
        [TestCase(37, 66, 2)]
        [TestCase(37, 90, 2)]
        [TestCase(37, 92, 2)]
        [TestCase(42, 0, 0)]
        [TestCase(42, 1, 43)]
        [TestCase(42, 2, 22)]
        [TestCase(42, 10, 5)]
        [TestCase(42, 13, 4)]
        [TestCase(42, 37, 2)]
        [TestCase(42, 42, 2)]
        [TestCase(42, 60, 2)]
        [TestCase(42, 66, 2)]
        [TestCase(42, 90, 2)]
        [TestCase(42, 92, 2)]
        [TestCase(60, 0, 0)]
        [TestCase(60, 1, 61)]
        [TestCase(60, 2, 31)]
        [TestCase(60, 10, 7)]
        [TestCase(60, 13, 5)]
        [TestCase(60, 37, 2)]
        [TestCase(60, 42, 2)]
        [TestCase(60, 60, 2)]
        [TestCase(60, 66, 2)]
        [TestCase(60, 90, 2)]
        [TestCase(60, 92, 2)]
        [TestCase(66, 0, 0)]
        [TestCase(66, 1, 67)]
        [TestCase(66, 2, 34)]
        [TestCase(66, 10, 7)]
        [TestCase(66, 13, 6)]
        [TestCase(66, 37, 2)]
        [TestCase(66, 42, 2)]
        [TestCase(66, 60, 2)]
        [TestCase(66, 66, 2)]
        [TestCase(66, 90, 2)]
        [TestCase(66, 92, 2)]
        [TestCase(90, 0, 0)]
        [TestCase(90, 1, 91)]
        [TestCase(90, 2, 46)]
        [TestCase(90, 10, 10)]
        [TestCase(90, 13, 7)]
        [TestCase(90, 37, 3)]
        [TestCase(90, 42, 3)]
        [TestCase(90, 60, 2)]
        [TestCase(90, 66, 2)]
        [TestCase(90, 90, 2)]
        [TestCase(90, 92, 2)]
        [TestCase(92, 0, 0)]
        [TestCase(92, 1, 93)]
        [TestCase(92, 2, 47)]
        [TestCase(92, 10, 10)]
        [TestCase(92, 13, 8)]
        [TestCase(92, 37, 3)]
        [TestCase(92, 42, 3)]
        [TestCase(92, 60, 2)]
        [TestCase(92, 66, 2)]
        [TestCase(92, 90, 2)]
        [TestCase(92, 92, 2)]
        public void DynamicallyWeightAdditionalSpecificAquaticEncounters(int magicCount, int specificAquaticCount, int expectedWeighting)
        {
            Assert.That(specificAquaticCount * expectedWeighting, Is.GreaterThan(magicCount).Or.EqualTo(0));
            if (expectedWeighting > 2)
                Assert.That(specificAquaticCount * (expectedWeighting - 1), Is.LessThanOrEqualTo(magicCount));

            specificEnvironmentEncounters.Clear();
            magicEncounters.Clear();

            var aquaticEncounters = new List<string>();
            var specificAquaticEncounters = new List<string>();

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            while (magicEncounters.Count < magicCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                magicEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            while (specificAquaticEncounters.Count < specificAquaticCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                specificAquaticEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            specifications.AllowAquatic = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(magicEncounters.Count, Is.LessThan(weightedEncounters.Count() / 2d).Or.EqualTo(weightedEncounters.Count()));

            foreach (var encounter in magicEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(1), "magic encounter");
            }

            foreach (var encounter in specificAquaticEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(expectedWeighting), "specific aquatic encounter");
            }
        }

        [Test]
        public void WeightAdditionalUndergroundAquaticEncounters()
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
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 2)]
        [TestCase(0, 2, 2)]
        [TestCase(0, 10, 2)]
        [TestCase(0, 13, 2)]
        [TestCase(0, 37, 2)]
        [TestCase(0, 42, 2)]
        [TestCase(0, 60, 2)]
        [TestCase(0, 66, 2)]
        [TestCase(0, 90, 2)]
        [TestCase(0, 92, 2)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 10, 2)]
        [TestCase(1, 13, 2)]
        [TestCase(1, 37, 2)]
        [TestCase(1, 42, 2)]
        [TestCase(1, 60, 2)]
        [TestCase(1, 66, 2)]
        [TestCase(1, 90, 2)]
        [TestCase(1, 92, 2)]
        [TestCase(2, 0, 0)]
        [TestCase(2, 1, 3)]
        [TestCase(2, 2, 2)]
        [TestCase(2, 10, 2)]
        [TestCase(2, 13, 2)]
        [TestCase(2, 37, 2)]
        [TestCase(2, 42, 2)]
        [TestCase(2, 60, 2)]
        [TestCase(2, 66, 2)]
        [TestCase(2, 90, 2)]
        [TestCase(2, 92, 2)]
        [TestCase(10, 0, 0)]
        [TestCase(10, 1, 11)]
        [TestCase(10, 2, 6)]
        [TestCase(10, 10, 2)]
        [TestCase(10, 13, 2)]
        [TestCase(10, 37, 2)]
        [TestCase(10, 42, 2)]
        [TestCase(10, 60, 2)]
        [TestCase(10, 66, 2)]
        [TestCase(10, 90, 2)]
        [TestCase(10, 92, 2)]
        [TestCase(13, 0, 0)]
        [TestCase(13, 1, 14)]
        [TestCase(13, 2, 7)]
        [TestCase(13, 10, 2)]
        [TestCase(13, 13, 2)]
        [TestCase(13, 37, 2)]
        [TestCase(13, 42, 2)]
        [TestCase(13, 60, 2)]
        [TestCase(13, 66, 2)]
        [TestCase(13, 90, 2)]
        [TestCase(13, 92, 2)]
        [TestCase(37, 0, 0)]
        [TestCase(37, 1, 38)]
        [TestCase(37, 2, 19)]
        [TestCase(37, 10, 4)]
        [TestCase(37, 13, 3)]
        [TestCase(37, 37, 2)]
        [TestCase(37, 42, 2)]
        [TestCase(37, 60, 2)]
        [TestCase(37, 66, 2)]
        [TestCase(37, 90, 2)]
        [TestCase(37, 92, 2)]
        [TestCase(42, 0, 0)]
        [TestCase(42, 1, 43)]
        [TestCase(42, 2, 22)]
        [TestCase(42, 10, 5)]
        [TestCase(42, 13, 4)]
        [TestCase(42, 37, 2)]
        [TestCase(42, 42, 2)]
        [TestCase(42, 60, 2)]
        [TestCase(42, 66, 2)]
        [TestCase(42, 90, 2)]
        [TestCase(42, 92, 2)]
        [TestCase(60, 0, 0)]
        [TestCase(60, 1, 61)]
        [TestCase(60, 2, 31)]
        [TestCase(60, 10, 7)]
        [TestCase(60, 13, 5)]
        [TestCase(60, 37, 2)]
        [TestCase(60, 42, 2)]
        [TestCase(60, 60, 2)]
        [TestCase(60, 66, 2)]
        [TestCase(60, 90, 2)]
        [TestCase(60, 92, 2)]
        [TestCase(66, 0, 0)]
        [TestCase(66, 1, 67)]
        [TestCase(66, 2, 34)]
        [TestCase(66, 10, 7)]
        [TestCase(66, 13, 6)]
        [TestCase(66, 37, 2)]
        [TestCase(66, 42, 2)]
        [TestCase(66, 60, 2)]
        [TestCase(66, 66, 2)]
        [TestCase(66, 90, 2)]
        [TestCase(66, 92, 2)]
        [TestCase(90, 0, 0)]
        [TestCase(90, 1, 91)]
        [TestCase(90, 2, 46)]
        [TestCase(90, 10, 10)]
        [TestCase(90, 13, 7)]
        [TestCase(90, 37, 3)]
        [TestCase(90, 42, 3)]
        [TestCase(90, 60, 2)]
        [TestCase(90, 66, 2)]
        [TestCase(90, 90, 2)]
        [TestCase(90, 92, 2)]
        [TestCase(92, 0, 0)]
        [TestCase(92, 1, 93)]
        [TestCase(92, 2, 47)]
        [TestCase(92, 10, 10)]
        [TestCase(92, 13, 8)]
        [TestCase(92, 37, 3)]
        [TestCase(92, 42, 3)]
        [TestCase(92, 60, 2)]
        [TestCase(92, 66, 2)]
        [TestCase(92, 90, 2)]
        [TestCase(92, 92, 2)]
        public void DynamicallyWeightAdditionalUndergroundAquaticEncounters(int magicCount, int undergroundAquaticCount, int expectedWeighting)
        {
            Assert.That(undergroundAquaticCount * expectedWeighting, Is.GreaterThan(magicCount).Or.EqualTo(0));
            if (expectedWeighting > 2)
                Assert.That(undergroundAquaticCount * (expectedWeighting - 1), Is.LessThanOrEqualTo(magicCount));

            specificEnvironmentEncounters.Clear();
            magicEncounters.Clear();

            var aquaticEncounters = new List<string>();
            var specificAquaticEncounters = new List<string>();
            var undergroundEncounters = new List<string>();
            var nightEncounters = new List<string>();
            var undergroundAquaticEncounters = new List<string>();

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            while (magicEncounters.Count < magicCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                magicEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                nightEncounters.Add(encounter);
            }

            while (undergroundAquaticEncounters.Count < undergroundAquaticCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                undergroundAquaticEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                nightEncounters.Add(encounter);
            }

            specifications.AllowAquatic = true;
            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(magicEncounters.Count, Is.LessThan(weightedEncounters.Count() / 2d).Or.EqualTo(weightedEncounters.Count()));

            foreach (var encounter in magicEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(1), "magic encounter");
            }

            foreach (var encounter in undergroundAquaticEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(expectedWeighting), "underground aquatic encounter");
            }
        }

        [Test]
        public void WeightSpecificEncounters()
        {
            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 3)]
        [TestCase(0, 2, 3)]
        [TestCase(0, 10, 3)]
        [TestCase(0, 13, 3)]
        [TestCase(0, 37, 3)]
        [TestCase(0, 42, 3)]
        [TestCase(0, 60, 3)]
        [TestCase(0, 66, 3)]
        [TestCase(0, 90, 3)]
        [TestCase(0, 92, 3)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 3)]
        [TestCase(1, 2, 3)]
        [TestCase(1, 10, 3)]
        [TestCase(1, 13, 3)]
        [TestCase(1, 37, 3)]
        [TestCase(1, 42, 3)]
        [TestCase(1, 60, 3)]
        [TestCase(1, 66, 3)]
        [TestCase(1, 90, 3)]
        [TestCase(1, 92, 3)]
        [TestCase(2, 0, 0)]
        [TestCase(2, 1, 1 + 2 + 2)]
        [TestCase(2, 2, 3)]
        [TestCase(2, 10, 3)]
        [TestCase(2, 13, 3)]
        [TestCase(2, 37, 3)]
        [TestCase(2, 42, 3)]
        [TestCase(2, 60, 3)]
        [TestCase(2, 66, 3)]
        [TestCase(2, 90, 3)]
        [TestCase(2, 92, 3)]
        [TestCase(10, 0, 0)]
        [TestCase(10, 1, 1 + 10 + 10)]
        [TestCase(10, 2, 1 + 5 + 5)]
        [TestCase(10, 10, 3)]
        [TestCase(10, 13, 3)]
        [TestCase(10, 37, 3)]
        [TestCase(10, 42, 3)]
        [TestCase(10, 60, 3)]
        [TestCase(10, 66, 3)]
        [TestCase(10, 90, 3)]
        [TestCase(10, 92, 3)]
        [TestCase(13, 0, 0)]
        [TestCase(13, 1, 1 + 13 + 13)]
        [TestCase(13, 2, 1 + 6 + 6)]
        [TestCase(13, 10, 3)]
        [TestCase(13, 13, 3)]
        [TestCase(13, 37, 3)]
        [TestCase(13, 42, 3)]
        [TestCase(13, 60, 3)]
        [TestCase(13, 66, 3)]
        [TestCase(13, 90, 3)]
        [TestCase(13, 92, 3)]
        [TestCase(37, 0, 0)]
        [TestCase(37, 1, 1 + 37 + 37)]
        [TestCase(37, 2, 1 + 18 + 18)]
        [TestCase(37, 10, 1 + 3 + 3)]
        [TestCase(37, 13, 1 + 2 + 2)]
        [TestCase(37, 37, 3)]
        [TestCase(37, 42, 3)]
        [TestCase(37, 60, 3)]
        [TestCase(37, 66, 3)]
        [TestCase(37, 90, 3)]
        [TestCase(37, 92, 3)]
        [TestCase(42, 0, 0)]
        [TestCase(42, 1, 1 + 42 + 42)]
        [TestCase(42, 2, 1 + 21 + 21)]
        [TestCase(42, 10, 1 + 4 + 4)]
        [TestCase(42, 13, 1 + 3 + 3)]
        [TestCase(42, 37, 3)]
        [TestCase(42, 42, 3)]
        [TestCase(42, 60, 3)]
        [TestCase(42, 66, 3)]
        [TestCase(42, 90, 3)]
        [TestCase(42, 92, 3)]
        [TestCase(60, 0, 0)]
        [TestCase(60, 1, 1 + 60 + 60)]
        [TestCase(60, 2, 1 + 30 + 30)]
        [TestCase(60, 10, 1 + 6 + 6)]
        [TestCase(60, 13, 1 + 4 + 4)]
        [TestCase(60, 37, 3)]
        [TestCase(60, 42, 3)]
        [TestCase(60, 60, 3)]
        [TestCase(60, 66, 3)]
        [TestCase(60, 90, 3)]
        [TestCase(60, 92, 3)]
        [TestCase(66, 0, 0)]
        [TestCase(66, 1, 1 + 66 + 66)]
        [TestCase(66, 2, 1 + 33 + 33)]
        [TestCase(66, 10, 1 + 6 + 6)]
        [TestCase(66, 13, 1 + 5 + 5)]
        [TestCase(66, 37, 3)]
        [TestCase(66, 42, 3)]
        [TestCase(66, 60, 3)]
        [TestCase(66, 66, 3)]
        [TestCase(66, 90, 3)]
        [TestCase(66, 92, 3)]
        [TestCase(90, 0, 0)]
        [TestCase(90, 1, 1 + 90 + 90)]
        [TestCase(90, 2, 1 + 45 + 45)]
        [TestCase(90, 10, 1 + 9 + 9)]
        [TestCase(90, 13, 1 + 6 + 6)]
        [TestCase(90, 37, 1 + 2 + 2)]
        [TestCase(90, 42, 1 + 2 + 2)]
        [TestCase(90, 60, 3)]
        [TestCase(90, 66, 3)]
        [TestCase(90, 90, 3)]
        [TestCase(90, 92, 3)]
        [TestCase(92, 0, 0)]
        [TestCase(92, 1, 1 + 92 + 92)]
        [TestCase(92, 2, 1 + 46 + 46)]
        [TestCase(92, 10, 1 + 9 + 9)]
        [TestCase(92, 13, 1 + 7 + 7)]
        [TestCase(92, 37, 1 + 2 + 2)]
        [TestCase(92, 42, 1 + 2 + 2)]
        [TestCase(92, 60, 3)]
        [TestCase(92, 66, 3)]
        [TestCase(92, 90, 3)]
        [TestCase(92, 92, 3)]
        public void DynamicallyWeightSpecificEncounters(int magicCount, int specificCount, int expectedWeighting)
        {
            Assert.That(specificCount * expectedWeighting, Is.GreaterThan(magicCount).Or.EqualTo(0));
            if (expectedWeighting > 3)
                Assert.That(specificCount * ((expectedWeighting - 1) / 2 - 1), Is.LessThanOrEqualTo(magicCount));

            specificEnvironmentEncounters.Clear();
            magicEncounters.Clear();

            while (magicEncounters.Count < magicCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                magicEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            while (specificEnvironmentEncounters.Count < specificCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                specificEnvironmentEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(magicEncounters.Count, Is.LessThan(weightedEncounters.Count() / 2d).Or.EqualTo(weightedEncounters.Count()));

            foreach (var encounter in magicEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(1), "magic encounter");
            }

            foreach (var encounter in specificEnvironmentEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(expectedWeighting), "specific environment encounter");
            }
        }

        [Test]
        public void WeightNativeSpecificAquaticEncounters()
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
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 3)]
        [TestCase(0, 2, 3)]
        [TestCase(0, 10, 3)]
        [TestCase(0, 13, 3)]
        [TestCase(0, 37, 3)]
        [TestCase(0, 42, 3)]
        [TestCase(0, 60, 3)]
        [TestCase(0, 66, 3)]
        [TestCase(0, 90, 3)]
        [TestCase(0, 92, 3)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 3)]
        [TestCase(1, 2, 3)]
        [TestCase(1, 10, 3)]
        [TestCase(1, 13, 3)]
        [TestCase(1, 37, 3)]
        [TestCase(1, 42, 3)]
        [TestCase(1, 60, 3)]
        [TestCase(1, 66, 3)]
        [TestCase(1, 90, 3)]
        [TestCase(1, 92, 3)]
        [TestCase(2, 0, 0)]
        [TestCase(2, 1, 1 + 2 + 2)]
        [TestCase(2, 2, 3)]
        [TestCase(2, 10, 3)]
        [TestCase(2, 13, 3)]
        [TestCase(2, 37, 3)]
        [TestCase(2, 42, 3)]
        [TestCase(2, 60, 3)]
        [TestCase(2, 66, 3)]
        [TestCase(2, 90, 3)]
        [TestCase(2, 92, 3)]
        [TestCase(10, 0, 0)]
        [TestCase(10, 1, 1 + 10 + 10)]
        [TestCase(10, 2, 1 + 5 + 5)]
        [TestCase(10, 10, 3)]
        [TestCase(10, 13, 3)]
        [TestCase(10, 37, 3)]
        [TestCase(10, 42, 3)]
        [TestCase(10, 60, 3)]
        [TestCase(10, 66, 3)]
        [TestCase(10, 90, 3)]
        [TestCase(10, 92, 3)]
        [TestCase(13, 0, 0)]
        [TestCase(13, 1, 1 + 13 + 13)]
        [TestCase(13, 2, 1 + 6 + 6)]
        [TestCase(13, 10, 3)]
        [TestCase(13, 13, 3)]
        [TestCase(13, 37, 3)]
        [TestCase(13, 42, 3)]
        [TestCase(13, 60, 3)]
        [TestCase(13, 66, 3)]
        [TestCase(13, 90, 3)]
        [TestCase(13, 92, 3)]
        [TestCase(37, 0, 0)]
        [TestCase(37, 1, 1 + 37 + 37)]
        [TestCase(37, 2, 1 + 18 + 18)]
        [TestCase(37, 10, 1 + 3 + 3)]
        [TestCase(37, 13, 1 + 2 + 2)]
        [TestCase(37, 37, 3)]
        [TestCase(37, 42, 3)]
        [TestCase(37, 60, 3)]
        [TestCase(37, 66, 3)]
        [TestCase(37, 90, 3)]
        [TestCase(37, 92, 3)]
        [TestCase(42, 0, 0)]
        [TestCase(42, 1, 1 + 42 + 42)]
        [TestCase(42, 2, 1 + 21 + 21)]
        [TestCase(42, 10, 1 + 4 + 4)]
        [TestCase(42, 13, 1 + 3 + 3)]
        [TestCase(42, 37, 3)]
        [TestCase(42, 42, 3)]
        [TestCase(42, 60, 3)]
        [TestCase(42, 66, 3)]
        [TestCase(42, 90, 3)]
        [TestCase(42, 92, 3)]
        [TestCase(60, 0, 0)]
        [TestCase(60, 1, 1 + 60 + 60)]
        [TestCase(60, 2, 1 + 30 + 30)]
        [TestCase(60, 10, 1 + 6 + 6)]
        [TestCase(60, 13, 1 + 4 + 4)]
        [TestCase(60, 37, 3)]
        [TestCase(60, 42, 3)]
        [TestCase(60, 60, 3)]
        [TestCase(60, 66, 3)]
        [TestCase(60, 90, 3)]
        [TestCase(60, 92, 3)]
        [TestCase(66, 0, 0)]
        [TestCase(66, 1, 1 + 66 + 66)]
        [TestCase(66, 2, 1 + 33 + 33)]
        [TestCase(66, 10, 1 + 6 + 6)]
        [TestCase(66, 13, 1 + 5 + 5)]
        [TestCase(66, 37, 3)]
        [TestCase(66, 42, 3)]
        [TestCase(66, 60, 3)]
        [TestCase(66, 66, 3)]
        [TestCase(66, 90, 3)]
        [TestCase(66, 92, 3)]
        [TestCase(90, 0, 0)]
        [TestCase(90, 1, 1 + 90 + 90)]
        [TestCase(90, 2, 1 + 45 + 45)]
        [TestCase(90, 10, 1 + 9 + 9)]
        [TestCase(90, 13, 1 + 6 + 6)]
        [TestCase(90, 37, 1 + 2 + 2)]
        [TestCase(90, 42, 1 + 2 + 2)]
        [TestCase(90, 60, 3)]
        [TestCase(90, 66, 3)]
        [TestCase(90, 90, 3)]
        [TestCase(90, 92, 3)]
        [TestCase(92, 0, 0)]
        [TestCase(92, 1, 1 + 92 + 92)]
        [TestCase(92, 2, 1 + 46 + 46)]
        [TestCase(92, 10, 1 + 9 + 9)]
        [TestCase(92, 13, 1 + 7 + 7)]
        [TestCase(92, 37, 1 + 2 + 2)]
        [TestCase(92, 42, 1 + 2 + 2)]
        [TestCase(92, 60, 3)]
        [TestCase(92, 66, 3)]
        [TestCase(92, 90, 3)]
        [TestCase(92, 92, 3)]
        public void DynamicallyWeightNativeSpecificAquaticEncounters(int magicCount, int specificAquaticCount, int expectedWeighting)
        {
            Assert.That(specificAquaticCount * expectedWeighting, Is.GreaterThan(magicCount).Or.EqualTo(0));
            if (expectedWeighting > 3)
                Assert.That(specificAquaticCount * ((expectedWeighting - 1) / 2 - 1), Is.LessThanOrEqualTo(magicCount));

            specificEnvironmentEncounters.Clear();
            magicEncounters.Clear();

            var aquaticEncounters = new List<string>();
            var specificAquaticEncounters = new List<string>();

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            while (magicEncounters.Count < magicCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                magicEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            while (specificAquaticEncounters.Count < specificAquaticCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                specificAquaticEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                timeOfDayEncounters.Add(encounter);
            }

            specifications.Environment = EnvironmentConstants.Aquatic;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(magicEncounters.Count, Is.LessThan(weightedEncounters.Count() / 2d).Or.EqualTo(weightedEncounters.Count()));

            foreach (var encounter in magicEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(1), "magic encounter");
            }

            foreach (var encounter in specificAquaticEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(expectedWeighting), "specific aquatic encounter");
            }
        }

        [TestCase(EnvironmentConstants.Aquatic, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, true, true)]
        [TestCase(EnvironmentConstants.Underground, true, false)]
        [TestCase(EnvironmentConstants.Underground, true, true)]
        public void WeightNativeUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground)
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
        }

        [TestCase(0, 0, 0)]
        [TestCase(0, 1, 3)]
        [TestCase(0, 2, 3)]
        [TestCase(0, 10, 3)]
        [TestCase(0, 13, 3)]
        [TestCase(0, 37, 3)]
        [TestCase(0, 42, 3)]
        [TestCase(0, 60, 3)]
        [TestCase(0, 66, 3)]
        [TestCase(0, 90, 3)]
        [TestCase(0, 92, 3)]
        [TestCase(1, 0, 0)]
        [TestCase(1, 1, 3)]
        [TestCase(1, 2, 3)]
        [TestCase(1, 10, 3)]
        [TestCase(1, 13, 3)]
        [TestCase(1, 37, 3)]
        [TestCase(1, 42, 3)]
        [TestCase(1, 60, 3)]
        [TestCase(1, 66, 3)]
        [TestCase(1, 90, 3)]
        [TestCase(1, 92, 3)]
        [TestCase(2, 0, 0)]
        [TestCase(2, 1, 1 + 2 + 2)]
        [TestCase(2, 2, 3)]
        [TestCase(2, 10, 3)]
        [TestCase(2, 13, 3)]
        [TestCase(2, 37, 3)]
        [TestCase(2, 42, 3)]
        [TestCase(2, 60, 3)]
        [TestCase(2, 66, 3)]
        [TestCase(2, 90, 3)]
        [TestCase(2, 92, 3)]
        [TestCase(10, 0, 0)]
        [TestCase(10, 1, 1 + 10 + 10)]
        [TestCase(10, 2, 1 + 5 + 5)]
        [TestCase(10, 10, 3)]
        [TestCase(10, 13, 3)]
        [TestCase(10, 37, 3)]
        [TestCase(10, 42, 3)]
        [TestCase(10, 60, 3)]
        [TestCase(10, 66, 3)]
        [TestCase(10, 90, 3)]
        [TestCase(10, 92, 3)]
        [TestCase(13, 0, 0)]
        [TestCase(13, 1, 1 + 13 + 13)]
        [TestCase(13, 2, 1 + 6 + 6)]
        [TestCase(13, 10, 3)]
        [TestCase(13, 13, 3)]
        [TestCase(13, 37, 3)]
        [TestCase(13, 42, 3)]
        [TestCase(13, 60, 3)]
        [TestCase(13, 66, 3)]
        [TestCase(13, 90, 3)]
        [TestCase(13, 92, 3)]
        [TestCase(37, 0, 0)]
        [TestCase(37, 1, 1 + 37 + 37)]
        [TestCase(37, 2, 1 + 18 + 18)]
        [TestCase(37, 10, 1 + 3 + 3)]
        [TestCase(37, 13, 1 + 2 + 2)]
        [TestCase(37, 37, 3)]
        [TestCase(37, 42, 3)]
        [TestCase(37, 60, 3)]
        [TestCase(37, 66, 3)]
        [TestCase(37, 90, 3)]
        [TestCase(37, 92, 3)]
        [TestCase(42, 0, 0)]
        [TestCase(42, 1, 1 + 42 + 42)]
        [TestCase(42, 2, 1 + 21 + 21)]
        [TestCase(42, 10, 1 + 4 + 4)]
        [TestCase(42, 13, 1 + 3 + 3)]
        [TestCase(42, 37, 3)]
        [TestCase(42, 42, 3)]
        [TestCase(42, 60, 3)]
        [TestCase(42, 66, 3)]
        [TestCase(42, 90, 3)]
        [TestCase(42, 92, 3)]
        [TestCase(60, 0, 0)]
        [TestCase(60, 1, 1 + 60 + 60)]
        [TestCase(60, 2, 1 + 30 + 30)]
        [TestCase(60, 10, 1 + 6 + 6)]
        [TestCase(60, 13, 1 + 4 + 4)]
        [TestCase(60, 37, 3)]
        [TestCase(60, 42, 3)]
        [TestCase(60, 60, 3)]
        [TestCase(60, 66, 3)]
        [TestCase(60, 90, 3)]
        [TestCase(60, 92, 3)]
        [TestCase(66, 0, 0)]
        [TestCase(66, 1, 1 + 66 + 66)]
        [TestCase(66, 2, 1 + 33 + 33)]
        [TestCase(66, 10, 1 + 6 + 6)]
        [TestCase(66, 13, 1 + 5 + 5)]
        [TestCase(66, 37, 3)]
        [TestCase(66, 42, 3)]
        [TestCase(66, 60, 3)]
        [TestCase(66, 66, 3)]
        [TestCase(66, 90, 3)]
        [TestCase(66, 92, 3)]
        [TestCase(90, 0, 0)]
        [TestCase(90, 1, 1 + 90 + 90)]
        [TestCase(90, 2, 1 + 45 + 45)]
        [TestCase(90, 10, 1 + 9 + 9)]
        [TestCase(90, 13, 1 + 6 + 6)]
        [TestCase(90, 37, 1 + 2 + 2)]
        [TestCase(90, 42, 1 + 2 + 2)]
        [TestCase(90, 60, 3)]
        [TestCase(90, 66, 3)]
        [TestCase(90, 90, 3)]
        [TestCase(90, 92, 3)]
        [TestCase(92, 0, 0)]
        [TestCase(92, 1, 1 + 92 + 92)]
        [TestCase(92, 2, 1 + 46 + 46)]
        [TestCase(92, 10, 1 + 9 + 9)]
        [TestCase(92, 13, 1 + 7 + 7)]
        [TestCase(92, 37, 1 + 2 + 2)]
        [TestCase(92, 42, 1 + 2 + 2)]
        [TestCase(92, 60, 3)]
        [TestCase(92, 66, 3)]
        [TestCase(92, 90, 3)]
        [TestCase(92, 92, 3)]
        public void DynamicallyWeightNativeUndergroundAquaticEncounters(int magicCount, int undergroundAquaticCount, int expectedWeighting)
        {
            Assert.That(undergroundAquaticCount * expectedWeighting, Is.GreaterThan(magicCount).Or.EqualTo(0));
            if (expectedWeighting > 3)
                Assert.That(undergroundAquaticCount * ((expectedWeighting - 1) / 2 - 1), Is.LessThanOrEqualTo(magicCount));

            specificEnvironmentEncounters.Clear();
            magicEncounters.Clear();

            var aquaticEncounters = new List<string>();
            var specificAquaticEncounters = new List<string>();
            var undergroundEncounters = new List<string>();
            var nightEncounters = new List<string>();
            var undergroundAquaticEncounters = new List<string>();

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            while (magicEncounters.Count < magicCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                magicEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                nightEncounters.Add(encounter);
            }

            while (undergroundAquaticEncounters.Count < undergroundAquaticCount)
            {
                var encounter = $"{Guid.NewGuid().ToString()}/{Guid.NewGuid().ToString()}";
                undergroundAquaticEncounters.Add(encounter);
                levelEncounters.Add(encounter);
                nightEncounters.Add(encounter);
            }

            specifications.AllowUnderground = true;
            specifications.Environment = EnvironmentConstants.Aquatic;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(magicEncounters.Count, Is.LessThan(weightedEncounters.Count() / 2).Or.EqualTo(weightedEncounters.Count()));

            foreach (var encounter in magicEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(1), "magic encounter");
            }

            foreach (var encounter in undergroundAquaticEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e.First().Key == encounter.Split('/')[0]), Is.EqualTo(expectedWeighting), "underground aquatic encounter");
            }
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
                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
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
                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
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
                "specific underground encounter", "amount",
                "underground aquatic encounter", "amount",
                "underground aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Underground, true);
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
                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowAquatic: true);
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
                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
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
                "specific environment encounter", "specific environment amount",
                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
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
                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowUnderground: true);
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
                "specific civilized encounter", "amount",
                "specific civilized encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowAquatic: true, allowUnderground: true);
        }
    }
}
