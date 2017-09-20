using CharacterGen.Characters;
using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EventGen;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterCharacterGeneratorEventDecoratorTests
    {
        private IEncounterCharacterGenerator eventDecorator;
        private Mock<IEncounterCharacterGenerator> mockInternalGenerator;
        private Mock<GenEventQueue> mockEventQueue;
        private List<Creature> creatures;

        [SetUp]
        public void Setup()
        {
            mockInternalGenerator = new Mock<IEncounterCharacterGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();

            eventDecorator = new EncounterCharacterGeneratorEventDecorator(mockInternalGenerator.Object, mockEventQueue.Object);

            creatures = new List<Creature>();
            creatures.Add(new Creature());
            creatures.Add(new Creature());
        }

        [Test]
        public void DecoratorReturnsInternalCharacters()
        {
            var characters = new[] { new Character(), new Character(), new Character() };
            mockInternalGenerator.Setup(g => g.GenerateFrom(creatures)).Returns(characters);

            var generatedCharacters = eventDecorator.GenerateFrom(creatures);

            Assert.That(generatedCharacters, Is.EqualTo(characters));
        }

        [Test]
        public void DecoratorLogsEvents()
        {
            var characters = new[] { new Character(), new Character(), new Character() };
            mockInternalGenerator.Setup(g => g.GenerateFrom(creatures)).Returns(characters);

            var generatedCharacters = eventDecorator.GenerateFrom(creatures);

            Assert.That(generatedCharacters, Is.EqualTo(characters));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Generating characters from 2 creatures"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Generated 3 characters"), Times.Once);
        }
    }
}
