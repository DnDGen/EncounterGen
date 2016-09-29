using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal class EncounterCollectionSelectorCachingProxy : IEncounterCollectionSelector
    {
        private readonly IEncounterCollectionSelector internalSelector;
        private readonly Dictionary<string, IEnumerable<Dictionary<string, string>>> cachedCollections;
        private readonly ICollectionSelector collectionSelector;

        public EncounterCollectionSelectorCachingProxy(IEncounterCollectionSelector internalSelector, ICollectionSelector collectionSelector)
        {
            this.internalSelector = internalSelector;
            this.collectionSelector = collectionSelector;

            cachedCollections = new Dictionary<string, IEnumerable<Dictionary<string, string>>>();
        }

        private string GetKey(int level, string environment, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            return $"{level}{environment}{temperature}{timeOfDay}{string.Join(",", creatureTypeFilters)}";
        }

        public IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(int level, string environment, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            var key = GetKey(level, environment, temperature, timeOfDay, creatureTypeFilters);
            if (!cachedCollections.ContainsKey(key))
                cachedCollections[key] = internalSelector.SelectAllWeightedFrom(level, environment, temperature, timeOfDay, creatureTypeFilters);

            return cachedCollections[key];
        }

        public Dictionary<string, string> SelectRandomFrom(int level, string environment, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            var weightedEncounters = SelectAllWeightedFrom(level, environment, temperature, timeOfDay, creatureTypeFilters);

            if (!weightedEncounters.Any())
                throw new ArgumentException($"No valid level {level} encounters exist for {temperature} {environment} {timeOfDay}");

            return collectionSelector.SelectRandomFrom(weightedEncounters);
        }
    }
}
