using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level15EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 15);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "11", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "12", MultiplierConstants.Triple)]
        [TestCase(11, 20, "13", MultiplierConstants.Double)]
        [TestCase(21, 30, "14", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "15", MultiplierConstants.Same)]
        [TestCase(71, 80, "16", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "17", MultiplierConstants.Half)]
        [TestCase(91, 100, "18", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
