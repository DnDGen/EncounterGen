using CharacterGen.Common.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level11CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 11, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 12, CreatureConstants.Commoner_Farmer + "1d2+17", RollConstants.OneD3)]
        [TestCase(13, 18, CreatureConstants.Ghost, RollConstants.One)]
        [TestCase(19, 24, CreatureConstants.Commoner_Herder + "1d2+17", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(25, 30, CreatureConstants.Commoner_Hunter + "1d2+15", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "1d2+15", RollConstants.One)]
        [TestCase(31, 36, CreatureConstants.Commoner_Merchant + "1d2+11", RollConstants.OneD3,
            CreatureConstants.Warrior_Guard + "1d2+11", RollConstants.OneD3,
            CreatureConstants.Expert_Merchant + "1d2+11", RollConstants.One)]
        [TestCase(37, 42, CreatureConstants.Commoner_Minstrel + "1d2+9", RollConstants.OneD6Plus3,
            CreatureConstants.Expert_Minstrel + "1d2+9", RollConstants.One)]
        [TestCase(37, 42, CreatureConstants.Commoner_Minstrel + "1d2+9", RollConstants.OneD6Plus3,
            CharacterClassConstants.Bard + "7", RollConstants.One)]
        [TestCase(43, 48, CreatureConstants.Warrior_Patrol + "1d2+11", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_Captain + "1d2+13", RollConstants.One)]
        [TestCase(43, 48, CreatureConstants.Warrior_Patrol + "1d2+9", RollConstants.OneD6Plus3,
            CharacterClassConstants.Fighter + "7", RollConstants.One)]
        [TestCase(49, 54, CreatureConstants.Commoner_Pilgrim + "1d2+3", RollConstants.OneD4Plus10,
            CreatureConstants.Warrior_Guard + "1d2+3", RollConstants.OneD3Plus1,
            CharacterClassConstants.Cleric + "8", RollConstants.One)]
        [TestCase(49, 54, CreatureConstants.Commoner_Pilgrim + "1d2+7", RollConstants.OneD6Plus5,
            CreatureConstants.Warrior_Guard + "1d2+7", RollConstants.OneD3,
            CharacterClassConstants.Cleric + "6", RollConstants.One)]
        [TestCase(49, 54, CreatureConstants.Commoner_Pilgrim + "1d2+9", RollConstants.OneD6Plus3,
            CharacterClassConstants.Cleric + "7", RollConstants.One)]
        [TestCase(55, 60, CreatureConstants.Warrior_Bandit + "1d2+15", RollConstants.OneD3Plus1)]
        [TestCase(43, 48, CreatureConstants.Warrior_Bandit + "1d2+11", RollConstants.OneD4Plus2,
            CreatureConstants.Warrior_Leader + "1d2+13", RollConstants.One)]
        [TestCase(43, 48, CreatureConstants.Warrior_Bandit + "1d2+9", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_Leader + "1d2+11", RollConstants.One)]
        [TestCase(55, 60, CreatureConstants.Warrior_Bandit + "1d2+15", RollConstants.OneD6Plus5,
            CharacterClassConstants.Fighter + "", RollConstants.One)]
        [TestCase(61, 66, CreatureConstants.Slaad_Death, RollConstants.OneD2)]
        [TestCase(67, 72, CreatureConstants.TrumpetArchon, RollConstants.OneD3Plus1)]
        [TestCase(73, 100, CreatureConstants.Character + "11", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
