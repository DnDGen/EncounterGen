using EncounterGen.Domain.Mappers.Collections;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class CollectionTests : TableTests
    {
        [Inject]
        internal CollectionMapper CollectionMapper { get; set; }

        private Dictionary<string, IEnumerable<string>> table;

        [SetUp]
        public void CollectionSetup()
        {
            table = CollectionMapper.Map(tableName);
        }

        public abstract void EntriesAreComplete();

        protected void AssertEntriesAreComplete(IEnumerable<string> entries)
        {
            AssertNoDuplicates(entries);
            AssertNoDuplicates(table.Keys);
            AssertCollection(entries, table.Keys);
        }

        private void AssertCollection(IEnumerable<string> expected, IEnumerable<string> actual)
        {
            if (expected.Count() < 10)
            {
                Assert.That(actual, Is.EquivalentTo(expected));
            }
            else
            {
                var missing = expected.Except(actual);
                Assert.That(missing, Is.Empty, "missing");

                var extra = actual.Except(expected);
                Assert.That(extra, Is.Empty, "extra");
            }

            Assert.That(actual.Count(), Is.EqualTo(expected.Count()));
        }

        public virtual void Collection(string entry, params string[] items)
        {
            Assert.That(table.Keys, Contains.Item(entry));
            AssertCollection(items, table[entry]);
        }

        public virtual void DistinctCollection(string entry, params string[] items)
        {
            AssertNoDuplicates(items);
            Assert.That(table.Keys, Contains.Item(entry));
            AssertNoDuplicates(table[entry]);

            AssertCollection(items, table[entry]);
        }

        private void AssertNoDuplicates(IEnumerable<string> collection)
        {
            var duplicates = collection.Where(i => collection.Count(ii => ii == i) > 1).Distinct();
            Assert.That(duplicates, Is.Empty);
        }

        public virtual void OrderedCollection(string entry, params string[] items)
        {
            Collection(entry, items);
            Assert.That(table[entry], Is.EqualTo(items));
        }
    }
}
