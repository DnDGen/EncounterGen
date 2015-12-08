using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level11EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 11);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "7", ModifierConstants.Quadruple)]
        [TestCase(6, 10, "8", ModifierConstants.Triple)]
        [TestCase(11, 20, "9", ModifierConstants.Double)]
        [TestCase(21, 30, "10", ModifierConstants.HalfAgain)]
        [TestCase(31, 70, "11", ModifierConstants.Same)]
        [TestCase(71, 80, "12", ModifierConstants.TwoThirds)]
        [TestCase(81, 90, "13", ModifierConstants.Half)]
        [TestCase(91, 100, "14", ModifierConstants.OneThird)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
