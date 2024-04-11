using DnDGen.EncounterGen.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Selectors.Collections
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

        private string GetKey(EncounterSpecifications specifications)
        {
            return $"{specifications.Description}";
        }

        public IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(EncounterSpecifications specifications)
        {
            var key = GetKey(specifications);
            if (!cachedCollections.ContainsKey(key))
                cachedCollections[key] = internalSelector.SelectAllWeightedFrom(specifications);

            return cachedCollections[key];
        }

        public Dictionary<string, string> SelectRandomFrom(EncounterSpecifications specifications)
        {
            var weightedEncounters = SelectAllWeightedFrom(specifications);

            if (!weightedEncounters.Any())
                throw new ArgumentException($"No valid encounters exist for {specifications.Description}");

            return collectionSelector.SelectRandomFrom(weightedEncounters);
        }
    }
}
