using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class EncounterTests
    {
        private Encounter encounter;

        [SetUp]
        public void Setup()
        {
            encounter = new Encounter();
        }

        [Test]
        public void EncounterInitialized()
        {
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Creatures, Is.Empty);
            Assert.That(encounter.Treasures, Is.Empty);
            Assert.That(encounter.AverageDifficulty, Is.Empty);
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(0));
            Assert.That(encounter.ActualDifficulty, Is.Empty);
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(0));
        }
    }
}
