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

        [TestCase(1, 18, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(19, 27, CreatureConstants.Cornugon, RollConstants.OneD3Plus1)]
        [TestCase(28, 36, CreatureConstants.Gelugon, RollConstants.OneD6Plus5)]
        [TestCase(37, 45, CreatureConstants.Golem_Stone_Greater, RollConstants.OneD3Plus1)]
        [TestCase(46, 54, CreatureConstants.Nightcrawler, RollConstants.OneD2)]
        [TestCase(55, 63, CreatureConstants.Nightwalker, RollConstants.OneD3Plus1)]
        [TestCase(64, 72, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(73, 81, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(82, 100, CreatureConstants.Character + "[16]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
