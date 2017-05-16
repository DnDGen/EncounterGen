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
        private List<string> timeOfDayEncounters;
        private List<string> magicEncounters;
        private List<string> specificEnvironmentEncounters;
        private List<string> landEncounters;
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
            magicEncounters = new List<string> { "magic encounter/magic amount", "other magic encounter/other magic amount" };
            specificEnvironmentEncounters = new List<string> { "specific environment encounter/specific environment amount", "other specific environment encounter/other specific environment amount" };
            landEncounters = new List<string> { "land encounter/land amount", "other land encounter/other land amount" };
            filters = new Dictionary<string, List<string>>();
            wildernessEncounters = new List<string>();
            specifications = new EncounterSpecifications();

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

            mockAmountSelector.Setup(s => s.SelectAverageEncounterLevel(It.IsAny<string>())).Returns((string e) => GetLevel(e));

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, timeOfDay, TableNameConstants.EncounterGroups)).Returns(timeOfDayEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, GroupConstants.Magic, TableNameConstants.EncounterGroups)).Returns(magicEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, string.Empty, TableNameConstants.EncounterGroups)).Returns(Enumerable.Empty<string>());
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, specifications.SpecificEnvironment, TableNameConstants.EncounterGroups)).Returns(specificEnvironmentEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, GroupConstants.Land, TableNameConstants.EncounterGroups)).Returns(landEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, GroupConstants.Wilderness, TableNameConstants.EncounterGroups)).Returns(wildernessEncounters);

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

            Assert.That(weightedEncounters, Is.Not.Empty);

            var extras = weightedEncounters.Skip(expectedArray.Length / 2);
            Assert.That(extras, Is.Empty);
            Assert.That(weightedEncounters.Length, Is.EqualTo(expectedArray.Length / 2));

            for (var i = 0; i < expectedArray.Length; i += 2)
            {
                var index = i / 2;
                var failureMessage = $"Index {index}";

                AssertTypesAndAmounts(weightedEncounters[index], failureMessage, expectedArray[i], expectedArray[i + 1]);
            }
        }

        [Test]
        public void SingleWeightAdditionalAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

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
        public void SingleWeightAdditionalUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);

            levelEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.AddRange(timeOfDayEncounters);

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

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
        }

        [Test]
        public void DoubleWeightNativeAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "aquatic encounter", "amount",

                "aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Aquatic);
        }

        [Test]
        public void DoubleWeightNativeUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);

            levelEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.AddRange(timeOfDayEncounters);

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

            var expectedEncounters = new[]
            {
                "underground encounter", "amount",

                "underground encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Underground);
        }

        [Test]
        public void DoubleWeightAdditionalSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

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

        [Test]
        public void DoubleWeightAdditionalUndergroundAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(undergroundAquaticEncounters);

            levelEncounters.Add(undergroundAquaticEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

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

        [Test]
        public void TripleWeightSpecificEncounters()
        {
            levelEncounters.Add(specificEnvironmentEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            var expectedEncounters = new[]
            {
                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void TripleWeightNativeSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                "specific aquatic encounter", "amount",

                "specific aquatic encounter", "amount",

                "specific aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Aquatic);
        }

        [TestCase(EnvironmentConstants.Aquatic, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, true, true)]
        [TestCase(EnvironmentConstants.Underground, true, false)]
        [TestCase(EnvironmentConstants.Underground, true, true)]
        public void TripleWeightNativeUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground)
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(undergroundAquaticEncounters);

            levelEncounters.Add(undergroundAquaticEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

            var expectedEncounters = new[]
            {
                "underground aquatic encounter", "amount",

                "underground aquatic encounter", "amount",

                "underground aquatic encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, environment, allowAquatic, allowUnderground);
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
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(undergroundAquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(specificUndergroundEncounters);

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

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

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
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(specificCivilizedEncounters);

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

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized);
        }

        [Test]
        public void IfUndergroundEnvironment_SetTimeOfDayToNight()
        {
            var undergroundEncounters = new[] { "dungeon encounter/amount", "other dungeon encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific dungeon encounter/amount", "other specific dungeon encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(specificUndergroundEncounters);

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

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific dungeon encounter", "amount",
                "land encounter", "land amount",
                "dungeon encounter", "amount",

                "specific dungeon encounter", "amount",
                "land encounter", "land amount",
                "dungeon encounter", "amount",

                "specific dungeon encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Underground);
        }

        [Test]
        public void IfAllowingUnderground_SetTimeOfDayToNight()
        {
            var undergroundEncounters = new[] { "dungeon encounter/amount", "other dungeon encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);

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

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "dungeon encounter", "amount",

                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",

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
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(civilizedEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(specificCivilizedEncounters);

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

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized);
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
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

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
            levelEncounters.Add(specificEnvironmentEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[0]);

            timeOfDayEncounters.Add(magicEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(specifications);

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

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Aquatic, true);
        }

        [Test]
        public void AddAquaticToUnderground()
        {
            var dungeonEncounters = new[] { "dungeon encounter/amount", "other dungeon encounter/other amount" };
            var specificDungeonEncounters = new[] { "specific dungeon encounter/amount", "other specific dungeon encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(specificDungeonEncounters);

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dungeonEncounters[0]);
            levelEncounters.Add(specificDungeonEncounters[0]);
            levelEncounters.Add(aquaticEncounters[0]);
            levelEncounters.Add(aquaticEncounters[1]);
            levelEncounters.Add(specificAquaticEncounters[0]);
            levelEncounters.Add(specificAquaticEncounters[1]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(dungeonEncounters[0]);
            nightEncounters.Add(specificDungeonEncounters[0]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[0]);

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific dungeon encounter", "amount",
                "land encounter", "land amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "dungeon encounter", "amount",

                "specific dungeon encounter", "amount",
                "land encounter", "land amount",
                "specific aquatic encounter", "amount",
                "dungeon encounter", "amount",

                "specific dungeon encounter", "amount",
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Underground, true);
        }

        [Test]
        public void AddAquaticToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(specificCivilizedEncounters);

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

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

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized, allowAquatic: true);
        }

        [Test]
        public void CanAddUndergroundToAnEnvironment()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);

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

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(specifications);

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
        }

        [Test]
        public void AddingUndergroundToUnderground()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(specificUndergroundEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(undergroundEncounters[0]);
            levelEncounters.Add(specificUndergroundEncounters[0]);

            var nightEncounters = new List<string>();
            nightEncounters.Add(magicEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

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

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Underground, allowUnderground: true);
        }

        [Test]
        public void AddUndergroundAndAquatic()
        {
            var dungeonEncounters = new[] { "dungeon encounter/amount", "other dungeon encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(dungeonEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(undergroundAquaticEncounters);

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

            levelEncounters.Add(magicEncounters[0]);
            levelEncounters.Add(magicEncounters[1]);
            levelEncounters.Add(landEncounters[0]);
            levelEncounters.Add(landEncounters[1]);
            levelEncounters.Add(dungeonEncounters[0]);
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
            nightEncounters.Add(dungeonEncounters[0]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

            var expectedEncounters = new[]
            {
                "magic encounter", "magic amount",
                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "aquatic encounter", "amount",
                "specific aquatic encounter", "amount",
                "dungeon encounter", "amount",
                "underground aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",
                "land encounter", "land amount",
                "specific aquatic encounter", "amount",
                "underground aquatic encounter", "amount",

                "specific environment encounter", "specific environment amount",
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
        }

        [Test]
        public void AddUndergroundToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(specificCivilizedEncounters);

            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);

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

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

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

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized, allowUnderground: true);
        }

        [Test]
        public void AddUndergroundAndAquaticToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Civilized, TableNameConstants.EncounterGroups)).Returns(specificCivilizedEncounters);

            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground, TableNameConstants.EncounterGroups)).Returns(undergroundEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(undergroundAquaticEncounters);

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(aquaticEncounters);
            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, temperature + EnvironmentConstants.Aquatic, TableNameConstants.EncounterGroups)).Returns(specificAquaticEncounters);

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

            mockCollectionSelector.Setup(s => s.ExplodeInto(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night, TableNameConstants.EncounterGroups)).Returns(nightEncounters);

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

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized, true, true);
        }
    }
}
