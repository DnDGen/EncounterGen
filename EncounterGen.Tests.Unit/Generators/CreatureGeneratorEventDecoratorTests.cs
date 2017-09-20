using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EncounterGen.Generators;
using EventGen;
using Moq;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class CreatureGeneratorEventDecoratorTests
    {
        private ICreatureGenerator eventDecorator;
        private Mock<ICreatureGenerator> mockInternalGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInternalGenerator = new Mock<ICreatureGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();

            eventDecorator = new CreatureGeneratorEventDecorator(mockInternalGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void DecoratorReturnsInternalCreatures()
        {
            var creatures = new[] { new Creature(), new Creature() };

            var specifications = new EncounterSpecifications();
            specifications.Environment = "environment";
            specifications.Level = 42;
            specifications.Temperature = "temperature";
            specifications.TimeOfDay = "time of day";

            mockInternalGenerator.Setup(g => g.GenerateFor(specifications)).Returns(creatures);

            var generatedCreatures = eventDecorator.GenerateFor(specifications);

            Assert.That(generatedCreatures, Is.EqualTo(creatures));
        }

        [Test]
        public void DecoratorLogsEvents()
        {
            var creatures = new[] { new Creature(), new Creature() };

            var specifications = new EncounterSpecifications();
            specifications.Environment = "environment";
            specifications.Level = 42;
            specifications.Temperature = "temperature";
            specifications.TimeOfDay = "time of day";

            mockInternalGenerator.Setup(g => g.GenerateFor(specifications)).Returns(creatures);

            var generatedCreatures = eventDecorator.GenerateFor(specifications);

            Assert.That(generatedCreatures, Is.EqualTo(creatures));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Generating creatures for {specifications.Description}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Generated 2 creatures"), Times.Once);
        }

        [Test]
        public void DecoratorReturnsCleanedInternalCreatures()
        {
            var creatures = new[] { new Creature(), new Creature() };
            var internalCleanedCreatures = new[] { new Creature(), new Creature() };

            mockInternalGenerator.Setup(g => g.CleanCreatures(creatures)).Returns(internalCleanedCreatures);

            var cleanedCreatures = eventDecorator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.EqualTo(internalCleanedCreatures));
            Assert.That(cleanedCreatures, Is.Not.EqualTo(creatures));
        }

        [Test]
        public void DecoratorLogsEventsForCleaning()
        {
            var creatures = new[] { new Creature(), new Creature() };
            var internalCleanedCreatures = new[] { new Creature(), new Creature() };

            mockInternalGenerator.Setup(g => g.CleanCreatures(creatures)).Returns(internalCleanedCreatures);

            var cleanedCreatures = eventDecorator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.EqualTo(internalCleanedCreatures));
            Assert.That(cleanedCreatures, Is.Not.EqualTo(creatures));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Cleaning 2 creatures"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Cleaned 2 creatures"), Times.Once);
        }
    }
}
