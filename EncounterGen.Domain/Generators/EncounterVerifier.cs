using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterVerifier : IEncounterVerifier
    {
        private readonly ICollectionSelector collectionSelector;
        private readonly IEncounterCollectionSelector encounterCollectionSelector;
        private readonly IAmountSelector amountSelector;

        public EncounterVerifier(ICollectionSelector collectionSelector, IEncounterCollectionSelector encounterCollectionSelector, IAmountSelector amountSelector)
        {
            this.collectionSelector = collectionSelector;
            this.encounterCollectionSelector = encounterCollectionSelector;
            this.amountSelector = amountSelector;
        }

        public bool ValidEncounterExistsAtLevel(EncounterSpecifications encounterSpecifications)
        {
            if (!encounterSpecifications.IsValid())
                return false;

            var allEncounterCreaturesAndAmounts = encounterCollectionSelector.SelectAllWeightedFrom(encounterSpecifications);

            return allEncounterCreaturesAndAmounts.Any();
        }

        public bool EncounterIsValid(IEnumerable<string> creatureNames, IEnumerable<string> creatureTypeFilters)
        {
            return creatureNames.Any(c => CreatureIsValid(c, creatureTypeFilters));
        }

        public bool CreatureIsValid(string creatureName, IEnumerable<string> creatureTypeFilters)
        {
            if (creatureTypeFilters.Any() == false)
                return true;

            var allowedCreatureNames = GetAllowedCreatureNames(creatureTypeFilters);

            return allowedCreatureNames.Contains(creatureName);
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

        public bool EncounterIsValid(Encounter encounter, IEnumerable<string> creatureTypeFilters)
        {
            var creatureNames = encounter.Creatures.Select(c => c.Type.Name);
            var level = amountSelector.SelectActualEncounterLevel(encounter);

            return EncounterSpecifications.LevelIsValid(level) && EncounterIsValid(creatureNames, creatureTypeFilters);
        }
    }
}
