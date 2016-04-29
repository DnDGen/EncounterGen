using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
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

        [TestCase(1, 8, CreatureConstants.TrumpetArchon, RollConstants.OneD3Plus1)]
        [TestCase(9, 16, CreatureConstants.AstralDeva, RollConstants.OneD3Plus1)]
        [TestCase(17, 24, CreatureConstants.Hamatula, RollConstants.OneD6Plus5)]
        [TestCase(25, 32, CreatureConstants.Marilith, RollConstants.One)]
        [TestCase(33, 40, CreatureConstants.Planetar, RollConstants.OneD2)]
        [TestCase(41, 48, CreatureConstants.Salamander_Noble, RollConstants.OneD4Plus10)]
        [TestCase(49, 64, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(65, 72, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(73, 80, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(81, 100, CreatureConstants.Character + "[14]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
