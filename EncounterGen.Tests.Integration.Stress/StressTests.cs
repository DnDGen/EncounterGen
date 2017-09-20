using DnDGen.Core.Selectors.Collections;
using DnDGen.Stress;
using DnDGen.Stress.Events;
using EncounterGen.Common;
using EncounterGen.Generators;
using EventGen;
using Ninject;
using NUnit.Framework;
using RollGen;
using System.Collections.Generic;
using System.Reflection;

namespace EncounterGen.Tests.Integration.Stress
{
    [TestFixture]
    [Stress]
    public abstract class StressTests : IntegrationTests
    {
        [Inject]
        public Dice Dice { get; set; }
        [Inject]
        public ICollectionSelector CollectionSelector { get; set; }

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
        public void StressSetup()
        {
            var options = new StressorWithEventsOptions();
            options.RunningAssembly = Assembly.GetExecutingAssembly();

#if STRESS
            options.IsFullStress = true;
#else
            options.IsFullStress = false;
#endif

            options.ClientIdManager = GetNewInstanceOf<ClientIDManager>();
            options.EventQueue = GetNewInstanceOf<GenEventQueue>();
            options.Source = "EncounterGen";

            stressor = new StressorWithEvents(options);
        }

        protected EncounterSpecifications RandomizeSpecifications(int level = 0, string environment = "", string temperature = "", string timeOfDay = "", string filter = "", bool useFilter = false)
        {
            var specifications = new EncounterSpecifications();
            specifications.Environment = string.IsNullOrEmpty(environment) ? GetRandomFrom(allEnvironments) : environment;
            specifications.Temperature = string.IsNullOrEmpty(temperature) ? GetRandomFrom(allTemperatures) : temperature;
            specifications.TimeOfDay = string.IsNullOrEmpty(timeOfDay) ? GetRandomFrom(allTimesOfDay) : timeOfDay;
            specifications.Level = level > 0 ? level : Dice.Roll().d(EncounterSpecifications.MaximumLevel).AsSum() + EncounterSpecifications.MinimumLevel - 1;
            specifications.AllowAquatic = Dice.Roll().d2().AsTrueOrFalse();
            specifications.AllowUnderground = Dice.Roll().d2().AsTrueOrFalse();

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
            return CollectionSelector.SelectRandomFrom(collection);
        }
    }
}
