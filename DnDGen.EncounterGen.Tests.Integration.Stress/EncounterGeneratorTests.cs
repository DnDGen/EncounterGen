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
        private IEncounterVerifier encounterVerifier;

        private const int PresetLevel = 7;

        private HashSet<string> testedFilters;

        [SetUp]
        public void Setup()
        {
            testedFilters = new HashSet<string>();
            encounterGenerator = GetNewInstanceOf<IEncounterGenerator>();
            encounterVerifier = GetNewInstanceOf<IEncounterVerifier>();
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

        [Test]
        public void BUG_StressCivilizedEncounter()
        {
            stressor.Stress(() => AssertEncounterInRandomEnvironment(EnvironmentConstants.Civilized, level: PresetLevel));
        }

        private void AssertEncounterInRandomEnvironment(string environment = "", string temperature = "", string timeOfDay = "", int level = 0, string filter = "", bool useFilter = false)
        {
            var encounter = MakeEncounterInRandomEnvironment(level, environment, temperature, timeOfDay, filter, useFilter);
            AssertEncounter(encounter);
        }

        private Encounter MakeEncounterInRandomEnvironment(int level = 0, string environment = "", string temperature = "", string timeOfDay = "", string filter = "", bool useFilter = false)
        {
            var specifications = stressor.Generate(
                () => RandomizeSpecifications(level, environment, temperature, timeOfDay, filter, useFilter),
                s => encounterVerifier.ValidEncounterExistsAtLevel(s));

            if (specifications.CreatureTypeFilters.Any())
                testedFilters.Add(specifications.CreatureTypeFilters.Single());

            return encounterGenerator.Generate(specifications);
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

        [Test]
        public void TreasureDoesNotHappen()
        {
            var encounter = stressor.GenerateOrFail(() => MakeEncounterInRandomEnvironment(PresetLevel), e => !e.Treasures.Any());
            AssertEncounter(encounter);
            Assert.That(encounter.Treasures, Is.Empty);
        }

        [Test]
        public void TreasureHappens()
        {
            var encounter = stressor.GenerateOrFail(() => MakeEncounterInRandomEnvironment(PresetLevel), e => e.Treasures.Any());
            AssertEncounter(encounter);
            Assert.That(encounter.Treasures, Is.Not.Empty);
        }

        [Test]
        public void CharactersHappen()
        {
            var encounter = stressor.GenerateOrFail(() => MakeEncounterInRandomEnvironment(PresetLevel), e => e.Characters.Any());
            AssertEncounter(encounter);
            Assert.That(encounter.Characters, Is.Not.Empty);
        }

        [Test]
        public void CharactersDoNotHappen()
        {
            var encounter = stressor.GenerateOrFail(() => MakeEncounterInRandomEnvironment(PresetLevel), e => e.Characters.Any() == false);
            AssertEncounter(encounter);
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SingleCreatureHappens()
        {
            var encounter = stressor.GenerateOrFail(() => MakeEncounterInRandomEnvironment(PresetLevel), e => e.Creatures.Count() == 1);
            AssertEncounter(encounter);
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(1));
        }

        [Test]
        public void MultipleCreaturesHappen()
        {
            var encounter = stressor.GenerateOrFail(() => MakeEncounterInRandomEnvironment(PresetLevel), e => e.Creatures.Count() > 1);
            AssertEncounter(encounter);
            Assert.That(encounter.Creatures.Count(), Is.GreaterThan(1));
        }
    }
}
