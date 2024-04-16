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

        private readonly IEnumerable<string> allEnvironments;
        private readonly IEnumerable<string> allTemperatures;
        private readonly IEnumerable<string> allTimesOfDay;
        private readonly IEnumerable<string> allFilters;

        public EncounterCollectionSelector(ICollectionSelector collectionSelector, IEncounterFormatter encounterFormatter)
        {
            this.collectionSelector = collectionSelector;
            this.encounterFormatter = encounterFormatter;

            allEnvironments = new[]
            {
                EnvironmentConstants.Aquatic,
                EnvironmentConstants.Civilized,
                EnvironmentConstants.Desert,
                EnvironmentConstants.Forest,
                EnvironmentConstants.Hills,
                EnvironmentConstants.Marsh,
                EnvironmentConstants.Mountain,
                EnvironmentConstants.Plains,
                EnvironmentConstants.Underground,
            };

            allTemperatures = new[]
            {
                EnvironmentConstants.Temperatures.Cold,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Warm,
            };

            allTimesOfDay = new[]
            {
                EnvironmentConstants.TimesOfDay.Day,
                EnvironmentConstants.TimesOfDay.Night,
            };

            allFilters = new[]
            {
                CreatureConstants.Types.Aberration,
                CreatureConstants.Types.Animal,
                CreatureConstants.Types.Construct,
                CreatureConstants.Types.Dragon,
                CreatureConstants.Types.Elemental,
                CreatureConstants.Types.Fey,
                CreatureConstants.Types.Giant,
                CreatureConstants.Types.Humanoid,
                CreatureConstants.Types.MagicalBeast,
                CreatureConstants.Types.MonstrousHumanoid,
                CreatureConstants.Types.Ooze,
                CreatureConstants.Types.Outsider,
                CreatureConstants.Types.Plant,
                CreatureConstants.Types.Undead,
                CreatureConstants.Types.Vermin,
            };
        }

        public IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(EncounterSpecifications encounterSpecifications)
        {
            var weightedEncounters = GetWeightedEncounters(encounterSpecifications);
            var weightedEncounterTypesAndAmounts = weightedEncounters.Select(encounterFormatter.SelectCreaturesAndAmountsFrom);

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
            var validEncounters = GetValidEncounters(encounterSpecifications);
            if (!validEncounters.Any())
            {
                return Enumerable.Empty<string>();
            }

            var extraplanarEncounters = GetEncountersFromCreatureGroup(GroupConstants.Extraplanar);
            var aquaticEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Aquatic);
            var undergroundEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Underground);
            var landEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Land);
            var anyEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Any);

            var commonEncounters = validEncounters.Except(extraplanarEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
                commonEncounters = commonEncounters.Except(aquaticEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Underground)
                commonEncounters = commonEncounters.Except(undergroundEncounters);

            if (encounterSpecifications.Environment == EnvironmentConstants.Civilized)
                commonEncounters = commonEncounters.Except(landEncounters).Except(anyEncounters);

            var uncommonEncounters = validEncounters.Intersect(aquaticEncounters.Union(undergroundEncounters));

            if (encounterSpecifications.Environment == EnvironmentConstants.Civilized)
                uncommonEncounters = uncommonEncounters.Union(validEncounters.Intersect(landEncounters.Union(anyEncounters)));

            var rareEncounters = validEncounters.Intersect(extraplanarEncounters);

            var weightedEncounters = collectionSelector.CreateWeighted(common: commonEncounters, uncommon: uncommonEncounters, rare: rareEncounters);

            return weightedEncounters;
        }

        private IEnumerable<string> GetValidEncounters(EncounterSpecifications encounterSpecifications)
        {
            if (ShouldGetUnderground(encounterSpecifications))
            {
                encounterSpecifications.TimeOfDay = EnvironmentConstants.TimesOfDay.Night;
            }

            var extraplanarEncounters = GetEncountersFromCreatureGroup(GroupConstants.Extraplanar);
            var anyEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Any);
            var specificEnvironmentEncounters = GetEncountersFromCreatureGroup(encounterSpecifications.SpecificEnvironment);

            var allEncounters = anyEncounters.Union(specificEnvironmentEncounters).Union(extraplanarEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
            {
                var landEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Land);
                allEncounters = allEncounters.Union(landEncounters);
            }

            if (ShouldGetCivilized(encounterSpecifications))
            {
                var civilizedEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Civilized);
                allEncounters = allEncounters.Union(civilizedEncounters);
            }

            if (ShouldGetAquatic(encounterSpecifications))
            {
                var aquaticEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Aquatic);
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
                var undergroundEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Underground);
                allEncounters = allEncounters.Union(undergroundEncounters);
            }

            if (ShouldGetUndergroundAquatic(encounterSpecifications))
            {
                var undergroundAquaticEncounters = GetEncountersFromCreatureGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic);
                allEncounters = allEncounters.Union(undergroundAquaticEncounters);
            }

            var validEncounters = GetValidEncounters(allEncounters, encounterSpecifications);

            return validEncounters;
        }

        private bool ShouldGetUndergroundAquatic(EncounterSpecifications specifications) => ShouldGetUnderground(specifications) && ShouldGetAquatic(specifications);

        private bool ShouldGetCivilized(EncounterSpecifications specifications) => specifications.Environment == EnvironmentConstants.Civilized;

        private bool ShouldGetUnderground(EncounterSpecifications specifications) =>
            specifications.Environment == EnvironmentConstants.Underground || specifications.AllowUnderground;

        private bool ShouldGetAquatic(EncounterSpecifications specifications) =>
            specifications.Environment == EnvironmentConstants.Aquatic || specifications.AllowAquatic;

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

        public IEnumerable<Dictionary<string, string>> SelectPossibleFrom(
            string environment = "",
            string temperature = "",
            string timeOfDay = "",
            int level = 0,
            bool? allowAquatic = null,
            bool? allowUnderground = null,
            params string[] filters)
        {
            IEnumerable<string> environments = new[] { environment };
            if (string.IsNullOrEmpty(environment))
                environments = allEnvironments;

            IEnumerable<string> temperatures = new[] { temperature };
            if (string.IsNullOrEmpty(temperature))
                temperatures = environments
                    .SelectMany(SelectPossibleTemperatures)
                    .Distinct();

            IEnumerable<string> timesOfDay = new[] { timeOfDay };
            if (string.IsNullOrEmpty(timeOfDay))
                timesOfDay = environments
                    .SelectMany(e => temperatures
                        .SelectMany(t => SelectPossibleTimesOfDay(e, t)))
                    .Distinct();

            IEnumerable<int> levels = new[] { level };
            if (level == 0)
                levels = environments
                    .SelectMany(e => temperatures
                        .SelectMany(t => timesOfDay.
                            SelectMany(d => SelectPossibleLevels(e, t, d))))
                    .Distinct();

            IEnumerable<bool> aquatics;
            if (allowAquatic.HasValue)
            {
                aquatics = new[] { allowAquatic.Value };
            }
            else
            {
                aquatics = environments
                    .SelectMany(e => temperatures
                        .SelectMany(t => timesOfDay.
                            SelectMany(d => levels.
                                SelectMany(l => SelectPossibleAllowAquatic(e, t, d, l)))))
                    .Distinct();
            }

            IEnumerable<bool> undergrounds;
            if (allowUnderground.HasValue)
            {
                undergrounds = new[] { allowUnderground.Value };
            }
            else
            {
                undergrounds = environments
                    .SelectMany(e => temperatures
                        .SelectMany(t => timesOfDay.
                            SelectMany(d => levels.
                                SelectMany(l => aquatics.
                                    SelectMany(a => SelectPossibleAllowUnderground(e, t, d, l, a))))))
                    .Distinct();
            }

            var specs = environments
                    .SelectMany(e => temperatures
                        .SelectMany(t => timesOfDay.
                            SelectMany(d => levels.
                                SelectMany(l => aquatics.
                                    SelectMany(a => undergrounds.
                                        Select(u => new EncounterSpecifications
                                        {
                                            Environment = e,
                                            Temperature = t,
                                            TimeOfDay = d,
                                            Level = l,
                                            AllowAquatic = a,
                                            AllowUnderground = u,
                                            CreatureTypeFilters = filters,
                                        }))))));

            var encounters = specs.SelectMany(GetValidEncounters);
            var encounterTypesAndAmounts = encounters.Select(encounterFormatter.SelectCreaturesAndAmountsFrom);

            return encounterTypesAndAmounts;
        }

        public IEnumerable<string> SelectPossibleTemperatures(string environment)
        {
            foreach (var temperature in allTemperatures)
            {
                var timesOfDay = SelectPossibleTimesOfDay(environment, temperature);
                if (timesOfDay.Any())
                    yield return temperature;
            }
        }

        public IEnumerable<string> SelectPossibleTimesOfDay(string environment, string temperature)
        {
            foreach (var timeOfDay in allTimesOfDay)
            {
                var levels = SelectPossibleLevels(environment, temperature, timeOfDay);
                if (levels.Any())
                    yield return timeOfDay;
            }
        }

        public IEnumerable<int> SelectPossibleLevels(string environment, string temperature, string timeOfDay)
        {
            var levels = Enumerable.Range(EncounterSpecifications.MinimumLevel, EncounterSpecifications.MaximumLevel);

            foreach (var level in levels)
            {
                var aquatic = SelectPossibleAllowAquatic(environment, temperature, timeOfDay, level);
                if (aquatic.Any())
                    yield return level;
            }
        }

        public IEnumerable<bool> SelectPossibleAllowAquatic(string environment, string temperature, string timeOfDay, int level)
        {
            foreach (var v in new[] { true, false })
            {
                var underground = SelectPossibleAllowUnderground(environment, temperature, timeOfDay, level, v);
                if (underground.Any())
                    yield return v;
            }
        }

        public IEnumerable<bool> SelectPossibleAllowUnderground(string environment, string temperature, string timeOfDay, int level, bool allowAquatic)
        {
            return new[] { true, false }
                .Where(v => GetValidEncounters(new EncounterSpecifications
                {
                    Environment = environment,
                    Temperature = temperature,
                    TimeOfDay = timeOfDay,
                    Level = level,
                    AllowAquatic = allowAquatic,
                    AllowUnderground = v,
                }).Any());

        }

        public IEnumerable<string> SelectPossibleFilters(string environment, string temperature, string timeOfDay, int level, bool allowAquatic, bool allowUnderground)
        {
            return allFilters
                .Where(f => GetValidEncounters(new EncounterSpecifications
                {
                    Environment = environment,
                    Temperature = temperature,
                    TimeOfDay = timeOfDay,
                    Level = level,
                    AllowAquatic = allowAquatic,
                    AllowUnderground = allowUnderground,
                    CreatureTypeFilters = new[] { f },
                }).Any());
        }
    }
}
