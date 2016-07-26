using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level13CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 13, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.Commoner_Hunter + "[20]", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "[20]", RollConstants.One)]
        [TestCase(5, 8, CreatureConstants.Commoner_Merchant + "[1d2+15]", RollConstants.OneD3,
            CreatureConstants.Warrior_Guard + "[1d2+15]", RollConstants.OneD3,
            CreatureConstants.Expert_Merchant + "[1d2+15]", RollConstants.One)]
        [TestCase(9, 12, CreatureConstants.Commoner_Minstrel + "[1d2+13]", RollConstants.OneD6Plus3,
            CreatureConstants.Expert_Minstrel + "[1d2+13]", RollConstants.One)]
        [TestCase(13, 16, CreatureConstants.Commoner_Minstrel + "[1d2+13]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Bard + "[9]", RollConstants.One)]
        [TestCase(17, 20, CreatureConstants.Warrior_Patrol + "[1d2+15]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_Captain + "[1d2+17]", RollConstants.One)]
        [TestCase(21, 24, CreatureConstants.Warrior_Patrol + "[1d2+13]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Fighter + "[9]", RollConstants.One)]
        [TestCase(25, 28, CreatureConstants.Commoner_Pilgrim + "[1d2+7]", RollConstants.OneD4Plus10,
            CreatureConstants.Warrior_Guard + "[1d2+7]", RollConstants.OneD3Plus1,
            CharacterClassConstants.Cleric + "[10]", RollConstants.One)]
        [TestCase(29, 32, CreatureConstants.Commoner_Pilgrim + "[1d2+11]", RollConstants.OneD6Plus5,
            CreatureConstants.Warrior_Guard + "[1d2+11]", RollConstants.OneD3,
            CharacterClassConstants.Cleric + "[8]", RollConstants.One)]
        [TestCase(33, 36, CreatureConstants.Commoner_Pilgrim + "[1d2+13]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Cleric + "[9]", RollConstants.One)]
        [TestCase(37, 40, CreatureConstants.Warrior_Bandit + "[20]", RollConstants.OneD3Plus1)]
        [TestCase(41, 44, CreatureConstants.Warrior_Bandit + "[1d2+15]", RollConstants.OneD4Plus2,
            CreatureConstants.Warrior_BanditLeader + "[1d2+17]", RollConstants.One)]
        [TestCase(45, 48, CreatureConstants.Warrior_Bandit + "[1d2+13]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_BanditLeader + "[1d2+15]", RollConstants.One)]
        [TestCase(49, 52, CreatureConstants.Warrior_Bandit + "[1d2+11]", RollConstants.OneD6Plus5,
            CharacterClassConstants.Fighter + "[8]", RollConstants.One)]
        [TestCase(53, 56, CreatureConstants.Warrior_Bandit + "[1d2+9]", RollConstants.OneD4Plus10,
            CharacterClassConstants.Fighter + "[8]", RollConstants.One)]
        [TestCase(57, 60, CreatureConstants.NPC_Traveler + "[20]", RollConstants.OneD3Plus1)]
        [TestCase(61, 65, CreatureConstants.Vampire + "[11]", RollConstants.One)]
        [TestCase(66, 70, CreatureConstants.Ghost + "[11]", RollConstants.One)]
        [TestCase(71, 76, CreatureConstants.Character + "[13]", RollConstants.One)]
        [TestCase(77, 82, CreatureConstants.Character + "[12]", RollConstants.OneD2)]
        [TestCase(83, 88, CreatureConstants.Character + "[11]", RollConstants.OneD3)]
        [TestCase(89, 94, CreatureConstants.Character + "[10]", RollConstants.OneD3Plus1)]
        [TestCase(95, 100, CreatureConstants.Character + "[9]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
