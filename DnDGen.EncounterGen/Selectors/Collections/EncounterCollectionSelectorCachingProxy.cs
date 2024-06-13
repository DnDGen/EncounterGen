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
        private readonly Dictionary<string, IEnumerable<string>> cachedEncounterCollections;
        private readonly ICollectionSelector collectionSelector;

        public EncounterCollectionSelectorCachingProxy(IEncounterCollectionSelector internalSelector, ICollectionSelector collectionSelector)
        {
            this.internalSelector = internalSelector;
            this.collectionSelector = collectionSelector;

            cachedCollections = new Dictionary<string, IEnumerable<Dictionary<string, string>>>();
            cachedEncounterCollections = new Dictionary<string, IEnumerable<string>>();
        }

        private string GetKey(EncounterSpecifications specifications)
        {
            return $"{specifications.Description}";
        }

        public IEnumerable<string> SelectPossibleTemperatures(string environment)
        {
            return internalSelector.SelectPossibleTemperatures(environment);
        }

        public IEnumerable<string> SelectPossibleTimesOfDay(string environment, string temperature)
        {
            return internalSelector.SelectPossibleTimesOfDay(environment, temperature);
        }

        public IEnumerable<int> SelectPossibleLevels(string environment, string temperature, string timeOfDay)
        {
            return internalSelector.SelectPossibleLevels(environment, temperature, timeOfDay);
        }

        public IEnumerable<bool> SelectPossibleAllowAquatic(string environment, string temperature, string timeOfDay, int level)
        {
            return internalSelector.SelectPossibleAllowAquatic(environment, temperature, timeOfDay, level);
        }

        public IEnumerable<bool> SelectPossibleAllowUnderground(string environment, string temperature, string timeOfDay, int level, bool allowAquatic)
        {
            return internalSelector.SelectPossibleAllowUnderground(environment, temperature, timeOfDay, level, allowAquatic);
        }

        public IEnumerable<string> SelectPossibleFilters(string environment, string temperature, string timeOfDay, int level, bool allowAquatic, bool allowUnderground)
        {
            return internalSelector.SelectPossibleFilters(environment, temperature, timeOfDay, level, allowAquatic, allowUnderground);
        }

        public string SelectRandomEncounterFrom(EncounterSpecifications encounterSpecifications)
        {
            var weightedEncounters = SelectAllWeightedEncountersFrom(encounterSpecifications);

            if (!weightedEncounters.Any())
                throw new ArgumentException($"No valid encounters exist for {encounterSpecifications.Description}");

            return collectionSelector.SelectRandomFrom(weightedEncounters);
        }

        public IEnumerable<string> SelectAllWeightedEncountersFrom(EncounterSpecifications encounterSpecifications)
        {
            var key = GetKey(encounterSpecifications);
            if (!cachedEncounterCollections.ContainsKey(key))
                cachedEncounterCollections[key] = internalSelector.SelectAllWeightedEncountersFrom(encounterSpecifications);

            return cachedEncounterCollections[key];
        }

        public IEnumerable<string> SelectPossibleEncountersFrom(
            string environment = "",
            string temperature = "",
            string timeOfDay = "",
            int level = 0,
            bool? allowAquatic = null,
            bool? allowUnderground = null,
            params string[] filters)
        {
            return internalSelector.SelectPossibleEncountersFrom(environment, temperature, timeOfDay, level, allowAquatic, allowUnderground, filters);
        }
    }
}
