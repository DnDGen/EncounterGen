using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Marsh.Warm.Day
{
    [TestFixture]
    public class Level17WarmMarshDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 17, EnvironmentConstants.WarmMarshDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 10, CreatureConstants.TrumpetArchon, RollConstants.OneD3Plus1)]
        [TestCase(11, 20, CreatureConstants.AstralDeva, RollConstants.OneD3Plus1)]
        [TestCase(21, 30, CreatureConstants.Hamatula, RollConstants.OneD6Plus5)]
        [TestCase(31, 40, CreatureConstants.Marilith, RollConstants.One)]
        [TestCase(41, 50, CreatureConstants.Planetar, RollConstants.OneD2)]
        [TestCase(51, 60, CreatureConstants.Salamander_Noble, RollConstants.OneD4Plus10)]
        [TestCase(61, 80, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(81, 100, CreatureConstants.Character + "[14]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
