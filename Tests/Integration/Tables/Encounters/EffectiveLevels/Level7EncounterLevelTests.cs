using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level7EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 7);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, 3, ModifierConstants.Quadruple)]
        [TestCase(6, 10, 4, ModifierConstants.Triple)]
        [TestCase(11, 20, 5, ModifierConstants.Double)]
        [TestCase(21, 30, 6, ModifierConstants.HalfAgain)]
        [TestCase(31, 70, 7, ModifierConstants.Same)]
        [TestCase(71, 80, 8, ModifierConstants.TwoThirds)]
        [TestCase(81, 90, 9, ModifierConstants.Half)]
        [TestCase(91, 100, 10, ModifierConstants.OneThird)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
