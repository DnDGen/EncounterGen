using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
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

        [TestCase(1, 6, CreatureConstants.Commoner_Farmer + "[1d2+5]", RollConstants.OneD3)]
        [TestCase(7, 12, CreatureConstants.Commoner_Herder + "[1d2+5]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(13, 18, CreatureConstants.Commoner_Hunter + "[1d2+3]", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "[1d2+3]", RollConstants.One)]
        [TestCase(19, 24, CreatureConstants.Commoner_Merchant + "[1]", RollConstants.OneD3,
            CreatureConstants.Warrior_Guard + "[1]", RollConstants.OneD3,
            CreatureConstants.Expert_Merchant + "[1]", RollConstants.One)]
        [TestCase(25, 30, CreatureConstants.Warrior_Patrol + "[1]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_Captain + "[1d2+1]", RollConstants.One)]
        [TestCase(31, 36, CreatureConstants.Warrior_Bandit + "[1d2+3]", RollConstants.OneD3Plus1)]
        [TestCase(37, 42, CreatureConstants.Warrior_Bandit + "[1]", RollConstants.OneD4Plus2,
            CreatureConstants.Warrior_BanditLeader + "[1d2+1]", RollConstants.One)]
        [TestCase(43, 48, CreatureConstants.NPC_Traveler + "[1d2+5]", RollConstants.OneD3)]
        [TestCase(49, 54, CreatureConstants.NPC_Traveler + "[1d2+3]", RollConstants.OneD3Plus1)]
        [TestCase(55, 60, CreatureConstants.Vampire + "[3]", RollConstants.One)]
        [TestCase(61, 66, CreatureConstants.Ghost + "[3]", RollConstants.One)]
        [TestCase(67, 72, CreatureConstants.Character + "[5]", RollConstants.One)]
        [TestCase(73, 78, CreatureConstants.Character + "[4]", RollConstants.OneD2)]
        [TestCase(79, 84, CreatureConstants.Character + "[3]", RollConstants.OneD3)]
        [TestCase(85, 91, CreatureConstants.Character + "[2]", RollConstants.OneD3Plus1)]
        [TestCase(92, 100, CreatureConstants.Character + "[1]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
