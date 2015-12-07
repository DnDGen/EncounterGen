using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level17EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 17);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "13", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "14", MultiplierConstants.Triple)]
        [TestCase(11, 20, "15", MultiplierConstants.Double)]
        [TestCase(21, 30, "16", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "17", MultiplierConstants.Same)]
        [TestCase(71, 80, "18", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "19", MultiplierConstants.Half)]
        [TestCase(91, 100, "20", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
