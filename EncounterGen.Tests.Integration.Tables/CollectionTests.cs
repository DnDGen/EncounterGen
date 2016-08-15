using EncounterGen.Domain.Mappers.Collections;
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
        internal CollectionMapper CollectionMapper { get; set; }

        private Dictionary<string, IEnumerable<string>> table;

        [SetUp]
        public void CollectionSetup()
        {
            table = CollectionMapper.Map(tableName);
        }

        public abstract void EntriesAreComplete();

        protected IEnumerable<string> GetCollection(string name)
        {
            if (table.ContainsKey(name) == false)
                throw new ArgumentException($"Table {tableName} does not contain entry {name}");

            return table[name];
        }

        protected IEnumerable<string> GetAllCollections()
        {
            return table.Values.SelectMany(vv => vv);
        }

        protected void AssertEntriesAreComplete(IEnumerable<string> entries)
        {
            AssertNoDuplicates(entries);
            AssertNoDuplicates(table.Keys);
            AssertWholeCollection(entries, table.Keys);
        }

        protected void AssertWholeCollection(IEnumerable<string> expected, IEnumerable<string> actual)
        {
            if (expected.Count() < 10)
            {
                Assert.That(actual, Is.EquivalentTo(expected));
            }
            else
            {
                var missing = expected.Except(actual);
                Assert.That(missing, Is.Empty, $"{missing.Count()} missing");

                var extra = actual.Except(expected);
                Assert.That(extra, Is.Empty, $"{extra.Count()} extra");
            }

            Assert.That(actual.Count(), Is.EqualTo(expected.Count()));
        }

        protected void AssertContainedCollection(IEnumerable<string> contained, IEnumerable<string> container)
        {
            if (contained.Count() < 10)
            {
                Assert.That(contained, Is.SubsetOf(container));
            }
            else
            {
                var extra = contained.Except(container);
                Assert.That(extra, Is.Empty, $"{extra.Count()} extra in contained collection that are not in container");
            }
        }

        public virtual void Collection(string entry, params string[] items)
        {
            Assert.That(table.Keys, Contains.Item(entry));
            AssertWholeCollection(items, table[entry]);
        }

        public virtual void DistinctCollection(string entry, params string[] items)
        {
            AssertNoDuplicates(items);
            Assert.That(table.Keys, Contains.Item(entry));
            AssertNoDuplicates(table[entry]);

            AssertWholeCollection(items, table[entry]);
        }

        protected void ContainedCollection(string entry, params string[] items)
        {
            Assert.That(table.Keys, Contains.Item(entry));
            AssertContainedCollection(table[entry], items);
        }

        protected void AssertNoDuplicates(IEnumerable<string> collection)
        {
            var duplicates = collection.Where(i => collection.Count(ii => ii == i) > 1).Distinct();
            Assert.That(collection, Is.Unique, $"Duplicates: {string.Join(", ", duplicates)}");
        }

        public virtual void OrderedCollection(string entry, params string[] items)
        {
            Collection(entry, items);
            Assert.That(table[entry], Is.EqualTo(items));
        }
    }
}
