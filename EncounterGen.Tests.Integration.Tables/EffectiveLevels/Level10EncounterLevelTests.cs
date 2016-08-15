using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.EffectiveLevels
{
    [TestFixture]
    public class Level10EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 10);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, 6, ModifierConstants.Quadruple)]
        [TestCase(6, 10, 7, ModifierConstants.Triple)]
        [TestCase(11, 20, 8, ModifierConstants.Double)]
        [TestCase(21, 30, 9, ModifierConstants.HalfAgain)]
        [TestCase(31, 70, 10, ModifierConstants.Same)]
        [TestCase(71, 80, 11, ModifierConstants.TwoThirds)]
        [TestCase(81, 90, 12, ModifierConstants.Half)]
        [TestCase(91, 100, 13, ModifierConstants.OneThird)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
