using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level12EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 12);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, 8, ModifierConstants.Quadruple)]
        [TestCase(6, 10, 9, ModifierConstants.Triple)]
        [TestCase(11, 20, 10, ModifierConstants.Double)]
        [TestCase(21, 30, 11, ModifierConstants.HalfAgain)]
        [TestCase(31, 70, 12, ModifierConstants.Same)]
        [TestCase(71, 80, 13, ModifierConstants.TwoThirds)]
        [TestCase(81, 90, 14, ModifierConstants.Half)]
        [TestCase(91, 100, 15, ModifierConstants.OneThird)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
