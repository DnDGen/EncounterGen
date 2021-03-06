﻿using CharacterGen.Characters;
using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EncounterGen.Generators;
using EventGen;
using Moq;
using NUnit.Framework;
using TreasureGen;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterGeneratorEventDecoratorTests
    {
        private IEncounterGenerator eventDecorator;
        private Mock<IEncounterGenerator> mockInternalGenerator;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInternalGenerator = new Mock<IEncounterGenerator>();
            mockEventQueue = new Mock<GenEventQueue>();

            eventDecorator = new EncounterGeneratorEventDecorator(mockInternalGenerator.Object, mockEventQueue.Object);
        }

        [Test]
        public void DecoratorLogsEvents()
        {
            var encounter = new Encounter();
            encounter.TargetEncounterLevel = 9266;
            encounter.ActualEncounterLevel = 90210;
            encounter.Creatures = new[] { new Creature(), new Creature() };
            encounter.Characters = new[] { new Character(), new Character(), new Character() };
            encounter.Treasures = new[] { new Treasure(), new Treasure(), new Treasure(), new Treasure() };

            var specifications = new EncounterSpecifications();
            specifications.Environment = "environment";
            specifications.Level = 42;
            specifications.Temperature = "temperature";
            specifications.TimeOfDay = "time of day";

            mockInternalGenerator.Setup(g => g.Generate(specifications)).Returns(encounter);

            var generatedEncounter = eventDecorator.Generate(specifications);

            Assert.That(generatedEncounter, Is.EqualTo(encounter));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Generating encounter in {specifications.Description}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Generated Overpowering encounter with 2 creatures, 3 characters, and 4 treasures"), Times.Once);
        }
    }
}
