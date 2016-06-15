using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class CreatureTests
    {
        private Creature creature;

        [SetUp]
        public void Setup()
        {
            creature = new Creature();
        }

        [Test]
        public void CreatureInitialized()
        {
            Assert.That(creature.Quantity, Is.EqualTo(0));
            Assert.That(creature.Name, Is.Empty);
            Assert.That(creature.Description, Is.Empty);
        }
    }
}
