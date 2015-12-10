using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level15DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 15, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 30, CreatureConstants.Beholder, RollConstants.OneD3)]
        [TestCase(31, 40, CreatureConstants.Slaadi_Death, RollConstants.OneD2,
            CreatureConstants.Slaadi_Green, RollConstants.OneD3Plus1)]
        [TestCase(41, 45, CreatureConstants.Ghaeles, RollConstants.OneD3)]
        [TestCase(46, 70, CreatureConstants.Character + "12", RollConstants.OneD3Plus1)]
        [TestCase(71, 80, CreatureConstants.Hezrou, RollConstants.OneD3Plus1)]
        [TestCase(81, 90, CreatureConstants.Gelugon, RollConstants.One,
            CreatureConstants.Cornugon, RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Vampire, RollConstants.One)]
        public override void Percentile(Int32 lower, Int32 upper, params String[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
