using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Marsh.Temperate.Night
{
    [TestFixture]
    public class Level18TemperateMarshNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 18, EnvironmentConstants.TemperateMarshNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 22, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(23, 33, CreatureConstants.Marilith, RollConstants.OneD2)]
        [TestCase(34, 44, CreatureConstants.Nightcrawler, RollConstants.One)]
        [TestCase(45, 55, CreatureConstants.Nightwing, RollConstants.OneD4Plus2)]
        [TestCase(56, 66, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(67, 77, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(78, 100, CreatureConstants.Character + "[15]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
