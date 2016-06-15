using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Day
{
    [TestFixture]
    public class Level20CivilizedDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 20, EnvironmentConstants.CivilizedDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, CreatureConstants.Character + "[20]", RollConstants.One)]
        [TestCase(21, 40, CreatureConstants.Character + "[19]", RollConstants.OneD2)]
        [TestCase(41, 60, CreatureConstants.Character + "[18]", RollConstants.OneD3)]
        [TestCase(61, 80, CreatureConstants.Character + "[17]", RollConstants.OneD3Plus1)]
        [TestCase(81, 100, CreatureConstants.Character + "[16]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
