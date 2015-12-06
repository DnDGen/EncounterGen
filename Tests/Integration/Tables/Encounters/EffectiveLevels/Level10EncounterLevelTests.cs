using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level10EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 10);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "6", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "7", MultiplierConstants.Triple)]
        [TestCase(11, 20, "8", MultiplierConstants.Double)]
        [TestCase(21, 30, "9", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "10", MultiplierConstants.Same)]
        [TestCase(71, 80, "11", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "12", MultiplierConstants.Half)]
        [TestCase(91, 100, "13", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
