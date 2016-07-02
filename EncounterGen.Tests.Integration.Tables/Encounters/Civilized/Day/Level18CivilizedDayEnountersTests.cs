using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Day
{
    [TestFixture]
    public class Level18CivilizedDayEnountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 18, EnvironmentConstants.CivilizedDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 14, CreatureConstants.Commoner_Pilgrim + "[1d2+17]", RollConstants.OneD4Plus10,
            CreatureConstants.Warrior_Guard + "[1d2+17]", RollConstants.OneD3Plus1,
            CharacterClassConstants.Cleric + "[15]", RollConstants.One)]
        [TestCase(15, 28, CreatureConstants.Warrior_Bandit + "[20]", RollConstants.OneD4Plus10,
            CharacterClassConstants.Fighter + "[13]", RollConstants.One)]
        [TestCase(29, 42, CreatureConstants.Character + "[18]", RollConstants.One)]
        [TestCase(43, 56, CreatureConstants.Character + "[17]", RollConstants.OneD2)]
        [TestCase(57, 70, CreatureConstants.Character + "[16]", RollConstants.OneD3)]
        [TestCase(71, 84, CreatureConstants.Character + "[15]", RollConstants.OneD3Plus1)]
        [TestCase(85, 100, CreatureConstants.Character + "[14]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
