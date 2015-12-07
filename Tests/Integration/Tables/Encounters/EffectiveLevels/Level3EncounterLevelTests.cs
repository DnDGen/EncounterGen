using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level3EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 3);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 10, "1", MultiplierConstants.Triple)]
        [TestCase(11, 30, "2", MultiplierConstants.HalfAgain)]
        [TestCase(31, 70, "3", MultiplierConstants.Same)]
        [TestCase(71, 80, "4", MultiplierConstants.TwoThirds)]
        [TestCase(81, 90, "5", MultiplierConstants.Half)]
        [TestCase(91, 100, "6", MultiplierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
