using EncounterGen.Common;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class EnvironmentConstantsTests
    {
        [TestCase(EnvironmentConstants.ColdForest, "Cold Forest")]
        [TestCase(EnvironmentConstants.TemperateForest, "Temperate Forest")]
        [TestCase(EnvironmentConstants.WarmForest, "Warm Forest")]
        [TestCase(EnvironmentConstants.ColdMarsh, "Cold Marsh")]
        [TestCase(EnvironmentConstants.TemperateMarsh, "Temperate Marsh")]
        [TestCase(EnvironmentConstants.WarmMarsh, "Warm Marsh")]
        [TestCase(EnvironmentConstants.ColdHills, "Cold Hills")]
        [TestCase(EnvironmentConstants.TemperateHills, "Temperate Hills")]
        [TestCase(EnvironmentConstants.WarmHills, "Warm Hills")]
        [TestCase(EnvironmentConstants.ColdMountain, "Cold Mountain")]
        [TestCase(EnvironmentConstants.TemperateMountain, "Temperate Mountain")]
        [TestCase(EnvironmentConstants.WarmMountain, "Warm Mountain")]
        [TestCase(EnvironmentConstants.ColdDesert, "Cold Desert")]
        [TestCase(EnvironmentConstants.TemperateDesert, "Temperate Desert")]
        [TestCase(EnvironmentConstants.WarmDesert, "Warm Desert")]
        [TestCase(EnvironmentConstants.ColdPlains, "Cold Plains")]
        [TestCase(EnvironmentConstants.TemperatePlains, "Temperate Plains")]
        [TestCase(EnvironmentConstants.WarmPlains, "Warm Plains")]
        [TestCase(EnvironmentConstants.Dungeon, "Dungeon")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
