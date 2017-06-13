using EncounterGen.Domain.Selectors.Collections;
using EventGen;
using Moq;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class CollectionSelectorEventDecoratorTests
    {
        private ICollectionSelector decorator;
        private Mock<ICollectionSelector> mockInnerSelector;
        private Mock<GenEventQueue> mockEventQueue;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ICollectionSelector>();
            mockEventQueue = new Mock<GenEventQueue>();
            decorator = new CollectionSelectorEventDecorator(mockInnerSelector.Object, mockEventQueue.Object);
        }

        [Test]
        public void PassThroughToSelectFrom()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(collection);

            var result = decorator.SelectFrom("table name", "entry");
            Assert.That(result, Is.EqualTo(collection));
        }

        [Test]
        public void LogEventsForSelectFrom()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(collection);

            var result = decorator.SelectFrom("table name", "entry");
            Assert.That(result, Is.EqualTo(collection));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Selecting entry from table name"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Finished selecting entry from table name"), Times.Once);
        }

        [Test]
        public void PassThroughToSelectRandomFrom()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.SelectRandomFrom(collection)).Returns("random result");

            var result = decorator.SelectRandomFrom(collection);
            Assert.That(result, Is.EqualTo("random result"));
        }

        [Test]
        public void LogNoEventsForSelectRandomFrom()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.SelectRandomFrom(collection)).Returns("random result");

            var result = decorator.SelectRandomFrom(collection);
            Assert.That(result, Is.EqualTo("random result"));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void PassThroughToIsGroup()
        {
            mockInnerSelector.Setup(s => s.IsGroup("table name", "entry")).Returns(true);

            var result = decorator.IsGroup("table name", "entry");
            Assert.That(result, Is.True);
        }

        [Test]
        public void LogNoEventsForIsGroup()
        {
            mockInnerSelector.Setup(s => s.IsGroup("table name", "entry")).Returns(true);

            var result = decorator.IsGroup("table name", "entry");
            Assert.That(result, Is.True);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void PassThroughToIsNotGroup()
        {
            mockInnerSelector.Setup(s => s.IsGroup("table name", "entry")).Returns(false);

            var result = decorator.IsGroup("table name", "entry");
            Assert.That(result, Is.False);
        }

        [Test]
        public void LogNoEventsForIsNotGroup()
        {
            mockInnerSelector.Setup(s => s.IsGroup("table name", "entry")).Returns(false);

            var result = decorator.IsGroup("table name", "entry");
            Assert.That(result, Is.False);
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void ExplodeIntoResultsFromInnerSelector()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.ExplodeInto("table name", "entry", "into this")).Returns(collection);

            var result = decorator.ExplodeInto("table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(collection));
        }

        [Test]
        public void LogEventsForExplodeInto()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.ExplodeInto("table name", "entry", "into this")).Returns(collection);

            var result = decorator.ExplodeInto("table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(collection));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Exploding entry into into this from table name"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Finished exploding entry into into this from table name"), Times.Once);
        }

        [Test]
        public void ExplodeResultsFromInnerSelector()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.Explode("table name", "entry")).Returns(collection);

            var result = decorator.Explode("table name", "entry");
            Assert.That(result, Is.EqualTo(collection));
        }

        [Test]
        public void LogEventsForExplode()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.Explode("table name", "entry")).Returns(collection);

            var result = decorator.Explode("table name", "entry");
            Assert.That(result, Is.EqualTo(collection));
            mockEventQueue.Verify(q => q.Enqueue(It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Exploding entry from table name"), Times.Once);
            mockEventQueue.Verify(q => q.Enqueue("EncounterGen", "Finished exploding entry from table name"), Times.Once);
        }
    }
}
