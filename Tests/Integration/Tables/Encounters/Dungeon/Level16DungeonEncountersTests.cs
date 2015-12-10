using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level16DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 16, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 30, CreatureConstants.PitFiend, RollConstants.One)]
        [TestCase(31, 35, CreatureConstants.AstralDeva, RollConstants.OneD3)]
        [TestCase(36, 60, CreatureConstants.Character + "13", RollConstants.OneD3Plus1)]
        [TestCase(61, 70, CreatureConstants.Gelugon, RollConstants.OneD3Plus1)]
        [TestCase(71, 80, CreatureConstants.Giant_Storm, RollConstants.OneD3Plus1)]
        [TestCase(81, 90, CreatureConstants.Vrock, RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Ghost, RollConstants.One)]
        public override void Percentile(Int32 lower, Int32 upper, params String[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
