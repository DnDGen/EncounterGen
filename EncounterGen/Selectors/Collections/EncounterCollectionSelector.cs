using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Selectors.Collections
{
    internal class EncounterCollectionSelector : IEncounterCollectionSelector
    {
        private readonly ICollectionSelector collectionSelector;
        private readonly IEncounterFormatter encounterFormatter;

        public EncounterCollectionSelector(ICollectionSelector collectionSelector, IEncounterFormatter encounterFormatter)
        {
            this.collectionSelector = collectionSelector;
            this.encounterFormatter = encounterFormatter;
        }

        public IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(EncounterSpecifications encounterSpecifications)
        {
            var weightedEncounters = GetWeightedEncounters(encounterSpecifications);
            var weightedEncounterTypesAndAmounts = weightedEncounters.Select(e => encounterFormatter.SelectCreaturesAndAmountsFrom(e));

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

            var magicEncounters = GetEncountersFromCreatureGroup(GroupConstants.Magic);
            var specificEnvironmentEncounters = GetEncountersFromCreatureGroup(encounterSpecifications.SpecificEnvironment);
            var aquaticEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Aquatic);
            var undergroundEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Underground);
            var undergroundAquaticEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic);

            //INFO: Using unions instead of adding to the weighted list is done to remove duplicate encounters from these collections
            var allEncounters = magicEncounters.Union(specificEnvironmentEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
            {
                var landEncounters = GetEncountersFromCreatureGroup(GroupConstants.Land);
                allEncounters = allEncounters.Union(landEncounters);
            }

            if (ShouldGetAquatic(encounterSpecifications))
            {
                allEncounters = allEncounters.Union(aquaticEncounters);

                //INFO: If the environment is aquatic, we already have these encounters as the specific environment
                if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
                {
                    var aquaticSpecifications = encounterSpecifications.Clone();
                    aquaticSpecifications.Environment = EnvironmentConstants.Aquatic;
                    var specificAquaticEncounters = GetEncountersFromCreatureGroup(aquaticSpecifications.SpecificEnvironment);

                    allEncounters = allEncounters.Union(specificAquaticEncounters);
                }
            }

            if (ShouldGetUnderground(encounterSpecifications))
            {
                allEncounters = allEncounters.Union(undergroundEncounters);
            }

            if (ShouldGetUndergroundAquatic(encounterSpecifications))
            {
                allEncounters = allEncounters.Union(undergroundAquaticEncounters);
            }

            var validEncounters = GetValidEncounters(allEncounters, encounterSpecifications);

            if (!validEncounters.Any())
            {
                return Enumerable.Empty<string>();
            }

            //INFO: Single weight
            var weightedEncounters = new List<string>();
            weightedEncounters = WeightEncounters(weightedEncounters, validEncounters, 1, string.Empty);

            //INFO: Common weight
            var commonValidEncounters = validEncounters.Except(magicEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
                commonValidEncounters = commonValidEncounters.Except(aquaticEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Underground)
                commonValidEncounters = commonValidEncounters.Except(undergroundEncounters);

            var uncommonEncounters = validEncounters.Except(commonValidEncounters);

            if (commonValidEncounters.Any())
            {
                var commonWeight = ComputeWeight(uncommonEncounters, commonValidEncounters);
                weightedEncounters = WeightEncounters(weightedEncounters, commonValidEncounters, commonWeight, "common");
            }

            //INFO: Specific weight
            var validSpecificEnvironmentEncounters = validEncounters.Intersect(specificEnvironmentEncounters);

            if (validSpecificEnvironmentEncounters.Any())
            {
                var specificWeight = ComputeWeight(uncommonEncounters, validSpecificEnvironmentEncounters);
                weightedEncounters = WeightEncounters(weightedEncounters, validSpecificEnvironmentEncounters, specificWeight, encounterSpecifications.SpecificEnvironment);
            }

            var validUndergroundAquaticEncounters = validEncounters.Intersect(undergroundAquaticEncounters);

            if (ShouldSpecificWeightUndergroundAquatic(encounterSpecifications) && validUndergroundAquaticEncounters.Any())
            {
                var undergroundAquaticWeight = ComputeWeight(uncommonEncounters, validUndergroundAquaticEncounters);
                weightedEncounters = WeightEncounters(weightedEncounters, validUndergroundAquaticEncounters, undergroundAquaticWeight, "underground aquatic");
            }

            return weightedEncounters;
        }

        private int ComputeWeight(IEnumerable<string> uncommonEncounters, IEnumerable<string> encountersToWeight)
        {
            return Math.Max(uncommonEncounters.Count() / encountersToWeight.Count(), 1);
        }

        private List<string> WeightEncounters(List<string> weightedEncounters, IEnumerable<string> encounters, int weight, string description)
        {
            var spacer = string.IsNullOrEmpty(description) ? string.Empty : " ";

            while (weight-- > 0)
                weightedEncounters.AddRange(encounters);

            return weightedEncounters;
        }

        private bool ShouldSpecificWeightUndergroundAquatic(EncounterSpecifications specifications)
        {
            return ShouldGetUndergroundAquatic(specifications)
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
            var creatures = collectionSelector.Explode(TableNameConstants.CreatureGroups, creatureGroup);
            var allEncounters = collectionSelector.SelectAllFrom(TableNameConstants.EncounterGroups);
            var encounters = collectionSelector.Flatten(allEncounters, creatures);

            return encounters;
        }

        private IEnumerable<string> GetValidEncounters(IEnumerable<string> source, EncounterSpecifications specifications)
        {
            var validEncounters = source;

            if (!validEncounters.Any())
                return Enumerable.Empty<string>();

            var encounterLevels = collectionSelector.SelectAllFrom(TableNameConstants.AverageEncounterLevels);
            var levelString = specifications.Level.ToString();
            validEncounters = validEncounters.Where(e => encounterLevels[e].Single() == levelString);

            if (!validEncounters.Any())
                return Enumerable.Empty<string>();

            if (specifications.CreatureTypeFilters.Any())
            {
                var allowedCreatureNames = GetAllowedCreatureNames(specifications.CreatureTypeFilters);
                validEncounters = validEncounters.Where(e => EncounterIsValid(e, allowedCreatureNames));
            }

            if (!validEncounters.Any())
                return Enumerable.Empty<string>();

            if (specifications.Environment == EnvironmentConstants.Civilized)
            {
                var wildlife = GetEncountersFromCreatureGroup(GroupConstants.Wilderness);
                validEncounters = validEncounters.Except(wildlife);
            }

            if (!validEncounters.Any())
                return Enumerable.Empty<string>();

            var timeOfDayEncounters = GetEncountersFromCreatureGroup(specifications.TimeOfDay);
            validEncounters = validEncounters.Intersect(timeOfDayEncounters);

            return validEncounters;
        }

        //INFO: This method exists here because we cannot use the EncounterVerifier on the selector level, only the generator level
        private bool EncounterIsValid(string encounter, IEnumerable<string> allowedCreatureNames)
        {
            var creaturesAndAmounts = encounterFormatter.SelectCreaturesAndAmountsFrom(encounter);
            var creatureNames = creaturesAndAmounts.Keys;
            return creatureNames.Any(c => CreatureIsValid(c, allowedCreatureNames));
        }

        //INFO: This method exists here because we cannot use the EncounterVerifier on the selector level, only the generator level
        private bool CreatureIsValid(string creatureName, IEnumerable<string> allowedCreatureNames)
        {
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
    }
}
