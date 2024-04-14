using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Mappers.Collections;
using DnDGen.Infrastructure.Selectors.Collections;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables
{
    [TestFixture]
    public abstract class CollectionTests : TableTests
    {
        internal CollectionMapper collectionMapper;
        internal ICollectionSelector collectionSelector;
        internal IEncounterFormatter encounterFormatter;

        private Dictionary<string, IEnumerable<string>> table;

        [SetUp]
        public void CollectionSetup()
        {
            collectionMapper = GetNewInstanceOf<CollectionMapper>();
            collectionSelector = GetNewInstanceOf<ICollectionSelector>();
            encounterFormatter = GetNewInstanceOf<IEncounterFormatter>();

            table = collectionMapper.Map(tableName);
        }

        public abstract void EntriesAreComplete();

        protected void AssertEntriesAreComplete(IEnumerable<string> entries)
        {
            AssertNoDuplicates(entries);
            AssertNoDuplicates(table.Keys);
            AssertWholeCollection(entries, table.Keys);
        }

        protected IEnumerable<string> GetEntries()
        {
            return table.Keys;
        }

        protected IEnumerable<string> GetCollection(string entry)
        {
            return table[entry];
        }

        protected IEnumerable<string> ExplodeCollection(string name)
        {
            if (collectionSelector.IsCollection(tableName, name))
                return collectionSelector.Explode(tableName, name);

            return new[] { name };
        }

        protected IEnumerable<string> ExplodeCollections(IEnumerable<string> names)
        {
            var collection = new List<string>();

            foreach (var name in names)
            {
                var explodedCollection = ExplodeCollection(name);
                collection.AddRange(explodedCollection);
            }

            return collection.Distinct();
        }

        protected IEnumerable<string> GetAllCreaturesFromEncounters()
        {
            var allEncounters = collectionSelector.SelectAllFrom(TableNameConstants.EncounterGroups).Values.SelectMany(v => v);
            var allCreatures = allEncounters.SelectMany(e => encounterFormatter.SelectCreaturesAndAmountsFrom(e).Keys);

            //INFO: These are creatues that do not explicitly appear in encounters, but we wish to include them anyway
            var extraCreatures = new[]
            {
                CreatureConstants.DominatedCreature_CR1,
                CreatureConstants.DominatedCreature_CR2,
                CreatureConstants.DominatedCreature_CR3,
                CreatureConstants.DominatedCreature_CR5,
                CreatureConstants.DominatedCreature_CR6,
                CreatureConstants.Mephit_Air,
                CreatureConstants.Mephit_Dust,
                CreatureConstants.Mephit_Earth,
                CreatureConstants.Mephit_Fire,
                CreatureConstants.Mephit_Ice,
                CreatureConstants.Mephit_Magma,
                CreatureConstants.Mephit_Ooze,
                CreatureConstants.Mephit_Salt,
                CreatureConstants.Mephit_Steam,
                CreatureConstants.Mephit_Water,
            };

            allCreatures = allCreatures.Union(extraCreatures);

            return allCreatures;
        }

        protected void AssertWholeCollection(IEnumerable<string> expected, IEnumerable<string> actual)
        {
            if (actual.Count() == 1 && expected.Count() == 1)
                Assert.That(actual.Single(), Is.EqualTo(expected.Single()));

            var missing = expected.Except(actual);
            Assert.That(missing, Is.Empty, $"{missing.Count()} of {expected.Count()} missing");

            var extra = actual.Except(expected);
            Assert.That(extra, Is.Empty, $"{extra.Count()} extra");

            Assert.That(actual.Count, Is.EqualTo(expected.Count()));
            Assert.That(actual, Is.EquivalentTo(expected));
        }

        protected void AssertContainedCollection(IEnumerable<string> contained, IEnumerable<string> container)
        {
            var extra = contained.Except(container);
            Assert.That(extra, Is.Empty, $"{extra.Count()} extra in contained collection that are not in container");

            Assert.That(contained, Is.SubsetOf(container));
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

        private void AssertNoDuplicates(IEnumerable<string> collection)
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
