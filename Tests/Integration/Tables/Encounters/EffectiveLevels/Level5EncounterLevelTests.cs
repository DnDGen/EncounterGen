using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level5EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 5);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "2", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "2", MultiplierConstants.Triple)]
        [TestCase(11, 20, "3", MultiplierConstants.Double)]
        [TestCase(21, 30, "4", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "5", MultiplierConstants.Same)]
        [TestCase(71, 80, "6", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "7", MultiplierConstants.Half)]
        [TestCase(91, 100, "8", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
