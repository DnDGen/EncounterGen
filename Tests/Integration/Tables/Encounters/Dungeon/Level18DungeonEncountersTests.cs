using EncounterGen.Common;
using EncounterGen.Generators;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level18DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 18, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 10, EncounterConstants.Reroll, "17")]
        [TestCase(11, 25, CreatureConstants.AstralDeva, "1d4+2")]
        [TestCase(26, 35, CreatureConstants.Planetar, "1d3")]
        [TestCase(36, 38, CreatureConstants.Dragon_Black_VeryOld, "1")]
        [TestCase(39, 40, CreatureConstants.Dragon_Blue_Old, "1")]
        [TestCase(41, 41, CreatureConstants.Dragon_Green_Old, "1")]
        [TestCase(42, 43, CreatureConstants.Dragon_Red_MatureAdult, "1")]
        [TestCase(44, 44, CreatureConstants.Dragon_Silver_MatureAdult, "1")]
        [TestCase(45, 47, CreatureConstants.Dragon_White_Ancient, "1")]
        [TestCase(48, 62, CreatureConstants.Nightcrawler, "1")]
        [TestCase(63, 72, CreatureConstants.Character, "1d4")]
        [TestCase(73, 90, CreatureConstants.Character, "1", CreatureConstants.WerewolfLord, "1")]
        [TestCase(91, 100, EncounterConstants.Reroll, "19")]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
