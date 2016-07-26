using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level16DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 16, EnvironmentConstants.Dungeon);
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
        [TestCase(36, 60, CreatureConstants.Character + "[13]", RollConstants.OneD3Plus1)]
        [TestCase(61, 70, CreatureConstants.Gelugon, RollConstants.OneD3Plus1)]
        [TestCase(71, 80, CreatureConstants.Giant_Storm, RollConstants.OneD3Plus1)]
        [TestCase(81, 90, CreatureConstants.Vrock, RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Ghost + "[1d3+12]", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
