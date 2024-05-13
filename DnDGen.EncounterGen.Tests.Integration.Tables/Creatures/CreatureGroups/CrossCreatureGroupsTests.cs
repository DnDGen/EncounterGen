using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class CrossCreatureGroupsTests : CreatureGroupsTableTests
    {
        private IEncounterVerifier encounterVerifier;

        [SetUp]
        public void Setup()
        {
            encounterVerifier = GetNewInstanceOf<IEncounterVerifier>();
        }

        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [TestCase(EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Land)]
        [TestCase(EnvironmentConstants.Any)]
        [TestCase(EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(GroupConstants.Wilderness)]
        public void AllCreaturesArePresentInAtLeastOneTimeOfDay(string source)
        {
            var sourceCreatures = ExplodeCollection(source);
            var allTimesOfDayCreatures = GetTimesOfDayCreatures();
            AssertContainedCollection(sourceCreatures, allTimesOfDayCreatures);
        }

        [TestCase(EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Land)]
        [TestCase(EnvironmentConstants.Any)]
        [TestCase(EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Underground)]
        [TestCase(GroupConstants.Wilderness)]
        public void AllCreaturesHaveType(string source)
        {
            var sourceCreatures = ExplodeCollection(source);
            var allTypes = new[]
            {
                CreatureDataConstants.Types.Aberration,
                CreatureDataConstants.Types.Animal,
                CreatureDataConstants.Types.Construct,
                CreatureDataConstants.Types.Dragon,
                CreatureDataConstants.Types.Elemental,
                CreatureDataConstants.Types.Fey,
                CreatureDataConstants.Types.Giant,
                CreatureDataConstants.Types.Humanoid,
                CreatureDataConstants.Types.MagicalBeast,
                CreatureDataConstants.Types.MonstrousHumanoid,
                CreatureDataConstants.Types.Ooze,
                CreatureDataConstants.Types.Outsider,
                CreatureDataConstants.Types.Plant,
                CreatureDataConstants.Types.Undead,
                CreatureDataConstants.Types.Vermin,
            };

            var excludedCreatures = new[] { CreatureDataConstants.DominatedCreature, CreatureDataConstants.Noncombatant };
            var explodedExcludedCreatures = ExplodeCollections(excludedCreatures);
            var creatures = sourceCreatures.Except(explodedExcludedCreatures);

            var creaturesWithoutType = creatures.Where(c => encounterVerifier.CreatureIsValid(c, allTypes) == false);
            Assert.That(creaturesWithoutType, Is.Empty, "Creatures not in a type category");
        }

        private IEnumerable<string> GetTimesOfDayCreatures()
        {
            var dayCreatures = ExplodeCollection(EnvironmentConstants.TimesOfDay.Day);
            var nightCreatures = ExplodeCollection(EnvironmentConstants.TimesOfDay.Night);

            return dayCreatures.Union(nightCreatures);
        }

        [Test]
        public void NoMissingCreaturesFromDominatedCreatureGroup()
        {
            var allCreatures = GetAllCreatures();
            var creatureTemplates = new[]
            {
                CreatureDataConstants.DominatedCreature_CR1,
                CreatureDataConstants.DominatedCreature_CR2,
                CreatureDataConstants.DominatedCreature_CR3,
                CreatureDataConstants.DominatedCreature_CR4,
                CreatureDataConstants.DominatedCreature_CR5,
                CreatureDataConstants.DominatedCreature_CR6,
                CreatureDataConstants.DominatedCreature_CR7,
                CreatureDataConstants.DominatedCreature_CR8,
                CreatureDataConstants.DominatedCreature_CR9,
                CreatureDataConstants.DominatedCreature_CR10,
                CreatureDataConstants.DominatedCreature_CR11,
                CreatureDataConstants.DominatedCreature_CR12,
                CreatureDataConstants.DominatedCreature_CR13,
                CreatureDataConstants.DominatedCreature_CR14,
                CreatureDataConstants.DominatedCreature_CR15,
                CreatureDataConstants.DominatedCreature_CR16,
                CreatureDataConstants.Mephit_CR3,
            };

            var constructs = ExplodeCollection(CreatureDataConstants.Types.Construct);
            var oozes = ExplodeCollection(CreatureDataConstants.Types.Ooze);
            var plants = ExplodeCollection(CreatureDataConstants.Types.Plant);
            var undead = ExplodeCollection(CreatureDataConstants.Types.Undead);

            var creaturesWithBrains = allCreatures
                .Except(creatureTemplates)
                .Except(constructs)
                .Except(oozes)
                .Except(plants)
                .Except(undead);

            var dominatedCreatures = ExplodeCollection(CreatureDataConstants.DominatedCreature);
            AssertWholeCollection(creaturesWithBrains, dominatedCreatures);
        }

        [TestCase(CreatureDataConstants.Types.Construct)]
        [TestCase(CreatureDataConstants.Types.Ooze)]
        [TestCase(CreatureDataConstants.Types.Plant)]
        [TestCase(CreatureDataConstants.Types.Undead)]
        public void CreatureTypeCannotBeDominated(string creatureType)
        {
            var creatures = ExplodeCollection(creatureType);
            var dominatedCreatues = ExplodeCollection(CreatureDataConstants.DominatedCreature);
            Assert.That(creatures.Intersect(dominatedCreatues), Is.Empty);
        }

        [Test]
        public void NoCircularSubgroups()
        {
            var table = collectionMapper.Map(tableName);

            foreach (var kvp in table)
            {
                AssertGroupDoesNotContain(kvp.Key, kvp.Key);
            }
        }

        private void AssertGroupDoesNotContain(string name, string forbiddenEntry)
        {
            var table = collectionMapper.Map(tableName);
            var group = table[name];

            if (name != forbiddenEntry)
                Assert.That(group, Does.Not.Contain(forbiddenEntry));

            var subgroupNames = group.Intersect(table.Keys);

            foreach (var subgroupName in subgroupNames)
            {
                //INFO: This is so groups can contain themselves (such as Ape containing Ape and Dire ape)
                if (subgroupName == name)
                    continue;

                AssertGroupDoesNotContain(subgroupName, forbiddenEntry);
                AssertGroupDoesNotContain(subgroupName, subgroupName);
            }
        }
    }
}
