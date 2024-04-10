using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using DnDGen.EncounterGen.Generators;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class CrossCreatureGroupsTests : CreatureGroupsTableTests
    {
        [Inject]
        public IEncounterVerifier EncounterVerifier { get; set; }

        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [TestCase(EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Underground)]
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
        [TestCase(GroupConstants.Magic)]
        [TestCase(GroupConstants.Land)]
        [TestCase(GroupConstants.Wilderness)]
        public void AllCreaturesArePresentInAtLeastOneTimeOfDay(string source)
        {
            var sourceCreatures = ExplodeCollection(source);
            var allTimesOfDayCreatures = GetTimesOfDayCreatures();
            AssertContainedCollection(sourceCreatures, allTimesOfDayCreatures);
        }

        [TestCase(EnvironmentConstants.Aquatic)]
        [TestCase(EnvironmentConstants.Underground)]
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
        [TestCase(GroupConstants.Magic)]
        [TestCase(GroupConstants.Land)]
        [TestCase(GroupConstants.Wilderness)]
        public void AllCreaturesHaveType(string source)
        {
            var sourceCreatures = ExplodeCollection(source);
            var allTypes = new[]
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

            var excludedCreatures = new[] { CreatureConstants.DominatedCreature, CreatureConstants.Noncombatant };
            var explodedExcludedCreatures = ExplodeCollections(excludedCreatures);
            var creatures = sourceCreatures.Except(explodedExcludedCreatures);

            var creaturesWithoutType = creatures.Where(c => EncounterVerifier.CreatureIsValid(c, allTypes) == false);
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
                CreatureConstants.DominatedCreature_CR1,
                CreatureConstants.DominatedCreature_CR2,
                CreatureConstants.DominatedCreature_CR3,
                CreatureConstants.DominatedCreature_CR4,
                CreatureConstants.DominatedCreature_CR5,
                CreatureConstants.DominatedCreature_CR6,
                CreatureConstants.DominatedCreature_CR7,
                CreatureConstants.DominatedCreature_CR8,
                CreatureConstants.DominatedCreature_CR9,
                CreatureConstants.DominatedCreature_CR10,
                CreatureConstants.DominatedCreature_CR11,
                CreatureConstants.DominatedCreature_CR12,
                CreatureConstants.DominatedCreature_CR13,
                CreatureConstants.DominatedCreature_CR14,
                CreatureConstants.DominatedCreature_CR15,
                CreatureConstants.DominatedCreature_CR16,
                CreatureConstants.Mephit_CR3,
            };

            var constructs = ExplodeCollection(CreatureConstants.Types.Construct);
            var oozes = ExplodeCollection(CreatureConstants.Types.Ooze);
            var plants = ExplodeCollection(CreatureConstants.Types.Plant);
            var undead = ExplodeCollection(CreatureConstants.Types.Undead);

            var creaturesWithBrains = allCreatures
                .Except(creatureTemplates)
                .Except(constructs)
                .Except(oozes)
                .Except(plants)
                .Except(undead);

            var dominatedCreatures = ExplodeCollection(CreatureConstants.DominatedCreature);
            AssertWholeCollection(creaturesWithBrains, dominatedCreatures);
        }

        [TestCase(CreatureConstants.Types.Construct)]
        [TestCase(CreatureConstants.Types.Ooze)]
        [TestCase(CreatureConstants.Types.Plant)]
        [TestCase(CreatureConstants.Types.Undead)]
        public void SubtypeCannotBeDominated(string subtype)
        {
            var subtypeCreatures = ExplodeCollection(subtype);
            var dominatedCreatues = ExplodeCollection(CreatureConstants.DominatedCreature);
            Assert.That(subtypeCreatures.Intersect(dominatedCreatues), Is.Empty);
        }

        [Test]
        public void NoCircularSubgroups()
        {
            var table = CollectionMapper.Map(tableName);

            foreach (var kvp in table)
            {
                AssertGroupDoesNotContain(kvp.Key, kvp.Key);
            }
        }

        private void AssertGroupDoesNotContain(string name, string forbiddenEntry)
        {
            var table = CollectionMapper.Map(tableName);
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
