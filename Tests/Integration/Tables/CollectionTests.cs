using EncounterGen.Mappers;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class CollectionTests : TableTests
    {
        [Inject]
        public CollectionMapper CollectionMapper { get; set; }

        private Dictionary<String, IEnumerable<String>> table;

        [SetUp]
        public void CollectionSetup()
        {
            table = CollectionMapper.Map(tableName);
        }

        public abstract void EntriesAreComplete();

        protected void AssertEntriesAreComplete(IEnumerable<String> entries)
        {
            AssertCollections(entries, table.Keys);
        }

        private void AssertCollections(IEnumerable<String> expected, IEnumerable<String> actual)
        {
            var missing = expected.Except(actual);
            Assert.That(missing, Is.Empty, "missing");

            var extra = actual.Except(expected);
            Assert.That(extra, Is.Empty, "extra");

            Assert.That(actual.Count(), Is.EqualTo(expected.Count()));
        }

        public virtual void Collection(String entry, params String[] items)
        {
            Assert.That(table.Keys, Contains.Item(entry));
            AssertCollections(items, table[entry]);
        }

        public virtual void OrderedCollection(String entry, params String[] items)
        {
            Collection(entry, items);

            for (var i = 0; i < items.Length; i++)
                Assert.That(table[entry].ElementAt(i), Is.EqualTo(items[i]));
        }
    }
}
