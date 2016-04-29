using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level18EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 18);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, 14, ModifierConstants.Quadruple)]
        [TestCase(6, 10, 15, ModifierConstants.Triple)]
        [TestCase(11, 20, 16, ModifierConstants.Double)]
        [TestCase(21, 30, 17, ModifierConstants.HalfAgain)]
        [TestCase(31, 70, 18, ModifierConstants.Same)]
        [TestCase(71, 80, 19, ModifierConstants.TwoThirds)]
        [TestCase(81, 100, 20, ModifierConstants.Half)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
