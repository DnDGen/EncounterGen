using EncounterGen.Common;
using EncounterGen.Generators;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level1DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 1, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 3, CreatureConstants.Centipede_Monstrous_Medium, "1d3")]
        [TestCase(4, 8, CreatureConstants.Rat_Dire, "1d4")]
        [TestCase(9, 10, CreatureConstants.FireBeetle_Giant, "1d4")]
        [TestCase(11, 13, CreatureConstants.Scorpion_Monstrous_Small, "1d3")]
        [TestCase(14, 16, CreatureConstants.Spider_Monstrous_Small, "1d3")]
        [TestCase(17, 20, CreatureConstants.DwarfWarrior, "1d3")]
        [TestCase(21, 22, CreatureConstants.ElfWarrior, "1d3")]
        [TestCase(23, 25, CreatureConstants.Darkmantle, "1")]
        [TestCase(26, 28, CreatureConstants.Krenshar, "1")]
        [TestCase(29, 30, CreatureConstants.Lemure, "1")]
        [TestCase(31, 40, CreatureConstants.GoblinWarrior, "1d3+1")]
        [TestCase(41, 50, CreatureConstants.KoboldWarrior, "1d4+2")]
        [TestCase(51, 56, CreatureConstants.Skeleton_HumanWarrior, "1d4")]
        [TestCase(57, 62, CreatureConstants.Zombie_HumanCommoner, "1d3")]
        [TestCase(63, 71, CreatureConstants.Snake_Viper_Tiny, "1d4+1")]
        [TestCase(72, 80, CreatureConstants.OrcWarrior, "1d3")]
        [TestCase(81, 85, CreatureConstants.Stirge, "1d3")]
        [TestCase(86, 90, CreatureConstants.Swarm_Spider, "1")]
        [TestCase(91, 100, EncounterConstants.Reroll, "2")]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
