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

        [TestCase("Encounter Generator", IgnoreReason = "Ignoring for 0.2")]
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
            var levels = Enumerable.Range(1, 20);

            var environment = Generate(() => GeneratEnvironment(environments),
                e => levels.Any(l => FilterVerifier.FiltersAreValid(e, l, filters)));

            return MakeEncounter(environment);
        }

        {
            var total = environments.Count();
            var randomIndex = Random.Next(total);
            var environment = environments.ElementAt(randomIndex);

            return environment;
        }

        private Encounter MakeEncounter(string environment, params string[] filters)
        {
            var level = Generate(() => Random.Next(1, 21), l => FilterVerifier.FiltersAreValid(environment, 1, filters));

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

        [TestCase(EnvironmentConstants.Dungeon)]
        [TestCase(EnvironmentConstants.ColdDesertDay,
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
            EnvironmentConstants.ColdPlainsNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.TemperateDesertDay,
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
            EnvironmentConstants.TemperatePlainsNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.WarmDesertDay,
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
            EnvironmentConstants.WarmPlainsNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.CivilizedDay, EnvironmentConstants.CivilizedNight)]
        [TestCase(EnvironmentConstants.ColdDesertDay, EnvironmentConstants.ColdDesertNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdForestDay, EnvironmentConstants.ColdForestNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdHillsDay, EnvironmentConstants.ColdHillsNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdMarshDay, EnvironmentConstants.ColdMarshNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdMountainDay, EnvironmentConstants.ColdMountainNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdPlainsDay, EnvironmentConstants.ColdPlainsNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.TemperateDesertDay, EnvironmentConstants.TemperateDesertNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.TemperateForestDay, EnvironmentConstants.TemperateForestNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.TemperateHillsDay, EnvironmentConstants.TemperateHillsNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.TemperateMarshDay, EnvironmentConstants.TemperateMarshNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.TemperateMountainDay, EnvironmentConstants.TemperateMountainNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.TemperatePlainsDay, EnvironmentConstants.TemperatePlainsNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.WarmDesertDay, EnvironmentConstants.WarmDesertNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.WarmForestDay, EnvironmentConstants.WarmForestNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.WarmHillsDay, EnvironmentConstants.WarmHillsNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.WarmMarshDay, EnvironmentConstants.WarmMarshNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.WarmMountainDay, EnvironmentConstants.WarmMountainNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.WarmPlainsDay, EnvironmentConstants.WarmPlainsNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdDesertDay,
            EnvironmentConstants.ColdDesertNight,
            EnvironmentConstants.TemperateDesertDay,
            EnvironmentConstants.TemperateDesertNight,
            EnvironmentConstants.WarmDesertDay,
            EnvironmentConstants.WarmDesertNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdForestDay,
            EnvironmentConstants.ColdForestNight,
            EnvironmentConstants.TemperateForestDay,
            EnvironmentConstants.TemperateForestNight,
            EnvironmentConstants.WarmForestDay,
            EnvironmentConstants.WarmForestNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdHillsDay,
            EnvironmentConstants.ColdHillsNight,
            EnvironmentConstants.TemperateHillsDay,
            EnvironmentConstants.TemperateHillsNight,
            EnvironmentConstants.WarmHillsDay,
            EnvironmentConstants.WarmHillsNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdMarshDay,
            EnvironmentConstants.ColdMarshNight,
            EnvironmentConstants.TemperateMarshDay,
            EnvironmentConstants.TemperateMarshNight,
            EnvironmentConstants.WarmMarshDay,
            EnvironmentConstants.WarmMarshNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdMountainDay,
            EnvironmentConstants.ColdMountainNight,
            EnvironmentConstants.TemperateMountainDay,
            EnvironmentConstants.TemperateMountainNight,
            EnvironmentConstants.WarmMountainDay,
            EnvironmentConstants.WarmMountainNight, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(EnvironmentConstants.ColdPlainsDay,
            EnvironmentConstants.ColdPlainsNight,
            EnvironmentConstants.TemperatePlainsDay,
            EnvironmentConstants.TemperatePlainsNight,
            EnvironmentConstants.WarmPlainsDay,
            EnvironmentConstants.WarmPlainsNight, IgnoreReason = "Ignoring for 0.2")]
        public void StressEnvironments(params string[] environments)
        {
            Stress(() => AssertEncounterInRandomEnvironment(environments));
        }

        private void AssertEncounterInRandomEnvironment(IEnumerable<string> environments, params string[] filters)
        {
            var encounter = MakeEncounter(environments, filters);
            AssertEncounter(encounter);
        }

        [Test, Ignore("Ignoring for 0.2")]
        public void TreasureDoesNotHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Treasure.Coin.Quantity == 0 && e.Treasure.Goods.Any() == false && e.Treasure.Items.Any() == false);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(encounter.Treasure.Goods, Is.Empty);
            Assert.That(encounter.Treasure.Items, Is.Empty);
        }

        [Test, Ignore("Ignoring for 0.2")]
        public void TreasureHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Treasure.Coin.Quantity > 0 || e.Treasure.Goods.Any() || e.Treasure.Items.Any());
            Assert.That(encounter.Treasure.Coin.Quantity > 0 || encounter.Treasure.Goods.Any() || encounter.Treasure.Items.Any(), Is.True);
        }

        [Test, Ignore("Ignoring for 0.2")]
        public void CoinHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Treasure.Coin.Quantity > 0);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.Positive);
            Assert.That(encounter.Treasure.Coin.Currency, Is.Not.Empty);
        }

        [Test, Ignore("Ignoring for 0.2")]
        public void GoodsHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Treasure.Goods.Any());
            Assert.That(encounter.Treasure.Goods, Is.Not.Empty);
        }

        [Test, Ignore("Ignoring for 0.2")]
        public void ItemsHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Treasure.Items.Any());
            Assert.That(encounter.Treasure.Items, Is.Not.Empty);
        }

        [Test, Ignore("Ignoring for 0.2")]
        public void CharactersHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Characters.Any());
            Assert.That(encounter.Characters, Is.Not.Empty);
        }

        [Test, Ignore("Ignoring for 0.2")]
        public void CharactersDoNotHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Characters.Any() == false);
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test, Ignore("Ignoring for 0.2")]
        public void SingleCreatureHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Creatures.Count() == 1);
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(1));
        }

        [Test, Ignore("Ignoring for 0.2")]
        public void MultipleCreaturesHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounter(allEnvironments), e => e.Creatures.Count() > 1);
            Assert.That(encounter.Creatures.Count(), Is.GreaterThan(1));
        }

        [TestCase(CreatureConstants.Types.Aberration, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Animal, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Construct, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Dragon, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Elemental, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Fey, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Giant, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Humanoid, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.MagicalBeast, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.MonstrousHumanoid, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Ooze, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Outsider, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Plant, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Undead, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Vermin, IgnoreReason = "Ignoring for 0.2")]
        [TestCase(CreatureConstants.Types.Aberration,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Animal,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Construct,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Dragon,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Elemental,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Fey,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight, IgnoreReason = "Ignoring for 0.2 (No Feys in these environments)")]
        [TestCase(CreatureConstants.Types.Giant,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Humanoid,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.MagicalBeast,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.MonstrousHumanoid,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Ooze,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Outsider,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Plant,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Undead,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        [TestCase(CreatureConstants.Types.Vermin,
            EnvironmentConstants.Dungeon,
            EnvironmentConstants.CivilizedDay,
            EnvironmentConstants.CivilizedNight)]
        public void StressFilter(string filter, params string[] environments)
        {
            if (environments.Any())
                Stress(() => AssertEncounterInRandomEnvironment(environments, filter));
            else
                Stress(() => AssertEncounterInRandomEnvironment(allEnvironments, filter));
        }
    }
}
