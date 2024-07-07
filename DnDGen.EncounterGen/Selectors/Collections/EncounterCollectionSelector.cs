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

        private readonly IEnumerable<string> allEnvironments;
        private readonly IEnumerable<string> allTemperatures;
        private readonly IEnumerable<string> allTimesOfDay;
        private readonly IEnumerable<string> allFilters;

        public EncounterCollectionSelector(ICollectionSelector collectionSelector)
        {
            this.collectionSelector = collectionSelector;

            allEnvironments =
            [
                EnvironmentConstants.Aquatic,
                EnvironmentConstants.Civilized,
                EnvironmentConstants.Desert,
                EnvironmentConstants.Forest,
                EnvironmentConstants.Hills,
                EnvironmentConstants.Marsh,
                EnvironmentConstants.Mountain,
                EnvironmentConstants.Plains,
                EnvironmentConstants.Underground,
            ];

            allTemperatures =
            [
                EnvironmentConstants.Temperatures.Cold,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Warm,
            ];

            allTimesOfDay =
            [
                EnvironmentConstants.TimesOfDay.Day,
                EnvironmentConstants.TimesOfDay.Night,
            ];

            allFilters =
            [
                CreatureDataConstants.Types.Aberration,
                CreatureDataConstants.Types.Animal,
                CreatureDataConstants.Types.Construct,
                CreatureDataConstants.Types.Dragon,
                CreatureDataConstants.Types.Elemental,
                CreatureDataConstants.Types.Fey,
                CreatureDataConstants.Types.Giant,
                CreatureDataConstants.Types.Humanoid,
                CreatureDataConstants.Types.MagicalBeast,
                CreatureDataConstants.Types.MonstrousHumanoid,
                CreatureDataConstants.Types.Ooze,
                CreatureDataConstants.Types.Outsider,
                CreatureDataConstants.Types.Plant,
                CreatureDataConstants.Types.Undead,
                CreatureDataConstants.Types.Vermin,
            ];
        }

        private (IEnumerable<string> Common, IEnumerable<string> Uncommon, IEnumerable<string> Rare) GetWeightedEncounters(EncounterSpecifications encounterSpecifications)
        {
            var validEncounters = GetValidEncounters(encounterSpecifications);
            if (!validEncounters.Any())
            {
                return ([], [], []);
            }

            var extraplanarEncounters = GetEncountersFromEncounterGroup(GroupConstants.Extraplanar);
            var aquaticEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Aquatic);
            var tempAquaticEncounters = GetEncountersFromEncounterGroup(encounterSpecifications.Temperature + EnvironmentConstants.Aquatic);
            var undergroundAquaticEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic);
            var undergroundEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Underground);
            var undeadEncounters = GetEncountersFromEncounterGroup(CreatureDataConstants.Types.Undead);
            var anyEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Any);
            var landEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Land);
            var characterEncounters = GetEncountersFromEncounterGroup(GroupConstants.Character);

            var commonEncounters = validEncounters.Except(extraplanarEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
            {
                var toRemove = aquaticEncounters
                    .Union(tempAquaticEncounters).Union(undergroundAquaticEncounters)
                    .Except(anyEncounters).Except(landEncounters);
                commonEncounters = commonEncounters.Except(toRemove);
            }

            if (encounterSpecifications.Environment != EnvironmentConstants.Underground)
            {
                var toRemove = undergroundEncounters
                    .Union(undergroundAquaticEncounters)
                    .Except(anyEncounters).Except(landEncounters);
                commonEncounters = commonEncounters.Except(toRemove);
            }

            if (encounterSpecifications.Environment == EnvironmentConstants.Civilized)
                commonEncounters = commonEncounters.Except(undeadEncounters);
            else
                commonEncounters = commonEncounters.Except(characterEncounters);


            var potentialUncommonEncounters = aquaticEncounters
                .Union(undergroundEncounters).Union(tempAquaticEncounters).Union(undergroundAquaticEncounters)
                .Except(anyEncounters).Except(landEncounters);

            if (encounterSpecifications.Environment == EnvironmentConstants.Civilized)
                potentialUncommonEncounters = potentialUncommonEncounters.Except(undeadEncounters);
            else
                potentialUncommonEncounters = potentialUncommonEncounters.Union(validEncounters.Intersect(characterEncounters));

            var uncommonEncounters = validEncounters.Except(commonEncounters).Intersect(potentialUncommonEncounters);
            var rareEncounters = validEncounters.Intersect(extraplanarEncounters);

            if (encounterSpecifications.Environment == EnvironmentConstants.Civilized)
                rareEncounters = rareEncounters.Union(validEncounters.Intersect(undeadEncounters));

            return (commonEncounters, uncommonEncounters, rareEncounters);
        }

        private IEnumerable<string> GetValidEncounters(EncounterSpecifications encounterSpecifications)
        {
            if (ShouldGetUnderground(encounterSpecifications))
            {
                encounterSpecifications.TimeOfDay = EnvironmentConstants.TimesOfDay.Night;
            }

            var extraplanarEncounters = GetEncountersFromEncounterGroup(GroupConstants.Extraplanar);
            var anyEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Any);
            var tempEnvironmentEncounters = GetEncountersFromEncounterGroup(encounterSpecifications.SpecificEnvironment);

            var allEncounters = tempEnvironmentEncounters.Union(anyEncounters).Union(extraplanarEncounters);

            if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
            {
                var landEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Land);
                allEncounters = allEncounters.Union(landEncounters);
            }

            if (ShouldGetCivilized(encounterSpecifications))
            {
                var civilizedEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Civilized);
                allEncounters = allEncounters.Union(civilizedEncounters);
            }

            if (ShouldGetAquatic(encounterSpecifications))
            {
                var aquaticEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Aquatic);
                allEncounters = allEncounters.Union(aquaticEncounters);

                //INFO: If the environment is aquatic, we already have these encounters as the specific environment
                if (encounterSpecifications.Environment != EnvironmentConstants.Aquatic)
                {
                    var aquaticSpecifications = encounterSpecifications.Clone();
                    aquaticSpecifications.Environment = EnvironmentConstants.Aquatic;
                    var tempAquaticEncounters = GetEncountersFromEncounterGroup(aquaticSpecifications.SpecificEnvironment);

                    allEncounters = allEncounters.Union(tempAquaticEncounters);
                }
            }

            if (ShouldGetUnderground(encounterSpecifications))
            {
                var undergroundEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Underground);
                allEncounters = allEncounters.Union(undergroundEncounters);
            }

            if (ShouldGetUndergroundAquatic(encounterSpecifications))
            {
                var undergroundAquaticEncounters = GetEncountersFromEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic);
                allEncounters = allEncounters.Union(undergroundAquaticEncounters);
            }

            var validEncounters = FilterOutInvalidEncounters(allEncounters, encounterSpecifications);

            return validEncounters;
        }

        private bool ShouldGetUndergroundAquatic(EncounterSpecifications specifications) => ShouldGetUnderground(specifications) && ShouldGetAquatic(specifications);

        private bool ShouldGetCivilized(EncounterSpecifications specifications) => specifications.Environment == EnvironmentConstants.Civilized;

        private bool ShouldGetUnderground(EncounterSpecifications specifications) =>
            specifications.Environment == EnvironmentConstants.Underground || specifications.AllowUnderground;

        private bool ShouldGetAquatic(EncounterSpecifications specifications) =>
            specifications.Environment == EnvironmentConstants.Aquatic || specifications.AllowAquatic;

        private IEnumerable<string> GetEncountersFromEncounterGroup(string encounterGroup) =>
            collectionSelector.SelectFrom(Config.Name, TableNameConstants.EncounterGroups, encounterGroup);

        private IEnumerable<string> FilterOutInvalidEncounters(IEnumerable<string> source, EncounterSpecifications specifications)
        {
            var validEncounters = source;

            if (!validEncounters.Any())
                return [];

            var levelEncounters = collectionSelector.SelectFrom(Config.Name, TableNameConstants.AverageEncounterLevels, specifications.Level.ToString());
            validEncounters = validEncounters.Intersect(levelEncounters);

            if (!validEncounters.Any())
                return [];

            if (specifications.CreatureTypeFilters.Any())
            {
                var filterEncounters = GetEncountersFromFilters(specifications.CreatureTypeFilters);
                validEncounters = validEncounters.Intersect(filterEncounters);
            }

            if (!validEncounters.Any())
                return [];

            if (specifications.Environment == EnvironmentConstants.Civilized)
            {
                var wildlife = GetEncountersFromEncounterGroup(GroupConstants.Wilderness);
                validEncounters = validEncounters.Except(wildlife);
            }

            if (!validEncounters.Any())
                return [];

            var timeOfDayEncounters = GetEncountersFromEncounterGroup(specifications.TimeOfDay);
            validEncounters = validEncounters.Intersect(timeOfDayEncounters);

            return validEncounters;
        }

        private IEnumerable<string> GetEncountersFromFilters(IEnumerable<string> creatureTypeFilters)
        {
            var encounters = new List<string>();

            foreach (var filter in creatureTypeFilters)
            {
                var filterCreatures = GetEncountersFromEncounterGroup(filter);
                encounters.AddRange(filterCreatures);
            }

            return encounters.Distinct();
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

        public string SelectRandomEncounterFrom(EncounterSpecifications encounterSpecifications)
        {
            var weightedEncounters = GetWeightedEncounters(encounterSpecifications);

            if (!weightedEncounters.Common.Any() && !weightedEncounters.Uncommon.Any() && !weightedEncounters.Rare.Any())
                throw new ArgumentException($"No valid encounters exist for {encounterSpecifications.Description}");

            return collectionSelector.SelectRandomFrom(weightedEncounters.Common, weightedEncounters.Uncommon, weightedEncounters.Rare);
        }

        //public IEnumerable<string> SelectAllWeightedEncountersFrom(EncounterSpecifications encounterSpecifications)
        //{
        //    var weightedEncounters = GetWeightedEncounters(encounterSpecifications);

        //    return collectionSelector.CreateWeighted(weightedEncounters.Common, weightedEncounters.Uncommon, weightedEncounters.Rare);
        //}

        public IEnumerable<string> SelectPossibleEncountersFrom(
            string environment = "",
            string temperature = "",
            string timeOfDay = "",
            int level = 0,
            bool? allowAquatic = null,
            bool? allowUnderground = null,
            params string[] filters)
        {
            //Shortcuts
            if (string.IsNullOrEmpty(environment) && string.IsNullOrEmpty(temperature) && string.IsNullOrEmpty(timeOfDay) && level == 0)
            {
                var shortcutEncounters = collectionSelector.SelectFrom(Config.Name, TableNameConstants.EncounterGroups, GroupConstants.All);

                if (allowAquatic.HasValue && allowAquatic.Value == false)
                {
                    var aquatic = GetEncountersFromEncounterGroup(EnvironmentConstants.Aquatic)
                        .Concat(GetEncountersFromEncounterGroup(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic))
                        .Concat(GetEncountersFromEncounterGroup(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic))
                        .Concat(GetEncountersFromEncounterGroup(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic))
                        .Concat(GetEncountersFromEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic));

                    shortcutEncounters = shortcutEncounters.Except(aquatic);
                }

                if (allowUnderground.HasValue && allowUnderground.Value == false)
                {
                    var underground = GetEncountersFromEncounterGroup(EnvironmentConstants.Underground)
                        .Concat(GetEncountersFromEncounterGroup(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic));

                    shortcutEncounters = shortcutEncounters.Except(underground);
                }

                if (filters.Any())
                {
                    var filterEncounters = GetEncountersFromFilters(filters);
                    shortcutEncounters = shortcutEncounters.Intersect(filterEncounters);
                }

                return shortcutEncounters;
            }

            //Full
            IEnumerable<string> environments = new[] { environment };
            if (string.IsNullOrEmpty(environment))
                environments = allEnvironments;

            IEnumerable<string> temperatures = new[] { temperature };
            if (string.IsNullOrEmpty(temperature))
                temperatures = environments
                    .SelectMany(SelectPossibleTemperatures)
                    .Distinct();

            if (!temperatures.Any())
                return Enumerable.Empty<string>();

            IEnumerable<string> timesOfDay = new[] { timeOfDay };
            if (string.IsNullOrEmpty(timeOfDay))
                timesOfDay = environments
                    .SelectMany(e => temperatures
                        .SelectMany(t => SelectPossibleTimesOfDay(e, t)))
                    .Distinct();

            if (!timesOfDay.Any())
                return Enumerable.Empty<string>();

            IEnumerable<int> levels = new[] { level };
            if (level == 0)
                levels = environments
                    .SelectMany(e => temperatures
                        .SelectMany(t => timesOfDay.
                            SelectMany(d => SelectPossibleLevels(e, t, d))))
                    .Distinct();

            if (!levels.Any())
                return Enumerable.Empty<string>();

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

            if (!aquatics.Any())
                return Enumerable.Empty<string>();

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

            if (!undergrounds.Any())
                return Enumerable.Empty<string>();

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

            return encounters;
        }
    }
}
