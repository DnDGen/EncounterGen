using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal class EncounterCollectionSelector : IEncounterCollectionSelector
    {
        private readonly ICollectionSelector collectionSelector;
        private readonly IAmountSelector amountSelector;
        private readonly IEncounterSelector encounterSelector;

        public EncounterCollectionSelector(ICollectionSelector collectionSelector, IAmountSelector amountSelector, IEncounterSelector encounterSelector)
        {
            this.collectionSelector = collectionSelector;
            this.amountSelector = amountSelector;
            this.encounterSelector = encounterSelector;
        }

        public IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(int level, string environment, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            var weightedEncounters = GetWeightedEncounters(level, environment, temperature, timeOfDay, creatureTypeFilters);
            var weightedEncounterTypesAndAmounts = weightedEncounters.Select(e => encounterSelector.SelectCreaturesAndAmountsFrom(e));

            return weightedEncounterTypesAndAmounts;
        }

        public Dictionary<string, string> SelectRandomFrom(int level, string environment, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            var weightedEncounters = SelectAllWeightedFrom(level, environment, temperature, timeOfDay, creatureTypeFilters);

            if (!weightedEncounters.Any())
                throw new ArgumentException($"No valid level {level} encounters exist for {temperature} {environment} {timeOfDay}");

            return collectionSelector.SelectRandomFrom(weightedEncounters);
        }

        private IEnumerable<string> GetWeightedEncounters(int level, string environment, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            var isCivilized = environment == EnvironmentConstants.Civilized;

            if (isCivilized)
            {
                temperature = string.Empty;
            }
            else if (environment == EnvironmentConstants.Dungeon)
            {
                timeOfDay = string.Empty;
            }

            var magicEncounters = GetValidEncountersFromCreatureGroup(GroupConstants.Magic, level, timeOfDay, isCivilized, creatureTypeFilters);
            var dragonEncounters = GetValidEncountersFromCreatureGroup(CreatureConstants.Types.Dragon, level, timeOfDay, isCivilized, creatureTypeFilters);
            var landEncounters = GetValidEncountersFromCreatureGroup(GroupConstants.Land, level, timeOfDay, isCivilized, creatureTypeFilters);
            var temperatureEncounters = GetValidEncountersFromCreatureGroup(temperature, level, timeOfDay, isCivilized, creatureTypeFilters);
            var environmentEncounters = GetValidEncountersFromCreatureGroup(environment, level, timeOfDay, isCivilized, creatureTypeFilters);

            var specificEnvironmentEncounters = Enumerable.Empty<string>();
            var specificEnvironment = temperature + environment;

            if (specificEnvironment != environment && specificEnvironment != temperature)
                specificEnvironmentEncounters = GetValidEncountersFromCreatureGroup(specificEnvironment, level, timeOfDay, isCivilized, creatureTypeFilters);

            //INFO: This is done to remove duplicate encounters from these lists
            var allEncounters = magicEncounters.Union(dragonEncounters)
                .Union(landEncounters)
                .Union(environmentEncounters)
                .Union(temperatureEncounters)
                .Union(specificEnvironmentEncounters);

            var weightedEncounters = new List<string>();
            weightedEncounters.AddRange(allEncounters);

            var commonEncounters = allEncounters.Except(magicEncounters).Except(dragonEncounters);
            weightedEncounters.AddRange(commonEncounters);

            weightedEncounters.AddRange(environmentEncounters);
            weightedEncounters.AddRange(temperatureEncounters);
            weightedEncounters.AddRange(specificEnvironmentEncounters);
            weightedEncounters.AddRange(specificEnvironmentEncounters);

            return weightedEncounters;
        }

        private IEnumerable<string> GetEncountersFromCreatureGroup(string creatureGroup)
        {
            return collectionSelector.ExplodeInto(TableNameConstants.CreatureGroups, creatureGroup, TableNameConstants.EncounterGroups);
        }

        private IEnumerable<string> GetValidEncountersFromCreatureGroup(string creatureGroup, int level, string timeOfDay, bool isCivilized, params string[] creatureTypeFilters)
        {
            var encounters = GetEncountersFromCreatureGroup(creatureGroup);
            var validEncounters = GetValidEncounters(encounters, level, timeOfDay, creatureTypeFilters);

            if (isCivilized)
            {
                var wildlife = GetValidEncountersFromCreatureGroup(GroupConstants.Wilderness, level, timeOfDay, false, creatureTypeFilters);
                validEncounters = validEncounters.Except(wildlife);
            }

            return validEncounters;
        }

        private IEnumerable<string> GetValidEncounters(IEnumerable<string> source, int level, string timeOfDay, params string[] creatureTypeFilters)
        {
            var validEncounters = source.Where(e => amountSelector.SelectAverageEncounterLevel(e) == level);
            var allowedCreatureNames = GetAllowedCreatureNames(creatureTypeFilters);
            validEncounters = validEncounters.Where(e => EncounterIsValid(e, allowedCreatureNames));

            var timeOfDayEncounters = GetEncountersFromCreatureGroup(timeOfDay);
            if (timeOfDayEncounters.Any())
                validEncounters = validEncounters.Intersect(timeOfDayEncounters);

            return validEncounters;
        }

        //INFO: This method exists here because we cannot use the EncounterVerifier on the selector level, only the generator level
        private bool EncounterIsValid(string encounter, IEnumerable<string> allowedCreatureNames)
        {
            var creaturesAndAmounts = encounterSelector.SelectCreaturesAndAmountsFrom(encounter);
            var creatureNames = creaturesAndAmounts.Keys;
            return creatureNames.Any(c => CreatureIsValid(c, allowedCreatureNames));
        }

        //INFO: This method exists here because we cannot use the EncounterVerifier on the selector level, only the generator level
        private bool CreatureIsValid(string creatureName, IEnumerable<string> allowedCreatureNames)
        {
            return !allowedCreatureNames.Any() || allowedCreatureNames.Contains(creatureName);
        }

        private IEnumerable<string> GetAllowedCreatureNames(IEnumerable<string> creatureTypeFilters)
        {
            var creatureNames = new List<string>();

            foreach (var filter in creatureTypeFilters)
            {
                var filterCreatures = collectionSelector.Explode(TableNameConstants.CreatureGroups, filter);
                creatureNames.AddRange(filterCreatures);
            }

            return creatureNames.Distinct();
        }
    }
}
