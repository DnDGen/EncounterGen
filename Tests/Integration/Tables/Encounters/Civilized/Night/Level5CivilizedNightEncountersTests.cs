using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level5CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 5, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 7, CreatureConstants.Commoner_Farmer + "[1d2+5]", RollConstants.OneD3)]
        [TestCase(8, 14, CreatureConstants.Commoner_Herder + "[1d2+5]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(15, 21, CreatureConstants.Commoner_Hunter + "[1d2+3]", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "[1d2+3]", RollConstants.One)]
        [TestCase(22, 28, CreatureConstants.Commoner_Merchant + "[1]", RollConstants.OneD3,
            CreatureConstants.Warrior_Guard + "[1]", RollConstants.OneD3,
            CreatureConstants.Expert_Merchant + "[1]", RollConstants.One)]
        [TestCase(29, 35, CreatureConstants.Warrior_Patrol + "[1]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_Captain + "[1d2+1]", RollConstants.One)]
        [TestCase(36, 42, CreatureConstants.Warrior_Bandit + "[1d2+3]", RollConstants.OneD3Plus1)]
        [TestCase(43, 49, CreatureConstants.Warrior_Bandit + "[1]", RollConstants.OneD4Plus2,
            CreatureConstants.Warrior_BanditLeader + "[1d2+1]", RollConstants.One)]
        [TestCase(50, 56, CreatureConstants.NPC_Traveler + "[1d2+5]", RollConstants.OneD3)]
        [TestCase(57, 63, CreatureConstants.NPC_Traveler + "[1d2+3]", RollConstants.OneD3Plus1)]
        [TestCase(64, 70, CreatureConstants.Character + "[5]", RollConstants.One)]
        [TestCase(71, 77, CreatureConstants.Character + "[4]", RollConstants.OneD2)]
        [TestCase(78, 84, CreatureConstants.Character + "[3]", RollConstants.OneD3)]
        [TestCase(85, 91, CreatureConstants.Character + "[2]", RollConstants.OneD3Plus1)]
        [TestCase(92, 100, CreatureConstants.Character + "[1]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
