using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using DnDGen.EncounterGen.Generators;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
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
            AssertEventSpacing();

            var leadCreatures = encounters.Select(e => e.First().Key);
            var subgroupCreatures = leadCreatures.Where(cr => isInSubgroup(cr));
            var percentage = subgroupCreatures.Count() / (double)leadCreatures.Count();

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

        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, EnvironmentConstants.Temperatures.Warm)]
        public void BUG_MagicIsNotMajorityOfEncounters(string environment, string timeOfDay, string temperature)
        {
            var levels = Enumerable.Range(1, 20);
            foreach (var level in levels)
            {
                var percentageWithCouatl = GetPercentage(environment, temperature, timeOfDay, level, IsMagicCreature);
                var percentageWithoutCouatl = GetPercentage(environment, temperature, timeOfDay, level, IsMagicCreatureAndNotCouatl);
                var percentage = Math.Min(percentageWithCouatl, percentageWithoutCouatl);

                if (percentageWithCouatl == 1 || percentageWithoutCouatl == 1)
                    percentage = 1;

                Assert.That(percentage, Is.LessThan(.5).Or.EqualTo(1), $"Level {level}");
            }
        }

        private bool IsMagicCreature(string creature)
        {
            var magicCreatures = CollectionSelector.Explode(TableNameConstants.CreatureGroups, GroupConstants.Magic);

            return magicCreatures.Contains(creature);
        }

        private bool IsMagicCreatureAndNotCouatl(string creature)
        {
            return IsMagicCreature(creature) && creature != CreatureConstants.Couatl;
        }
    }
}
