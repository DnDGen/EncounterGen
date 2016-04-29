using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level14EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 14);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, 10, ModifierConstants.Quadruple)]
        [TestCase(6, 10, 11, ModifierConstants.Triple)]
        [TestCase(11, 20, 12, ModifierConstants.Double)]
        [TestCase(21, 30, 13, ModifierConstants.HalfAgain)]
        [TestCase(31, 70, 14, ModifierConstants.Same)]
        [TestCase(71, 80, 15, ModifierConstants.TwoThirds)]
        [TestCase(81, 90, 16, ModifierConstants.Half)]
        [TestCase(91, 100, 17, ModifierConstants.OneThird)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
