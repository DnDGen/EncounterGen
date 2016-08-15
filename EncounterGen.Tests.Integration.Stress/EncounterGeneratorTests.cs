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
        private IEnumerable<string> allTemperatures;
        private IEnumerable<string> allTimesOfDay;

        [SetUp]
        public void Setup()
        {
            allEnvironments = new[]
            {
                EnvironmentConstants.Forest,
                EnvironmentConstants.Marsh,
                EnvironmentConstants.Mountain,
                EnvironmentConstants.Hills,
                EnvironmentConstants.Civilized,
                EnvironmentConstants.Desert,
                EnvironmentConstants.Dungeon,
                EnvironmentConstants.Plains
            };

            allTemperatures = new[]
            {
                EnvironmentConstants.Temperatures.Cold,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Warm
            };

            allTimesOfDay = new[]
            {
                EnvironmentConstants.TimesOfDay.Day,
                EnvironmentConstants.TimesOfDay.Night
            };
        }

        [Test]
        public void StressEncounterGenerator()
        {
            Stress(() => AssertEncounterInRandomEnvironment());
        }

        private Encounter MakeEncounterInRandomEnvironment(params string[] filters)
        {
            var parameters = Generate(RandomizeParameters, p => FilterVerifier.FiltersAreValid(p.Environment, p.Level, p.Temperature, p.TimeOfDay, filters));
            return EncounterGenerator.Generate(parameters.Environment, parameters.Level, parameters.Temperature, parameters.TimeOfDay, filters);
        }

        private EncounterGeneratorParameters RandomizeParameters()
        {
            var parameters = new EncounterGeneratorParameters();
            parameters.Environment = GetRandomFrom(allEnvironments);
            parameters.Temperature = GetRandomFrom(allTemperatures);
            parameters.TimeOfDay = GetRandomFrom(allTimesOfDay);
            parameters.Level = Random.Next(1, 21);

            return parameters;
        }

        private class EncounterGeneratorParameters
        {
            public string Environment { get; set; }
            public string Temperature { get; set; }
            public string TimeOfDay { get; set; }
            public int Level { get; set; }
        }

        private string GetRandomFrom(IEnumerable<string> collection)
        {
            var total = collection.Count();
            var randomIndex = Random.Next(total);
            var randomValue = collection.ElementAt(randomIndex);

            return randomValue;
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
                Assert.That(creature.Description, Is.Not.Null);
            }
        }

        [TestCase(EnvironmentConstants.Dungeon, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Dungeon, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Dungeon, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Dungeon, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Dungeon, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Dungeon, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        public void StressEnvironment(string environment, string timeOfDay, string temperature)
        {
            Stress(() => AssertEncounterInEnvironment(environment, temperature, timeOfDay));
        }

        private void AssertEncounterInRandomEnvironment(params string[] filters)
        {
            var encounter = MakeEncounterInRandomEnvironment(filters);
            AssertEncounter(encounter);
        }

        private void AssertEncounterInEnvironment(string environment, string temperature, string timeOfDay, params string[] filters)
        {
            var level = Generate(() => Random.Next(1, 21), lvl => FilterVerifier.FiltersAreValid(environment, lvl, temperature, timeOfDay, filters));
            AssertEncounterInSpecificEnvironment(environment, temperature, timeOfDay, level, filters);
        }

        private void AssertEncounterInSpecificEnvironment(string environment, string temperature, string timeOfDay, int level, params string[] filters)
        {
            var encounter = EncounterGenerator.Generate(environment, level, temperature, timeOfDay, filters);
            AssertEncounter(encounter);
        }

        [Test]
        public void TreasureDoesNotHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Treasure.Coin.Quantity == 0 && e.Treasure.Goods.Any() == false && e.Treasure.Items.Any() == false);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(encounter.Treasure.Goods, Is.Empty);
            Assert.That(encounter.Treasure.Items, Is.Empty);
        }

        [Test]
        public void TreasureHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Treasure.Coin.Quantity > 0 || e.Treasure.Goods.Any() || e.Treasure.Items.Any());
            Assert.That(encounter.Treasure.Coin.Quantity > 0 || encounter.Treasure.Goods.Any() || encounter.Treasure.Items.Any(), Is.True);
        }

        [Test]
        public void CoinHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Treasure.Coin.Quantity > 0);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.Positive);
            Assert.That(encounter.Treasure.Coin.Currency, Is.Not.Empty);
        }

        [Test]
        public void GoodsHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Treasure.Goods.Any());
            Assert.That(encounter.Treasure.Goods, Is.Not.Empty);
        }

        [Test]
        public void ItemsHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Treasure.Items.Any());
            Assert.That(encounter.Treasure.Items, Is.Not.Empty);
        }

        [Test]
        public void CharactersHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Characters.Any());
            Assert.That(encounter.Characters, Is.Not.Empty);
        }

        [Test]
        public void CharactersDoNotHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Characters.Any() == false);
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SingleCreatureHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Creatures.Count() == 1);
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(1));
        }

        [Test]
        public void MultipleCreaturesHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Creatures.Count() > 1);
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
            Stress(() => AssertEncounterInRandomEnvironment(filter));
        }

        [Test]
        public void CharactersOccurAMinorityOfTheTime()
        {
            var charactersOccurred = new List<bool>();
            Stress(() => StressCharacterPercentage(charactersOccurred));

            var percentage = charactersOccurred.Count(o => o) / (double)charactersOccurred.Count;
            Assert.That(percentage, Is.LessThan(.5), $"{charactersOccurred.Count} encounters total");
        }

        private void StressCharacterPercentage(List<bool> charactersOccurred)
        {
            var encounter = MakeEncounterInRandomEnvironment();
            var charactersHappened = encounter.Characters.Any();
            charactersOccurred.Add(charactersHappened);
        }
    }
}
