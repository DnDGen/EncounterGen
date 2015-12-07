using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level12EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 12);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "8", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "9", MultiplierConstants.Triple)]
        [TestCase(11, 20, "10", MultiplierConstants.Double)]
        [TestCase(21, 30, "11", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "12", MultiplierConstants.Same)]
        [TestCase(71, 80, "13", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "14", MultiplierConstants.Half)]
        [TestCase(91, 100, "15", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
