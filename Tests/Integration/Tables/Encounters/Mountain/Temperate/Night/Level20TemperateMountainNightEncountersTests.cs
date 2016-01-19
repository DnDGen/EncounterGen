using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Mountain.Temperate.Night
{
    [TestFixture]
    public class Level20TemperateMountainNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 20, EnvironmentConstants.TemperateMountainNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 7, CreatureConstants.Balor, RollConstants.One)]
        [TestCase(8, 14, CreatureConstants.PitFiend, RollConstants.One)]
        [TestCase(15, 28, CreatureConstants.Tarrasque, RollConstants.One)]
        [TestCase(29, 42, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(43, 56, CreatureConstants.Character + "[18]", RollConstants.OneD3)]
        [TestCase(57, 70, CreatureConstants.Character + "[19]", RollConstants.OneD2)]
        [TestCase(71, 84, CreatureConstants.Character + "[20]", RollConstants.One)]
        [TestCase(85, 100, CreatureConstants.Character + "[17]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
