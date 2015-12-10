using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level20DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 20, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 30, CreatureConstants.Balor, RollConstants.OneD3)]
        [TestCase(31, 40, CreatureConstants.Marilith, RollConstants.OneD3Plus1)]
        [TestCase(41, 45, CreatureConstants.Solar, RollConstants.One,
            CreatureConstants.Planetar, RollConstants.OneD2)]
        [TestCase(46, 55, CreatureConstants.Character + "17", RollConstants.OneD3Plus1)]
        [TestCase(56, 60, CreatureConstants.Character + "18", RollConstants.OneD3)]
        [TestCase(61, 65, CreatureConstants.Character + "19", RollConstants.OneD2)]
        [TestCase(66, 70, CreatureConstants.Character + "20", RollConstants.One)]
        [TestCase(71, 80, CreatureConstants.Nalfeshnee, RollConstants.OneD3Plus1,
            CreatureConstants.Hezrou, RollConstants.OneD3Plus1)]
        [TestCase(81, 85, CreatureConstants.Ghost, RollConstants.One)]
        [TestCase(86, 90, CreatureConstants.Lich, RollConstants.One)]
        [TestCase(91, 95, CreatureConstants.Nightcrawler, RollConstants.OneD3)]
        [TestCase(96, 100, CreatureConstants.Vampire, RollConstants.One)]
        public override void Percentile(Int32 lower, Int32 upper, params String[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
