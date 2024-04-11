using DnDGen.Infrastructure.Mappers.Percentiles;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class PercentileTests : TableTests
    {
        internal PercentileMapper percentileMapper;

        private Dictionary<int, string> table;

        [SetUp]
        public void PercentileSetup()
        {
            percentileMapper = GetNewInstanceOf<PercentileMapper>();

            table = percentileMapper.Map(tableName);
        }

        public abstract void TableIsComplete();

        protected void AssertTableIsComplete()
        {
            for (var roll = 100; roll > 0; roll--)
                Assert.That(table.Keys, Contains.Item(roll), tableName);

            Assert.That(table.Keys.Count, Is.EqualTo(100), tableName);
        }

        public virtual void Percentile(int lower, int upper, int content)
        {
            for (var roll = lower; roll <= upper; roll++)
                AssertPercentile(content, roll);

            if (lower > 1)
            {
                var message = string.Format("Roll: {0}", lower - 1);
                Assert.That(table[lower - 1], Is.Not.EqualTo(content), message);
            }

            if (upper < 100)
            {
                var message = string.Format("Roll: {0}", upper + 1);
                Assert.That(table[upper + 1], Is.Not.EqualTo(content), message);
            }
        }

        private void AssertPercentile(int content, int roll)
        {
            Assert.That(table.Keys, Contains.Item(roll), tableName);

            var message = string.Format("Roll: {0}", roll);
            Assert.That(table[roll], Is.EqualTo(content.ToString()), message);
        }
    }
}
