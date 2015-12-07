using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level6EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 6);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "2", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "3", MultiplierConstants.Triple)]
        [TestCase(11, 20, "4", MultiplierConstants.Double)]
        [TestCase(21, 30, "5", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "6", MultiplierConstants.Same)]
        [TestCase(71, 80, "7", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "8", MultiplierConstants.Half)]
        [TestCase(91, 100, "9", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
