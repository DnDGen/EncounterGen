using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public abstract class EncounterGroupsTableTests : CollectionTests
    {
        protected override string tableName => TableNameConstants.EncounterGroups;

        protected void AssertEncounterGroupNamesAreComplete()
        {
            var names = new[]
            {
                string.Empty,
                GroupConstants.All,
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
                EnvironmentConstants.TimesOfDay.Day,
                EnvironmentConstants.TimesOfDay.Night,
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
                GroupConstants.Wilderness,
            };

            AssertNamesAreComplete(names);
        }
    }
}
