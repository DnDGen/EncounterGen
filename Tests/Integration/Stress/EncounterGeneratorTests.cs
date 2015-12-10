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

        private IEnumerable<String> environments;

        [SetUp]
        public void Setup()
        {
            environments = new[]
            {
                EnvironmentConstants.ColdForest,
                EnvironmentConstants.TemperateForest,
                EnvironmentConstants.WarmForest,
                EnvironmentConstants.ColdMarsh,
                EnvironmentConstants.TemperateMarsh,
                EnvironmentConstants.WarmMarsh,
                EnvironmentConstants.ColdHills,
                EnvironmentConstants.TemperateHills,
                EnvironmentConstants.WarmHills,
                EnvironmentConstants.ColdMountain,
                EnvironmentConstants.TemperateMountain,
                EnvironmentConstants.WarmMountain,
                EnvironmentConstants.ColdDesert,
                EnvironmentConstants.TemperateDesert,
                EnvironmentConstants.WarmDesert,
                EnvironmentConstants.ColdPlains,
                EnvironmentConstants.TemperatePlains,
                EnvironmentConstants.WarmPlains,
                EnvironmentConstants.Dungeon
            };
        }

        [TestCase("Encounter Generator")]
        public override void Stress(String stressSubject)
        {
            Stress();
        }

        protected override void MakeAssertions()
        {
            var randomIndex = Random.Next(environments.Count());
            var environment = environments.ElementAt(randomIndex);

            var encounter = MakeEncounter(environment);
            AssertEncounter(encounter);
        }

        private Encounter MakeEncounter(String environment)
        {
            var level = Random.Next(1, 21);
            return EncounterGenerator.Generate(environment, level);
        }

        private void AssertEncounter(Encounter encounter)
        {
            Assert.That(encounter.Creatures, Is.Not.Empty);

            foreach (var creature in encounter.Creatures)
            {
                Assert.That(creature.Type, Is.Not.Empty);
                Assert.That(creature.Quantity, Is.InRange(1, 14));
            }

            if (encounter.Characters.Any())
            {
                Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
                Assert.That(encounter.Treasure.Goods, Is.Empty);
                Assert.That(encounter.Treasure.Items, Is.Empty);
            }
        }

        [Test]
        public void StressDungeonEncounters()
        {
            Stress(AssertDungeon);
        }

        private void AssertDungeon()
        {
            var encounter = MakeEncounter(EnvironmentConstants.Dungeon);
            AssertEncounter(encounter);
        }
    }
}
