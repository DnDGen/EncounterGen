using EncounterGen.Mappers;
using Ninject;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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
    }
}
