using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level18EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 18);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "14", MultiplierConstants.Quadruple)]
        [TestCase(6, 10, "15", MultiplierConstants.Triple)]
        [TestCase(11, 20, "16", MultiplierConstants.Double)]
        [TestCase(21, 30, "17", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "18", MultiplierConstants.Same)]
        [TestCase(71, 80, "19", MultiplierConstants.TwoThirds)]
        [TestCase(81, 100, "20", MultiplierConstants.Half)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
