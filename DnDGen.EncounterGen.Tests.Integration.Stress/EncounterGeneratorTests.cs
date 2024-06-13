using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Stress
{
    [TestFixture]
    public class EncounterGeneratorTests : StressTests
    {
        private IEncounterGenerator encounterGenerator;
        private HashSet<string> testedFilters;

        [SetUp]
        public void Setup()
        {
            testedFilters = new HashSet<string>();
            encounterGenerator = GetNewInstanceOf<IEncounterGenerator>();
        }

        [Test]
        public void StressEncounterGenerator()
        {
            stressor.Stress(() => AssertEncounterInRandomEnvironment());
        }

        [Test]
        public void StressEncounterGeneratorWithFilter()
        {
            stressor.Stress(() => AssertEncounterInRandomEnvironment(useFilter: true));

            Console.WriteLine($"Stressed the following filters: {string.Join(", ", testedFilters.OrderBy(f => f))}");

            var untestedFilters = allFilters.Except(testedFilters);
            Console.WriteLine($"Did not stress the following filters: {string.Join(", ", untestedFilters.OrderBy(f => f))}");
        }

        private void AssertEncounterInRandomEnvironment(string environment = "", string temperature = "", string timeOfDay = "", int level = 0, string filter = "", bool useFilter = false)
        {
            var encounter = MakeEncounterInRandomEnvironment(level, environment, temperature, timeOfDay, filter, useFilter);
            AssertEncounter(encounter);
        }

        private Encounter MakeEncounterInRandomEnvironment(int level = 0, string environment = "", string temperature = "", string timeOfDay = "", string filter = "", bool useFilter = false)
        {
            var specifications = RandomizeSpecifications(level, environment, temperature, timeOfDay, filter, useFilter);

            if (specifications.CreatureTypeFilters.Any())
                testedFilters.Add(specifications.CreatureTypeFilters.Single());

            return encounterGenerator.Generate(specifications);
        }

        private void AssertEncounter(Encounter encounter)
        {
            Assert.That(encounter.Description, Is.Not.Empty);
            Assert.That(encounter.Creatures, Is.Not.Empty, encounter.Description);
            Assert.That(encounter.Creatures, Is.All.Not.Null, encounter.Description);
            Assert.That(encounter.Characters, Is.Not.Null, encounter.Description);
            Assert.That(encounter.Characters, Is.All.Not.Null, encounter.Description);

            foreach (var creature in encounter.Creatures)
            {
                AssertCreature(creature.Creature);
                Assert.That(creature.Quantity, Is.Positive, creature.Creature.Name);
                Assert.That(creature.ChallengeRating, Is.Not.Empty, creature.Creature.Name);
            }

            Assert.That(encounter.Treasures, Is.Not.Null, encounter.Description);
            Assert.That(encounter.Treasures, Is.All.Not.Null, encounter.Description);
            Assert.That(encounter.Treasures.Select(t => t.IsAny), Is.All.True, encounter.Description);

            var totalCreatures = encounter.Creatures.Sum(c => c.Quantity);
            Assert.That(encounter.Characters.Count, Is.LessThanOrEqualTo(totalCreatures), encounter.Description);
            Assert.That(encounter.Treasures.Count, Is.LessThanOrEqualTo(encounter.Creatures.Count()), encounter.Description);

            Assert.That(encounter.TargetEncounterLevel, Is.Positive, encounter.Description);
            Assert.That(encounter.AverageEncounterLevel, Is.Positive, encounter.Description);
            Assert.That(encounter.ActualEncounterLevel, Is.Positive, encounter.Description);

            Assert.That(encounter.AverageDifficulty, Is.Not.Empty, encounter.Description);
            Assert.That(encounter.ActualDifficulty, Is.Not.Empty, encounter.Description);
        }

        private void AssertCreature(Creature creature)
        {
            Assert.That(creature.Name, Is.Not.Empty);
            Assert.That(creature.Description, Is.Not.Null, creature.Name);

            Assert.That(dice.ContainsRoll(creature.Name), Is.False, creature.Name);
            Assert.That(dice.ContainsRoll(creature.Description), Is.False, creature.Name);

            if (creature.SubCreature != null)
                AssertCreature(creature.SubCreature);
        }

        [Test]
        public void BUG_StressEncounterInProblematicEnvironment()
        {
            stressor.Stress(TestProblemEnvironments);
        }

        private void TestProblemEnvironments()
        {
            var problemEnvironments = new (string Env, string Temp, string Time, int Level)[]
            {
                (EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 7),
                (EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 1),
                (EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 1),
            };

            var problemEnvironment = collectionSelector.SelectRandomFrom(problemEnvironments);

            AssertEncounterInRandomEnvironment(problemEnvironment.Env, problemEnvironment.Temp, problemEnvironment.Time, problemEnvironment.Level);
        }
    }
}
