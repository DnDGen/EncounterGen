using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level19CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 19, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 12, CreatureConstants.Commoner_Pilgrim + "[20]", RollConstants.OneD4Plus10,
            CreatureConstants.Warrior_Guard + "[20]", RollConstants.OneD3Plus1,
            CharacterClassConstants.Cleric + "[16]", RollConstants.One)]
        [TestCase(13, 25, CreatureConstants.Vampire + "[11]", RollConstants.One)]
        [TestCase(26, 37, CreatureConstants.Ghost + "[14]", RollConstants.One)]
        [TestCase(38, 50, CreatureConstants.Character + "[19]", RollConstants.One)]
        [TestCase(51, 62, CreatureConstants.Character + "[18]", RollConstants.OneD2)]
        [TestCase(63, 75, CreatureConstants.Character + "[17]", RollConstants.OneD3)]
        [TestCase(76, 87, CreatureConstants.Character + "[16]", RollConstants.OneD3Plus1)]
        [TestCase(88, 100, CreatureConstants.Character + "[15]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
