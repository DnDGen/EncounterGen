using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EncounterGen.Domain.Generators
{
    internal class FilterVerifier : IFilterVerifier
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private ICollectionSelector collectionSelector;
        private Regex challengeRatingRegex;
        private Regex subTypeRegex;

        public FilterVerifier(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICollectionSelector collectionSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionSelector = collectionSelector;

            challengeRatingRegex = new Regex(RegexConstants.ChallengeRatingPattern);
            subTypeRegex = new Regex(RegexConstants.SubTypePattern);
        }

        public bool FiltersAreValid(string environment, int level, params string[] creatureTypeFilters)
        {
            if (creatureTypeFilters.Any() == false)
                return true;

            var tableName = string.Format(TableNameConstants.LevelXEncounterLevel, level);
            var encounterLevelsAndAmounts = typeAndAmountPercentileSelector.SelectAllFrom(tableName);
            var potentialLevels = encounterLevelsAndAmounts.SelectMany(dict => dict.Keys).Select(k => Convert.ToInt32(k));

            foreach (var potentialLevel in potentialLevels)
            {
                tableName = string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, potentialLevel, environment);
                var encounterCreaturesAndAmounts = typeAndAmountPercentileSelector.SelectAllFrom(tableName);
                var potentialCreatures = encounterCreaturesAndAmounts.SelectMany(dict => dict.Keys);

                if (potentialCreatures.Any(c => CreatureIsValid(c, creatureTypeFilters)))
                    return true;
            }

            return false;
        }

        public bool CreatureIsValid(string creatureName, params string[] creatureTypeFilters)
        {
            if (creatureTypeFilters.Any() == false)
                return true;

            var allowedCreatureNames = GetAllowedCreatureNames(creatureTypeFilters);
            var potentialCreatureName = GetCreatureType(creatureName);

            return allowedCreatureNames.Contains(potentialCreatureName);
        }

        private IEnumerable<string> GetAllowedCreatureNames(IEnumerable<string> creatureTypeFilters)
        {
            var creatureNames = Enumerable.Empty<string>();

            foreach (var filter in creatureTypeFilters)
            {
                var filterCreatures = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, filter);
                creatureNames = creatureNames.Union(filterCreatures);
            }

            return creatureNames;
        }

        private string GetCreatureType(string fullCreatureType)
        {
            var creatureType = subTypeRegex.Replace(fullCreatureType, string.Empty);
            creatureType = challengeRatingRegex.Replace(creatureType, string.Empty);

            return creatureType;
        }
    }
}
