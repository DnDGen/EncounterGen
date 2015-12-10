using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level15EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 15);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, 11, ModifierConstants.Quadruple)]
        [TestCase(6, 10, 12, ModifierConstants.Triple)]
        [TestCase(11, 20, 13, ModifierConstants.Double)]
        [TestCase(21, 30, 14, ModifierConstants.HalfAgain)]
        [TestCase(31, 70, 15, ModifierConstants.Same)]
        [TestCase(71, 80, 16, ModifierConstants.TwoThirds)]
        [TestCase(81, 90, 17, ModifierConstants.Half)]
        [TestCase(91, 100, 18, ModifierConstants.OneThird)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
