using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level6CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 6, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, CreatureConstants.Commoner_Farmer + "[1d2+7]", RollConstants.OneD3)]
        [TestCase(6, 9, CreatureConstants.Commoner_Herder + "[1d2+7]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(10, 14, CreatureConstants.Commoner_Hunter + "[1d2+5]", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "[1d2+5]", RollConstants.One)]
        [TestCase(15, 18, CreatureConstants.Commoner_Merchant + "[1d2+1]", RollConstants.OneD3,
            CreatureConstants.Warrior_Guard + "[1d2+1]", RollConstants.OneD3,
            CreatureConstants.Expert_Merchant + "[1d2+1]", RollConstants.One)]
        [TestCase(19, 23, CreatureConstants.Commoner_Minstrel + "[1]", RollConstants.OneD6Plus3,
            CreatureConstants.Expert_Minstrel + "[1]", RollConstants.One)]
        [TestCase(24, 27, CreatureConstants.Commoner_Minstrel + "[1]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Bard + "[2]", RollConstants.One)]
        [TestCase(28, 32, CreatureConstants.Warrior_Patrol + "[1d2+1]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_Captain + "[1d2+3]", RollConstants.One)]
        [TestCase(33, 36, CreatureConstants.Warrior_Patrol + "[1]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Fighter + "[2]", RollConstants.One)]
        [TestCase(37, 41, CreatureConstants.Commoner_Pilgrim + "[1]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Cleric + "[2]", RollConstants.One)]
        [TestCase(42, 45, CreatureConstants.Warrior_Bandit + "[1d2+5]", RollConstants.OneD3Plus1)]
        [TestCase(46, 50, CreatureConstants.Warrior_Bandit + "[1d2+1]", RollConstants.OneD4Plus2,
            CreatureConstants.Warrior_BanditLeader + "[1d2+3]", RollConstants.One)]
        [TestCase(51, 54, CreatureConstants.Warrior_Bandit + "[1]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_BanditLeader + "[1d2+1]", RollConstants.One)]
        [TestCase(55, 59, CreatureConstants.NPC_Traveler + "[1d2+7]", RollConstants.OneD3)]
        [TestCase(60, 63, CreatureConstants.NPC_Traveler + "[1d2+5]", RollConstants.OneD3Plus1)]
        [TestCase(64, 68, CreatureConstants.Ghost + "[4]", RollConstants.One)]
        [TestCase(69, 72, CreatureConstants.Vampire + "[4]", RollConstants.One)]
        [TestCase(73, 77, CreatureConstants.Character + "[6]", RollConstants.One)]
        [TestCase(78, 81, CreatureConstants.Character + "[5]", RollConstants.OneD2)]
        [TestCase(82, 86, CreatureConstants.Character + "[4]", RollConstants.OneD3)]
        [TestCase(87, 90, CreatureConstants.Character + "[3]", RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Character + "[2]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
