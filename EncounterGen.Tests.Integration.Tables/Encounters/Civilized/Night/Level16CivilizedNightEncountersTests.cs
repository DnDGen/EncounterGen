using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level16CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 16, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 7, CreatureConstants.Commoner_Minstrel + "[20]", RollConstants.OneD6Plus3,
            CreatureConstants.Expert_Minstrel + "[20]", RollConstants.One)]
        [TestCase(8, 13, CreatureConstants.Commoner_Minstrel + "[20]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Bard + "[12]", RollConstants.One)]
        [TestCase(14, 20, CreatureConstants.Warrior_Patrol + "[20]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Fighter + "[12]", RollConstants.One)]
        [TestCase(21, 26, CreatureConstants.Commoner_Pilgrim + "[1d2+13]", RollConstants.OneD4Plus10,
            CreatureConstants.Warrior_Guard + "[1d2+13]", RollConstants.OneD3Plus1,
            CharacterClassConstants.Cleric + "[13]", RollConstants.One)]
        [TestCase(27, 33, CreatureConstants.Commoner_Pilgrim + "[1d2+17]", RollConstants.OneD6Plus5,
            CreatureConstants.Warrior_Guard + "[1d2+17]", RollConstants.OneD3,
            CharacterClassConstants.Cleric + "[11]", RollConstants.One)]
        [TestCase(34, 39, CreatureConstants.Commoner_Pilgrim + "[20]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Cleric + "[12]", RollConstants.One)]
        [TestCase(40, 46, CreatureConstants.Warrior_Bandit + "[1d2+17]", RollConstants.OneD6Plus5,
            CharacterClassConstants.Fighter + "[11]", RollConstants.One)]
        [TestCase(47, 52, CreatureConstants.Warrior_Bandit + "[1d2+15]", RollConstants.OneD4Plus10,
            CharacterClassConstants.Fighter + "[11]", RollConstants.One)]
        [TestCase(53, 59, CreatureConstants.Vampire + "[8]", RollConstants.One)]
        [TestCase(60, 65, CreatureConstants.Ghost + "[11]", RollConstants.One)]
        [TestCase(66, 72, CreatureConstants.Character + "[16]", RollConstants.One)]
        [TestCase(73, 78, CreatureConstants.Character + "[15]", RollConstants.OneD2)]
        [TestCase(79, 85, CreatureConstants.Character + "[14]", RollConstants.OneD3)]
        [TestCase(86, 91, CreatureConstants.Character + "[13]", RollConstants.OneD3Plus1)]
        [TestCase(92, 100, CreatureConstants.Character + "[12]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
