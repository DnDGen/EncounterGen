using DnDGen.EncounterGen.Models;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit.Models
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
        [TestCase(EnvironmentConstants.Any, "Any")]
        [TestCase(EnvironmentConstants.Land, "Land")]
        [TestCase(EnvironmentConstants.Plane_Air, "Elemental Plane of Air")]
        [TestCase(EnvironmentConstants.Plane_Astral, "Astral Plane")]
        [TestCase(EnvironmentConstants.Plane_Chaotic, "A chaotic-aligned plane")]
        [TestCase(EnvironmentConstants.Plane_ChaoticEvil, "A chaotic-evil-aligned plane")]
        [TestCase(EnvironmentConstants.Plane_ChaoticGood, "A chaotic-good-aligned plane")]
        [TestCase(EnvironmentConstants.Plane_Earth, "Elemental Plane of Earth")]
        [TestCase(EnvironmentConstants.Plane_Ethereal, "Ethereal Plane")]
        [TestCase(EnvironmentConstants.Plane_Evil, "An evil-aligned plane")]
        [TestCase(EnvironmentConstants.Plane_Fire, "Elemental Plane of Fire")]
        [TestCase(EnvironmentConstants.Plane_Good, "A good-aligned plane")]
        [TestCase(EnvironmentConstants.Plane_Lawful, "A lawful-aligned plane")]
        [TestCase(EnvironmentConstants.Plane_LawfulEvil, "A lawful-evil-aligned plane")]
        [TestCase(EnvironmentConstants.Plane_LawfulGood, "A lawful-good-aligned plane")]
        [TestCase(EnvironmentConstants.Plane_Limbo, "Plane of Limbo")]
        [TestCase(EnvironmentConstants.Plane_NeutralEvil, "A neutral-evil-aligned plane")]
        [TestCase(EnvironmentConstants.Plane_PositiveEnergy, "Positive Energy Plane")]
        [TestCase(EnvironmentConstants.Plane_Shadow, "Plane of Shadow")]
        [TestCase(EnvironmentConstants.Plane_Water, "Elemental Plane of Water")]
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
