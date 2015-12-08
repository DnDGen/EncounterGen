using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level13EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 13);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "9", ModifierConstants.Quadruple)]
        [TestCase(6, 10, "10", ModifierConstants.Triple)]
        [TestCase(11, 20, "11", ModifierConstants.Double)]
        [TestCase(21, 30, "12", ModifierConstants.HalfAgain)]
        [TestCase(31, 70, "13", ModifierConstants.Same)]
        [TestCase(71, 80, "14", ModifierConstants.TwoThirds)]
        [TestCase(81, 90, "15", ModifierConstants.Half)]
        [TestCase(91, 100, "16", ModifierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
