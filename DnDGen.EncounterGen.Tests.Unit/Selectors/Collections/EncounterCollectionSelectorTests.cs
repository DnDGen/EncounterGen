using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
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

        private IEncounterCollectionSelector encounterCollectionSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
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
        private List<string> characterEncounters;
        private EncounterSpecifications specifications;
        private Dictionary<string, IEnumerable<string>> encounterGroups;
        private Dictionary<string, IEnumerable<string>> encounterLevels;
        private Dictionary<char, IEnumerable<string>> weightedEncounters;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            encounterCollectionSelector = new EncounterCollectionSelector(mockCollectionSelector.Object);

            levelEncounters = [];
            timeOfDayEncounters = [];
            extraplanarEncounters = ["extraplanar encounter", "other extraplanar encounter"];
            anyEncounters = ["any encounter", "other any encounter"];
            civilizedEncounters = ["civilized encounter", "other civilized encounter"];
            undeadEncounters = ["undead encounter", "other undead encounter"];
            specificEnvironmentEncounters =
            [
                "specific environment encounter",
                "other specific environment encounter"
            ];
            landEncounters = ["land encounter", "other land encounter"];
            filters = [];
            wildernessEncounters = [];
            characterEncounters = [];
            specifications = new EncounterSpecifications();
            encounterGroups = [];
            encounterLevels = [];
            weightedEncounters = [];

            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);
            SetupEncounterLevel("level encounter", 9266);

            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);
            timeOfDayEncounters.Add("time of day encounter");

            SetupEncounterFilter("filter");
            SetupEncounterFilter("other filter");

            specifications.Environment = environment;
            specifications.Level = 9266;
            specifications.Temperature = temperature;
            specifications.TimeOfDay = timeOfDay;

            SetUpEncounterGroup(timeOfDay, timeOfDayEncounters);
            SetUpEncounterGroup(GroupConstants.Extraplanar, extraplanarEncounters);
            SetUpEncounterGroup(string.Empty, []);
            SetUpEncounterGroup(specifications.SpecificEnvironment, specificEnvironmentEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Land, landEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Any, anyEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(CreatureDataConstants.Types.Undead, undeadEncounters);
            SetUpEncounterGroup(GroupConstants.Wilderness, wildernessEncounters);
            SetUpEncounterGroup(GroupConstants.Character, characterEncounters);

            mockCollectionSelector.Setup(s => s.SelectAllFrom(Config.Name, TableNameConstants.EncounterGroups)).Returns(encounterGroups);
            mockCollectionSelector
                .Setup(s => s.SelectFrom(Config.Name, TableNameConstants.EncounterGroups, It.IsAny<string>()))
                .Returns((string a, string t, string n) => encounterGroups.ContainsKey(n) ? encounterGroups[n] : []);
            mockCollectionSelector
                .Setup(s => s.SelectFrom(Config.Name, TableNameConstants.EncounterGroups, GroupConstants.All))
                .Returns(() => encounterGroups.Values.SelectMany(e => e).Distinct());
            mockCollectionSelector
                .Setup(s => s.SelectFrom(Config.Name, TableNameConstants.AverageEncounterLevels, It.IsAny<string>()))
                .Returns((string a, string t, string l) => GetEncounterLevel(l));
            mockCollectionSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>(), null))
                .Callback((IEnumerable<string> c, IEnumerable<string> u, IEnumerable<string> r, IEnumerable<string> v) =>
                {
                    weightedEncounters['c'] = c;
                    weightedEncounters['u'] = u;
                    weightedEncounters['r'] = r;
                })
                .Returns((IEnumerable<string> c, IEnumerable<string> u, IEnumerable<string> r, IEnumerable<string> v) => c.Union(u).Union(r).Last());
            //mockCollectionSelector
            //    .Setup(s => s.CreateWeighted(
            //        It.IsAny<IEnumerable<string>>(),
            //        It.IsAny<IEnumerable<string>>(),
            //        It.IsAny<IEnumerable<string>>(),
            //        It.IsAny<IEnumerable<string>>()))
            //    .Returns(CreateWeighted);
        }

        private IEnumerable<string> GetEncounterLevel(string level)
        {
            if (!encounterLevels.ContainsKey(level))
                return [];

            return encounterLevels[level].Where(levelEncounters.Contains);
        }

        private void SetupEncounterFilter(string filter, params string[] filterValues)
        {
            filters[filter] = new List<string>(filterValues);
            SetUpEncounterGroup(filter, filters[filter]);
        }

        //private IEnumerable<string> CreateWeighted(IEnumerable<string> common, IEnumerable<string> uncommon, IEnumerable<string> rare, IEnumerable<string> veryRare)
        //{
        //    var weighted = Enumerable.Empty<string>();

        //    if (common?.Any() == true)
        //        weighted = weighted.Concat(Enumerable.Repeat(common, commonWeight).SelectMany(e => e));

        //    if (uncommon?.Any() == true)
        //        weighted = weighted.Concat(Enumerable.Repeat(uncommon, uncommonWeight).SelectMany(e => e));

        //    if (rare?.Any() == true)
        //        weighted = weighted.Concat(Enumerable.Repeat(rare, rareWeight).SelectMany(e => e));

        //    if (veryRare?.Any() == true)
        //        weighted = weighted.Concat(Enumerable.Repeat(veryRare, veryRareWeight).SelectMany(e => e));

        //    return weighted;
        //}

        private void SetupEncounterLevel(string encounter, int level)
        {
            levelEncounters.Add(encounter);

            if (!encounterLevels.ContainsKey(level.ToString()))
                encounterLevels[level.ToString()] = [];

            encounterLevels[level.ToString()] = encounterLevels[level.ToString()].Concat([encounter]);
        }

        private void SetUpEncounterGroup(string name, IEnumerable<string> encounters)
        {
            encounterGroups[name] = encounters;
        }

        private void AssertEncounterWeight(IEnumerable<string> common, IEnumerable<string> uncommon, IEnumerable<string> rare)
        {
            Assert.That(weightedEncounters, Has.Count.EqualTo(3)
                .And.ContainKey('c')
                .And.ContainKey('u')
                .And.ContainKey('r'));
            Assert.That(weightedEncounters['c'], Is.EquivalentTo(common));
            Assert.That(weightedEncounters['u'], Is.EquivalentTo(uncommon));
            Assert.That(weightedEncounters['r'], Is.EquivalentTo(rare));

            mockCollectionSelector.Verify(
                s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>(), null),
                Times.Once);
        }

        [Test]
        public void SelectRandomEncounterFrom_SelectingRandomGetsEncounterFromSelector()
        {
            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);
            Assert.That(encounter, Is.EqualTo("specific environment encounter"));
        }

        [Test]
        public void SelectRandomEncounterFrom_GetRandomEncounterFromSelector()
        {
            mockCollectionSelector
                .Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>(), null))
                .Returns("my random encounter");

            specificEnvironmentEncounters.Add("wrong encounter/wrong amount");
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[2], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[2]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);
            Assert.That(encounter, Is.EqualTo("my random encounter"));
        }

        [Test]
        public void SelectRandomEncounterFrom_ThrowsException_WhenNoneMatchLevel()
        {
            levelEncounters.Clear();

            Assert.That(() => encounterCollectionSelector.SelectRandomEncounterFrom(specifications),
                Throws.ArgumentException.With.Message.EqualTo($"No valid encounters exist for {specifications.Description}"));
        }

        [Test]
        public void SelectRandomEncounterFrom_ThrowsException_WhenNoneMatchFilter()
        {
            specifications.CreatureTypeFilters = ["filter"];

            Assert.That(() => encounterCollectionSelector.SelectRandomEncounterFrom(specifications),
                Throws.ArgumentException.With.Message.EqualTo($"No valid encounters exist for {specifications.Description}"));
        }

        [Test]
        public void SelectRandomEncounterFrom_ThrowsException_WhenCivilizedAndAllAreWilderness()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);
            wildernessEncounters.AddRange(levelEncounters);

            specifications.Environment = EnvironmentConstants.Civilized;

            Assert.That(() => encounterCollectionSelector.SelectRandomEncounterFrom(specifications),
                Throws.ArgumentException.With.Message.EqualTo($"No valid encounters exist for {specifications.Description}"));
        }

        [Test]
        public void SelectRandomEncounterFrom_ThrowsException_WhenNoneMatchTimeOfDay()
        {
            timeOfDayEncounters.Clear();

            Assert.That(() => encounterCollectionSelector.SelectRandomEncounterFrom(specifications),
                Throws.ArgumentException.With.Message.EqualTo($"No valid encounters exist for {specifications.Description}"));
        }

        [Test]
        public void SelectRandomEncounterFrom_FilterOutEncountersThatDoNotMatchLevel()
        {
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("specific environment encounter"));
            AssertEncounterWeight(["specific environment encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_FilterOutEncountersThatDoNotMatchTimeOfDay()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("specific environment encounter"));
            AssertEncounterWeight(["specific environment encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_FilterOutEncountersThatDoNotMatchFilter()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            filters["filter"].Add("specific environment encounter");
            filters["other filter"].Add("extraplanar encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("specific environment encounter"));
            AssertEncounterWeight(["specific environment encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_DoNotFilterOutEncountersThatMatchFilter()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            filters["filter"].Add("specific environment encounter");
            filters["filter"].Add("extraplanar encounter");

            specifications.CreatureTypeFilters = new[] { "filter" };

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(["specific environment encounter"], [], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightExtraplanarEncounters()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(["specific environment encounter"], [], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllExtraplanarEncounters()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(extraplanarEncounters[1], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(extraplanarEncounters[1]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other extraplanar encounter"));
            AssertEncounterWeight(["specific environment encounter"], [], ["extraplanar encounter", "other extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightCharacterEncounters_WhenNotCivilized()
        {
            characterEncounters.Add("character encounter");
            landEncounters.Add("character encounter");

            SetupEncounterLevel("character encounter", 9266);
            timeOfDayEncounters.Add("character encounter");

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter"], ["character encounter"], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllCharacterEncounters_WhenNotCivilized()
        {
            characterEncounters.Add("character encounter");
            characterEncounters.Add("other character encounter");
            landEncounters.Add("character encounter");
            landEncounters.Add("other character encounter");

            SetupEncounterLevel("character encounter", 9266);
            SetupEncounterLevel("other character encounter", 9266);
            timeOfDayEncounters.Add("character encounter");
            timeOfDayEncounters.Add("other character encounter");

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter"], ["character encounter", "other character encounter"], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightCharacterEncounters_WhenCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            characterEncounters.Add("character encounter");
            landEncounters.Add("character encounter");

            SetupEncounterLevel("character encounter", 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);
            timeOfDayEncounters.Add("character encounter");
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            specifications.Environment = EnvironmentConstants.Civilized;

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter", "character encounter", "other character encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllCharacterEncounters_WhenCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);

            characterEncounters.Add("character encounter");
            characterEncounters.Add("other character encounter");
            landEncounters.Add("character encounter");
            landEncounters.Add("other character encounter");

            SetupEncounterLevel("character encounter", 9266);
            SetupEncounterLevel("other character encounter", 9266);
            SetupEncounterLevel(civilizedEncounters[0], 9266);
            SetupEncounterLevel(specificCivilizedEncounters[0], 9266);
            timeOfDayEncounters.Add("character encounter");
            timeOfDayEncounters.Add("other character encounter");
            timeOfDayEncounters.Add(civilizedEncounters[0]);
            timeOfDayEncounters.Add(specificCivilizedEncounters[0]);

            specifications.Environment = EnvironmentConstants.Civilized;

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter", "character encounter", "other character encounter", "civilized encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAdditionalAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(aquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(aquaticEncounters[0]);

            specifications.AllowAquatic = true;

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter"], ["aquatic encounter"], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_DoNotWeightCommonEncountersIfNone()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            timeOfDayEncounters.Add(extraplanarEncounters[0]);

            specificEnvironmentEncounters.Clear();

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight([], [], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_DoNotWeightSpecificEncountersIfNone()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(["land encounter", "any encounter"], ["underground aquatic encounter"], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_DoNotWeightUndergroundAquaticEncountersIfNone()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(["specific environment encounter", "land encounter", "any encounter"], [], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAdditionalUndergroundEncounters()
        {
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel(undergroundEncounters[0], 9266);

            var nightEncounters = new List<string>();
            nightEncounters.Add(undergroundEncounters[0]);
            nightEncounters.AddRange(timeOfDayEncounters);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowUnderground = true;

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter"], ["underground encounter"], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightLandEncounters()
        {
            SetupEncounterLevel(landEncounters[0], 9266);
            timeOfDayEncounters.Add(landEncounters[0]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter", "land encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllLandEncounters()
        {
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(landEncounters[0], 9266);
            timeOfDayEncounters.Add(landEncounters[0]);
            SetupEncounterLevel(landEncounters[1], 9266);
            timeOfDayEncounters.Add(landEncounters[1]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter", "other specific environment encounter", "land encounter", "other land encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAnyEncounters()
        {
            SetupEncounterLevel(anyEncounters[0], 9266);
            timeOfDayEncounters.Add(anyEncounters[0]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter", "any encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllAnyEncounters()
        {
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);
            SetupEncounterLevel(anyEncounters[0], 9266);
            timeOfDayEncounters.Add(anyEncounters[0]);
            SetupEncounterLevel(anyEncounters[1], 9266);
            timeOfDayEncounters.Add(anyEncounters[1]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter", "other specific environment encounter", "any encounter", "other any encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightNativeAquaticEncounters()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific aquatic encounter", "aquatic encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllNativeAquaticEncounters()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific aquatic encounter", "other specific aquatic encounter", "aquatic encounter", "other aquatic encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightNativeUndergroundEncounters()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific underground encounter", "underground encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllNativeUndergroundEncounters()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific underground encounter", "other specific underground encounter", "underground encounter", "other underground encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAdditionalSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            specifications.AllowAquatic = true;

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter"], ["specific aquatic encounter"], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllAdditionalSpecificAquaticEncounters()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(
                ["specific environment encounter", "other specific environment encounter"],
                ["specific aquatic encounter", "other specific aquatic encounter"],
                []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAdditionalUndergroundAquaticEncounters()
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

            var nightEncounters = new List<string>
            {
                specificEnvironmentEncounters[0],
                undergroundAquaticEncounters[0]
            };

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.AllowAquatic = true;
            specifications.AllowUnderground = true;

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter"], ["underground aquatic encounter"], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllAdditionalUndergroundAquaticEncounters()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(
                ["specific environment encounter", "other specific environment encounter"],
                ["underground aquatic encounter", "other underground aquatic encounter"],
                []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightSpecificEncounters()
        {
            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllSpecificEncounters()
        {
            SetupEncounterLevel(specificEnvironmentEncounters[1], 9266);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[1]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific environment encounter", "other specific environment encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightNativeSpecificAquaticEncounters()
        {
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temperature + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel(specificAquaticEncounters[0], 9266);
            timeOfDayEncounters.Add(specificAquaticEncounters[0]);

            specifications.Environment = EnvironmentConstants.Aquatic;

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific aquatic encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_WeightAllNativeSpecificAquaticEncounters()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific aquatic encounter", "other specific aquatic encounter"], [], []);
        }

        [TestCase(EnvironmentConstants.Aquatic, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, true, true)]
        [TestCase(EnvironmentConstants.Underground, true, false)]
        [TestCase(EnvironmentConstants.Underground, true, true)]
        public void SelectRandomEncounterFrom_WeightNativeUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground)
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

            var nightEncounters = new List<string>
            {
                undergroundAquaticEncounters[0]
            };

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            specifications.Environment = environment;
            specifications.AllowAquatic = allowAquatic;
            specifications.AllowUnderground = allowUnderground;

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("underground aquatic encounter"));
            AssertEncounterWeight([], ["underground aquatic encounter"], []);
        }

        [TestCase(EnvironmentConstants.Aquatic, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, true, true)]
        [TestCase(EnvironmentConstants.Underground, true, false)]
        [TestCase(EnvironmentConstants.Underground, true, true)]
        public void SelectRandomEncounterFrom_WeightAllNativeUndergroundAquaticEncounters(string environment, bool allowAquatic, bool allowUnderground)
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other underground aquatic encounter"));
            AssertEncounterWeight([], ["underground aquatic encounter", "other underground aquatic encounter"], []);
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
        public void SelectRandomEncounterFrom_ShouldAddUndergroundAquaticEncounters(
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.Not.Empty);
            Assert.That(weightedEncounters, Is.Not.Empty);
            Assert.That(weightedEncounters.Values.Any(e => e.Contains("underground aquatic encounter")), Is.EqualTo(hasUndergroundAquatic));
        }

        [Test]
        public void SelectRandomEncounterFrom_IfCivilized_DoNotGetWildlife()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific civilized encounter", "civilized encounter", "other land encounter", "other any encounter"], [], ["other extraplanar encounter"]);
        }

        [Test]
        public void BUG_SelectRandomEncounterFrom_IfCivilized_UndeadFromAnyAreRare()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("undead encounter"));
            AssertEncounterWeight(
                ["specific civilized encounter", "civilized encounter", "other land encounter", "other any encounter"],
                [],
                ["other extraplanar encounter", "undead encounter"]);
        }

        [Test]
        public void BUG_SelectRandomEncounterFrom_IfNotCivilized_UndeadFromAnyAreCommon()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other extraplanar encounter"));
            AssertEncounterWeight(
                ["specific environment encounter", "undead encounter", "land encounter", "other land encounter", "any encounter", "other any encounter"],
                [],
                ["extraplanar encounter", "other extraplanar encounter"]);

        }

        [Test]
        public void BUG_SelectRandomEncounterFrom_IfCivilized_UndeadFromLandAreRare()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("undead encounter"));
            AssertEncounterWeight(
                ["specific civilized encounter", "civilized encounter", "other land encounter", "other any encounter"],
                [],
                ["other extraplanar encounter", "undead encounter"]);
        }

        [Test]
        public void BUG_SelectRandomEncounterFrom_IfNotCivilized_UndeadFromLandAreCommon()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other extraplanar encounter"));
            AssertEncounterWeight(
                ["specific environment encounter", "undead encounter", "land encounter", "other land encounter", "any encounter", "other any encounter"],
                [],
                ["extraplanar encounter", "other extraplanar encounter"]);
        }

        [Test]
        public void BUG_SelectRandomEncounterFrom_IfCivilized_UndergroundUndeadAreRare()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("undead encounter"));
            AssertEncounterWeight(
                ["specific civilized encounter", "civilized encounter", "other land encounter", "other any encounter"],
                ["other underground encounter"],
                ["other extraplanar encounter", "undead encounter"]);
        }

        [Test]
        public void BUG_SelectRandomEncounterFrom_IfNotCivilized_UndergroundUndeadFromAnyAreCommon()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other extraplanar encounter"));
            AssertEncounterWeight(
                ["specific environment encounter", "undead encounter", "land encounter", "other land encounter", "any encounter", "other any encounter"],
                ["other underground encounter", "underground encounter"],
                ["extraplanar encounter", "other extraplanar encounter"]);
        }

        [Test]
        public void BUG_SelectRandomEncounterFrom_IfNotCivilized_UndergroundUndeadFromLandAreCommon()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other extraplanar encounter"));
            AssertEncounterWeight(
                ["specific environment encounter", "undead encounter", "land encounter", "other land encounter", "any encounter", "other any encounter"],
                ["other underground encounter", "underground encounter"],
                ["extraplanar encounter", "other extraplanar encounter"]);
        }

        [Test]
        public void BUG_SelectRandomEncounterFrom_IfNotCivilized_UndergroundUndeadAreUncommon()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other extraplanar encounter"));
            AssertEncounterWeight(
                ["specific environment encounter", "land encounter", "other land encounter", "any encounter", "other any encounter"],
                ["undead encounter", "other underground encounter", "underground encounter"],
                ["extraplanar encounter", "other extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_IfUndergroundEnvironment_SetTimeOfDayToNight()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("character encounter"));
            AssertEncounterWeight(["specific underground encounter", "land encounter", "any encounter", "underground encounter"], [], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_IfAllowingUnderground_SetTimeOfDayToNight()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(["specific environment encounter", "land encounter", "any encounter"], ["underground encounter"], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_GetAllPossibleWeightedEncounters_WithoutAquaticOrUnderground()
        {
            SetupEncounterLevel(extraplanarEncounters[0], 9266);
            SetupEncounterLevel(landEncounters[0], 9266);
            SetupEncounterLevel(anyEncounters[0], 9266);
            SetupEncounterLevel(specificEnvironmentEncounters[0], 9266);

            timeOfDayEncounters.Add(extraplanarEncounters[0]);
            timeOfDayEncounters.Add(landEncounters[0]);
            timeOfDayEncounters.Add(anyEncounters[0]);
            timeOfDayEncounters.Add(specificEnvironmentEncounters[0]);

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(["specific environment encounter", "land encounter", "any encounter"], [], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_GetAllPossibleWeightedCivilizedEncounters()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other extraplanar encounter"));
            AssertEncounterWeight(["specific civilized encounter", "civilized encounter", "other land encounter", "other any encounter"], [], ["other extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_SelectAllWeightedReturnsNoEncounters()
        {
            levelEncounters.Clear();
            var allEncounters = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);
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
        public void SelectRandomEncounterFrom_ApplyFiltersToAllWeightedEncounters()
        {
            specificEnvironmentEncounters.Add("wrong encounter");
            SetupEncounterLevel("wrong encounter", 9266);
            timeOfDayEncounters.Add("wrong encounter");

            filters["filter"].Add("specific environment encounter");

            specifications.CreatureTypeFilters = ["filter"];

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);
            Assert.That(encounter, Is.EqualTo("specific environment encounter"));
            AssertEncounterWeight(["specific environment encounter"], [], []);
        }

        [Test]
        public void SelectRandomEncounterFrom_AquaticEnvironmentDoesNotHaveNonAquaticEncounters()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(["specific aquatic encounter", "aquatic encounter", "any encounter"], [], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_CanAddAquaticToAnEnvironment()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(
                ["specific environment encounter", "any encounter", "land encounter"],
                ["aquatic encounter", "specific aquatic encounter"],
                ["extraplanar encounter"]);

        }

        [Test]
        public void SelectRandomEncounterFrom_AddingAquaticToAquatic()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(["specific aquatic encounter", "aquatic encounter", "any encounter"], [], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_AddAquaticToUnderground()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(
                ["specific underground encounter", "any encounter", "land encounter", "underground encounter"],
                ["aquatic encounter", "specific aquatic encounter", "underground aquatic encounter"],
                ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_AddAquaticToCivilized()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other extraplanar encounter"));
            AssertEncounterWeight(
                ["civilized encounter", "other any encounter", "other land encounter"],
                ["other specific aquatic encounter", "other aquatic encounter"],
                ["other extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_CanAddUndergroundToAnEnvironment()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(["specific environment encounter", "any encounter", "land encounter"], ["underground encounter"], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_AddingUndergroundToUnderground()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(["specific underground encounter", "any encounter", "land encounter", "underground encounter"], [], ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_GetAllPossibleWeightedEncounters_AddUndergroundAndAquatic()
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

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("extraplanar encounter"));
            AssertEncounterWeight(
                ["specific environment encounter", "any encounter", "land encounter"],
                ["aquatic encounter", "specific aquatic encounter", "underground encounter", "underground aquatic encounter"],
                ["extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_AddUndergroundToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };

            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

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

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);

            specifications.Environment = EnvironmentConstants.Civilized;
            specifications.AllowUnderground = true;

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other extraplanar encounter"));
            AssertEncounterWeight(
                ["specific civilized encounter", "civilized encounter", "other any encounter", "other land encounter"],
                ["other underground encounter"],
                ["other extraplanar encounter"]);
        }

        [Test]
        public void SelectRandomEncounterFrom_AddUndergroundAndAquaticToCivilized()
        {
            var specificCivilizedEncounters = new[] { "specific civilized encounter", "other specific civilized encounter" };
            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            var undergroundAquaticEncounters = new[] { "underground aquatic encounter", "other underground aquatic encounter" };
            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(temperature + EnvironmentConstants.Civilized, specificCivilizedEncounters);
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

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, nightEncounters);

            wildernessEncounters.Add(extraplanarEncounters[0]);
            wildernessEncounters.Add(anyEncounters[0]);
            wildernessEncounters.Add(landEncounters[0]);
            wildernessEncounters.Add(undergroundEncounters[0]);
            wildernessEncounters.Add(undergroundAquaticEncounters[0]);
            wildernessEncounters.Add(aquaticEncounters[0]);
            wildernessEncounters.Add(specificAquaticEncounters[0]);

            specifications.Environment = EnvironmentConstants.Civilized;
            specifications.AllowAquatic = true;
            specifications.AllowUnderground = true;

            var encounter = encounterCollectionSelector.SelectRandomEncounterFrom(specifications);

            Assert.That(encounter, Is.EqualTo("other extraplanar encounter"));
            AssertEncounterWeight(
                ["specific civilized encounter", "civilized encounter", "other any encounter", "other land encounter"],
                ["other aquatic encounter", "other specific aquatic encounter", "other underground encounter", "other underground aquatic encounter"],
                ["other extraplanar encounter"]);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_AllDefaults_Some()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom();

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        [Ignore("If nothing is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_AllDefaults_None()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom();

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetEnvironment_Some()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(environment: "environment");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetEnvironment_None()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(environment: "environment");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetTemperature_Some()
        {
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Desert, new[] { "my desert encounter", "my wrong encounter" });
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my forest encounter" });
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my hills encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my desert encounter",
                "my forest encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my hills encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, new[]
            {
                "my temperature aquatic encounter",
                "my wrong encounter"
            });

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Civilized, new[]
            {
                "my temperature civilized encounter",
                "my wrong encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my temperature civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(temperature: "temperature");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetTemperature_None()
        {
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Desert, new[] { "my desert encounter", "my wrong encounter" });
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my forest encounter" });
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my hills encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my desert encounter",
                "my forest encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my hills encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, new[]
            {
                "my temperature aquatic encounter",
                "my wrong encounter"
            });

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Civilized, new[]
            {
                "my temperature civilized encounter",
                "my wrong encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my temperature civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(temperature: "temperature");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetTimeOfDay_Some()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(timeOfDay: "time of day");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetTimeOfDay_None()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(timeOfDay: "time of day");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetLevel_Some()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 783);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(level: 783);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetLevel_None()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 7);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(level: 783);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetAllowAquatic_Some(bool aquatic)
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(allowAquatic: aquatic);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        [Ignore("If only the allow aquatic is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetAllowAquatic_None(bool aquatic)
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(allowAquatic: aquatic);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetAllowUnderground_Some(bool underground)
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(allowUnderground: underground);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [TestCase(true)]
        [TestCase(false)]
        [Ignore("If only the allow underground is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetAllowUnderground_None(bool underground)
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            levelEncounters.Clear();

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(allowUnderground: underground);

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetFilter_Some()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            SetupEncounterFilter("filter 1", "my land encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(filters: new[] { "filter 1" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        [Ignore("If only the filter is toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetFilter_None()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            SetupEncounterFilter("filter 1", "my wrong encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(filters: new[] { "filter 1" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetFilters_Some()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            SetupEncounterFilter("filter 1", "my land encounter");
            SetupEncounterFilter("filter 2", "my any encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        [Ignore("If only the filters are toggled, then there will be valid encounters no matter what")]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSetFilters_None()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills, new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
            });

            SetupEncounterLevel("my aquatic encounter", 3);
            SetupEncounterLevel("my warm aquatic encounter", 6);
            SetupEncounterLevel("my temperate aquatic encounter", 9);
            SetupEncounterLevel("my cold aquatic encounter", 6);

            var civilizedEncounters = new[] { "my civilized encounter", "civilized encounter", "other civilized encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Civilized, civilizedEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm civilized encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold civilized encounter"
            });

            SetupEncounterLevel("my civilized encounter", 3);
            SetupEncounterLevel("my warm civilized encounter", 6);
            SetupEncounterLevel("my temperate civilized encounter", 9);
            SetupEncounterLevel("my cold civilized encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);
            SetupEncounterLevel("my underground aquatic encounter", 13);

            SetupEncounterFilter("filter 1", "my wrong encounter");
            SetupEncounterFilter("filter 2", "my other wrong encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSomeSetValues_Some()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            SetupEncounterFilter("filter 1", "my warm encounter", "my land encounter");
            SetupEncounterFilter("filter 2", "my any encounter", "my extraplanar encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(
                environment: "environment",
                timeOfDay: "time of day",
                allowAquatic: false,
                filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromSomeSetValues_None()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[] { "my wrong encounter", "my temperate encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my warm encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my warm encounter", 666);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);
            SetupEncounterLevel("my underground encounter", 7);

            SetupEncounterFilter("filter 1", "my warm encounter", "my wrong encounter");
            SetupEncounterFilter("filter 2", "my any encounter", "my other wrong encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(
                environment: "environment",
                timeOfDay: "time of day",
                allowAquatic: false,
                filters: new[] { "filter 1", "filter 2" });

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromAllSetValues_Some()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my encounter", 783);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            SetupEncounterFilter("filter 1", "my encounter", "my other encounter");
            SetupEncounterFilter("filter 2", "my other land encounter", "my other any encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom("environment", "temperature", "time of day", 783, false, false, "filter 1", "filter 2");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Not.Empty);
        }

        [Test]
        public void SelectPossibleEncountersFrom_ReturnsPossibleEncounters_FromAllSetValues_None()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my encounter",
                "my temperate encounter",
                "my wrong encounter",
                "my any encounter",
                "my extraplanar encounter",
                "my warm aquatic encounter",
                "my cold aquatic encounter",
                "my warm civilized encounter",
                "my cold civilized encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my cold encounter",
                "my wrong encounter",
                "my land encounter",
                "my aquatic encounter",
                "my temperate aquatic encounter",
                "my civilized encounter",
                "my temperate civilized encounter",
                "my underground encounter",
                "my underground aquatic encounter",
                "my other encounter" });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my temperate encounter", 26);
            SetupEncounterLevel("my cold encounter", 6);
            SetupEncounterLevel("my other encounter", 9);

            landEncounters.Add("my land encounter");
            anyEncounters.Add("my any encounter");
            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my land encounter", 2);
            SetupEncounterLevel("my any encounter", 10);
            SetupEncounterLevel("my extraplanar encounter", 4);

            SetupEncounterFilter("filter 1", "my wrong encounter", "my other encounter");
            SetupEncounterFilter("filter 2", "my other wrong encounter", "my other aquatic encounter");

            var possibleEncounters = encounterCollectionSelector.SelectPossibleEncountersFrom(
                "environment",
                "temperature",
                "time of day",
                783,
                false,
                false,
                "filter 1",
                "filter 2");

            //INFO: Since this method is only used in the EncounterVerifier, and immediately followed with .Any(), we will not assert contents
            Assert.That(possibleEncounters, Is.Empty);
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter" });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[] { EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Temperatures.Cold }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_FromLand()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter",
                "my temperate encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter",
                "my land encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            landEncounters.Add("my land encounter");
            SetupEncounterLevel("my land encounter", 6);

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
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter",
                "my temperate encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter",
                "my any encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            anyEncounters.Add("my any encounter");
            SetupEncounterLevel("my any encounter", 6);

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
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter",
                "my temperate encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter",
                "my extraplanar encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my extraplanar encounter", 6);

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
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized, new[]
            {
                "my warm encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my temperate encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized, new[]
            {
                "my wrong encounter",
                "my cold encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter",
                "my civilized encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            civilizedEncounters.Add("my civilized encounter");
            SetupEncounterLevel("my civilized encounter", 6);

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
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter",
                "my temperate encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter",
                "my aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my aquatic encounter", 6);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic, new[]
            {
                "my warm aquatic encounter",
                "my wrong encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my temperate aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic, new[]
            {
                "my wrong encounter",
                "my cold aquatic encounter"
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
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter",
                "my temperate encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter",
                "my specific aquatic encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my specific aquatic encounter", 6);

            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[]
            {
                "specific aquatic encounter",
                "my specific aquatic encounter",
                "other specific aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup(temp + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[] { temp }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_FromUnderground()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter",
                "my temperate encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter",
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter",
                "my underground encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my underground encounter", 6);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my underground encounter"
            });

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

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
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter",
                "my temperate encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter",
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter",
                "my underground aquatic encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my underground aquatic encounter", 6);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

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
            SetUpEncounterGroup(temperature + "environment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter",
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter",
            });

            SetupEncounterLevel("my encounter", 9);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.EquivalentTo(new[] { temperature }));
        }

        [Test]
        public void SelectPossibleTemperatures_ReturnsValidTemperatures_None()
        {
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Warm + "environment", new[] { "my warm encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Temperate + "environment", new[]
            {
                "my wrong encounter",
                "my temperate encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.Temperatures.Cold + "environment", new[] { "my wrong encounter", "my cold encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
{
                "my encounter",
                "my wrong encounter",
                "my day encounter",
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter",
            });

            SetupEncounterLevel("my encounter", 9);

            var possibleTemps = encounterCollectionSelector.SelectPossibleTemperatures("environment");
            Assert.That(possibleTemps, Is.Empty);
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my day encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my night encounter",
                "my wrong encounter",
                "my other encounter" });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.TimesOfDay.Night }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromLand()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter",
                "my land encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            landEncounters.Add("my land encounter");
            SetupEncounterLevel("my land encounter", 6);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromAny()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter",
                "my any encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            anyEncounters.Add("my any encounter");
            SetupEncounterLevel("my any encounter", 6);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromExtraplanar()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter",
                "my extraplanar encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my extraplanar encounter", 6);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromCivilized()
        {
            SetUpEncounterGroup("temperatureCivilized", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter",
                "my civilized encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            civilizedEncounters.Add("my civilized encounter");
            SetupEncounterLevel("my civilized encounter", 6);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay(EnvironmentConstants.Civilized, "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter",
                "my aquatic encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my aquatic encounter", 6);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromSpecificAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter",
                "my specific aquatic encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my specific aquatic encounter", 6);

            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[]
            {
                "specific aquatic encounter",
                "my specific aquatic encounter",
                "other specific aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        //INFO: Because you can have a Day encounter allowing underground (which would be Night), if Night has a valid encounter, it will show Day as an option
        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromUnderground()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my wrong encounter",
                "my underground encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my underground encounter", 6);

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.TimesOfDay.Night }));
        }

        //INFO: Because you can have a Day encounter allowing underground (which would be Night), if Night has a valid encounter, it will show Day as an option
        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_FromUndergroundAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my wrong encounter",
                "my underground aquatic encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my underground aquatic encounter", 6);

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.TimesOfDay.Night }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_ForDay()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter"
            });

            SetupEncounterLevel("my encounter", 9);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day }));
        }

        //INFO: Because you can have a Day encounter allowing underground (which would be Night), if Night has a valid encounter, it will show Day as an option
        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_ForNight()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter"
            });

            SetupEncounterLevel("my encounter", 9);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.EquivalentTo(new[] { EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.TimesOfDay.Night }));
        }

        [Test]
        public void SelectPossibleTimesOfDay_ReturnsValidTimesOfDay_None()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Day, new[]
            {
                "my wrong encounter",
                "my day encounter"
            });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my wrong encounter",
                "my night encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            var possibleTimesOfDay = encounterCollectionSelector.SelectPossibleTimesOfDay("environment", "temperature");
            Assert.That(possibleTimesOfDay, Is.Empty);
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter", "my other encounter" });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromLand()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my land encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            landEncounters.Add("my land encounter");
            SetupEncounterLevel("my land encounter", 6);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromAny()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my any encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            anyEncounters.Add("my any encounter");
            SetupEncounterLevel("my any encounter", 6);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromExtraplanar()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my extraplanar encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            extraplanarEncounters.Add("my extraplanar encounter");
            SetupEncounterLevel("my extraplanar encounter", 6);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromCivilized()
        {
            SetUpEncounterGroup("temperatureCivilized", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my civilized encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);

            civilizedEncounters.Add("my civilized encounter");
            SetupEncounterLevel("my civilized encounter", 6);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels(EnvironmentConstants.Civilized, "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my aquatic encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my aquatic encounter", 6);

            var aquaticEncounters = new[] { "my aquatic encounter", "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromSpecificAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my specific aquatic encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my specific aquatic encounter", 6);

            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[]
            {
                "specific aquatic encounter",
                "my specific aquatic encounter",
                "other specific aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromUnderground()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my underground encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my underground encounter", 6);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my underground encounter"
            });

            var undergroundEncounters = new[]
            {
                "underground encounter",
                "my underground encounter",
                "other underground encounter"
            };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { 9, 26, 6 }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_FromUndergroundAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my underground aquatic encounter"
            });

            SetupEncounterLevel("my encounter", 9);
            SetupEncounterLevel("my other encounter", 26);
            SetupEncounterLevel("my underground aquatic encounter", 6);

            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[]
            {
                "my encounter",
                "my wrong encounter",
                "my other encounter",
                "my underground aquatic encounter"
            });

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my underground aquatic encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

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
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter", "my other encounter" });

            SetupEncounterLevel("my encounter", level);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.EquivalentTo(new[] { level }));
        }

        [Test]
        public void SelectPossibleLevels_ReturnsValidLevels_None()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", EncounterSpecifications.MaximumLevel + 1);

            var possibleLevels = encounterCollectionSelector.SelectPossibleLevels("environment", "temperature", "time of day");
            Assert.That(possibleLevels, Is.Empty);
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromLand()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            landEncounters.Add("my encounter");

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromAny()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            anyEncounters.Add("my encounter");

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromExtraplanar()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            extraplanarEncounters.Add("my encounter");

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromCivilized()
        {
            SetUpEncounterGroup("temperatureCivilized", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            civilizedEncounters.Add("my encounter");

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic(EnvironmentConstants.Civilized, "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            var aquaticEncounters = new[] { "my encounter", "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromSpecificAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "my encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromUnderground()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            var undergroundEncounters = new[] { "underground encounter", "my encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel("my encounter", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_FromUndergroundAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel("my encounter", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.EquivalentTo(new[] { true }));
        }

        [Test]
        public void SelectPossibleAllowAquatic_ReturnsValidAquatic_None()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter", 9266);

            var possibleAquatics = encounterCollectionSelector.SelectPossibleAllowAquatic("environment", "temperature", "time of day", 9266);
            Assert.That(possibleAquatics, Is.Empty);
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromLand()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            landEncounters.Add("my encounter");

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromAny()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            anyEncounters.Add("my encounter");

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromExtraplanar()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            extraplanarEncounters.Add("my encounter");

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromCivilized()
        {
            SetUpEncounterGroup("temperatureCivilized", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            civilizedEncounters.Add("my encounter");

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
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            var aquaticEncounters = new[] { "my encounter", "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, true);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromSpecificAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "my encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, true);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true, false }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromUnderground()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            var undergroundEncounters = new[] { "underground encounter", "my encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel("my encounter", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_FromUndergroundAquatic()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel("my encounter", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, true);
            Assert.That(possibleUndergrounds, Is.EquivalentTo(new[] { true }));
        }

        [Test]
        public void SelectPossibleAllowUnderground_ReturnsValidUnderground_None()
        {
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            var undergroundEncounters = new[] { "underground encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel("my encounter", 9266);

            var possibleUndergrounds = encounterCollectionSelector.SelectPossibleAllowUnderground("environment", "temperature", "time of day", 9266, false);
            Assert.That(possibleUndergrounds, Is.Empty);
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters()
        {
            SetupAllFilters();
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        private void SetupAllFilters()
        {
            SetupEncounterFilter(CreatureDataConstants.Types.Aberration);
            SetupEncounterFilter(CreatureDataConstants.Types.Animal);
            SetupEncounterFilter(CreatureDataConstants.Types.Construct);
            SetupEncounterFilter(CreatureDataConstants.Types.Dragon);
            SetupEncounterFilter(CreatureDataConstants.Types.Elemental);
            SetupEncounterFilter(CreatureDataConstants.Types.Fey);
            SetupEncounterFilter(CreatureDataConstants.Types.Giant);
            SetupEncounterFilter(CreatureDataConstants.Types.Humanoid);
            SetupEncounterFilter(CreatureDataConstants.Types.MagicalBeast);
            SetupEncounterFilter(CreatureDataConstants.Types.MonstrousHumanoid);
            SetupEncounterFilter(CreatureDataConstants.Types.Ooze);
            SetupEncounterFilter(CreatureDataConstants.Types.Outsider);
            SetupEncounterFilter(CreatureDataConstants.Types.Plant);
            SetupEncounterFilter(CreatureDataConstants.Types.Undead);
            SetupEncounterFilter(CreatureDataConstants.Types.Vermin);
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromLand()
        {
            SetupAllFilters();
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            landEncounters.Add("my encounter");

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromAny()
        {
            SetupAllFilters();
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            anyEncounters.Add("my encounter");

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromExtraplanar()
        {
            SetupAllFilters();
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            extraplanarEncounters.Add("my encounter");

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromCivilized()
        {
            SetupAllFilters();
            SetUpEncounterGroup("temperatureCivilized", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);
            civilizedEncounters.Add("my encounter");

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters(EnvironmentConstants.Civilized, "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromAquatic()
        {
            SetupAllFilters();
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            var aquaticEncounters = new[] { "my encounter", "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter", 9266);

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, true, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromSpecificAquatic()
        {
            SetupAllFilters();
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            var aquaticEncounters = new[] { "aquatic encounter", "other aquatic encounter" };
            var specificAquaticEncounters = new[] { "specific aquatic encounter", "my encounter", "other specific aquatic encounter" };

            SetUpEncounterGroup(EnvironmentConstants.Aquatic, aquaticEncounters);
            SetUpEncounterGroup("temperature" + EnvironmentConstants.Aquatic, specificAquaticEncounters);

            SetupEncounterLevel("my encounter", 9266);

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, true, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromUnderground()
        {
            SetupAllFilters();
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            var undergroundEncounters = new[] { "underground encounter", "my encounter", "other underground encounter" };
            SetUpEncounterGroup(EnvironmentConstants.Underground, undergroundEncounters);

            SetupEncounterLevel("my encounter", 9266);

            filters[CreatureDataConstants.Types.Aberration].Add("my encounter");
            filters[CreatureDataConstants.Types.Aberration].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, true);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { CreatureDataConstants.Types.Aberration }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_FromUndergroundAquatic()
        {
            SetupAllFilters();
            SetUpEncounterGroup("temperatureenvironment", new[] { "my other encounter" });
            SetUpEncounterGroup(EnvironmentConstants.TimesOfDay.Night, new[] { "my encounter", "my wrong encounter" });

            var undergroundAquaticEncounters = new[]
            {
                "underground aquatic encounter",
                "my encounter",
                "other underground aquatic encounter"
            };

            SetUpEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, undergroundAquaticEncounters);

            SetupEncounterLevel("my encounter", 9266);

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
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);

            filters[filter].Add("my encounter");
            filters[filter].Add("my wrong encounter");

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.EquivalentTo(new[] { filter }));
        }

        [Test]
        public void SelectPossibleFilters_ReturnsValidFilters_SomeFilters()
        {
            SetupAllFilters();
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter", "my other encounter" });

            SetupEncounterLevel("my encounter", 9266);
            SetupEncounterLevel("my other encounter", 9266);

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
            SetUpEncounterGroup("temperatureenvironment", new[] { "my encounter", "my other encounter" });
            SetUpEncounterGroup("time of day", new[] { "my encounter", "my wrong encounter" });

            SetupEncounterLevel("my encounter", 9266);

            var possibleFilters = encounterCollectionSelector.SelectPossibleFilters("environment", "temperature", "time of day", 9266, false, false);
            Assert.That(possibleFilters, Is.Empty);
        }
    }
}
