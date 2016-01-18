using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Marsh.Temperate.Day
{
    [TestFixture]
    public class Level19TemperateMarshDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 19, EnvironmentConstants.TemperateMarshDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 28, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(29, 42, CreatureConstants.Cornugon, RollConstants.OneD3Plus1)]
        [TestCase(43, 56, CreatureConstants.Gelugon, RollConstants.OneD6Plus5)]
        [TestCase(57, 70, CreatureConstants.Golem_Stone_Greater, RollConstants.OneD3Plus1)]
        [TestCase(71, 100, CreatureConstants.Character + "[16]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
