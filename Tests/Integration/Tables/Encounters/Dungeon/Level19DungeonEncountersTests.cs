using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level19DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 19, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(31, 40, CreatureConstants.PitFiend, RollConstants.OneD3Plus1)]
        [TestCase(41, 45, CreatureConstants.Solar, RollConstants.OneD3)]
        [TestCase(46, 70, CreatureConstants.Character, RollConstants.OneD3Plus1)]
        [TestCase(71, 80, CreatureConstants.Nalfeshnee, RollConstants.OneD3Plus1)]
        [TestCase(81, 90, CreatureConstants.Ghost, RollConstants.One)]
        [TestCase(91, 100, CreatureConstants.Nightcrawler, RollConstants.OneD3)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }

        [TestCase(21, 30, CreatureConstants.Marilith, RollConstants.One, CreatureConstants.Glabrezu, RollConstants.OneD3)]
        public override void Percentile(Int32 lower, Int32 upper, String firstType, String firstAmount, String secondType, String secondAmount)
        {
            base.Percentile(lower, upper, firstType, firstAmount, secondType, secondAmount);
        }
    }
}
