using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EventGen;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using TreasureGen;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterTreasureGeneratorEventDecoratorTests
    {
        private IEncounterTreasureGenerator eventDecorator;
        private Mock<IEncounterTreasureGenerator> mockInternalGenerator;
        private Mock<GenEventQueue> mockEventQueue;
        private List<Creature> creatures;

        [SetUp]
        public void Setup()
        {
            mockInternalGenerator = new Mock<IEncounterTreasureGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();

            eventDecorator = new EncounterTreasureGeneratorEventDecorator(mockInternalGenerator.Object, mockEventQueue.Object);

            creatures = new List<Creature>();
            creatures.Add(new Creature());
            creatures.Add(new Creature());
        }

        [Test]
        public void DecoratorReturnsInternalTreasures()
        {
            var treasures = new[] { new Treasure(), new Treasure(), new Treasure() };
            mockInternalGenerator.Setup(g => g.GenerateFor(creatures, 9266)).Returns(treasures);

            var generatedTreasures = eventDecorator.GenerateFor(creatures, 9266);

            Assert.That(generatedTreasures, Is.EqualTo(treasures));
        }

        [Test]
        public void DecoratorLogsEvents()
        {
            var treasures = new[] { new Treasure(), new Treasure(), new Treasure() };
            mockInternalGenerator.Setup(g => g.GenerateFor(creatures, 9266)).Returns(treasures);

            var generatedTreasures = eventDecorator.GenerateFor(creatures, 9266);

            Assert.That(generatedTreasures, Is.EqualTo(treasures));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Generating level 9266 treasure for 2 creatures"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Generated 3 treasures"), Times.Once);
        }
    }
}
