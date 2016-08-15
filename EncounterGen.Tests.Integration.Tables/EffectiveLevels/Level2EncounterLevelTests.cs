using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.EffectiveLevels
{
    [TestFixture]
    public class Level2EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 2);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 20, 1, ModifierConstants.Double)]
        [TestCase(21, 70, 2, ModifierConstants.Same)]
        [TestCase(71, 80, 3, ModifierConstants.TwoThirds)]
        [TestCase(81, 90, 4, ModifierConstants.Half)]
        [TestCase(91, 100, 5, ModifierConstants.OneThird)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
