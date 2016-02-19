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

        private IEnumerable<string> environments;

        [SetUp]
        public void Setup()
        {
            environments = new[]
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
            var encounter = MakeEncounter();
            AssertEncounter(encounter);
        }

        private Encounter MakeEncounter()
        {
            var randomIndex = Random.Next(environments.Count());
            var environment = environments.ElementAt(randomIndex);

            return MakeEncounter(environment);
        }

        private Encounter MakeEncounter(string environment)
        {
            var level = Random.Next(1, 21);
            return EncounterGenerator.Generate(environment, level);
        }

        private void AssertEncounter(Encounter encounter)
        {
            Assert.That(encounter.Creatures, Is.Not.Empty);
            Assert.That(encounter.Creatures, Is.All.Not.Null);
            Assert.That(encounter.Characters, Is.All.Not.Null);

            foreach (var creature in encounter.Creatures)
            {
                Assert.That(creature.Type, Is.Not.Empty);
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
        public void TreasureDoesNotHappen()
        {
            var encounter = GenerateOrFail(MakeEncounter, e => e.Treasure.Coin.Quantity == 0 && e.Treasure.Goods.Any() == false && e.Treasure.Items.Any() == false);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(encounter.Treasure.Goods, Is.Empty);
            Assert.That(encounter.Treasure.Items, Is.Empty);
        }

        [Test]
        public void TreasureHappens()
        {
            var encounter = GenerateOrFail(MakeEncounter, e => e.Treasure.Coin.Quantity > 0 || e.Treasure.Goods.Any() || e.Treasure.Items.Any());
            Assert.That(encounter.Treasure.Coin.Quantity > 0 || encounter.Treasure.Goods.Any() || encounter.Treasure.Items.Any(), Is.True);
        }

        [Test]
        public void CoinHappens()
        {
            var encounter = GenerateOrFail(MakeEncounter, e => e.Treasure.Coin.Quantity > 0);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.Positive);
            Assert.That(encounter.Treasure.Coin.Currency, Is.Not.Empty);
        }

        [Test]
        public void GoodsHappen()
        {
            var encounter = GenerateOrFail(MakeEncounter, e => e.Treasure.Goods.Any());
            Assert.That(encounter.Treasure.Goods, Is.Not.Empty);
        }

        [Test]
        public void ItemsHappen()
        {
            var encounter = GenerateOrFail(MakeEncounter, e => e.Treasure.Items.Any());
            Assert.That(encounter.Treasure.Items, Is.Not.Empty);
        }

        [Test]
        public void CharactersHappen()
        {
            var encounter = GenerateOrFail(MakeEncounter, e => e.Characters.Any());
            Assert.That(encounter.Characters, Is.Not.Empty);
        }

        [Test]
        public void CharactersDoNotHappen()
        {
            var encounter = GenerateOrFail(MakeEncounter, e => e.Characters.Any() == false);
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SingleCreatureHappens()
        {
            var encounter = GenerateOrFail(MakeEncounter, e => e.Creatures.Count() == 1);
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(1));
        }

        [Test]
        public void MultipleCreaturesHappen()
        {
            var encounter = GenerateOrFail(MakeEncounter, e => e.Creatures.Count() > 1);
            Assert.That(encounter.Creatures.Count(), Is.GreaterThan(1));
        }
    }
}
