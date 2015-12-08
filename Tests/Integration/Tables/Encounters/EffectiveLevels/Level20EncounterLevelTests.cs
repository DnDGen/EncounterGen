using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.EffectiveLevels
{
    [TestFixture]
    public class Level20EncounterLevelTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXEncounterLevel, 20);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, "16", ModifierConstants.Quadruple)]
        [TestCase(6, 10, "17", ModifierConstants.Triple)]
        [TestCase(11, 20, "18", ModifierConstants.Double)]
        [TestCase(21, 30, "19", ModifierConstants.HalfAgain)]
        [TestCase(31, 100, "20", ModifierConstants.Same)]
        public override void Percentile(Int32 lower, Int32 upper, String type, String amount)
        {
            base.Percentile(lower, upper, type, amount);
        }
    }
}
