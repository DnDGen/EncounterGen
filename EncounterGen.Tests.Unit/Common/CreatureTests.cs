using DnDGen.EncounterGen.Models;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit.Common
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
            Assert.That(creature.Type, Is.Not.Null);
            Assert.That(creature.ChallengeRating, Is.Empty);
        }
    }
}
