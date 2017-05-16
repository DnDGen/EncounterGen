using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class EnvironmentConstantsTests
    {
        [TestCase(EnvironmentConstants.Aquatic, "Aquatic")]
        [TestCase(EnvironmentConstants.Civilized, "Civilized")]
        [TestCase(EnvironmentConstants.Desert, "Desert")]
        [TestCase(EnvironmentConstants.Forest, "Forest")]
        [TestCase(EnvironmentConstants.Hills, "Hills")]
        [TestCase(EnvironmentConstants.Marsh, "Marsh")]
        [TestCase(EnvironmentConstants.Mountain, "Mountain")]
        [TestCase(EnvironmentConstants.Plains, "Plains")]
        [TestCase(EnvironmentConstants.Underground, "Underground")]
        [TestCase(EnvironmentConstants.Temperatures.Cold, "Cold")]
        [TestCase(EnvironmentConstants.Temperatures.Temperate, "Temperate")]
        [TestCase(EnvironmentConstants.Temperatures.Warm, "Warm")]
        [TestCase(EnvironmentConstants.TimesOfDay.Day, "Day")]
        [TestCase(EnvironmentConstants.TimesOfDay.Night, "Night")]
        public void EnvironmentConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
