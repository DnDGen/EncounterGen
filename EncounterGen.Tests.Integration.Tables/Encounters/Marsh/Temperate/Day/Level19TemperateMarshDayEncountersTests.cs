using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Marsh.Temperate.Day
{
    [TestFixture]
    public class Level19TemperateMarshDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 19, EnvironmentConstants.TemperateMarshDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 22, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(23, 33, CreatureConstants.Cornugon, RollConstants.OneD3Plus1)]
        [TestCase(34, 44, CreatureConstants.Gelugon, RollConstants.OneD6Plus5)]
        [TestCase(45, 55, CreatureConstants.Golem_Stone_Greater, RollConstants.OneD3Plus1)]
        [TestCase(56, 66, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(67, 77, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(78, 100, CreatureConstants.Character + "[16]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
