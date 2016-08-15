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
        private IEncounterCollectionSelector encounterCollectionSelector;
        private IRollSelector rollSelector;
        private Regex challengeRatingRegex;
        private Regex descriptionRegex;

        public FilterVerifier(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICollectionSelector collectionSelector, IEncounterCollectionSelector encounterCollectionSelector, IRollSelector rollSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.collectionSelector = collectionSelector;
            this.encounterCollectionSelector = encounterCollectionSelector;
            this.rollSelector = rollSelector;

            challengeRatingRegex = new Regex(RegexConstants.ChallengeRatingPattern);
            descriptionRegex = new Regex(RegexConstants.DescriptionPattern);
        }

        public bool FiltersAreValid(string environment, int level, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            if (creatureTypeFilters.Any() == false)
                return true;

            var tableName = string.Format(TableNameConstants.LevelXEncounterLevel, level);
            var allEncounterLevelsAndModifiers = typeAndAmountPercentileSelector.SelectAllFrom(tableName);

            foreach (var encounterLevelsAndModifiers in allEncounterLevelsAndModifiers)
            {
                foreach (var encounterLevelAndModifier in encounterLevelsAndModifiers)
                {
                    var potentialLevel = Convert.ToInt32(encounterLevelAndModifier.Key);
                    var potentialModifier = Convert.ToInt32(encounterLevelAndModifier.Value);

                    var allEncounterCreaturesAndAmounts = encounterCollectionSelector.SelectAllFrom(potentialLevel, environment, temperature, timeOfDay);

                    var validEncounterExists = allEncounterCreaturesAndAmounts.Any(e => EncounterIsValid(e, potentialModifier, creatureTypeFilters));
                    if (validEncounterExists)
                        return true;
                }
            }

            return false;
        }

        public bool EncounterIsValid(Dictionary<string, string> creaturesAndAmounts, int modifier, params string[] creatureTypeFilters)
        {
            var creatures = creaturesAndAmounts.Keys;
            var amounts = creaturesAndAmounts.Values;

            return creatures.Any(c => CreatureIsValid(c, creatureTypeFilters)) && amounts.All(a => rollSelector.SelectFrom(a, modifier) != RollConstants.Reroll);
        }

        public bool CreatureIsValid(string creatureName, params string[] creatureTypeFilters)
        {
            if (creatureTypeFilters.Any() == false)
                return true;

            var allowedCreatureNames = GetAllowedCreatureNames(creatureTypeFilters);
            var potentialCreatureName = GetCreatureName(creatureName);

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

        private string GetCreatureName(string fullCreatureName)
        {
            var creatureName = descriptionRegex.Replace(fullCreatureName, string.Empty);
            creatureName = challengeRatingRegex.Replace(creatureName, string.Empty);

            return creatureName;
        }
    }
}
