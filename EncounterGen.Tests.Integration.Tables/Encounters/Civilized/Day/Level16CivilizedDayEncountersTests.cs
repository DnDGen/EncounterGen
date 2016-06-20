using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Day
{
    [TestFixture]
    public class Level16CivilizedDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 16, EnvironmentConstants.CivilizedDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 8, CreatureConstants.Commoner_Minstrel + "[20]", RollConstants.OneD6Plus3,
            CreatureConstants.Expert_Minstrel + "[20]", RollConstants.One)]
        [TestCase(9, 15, CreatureConstants.Commoner_Minstrel + "[20]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Bard + "[12]", RollConstants.One)]
        [TestCase(16, 23, CreatureConstants.Warrior_Patrol + "[20]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Fighter + "[12]", RollConstants.One)]
        [TestCase(24, 30, CreatureConstants.Commoner_Pilgrim + "[1d2+13]", RollConstants.OneD4Plus10,
            CreatureConstants.Warrior_Guard + "[1d2+13]", RollConstants.OneD3Plus1,
            CharacterClassConstants.Cleric + "[13]", RollConstants.One)]
        [TestCase(31, 38, CreatureConstants.Commoner_Pilgrim + "[1d2+17]", RollConstants.OneD6Plus5,
            CreatureConstants.Warrior_Guard + "[1d2+17]", RollConstants.OneD3,
            CharacterClassConstants.Cleric + "[11]", RollConstants.One)]
        [TestCase(39, 45, CreatureConstants.Commoner_Pilgrim + "[20]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Cleric + "[12]", RollConstants.One)]
        [TestCase(46, 53, CreatureConstants.Warrior_Bandit + "[1d2+17]", RollConstants.OneD6Plus5,
            CharacterClassConstants.Fighter + "[11]", RollConstants.One)]
        [TestCase(54, 60, CreatureConstants.Warrior_Bandit + "[1d2+15]", RollConstants.OneD4Plus10,
            CharacterClassConstants.Fighter + "[11]", RollConstants.One)]
        [TestCase(61, 68, CreatureConstants.Character + "[16]", RollConstants.One)]
        [TestCase(69, 75, CreatureConstants.Character + "[15]", RollConstants.OneD2)]
        [TestCase(76, 83, CreatureConstants.Character + "[14]", RollConstants.OneD3)]
        [TestCase(84, 90, CreatureConstants.Character + "[13]", RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Character + "[12]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
