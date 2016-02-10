using EncounterGen.Mappers;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class PercentileTests : TableTests
    {
        [Inject]
        public PercentileMapper PercentileMapper { get; set; }

        private Dictionary<int, string> table;

        [SetUp]
        public void PercentileSetup()
        {
            table = PercentileMapper.Map(tableName);
        }

        public abstract void TableIsComplete();

        protected void AssertTableIsComplete()
        {
            for (var roll = 100; roll > 0; roll--)
                Assert.That(table.Keys, Contains.Item(roll), tableName);

            Assert.That(table.Keys.Count, Is.EqualTo(100), tableName);
        }

        public virtual void Percentile(string content, int roll)
        {
            AssertPercentile(content, roll);
        }

        public virtual void Percentile(string content, int lower, int upper)
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

        private void AssertPercentile(string content, int roll)
        {
            Assert.That(table.Keys, Contains.Item(roll), tableName);

            var message = string.Format("Roll: {0}", roll);
            Assert.That(table[roll], Is.EqualTo(content), message);
        }
    }
}
