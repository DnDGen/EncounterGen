using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class CrossCreatureGroupsTests : CreatureGroupsTests
    {
        [Inject]
        public IEncounterVerifier EncounterVerifier { get; set; }

        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [TestCase(EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Dungeon)]
        [TestCase(EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Hills)]
        [TestCase(EnvironmentConstants.Marsh)]
        [TestCase(EnvironmentConstants.Mountain)]
        [TestCase(EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Cold)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate)]
        [TestCase(EnvironmentConstants.Temperatures.Warm)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Dungeon)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Dungeon)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Dungeon)]
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
        [TestCase(GroupConstants.Magic)]
        [TestCase(GroupConstants.Land)]
        public void AllCreaturesArePresentInAtLeastOneTimeOfDay(string source)
        {
            var sourceCreatures = GetCollection(source);
            var allTimesOfDayCreatures = GetTimesOfDayCreatures();
            AssertContainedCollection(sourceCreatures, allTimesOfDayCreatures);
        }

        private IEnumerable<string> GetTimesOfDayCreatures()
        {
            var dayCreatures = GetCollection(EnvironmentConstants.TimesOfDay.Day);
            var nightCreatures = GetCollection(EnvironmentConstants.TimesOfDay.Night);

            return dayCreatures.Union(nightCreatures);
        }

        [Test]
        public void AllCreaturesHaveType()
        {
            var allCreatures = GetAllCollections();
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

            var excludedCreatures = new[] { CreatureConstants.DominatedCreature, "Noncombatant" };
            var creatures = allCreatures.Distinct().Except(excludedCreatures);

            var creaturesWithoutType = creatures.Where(c => EncounterVerifier.CreatureIsValid(c, types) == false);
            Assert.That(creaturesWithoutType, Is.Empty, "Creatures not in a type category");
        }

        [Test]
        public void AllCreaturesWithoutDescriptionHaveType()
        {
            var allCreatures = GetAllCollections();
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

            var excludedCreatures = new[] { CreatureConstants.DominatedCreature, "Noncombatant" };
            var creatures = allCreatures.Distinct().Select(c => GetCreature(c)).Except(excludedCreatures);

            var creaturesWithoutType = creatures.Where(c => EncounterVerifier.CreatureIsValid(c, types) == false);
            Assert.That(creaturesWithoutType, Is.Empty);
        }

        [Test]
        public void NoMissingCreaturesFromDominatedCreatureGroup()
        {
            var challengeRatings = CollectionMapper.Map(TableNameConstants.ChallengeRatings);
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
                CreatureConstants.Mephit_CR3
            };

            var constructs = GetCollection(CreatureConstants.Types.Construct);
            var oozes = GetCollection(CreatureConstants.Types.Ooze);
            var plants = GetCollection(CreatureConstants.Types.Plant);
            var undead = GetCollection(CreatureConstants.Types.Undead);

            var creaturesWithBrains = challengeRatings.Keys
                .Except(creatureTemplates)
                .Except(constructs)
                .Except(oozes)
                .Except(plants)
                .Except(undead);

            var dominatedCreatures = GetCollection(CreatureConstants.DominatedCreature);
            AssertContainedCollection(creaturesWithBrains, dominatedCreatures);
        }

        [TestCase(CreatureConstants.Types.Construct)]
        [TestCase(CreatureConstants.Types.Ooze)]
        [TestCase(CreatureConstants.Types.Plant)]
        [TestCase(CreatureConstants.Types.Undead)]
        public void SubtypeCannotBeDominated(string subtype)
        {
            var subtypeCreatures = GetCollection(subtype);
            var dominatedCreatues = GetCollection(CreatureConstants.DominatedCreature);
            Assert.That(subtypeCreatures.Intersect(dominatedCreatues), Is.Empty);
        }
    }
}
