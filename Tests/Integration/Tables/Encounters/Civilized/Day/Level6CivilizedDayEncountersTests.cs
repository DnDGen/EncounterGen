using CharacterGen.Common.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Day
{
    [TestFixture]
    public class Level6CivilizedDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 6, EnvironmentConstants.CivilizedDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, CreatureConstants.Commoner_Farmer + "[1d2+7]", RollConstants.OneD3)]
        [TestCase(6, 10, CreatureConstants.Commoner_Herder + "[1d2+7]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(11, 15, CreatureConstants.Commoner_Hunter + "[1d2+5]", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "[1d2+5]", RollConstants.One)]
        [TestCase(16, 20, CreatureConstants.Commoner_Merchant + "[1d2+1]", RollConstants.OneD3,
            CreatureConstants.Warrior_Guard + "[1d2+1]", RollConstants.OneD3,
            CreatureConstants.Expert_Merchant + "[1d2+1]", RollConstants.One)]
        [TestCase(21, 25, CreatureConstants.Commoner_Minstrel + "[1]", RollConstants.OneD6Plus3,
            CreatureConstants.Expert_Minstrel + "[1]", RollConstants.One)]
        [TestCase(26, 30, CreatureConstants.Commoner_Minstrel + "[1]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Bard + "[2]", RollConstants.One)]
        [TestCase(31, 35, CreatureConstants.Warrior_Patrol + "[1d2+1]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_Captain + "[1d2+3]", RollConstants.One)]
        [TestCase(36, 40, CreatureConstants.Warrior_Patrol + "[1]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Fighter + "[2]", RollConstants.One)]
        [TestCase(41, 45, CreatureConstants.Commoner_Pilgrim + "[1]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Cleric + "[2]", RollConstants.One)]
        [TestCase(46, 50, CreatureConstants.Warrior_Bandit + "[1d2+5]", RollConstants.OneD3Plus1)]
        [TestCase(51, 55, CreatureConstants.Warrior_Bandit + "[1d2+1]", RollConstants.OneD4Plus2,
            CreatureConstants.Warrior_BanditLeader + "[1d2+3]", RollConstants.One)]
        [TestCase(56, 60, CreatureConstants.Warrior_Bandit + "[1]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_BanditLeader + "[1d2+1]", RollConstants.One)]
        [TestCase(61, 65, CreatureConstants.NPC_Traveler + "[1d2+7]", RollConstants.OneD3)]
        [TestCase(66, 70, CreatureConstants.NPC_Traveler + "[1d2+5]", RollConstants.OneD3Plus1)]
        [TestCase(71, 75, CreatureConstants.Character + "[6]", RollConstants.One)]
        [TestCase(76, 80, CreatureConstants.Character + "[5]", RollConstants.OneD2)]
        [TestCase(81, 85, CreatureConstants.Character + "[4]", RollConstants.OneD3)]
        [TestCase(86, 90, CreatureConstants.Character + "[3]", RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Character + "[2]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
