using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Marsh.Warm.Night
{
    [TestFixture]
    public class Level19WarmMarshNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 19, EnvironmentConstants.WarmMarshNight);
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
        [TestCase(56, 66, CreatureConstants.Nightcrawler, RollConstants.OneD2)]
        [TestCase(67, 77, CreatureConstants.Nightwalker, RollConstants.OneD3Plus1)]
        [TestCase(78, 100, CreatureConstants.Character + "[16]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
