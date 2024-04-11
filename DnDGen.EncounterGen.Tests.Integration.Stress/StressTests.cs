using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.RollGen;
using DnDGen.Stress;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DnDGen.EncounterGen.Tests.Integration.Stress
{
    [TestFixture]
    [Stress]
    public abstract class StressTests : IntegrationTests
    {
        protected Dice dice;
        protected ICollectionSelector collectionSelector;
        protected IEncounterVerifier encounterVerifier;

        protected Stressor stressor;

        protected readonly IEnumerable<string> allEnvironments;
        protected readonly IEnumerable<string> allTemperatures;
        protected readonly IEnumerable<string> allTimesOfDay;
        protected readonly IEnumerable<string> allFilters;

        public StressTests()
        {
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

        [OneTimeSetUp]
        public void OneTimeStressSetup()
        {
            var options = new StressorOptions();
            options.RunningAssembly = Assembly.GetExecutingAssembly();
            options.TimeLimitPercentage = .55;

#if STRESS
            options.IsFullStress = true;
#else
            options.IsFullStress = false;
#endif

            stressor = new Stressor(options);
        }

        [SetUp]
        public void StressSetup()
        {
            dice = GetNewInstanceOf<Dice>();
            collectionSelector = GetNewInstanceOf<ICollectionSelector>();
            encounterVerifier = GetNewInstanceOf<IEncounterVerifier>();
        }

        protected EncounterSpecifications RandomizeSpecifications(int level = 0, string environment = "", string temperature = "", string timeOfDay = "", string filter = "", bool useFilter = false)
        {
            var validPresets = encounterVerifier.ValidEncounterExists(environment, temperature, timeOfDay, level, true, true);
            if (!string.IsNullOrEmpty(filter))
                validPresets = encounterVerifier.ValidEncounterExists(environment, temperature, timeOfDay, level, true, true, filter);

            if (!validPresets)
                Assert.Fail($"Presets are not valid: {environment}, {temperature}, {timeOfDay}, {level}, {filter}");

            var specifications = new EncounterSpecifications();
            var isValid = false;

            while (!isValid)
            {
                specifications.Environment = string.IsNullOrEmpty(environment) ? GetRandomFrom(allEnvironments) : environment;

                var validTemperatures = encounterVerifier.GetValidTemperatues(specifications.Environment);
                if (!validTemperatures.Any() || (!string.IsNullOrEmpty(temperature) && !validTemperatures.Contains(temperature)))
                    continue;

                specifications.Temperature = string.IsNullOrEmpty(temperature) ? GetRandomFrom(validTemperatures) : temperature;

                var validTimesOfDay = encounterVerifier.GetValidTimesOfDay(specifications.Environment, specifications.Temperature);
                if (!validTimesOfDay.Any() || (!string.IsNullOrEmpty(timeOfDay) && !validTimesOfDay.Contains(timeOfDay)))
                    continue;

                specifications.TimeOfDay = string.IsNullOrEmpty(timeOfDay) ? GetRandomFrom(validTimesOfDay) : timeOfDay;

                var validLevels = encounterVerifier.GetValidLevels(specifications.Environment, specifications.Temperature, specifications.TimeOfDay);
                if (!validLevels.Any() || (level > 0 && !validLevels.Contains(level)))
                    continue;

                specifications.Level = level > 0 ? level : collectionSelector.SelectRandomFrom(validLevels);

                var validAquatic = encounterVerifier.GetValidAllowAquatic(
                    specifications.Environment,
                    specifications.Temperature,
                    specifications.TimeOfDay,
                    specifications.Level);

                specifications.AllowAquatic = collectionSelector.SelectRandomFrom(validAquatic);

                var validUnderground = encounterVerifier.GetValidAllowUnderground(
                    specifications.Environment,
                    specifications.Temperature,
                    specifications.TimeOfDay,
                    specifications.Level,
                    specifications.AllowAquatic);

                specifications.AllowUnderground = collectionSelector.SelectRandomFrom(validUnderground);


                var validFilters = encounterVerifier.GetValidFilters(
                    specifications.Environment,
                    specifications.Temperature,
                    specifications.TimeOfDay,
                    specifications.Level,
                    specifications.AllowAquatic,
                    specifications.AllowUnderground);
                if ((useFilter && !validFilters.Any()) || (!string.IsNullOrEmpty(filter) && !validFilters.Contains(filter)))
                    continue;

                if (!string.IsNullOrEmpty(filter))
                {
                    specifications.CreatureTypeFilters = new[] { filter };
                }
                else if (useFilter)
                {
                    var randomFilter = GetRandomFrom(validFilters);
                    specifications.CreatureTypeFilters = new[] { randomFilter };
                }

                isValid = specifications.IsValid() && encounterVerifier.ValidEncounterExists(specifications);
            }

            return specifications;
        }

        private string GetRandomFrom(IEnumerable<string> collection)
        {
            return collectionSelector.SelectRandomFrom(collection);
        }
    }
}
