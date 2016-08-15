using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.EffectiveLevels
{
    [TestFixture]
    public class Level8EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 8);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, 4, ModifierConstants.Quadruple)]
        [TestCase(6, 10, 5, ModifierConstants.Triple)]
        [TestCase(11, 20, 6, ModifierConstants.Double)]
        [TestCase(21, 30, 7, ModifierConstants.HalfAgain)]
        [TestCase(31, 70, 8, ModifierConstants.Same)]
        [TestCase(71, 80, 9, ModifierConstants.TwoThirds)]
        [TestCase(81, 90, 10, ModifierConstants.Half)]
        [TestCase(91, 100, 11, ModifierConstants.OneThird)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
