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

        private Encounter MakeEncounterInRandomEnvironment(int level = 0, string environment = "", string temperature = "", string timeOfDay = "", params string[] filters)
        {
            var parameters = Generate(
                () => RandomizeParameters(level, environment, temperature, timeOfDay),
                p => FilterVerifier.FiltersAreValid(p.Environment, p.Level, p.Temperature, p.TimeOfDay, filters));

            return EncounterGenerator.Generate(parameters.Environment, parameters.Level, parameters.Temperature, parameters.TimeOfDay, filters);
        }

        private EncounterGeneratorParameters RandomizeParameters(int level = 0, string environment = "", string temperature = "", string timeOfDay = "")
        {
            var parameters = new EncounterGeneratorParameters();
            parameters.Environment = string.IsNullOrEmpty(environment) ? GetRandomFrom(allEnvironments) : environment;
            parameters.Temperature = string.IsNullOrEmpty(temperature) ? GetRandomFrom(allTemperatures) : temperature;
            parameters.TimeOfDay = string.IsNullOrEmpty(timeOfDay) ? GetRandomFrom(allTimesOfDay) : timeOfDay;
            parameters.Level = level > 0 ? level : Random.Next(20) + 1;

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
            Assert.That(encounter.Characters, Is.Not.Null);
            Assert.That(encounter.Characters, Is.All.Not.Null);

            foreach (var creature in encounter.Creatures)
            {
                Assert.That(creature.Name, Is.Not.Empty);
                Assert.That(creature.Quantity, Is.Positive);
                Assert.That(creature.Description, Is.Not.Null);
            }

            Assert.That(encounter.Treasures, Is.Not.Null);
            Assert.That(encounter.Treasures, Is.All.Not.Null);
            Assert.That(encounter.Treasures.Select(t => t.IsAny), Is.All.True);

            var totalCreatures = encounter.Creatures.Sum(c => c.Quantity);
            Assert.That(encounter.Characters.Count, Is.LessThanOrEqualTo(totalCreatures));
            Assert.That(encounter.Treasures.Count, Is.LessThanOrEqualTo(encounter.Creatures.Count()));
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
            Stress(() => AssertEncounterInRandomEnvironment(environment, temperature, timeOfDay));
        }

        private void AssertEncounterInRandomEnvironment(string environment = "", string temperature = "", string timeOfDay = "", int level = 0, params string[] filters)
        {
            var encounter = MakeEncounterInRandomEnvironment(level, environment, temperature, timeOfDay, filters);
            AssertEncounter(encounter);
        }

        [TestCase(1)]
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
        public void StressEncounterLevel(int level)
        {
            Stress(() => AssertEncounterInRandomEnvironment(level: level));
        }

        [Test]
        public void TreasureDoesNotHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Treasures.Any() == false);
            AssertEncounter(encounter);
            Assert.That(encounter.Treasures, Is.Empty);
        }

        [Test]
        public void TreasureHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Treasures.Any());
            AssertEncounter(encounter);
            Assert.That(encounter.Treasures, Is.Not.Empty);
        }

        [Test]
        public void CoinHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Treasures.Any(t => t.Coin.Quantity > 0));
            AssertEncounter(encounter);

            var coinTreasure = encounter.Treasures.First(t => t.Coin.Quantity > 0);
            Assert.That(coinTreasure.Coin.Quantity, Is.Positive);
            Assert.That(coinTreasure.Coin.Currency, Is.Not.Empty);
        }

        [Test]
        public void GoodsHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Treasures.Any(t => t.Goods.Any()));
            AssertEncounter(encounter);

            var goodsTreasure = encounter.Treasures.First(t => t.Goods.Any());
            Assert.That(goodsTreasure.Goods, Is.Not.Empty);
        }

        [Test]
        public void ItemsHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Treasures.Any(t => t.Items.Any()));
            AssertEncounter(encounter);

            var itemsTreasure = encounter.Treasures.First(t => t.Items.Any());
            Assert.That(itemsTreasure.Items, Is.Not.Empty);
        }

        [Test]
        public void CharactersHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Characters.Any());
            AssertEncounter(encounter);
            Assert.That(encounter.Characters, Is.Not.Empty);
        }

        [Test]
        public void CharactersDoNotHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Characters.Any() == false);
            AssertEncounter(encounter);
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SingleCreatureHappens()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Creatures.Count() == 1);
            AssertEncounter(encounter);
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(1));
        }

        [Test]
        public void MultipleCreaturesHappen()
        {
            var encounter = GenerateOrFail(() => MakeEncounterInRandomEnvironment(), e => e.Creatures.Count() > 1);
            AssertEncounter(encounter);
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
            Stress(() => AssertEncounterInRandomEnvironment(filters: new[] { filter }));
        }

        [Test]
        public void CharactersOccurAMinorityOfTheTime()
        {
            StressPercentage(CharacterOccurred);
        }

        private void StressPercentage(Func<Encounter, bool> occurred)
        {
            var occurrances = new List<bool>();
            Stress(() => StressPercentage(occurrances, occurred));
            AssertPercentageIsMinority(occurrances);
        }

        private void AssertPercentageIsMinority(IEnumerable<bool> occurances)
        {
            var total = occurances.Count();
            var percentage = occurances.Count(o => o) / (double)total;

            Assert.That(percentage, Is.Positive, $"{total} encounters total");
            Assert.That(percentage, Is.LessThan(.5), $"{total} encounters total");

            Console.WriteLine("Actual percentage was {0:P}", percentage);
        }

        private void StressPercentage(List<bool> occurances, Func<Encounter, bool> occured)
        {
            var encounter = MakeEncounterInRandomEnvironment();
            AssertEncounter(encounter);

            var occuranceHappened = occured(encounter);
            occurances.Add(occuranceHappened);
        }

        private bool CharacterOccurred(Encounter encounter)
        {
            return encounter.Characters.Any();
        }

        [Test]
        public void DragonsOccurAMinorityOfTheTime()
        {
            StressPercentage(DragonOccured);
        }

        private bool DragonOccured(Encounter encounter)
        {
            return encounter.Creatures.First().Name.Contains("dragon");
        }

        [Test]
        public void DragonsAndCharactersOccurAMinorityOfTheTime()
        {
            StressPercentage(e => CharacterOccurred(e) || DragonOccured(e));
        }
    }
}
