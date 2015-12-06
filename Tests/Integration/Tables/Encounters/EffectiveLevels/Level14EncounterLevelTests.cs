using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level14EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 14);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "10", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "11", MultiplierConstants.Triple)]
        [TestCase(11, 20, "12", MultiplierConstants.Double)]
        [TestCase(21, 30, "13", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "14", MultiplierConstants.Same)]
        [TestCase(71, 80, "15", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "16", MultiplierConstants.Half)]
        [TestCase(91, 100, "17", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
