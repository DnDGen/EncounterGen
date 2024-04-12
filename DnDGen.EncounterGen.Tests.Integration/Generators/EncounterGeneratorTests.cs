using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.RollGen;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Generators
{
    [TestFixture]
    internal class EncounterGeneratorTests : IntegrationTests
    {
        private IEncounterGenerator encounterGenerator;
        private Dice dice;

        [SetUp]
        public void Setup()
        {
            encounterGenerator = GetNewInstanceOf<IEncounterGenerator>();
            dice = GetNewInstanceOf<Dice>();
        }

        [TestCase(EnvironmentConstants.Civilized,
            EnvironmentConstants.Temperatures.Temperate,
            EnvironmentConstants.TimesOfDay.Night,
            7, false, true)]
        public void Generate_ReturnsEncounter(string environment, string temperature, string timeOfDay, int level, bool allowAquatic, bool allowUnderground)
        {
            var specifications = new EncounterSpecifications
            {
                Environment = environment,
                Temperature = temperature,
                TimeOfDay = timeOfDay,
                Level = level,
                AllowAquatic = allowAquatic,
                AllowUnderground = allowUnderground
            };

            var encounter = encounterGenerator.Generate(specifications);
            AssertEncounter(encounter);
        }

        private void AssertEncounter(Encounter encounter)
        {
            Assert.That(encounter.Creatures, Is.Not.Empty);
            Assert.That(encounter.Creatures, Is.All.Not.Null);
            Assert.That(encounter.Characters, Is.Not.Null);
            Assert.That(encounter.Characters, Is.All.Not.Null);

            foreach (var creature in encounter.Creatures)
            {
                AssertCreatureType(creature.Type);
                Assert.That(creature.Quantity, Is.Positive);
                Assert.That(creature.ChallengeRating, Is.Not.Empty);
            }

            Assert.That(encounter.Treasures, Is.Not.Null);
            Assert.That(encounter.Treasures, Is.All.Not.Null);
            Assert.That(encounter.Treasures.Select(t => t.IsAny), Is.All.True);

            var totalCreatures = encounter.Creatures.Sum(c => c.Quantity);
            Assert.That(encounter.Characters.Count, Is.LessThanOrEqualTo(totalCreatures));
            Assert.That(encounter.Treasures.Count, Is.LessThanOrEqualTo(encounter.Creatures.Count()));

            Assert.That(encounter.TargetEncounterLevel, Is.Positive);
            Assert.That(encounter.AverageEncounterLevel, Is.Positive);
            Assert.That(encounter.ActualEncounterLevel, Is.Positive);

            Assert.That(encounter.AverageDifficulty, Is.Not.Empty);
            Assert.That(encounter.ActualDifficulty, Is.Not.Empty);
        }

        private void AssertCreatureType(CreatureType creatureType)
        {
            Assert.That(creatureType.Name, Is.Not.Empty);
            Assert.That(creatureType.Description, Is.Not.Null);

            Assert.That(dice.ContainsRoll(creatureType.Name), Is.False);
            Assert.That(dice.ContainsRoll(creatureType.Description), Is.False);

            if (creatureType.SubType != null)
                AssertCreatureType(creatureType.SubType);
        }
    }
}
