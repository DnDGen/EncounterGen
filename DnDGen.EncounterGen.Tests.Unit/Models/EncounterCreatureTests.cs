using DnDGen.EncounterGen.Models;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit.Models
{
    [TestFixture]
    public class EncounterCreatureTests
    {
        private EncounterCreature encounterCreature;

        [SetUp]
        public void Setup()
        {
            encounterCreature = new EncounterCreature();
        }

        [Test]
        public void CreatureInitialized()
        {
            Assert.That(encounterCreature.Quantity, Is.EqualTo(0));
            Assert.That(encounterCreature.Creature, Is.Not.Null);
            Assert.That(encounterCreature.ChallengeRating, Is.Empty);
        }
    }
}
