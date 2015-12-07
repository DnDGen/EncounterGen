using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level7EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 7);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "3", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "4", MultiplierConstants.Triple)]
        [TestCase(11, 20, "5", MultiplierConstants.Double)]
        [TestCase(21, 30, "6", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "7", MultiplierConstants.Same)]
        [TestCase(71, 80, "8", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "9", MultiplierConstants.Half)]
        [TestCase(91, 100, "10", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
