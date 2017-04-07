using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
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

        public IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(EncounterSpecifications encounterSpecifications)
        {
            var weightedEncounters = GetWeightedEncounters(encounterSpecifications);
            var weightedEncounterTypesAndAmounts = weightedEncounters.Select(e => encounterSelector.SelectCreaturesAndAmountsFrom(e));

            return weightedEncounterTypesAndAmounts;
        }

        public Dictionary<string, string> SelectRandomFrom(EncounterSpecifications encounterSpecifications)
        {
            var weightedEncounters = SelectAllWeightedFrom(encounterSpecifications);

            if (!weightedEncounters.Any())
                throw new ArgumentException($"No valid encounters exist for {encounterSpecifications.Description}");

            return collectionSelector.SelectRandomFrom(weightedEncounters);
        }

        private IEnumerable<string> GetWeightedEncounters(EncounterSpecifications encounterSpecifications)
        {
            if (encounterSpecifications.Environment == EnvironmentConstants.Dungeon)
            {
                encounterSpecifications.TimeOfDay = EnvironmentConstants.TimesOfDay.Night;
            }

            var magicEncounters = GetValidEncountersFromCreatureGroup(GroupConstants.Magic, encounterSpecifications);
            var dragonEncounters = GetValidEncountersFromCreatureGroup(CreatureConstants.Types.Dragon, encounterSpecifications);
            var landEncounters = GetValidEncountersFromCreatureGroup(GroupConstants.Land, encounterSpecifications);
            var temperatureEncounters = GetValidEncountersFromCreatureGroup(encounterSpecifications.Temperature, encounterSpecifications);
            var environmentEncounters = GetValidEncountersFromCreatureGroup(encounterSpecifications.Environment, encounterSpecifications);

            var specificEnvironment = encounterSpecifications.Temperature + encounterSpecifications.Environment;
            var specificEnvironmentEncounters = GetValidEncountersFromCreatureGroup(specificEnvironment, encounterSpecifications);

            var aquaticEncounters = GetValidEncountersFromCreatureGroup(EnvironmentConstants.Aquatic, encounterSpecifications);
            var specificAquaticEnvironment = encounterSpecifications.Temperature + EnvironmentConstants.Aquatic;
            var specificAquaticEncounters = GetValidEncountersFromCreatureGroup(specificAquaticEnvironment, encounterSpecifications);

            //INFO: This is done to remove duplicate encounters from these lists
            var allEncounters = magicEncounters
                .Union(environmentEncounters)
                .Union(specificEnvironmentEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
            {
                allEncounters = allEncounters
                    .Union(dragonEncounters)
                    .Union(landEncounters)
                    .Union(temperatureEncounters);
            }

            if (encounterSpecifications.AllowAquatic)
            {
                allEncounters = allEncounters
                    .Union(aquaticEncounters)
                    .Union(specificAquaticEncounters);
            }

            var weightedEncounters = new List<string>();
            weightedEncounters.AddRange(allEncounters);

            var commonEncounters = allEncounters.Except(magicEncounters).Except(dragonEncounters);
            weightedEncounters.AddRange(commonEncounters);

            weightedEncounters.AddRange(environmentEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
            {
                weightedEncounters.AddRange(temperatureEncounters);

                if (encounterSpecifications.AllowAquatic)
                    weightedEncounters.AddRange(specificAquaticEncounters);
            }

            weightedEncounters.AddRange(specificEnvironmentEncounters);
            weightedEncounters.AddRange(specificEnvironmentEncounters);

            return weightedEncounters;
        }

        private IEnumerable<string> GetEncountersFromCreatureGroup(string creatureGroup)
        {
            return collectionSelector.ExplodeInto(TableNameConstants.CreatureGroups, creatureGroup, TableNameConstants.EncounterGroups);
        }

        private IEnumerable<string> GetValidEncountersFromCreatureGroup(string creatureGroup, EncounterSpecifications specifications)
        {
            var encounters = GetEncountersFromCreatureGroup(creatureGroup);
            var validEncounters = GetValidEncounters(encounters, specifications);

            if (specifications.Environment == EnvironmentConstants.Civilized)
            {
                var wildlife = GetEncountersFromCreatureGroup(GroupConstants.Wilderness);
                validEncounters = validEncounters.Except(wildlife);
            }

            return validEncounters;
        }

        private IEnumerable<string> GetValidEncounters(IEnumerable<string> source, EncounterSpecifications specifications)
        {
            var validEncounters = source.Where(e => amountSelector.SelectAverageEncounterLevel(e) == specifications.Level);
            var allowedCreatureNames = GetAllowedCreatureNames(specifications.CreatureTypeFilters);
            validEncounters = validEncounters.Where(e => EncounterIsValid(e, allowedCreatureNames));

            var timeOfDayEncounters = GetEncountersFromCreatureGroup(specifications.TimeOfDay);
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
