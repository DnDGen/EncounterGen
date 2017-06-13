using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Generators;
using EventGen;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace EncounterGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class EncounterCollectionSelectorEventDecoratorTests
    {
        private IEncounterCollectionSelector eventDecorator;
        private Mock<IEncounterCollectionSelector> mockInnerSelector;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IEncounterCollectionSelector>();
            mockEventQueue = new Mock<GenEventQueue>();

            eventDecorator = new EncounterCollectionSelectorEventDecorator(mockInnerSelector.Object, mockEventQueue.Object);
        }

        [Test]
        public void DecoratorReturnsInnerEncounter()
        {
            var encounter = new Dictionary<string, string>();
            encounter["creature"] = "amount";
            encounter["other creature"] = "other amount";

            var specifications = new EncounterSpecifications();
            specifications.Environment = "environment";
            specifications.Level = 42;
            specifications.Temperature = "temperature";
            specifications.TimeOfDay = "time of day";

            mockInnerSelector.Setup(g => g.SelectRandomFrom(specifications)).Returns(encounter);

            var generatedEncounter = eventDecorator.SelectRandomFrom(specifications);

            Assert.That(generatedEncounter, Is.EqualTo(encounter));
        }

        [Test]
        public void DecoratorLogsEventsForRandomEncounter()
        {
            var encounter = new Dictionary<string, string>();
            encounter["creature"] = "amount";
            encounter["other creature"] = "other amount";

            var specifications = new EncounterSpecifications();
            specifications.Environment = "environment";
            specifications.Level = 42;
            specifications.Temperature = "temperature";
            specifications.TimeOfDay = "time of day";

            mockInnerSelector.Setup(g => g.SelectRandomFrom(specifications)).Returns(encounter);

            var generatedEncounter = eventDecorator.SelectRandomFrom(specifications);

            Assert.That(generatedEncounter, Is.EqualTo(encounter));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Selecting a random encounter from the encounter table for {specifications.Description}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Finished selecting a random encounter from the encounter table for {specifications.Description}"), Times.Once);
        }

        [Test]
        public void DecoratorReturnsInnerEncounterTable()
        {
            var encounters = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            encounters[0]["creature"] = "amount";
            encounters[0]["other creature"] = "other amount";
            encounters[1]["another creature"] = "another amount";

            var specifications = new EncounterSpecifications();
            specifications.Environment = "environment";
            specifications.Level = 42;
            specifications.Temperature = "temperature";
            specifications.TimeOfDay = "time of day";

            mockInnerSelector.Setup(g => g.SelectAllWeightedFrom(specifications)).Returns(encounters);

            var generatedEncounters = eventDecorator.SelectAllWeightedFrom(specifications);

            Assert.That(generatedEncounters, Is.EqualTo(encounters));
        }

        [Test]
        public void DecoratorLogsEventsForEncounterTable()
        {
            var encounters = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            encounters[0]["creature"] = "amount";
            encounters[0]["other creature"] = "other amount";
            encounters[1]["another creature"] = "another amount";

            var specifications = new EncounterSpecifications();
            specifications.Environment = "environment";
            specifications.Level = 42;
            specifications.Temperature = "temperature";
            specifications.TimeOfDay = "time of day";

            mockInnerSelector.Setup(g => g.SelectAllWeightedFrom(specifications)).Returns(encounters);

            var generatedEncounters = eventDecorator.SelectAllWeightedFrom(specifications);

            Assert.That(generatedEncounters, Is.EqualTo(encounters));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Selecting encounter table for {specifications.Description}"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", $"Finished selecting encounter table for {specifications.Description}"), Times.Once);
        }
    }
}
