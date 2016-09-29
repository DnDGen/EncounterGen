using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal class EncounterCollectionSelector : IEncounterCollectionSelector
    {
        private readonly ICollectionSelector collectionSelector;
        private readonly IAmountSelector amountSelector;
        private Regex challengeRatingRegex;

        public EncounterCollectionSelector(ICollectionSelector collectionSelector, IAmountSelector amountSelector)
        {
            this.collectionSelector = collectionSelector;
            this.amountSelector = amountSelector;

            challengeRatingRegex = new Regex(RegexConstants.ChallengeRatingPattern);
        }

        public IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(int level, string environment, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            var weightedEncounters = GetWeightedEncounters(level, environment, temperature, timeOfDay, creatureTypeFilters);
            var weightedEncounterTypesAndAmounts = weightedEncounters.Select(e => ParseTypesAndAmounts(e));

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
            var dragonEncounters = GetValidEncountersFromCreatureGroup(CreatureConstants.Dragon, level, timeOfDay, isCivilized, creatureTypeFilters);
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
            validEncounters = validEncounters.Where(e => EncounterIsValid(e, creatureTypeFilters));

            var timeOfDayEncounters = GetEncountersFromCreatureGroup(timeOfDay);
            if (timeOfDayEncounters.Any())
                validEncounters = validEncounters.Intersect(timeOfDayEncounters);

            return validEncounters;
        }

        private bool EncounterIsValid(string encounter, params string[] creatureTypeFilters)
        {
            var creatureNames = encounter.Split(',').Select(e => e.Split('/')[0]);
            return creatureNames.Any(n => CreatureIsValid(n, creatureTypeFilters));
        }

        private bool CreatureIsValid(string creatureName, params string[] creatureTypeFilters)
        {
            if (creatureTypeFilters.Any() == false)
                return true;

            var allowedCreatureNames = GetAllowedCreatureNames(creatureTypeFilters);
            var potentialCreatureName = GetCreatureName(creatureName);

            return allowedCreatureNames.Contains(potentialCreatureName);
        }

        private IEnumerable<string> GetAllowedCreatureNames(IEnumerable<string> creatureTypeFilters)
        {
            var creatureNames = creatureTypeFilters.SelectMany(f => collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, f));
            return creatureNames;
        }

        private string GetCreatureName(string fullCreatureName)
        {
            return challengeRatingRegex.Replace(fullCreatureName, string.Empty);
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
