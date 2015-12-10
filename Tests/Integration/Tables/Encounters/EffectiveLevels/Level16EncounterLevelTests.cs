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

        [TestCase(1, 5, 12, ModifierConstants.Quadruple)]
        [TestCase(6, 10, 13, ModifierConstants.Triple)]
        [TestCase(11, 20, 14, ModifierConstants.Double)]
        [TestCase(21, 30, 15, ModifierConstants.HalfAgain)]
        [TestCase(31, 70, 16, ModifierConstants.Same)]
        [TestCase(71, 80, 17, ModifierConstants.TwoThirds)]
        [TestCase(81, 90, 18, ModifierConstants.Half)]
        [TestCase(91, 100, 19, ModifierConstants.OneThird)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
