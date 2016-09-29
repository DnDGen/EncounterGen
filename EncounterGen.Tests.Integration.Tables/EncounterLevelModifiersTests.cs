using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public class EncounterLevelModifiersTests : PercentileTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.EncounterLevelModifiers;
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 2, -5)]
        [TestCase(3, 8, -4)]
        [TestCase(9, 15, -3)]
        [TestCase(16, 23, -2)]
        [TestCase(24, 32, -1)]
        [TestCase(33, 82, 0)]
        [TestCase(83, 86, 1)]
        [TestCase(87, 90, 2)]
        [TestCase(91, 94, 3)]
        [TestCase(95, 97, 4)]
        [TestCase(98, 100, 5)]
        public override void Percentile(int lower, int upper, int content)
        {
            base.Percentile(lower, upper, content);
        }
    }
}
