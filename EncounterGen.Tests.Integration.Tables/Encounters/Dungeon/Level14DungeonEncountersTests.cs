using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level14DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 14, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 15, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(16, 25, CreatureConstants.Beholder, RollConstants.One,
            CreatureConstants.CharmedCreature + "[11]", RollConstants.One)]
        [TestCase(26, 35, CreatureConstants.Slaad_Death, RollConstants.OneD2)]
        [TestCase(36, 40, CreatureConstants.Giant_Cloud + " (good)", RollConstants.OneD3Plus1)]
        [TestCase(41, 55, CreatureConstants.Character + "[11]", RollConstants.OneD3Plus1)]
        [TestCase(56, 60, CreatureConstants.Cryohydra + " (1d4+8 heads)", RollConstants.One)]
        [TestCase(61, 65, CreatureConstants.Golem_Iron, RollConstants.OneD2)]
        [TestCase(66, 70, CreatureConstants.Pyrohydra + " (1d4+8 heads)", RollConstants.One)]
        [TestCase(71, 80, CreatureConstants.Giant_Cloud + " (evil)", RollConstants.OneD3Plus1)]
        [TestCase(81, 90, CreatureConstants.Giant_Storm, RollConstants.One,
            CreatureConstants.Griffon, RollConstants.OneD4Plus2)]
        [TestCase(91, 100, CreatureConstants.Lich + "[1d3+10]", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
