using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level4CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 4, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 8, CreatureConstants.Commoner_Farmer + "[1d2+3]", RollConstants.OneD3)]
        [TestCase(9, 16, CreatureConstants.Commoner_Herder + "[1d2+3]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(17, 24, CreatureConstants.Commoner_Hunter + "[1d2+1]", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "[1d2+1]", RollConstants.One)]
        [TestCase(25, 32, CreatureConstants.Warrior_Bandit + "[1d2+1]", RollConstants.OneD3Plus1)]
        [TestCase(33, 40, CreatureConstants.NPC_Traveler + "[1d2+3]", RollConstants.OneD3)]
        [TestCase(41, 48, CreatureConstants.NPC_Traveler + "[1d2+1]", RollConstants.OneD3Plus1)]
        [TestCase(49, 56, CreatureConstants.Vampire + "[2]", RollConstants.One)]
        [TestCase(57, 64, CreatureConstants.Ghost + "[2]", RollConstants.One)]
        [TestCase(65, 72, CreatureConstants.Character + "[4]", RollConstants.One)]
        [TestCase(73, 80, CreatureConstants.Character + "[3]", RollConstants.OneD2)]
        [TestCase(81, 90, CreatureConstants.Character + "[2]", RollConstants.OneD3)]
        [TestCase(91, 100, CreatureConstants.Character + "[1]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
