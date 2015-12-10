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
            Assert.That(entries, Is.EquivalentTo(table.Keys));
        }

        public virtual void Collection(String entry, params String[] items)
        {
            Assert.That(table.Keys, Contains.Item(entry));
            Assert.That(table[entry], Is.EquivalentTo(items));
        }

        public virtual void OrderedCollection(String entry, params String[] items)
        {
            Collection(entry, items);

            Assert.That(table.Count, Is.EqualTo(items.Length));

            for (var i = 0; i < items.Length; i++)
                Assert.That(table[entry].ElementAt(i), Is.EqualTo(items[i]));
        }
    }
}
