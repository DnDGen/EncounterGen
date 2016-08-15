using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Selectors
{
    internal class EncounterCollectionSelector : IEncounterCollectionSelector
    {
        private readonly ICollectionSelector collectionSelector;
        private Dictionary<string, IEnumerable<string>> cachedCollections;

        public EncounterCollectionSelector(ICollectionSelector collectionSelector)
        {
            this.collectionSelector = collectionSelector;

            cachedCollections = new Dictionary<string, IEnumerable<string>>();
        }

        public IEnumerable<Dictionary<string, string>> SelectAllFrom(int level, string environment, string temperature, string timeOfDay)
        {
            var weightedEncounters = GetWeightedEncounters(level, environment, temperature, timeOfDay);
            var encounterTypesAndAmounts = weightedEncounters.Distinct().Select(e => ParseTypesAndAmounts(e));

            return encounterTypesAndAmounts;
        }

        public IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(int level, string environment, string temperature, string timeOfDay)
        {
            var weightedEncounters = GetWeightedEncounters(level, environment, temperature, timeOfDay);
            var weightedEncounterTypesAndAmounts = weightedEncounters.Select(e => ParseTypesAndAmounts(e));

            return weightedEncounterTypesAndAmounts;
        }

        public Dictionary<string, string> SelectFrom(int level, string environment, string temperature, string timeOfDay)
        {
            var weightedEncounters = GetWeightedEncounters(level, environment, temperature, timeOfDay);
            var encounter = collectionSelector.SelectRandomFrom(weightedEncounters);
            var encounterTypesAndAmounts = ParseTypesAndAmounts(encounter);

            return encounterTypesAndAmounts;
        }

        private IEnumerable<string> GetWeightedEncounters(int level, string environment, string temperature, string timeOfDay)
        {
            if (environment == EnvironmentConstants.Civilized)
            {
                temperature = string.Empty;
            }
            else if (environment == EnvironmentConstants.Dungeon)
            {
                timeOfDay = string.Empty;
            }

            var key = $"{level}{environment}{temperature}{timeOfDay}";
            if (cachedCollections.ContainsKey(key) == false)
            {
                var collection = GetNewWeightedEncounters(level, environment, temperature, timeOfDay);
                cachedCollections[key] = collection;
            }

            return cachedCollections[key];
        }

        private IEnumerable<string> GetNewWeightedEncounters(int level, string environment, string temperature, string timeOfDay)
        {
            var weightedEncounters = new List<string>();

            var temperatureEncounters = Enumerable.Empty<string>();
            var magicEncounters = Enumerable.Empty<string>();
            var landEncounters = Enumerable.Empty<string>();
            var specificEncounters = Enumerable.Empty<string>();
            var environmentEncounters = collectionSelector.SelectFrom(TableNameConstants.EncounterGroups, environment);
            var allEncounters = environmentEncounters;

            if (environment != EnvironmentConstants.Civilized)
            {
                magicEncounters = collectionSelector.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Magic);
                landEncounters = collectionSelector.SelectFrom(TableNameConstants.EncounterGroups, GroupConstants.Land);
                temperatureEncounters = collectionSelector.SelectFrom(TableNameConstants.EncounterGroups, temperature);
                specificEncounters = collectionSelector.SelectFrom(TableNameConstants.EncounterGroups, temperature + environment);

                var wildlife = temperatureEncounters.Union(magicEncounters).Union(landEncounters).Union(specificEncounters);
                allEncounters = allEncounters.Union(wildlife);
            }

            var validEncounters = GetValidEncounters(allEncounters, level, timeOfDay);
            weightedEncounters.AddRange(validEncounters);

            var validNonMagicEncounters = validEncounters.Except(magicEncounters);
            weightedEncounters.AddRange(validNonMagicEncounters);

            var validEnvironmentEncounters = validEncounters.Intersect(environmentEncounters);
            weightedEncounters.AddRange(validEnvironmentEncounters);

            var validTemperatureEncounters = validEncounters.Intersect(temperatureEncounters);
            weightedEncounters.AddRange(validTemperatureEncounters);

            var validSpecificEncounters = validEncounters.Intersect(specificEncounters);
            weightedEncounters.AddRange(validSpecificEncounters);
            weightedEncounters.AddRange(validSpecificEncounters);

            return weightedEncounters;
        }

        private IEnumerable<string> GetValidEncounters(IEnumerable<string> source, int level, string timeOfDay)
        {
            var levelEncounters = collectionSelector.SelectFrom(TableNameConstants.EncounterGroups, level.ToString());
            var timeOfDayEncounters = collectionSelector.SelectFrom(TableNameConstants.EncounterGroups, timeOfDay);

            var validEncounters = source.Intersect(levelEncounters);

            if (timeOfDayEncounters.Any())
                validEncounters = validEncounters.Intersect(timeOfDayEncounters);

            return validEncounters;
        }

        private Dictionary<string, string> ParseTypesAndAmounts(string encounter)
        {
            var typeAndAmountPairs = encounter.Split(',');
            var typesAndAmounts = new Dictionary<string, string>();

            foreach (var pair in typeAndAmountPairs)
            {
                var sections = pair.Split('/');
                typesAndAmounts[sections[0]] = sections[1];
            }

            return typesAndAmounts;
        }
    }
}
