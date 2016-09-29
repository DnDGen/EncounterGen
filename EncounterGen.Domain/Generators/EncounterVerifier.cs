using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterVerifier : IEncounterVerifier
    {
        private ICollectionSelector collectionSelector;
        private IEncounterCollectionSelector encounterCollectionSelector;
        private IAmountSelector amountSelector;
        private Regex challengeRatingRegex;

        public int MinimumLevel
        {
            get { return 1; }
        }

        public int MaximumLevel
        {
            //INFO: This is because TreasureGen only supports treasure up to level 30
            get { return 30; }
        }

        public EncounterVerifier(ICollectionSelector collectionSelector, IEncounterCollectionSelector encounterCollectionSelector, IAmountSelector amountSelector)
        {
            this.collectionSelector = collectionSelector;
            this.encounterCollectionSelector = encounterCollectionSelector;
            this.amountSelector = amountSelector;

            challengeRatingRegex = new Regex(RegexConstants.ChallengeRatingPattern);
        }

        public bool ValidEncounterExistsAtLevel(string environment, int level, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            if (!LevelIsValid(level))
                return false;

            var allEncounterCreaturesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(level, environment, temperature, timeOfDay, creatureTypeFilters);

            return allEncounterCreaturesAndAmounts.Any();
        }

        private bool LevelIsValid(int level)
        {
            return level <= MaximumLevel && level >= MinimumLevel;
        }

        public bool EncounterIsValid(IEnumerable<string> creatureNames, params string[] creatureTypeFilters)
        {
            return creatureNames.Any(c => CreatureIsValid(c, creatureTypeFilters));
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
            return challengeRatingRegex.Replace(fullCreatureName, string.Empty);
        }

        public bool EncounterIsValid(IEnumerable<Creature> creatures, params string[] creatureTypeFilters)
        {
            var creatureNames = creatures.Select(c => c.Name);
            var level = amountSelector.SelectEncounterLevel(creatures);

            return LevelIsValid(level) && EncounterIsValid(creatureNames, creatureTypeFilters);
        }
    }
}
