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

            Assert.That(encounter.Creatures, Is.Not.Empty);

            if (encounter.Creatures.Any(c => c == CreatureConstants.Character))
            {
                Assert.That(encounter.Characters.Count(), Is.EqualTo(encounter.Creatures.Count()));
                Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
                Assert.That(encounter.Treasure.Goods, Is.Empty);
                Assert.That(encounter.Treasure.Items, Is.Empty);
            }
        }

        private Encounter MakeEncounter(String environment)
        {
            var level = Random.Next(1, 21);
            return EncounterGenerator.Generate(environment, level);
        }

        [Test]
        public void StressDungeonEncounters()
        {
            var encounter = Generate(() => MakeEncounter(EnvironmentConstants.Dungeon), e => true);

            Assert.That(encounter.Creatures, Is.Not.Empty);

            if (encounter.Creatures.Any(c => c == CreatureConstants.Character))
            {
                Assert.That(encounter.Characters.Count(), Is.EqualTo(encounter.Creatures.Count()));
                Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
                Assert.That(encounter.Treasure.Goods, Is.Empty);
                Assert.That(encounter.Treasure.Items, Is.Empty);
            }
        }
    }
}
