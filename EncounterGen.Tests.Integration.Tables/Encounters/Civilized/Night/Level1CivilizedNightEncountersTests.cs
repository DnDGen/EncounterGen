using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level1CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 1, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 33, CreatureConstants.Dog, RollConstants.One)]
        [TestCase(34, 67, CreatureConstants.Cat, RollConstants.One)]
        [TestCase(68, 100, CreatureConstants.Character + "[1]", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
