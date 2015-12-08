using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level9EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 9);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "5", ModifierConstants.Quadruple)]
        [TestCase(6, 10, "6", ModifierConstants.Triple)]
        [TestCase(11, 20, "7", ModifierConstants.Double)]
        [TestCase(21, 30, "8", ModifierConstants.HalfAgain)]
        [TestCase(31, 70, "9", ModifierConstants.Same)]
        [TestCase(71, 80, "10", ModifierConstants.TwoThirds)]
        [TestCase(81, 90, "11", ModifierConstants.Half)]
        [TestCase(91, 100, "12", ModifierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
