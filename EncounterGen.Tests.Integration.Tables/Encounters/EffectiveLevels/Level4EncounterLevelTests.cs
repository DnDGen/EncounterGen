using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level4EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 4);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 10, 1, ModifierConstants.Quadruple)]
        [TestCase(11, 20, 2, ModifierConstants.Double)]
        [TestCase(21, 30, 3, ModifierConstants.HalfAgain)]
        [TestCase(31, 70, 4, ModifierConstants.Same)]
        [TestCase(71, 80, 5, ModifierConstants.TwoThirds)]
        [TestCase(81, 90, 6, ModifierConstants.Half)]
        [TestCase(91, 100, 7, ModifierConstants.OneThird)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
