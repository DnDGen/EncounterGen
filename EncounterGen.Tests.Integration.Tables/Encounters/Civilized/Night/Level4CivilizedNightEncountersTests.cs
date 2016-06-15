using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level4CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 4, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 10, CreatureConstants.Commoner_Farmer + "[1d2+3]", RollConstants.OneD3)]
        [TestCase(11, 20, CreatureConstants.Commoner_Herder + "[1d2+3]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(21, 30, CreatureConstants.Commoner_Hunter + "[1d2+1]", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "[1d2+1]", RollConstants.One)]
        [TestCase(31, 40, CreatureConstants.Warrior_Bandit + "[1d2+1]", RollConstants.OneD3Plus1)]
        [TestCase(41, 50, CreatureConstants.NPC_Traveler + "[1d2+3]", RollConstants.OneD3)]
        [TestCase(51, 60, CreatureConstants.NPC_Traveler + "[1d2+1]", RollConstants.OneD3Plus1)]
        [TestCase(61, 70, CreatureConstants.Character + "[4]", RollConstants.One)]
        [TestCase(71, 80, CreatureConstants.Character + "[3]", RollConstants.OneD2)]
        [TestCase(81, 90, CreatureConstants.Character + "[2]", RollConstants.OneD3)]
        [TestCase(91, 100, CreatureConstants.Character + "[1]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
