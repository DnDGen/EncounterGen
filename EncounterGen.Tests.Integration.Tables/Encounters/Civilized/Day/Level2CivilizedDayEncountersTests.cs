using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Day
{
    [TestFixture]
    public class Level2CivilizedDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 2, EnvironmentConstants.CivilizedDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, CreatureConstants.Commoner_Farmer + "[1]", RollConstants.OneD3)]
        [TestCase(21, 40, CreatureConstants.Commoner_Herder + "[1]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(41, 60, CreatureConstants.NPC_Traveler + "[1]", RollConstants.OneD3)]
        [TestCase(61, 80, CreatureConstants.Character + "[2]", RollConstants.One)]
        [TestCase(81, 100, CreatureConstants.Character + "[1]", RollConstants.OneD2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
