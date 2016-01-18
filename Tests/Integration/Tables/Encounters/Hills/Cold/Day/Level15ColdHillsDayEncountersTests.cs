using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Cold.Day
{
    [TestFixture]
    public class Level15ColdHillsDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 15, EnvironmentConstants.ColdHillsDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 10, CreatureConstants.AstralDeva, RollConstants.OneD2)]
        [TestCase(11, 20, CreatureConstants.Glabrezu, RollConstants.One,
            CreatureConstants.Succubus, RollConstants.One,
            CreatureConstants.Vrock, RollConstants.OneD3Plus1)]
        [TestCase(21, 30, CreatureConstants.Hamatula, RollConstants.OneD4Plus2)]
        [TestCase(31, 40, CreatureConstants.Osyluth, RollConstants.OneD6Plus5)]
        [TestCase(41, 50, CreatureConstants.TrumpetArchon, RollConstants.OneD2)]
        [TestCase(51, 60, CreatureConstants.Vrock, RollConstants.OneD6Plus5)]
        [TestCase(61, 80, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(81, 100, CreatureConstants.Character + "[12]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
