using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class CreatureTypeTests
    {
        private CreatureType creatureType;

        [SetUp]
        public void Setup()
        {
            creatureType = new CreatureType();
        }

        [Test]
        public void CreatureTypeInitialized()
        {
            Assert.That(creatureType.Name, Is.Empty);
            Assert.That(creatureType.Description, Is.Empty);
            Assert.That(creatureType.SubType, Is.Null);
        }

        [Test]
        public void CreateSubtype()
        {
            creatureType.SubType = new CreatureType();
            Assert.That(creatureType.SubType.Name, Is.Empty);
            Assert.That(creatureType.SubType.Description, Is.Empty);
            Assert.That(creatureType.SubType.SubType, Is.Null);
        }
    }
}
