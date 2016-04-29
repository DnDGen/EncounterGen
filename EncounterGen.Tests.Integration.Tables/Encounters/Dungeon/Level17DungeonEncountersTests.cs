using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level17DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 17, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 30, CreatureConstants.Marilith, RollConstants.One)]
        [TestCase(31, 35, CreatureConstants.TrumpetArchon, RollConstants.OneD3Plus1)]
        [TestCase(36, 60, CreatureConstants.Character + "[14]", RollConstants.OneD3Plus1)]
        [TestCase(61, 70, CreatureConstants.Glabrezu, RollConstants.OneD3)]
        [TestCase(71, 80, CreatureConstants.Hezrou, RollConstants.OneD3Plus1)]
        [TestCase(81, 90, CreatureConstants.Lich + "[1d3+13]", RollConstants.One)]
        [TestCase(91, 100, CreatureConstants.Nightwing, RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
