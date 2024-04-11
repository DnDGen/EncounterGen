using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration.Generators
{
    [TestFixture]
    public class EncounterVerifierTests : IntegrationTests
    {
        private IEncounterVerifier encounterVerifier;

        [SetUp]
        public void Setup()
        {
            encounterVerifier = GetNewInstanceOf<IEncounterVerifier>();
        }

        [TestCase(1, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, false, false, true)]
        [TestCase(1, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, false, false, true)]
        [TestCase(1, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, false, false, true)]
        [TestCase(4, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, false, false, true)]
        [TestCase(4, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, false, true, true)]
        [TestCase(4, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, true, false, true)]
        [TestCase(4, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, true, true, true)]
        [TestCase(4, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, false, false, false, CreatureConstants.Types.Giant)]
        [TestCase(4, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Civilized, EnvironmentConstants.TimesOfDay.Day, false, false, true, CreatureConstants.Types.Humanoid)]
        [TestCase(10, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, false, false, true)]
        [TestCase(10, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, false, true, true)]
        [TestCase(10, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, true, false, true)]
        [TestCase(10, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, true, true, true)]
        [TestCase(10, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, false, false, false, CreatureConstants.Types.Fey)]
        [TestCase(10, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.Underground, EnvironmentConstants.TimesOfDay.Night, false, false, true, CreatureConstants.Types.Humanoid)]
        [TestCase(21, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, false, false, true)]
        [TestCase(21, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, false, true, true)]
        [TestCase(21, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, true, false, true)]
        [TestCase(21, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, true, true, true)]
        [TestCase(21, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, false, false, true, CreatureConstants.Types.Humanoid)]
        [TestCase(21, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.Marsh, EnvironmentConstants.TimesOfDay.Day, false, false, false, CreatureConstants.Types.MonstrousHumanoid)]
        public void EncounterVerificationHasAppropriateEventSpacing(int level, string temperature, string environment, string timeOfDay, bool allowAquatic, bool allowUnderground, bool isValid, params string[] filters)
        {
            var specifications = new EncounterSpecifications();
            specifications.Level = level;
            specifications.Temperature = temperature;
            specifications.Environment = environment;
            specifications.TimeOfDay = timeOfDay;
            specifications.AllowAquatic = allowAquatic;
            specifications.AllowUnderground = allowUnderground;
            specifications.CreatureTypeFilters = filters;

            var filterIsValid = encounterVerifier.ValidEncounterExistsAtLevel(specifications);

            Assert.That(filterIsValid, Is.EqualTo(isValid));
            AssertEventSpacing();
        }
    }
}
