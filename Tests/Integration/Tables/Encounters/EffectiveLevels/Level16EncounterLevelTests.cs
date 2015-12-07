using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level16EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 16);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "12", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "13", MultiplierConstants.Triple)]
        [TestCase(11, 20, "14", MultiplierConstants.Double)]
        [TestCase(21, 30, "15", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "16", MultiplierConstants.Same)]
        [TestCase(71, 80, "17", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "18", MultiplierConstants.Half)]
        [TestCase(91, 100, "19", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
