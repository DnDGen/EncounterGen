using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level19EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 19);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "15", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "16", MultiplierConstants.Triple)]
        [TestCase(11, 20, "17", MultiplierConstants.Double)]
        [TestCase(21, 30, "18", MultiplierConstants.HalfAgain)]
        [TestCase(31, 80, "19", MultiplierConstants.Same)]
        [TestCase(81, 100, "20", MultiplierConstants.TwoThirds)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
