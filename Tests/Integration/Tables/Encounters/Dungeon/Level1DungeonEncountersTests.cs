using EncounterGen.Common;
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

        [TestCase(1, 4, CreatureConstants.Centipede_Monstrous_Medium, "1d3")]
        [TestCase(5, 9, CreatureConstants.Rat_Dire, "1d3+1")]
        [TestCase(10, 14, CreatureConstants.FireBeetle_Giant, "1d3+1")]
        [TestCase(15, 17, CreatureConstants.Scorpion_Monstrous_Small, "1d3")]
        [TestCase(18, 20, CreatureConstants.Spider_Monstrous_Small, "1d3")]
        [TestCase(21, 25, CreatureConstants.Dragon, "1")]
        [TestCase(26, 30, CreatureConstants.DwarfWarrior, "1d3")]
        [TestCase(31, 35, CreatureConstants.ElfWarrior, "1d3")]
        [TestCase(36, 40, CreatureConstants.Character, "1")]
        [TestCase(41, 45, CreatureConstants.Darkmantle, "1")]
        [TestCase(46, 55, CreatureConstants.Krenshar, "1")]
        [TestCase(56, 60, CreatureConstants.Lemure, "1")]
        [TestCase(61, 65, CreatureConstants.Goblin, "1d4+2")]
        [TestCase(71, 80, CreatureConstants.Kobold, "1d6+3")]
        [TestCase(81, 90, CreatureConstants.Skeleton_HumanWarrior, "1d3+1")]
        [TestCase(91, 100, CreatureConstants.Zombie_HumanCommoner, "1d3")]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }

        [TestCase(66, 70, CreatureConstants.Hobgoblin, "1", CreatureConstants.Goblin, "1d3")]
        public override void Percentile(Int32 lower, Int32 upper, String firstType, String firstAmount, String secondType, String secondAmount)
        {
            base.Percentile(lower, upper, firstType, firstAmount, secondType, secondAmount);
        }
    }
}
