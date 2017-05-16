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
            if (ShouldGetUnderground(encounterSpecifications))
            {
                encounterSpecifications.TimeOfDay = EnvironmentConstants.TimesOfDay.Night;
            }

            var magicEncounters = GetValidEncountersFromCreatureGroup(GroupConstants.Magic, encounterSpecifications);
            var landEncounters = GetValidEncountersFromCreatureGroup(GroupConstants.Land, encounterSpecifications);
            var specificEnvironmentEncounters = GetValidEncountersFromCreatureGroup(encounterSpecifications.SpecificEnvironment, encounterSpecifications);

            var aquaticEncounters = GetValidEncountersFromCreatureGroup(EnvironmentConstants.Aquatic, encounterSpecifications);

            var aquaticSpecifications = encounterSpecifications.Clone();
            aquaticSpecifications.Environment = EnvironmentConstants.Aquatic;
            var specificAquaticEncounters = GetValidEncountersFromCreatureGroup(aquaticSpecifications.SpecificEnvironment, encounterSpecifications);

            var undergroundEncounters = GetValidEncountersFromCreatureGroup(EnvironmentConstants.Underground, encounterSpecifications);
            var undergroundAquaticEncounters = GetValidEncountersFromCreatureGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic, encounterSpecifications);

            //INFO: This is done to remove duplicate encounters from these lists
            var allEncounters = magicEncounters.Union(specificEnvironmentEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
            {
                allEncounters = allEncounters.Union(landEncounters);
            }

            if (ShouldGetAquatic(encounterSpecifications))
            {
                allEncounters = allEncounters
                    .Union(aquaticEncounters)
                    .Union(specificAquaticEncounters);
            }

            if (ShouldGetUnderground(encounterSpecifications))
            {
                allEncounters = allEncounters.Union(undergroundEncounters);
            }

            if (ShouldGetUndergroundAquatic(encounterSpecifications))
            {
                allEncounters = allEncounters.Union(undergroundAquaticEncounters);
            }

            //INFO: Single weight
            var weightedEncounters = new List<string>();
            weightedEncounters.AddRange(allEncounters);

            //INFO: Double weight
            var commonEncounters = allEncounters.Except(magicEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
                commonEncounters = commonEncounters.Except(aquaticEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Underground)
                commonEncounters = commonEncounters.Except(undergroundEncounters);

            weightedEncounters.AddRange(commonEncounters);

            //INFO: Triple weight
            weightedEncounters.AddRange(specificEnvironmentEncounters);

            if (ShouldTripleWeightUndergroundAquatic(encounterSpecifications))
            {
                weightedEncounters.AddRange(undergroundAquaticEncounters);
            }

            return weightedEncounters;
        }

        private bool ShouldTripleWeightUndergroundAquatic(EncounterSpecifications specifications)
        {
            return ShouldGetUnderground(specifications) && ShouldGetAquatic(specifications)
                && (specifications.Environment == EnvironmentConstants.Aquatic || specifications.Environment == EnvironmentConstants.Underground);
        }

        private bool ShouldGetUndergroundAquatic(EncounterSpecifications specifications)
        {
            return ShouldGetUnderground(specifications) && ShouldGetAquatic(specifications);
        }

        private bool ShouldGetUnderground(EncounterSpecifications specifications)
        {
            return (specifications.Environment == EnvironmentConstants.Underground || specifications.AllowUnderground);
        }

        private bool ShouldGetAquatic(EncounterSpecifications specifications)
        {
            return (specifications.Environment == EnvironmentConstants.Aquatic || specifications.AllowAquatic);
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
