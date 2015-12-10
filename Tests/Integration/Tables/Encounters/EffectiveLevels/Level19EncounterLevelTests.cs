using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level19EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 19);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, 15, ModifierConstants.Quadruple)]
        [TestCase(6, 10, 16, ModifierConstants.Triple)]
        [TestCase(11, 20, 17, ModifierConstants.Double)]
        [TestCase(21, 30, 18, ModifierConstants.HalfAgain)]
        [TestCase(31, 80, 19, ModifierConstants.Same)]
        [TestCase(81, 100, 20, ModifierConstants.TwoThirds)]
        public void Percentile(Int32 lower, Int32 upper, Int32 type, Int32 amount)
        {
            base.Percentile(lower, upper, type.ToString(), amount.ToString());
        }
    }
}
