using EncounterGen.Generators;
using EncounterGen.Generators.Domain;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterGeneratorTests
    {
        private IEncounterGenerator encounterGenerator;

        [SetUp]
        public void Setup()
        {
            encounterGenerator = new EncounterGenerator();
        }

        [Test]
        public void GenerateEncounter()
        {
            var encounter = encounterGenerator.Generate("environment", 9266);
            Assert.That(encounter, Is.Not.Null);
        }
    }
}
