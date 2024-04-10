using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors.Collections;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Tests.Integration.Selectors.Collections
{
    [TestFixture]
    public class EncounterCollectionSelectorTests : IntegrationTests
    {
        private IEncounterCollectionSelector encounterCollectionSelector;

        [SetUp]
        public void Setup()
        {
            encounterCollectionSelector = GetNewInstanceOf<IEncounterCollectionSelector>();
        }

        [TestCase(1, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(1, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(1, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(1, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(1, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(1, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(2, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(2, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(3, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(3, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(20, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, false, true)]
        public void RandomEncounterCollectionSelectionIsFast(int level, string temperature, string environment, string timeOfDay, bool allowAquatic, bool allowUnderground, params string[] filters)
        {
            var specifications = new EncounterSpecifications();
            specifications.Level = level;
            specifications.Temperature = temperature;
            specifications.Environment = environment;
            specifications.TimeOfDay = timeOfDay;
            specifications.AllowAquatic = allowAquatic;
            specifications.AllowUnderground = allowUnderground;
            specifications.CreatureTypeFilters = filters;

            var encounter = encounterCollectionSelector.SelectRandomFrom(specifications);

            AssertEncounter(encounter);
        }

        private void AssertEncounter(Dictionary<string, string> encounter)
        {
            Assert.That(encounter, Is.Not.Empty);
            Assert.That(encounter.Keys, Is.All.Not.Empty);
            Assert.That(encounter.Values, Is.All.Not.Empty);
        }

        [TestCase(1, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.Forest, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(1, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(1, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(1, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(1, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(1, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Plains, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(2, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.Hills, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(2, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.Mountain, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(3, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(3, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(20, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Night, false, true)]
        public void EncounterCollectionSelectionIsFast(int level, string temperature, string environment, string timeOfDay, bool allowAquatic, bool allowUnderground, params string[] filters)
        {
            var specifications = new EncounterSpecifications();
            specifications.Level = level;
            specifications.Temperature = temperature;
            specifications.Environment = environment;
            specifications.TimeOfDay = timeOfDay;
            specifications.AllowAquatic = allowAquatic;
            specifications.AllowUnderground = allowUnderground;
            specifications.CreatureTypeFilters = filters;

            var collection = encounterCollectionSelector.SelectAllWeightedFrom(specifications);

            Assert.That(collection, Is.Not.Empty);

            foreach (var encounter in collection)
                AssertEncounter(encounter);
        }
    }
}
