using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level3CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 3, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 8, CreatureConstants.Dog, RollConstants.OneD6Plus5)]
        [TestCase(9, 16, CreatureConstants.Commoner_Farmer + "[1d2+1]", RollConstants.OneD3)]
        [TestCase(17, 24, CreatureConstants.Commoner_Herder + "[1d2+1]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(25, 32, CreatureConstants.Commoner_Hunter + "[1]", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "[1]", RollConstants.One)]
        [TestCase(33, 40, CreatureConstants.Warrior_Bandit + "[1]", RollConstants.OneD3Plus1)]
        [TestCase(41, 48, CreatureConstants.NPC_Traveler + "[1d2+1]", RollConstants.OneD3)]
        [TestCase(49, 56, CreatureConstants.NPC_Traveler + "[1]", RollConstants.OneD3Plus1)]
        [TestCase(57, 64, CreatureConstants.Vampire + "[1]", RollConstants.One)]
        [TestCase(65, 72, CreatureConstants.Ghost + "[1]", RollConstants.One)]
        [TestCase(73, 80, CreatureConstants.Character + "[3]", RollConstants.One)]
        [TestCase(81, 90, CreatureConstants.Character + "[2]", RollConstants.OneD2)]
        [TestCase(91, 100, CreatureConstants.Character + "[1]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
