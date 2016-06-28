using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level15CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 15, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 6, CreatureConstants.Commoner_Merchant + "[20]", RollConstants.OneD3,
            CreatureConstants.Warrior_Guard + "[20]", RollConstants.OneD3,
            CreatureConstants.Expert_Merchant + "[20]", RollConstants.One)]
        [TestCase(7, 12, CreatureConstants.Commoner_Minstrel + "[1d2+17]", RollConstants.OneD6Plus3,
            CreatureConstants.Expert_Minstrel + "[1d2+17]", RollConstants.One)]
        [TestCase(13, 18, CreatureConstants.Commoner_Minstrel + "[1d2+17]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Bard + "[11]", RollConstants.One)]
        [TestCase(19, 24, CreatureConstants.Warrior_Patrol + "[1d2+17]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Fighter + "[11]", RollConstants.One)]
        [TestCase(25, 30, CreatureConstants.Commoner_Pilgrim + "[1d2+11]", RollConstants.OneD4Plus10,
            CreatureConstants.Warrior_Guard + "[1d2+11]", RollConstants.OneD3Plus1,
            CharacterClassConstants.Cleric + "[12]", RollConstants.One)]
        [TestCase(31, 36, CreatureConstants.Commoner_Pilgrim + "[1d2+15]", RollConstants.OneD6Plus5,
            CreatureConstants.Warrior_Guard + "[1d2+15]", RollConstants.OneD3,
            CharacterClassConstants.Cleric + "[10]", RollConstants.One)]
        [TestCase(37, 42, CreatureConstants.Commoner_Pilgrim + "[1d2+17]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Cleric + "[11]", RollConstants.One)]
        [TestCase(43, 48, CreatureConstants.Warrior_Bandit + "[1d2+17]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_BanditLeader + "[20]", RollConstants.One)]
        [TestCase(49, 54, CreatureConstants.Warrior_Bandit + "[1d2+15]", RollConstants.OneD6Plus5,
            CharacterClassConstants.Fighter + "[10]", RollConstants.One)]
        [TestCase(55, 60, CreatureConstants.Warrior_Bandit + "[1d2+13]", RollConstants.OneD4Plus10,
            CharacterClassConstants.Fighter + "[10]", RollConstants.One)]
        [TestCase(61, 65, CreatureConstants.Vampire + "[7]", RollConstants.One)]
        [TestCase(66, 70, CreatureConstants.Ghost + "[10]", RollConstants.One)]
        [TestCase(71, 76, CreatureConstants.Character + "[15]", RollConstants.One)]
        [TestCase(77, 82, CreatureConstants.Character + "[14]", RollConstants.OneD2)]
        [TestCase(83, 88, CreatureConstants.Character + "[13]", RollConstants.OneD3)]
        [TestCase(89, 94, CreatureConstants.Character + "[12]", RollConstants.OneD3Plus1)]
        [TestCase(95, 100, CreatureConstants.Character + "[11]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
