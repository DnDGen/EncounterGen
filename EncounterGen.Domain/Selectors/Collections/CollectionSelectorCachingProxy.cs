using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal class CollectionSelectorCachingProxy : ICollectionSelector
    {
        private readonly ICollectionSelector internalSelector;
        private Dictionary<string, IEnumerable<string>> cachedCollections;

        public CollectionSelectorCachingProxy(ICollectionSelector internalSelector)
        {
            this.internalSelector = internalSelector;

            cachedCollections = new Dictionary<string, IEnumerable<string>>();
        }

        public IEnumerable<string> Explode(string tableName, string name)
        {
            var key = tableName + name;

            if (!cachedCollections.ContainsKey(key))
                cachedCollections[key] = internalSelector.Explode(tableName, name);

            return cachedCollections[key];
        }

        public IEnumerable<string> ExplodeInto(string tableName, string name, string intoTableName)
        {
            var key = tableName + name + intoTableName;

            if (!cachedCollections.ContainsKey(key))
                cachedCollections[key] = internalSelector.ExplodeInto(tableName, name, intoTableName);

            return cachedCollections[key];
        }

        public bool IsGroup(string tableName, string name)
        {
            return internalSelector.IsGroup(tableName, name);
        }

        public IEnumerable<string> SelectFrom(string tableName, string name)
        {
            return internalSelector.SelectFrom(tableName, name);
        }

        public T SelectRandomFrom<T>(IEnumerable<T> collection)
        {
            return internalSelector.SelectRandomFrom(collection);
        }
    }
}
