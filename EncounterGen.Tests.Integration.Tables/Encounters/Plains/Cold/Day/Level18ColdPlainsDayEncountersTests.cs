using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Plains.Cold.Day
{
    [TestFixture]
    public class Level18ColdPlainsDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 18, EnvironmentConstants.ColdPlainsDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 28, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(29, 42, CreatureConstants.Marilith, RollConstants.OneD2)]
        [TestCase(43, 56, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(57, 70, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(71, 100, CreatureConstants.Character + "[15]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
