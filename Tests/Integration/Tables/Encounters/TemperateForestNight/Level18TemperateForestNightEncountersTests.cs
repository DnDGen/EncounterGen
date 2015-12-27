using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.TemperateForestNight
{
    [TestFixture]
    public class Level18TemperateForestNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 18, EnvironmentConstants.TemperateForestNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 28, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(29, 42, CreatureConstants.Marilith, RollConstants.OneD2)]
        [TestCase(43, 56, CreatureConstants.Nightcrawler, RollConstants.One)]
        [TestCase(57, 70, CreatureConstants.Nightwing, RollConstants.OneD4Plus2)]
        [TestCase(71, 100, CreatureConstants.Character + "15", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
