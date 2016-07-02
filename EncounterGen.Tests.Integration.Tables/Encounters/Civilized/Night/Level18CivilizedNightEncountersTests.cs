using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level18CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 18, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 11, CreatureConstants.Ghost + "[13]", RollConstants.One)]
        [TestCase(12, 22, CreatureConstants.Commoner_Pilgrim + "[1d2+17]", RollConstants.OneD4Plus10,
            CreatureConstants.Warrior_Guard + "[1d2+17]", RollConstants.OneD3Plus1,
            CharacterClassConstants.Cleric + "[15]", RollConstants.One)]
        [TestCase(23, 33, CreatureConstants.Warrior_Bandit + "[20]", RollConstants.OneD4Plus10,
            CharacterClassConstants.Fighter + "[13]", RollConstants.One)]
        [TestCase(34, 44, CreatureConstants.Vampire + "[10]", RollConstants.One)]
        [TestCase(45, 55, CreatureConstants.Character + "[18]", RollConstants.One)]
        [TestCase(56, 66, CreatureConstants.Character + "[17]", RollConstants.OneD2)]
        [TestCase(67, 77, CreatureConstants.Character + "[16]", RollConstants.OneD3)]
        [TestCase(78, 88, CreatureConstants.Character + "[15]", RollConstants.OneD3Plus1)]
        [TestCase(89, 100, CreatureConstants.Character + "[14]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
