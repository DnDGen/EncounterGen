using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class EnvironmentConstantsTests
    {
        [TestCase(EnvironmentConstants.Forest, "Forest")]
        [TestCase(EnvironmentConstants.Marsh, "Marsh")]
        [TestCase(EnvironmentConstants.Hills, "Hills")]
        [TestCase(EnvironmentConstants.Mountain, "Mountain")]
        [TestCase(EnvironmentConstants.Desert, "Desert")]
        [TestCase(EnvironmentConstants.Plains, "Plains")]
        [TestCase(EnvironmentConstants.Dungeon, "Dungeon")]
        [TestCase(EnvironmentConstants.Civilized, "Civilized")]
        [TestCase(EnvironmentConstants.Temperatures.Cold, "Cold")]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, "Temperate")]
        [TestCase(EnvironmentConstants.Temperatures.Warm, "Warm")]
        [TestCase(EnvironmentConstants.TimesOfDay.Day, "Day")]
        [TestCase(EnvironmentConstants.TimesOfDay.Night, "Night")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
