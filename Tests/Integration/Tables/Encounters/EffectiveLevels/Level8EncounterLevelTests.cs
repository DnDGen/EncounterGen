using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level8EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 8);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "4", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "5", MultiplierConstants.Triple)]
        [TestCase(11, 20, "6", MultiplierConstants.Double)]
        [TestCase(21, 30, "7", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "8", MultiplierConstants.Same)]
        [TestCase(71, 80, "9", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "10", MultiplierConstants.Half)]
        [TestCase(91, 100, "11", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
