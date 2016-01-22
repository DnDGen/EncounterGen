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

        [TestCase(1, 6, CreatureConstants.Balor, RollConstants.One)]
        [TestCase(7, 12, CreatureConstants.PitFiend, RollConstants.One)]
        [TestCase(13, 24, CreatureConstants.Tarrasque, RollConstants.One)]
        [TestCase(25, 36, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(37, 48, CreatureConstants.Character + "[18]", RollConstants.OneD3)]
        [TestCase(49, 60, CreatureConstants.Character + "[19]", RollConstants.OneD2)]
        [TestCase(61, 72, CreatureConstants.Character + "[20]", RollConstants.One)]
        [TestCase(73, 78, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(79, 84, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(85, 100, CreatureConstants.Character + "[17]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
