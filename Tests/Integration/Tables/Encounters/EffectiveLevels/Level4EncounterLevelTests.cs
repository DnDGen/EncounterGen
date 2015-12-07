using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level4EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 4);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 10, "1", MultiplierConstants.Quadruple)]
        [TestCase(11, 20, "2", MultiplierConstants.Double)]
        [TestCase(21, 30, "3", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "4", MultiplierConstants.Same)]
        [TestCase(71, 80, "5", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "6", MultiplierConstants.Half)]
        [TestCase(91, 100, "7", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
