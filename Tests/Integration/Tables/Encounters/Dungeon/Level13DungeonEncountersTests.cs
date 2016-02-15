using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level13DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 13, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 15, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(16, 20, CreatureConstants.Beholder, RollConstants.One)]
        [TestCase(21, 30, CreatureConstants.NightHag, RollConstants.OneD3Plus1,
            CreatureConstants.Nightmare, RollConstants.OneD3Plus1)]
        [TestCase(31, 35, CreatureConstants.Slaad_Gray, RollConstants.OneD3Plus1)]
        [TestCase(36, 40, CreatureConstants.Couatl, RollConstants.OneD3Plus1)]
        [TestCase(41, 45, CreatureConstants.Naga_Guardian, RollConstants.OneD3Plus1)]
        [TestCase(46, 60, CreatureConstants.Character + "[10]", RollConstants.OneD3Plus1)]
        [TestCase(61, 67, CreatureConstants.FrostWorm, RollConstants.OneD2)]
        [TestCase(68, 73, CreatureConstants.Hydra + " (1d3+9 heads)", RollConstants.One)]
        [TestCase(74, 80, CreatureConstants.Roper, RollConstants.OneD3Plus1)]
        [TestCase(81, 90, CreatureConstants.Cornugon, RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Ghost + "[1d3+9]", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
