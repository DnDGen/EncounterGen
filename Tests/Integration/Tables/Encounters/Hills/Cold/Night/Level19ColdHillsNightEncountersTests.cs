using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Cold.Night
{
    [TestFixture]
    public class Level19ColdHillsNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 19, EnvironmentConstants.ColdHillsNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 30, CreatureConstants.Cornugon, RollConstants.OneD3Plus1)]
        [TestCase(31, 40, CreatureConstants.Gelugon, RollConstants.OneD6Plus5)]
        [TestCase(41, 50, CreatureConstants.Golem_Stone_Greater, RollConstants.OneD3Plus1)]
        [TestCase(51, 60, CreatureConstants.Nightcrawler, RollConstants.OneD2)]
        [TestCase(61, 70, CreatureConstants.Nightwalker, RollConstants.OneD3Plus1)]
        [TestCase(71, 100, CreatureConstants.Character + "[16]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
