using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level2CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 2, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, CreatureConstants.Commoner_Farmer + "[1d2]", RollConstants.OneD3)]
        [TestCase(21, 40, CreatureConstants.Commoner_Herder + "[1d2]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(41, 60, CreatureConstants.NPC_Traveler + "[1d2]", RollConstants.OneD3)]
        [TestCase(61, 80, CreatureConstants.Character + "[2]", RollConstants.One)]
        [TestCase(81, 100, CreatureConstants.Character + "[1]", RollConstants.OneD2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
