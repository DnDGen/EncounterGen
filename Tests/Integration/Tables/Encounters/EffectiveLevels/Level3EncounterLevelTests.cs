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

        [TestCase(1, 10, 1, ModifierConstants.Triple)]
        [TestCase(11, 30, 2, ModifierConstants.HalfAgain)]
        [TestCase(31, 70, 3, ModifierConstants.Same)]
        [TestCase(71, 80, 4, ModifierConstants.TwoThirds)]
        [TestCase(81, 90, 5, ModifierConstants.Half)]
        [TestCase(91, 100, 6, ModifierConstants.OneThird)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
