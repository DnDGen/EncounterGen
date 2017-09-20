using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public class CrossEncounterGroupsTests : EncounterGroupsTests
    {
        [Inject]
        public IEncounterVerifier EncounterVerifier { get; set; }

        [Test]
        public override void EntriesAreComplete()
        {
            AssertEncounterGroupEntriesAreComplete();
        }

        private IEnumerable<string> GetTimesOfDayEncounters()
        {
            var dayEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.TimesOfDay.Day);
            var nightEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.TimesOfDay.Night);

            return dayEncounters.Union(nightEncounters);
        }

        private IEnumerable<string> GetUnfilteredEncounters()
        {
            var allEncounters = new List<string>();

            var categories = new[] {
                EnvironmentConstants.Aquatic,
                EnvironmentConstants.Underground,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Underground,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Underground,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Underground,
                GroupConstants.Land,
                GroupConstants.Magic,
                GroupConstants.Wilderness,
            };

            foreach (var category in categories)
            {
                var categoryEncounters = GetEncountersFromCreatureGroup(category);
                allEncounters.AddRange(categoryEncounters);
            }

            return allEncounters;
        }

        [Test]
        public void AllTimeOfDayEncountersArePresentInOtherCategories()
        {
            var allTimesOfDayEncounters = GetTimesOfDayEncounters();
            var nonTimeOfDayEncounters = GetUnfilteredEncounters();
            AssertContainedCollection(allTimesOfDayEncounters, nonTimeOfDayEncounters);
        }

        [Test]
        public void AllCreaturesFromEncountersHaveType()
        {
            var types = new[]
            {
                CreatureConstants.Types.Aberration,
                CreatureConstants.Types.Animal,
                CreatureConstants.Types.Construct,
                CreatureConstants.Types.Dragon,
                CreatureConstants.Types.Elemental,
                CreatureConstants.Types.Fey,
                CreatureConstants.Types.Giant,
                CreatureConstants.Types.Humanoid,
                CreatureConstants.Types.MagicalBeast,
                CreatureConstants.Types.MonstrousHumanoid,
                CreatureConstants.Types.Ooze,
                CreatureConstants.Types.Outsider,
                CreatureConstants.Types.Plant,
                CreatureConstants.Types.Undead,
                CreatureConstants.Types.Vermin,
            };

            var excludedCreatures = new[] {
                CreatureConstants.DominatedCreature,
                CreatureConstants.DominatedCreature_CR1,
                CreatureConstants.DominatedCreature_CR10,
                CreatureConstants.DominatedCreature_CR11,
                CreatureConstants.DominatedCreature_CR12,
                CreatureConstants.DominatedCreature_CR13,
                CreatureConstants.DominatedCreature_CR14,
                CreatureConstants.DominatedCreature_CR15,
                CreatureConstants.DominatedCreature_CR16,
                CreatureConstants.DominatedCreature_CR2,
                CreatureConstants.DominatedCreature_CR3,
                CreatureConstants.DominatedCreature_CR4,
                CreatureConstants.DominatedCreature_CR5,
                CreatureConstants.DominatedCreature_CR6,
                CreatureConstants.DominatedCreature_CR7,
                CreatureConstants.DominatedCreature_CR8,
                CreatureConstants.DominatedCreature_CR9,
                CreatureConstants.Noncombatant,
            };

            var allCreatures = GetAllCreaturesFromEncounters();
            allCreatures = allCreatures.Except(excludedCreatures);

            var creaturesWithType = allCreatures.Where(c => EncounterVerifier.CreatureIsValid(c, types));
            AssertWholeCollection(allCreatures, creaturesWithType);
        }

        [TestCase(EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Underground)]
        [TestCase(GroupConstants.Land)]
        [TestCase(GroupConstants.Magic)]
        [TestCase(GroupConstants.Wilderness)]
        public void BUG_NoEncountersHaveMultipleEntriesOfSameCreature(string category)
        {
            var encounters = GetEncountersFromCreatureGroup(category);

            foreach (var encounter in encounters)
            {
                var creatures = EncounterFormatter.SelectCreaturesAndAmountsFrom(encounter).Keys;
                Assert.That(creatures, Is.Unique, encounter);
            }
        }

        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 1)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 2)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 20)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 1)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 2)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 20)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 1)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 2)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 20)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 1)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 2)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 20)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 1)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 2)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 20)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 1)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 2)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 20)]
        public void BUG_CivilizedUndeadAreRare(string temperature, string timeOfDay, int level)
        {
            var percentage = GetPercentage(EnvironmentConstants.Civilized, temperature, timeOfDay, level, IsUndead);
            Assert.That(percentage, Is.LessThanOrEqualTo(.15));
        }

        private bool IsUndead(string creature)
        {
            var undead = CollectionSelector.Explode(TableNameConstants.CreatureGroups, CreatureConstants.Types.Undead);
            return undead.Contains(creature);
        }

        private double GetPercentage(string environment, string temperature, string timeOfDay, int level, Func<string, bool> isInSubgroup)
        {
            var specifications = new EncounterSpecifications();
            specifications.Environment = environment;
            specifications.Level = level;
            specifications.Temperature = temperature;
            specifications.TimeOfDay = timeOfDay;

            var encounters = EncounterCollectionSelector.SelectAllWeightedFrom(specifications);
            var leadCreatures = encounters.Select(e => e.First().Key);

            var subgroupCreatures = leadCreatures.Where(cr => isInSubgroup(cr));
            var percentage = subgroupCreatures.Count() / (double)leadCreatures.Count();

            //INFO: These assertions verify that we are working with a valid, weighted collection
            Assert.That(encounters, Is.Not.Unique);
            Assert.That(leadCreatures, Is.Not.Unique);

            AssertEventSpacing();

            Console.WriteLine($"Actual percentage for {specifications.Description} is {{0:P}}", percentage);

            return percentage;
        }

        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, 20)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, 20)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, 20)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, 20)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, 20)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 3)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 4)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 5)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 6)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 7)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 8)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 9)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 10)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 11)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 12)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 13)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 14)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 15)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 16)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 17)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 18)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 19)]
        [TestCase(EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, 20)]
        public void BUG_CivilizedUndeadCharactersExist(string temperature, string timeOfDay, int level)
        {
            var percentage = GetPercentage(EnvironmentConstants.Civilized, temperature, timeOfDay, level, IsUndeadCharacter);
            Assert.That(percentage, Is.Positive);
        }

        private bool IsUndeadCharacter(string creature)
        {
            var name = EncounterFormatter.SelectNameFrom(creature);
            return IsUndead(creature) && name == CreatureConstants.Character;
        }
    }
}
