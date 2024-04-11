using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.RollGen;
using DnDGen.Stress;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

namespace DnDGen.EncounterGen.Tests.Integration.Stress
{
    [TestFixture]
    [Stress]
    public abstract class StressTests : IntegrationTests
    {
        protected Dice dice;
        protected ICollectionSelector collectionSelector;

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
        }

        protected EncounterSpecifications RandomizeSpecifications(int level = 0, string environment = "", string temperature = "", string timeOfDay = "", string filter = "", bool useFilter = false)
        {
            var specifications = new EncounterSpecifications();
            specifications.Environment = string.IsNullOrEmpty(environment) ? GetRandomFrom(allEnvironments) : environment;
            specifications.Temperature = string.IsNullOrEmpty(temperature) ? GetRandomFrom(allTemperatures) : temperature;
            specifications.TimeOfDay = string.IsNullOrEmpty(timeOfDay) ? GetRandomFrom(allTimesOfDay) : timeOfDay;
            specifications.Level = level > 0 ? level : dice.Roll().d(EncounterSpecifications.MaximumLevel).AsSum() + EncounterSpecifications.MinimumLevel - 1;
            specifications.AllowAquatic = dice.Roll().d2().AsTrueOrFalse();
            specifications.AllowUnderground = dice.Roll().d2().AsTrueOrFalse();

            if (!string.IsNullOrEmpty(filter))
            {
                specifications.CreatureTypeFilters = new[] { filter };
            }
            else if (useFilter)
            {
                var randomFilter = GetRandomFrom(allFilters);
                specifications.CreatureTypeFilters = new[] { randomFilter };
            }

            return specifications;
        }

        private string GetRandomFrom(IEnumerable<string> collection)
        {
            return collectionSelector.SelectRandomFrom(collection);
        }
    }
}
