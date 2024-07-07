using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors.Collections;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public class CrossEncounterGroupsTests : EncounterGroupsTableTests
    {
        private IEncounterVerifier encounterVerifier;
        private IEncounterCollectionSelector encounterCollectionSelector;

        [SetUp]
        public void Setup()
        {
            encounterVerifier = GetNewInstanceOf<IEncounterVerifier>();
            encounterCollectionSelector = GetNewInstanceOf<IEncounterCollectionSelector>();
        }

        [Test]
        public override void EntriesAreComplete()
        {
            AssertEncounterGroupNamesAreComplete();
        }

        [Test]
        public void AllEncountersAreInTimesOfDay()
        {
            var allEncounters = EncounterConstants.GetAll();
            var timesOfDay = new[] { EnvironmentConstants.TimesOfDay.Day, EnvironmentConstants.TimesOfDay.Night };
            var timesOfDayEncounters = timesOfDay.SelectMany(t => table[t]).Distinct();
            Assert.That(timesOfDayEncounters, Is.EquivalentTo(allEncounters));
        }

        [Test]
        public void AllEncountersAreInEnvironments()
        {
            var allEncounters = EncounterConstants.GetAll();
            var environments = new[]
            {
                EnvironmentConstants.Aquatic,
                EnvironmentConstants.Underground,
                EnvironmentConstants.Any,
                EnvironmentConstants.Land,
                EnvironmentConstants.Civilized,
                EnvironmentConstants.Underground + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Underground,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Underground,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Underground,
                EnvironmentConstants.Plane_Air,
                EnvironmentConstants.Plane_Astral,
                EnvironmentConstants.Plane_Chaotic,
                EnvironmentConstants.Plane_ChaoticEvil,
                EnvironmentConstants.Plane_ChaoticGood,
                EnvironmentConstants.Plane_Earth,
                EnvironmentConstants.Plane_Ethereal,
                EnvironmentConstants.Plane_Evil,
                EnvironmentConstants.Plane_Fire,
                EnvironmentConstants.Plane_Good,
                EnvironmentConstants.Plane_Lawful,
                EnvironmentConstants.Plane_LawfulEvil,
                EnvironmentConstants.Plane_LawfulGood,
                EnvironmentConstants.Plane_Limbo,
                EnvironmentConstants.Plane_NeutralEvil,
                EnvironmentConstants.Plane_PositiveEnergy,
                EnvironmentConstants.Plane_Shadow,
                EnvironmentConstants.Plane_Water,
                GroupConstants.Extraplanar,
            };

            var environmentEncounters = environments.SelectMany(e => table[e]).Distinct();
            Assert.That(environmentEncounters, Is.EquivalentTo(allEncounters));
        }

        [Test]
        public void AllCreaturesFromEncountersHaveType()
        {
            var types = new[]
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

            var excludedCreatures = new[] {
                CreatureDataConstants.DominatedCreature,
                CreatureDataConstants.DominatedCreature_CR1,
                CreatureDataConstants.DominatedCreature_CR10,
                CreatureDataConstants.DominatedCreature_CR11,
                CreatureDataConstants.DominatedCreature_CR12,
                CreatureDataConstants.DominatedCreature_CR13,
                CreatureDataConstants.DominatedCreature_CR14,
                CreatureDataConstants.DominatedCreature_CR15,
                CreatureDataConstants.DominatedCreature_CR16,
                CreatureDataConstants.DominatedCreature_CR2,
                CreatureDataConstants.DominatedCreature_CR3,
                CreatureDataConstants.DominatedCreature_CR4,
                CreatureDataConstants.DominatedCreature_CR5,
                CreatureDataConstants.DominatedCreature_CR6,
                CreatureDataConstants.DominatedCreature_CR7,
                CreatureDataConstants.DominatedCreature_CR8,
                CreatureDataConstants.DominatedCreature_CR9,
                CreatureDataConstants.Noncombatant,
            };

            var allCreatures = GetAllCreaturesFromEncounters();
            allCreatures = allCreatures.Except(excludedCreatures);

            var creaturesWithType = allCreatures.Where(c => encounterVerifier.CreatureIsValid(c, types));
            AssertCollection(allCreatures, creaturesWithType);
        }
    }
}
