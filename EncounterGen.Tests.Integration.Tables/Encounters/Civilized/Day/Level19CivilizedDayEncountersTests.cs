using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Day
{
    [TestFixture]
    public class Level19CivilizedDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 19, EnvironmentConstants.CivilizedDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, CreatureConstants.Commoner_Pilgrim + "[20]", RollConstants.OneD4Plus10,
            CreatureConstants.Warrior_Guard + "[20]", RollConstants.OneD3Plus1,
            CharacterClassConstants.Cleric + "[16]", RollConstants.One)]
        [TestCase(21, 36, CreatureConstants.Character + "[19]", RollConstants.One)]
        [TestCase(37, 52, CreatureConstants.Character + "[18]", RollConstants.OneD2)]
        [TestCase(53, 68, CreatureConstants.Character + "[17]", RollConstants.OneD3)]
        [TestCase(69, 84, CreatureConstants.Character + "[16]", RollConstants.OneD3Plus1)]
        [TestCase(85, 100, CreatureConstants.Character + "[15]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
