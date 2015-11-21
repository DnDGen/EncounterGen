using EncounterGen.Common;
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

        [TestCase(1, 20, CreatureConstants.Dragon, "1")]
        [TestCase(21, 30, CreatureConstants.Balor, "1d3")]
        [TestCase(41, 45, CreatureConstants.Planetar, "1d3")]
        [TestCase(46, 70, CreatureConstants.Character, "1d3+1")]
        [TestCase(71, 80, CreatureConstants.Glabrezu, "1d3+1")]
        [TestCase(81, 90, CreatureConstants.Vampire, "1")]
        [TestCase(91, 100, CreatureConstants.Nightwalker, "1d3+1")]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }

        [TestCase(31, 40, CreatureConstants.PitFiend, "1", CreatureConstants.Gelugon, "1d3+1")]
        public override void Percentile(Int32 lower, Int32 upper, String firstType, String firstAmount, String secondType, String secondAmount)
        {
            base.Percentile(lower, upper, firstType, firstAmount, secondType, secondAmount);
        }
    }
}
