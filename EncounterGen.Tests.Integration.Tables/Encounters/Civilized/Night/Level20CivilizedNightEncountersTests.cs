using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Night
{
    [TestFixture]
    public class Level20CivilizedNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 20, EnvironmentConstants.CivilizedNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 14, CreatureConstants.Vampire + "[12]", RollConstants.One)]
        [TestCase(15, 28, CreatureConstants.Ghost + "[15]", RollConstants.One)]
        [TestCase(29, 42, CreatureConstants.Character + "[20]", RollConstants.One)]
        [TestCase(43, 56, CreatureConstants.Character + "[19]", RollConstants.OneD2)]
        [TestCase(57, 70, CreatureConstants.Character + "[18]", RollConstants.OneD3)]
        [TestCase(71, 84, CreatureConstants.Character + "[17]", RollConstants.OneD3Plus1)]
        [TestCase(85, 100, CreatureConstants.Character + "[16]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
