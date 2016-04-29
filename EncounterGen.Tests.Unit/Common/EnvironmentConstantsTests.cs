using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class EnvironmentConstantsTests
    {
        [TestCase(EnvironmentConstants.ColdForestDay, "Cold Forest Day")]
        [TestCase(EnvironmentConstants.TemperateForestDay, "Temperate Forest Day")]
        [TestCase(EnvironmentConstants.WarmForestDay, "Warm Forest Day")]
        [TestCase(EnvironmentConstants.ColdMarshDay, "Cold Marsh Day")]
        [TestCase(EnvironmentConstants.TemperateMarshDay, "Temperate Marsh Day")]
        [TestCase(EnvironmentConstants.WarmMarshDay, "Warm Marsh Day")]
        [TestCase(EnvironmentConstants.ColdHillsDay, "Cold Hills Day")]
        [TestCase(EnvironmentConstants.TemperateHillsDay, "Temperate Hills Day")]
        [TestCase(EnvironmentConstants.WarmHillsDay, "Warm Hills Day")]
        [TestCase(EnvironmentConstants.ColdMountainDay, "Cold Mountain Day")]
        [TestCase(EnvironmentConstants.TemperateMountainDay, "Temperate Mountain Day")]
        [TestCase(EnvironmentConstants.WarmMountainDay, "Warm Mountain Day")]
        [TestCase(EnvironmentConstants.ColdDesertDay, "Cold Desert Day")]
        [TestCase(EnvironmentConstants.TemperateDesertDay, "Temperate Desert Day")]
        [TestCase(EnvironmentConstants.WarmDesertDay, "Warm Desert Day")]
        [TestCase(EnvironmentConstants.ColdPlainsDay, "Cold Plains Day")]
        [TestCase(EnvironmentConstants.TemperatePlainsDay, "Temperate Plains Day")]
        [TestCase(EnvironmentConstants.WarmPlainsDay, "Warm Plains Day")]
        [TestCase(EnvironmentConstants.Dungeon, "Dungeon")]
        [TestCase(EnvironmentConstants.CivilizedDay, "Civilized Day")]
        [TestCase(EnvironmentConstants.ColdForestNight, "Cold Forest Night")]
        [TestCase(EnvironmentConstants.TemperateForestNight, "Temperate Forest Night")]
        [TestCase(EnvironmentConstants.WarmForestNight, "Warm Forest Night")]
        [TestCase(EnvironmentConstants.ColdMarshNight, "Cold Marsh Night")]
        [TestCase(EnvironmentConstants.TemperateMarshNight, "Temperate Marsh Night")]
        [TestCase(EnvironmentConstants.WarmMarshNight, "Warm Marsh Night")]
        [TestCase(EnvironmentConstants.ColdHillsNight, "Cold Hills Night")]
        [TestCase(EnvironmentConstants.TemperateHillsNight, "Temperate Hills Night")]
        [TestCase(EnvironmentConstants.WarmHillsNight, "Warm Hills Night")]
        [TestCase(EnvironmentConstants.ColdMountainNight, "Cold Mountain Night")]
        [TestCase(EnvironmentConstants.TemperateMountainNight, "Temperate Mountain Night")]
        [TestCase(EnvironmentConstants.WarmMountainNight, "Warm Mountain Night")]
        [TestCase(EnvironmentConstants.ColdDesertNight, "Cold Desert Night")]
        [TestCase(EnvironmentConstants.TemperateDesertNight, "Temperate Desert Night")]
        [TestCase(EnvironmentConstants.WarmDesertNight, "Warm Desert Night")]
        [TestCase(EnvironmentConstants.ColdPlainsNight, "Cold Plains Night")]
        [TestCase(EnvironmentConstants.TemperatePlainsNight, "Temperate Plains Night")]
        [TestCase(EnvironmentConstants.WarmPlainsNight, "Warm Plains Night")]
        [TestCase(EnvironmentConstants.CivilizedNight, "Civilized Night")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
