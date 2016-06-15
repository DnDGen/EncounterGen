using EncounterGen.Common;
using EncounterGen.Generators;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Integration.Stress
{
    [TestFixture]
    public class EncounterGeneratorTests : StressTests
    {
        [Inject]
        public IEncounterGenerator EncounterGenerator { get; set; }
        [Inject]
        public Random Random { get; set; }
        [Inject]
        public IFilterVerifier FilterVerifier { get; set; }

        private IEnumerable<string> allEnvironments;

        [SetUp]
        public void Setup()
        {
            allEnvironments = new[]
            {
                EnvironmentConstants.ColdForestDay,
                EnvironmentConstants.TemperateForestDay,
                EnvironmentConstants.WarmForestDay,
                EnvironmentConstants.ColdMarshDay,
                EnvironmentConstants.TemperateMarshDay,
                EnvironmentConstants.WarmMarshDay,
                EnvironmentConstants.ColdHillsDay,
                EnvironmentConstants.TemperateHillsDay,
                EnvironmentConstants.WarmHillsDay,
                EnvironmentConstants.ColdMountainDay,
                EnvironmentConstants.TemperateMountainDay,
                EnvironmentConstants.WarmMountainDay,
                EnvironmentConstants.ColdDesertDay,
                EnvironmentConstants.TemperateDesertDay,
                EnvironmentConstants.WarmDesertDay,
                EnvironmentConstants.ColdPlainsDay,
                EnvironmentConstants.TemperatePlainsDay,
                EnvironmentConstants.WarmPlainsDay,
                EnvironmentConstants.Dungeon,
                EnvironmentConstants.CivilizedDay,
                EnvironmentConstants.CivilizedNight,
                EnvironmentConstants.ColdDesertNight,
                EnvironmentConstants.ColdForestNight,
                EnvironmentConstants.ColdHillsNight,
                EnvironmentConstants.ColdMarshNight,
                EnvironmentConstants.ColdMountainNight,
                EnvironmentConstants.ColdPlainsNight,
                EnvironmentConstants.TemperateDesertNight,
                EnvironmentConstants.TemperateForestNight,
                EnvironmentConstants.TemperateHillsNight,
                EnvironmentConstants.TemperateMarshNight,
                EnvironmentConstants.TemperateMountainNight,
                EnvironmentConstants.TemperatePlainsNight,
                EnvironmentConstants.WarmDesertNight,
                EnvironmentConstants.WarmForestNight,
                EnvironmentConstants.WarmHillsNight,
                EnvironmentConstants.WarmMarshNight,
                EnvironmentConstants.WarmMountainNight,
                EnvironmentConstants.WarmPlainsNight
            };
        }

        [TestCase("Encounter Generator")]
        public override void Stress(string stressSubject)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            AssertEncounterInRandomEnvironment(allEnvironments);
        }

        private Encounter MakeEncounter(IEnumerable<string> environments, params string[] filters)
        {
            var randomIndex = Random.Next(environments.Count());
            var environment = environments.ElementAt(randomIndex);
            var levels = Enumerable.Range(1, 20);

            while (levels.Any(l => FilterVerifier.FiltersAreValid(environment, l, filters) == false))
            {
                randomIndex = Random.Next(environments.Count());
                environment = environments.ElementAt(randomIndex);
            }

            return MakeEncounter(environment);
        }

        private Encounter MakeEncounter(string environment, params string[] filters)
        {
            var level = Random.Next(1, 21);

            while (FilterVerifier.FiltersAreValid(environment, level, filters) == false)
            {
                level = Random.Next(1, 21);
            }

            return EncounterGenerator.Generate(environment, level, filters);
        }

        private void AssertEncounter(Encounter encounter)
        {
            Assert.That(encounter.Creatures, Is.Not.Empty);
            Assert.That(encounter.Creatures, Is.All.Not.Null);
            Assert.That(encounter.Characters, Is.All.Not.Null);

            foreach (var creature in encounter.Creatures)
            {
                Assert.That(creature.Name, Is.Not.Empty);
                Assert.That(creature.Quantity, Is.InRange(1, 14));
            }
        }

        [Test]
        public void StressDungeonEncounters()
        {
            Stress(AssertDungeonEncounter);
        }

        private void AssertDungeonEncounter()
        {
            var encounter = MakeEncounter(EnvironmentConstants.Dungeon);
            AssertEncounter(encounter);
        }

        [Test]
        public void StressColdEncounters()
        {
            var coldEnvironments = new[]
            {
                EnvironmentConstants.ColdDesertDay,
                EnvironmentConstants.ColdDesertNight,
                EnvironmentConstants.ColdForestDay,
                EnvironmentConstants.ColdForestNight,
                EnvironmentConstants.ColdHillsDay,
                EnvironmentConstants.ColdHillsNight,
                EnvironmentConstants.ColdMarshDay,
                EnvironmentConstants.ColdMarshNight,
                EnvironmentConstants.ColdMountainDay,
                EnvironmentConstants.ColdMountainNight,
                EnvironmentConstants.ColdPlainsDay,
                EnvironmentConstants.ColdPlainsNight
            };

            Stress(() => AssertEncounterInRandomEnvironment(coldEnvironments));
        }

        [Test]
        public void StressTemperateEncounters()
        {
            var temperateEnvironments = new[]
            {
                EnvironmentConstants.TemperateDesertDay,
                EnvironmentConstants.TemperateDesertNight,
                EnvironmentConstants.TemperateForestDay,
                EnvironmentConstants.TemperateForestNight,
                EnvironmentConstants.TemperateHillsDay,
                EnvironmentConstants.TemperateHillsNight,
                EnvironmentConstants.TemperateMarshDay,
                EnvironmentConstants.TemperateMarshNight,
                EnvironmentConstants.TemperateMountainDay,
                EnvironmentConstants.TemperateMountainNight,
                EnvironmentConstants.TemperatePlainsDay,
                EnvironmentConstants.TemperatePlainsNight
            };

            Stress(() => AssertEncounterInRandomEnvironment(temperateEnvironments));
        }

        [Test]
        public void StressWarmEncounters()
        {
            var warmEnvironments = new[]
            {
                EnvironmentConstants.WarmDesertDay,
                EnvironmentConstants.WarmDesertNight,
                EnvironmentConstants.WarmForestDay,
                EnvironmentConstants.WarmForestNight,
                EnvironmentConstants.WarmHillsDay,
                EnvironmentConstants.WarmHillsNight,
                EnvironmentConstants.WarmMarshDay,
                EnvironmentConstants.WarmMarshNight,
                EnvironmentConstants.WarmMountainDay,
                EnvironmentConstants.WarmMountainNight,
                EnvironmentConstants.WarmPlainsDay,
                EnvironmentConstants.WarmPlainsNight
            };

            Stress(() => AssertEncounterInRandomEnvironment(warmEnvironments));
        }

        [TestCase(EnvironmentConstants.CivilizedDay, EnvironmentConstants.CivilizedNight)]
        [TestCase(EnvironmentConstants.ColdDesertDay, EnvironmentConstants.ColdDesertNight)]
        [TestCase(EnvironmentConstants.ColdForestDay, EnvironmentConstants.ColdForestNight)]
        [TestCase(EnvironmentConstants.ColdHillsDay, EnvironmentConstants.ColdHillsNight)]
        [TestCase(EnvironmentConstants.ColdMarshDay, EnvironmentConstants.ColdMarshNight)]
        [TestCase(EnvironmentConstants.ColdMountainDay, EnvironmentConstants.ColdMountainNight)]
        [TestCase(EnvironmentConstants.ColdPlainsDay, EnvironmentConstants.ColdPlainsNight)]
        [TestCase(EnvironmentConstants.TemperateDesertDay, EnvironmentConstants.TemperateDesertNight)]
        [TestCase(EnvironmentConstants.TemperateForestDay, EnvironmentConstants.TemperateForestNight)]
        [TestCase(EnvironmentConstants.TemperateHillsDay, EnvironmentConstants.TemperateHillsNight)]
        [TestCase(EnvironmentConstants.TemperateMarshDay, EnvironmentConstants.TemperateMarshNight)]
        [TestCase(EnvironmentConstants.TemperateMountainDay, EnvironmentConstants.TemperateMountainNight)]
        [TestCase(EnvironmentConstants.TemperatePlainsDay, EnvironmentConstants.TemperatePlainsNight)]
        [TestCase(EnvironmentConstants.WarmDesertDay, EnvironmentConstants.WarmDesertNight)]
        [TestCase(EnvironmentConstants.WarmForestDay, EnvironmentConstants.WarmForestNight)]
        [TestCase(EnvironmentConstants.WarmHillsDay, EnvironmentConstants.WarmHillsNight)]
        [TestCase(EnvironmentConstants.WarmMarshDay, EnvironmentConstants.WarmMarshNight)]
        [TestCase(EnvironmentConstants.WarmMountainDay, EnvironmentConstants.WarmMountainNight)]
        [TestCase(EnvironmentConstants.WarmPlainsDay, EnvironmentConstants.WarmPlainsNight)]
        public void StressFullDayOfEncounters(string day, string night)
        {
            var environments = new[] { day, night };
            Stress(() => AssertEncounterInRandomEnvironment(environments));
        }

        [Test]
        public void StressDesertEncounters()
        {
            var desertEnvironments = new[]
            {
                EnvironmentConstants.ColdDesertDay,
                EnvironmentConstants.ColdDesertNight,
                EnvironmentConstants.TemperateDesertDay,
                EnvironmentConstants.TemperateDesertNight,
                EnvironmentConstants.WarmDesertDay,
                EnvironmentConstants.WarmDesertNight
            };

            Stress(() => AssertEncounterInRandomEnvironment(desertEnvironments));
        }

        [Test]
        public void StressForestEncounters()
        {
            var forestEnvironments = new[]
            {
                EnvironmentConstants.ColdForestDay,
                EnvironmentConstants.ColdForestNight,
                EnvironmentConstants.TemperateForestDay,
                EnvironmentConstants.TemperateForestNight,
                EnvironmentConstants.WarmForestDay,
                EnvironmentConstants.WarmForestNight
            };

            Stress(() => AssertEncounterInRandomEnvironment(forestEnvironments));
        }

        [Test]
        public void StressHillsEncounters()
        {
            var hillsEnvironments = new[]
            {
                EnvironmentConstants.ColdHillsDay,
                EnvironmentConstants.ColdHillsNight,
                EnvironmentConstants.TemperateHillsDay,
                EnvironmentConstants.TemperateHillsNight,
                EnvironmentConstants.WarmHillsDay,
                EnvironmentConstants.WarmHillsNight
            };

            Stress(() => AssertEncounterInRandomEnvironment(hillsEnvironments));
        }

        [Test]
        public void StressMarshEncounters()
        {
            var marshEnvironments = new[]
            {
                EnvironmentConstants.ColdMarshDay,
                EnvironmentConstants.ColdMarshNight,
                EnvironmentConstants.TemperateMarshDay,
                EnvironmentConstants.TemperateMarshNight,
                EnvironmentConstants.WarmMarshDay,
                EnvironmentConstants.WarmMarshNight
            };

            Stress(() => AssertEncounterInRandomEnvironment(marshEnvironments));
        }

        [Test]
        public void StressMountainEncounters()
        {
            var mountainEnvironments = new[]
            {
                EnvironmentConstants.ColdMountainDay,
                EnvironmentConstants.ColdMountainNight,
                EnvironmentConstants.TemperateMountainDay,
                EnvironmentConstants.TemperateMountainNight,
                EnvironmentConstants.WarmMountainDay,
                EnvironmentConstants.WarmMountainNight
            };

            Stress(() => AssertEncounterInRandomEnvironment(mountainEnvironments));
        }

        [Test]
        public void StressPlainsEncounters()
        {
            var plainsEnvironments = new[]
            {
                EnvironmentConstants.ColdPlainsDay,
                EnvironmentConstants.ColdPlainsNight,
                EnvironmentConstants.TemperatePlainsDay,
                EnvironmentConstants.TemperatePlainsNight,
                EnvironmentConstants.WarmPlainsDay,
                EnvironmentConstants.WarmPlainsNight
            };

            Stress(() => AssertEncounterInRandomEnvironment(plainsEnvironments));
        }

        private void AssertEncounterInRandomEnvironment(IEnumerable<string> environments, params string[] filters)
        {
            var encounter = MakeEncounter(environments, filters);
            AssertEncounter(encounter);
        }

        [Test]
        public void TreasureDoesNotHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Treasure.Coin.Quantity == 0 && e.Treasure.Goods.Any() == false && e.Treasure.Items.Any() == false);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(encounter.Treasure.Goods, Is.Empty);
            Assert.That(encounter.Treasure.Items, Is.Empty);
        }

        [Test]
        public void TreasureHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Treasure.Coin.Quantity > 0 || e.Treasure.Goods.Any() || e.Treasure.Items.Any());
            Assert.That(encounter.Treasure.Coin.Quantity > 0 || encounter.Treasure.Goods.Any() || encounter.Treasure.Items.Any(), Is.True);
        }

        [Test]
        public void CoinHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Treasure.Coin.Quantity > 0);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.Positive);
            Assert.That(encounter.Treasure.Coin.Currency, Is.Not.Empty);
        }

        [Test]
        public void GoodsHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Treasure.Goods.Any());
            Assert.That(encounter.Treasure.Goods, Is.Not.Empty);
        }

        [Test]
        public void ItemsHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Treasure.Items.Any());
            Assert.That(encounter.Treasure.Items, Is.Not.Empty);
        }

        [Test]
        public void CharactersHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Characters.Any());
            Assert.That(encounter.Characters, Is.Not.Empty);
        }

        [Test]
        public void CharactersDoNotHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Characters.Any() == false);
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SingleCreatureHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Creatures.Count() == 1);
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(1));
        }

        [Test]
        public void MultipleCreaturesHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Creatures.Count() > 1);
            Assert.That(encounter.Creatures.Count(), Is.GreaterThan(1));
        }

        [TestCase(CreatureConstants.Types.Aberration)]
        [TestCase(CreatureConstants.Types.Animal)]
        [TestCase(CreatureConstants.Types.Construct)]
        [TestCase(CreatureConstants.Types.Dragon)]
        [TestCase(CreatureConstants.Types.Elemental)]
        [TestCase(CreatureConstants.Types.Fey)]
        [TestCase(CreatureConstants.Types.Giant)]
        [TestCase(CreatureConstants.Types.Humanoid)]
        [TestCase(CreatureConstants.Types.MagicalBeast)]
        [TestCase(CreatureConstants.Types.MonstrousHumanoid)]
        [TestCase(CreatureConstants.Types.Ooze)]
        [TestCase(CreatureConstants.Types.Outsider)]
        [TestCase(CreatureConstants.Types.Plant)]
        [TestCase(CreatureConstants.Types.Undead)]
        [TestCase(CreatureConstants.Types.Vermin)]
        public void StressFilter(string filter)
        {
            Stress(() => AssertEncounterInRandomEnvironment(allEnvironments, filter));
        }
    }
}
