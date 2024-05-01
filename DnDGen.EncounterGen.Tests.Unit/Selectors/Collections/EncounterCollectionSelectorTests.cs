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
        private const int commonWeight = 4;
        private const int uncommonWeight = 3;
        private const int rareWeight = 2;
        private const int veryRareWeight = 1;

        private IEncounterCollectionSelector encounterCollectionSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<IEncounterFormatter> mockEncounterSelector;
        private List<string> levelEncounters;
        private List<string> timeOfDayEncounters;
        private List<string> specificEnvironmentEncounters;
        private List<string> landEncounters;
        private List<string> extraplanarEncounters;
        private List<string> anyEncounters;
        private List<string> civilizedEncounters;
        private List<string> undeadEncounters;
        private Dictionary<string, List<string>> filters;
        private List<string> wildernessEncounters;
        private EncounterSpecifications specifications;
        private Dictionary<string, IEnumerable<string>> encounterGroups;
        private Dictionary<string, IEnumerable<string>> encounterLevels;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockEncounterSelector = new Mock<IEncounterFormatter>();
            encounterCollectionSelector = new EncounterCollectionSelector(mockCollectionSelector.Object, mockEncounterSelector.Object);

            levelEncounters = new List<string>();
            timeOfDayEncounters = new List<string>();
            extraplanarEncounters = new List<string> { "extraplanar encounter", "other extraplanar encounter" };
            anyEncounters = new List<string> { "any encounter", "other any encounter" };
            civilizedEncounters = new List<string> { "civilized encounter", "other civilized encounter" };
            undeadEncounters = new List<string> { "undead encounter", "other undead encounter" };
            specificEnvironmentEncounters = new List<string>
            {
                "specific environment encounter",
                "other specific environment encounter"
            };
            landEncounters = new List<string> { "land encounter", "other land encounter" };
            filters = new Dictionary<string, List<string>>();
            wildernessEncounters = new List<string>();
            specifications = new EncounterSpecifications();
            encounterGroups = new Dictionary<string, IEnumerable<string>>();
            encounterLevels = new Dictionary<string, IEnumerable<string>>();

            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);
            SetupEncounterLevel("level encounter", 9266);

            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);
            timeOfDayEncounters.Add("time of day encounter");

            SetupFilter("filter");
            SetupFilter("other filter");

            SetupEncounterFilter("filter");
            SetupEncounterFilter("other filter");

            specifications.Environment = environment;
            specifications.Level = 9266;
            specifications.Temperature = temperature;
            specifications.TimeOfDay = timeOfDay;

            SetUpCreatureBasedEncounterGroup(timeOfDay, timeOfDayEncounters);
            SetUpCreatureBasedEncounterGroup(GroupConstants.Extraplanar, extraplanarEncounters);
            SetUpCreatureBasedEncounterGroup(string.Empty, Enumerable.Empty<string>());
            SetUpCreatureBasedEncounterGroup(specifications.SpecificEnvironment, specificEnvironmentEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Land, landEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Any, anyEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(CreatureDataConstants.Types.Undead, undeadEncounters);
            SetUpCreatureBasedEncounterGroup(GroupConstants.Wilderness, wildernessEncounters);

            SetUpEncounterGroup(timeOfDay, timeOfDayEncounters);
            SetUpEncounterGroup(GroupConstants.Extraplanar, extraplanarEncounters);
            SetUpEncounterGroup(string.Empty, Enumerable.Empty<string>());
            SetUpEncounterGroup(specifications.SpecificEnvironment, specificEnvironmentEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Land, landEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Any, anyEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(CreatureDataConstants.Types.Undead, undeadEncounters);
            SetUpEncounterGroup(GroupConstants.Wilderness, wildernessEncounters);

            mockCollectionSelector.Setup(s => s.SelectAllFrom(TableNameConstants.EncounterGroups)).Returns(encounterGroups);
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterGroups, It.IsAny<string>()))
                .Returns((string t, string n) => encounterGroups.ContainsKey(n) ? encounterGroups[n] : Enumerable.Empty<string>());
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.AverageEncounterLevels, It.IsAny<string>()))
                .Returns((string t, string l) => GetEncounterLevel(l));
            mockCollectionSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>()))
                .Returns((IEnumerable<Dictionary<string, string>> collection) => collection.Last());
            mockCollectionSelector
                .Setup(s => s.CreateWeighted(
                    It.IsAny<IEnumerable<string>>(),
                    It.IsAny<IEnumerable<string>>(),
                    It.IsAny<IEnumerable<string>>(),
                    It.IsAny<IEnumerable<string>>()))
                .Returns(CreateWeighted);

            mockEncounterSelector.Setup(s => s.SelectCreaturesAndAmountsFrom(It.IsAny<string>())).Returns(ParseCreatureAndAmount);
        }

        private IEnumerable<string> GetEncounterLevel(string level)
        {
            if (!encounterLevels.ContainsKey(level))
                return Enumerable.Empty<string>();

            return encounterLevels[level].Where(levelEncounters.Contains);
        }

        [Obsolete]
        private void SetupFilter(string filter, params string[] filterValues)
        {
            filters[filter] = new List<string>(filterValues);
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, filter)).Returns(filters[filter]);
        }

        private void SetupEncounterFilter(string filter, params string[] filterValues)
        {
            filters[filter] = new List<string>(filterValues);
            SetUpEncounterGroup("filter", filters[filter]);
        }

        private IEnumerable<string> CreateWeighted(IEnumerable<string> common, IEnumerable<string> uncommon, IEnumerable<string> rare, IEnumerable<string> veryRare)
        {
            var weighted = Enumerable.Empty<string>();

            if (common?.Any() == true)
                weighted = weighted.Concat(Enumerable.Repeat(common, commonWeight).SelectMany(e => e));

            if (uncommon?.Any() == true)
                weighted = weighted.Concat(Enumerable.Repeat(uncommon, uncommonWeight).SelectMany(e => e));

            if (rare?.Any() == true)
                weighted = weighted.Concat(Enumerable.Repeat(rare, rareWeight).SelectMany(e => e));

            if (veryRare?.Any() == true)
                weighted = weighted.Concat(Enumerable.Repeat(veryRare, veryRareWeight).SelectMany(e => e));

            return weighted;
        }

        private void SetupEncounterLevel(string encounter, int level)
        {
            levelEncounters.Add(encounter);

            if (!encounterLevels.ContainsKey(level.ToString()))
                encounterLevels[level.ToString()] = new List<string>();

            encounterLevels[level.ToString()] = encounterLevels[level.ToString()].Concat(new[] { encounter });
        }

        [Obsolete]
        private void SetUpCreatureBasedEncounterGroup(string creatureGroup, IEnumerable<string> encounters)
        {
            var creatureCollection = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, creatureGroup)).Returns(creatureCollection);
            mockCollectionSelector.Setup(s => s.Flatten(encounterGroups, creatureCollection)).Returns(encounters);

            encounterGroups[creatureGroup] = encounters;
        }

        private void SetUpEncounterGroup(string name, IEnumerable<string> encounters)
        {
            encounterGroups[name] = encounters;
        }

        [Obsolete]
        private Dictionary<string, string> ParseCreatureAndAmount(string encounter)
        {
            return encounter.Split(',').ToDictionary(e => e.Split('/')[0], e => e.Split('/')[1]);
        }

        [Test]
        public void SelectRandomFrom_SelectingRandomGetsEncounterTypesAndAmountsFromSelector()
        {
            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, ("specific environment encounter", "specific environment amount"));
        }

        [Test]
        public void SelectRandomFrom_IfSelectingRandomAndNoEncountersExist_ThrowException()
        {
            levelEncounters.Clear();

            Assert.That(() => encounterCollectionSelector.SelectRandomFrom(specifications),
                Throws.ArgumentException.With.Message.EqualTo($"No valid encounters exist for {specifications.Description}"));
        }

        [Obsolete]
        private void AssertTypesAndAmounts(Dictionary<string, string> actual, params (string Creature, string Amount)[] expected)
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.Not.Empty);

            for (var i = 0; i < expected.Length; i++)
            {
                Assert.That(actual.Keys, Contains.Item(expected[i].Creature));
                Assert.That(actual[expected[i].Creature], Is.EqualTo(expected[i].Amount));
            }

            Assert.That(actual.Count, Is.EqualTo(expected.Length));
        }

        [Test]
        public void SelectRandomFrom_GetRandomEncounterTypesAndAmountsFromSelector()
        {
            mockCollectionSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>()))
                .Returns((IEnumerable<Dictionary<string, string>> collection) => collection.ElementAt(1));

            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[2], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[2]);

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, ("other specific environment encounter", "other specific environment amount"));
        }

        [Test]
        public void SelectRandomFrom_GetMultipleRandomEncounterTypesAndAmountsFromSelector()
        {
            specificEnvironmentEncounters.Add("other encounter/other amount,encounter/amount");
            SetupEncounterLevel("other encounter/other amount,encounter/amount", 9266);
            timeOfDayEncounters.Add("other encounter/other amount,encounter/amount");

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, ("encounter", "amount"), ("other encounter", "other amount"));
        }

        [Test]
        public void SelectAllWeightedFrom_ReturnEmptyWhenNoneMatchLevel()
        {
            levelEncounters.Clear();

            var expectedEncounters = Enumerable.Empty<(string, string, int)>();

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_ReturnEmptyWhenNoneMatchFilter()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var expectedEncounters = Enumerable.Empty<(string, string, int)>();

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_ReturnEmptyWhenCivilizedAndAllAreWilderness()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);
            wildernessEncounters.AddRange(levelEncounters);

            var expectedEncounters = Enumerable.Empty<(string, string, int)>();

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Civilized);
        }

        [Test]
        public void SelectAllWeightedFrom_ReturnEmptyWhenNoneMatchTimeOfDay()
        {
            timeOfDayEncounters.Clear();

            var expectedEncounters = Enumerable.Empty<(string, string, int)>();

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_FilterOutEncountersThatDoNotMatchLevel()
        {
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_FilterOutEncountersThatDoNotMatchTimeOfDay()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_FilterOutEncountersThatDoNotMatchFilter()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            filters["filter"].Add("specific environment encounter");
            filters["other filter"].Add("extraplanar encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_DoNotFilterOutEncountersThatMatchFilter()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            filters["filter"].Add("specific environment encounter");
            filters["filter"].Add("extraplanar encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightExtraplanarEncounters()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Obsolete]
        private void AssertEncounterWeight(
            IEnumerable<(string Creature, string Amount, int Weight)> expectedEncounters,
            string targetEnvironment = environment,
            bool allowAquatic = false,
            bool allowUnderground = false)
        {
            specifications.Environment = targetEnvironment;
            specifications.AllowAquatic = allowAquatic;
            specifications.AllowUnderground = allowUnderground;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Obsolete]
        private void AssertEncounterWeight(
            IEnumerable<(string Creature, string Amount, int Weight)> expectedEncounters,
            IEnumerable<Dictionary<string, string>> weightedEncounters)
        {
            if (expectedEncounters.Any())
                Assert.That(weightedEncounters, Is.Not.Empty);
            else
                Assert.That(weightedEncounters, Is.Empty);

            foreach (var expectedEncounter in expectedEncounters)
            {
                var matchingEncounters = weightedEncounters.Where(e => e.ContainsKey(expectedEncounter.Creature));

                Assert.That(
                    matchingEncounters.Count,
                    Is.EqualTo(expectedEncounter.Weight),
                    $"{expectedEncounter.Creature}/{expectedEncounter.Amount}: {expectedEncounter.Weight}");

                foreach (var matchedEncounter in matchingEncounters)
                {
                    AssertTypesAndAmounts(matchedEncounter, (expectedEncounter.Creature, expectedEncounter.Amount));
                }
            }

            Assert.That(weightedEncounters.Count, Is.EqualTo(expectedEncounters.Sum(e => e.Weight)));
        }

        private void AssertEncounterWeight(
            IEnumerable<(string Encounter, int Weight)> expectedEncounters,
            IEnumerable<string> weightedEncounters)
        {
            if (expectedEncounters.Any())
                Assert.That(weightedEncounters, Is.Not.Empty);
            else
                Assert.That(weightedEncounters, Is.Empty);

            foreach (var expectedEncounter in expectedEncounters)
            {
                Assert.That(weightedEncounters.Count(e => e == expectedEncounter.Encounter), Is.EqualTo(expectedEncounter.Weight));
            }

            Assert.That(weightedEncounters.Count, Is.EqualTo(expectedEncounters.Sum(e => e.Weight)));
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAllExtraplanarEncounters()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAdditionalAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(aquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(aquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("aquatic encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
        }

        [Test]
        public void SelectAllWeightedFrom_DoNotWeightCommonEncountersIfNone()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            specificEnvironmentEncounters.Clear();

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_DoNotWeightSpecificEncountersIfNone()
        {
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var nightEncounters = new List<string>();

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            specificEnvironmentEncounters.Clear();

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("land encounter", "land amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("underground aquatic encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_DoNotWeightUndergroundAquaticEncountersIfNone()
        {
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var nightEncounters = new List<string>();

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAdditionalUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel(undergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.AddRange(timeOfDayEncounters);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("underground encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightLandEncounters()
        {
            SetupEncounterLevel(landEncounters[0], 9266);
            timeOfDayEncounters.Add(landEncounters[0]);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAllLandEncounters()
        {
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(landEncounters[0], 9266);
            timeOfDayEncounters.Add(landEncounters[0]);
            SetupEncounterLevel(landEncounters[1], 9266);
            timeOfDayEncounters.Add(landEncounters[1]);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("other specific environment encounter", "other specific environment amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAnyEncounters()
        {
            SetupEncounterLevel(anyEncounters[0], 9266);
            timeOfDayEncounters.Add(anyEncounters[0]);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAllAnyEncounters()
        {
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(anyEncounters[0], 9266);
            timeOfDayEncounters.Add(anyEncounters[0]);
            SetupEncounterLevel(anyEncounters[1], 9266);
            timeOfDayEncounters.Add(anyEncounters[1]);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("other specific environment encounter", "other specific environment amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightNativeAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                ("specific aquatic encounter", "amount", commonWeight),
                ("aquatic encounter", "amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Aquatic);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAllNativeAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[1], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[1]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[1]);

            var expectedEncounters = new[]
            {
                ("specific aquatic encounter", "amount", commonWeight),
                ("other specific aquatic encounter", "other amount", commonWeight),
                ("aquatic encounter", "amount", commonWeight),
                ("other aquatic encounter", "other amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Aquatic);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightNativeUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("specific underground encounter", "amount", commonWeight),
                ("underground encounter", "amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Underground);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAllNativeUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[1], 9266);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);
            nightEncounters.Add(specificUndergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[1]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("specific underground encounter", "amount", commonWeight),
                ("other specific underground encounter", "other amount", commonWeight),
                ("underground encounter", "amount", commonWeight),
                ("other underground encounter", "other amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Underground);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAdditionalSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("specific aquatic encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAllAdditionalSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[1]);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("other specific environment encounter", "other specific environment amount", commonWeight),
                ("specific aquatic encounter", "amount", uncommonWeight),
                ("other specific aquatic encounter", "other amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAdditionalUndergroundAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("underground aquatic encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAllAdditionalUndergroundAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[1], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[1]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[1]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("other specific environment encounter", "other specific environment amount", commonWeight),
                ("underground aquatic encounter", "amount", uncommonWeight),
                ("other underground aquatic encounter", "other amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightSpecificEncounters()
        {
            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAllSpecificEncounters()
        {
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("other specific environment encounter", "other specific environment amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightNativeSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                ("specific aquatic encounter", "amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Aquatic);
        }

        [Test]
        public void SelectAllWeightedFrom_WeightAllNativeSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[1]);

            var expectedEncounters = new[]
            {
                ("specific aquatic encounter", "amount", commonWeight),
                ("other specific aquatic encounter", "other amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Aquatic);
        }

        [TestCase(EnvironmentConstants.Aquatic, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, true, true)]
        [TestCase(EnvironmentConstants.Underground, true, false)]
        [TestCase(EnvironmentConstants.Underground, true, true)]
        public void SelectAllWeightedFrom_WeightNativeUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground)
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            levelEncounters.Clear();
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("underground aquatic encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, environment, allowAquatic, allowUnderground);
        }

        [TestCase(EnvironmentConstants.Aquatic, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, true, true)]
        [TestCase(EnvironmentConstants.Underground, true, false)]
        [TestCase(EnvironmentConstants.Underground, true, true)]
        public void SelectAllWeightedFrom_WeightAllNativeUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground)
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            levelEncounters.Clear();
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[1], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[1]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("underground aquatic encounter", "amount", uncommonWeight),
                ("other underground aquatic encounter", "other amount", uncommonWeight),
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
        public void SelectAllWeightedFrom_ShouldAddUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground, bool hasUndergroundAquatic)
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);
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

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = environment;
            specifications.AllowAquatic = allowAquatic;
            specifications.AllowUnderground = allowUnderground;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(weightedEncounters, Is.Not.Empty);
            Assert.That(weightedEncounters.Any(e => e.Keys.Contains("underground aquatic encounter")), Is.EqualTo(hasUndergroundAquatic));
        }

        [Test]
        public void SelectAllWeightedFrom_IfCivilized_DoNotGetWildlife()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific civilized encounter", "amount", commonWeight),
                ("civilized encounter", "civilized amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized);
        }

        [Test]
        public void BUG_SelectAllWeightedFrom_IfCivilized_UndeadFromAnyAreRare()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            anyEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific civilized encounter", "amount", commonWeight),
                ("civilized encounter", "civilized amount", commonWeight),
                ("undead encounter", "undead amount", rareWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized);
        }

        [Test]
        public void BUG_SelectAllWeightedFrom_IfNotCivilized_UndeadFromAnyAreCommon()
        {
            anyEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("undead encounter", "undead amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void BUG_SelectAllWeightedFrom_IfCivilized_UndeadFromLandAreRare()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            landEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific civilized encounter", "amount", commonWeight),
                ("civilized encounter", "civilized amount", commonWeight),
                ("undead encounter", "undead amount", rareWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized);
        }

        [Test]
        public void BUG_SelectAllWeightedFrom_IfNotCivilized_UndeadFromLandAreCommon()
        {
            landEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("undead encounter", "undead amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void BUG_SelectAllWeightedFrom_IfCivilized_UndergroundUndeadAreRare()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            var undergroundEncounters = new List<string> { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            anyEncounters.AddRange(undeadEncounters);
            undergroundEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(undergroundEncounters[0]);
            timeOfDayEncounters.Add(undergroundEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific civilized encounter", "amount", commonWeight),
                ("civilized encounter", "civilized amount", commonWeight),
                ("undead encounter", "undead amount", rareWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
                ("other underground encounter", "other amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowUnderground: true);
        }

        [Test]
        public void BUG_SelectAllWeightedFrom_IfNotCivilized_UndergroundUndeadFromAnyAreCommon()
        {
            var undergroundEncounters = new List<string> { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            anyEncounters.AddRange(undeadEncounters);
            undergroundEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(undergroundEncounters[0]);
            timeOfDayEncounters.Add(undergroundEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("undead encounter", "undead amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
                ("other underground encounter", "other amount", uncommonWeight),
                ("underground encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
        }

        [Test]
        public void BUG_SelectAllWeightedFrom_IfNotCivilized_UndergroundUndeadFromLandAreCommon()
        {
            var undergroundEncounters = new List<string> { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            landEncounters.AddRange(undeadEncounters);
            undergroundEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(undergroundEncounters[0]);
            timeOfDayEncounters.Add(undergroundEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("undead encounter", "undead amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
                ("other underground encounter", "other amount", uncommonWeight),
                ("underground encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
        }

        [Test]
        public void BUG_SelectAllWeightedFrom_IfNotCivilized_UndergroundUndeadAreUncommon()
        {
            var undergroundEncounters = new List<string> { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            undergroundEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(undergroundEncounters[0]);
            timeOfDayEncounters.Add(undergroundEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("undead encounter", "undead amount", uncommonWeight),
                ("land encounter", "land amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
                ("other underground encounter", "other amount", uncommonWeight),
                ("underground encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_IfUndergroundEnvironment_SetTimeOfDayToNight()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific underground encounter", "amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("underground encounter", "amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Underground);
        }

        [Test]
        public void SelectAllWeightedFrom_IfAllowingUnderground_SetTimeOfDayToNight()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("underground encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_GetAllPossibleWeightedEncounters_WithoutAquaticOrUnderground()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_GetAllPossibleWeightedCivilizedEncounters()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific civilized encounter", "amount", commonWeight),
                ("civilized encounter", "civilized amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized);
        }

        [Test]
        public void SelectAllWeightedFrom_SelectAllWeightedReturnsNoEncounters()
        {
            levelEncounters.Clear();
            var allEncounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(specifications);
            Assert.That(allEncounterTypesAndAmounts, Is.Empty);
        }

        [Test]
        public void SelectRandomFrom_ApplyFiltersToRandomEncounter()
        {
            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            SetupEncounterLevel("wrong encounter/wrong amount", 9266);
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            filters["filter"].Add("specific environment encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, ("specific environment encounter", "specific environment amount"));
        }

        [Test]
        public void SelectRandomFrom_EncounterMatchesIfAnyCreatureMatchesFilter()
        {
            mockCollectionSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>()))
                .Returns((IEnumerable<Dictionary<string, string>> collection) => collection.ElementAt(1));

            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            specificEnvironmentEncounters.Add("other encounter/other amount,encounter/amount");
            SetupEncounterLevel("wrong encounter/wrong amount", 9266);
            SetupEncounterLevel("other encounter/other amount,encounter/amount", 9266);
            timeOfDayEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("other encounter/other amount,encounter/amount");

            filters["filter"].Add("encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, ("other encounter", "other amount"), ("encounter", "amount"));
        }

        [Test]
        public void SelectRandomFrom_EncounterMatchesIfCreatureMatchesAnyFilter()
        {
            mockCollectionSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>()))
                .Returns((IEnumerable<Dictionary<string, string>> collection) => collection.ElementAt(1));

            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            specificEnvironmentEncounters.Add("other encounter/other amount");
            SetupEncounterLevel("wrong encounter/wrong amount", 9266);
            SetupEncounterLevel("other encounter/other amount", 9266);
            timeOfDayEncounters.Add("wrong encounter/wrong amount");
            timeOfDayEncounters.Add("other encounter/other amount");

            filters["filter"].Add("encounter");
            filters["other filter"].Add("other encounter");

            specifications.CreatureTypeFilters = new[] { "filter", "other filter" };

            var encounterTypesAndAmounts = encounterCollectionSelector.SelectRandomFrom(specifications);
            AssertTypesAndAmounts(encounterTypesAndAmounts, ("other encounter", "other amount"));
        }

        [Test]
        public void SelectAllWeightedFrom_ApplyFiltersToAllWeightedEncounters()
        {
            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            SetupEncounterLevel("wrong encounter/wrong amount", 9266);
            timeOfDayEncounters.Add("wrong encounter/wrong amount");

            filters["filter"].Add("specific environment encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var allEncounterTypesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(specifications).ToArray();
            Assert.That(allEncounterTypesAndAmounts.Count, Is.EqualTo(commonWeight));

            for (var i = 0; i < commonWeight; i++)
                AssertTypesAndAmounts(allEncounterTypesAndAmounts[i], ("specific environment encounter", "specific environment amount"));
        }

        [Test]
        public void SelectAllWeightedFrom_AquaticEnvironmentDoesNotHaveNonAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific aquatic encounter", "amount", commonWeight),
                ("aquatic encounter", "amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Aquatic);
        }

        [Test]
        public void SelectAllWeightedFrom_CanAddAquaticToAnEnvironment()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("aquatic encounter", "amount", uncommonWeight),
                ("specific aquatic encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true);
        }

        [Test]
        public void SelectAllWeightedFrom_AddingAquaticToAquatic()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific aquatic encounter", "amount", commonWeight),
                ("aquatic encounter", "amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Aquatic, allowAquatic: true);
        }

        [Test]
        public void SelectAllWeightedFrom_AddAquaticToUnderground()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[1], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[1], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific underground encounter", "amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("aquatic encounter", "amount", uncommonWeight),
                ("specific aquatic encounter", "amount", uncommonWeight),
                ("underground encounter", "amount", commonWeight),
                ("underground aquatic encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, EnvironmentConstants.Underground, true);
        }

        [Test]
        public void SelectAllWeightedFrom_AddAquaticToCivilized()
        {
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[1], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[1]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[1]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(aquaticEncounters[0]);
            wildernessEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                ("civilized encounter", "civilized amount", commonWeight),
                ("other specific aquatic encounter", "other amount", uncommonWeight),
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("other any encounter", "other any amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("other aquatic encounter", "other amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowAquatic: true);
        }

        [Test]
        public void SelectAllWeightedFrom_CanAddUndergroundToAnEnvironment()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(extraplanarEncounters[1]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(anyEncounters[1]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(landEncounters[1]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("underground encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_AddingUndergroundToUnderground()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var specificUndergroundEncounters = new[] { "specific underground encounter/amount", "other specific underground encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific underground encounter", "amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("underground encounter", "amount", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Underground, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_GetAllPossibleWeightedEncounters_AddUndergroundAndAquatic()
        {
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[1], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", "extraplanar amount", rareWeight),
                ("specific environment encounter", "specific environment amount", commonWeight),
                ("any encounter", "any amount", commonWeight),
                ("land encounter", "land amount", commonWeight),
                ("aquatic encounter", "amount", uncommonWeight),
                ("specific aquatic encounter", "amount", uncommonWeight),
                ("underground encounter", "amount", uncommonWeight),
                ("underground aquatic encounter", "amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, allowAquatic: true, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_AddUndergroundToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(extraplanarEncounters[1]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(anyEncounters[1]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(landEncounters[1]);
            nightEncounters.Add(civilizedEncounters[0]);
            nightEncounters.Add(specificCivilizedEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific civilized encounter", "amount", commonWeight),
                ("civilized encounter", "civilized amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("other underground encounter", "other amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_AddUndergroundAndAquaticToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[1], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[1], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(extraplanarEncounters[1]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(anyEncounters[1]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(landEncounters[1]);
            nightEncounters.Add(civilizedEncounters[0]);
            nightEncounters.Add(specificCivilizedEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[1]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(aquaticEncounters[1]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[1]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);
            wildernessEncounters.Add(undergroundAquaticEncounters[0]);
            wildernessEncounters.Add(aquaticEncounters[0]);
            wildernessEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific civilized encounter", "amount", commonWeight),
                ("civilized encounter", "civilized amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("other aquatic encounter", "other amount", uncommonWeight),
                ("other specific aquatic encounter", "other amount", uncommonWeight),
                ("other underground encounter", "other amount", uncommonWeight),
                ("other underground aquatic encounter", "other amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowAquatic: true, allowUnderground: true);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_AllDefaults_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom();

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        [Ignore("If nothing is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_AllDefaults_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom();

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetEnvironment_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(environment: "environment");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetEnvironment_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(environment: "environment");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetTemperature_Some()
        {
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Desert, new[] { "my desert encounter/my desert amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my forest encounter/my forest amount" });
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my hills encounter/my hills amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my desert encounter/my desert amount",
                "my forest encounter/my forest amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my hills encounter/my hills amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, new[]
            {
                "my temperature aquatic encounter/my temperature aquatic amount",
                "my wrong encounter/my wrong amount"
            });

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Civilized, new[]
            {
                "my temperature civilized encounter/my temperature civilized amount",
                "my wrong encounter/my wrong amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my temperature civilized encounter/my warm civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(temperature: "temperature");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetTemperature_None()
        {
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Desert, new[] { "my desert encounter/my desert amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my forest encounter/my forest amount" });
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my hills encounter/my hills amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my desert encounter/my desert amount",
                "my forest encounter/my forest amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my hills encounter/my hills amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, new[]
            {
                "my temperature aquatic encounter/my temperature aquatic amount",
                "my wrong encounter/my wrong amount"
            });

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Civilized, new[]
            {
                "my temperature civilized encounter/my temperature civilized amount",
                "my wrong encounter/my wrong amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my temperature civilized encounter/my warm civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(temperature: "temperature");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetTimeOfDay_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(timeOfDay: "time of day");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetTimeOfDay_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(timeOfDay: "time of day");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetLevel_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 783);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(level: 783);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetLevel_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 7);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(level: 783);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetAllowAquatic_Some(bool aquatic)
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(allowAquatic: aquatic);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        [Ignore("If only the allow aquatic is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetAllowAquatic_None(bool aquatic)
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(allowAquatic: aquatic);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetAllowUnderground_Some(bool underground)
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(allowUnderground: underground);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        [Ignore("If only the allow underground is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetAllowUnderground_None(bool underground)
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(allowUnderground: underground);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetFilter_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            SetupFilter("filter 1", "my land encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(filters: new[] { "filter 1" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        [Ignore("If only the filter is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetFilter_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            SetupFilter("filter 1", "my wrong encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(filters: new[] { "filter 1" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetFilters_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            SetupFilter("filter 1", "my land encounter");
            SetupFilter("filter 2", "my any encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        [Ignore("If only the filters are toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetFilters_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            SetupFilter("filter 1", "my wrong encounter");
            SetupFilter("filter 2", "my other wrong encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSomeSetValues_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            SetupFilter("filter 1", "my warm encounter", "my land encounter");
            SetupFilter("filter 2", "my any encounter", "my extraplanar encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(
                environment: "environment",
                timeOfDay: "time of day",
                allowAquatic: false,
                filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSomeSetValues_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 666);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            SetupFilter("filter 1", "my warm encounter", "my wrong encounter");
            SetupFilter("filter 2", "my any encounter", "my other wrong encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(
                environment: "environment",
                timeOfDay: "time of day",
                allowAquatic: false,
                filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromAllSetValues_Some()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my encounter/my amount", 783);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            SetupFilter("filter 1", "my encounter", "my other encounter");
            SetupFilter("filter 2", "my other land encounter", "my other any encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom("environment", "temperature", "time of day", 783, false, false, "filter 1", "filter 2");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromAllSetValues_None()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            SetupFilter("filter 1", "my wrong encounter", "my other encounter");
            SetupFilter("filter 2", "my other wrong encounter", "my other aquatic encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom("environment", "temperature", "time of day", 783, false, false, "filter 1", "filter 2");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectRandomEncounterFrom_SelectingRandomGetsEncounterFromSelector()
        {
            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);
            Assert.That(encounter, Is.EqualTo("specific environment encounter"));
        }

        [Test]
        public void SelectRandomEncounterFrom_IfSelectingRandomAndNoEncountersExist_ThrowException()
        {
            levelEncounters.Clear();

            Assert.That(() => encounterCollectionSelector.SelectRandomEncounterFrom(specifications),
                Throws.ArgumentException.With.Message.EqualTo($"No valid encounters exist for {specifications.Description}"));
        }

        [Test]
        public void SelectRandomEncounterFrom_GetRandomEncounterFromSelector()
        {
            mockCollectionSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>()))
                .Returns((IEnumerable<Dictionary<string, string>> collection) => collection.ElementAt(1));

            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[2], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[2]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);
            Assert.That(encounter, Is.EqualTo("other specific environment encounter"));
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_ReturnEmptyWhenNoneMatchLevel()
        {
            levelEncounters.Clear();

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = Enumerable.Empty<(string, int)>();
            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_ReturnEmptyWhenNoneMatchFilter()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = Enumerable.Empty<(string, int)>();
            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_ReturnEmptyWhenCivilizedAndAllAreWilderness()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);
            wildernessEncounters.AddRange(levelEncounters);

            specifications.Environment = EnvironmentConstants.Civilized;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = Enumerable.Empty<(string, int)>();
            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_ReturnEmptyWhenNoneMatchTimeOfDay()
        {
            timeOfDayEncounters.Clear();

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = Enumerable.Empty<(string, int)>();
            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_FilterOutEncountersThatDoNotMatchLevel()
        {
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_FilterOutEncountersThatDoNotMatchTimeOfDay()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_FilterOutEncountersThatDoNotMatchFilter()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            filters["filter"].Add("specific environment encounter");
            filters["other filter"].Add("extraplanar encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_DoNotFilterOutEncountersThatMatchFilter()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            filters["filter"].Add("specific environment encounter");
            filters["filter"].Add("extraplanar encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightExtraplanarEncounters()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAllExtraplanarEncounters()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("other extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAdditionalAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(aquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(aquaticEncounters[0]);

            specifications.AllowAquatic = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_DoNotWeightCommonEncountersIfNone()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            specificEnvironmentEncounters.Clear();

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_DoNotWeightSpecificEncountersIfNone()
        {
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter", "other underground aquatic encounter" };
            var nightEncounters = new List<string>();

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            specificEnvironmentEncounters.Clear();

            specifications.AllowAquatic = true;
            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("land encounter", commonWeight),
                ("any encounter", commonWeight),
                ("underground aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_DoNotWeightUndergroundAquaticEncountersIfNone()
        {
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter", "other underground aquatic encounter" };
            var nightEncounters = new List<string>();

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);

            specifications.AllowAquatic = true;
            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("land encounter", commonWeight),
                ("any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAdditionalUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel(undergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.AddRange(timeOfDayEncounters);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("underground encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightLandEncounters()
        {
            SetupEncounterLevel(landEncounters[0], 9266);
            timeOfDayEncounters.Add(landEncounters[0]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("land encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAllLandEncounters()
        {
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(landEncounters[0], 9266);
            timeOfDayEncounters.Add(landEncounters[0]);
            SetupEncounterLevel(landEncounters[1], 9266);
            timeOfDayEncounters.Add(landEncounters[1]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("other specific environment encounter", commonWeight),
                ("land encounter", commonWeight),
                ("other land encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAnyEncounters()
        {
            SetupEncounterLevel(anyEncounters[0], 9266);
            timeOfDayEncounters.Add(anyEncounters[0]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAllAnyEncounters()
        {
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(anyEncounters[0], 9266);
            timeOfDayEncounters.Add(anyEncounters[0]);
            SetupEncounterLevel(anyEncounters[1], 9266);
            timeOfDayEncounters.Add(anyEncounters[1]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("other specific environment encounter", commonWeight),
                ("any encounter", commonWeight),
                ("other any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightNativeAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            specifications.Environment = EnvironmentConstants.Aquatic;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific aquatic encounter", commonWeight),
                ("aquatic encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAllNativeAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[1], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[1]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[1]);

            specifications.Environment = EnvironmentConstants.Aquatic;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific aquatic encounter", commonWeight),
                ("other specific aquatic encounter", commonWeight),
                ("aquatic encounter", commonWeight),
                ("other aquatic encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightNativeUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var specificUndergroundEncounters = new[] { "specific underground encounter", "other specific underground encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = EnvironmentConstants.Underground;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific underground encounter", commonWeight),
                ("underground encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAllNativeUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var specificUndergroundEncounters = new[] { "specific underground encounter", "other specific underground encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[1], 9266);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);
            nightEncounters.Add(specificUndergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[1]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = EnvironmentConstants.Underground;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific underground encounter", commonWeight),
                ("other specific underground encounter", commonWeight),
                ("underground encounter", commonWeight),
                ("other underground encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAdditionalSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            specifications.AllowAquatic = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("specific aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAllAdditionalSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[1]);

            specifications.AllowAquatic = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("other specific environment encounter", commonWeight),
                ("specific aquatic encounter", uncommonWeight),
                ("other specific aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAdditionalUndergroundAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter", "other underground aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowAquatic = true;
            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("underground aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAllAdditionalUndergroundAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter", "other underground aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[1], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[1]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[1]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowAquatic = true;
            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("other specific environment encounter", commonWeight),
                ("underground aquatic encounter", uncommonWeight),
                ("other underground aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightSpecificEncounters()
        {
            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAllSpecificEncounters()
        {
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific environment encounter", commonWeight),
                ("other specific environment encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightNativeSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            specifications.Environment = EnvironmentConstants.Aquatic;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific aquatic encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_WeightAllNativeSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[1]);

            specifications.Environment = EnvironmentConstants.Aquatic;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("specific aquatic encounter", commonWeight),
                ("other specific aquatic encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [TestCase(EnvironmentConstants.Aquatic, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, true, true)]
        [TestCase(EnvironmentConstants.Underground, true, false)]
        [TestCase(EnvironmentConstants.Underground, true, true)]
        public void SelectAllWeightedEncountersFrom_WeightNativeUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground)
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter", "other underground aquatic encounter" };
            var specificUndergroundEncounters = new[] { "specific underground encounter", "other specific underground encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            levelEncounters.Clear();
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = environment;
            specifications.AllowAquatic = allowAquatic;
            specifications.AllowUnderground = allowUnderground;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("underground aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [TestCase(EnvironmentConstants.Aquatic, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, true, true)]
        [TestCase(EnvironmentConstants.Underground, true, false)]
        [TestCase(EnvironmentConstants.Underground, true, true)]
        public void SelectAllWeightedEncountersFrom_WeightAllNativeUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground)
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter", "other underground aquatic encounter" };
            var specificUndergroundEncounters = new[] { "specific underground encounter", "other specific underground encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            levelEncounters.Clear();
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[1], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[1]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = environment;
            specifications.AllowAquatic = allowAquatic;
            specifications.AllowUnderground = allowUnderground;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("underground aquatic encounter", uncommonWeight),
                ("other underground aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
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
        public void SelectAllWeightedEncountersFrom_ShouldAddUndergroundAquaticEncounters(
            string environment,
            bool allowAquatic,
            bool allowUnderground,
            bool hasUndergroundAquatic)
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter", "other underground aquatic encounter" };
            var specificUndergroundEncounters = new[] { "specific underground encounter", "other specific underground encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);
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

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(weightedEncounters, Is.Not.Empty);
            Assert.That(weightedEncounters.Any(e => e.Contains("underground aquatic encounter")), Is.EqualTo(hasUndergroundAquatic));
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_IfCivilized_DoNotGetWildlife()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);

            specifications.Environment = EnvironmentConstants.Civilized;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", rareWeight),
                ("specific civilized encounter", commonWeight),
                ("civilized encounter", commonWeight),
                ("other land encounter", commonWeight),
                ("other any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void BUG_SelectAllWeightedEncountersFrom_IfCivilized_UndeadFromAnyAreRare()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            anyEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);

            specifications.Environment = EnvironmentConstants.Civilized;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", rareWeight),
                ("specific civilized encounter", commonWeight),
                ("civilized encounter", commonWeight),
                ("undead encounter", rareWeight),
                ("other land encounter", commonWeight),
                ("other any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void BUG_SelectAllWeightedEncountersFrom_IfNotCivilized_UndeadFromAnyAreCommon()
        {
            anyEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("other extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("undead encounter", commonWeight),
                ("land encounter", commonWeight),
                ("other land encounter", commonWeight),
                ("any encounter", commonWeight),
                ("other any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void BUG_SelectAllWeightedEncountersFrom_IfCivilized_UndeadFromLandAreRare()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            landEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);

            specifications.Environment = EnvironmentConstants.Civilized;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", rareWeight),
                ("specific civilized encounter", commonWeight),
                ("civilized encounter", commonWeight),
                ("undead encounter", rareWeight),
                ("other land encounter", commonWeight),
                ("other any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void BUG_SelectAllWeightedEncountersFrom_IfNotCivilized_UndeadFromLandAreCommon()
        {
            landEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("other extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("undead encounter", commonWeight),
                ("land encounter", commonWeight),
                ("other land encounter", commonWeight),
                ("any encounter", commonWeight),
                ("other any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void BUG_SelectAllWeightedEncountersFrom_IfCivilized_UndergroundUndeadAreRare()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            var undergroundEncounters = new List<string> { "underground encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            anyEncounters.AddRange(undeadEncounters);
            undergroundEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(undergroundEncounters[0]);
            timeOfDayEncounters.Add(undergroundEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = EnvironmentConstants.Civilized;
            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", rareWeight),
                ("specific civilized encounter", commonWeight),
                ("civilized encounter", commonWeight),
                ("undead encounter", rareWeight),
                ("other land encounter", commonWeight),
                ("other any encounter", commonWeight),
                ("other underground encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void BUG_SelectAllWeightedEncountersFrom_IfNotCivilized_UndergroundUndeadFromAnyAreCommon()
        {
            var undergroundEncounters = new List<string> { "underground encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            anyEncounters.AddRange(undeadEncounters);
            undergroundEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(undergroundEncounters[0]);
            timeOfDayEncounters.Add(undergroundEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("other extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("undead encounter", commonWeight),
                ("land encounter", commonWeight),
                ("other land encounter", commonWeight),
                ("any encounter", commonWeight),
                ("other any encounter", commonWeight),
                ("other underground encounter", uncommonWeight),
                ("underground encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void BUG_SelectAllWeightedEncountersFrom_IfNotCivilized_UndergroundUndeadFromLandAreCommon()
        {
            var undergroundEncounters = new List<string> { "underground encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            landEncounters.AddRange(undeadEncounters);
            undergroundEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(undergroundEncounters[0]);
            timeOfDayEncounters.Add(undergroundEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("other extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("undead encounter", commonWeight),
                ("land encounter", commonWeight),
                ("other land encounter", commonWeight),
                ("any encounter", commonWeight),
                ("other any encounter", commonWeight),
                ("other underground encounter", uncommonWeight),
                ("underground encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void BUG_SelectAllWeightedEncountersFrom_IfNotCivilized_UndergroundUndeadAreUncommon()
        {
            var undergroundEncounters = new List<string> { "underground encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            undergroundEncounters.AddRange(undeadEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undeadEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(undeadEncounters[0]);
            timeOfDayEncounters.Add(undeadEncounters[1]);
            timeOfDayEncounters.Add(undergroundEncounters[0]);
            timeOfDayEncounters.Add(undergroundEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var nightEncounters = new List<string>(timeOfDayEncounters);
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("other extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("undead encounter", uncommonWeight),
                ("land encounter", commonWeight),
                ("other land encounter", commonWeight),
                ("any encounter", commonWeight),
                ("other any encounter", commonWeight),
                ("other underground encounter", uncommonWeight),
                ("underground encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_IfUndergroundEnvironment_SetTimeOfDayToNight()
        {
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var specificUndergroundEncounters = new[] { "specific underground encounter", "other specific underground encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = EnvironmentConstants.Underground;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific underground encounter", commonWeight),
                ("land encounter", commonWeight),
                ("any encounter", commonWeight),
                ("underground encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_IfAllowingUnderground_SetTimeOfDayToNight()
        {
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("land encounter", commonWeight),
                ("any encounter", commonWeight),
                ("underground encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_GetAllPossibleWeightedEncounters_WithoutAquaticOrUnderground()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("land encounter", commonWeight),
                ("any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_GetAllPossibleWeightedCivilizedEncounters()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);

            specifications.Environment = EnvironmentConstants.Civilized;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", rareWeight),
                ("specific civilized encounter", commonWeight),
                ("civilized encounter", commonWeight),
                ("other land encounter", commonWeight),
                ("other any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_SelectAllWeightedReturnsNoEncounters()
        {
            levelEncounters.Clear();
            var allEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(allEncounters, Is.Empty);
        }

        [Test]
        public void SelectRandomEncounterFrom_ApplyFiltersToRandomEncounter()
        {
            specificEnvironmentEncounters.Add("wrong encounter");
            SetupEncounterLevel("wrong encounter", 9266);
            timeOfDayEncounters.Add("wrong encounter");

            filters["filter"].Add("specific environment encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);
            Assert.That(encounter, Is.EqualTo("specific environment encounter"));
        }

        [Test]
        public void SelectRandomEncounterFrom_EncounterMatchesIfAnyCreatureMatchesFilter()
        {
            mockCollectionSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<Dictionary<string, string>>>()))
                .Returns((IEnumerable<Dictionary<string, string>> collection) => collection.ElementAt(1));

            specificEnvironmentEncounters.Add("wrong encounter");
            specificEnvironmentEncounters.Add("other encounter");
            SetupEncounterLevel("wrong encounter", 9266);
            SetupEncounterLevel("other encounter", 9266);
            timeOfDayEncounters.Add("wrong encounter");
            timeOfDayEncounters.Add("other encounter");

            filters["filter"].Add("encounter");
            filters["filter"].Add("other encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);
            Assert.That(encounter, Is.EqualTo("other encounter"));
        }

        [Test]
        public void SelectRandomEncounterFrom_EncounterMatchesIfCreatureMatchesAnyFilter()
        {
            mockCollectionSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>()))
                .Returns((IEnumerable<string> collection) => collection.ElementAt(1));

            specificEnvironmentEncounters.Add("wrong encounter");
            specificEnvironmentEncounters.Add("other encounter");
            SetupEncounterLevel("wrong encounter", 9266);
            SetupEncounterLevel("other encounter", 9266);
            timeOfDayEncounters.Add("wrong encounter");
            timeOfDayEncounters.Add("other encounter");

            filters["filter"].Add("encounter");
            filters["other filter"].Add("other encounter");

            specifications.CreatureTypeFilters = new[] { "filter", "other filter" };

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);
            Assert.That(encounter, Is.EqualTo("other encounter"));
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_ApplyFiltersToAllWeightedEncounters()
        {
            specificEnvironmentEncounters.Add("wrong encounter");
            SetupEncounterLevel("wrong encounter", 9266);
            timeOfDayEncounters.Add("wrong encounter");

            filters["filter"].Add("specific environment encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var allEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);
            var expected = new[] { ("specific environment encounter", commonWeight) };
            AssertEncounterWeight(expected, allEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_AquaticEnvironmentDoesNotHaveNonAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            specifications.Environment = EnvironmentConstants.Aquatic;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific aquatic encounter", commonWeight),
                ("aquatic encounter", commonWeight),
                ("any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CanAddAquaticToAnEnvironment()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            specifications.AllowAquatic = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("any encounter", commonWeight),
                ("land encounter", commonWeight),
                ("aquatic encounter", uncommonWeight),
                ("specific aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_AddingAquaticToAquatic()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            specifications.Environment = EnvironmentConstants.Aquatic;
            specifications.AllowAquatic = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific aquatic encounter", commonWeight),
                ("aquatic encounter", commonWeight),
                ("any encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_AddAquaticToUnderground()
        {
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var specificUndergroundEncounters = new[] { "specific underground encounter", "other specific underground encounter" };
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter", "other underground aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[1], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[1], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = EnvironmentConstants.Underground;
            specifications.AllowAquatic = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific underground encounter", commonWeight),
                ("any encounter", commonWeight),
                ("land encounter", commonWeight),
                ("aquatic encounter", uncommonWeight),
                ("specific aquatic encounter", uncommonWeight),
                ("underground encounter", commonWeight),
                ("underground aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_AddAquaticToCivilized()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[1], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[1]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[1]);
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[0]);
            timeOfDayEncounters.Add(aquaticEncounters[1]);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);
            timeOfDayEncounters.Add(specificAquaticEncounters[1]);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(aquaticEncounters[0]);
            wildernessEncounters.Add(specificAquaticEncounters[0]);

            specifications.Environment = EnvironmentConstants.Civilized;
            specifications.AllowAquatic = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("civilized encounter", commonWeight),
                ("other specific aquatic encounter", uncommonWeight),
                ("other extraplanar encounter", rareWeight),
                ("other any encounter", commonWeight),
                ("other land encounter", commonWeight),
                ("other aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CanAddUndergroundToAnEnvironment()
        {
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(extraplanarEncounters[1]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(anyEncounters[1]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(landEncounters[1]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("any encounter", commonWeight),
                ("land encounter", commonWeight),
                ("underground encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_AddingUndergroundToUnderground()
        {
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var specificUndergroundEncounters = new[] { "specific underground encounter", "other specific underground encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Underground, specificUndergroundEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(specificUndergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(specificUndergroundEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = EnvironmentConstants.Underground;
            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific underground encounter", commonWeight),
                ("any encounter", commonWeight),
                ("land encounter", commonWeight),
                ("underground encounter", commonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_GetAllPossibleWeightedEncounters_AddUndergroundAndAquatic()
        {
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter", "other underground aquatic encounter" };
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[1], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(specificEnvironmentEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowAquatic = true;
            specifications.AllowUnderground = true;

            var weightedEncounters = encounterCollectionSelector.SelectAllWeightedEncountersFrom(specifications);

            var expectedEncounters = new[]
            {
                ("extraplanar encounter", rareWeight),
                ("specific environment encounter", commonWeight),
                ("any encounter", commonWeight),
                ("land encounter", commonWeight),
                ("aquatic encounter", uncommonWeight),
                ("specific aquatic encounter", uncommonWeight),
                ("underground encounter", uncommonWeight),
                ("underground aquatic encounter", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, weightedEncounters);
        }

        [Test]
        public void SelectAllWeightedFrom_AddUndergroundToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(extraplanarEncounters[1]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(anyEncounters[1]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(landEncounters[1]);
            nightEncounters.Add(civilizedEncounters[0]);
            nightEncounters.Add(specificCivilizedEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific civilized encounter", "amount", commonWeight),
                ("civilized encounter", "civilized amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("other underground encounter", "other amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowUnderground: true);
        }

        [Test]
        public void SelectAllWeightedFrom_AddUndergroundAndAquaticToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter/amount", "other specific civilized encounter/other amount" };
            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter/amount", "other underground aquatic encounter/other amount" };
            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[1], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[1], 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[0], 9266);
            SetupEncounterLevel(undergroundEncounters[1], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[0], 9266);
            SetupEncounterLevel(undergroundAquaticEncounters[1], 9266);
            SetupEncounterLevel(aquaticEncounters[0], 9266);
            SetupEncounterLevel(aquaticEncounters[1], 9266);
            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            SetupEncounterLevel(specificAquaticEncounters[1], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(extraplanarEncounters[0]);
            nightEncounters.Add(extraplanarEncounters[1]);
            nightEncounters.Add(anyEncounters[0]);
            nightEncounters.Add(anyEncounters[1]);
            nightEncounters.Add(landEncounters[0]);
            nightEncounters.Add(landEncounters[1]);
            nightEncounters.Add(civilizedEncounters[0]);
            nightEncounters.Add(specificCivilizedEncounters[0]);
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.Add(undergroundEncounters[1]);
            nightEncounters.Add(undergroundAquaticEncounters[0]);
            nightEncounters.Add(undergroundAquaticEncounters[1]);
            nightEncounters.Add(aquaticEncounters[0]);
            nightEncounters.Add(aquaticEncounters[1]);
            nightEncounters.Add(specificAquaticEncounters[0]);
            nightEncounters.Add(specificAquaticEncounters[1]);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);
            wildernessEncounters.Add(undergroundAquaticEncounters[0]);
            wildernessEncounters.Add(aquaticEncounters[0]);
            wildernessEncounters.Add(specificAquaticEncounters[0]);

            var expectedEncounters = new[]
            {
                ("other extraplanar encounter", "other extraplanar amount", rareWeight),
                ("specific civilized encounter", "amount", commonWeight),
                ("civilized encounter", "civilized amount", commonWeight),
                ("other any encounter", "other any amount", commonWeight),
                ("other land encounter", "other land amount", commonWeight),
                ("other aquatic encounter", "other amount", uncommonWeight),
                ("other specific aquatic encounter", "other amount", uncommonWeight),
                ("other underground encounter", "other amount", uncommonWeight),
                ("other underground aquatic encounter", "other amount", uncommonWeight),
            };

            AssertEncounterWeight(expectedEncounters, targetEnvironment: EnvironmentConstants.Civilized, allowAquatic: true, allowUnderground: true);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_AllDefaults_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom();

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        [Ignore("If nothing is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_AllDefaults_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom();

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetEnvironment_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(environment: "environment");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetEnvironment_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(environment: "environment");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetTemperature_Some()
        {
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Desert, new[] { "my desert encounter/my desert amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my forest encounter/my forest amount" });
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my hills encounter/my hills amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my desert encounter/my desert amount",
                "my forest encounter/my forest amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my hills encounter/my hills amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, new[]
            {
                "my temperature aquatic encounter/my temperature aquatic amount",
                "my wrong encounter/my wrong amount"
            });

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Civilized, new[]
            {
                "my temperature civilized encounter/my temperature civilized amount",
                "my wrong encounter/my wrong amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my temperature civilized encounter/my warm civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(temperature: "temperature");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetTemperature_None()
        {
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Desert, new[] { "my desert encounter/my desert amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my forest encounter/my forest amount" });
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my hills encounter/my hills amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my desert encounter/my desert amount",
                "my forest encounter/my forest amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my hills encounter/my hills amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, new[]
            {
                "my temperature aquatic encounter/my temperature aquatic amount",
                "my wrong encounter/my wrong amount"
            });

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Civilized, new[]
            {
                "my temperature civilized encounter/my temperature civilized amount",
                "my wrong encounter/my wrong amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my temperature civilized encounter/my warm civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(temperature: "temperature");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetTimeOfDay_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(timeOfDay: "time of day");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetTimeOfDay_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(timeOfDay: "time of day");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetLevel_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 783);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(level: 783);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetLevel_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 7);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(level: 783);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetAllowAquatic_Some(bool aquatic)
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(allowAquatic: aquatic);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        [Ignore("If only the allow aquatic is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetAllowAquatic_None(bool aquatic)
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(allowAquatic: aquatic);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetAllowUnderground_Some(bool underground)
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(allowUnderground: underground);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        [Ignore("If only the allow underground is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetAllowUnderground_None(bool underground)
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(allowUnderground: underground);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetFilter_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            SetupFilter("filter 1", "my land encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(filters: new[] { "filter 1" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        [Ignore("If only the filter is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetFilter_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            SetupFilter("filter 1", "my wrong encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(filters: new[] { "filter 1" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetFilters_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            SetupFilter("filter 1", "my land encounter");
            SetupFilter("filter 2", "my any encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        [Ignore("If only the filters are toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSetFilters_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 3);
            SetupEncounterLevel("my warm aquatic encounter/my warm aquatic amount", 6);
            SetupEncounterLevel("my temperate aquatic encounter/my temperate aquatic amount", 9);
            SetupEncounterLevel("my cold aquatic encounter/my cold aquatic amount", 6);

            var civilizedEncounters = new[] { "my civilized encounter/my civilized amount", "civilized encounter/amount", "other civilized encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter/my warm civilized amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate civilized encounter/my temperate civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold civilized encounter/my cold civilized amount"
            });

            SetupEncounterLevel("my civilized encounter/my civilized amount", 3);
            SetupEncounterLevel("my warm civilized encounter/my warm civilized amount", 6);
            SetupEncounterLevel("my temperate civilized encounter/my temperate civilized amount", 9);
            SetupEncounterLevel("my cold civilized encounter/my cold civilized amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 13);

            SetupFilter("filter 1", "my wrong encounter");
            SetupFilter("filter 2", "my other wrong encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSomeSetValues_Some()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            SetupFilter("filter 1", "my warm encounter", "my land encounter");
            SetupFilter("filter 2", "my any encounter", "my extraplanar encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(
                environment: "environment",
                timeOfDay: "time of day",
                allowAquatic: false,
                filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromSomeSetValues_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter/my amount", "my temperate encounter/my temperate amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my warm encounter/my warm amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my warm encounter/my warm amount", 666);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter/my underground amount", 7);

            SetupFilter("filter 1", "my warm encounter", "my wrong encounter");
            SetupFilter("filter 2", "my any encounter", "my other wrong encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom(
                environment: "environment",
                timeOfDay: "time of day",
                allowAquatic: false,
                filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromAllSetValues_Some()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my encounter/my amount", 783);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            SetupFilter("filter 1", "my encounter", "my other encounter");
            SetupFilter("filter 2", "my other land encounter", "my other any encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom("environment", "temperature", "time of day", 783, false, false, "filter 1", "filter 2");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleFrom_ReturnsPossibleEncounters_FromAllSetValues_None()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my temperate encounter/my temperate amount",
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount",
                "my extraplanar encounter/my extraplanar amount",
                "my warm aquatic encounter/my warm aquatic amount",
                "my cold aquatic encounter/my cold aquatic amount",
                "my warm civilized encounter/my warm civilized amount",
                "my cold civilized encounter/my cold civilized amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my cold encounter/my cold amount",
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount",
                "my aquatic encounter/my aquatic amount",
                "my temperate aquatic encounter/my temperate aquatic amount",
                "my civilized encounter/my civilized amount",
                "my temperate civilized encounter/my temperate civilized amount",
                "my underground encounter/my underground amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my temperate encounter/my temperate amount", 26);
            SetupEncounterLevel("my cold encounter/my cold amount", 6);
            SetupEncounterLevel("my other encounter/my other amount", 9);

            landEncounters.Add("my land encounter/my land amount");
            anyEncounters.Add("my any encounter/my any amount");
            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my land encounter/my land amount", 2);
            SetupEncounterLevel("my any encounter/my any amount", 10);
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 4);

            SetupFilter("filter 1", "my wrong encounter", "my other encounter");
            SetupFilter("filter 2", "my other wrong encounter", "my other aquatic encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleFrom("environment", "temperature", "time of day", 783, false, false, "filter 1", "filter 2");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[] { EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Temperatures.Cold }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_FromLand()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter/my amount",
                "my temperate encounter/my temperate amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount",
                "my land encounter/my land amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            landEncounters.Add("my land encounter/my land amount");
            SetupEncounterLevel("my land encounter/my land amount", 6);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[]
            {
                EnvironmentConstants.Temperatures.Warm,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Cold
            }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_FromAny()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter/my amount",
                "my temperate encounter/my temperate amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount",
                "my any encounter/my any amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            anyEncounters.Add("my any encounter/my any amount");
            SetupEncounterLevel("my any encounter/my any amount", 6);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[]
            {
                EnvironmentConstants.Temperatures.Warm,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Cold
            }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_FromExtraplanar()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter/my amount",
                "my temperate encounter/my temperate amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount",
                "my extraplanar encounter/my extraplanar amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 6);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[]
            {
                EnvironmentConstants.Temperatures.Warm,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Cold
            }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_FromCivilized()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm encounter/my warm amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my temperate encounter/my temperate amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter/my amount",
                "my cold encounter/my cold amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount",
                "my civilized encounter/my civilized amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            civilizedEncounters.Add("my civilized encounter/my civilized amount");
            SetupEncounterLevel("my civilized encounter/my civilized amount", 6);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures(EnvironmentConstants.Civilized);
            Assert.That(possibleTemps, Is.EquivalentTo(new[]
            {
                EnvironmentConstants.Temperatures.Warm,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Cold
            }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_FromAquatic()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter/my amount",
                "my temperate encounter/my temperate amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount",
                "my aquatic encounter/my aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 6);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter/my warm aquatic amount",
                "my wrong encounter/my wrong amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my temperate aquatic encounter/my temperate aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter/my amount",
                "my cold aquatic encounter/my cold aquatic amount"
            });

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[]
            {
                EnvironmentConstants.Temperatures.Warm,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Cold
            }));
        }

        [TestCase(EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Temperatures.Cold)]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_FromSpecificAquatic(string temp)
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter/my amount",
                "my temperate encounter/my temperate amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount",
                "my specific aquatic encounter/my specific aquatic amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my specific aquatic encounter/my specific aquatic amount", 6);

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[]
            {
                "specific aquatic encounter/amount",
                "my specific aquatic encounter/my specific aquatic amount",
                "other specific aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup(temp + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[] { temp }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_FromUnderground()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter/my amount",
                "my temperate encounter/my temperate amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount",
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my underground encounter/my underground amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my underground encounter/my underground amount", 6);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my underground encounter/my underground amount"
            });

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[]
            {
                EnvironmentConstants.Temperatures.Warm,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Cold
            }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_FromUndergroundAquatic()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter/my amount",
                "my temperate encounter/my temperate amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount",
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my underground aquatic encounter/my underground aquatic amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 6);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[]
            {
                EnvironmentConstants.Temperatures.Warm,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Cold
            }));
        }

        [TestCase(EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Temperatures.Cold)]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_ForTemperature(string temperature)
        {
            SetUpCreatureBasedEncounterGroup(temperature + "environment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount",
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
            });

            SetupEncounterLevel("my encounter/my amount", 9);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[] { temperature }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_None()
        {
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter/my warm amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter/my amount",
                "my temperate encounter/my temperate amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter/my amount", "my cold encounter/my cold amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
{
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount",
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
            });

            SetupEncounterLevel("my encounter/my amount", 9);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.Empty);
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter/my night amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount" });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.TimesOfDay.Night }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromLand()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter/my wrong amount",
                "my land encounter/my land amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            landEncounters.Add("my land encounter/my land amount");
            SetupEncounterLevel("my land encounter/my land amount", 6);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromAny()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter/my wrong amount",
                "my any encounter/my any amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            anyEncounters.Add("my any encounter/my any amount");
            SetupEncounterLevel("my any encounter/my any amount", 6);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromExtraplanar()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter/my wrong amount",
                "my extraplanar encounter/my extraplanar amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 6);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromCivilized()
        {
            SetUpCreatureBasedEncounterGroup("temperatureCivilized", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter/my wrong amount",
                "my civilized encounter/my civilized amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            civilizedEncounters.Add("my civilized encounter/my civilized amount");
            SetupEncounterLevel("my civilized encounter/my civilized amount", 6);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay(EnvironmentConstants.Civilized, "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter/my wrong amount",
                "my aquatic encounter/my aquatic amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 6);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromSpecificAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter/my wrong amount",
                "my specific aquatic encounter/my specific aquatic amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my specific aquatic encounter/my specific aquatic amount", 6);

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[]
            {
                "specific aquatic encounter/amount",
                "my specific aquatic encounter/my specific aquatic amount",
                "other specific aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        //INFO: Because you can have a Day encounter allowing underground (which would be Night), if Night has a valid encounter, it will show Day as an option
        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromUnderground()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my wrong encounter/my wrong amount",
                "my underground encounter/my underground amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my underground encounter/my underground amount", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.TimesOfDay.Night }));
        }

        //INFO: Because you can have a Day encounter allowing underground (which would be Night), if Night has a valid encounter, it will show Day as an option
        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromUndergroundAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my wrong encounter/my wrong amount",
                "my underground aquatic encounter/my underground aquatic amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 6);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.TimesOfDay.Night }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_ForDay()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        //INFO: Because you can have a Day encounter allowing underground (which would be Night), if Night has a valid encounter, it will show Day as an option
        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_ForNight()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.TimesOfDay.Night }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_None()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter/my wrong amount",
                "my day encounter/my day amount"
            });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my wrong encounter/my wrong amount",
                "my night encounter/my night amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.Empty);
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount", "my other encounter/my other amount" });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromLand()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my land encounter/my land amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            landEncounters.Add("my land encounter/my land amount");
            SetupEncounterLevel("my land encounter/my land amount", 6);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromAny()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my any encounter/my any amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            anyEncounters.Add("my any encounter/my any amount");
            SetupEncounterLevel("my any encounter/my any amount", 6);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromExtraplanar()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my extraplanar encounter/my extraplanar amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            extraplanarEncounters.Add("my extraplanar encounter/my extraplanar amount");
            SetupEncounterLevel("my extraplanar encounter/my extraplanar amount", 6);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromCivilized()
        {
            SetUpCreatureBasedEncounterGroup("temperatureCivilized", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my civilized encounter/my civilized amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);

            civilizedEncounters.Add("my civilized encounter/my civilized amount");
            SetupEncounterLevel("my civilized encounter/my civilized amount", 6);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels(EnvironmentConstants.Civilized, "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my aquatic encounter/my aquatic amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my aquatic encounter/my aquatic amount", 6);

            var aquaticEncounters = new[] { "my aquatic encounter/my aquatic amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromSpecificAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my specific aquatic encounter/my specific aquatic amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my specific aquatic encounter/my specific aquatic amount", 6);

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[]
            {
                "specific aquatic encounter/amount",
                "my specific aquatic encounter/my specific aquatic amount",
                "other specific aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromUnderground()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my underground encounter/my underground amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my underground encounter/my underground amount", 6);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my underground encounter/my underground amount"
            });

            var undergroundEncounters = new[]
            {
                "underground encounter/amount",
                "my underground encounter/my underground amount",
                "other underground encounter/other amount"
            };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromUndergroundAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my underground aquatic encounter/my underground aquatic amount"
            });

            SetupEncounterLevel("my encounter/my amount", 9);
            SetupEncounterLevel("my other encounter/my other amount", 26);
            SetupEncounterLevel("my underground aquatic encounter/my underground aquatic amount", 6);

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my encounter/my amount",
                "my wrong encounter/my wrong amount",
                "my other encounter/my other amount",
                "my underground aquatic encounter/my underground aquatic amount"
            });

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my underground aquatic encounter/my underground aquatic amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [TestCase(EncounterSpecifications.MinimumLevel)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        [TestCase(20)]
        [TestCase(21)]
        [TestCase(22)]
        [TestCase(23)]
        [TestCase(24)]
        [TestCase(25)]
        [TestCase(26)]
        [TestCase(27)]
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(EncounterSpecifications.MaximumLevel)]
        public void SelectPossibleLevels_ReturnsValidLevels_ForLevel(int level)
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount", "my other encounter/my other amount" });

            SetupEncounterLevel("my encounter/my amount", level);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { level }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_None()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", EncounterSpecifications.MaximumLevel + 1);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.Empty);
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromLand()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            landEncounters.Add("my encounter/my amount");

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromAny()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            anyEncounters.Add("my encounter/my amount");

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromExtraplanar()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            extraplanarEncounters.Add("my encounter/my amount");

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromCivilized()
        {
            SetUpCreatureBasedEncounterGroup("temperatureCivilized", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            civilizedEncounters.Add("my encounter/my amount");

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic(EnvironmentConstants.Civilized, "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var aquaticEncounters = new[] { "my encounter/my amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromSpecificAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "my encounter/my amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromUnderground()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var undergroundEncounters = new[] { "underground encounter/amount", "my encounter/my amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromUndergroundAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my encounter/my amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_None()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.Empty);
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromLand()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            landEncounters.Add("my encounter/my amount");

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromAny()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            anyEncounters.Add("my encounter/my amount");

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromExtraplanar()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            extraplanarEncounters.Add("my encounter/my amount");

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromCivilized()
        {
            SetUpCreatureBasedEncounterGroup("temperatureCivilized", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            civilizedEncounters.Add("my encounter/my amount");

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground(
                EnvironmentConstants.Civilized,
                "temperature",
                "time of day",
                9266,
                false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var aquaticEncounters = new[] { "my encounter/my amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, true);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromSpecificAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "my encounter/my amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, true);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromUnderground()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var undergroundEncounters = new[] { "underground encounter/amount", "my encounter/my amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromUndergroundAquatic()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my encounter/my amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, true);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_None()
        {
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var undergroundEncounters = new[] { "underground encounter/amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.Empty);
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        private void SetupAllFilters()
        {
            SetupFilter(CreatureDataConstants.Types.Aberration);
            SetupFilter(CreatureDataConstants.Types.Animal);
            SetupFilter(CreatureDataConstants.Types.Construct);
            SetupFilter(CreatureDataConstants.Types.Dragon);
            SetupFilter(CreatureDataConstants.Types.Elemental);
            SetupFilter(CreatureDataConstants.Types.Fey);
            SetupFilter(CreatureDataConstants.Types.Giant);
            SetupFilter(CreatureDataConstants.Types.Humanoid);
            SetupFilter(CreatureDataConstants.Types.MagicalBeast);
            SetupFilter(CreatureDataConstants.Types.MonstrousHumanoid);
            SetupFilter(CreatureDataConstants.Types.Ooze);
            SetupFilter(CreatureDataConstants.Types.Outsider);
            SetupFilter(CreatureDataConstants.Types.Plant);
            SetupFilter(CreatureDataConstants.Types.Undead);
            SetupFilter(CreatureDataConstants.Types.Vermin);
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromLand()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            landEncounters.Add("my encounter/my amount");

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromAny()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            anyEncounters.Add("my encounter/my amount");

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromExtraplanar()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            extraplanarEncounters.Add("my encounter/my amount");

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromCivilized()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureCivilized", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            civilizedEncounters.Add("my encounter/my amount");

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters(EnvironmentConstants.Civilized, "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromAquatic()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var aquaticEncounters = new[] { "my encounter/my amount", "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, true, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromSpecificAquatic()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var aquaticEncounters = new[] { "aquatic encounter/amount", "other aquatic encounter/other amount" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter/amount", "my encounter/my amount", "other specific aquatic encounter/other amount" };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpCreatureBasedEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, true, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromUnderground()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var undergroundEncounters = new[] { "underground encounter/amount", "my encounter/my amount", "other underground encounter/other amount" };
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, true);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromUndergroundAquatic()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter/amount",
                "my encounter/my amount",
                "other underground aquatic encounter/other amount"
            };

            SetUpCreatureBasedEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel("my encounter/my amount", 9266);

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, true, true);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [TestCase(CreatureDataConstants.Types.Aberration)]
        [TestCase(CreatureDataConstants.Types.Animal)]
        [TestCase(CreatureDataConstants.Types.Construct)]
        [TestCase(CreatureDataConstants.Types.Dragon)]
        [TestCase(CreatureDataConstants.Types.Elemental)]
        [TestCase(CreatureDataConstants.Types.Fey)]
        [TestCase(CreatureDataConstants.Types.Giant)]
        [TestCase(CreatureDataConstants.Types.Humanoid)]
        [TestCase(CreatureDataConstants.Types.MagicalBeast)]
        [TestCase(CreatureDataConstants.Types.MonstrousHumanoid)]
        [TestCase(CreatureDataConstants.Types.Ooze)]
        [TestCase(CreatureDataConstants.Types.Outsider)]
        [TestCase(CreatureDataConstants.Types.Plant)]
        [TestCase(CreatureDataConstants.Types.Undead)]
        [TestCase(CreatureDataConstants.Types.Vermin)]
        public void SelectPossibleFilters_ReturnsValidFilters_ForFilter(string filter)
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);

            filters[filter].Add("my encounter");
            filters[filter].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { filter }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_SomeFilters()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount", "my other encounter/my other amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);
            SetupEncounterLevel("my other encounter/my other amount", 9266);

            filters[CreatureDataConstants.Types.Animal].Add("my encounter");
            filters[CreatureDataConstants.Types.Animal].Add("my wrong encounter");
            filters[CreatureDataConstants.Types.Construct].Add("my other encounter");
            filters[CreatureDataConstants.Types.Construct].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Animal, CreatureDataConstants.Types.Construct }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_NoFilters()
        {
            SetupAllFilters();
            SetUpCreatureBasedEncounterGroup("temperatureenvironment", new[] { "my encounter/my amount", "my other encounter/my other amount" });
            SetUpCreatureBasedEncounterGroup("time of day", new[] { "my encounter/my amount", "my wrong encounter/my wrong amount" });

            SetupEncounterLevel("my encounter/my amount", 9266);

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.Empty);
        }
    }
}
