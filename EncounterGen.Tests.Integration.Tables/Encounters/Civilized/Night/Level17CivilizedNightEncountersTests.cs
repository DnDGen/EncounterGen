using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level17CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 17, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 9, CreatureConstants.Ghost + "[12]", RollConstants.One)]
        [TestCase(10, 18, CreatureConstants.Commoner_Pilgrim + "[1d2+15]", RollConstants.OneD4Plus10,
            CreatureConstants.Warrior_Guard + "[1d2+15]", RollConstants.OneD3Plus1,
            CharacterClassConstants.Cleric + "[14]", RollConstants.One)]
        [TestCase(19, 27, CreatureConstants.Commoner_Pilgrim + "[20]", RollConstants.OneD6Plus5,
            CreatureConstants.Warrior_Guard + "[20]", RollConstants.OneD3,
            CharacterClassConstants.Cleric + "[12]", RollConstants.One)]
        [TestCase(28, 36, CreatureConstants.Warrior_Bandit + "[20]", RollConstants.OneD6Plus5,
            CharacterClassConstants.Fighter + "[12]", RollConstants.One)]
        [TestCase(37, 45, CreatureConstants.Warrior_Bandit + "[1d2+17]", RollConstants.OneD4Plus10,
            CharacterClassConstants.Fighter + "[12]", RollConstants.One)]
        [TestCase(46, 54, CreatureConstants.Vampire + "[9]", RollConstants.One)]
        [TestCase(55, 63, CreatureConstants.Character + "[17]", RollConstants.One)]
        [TestCase(64, 72, CreatureConstants.Character + "[16]", RollConstants.OneD2)]
        [TestCase(73, 81, CreatureConstants.Character + "[15]", RollConstants.OneD3)]
        [TestCase(82, 90, CreatureConstants.Character + "[14]", RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Character + "[13]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
