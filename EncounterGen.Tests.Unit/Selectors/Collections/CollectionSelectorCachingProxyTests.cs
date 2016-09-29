using EncounterGen.Domain.Selectors.Collections;
using Moq;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class CollectionSelectorCachingProxyTests
    {
        private ICollectionSelector cachingProxy;
        private Mock<ICollectionSelector> mockInnerSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<ICollectionSelector>();
            cachingProxy = new CollectionSelectorCachingProxy(mockInnerSelector.Object);
        }

        [Test]
        public void PassThroughToSelectFrom()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(collection);

            var result = cachingProxy.SelectFrom("table name", "entry");
            Assert.That(result, Is.EqualTo(collection));
        }

        [Test]
        public void PassThroughToSelectRandomFrom()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.SelectRandomFrom(collection)).Returns("random result");

            var result = cachingProxy.SelectRandomFrom(collection);
            Assert.That(result, Is.EqualTo("random result"));
        }

        [Test]
        public void PassThroughToIsGroup()
        {
            mockInnerSelector.Setup(s => s.IsGroup("table name", "entry")).Returns(true);

            var result = cachingProxy.IsGroup("table name", "entry");
            Assert.That(result, Is.True);
        }

        [Test]
        public void PassThroughToIsNotGroup()
        {
            mockInnerSelector.Setup(s => s.IsGroup("table name", "entry")).Returns(false);

            var result = cachingProxy.IsGroup("table name", "entry");
            Assert.That(result, Is.False);
        }

        [Test]
        public void CacheExplodeIntoResultsFromInnerSelector()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.ExplodeInto("table name", "entry", "into this")).Returns(collection);

            var result = cachingProxy.ExplodeInto("table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.ExplodeInto("table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.ExplodeInto(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void ExplodeResultsCachedByUniqueFrom()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.ExplodeInto("table name", "entry", "into this")).Returns(collection);

            var otherCollection = new[] { "thing 3", "thing 4" };
            mockInnerSelector.Setup(s => s.ExplodeInto("other table name", "entry", "into this")).Returns(otherCollection);

            var result = cachingProxy.ExplodeInto("table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.ExplodeInto("other table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.ExplodeInto(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));

            result = cachingProxy.ExplodeInto("table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.ExplodeInto(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));

            result = cachingProxy.ExplodeInto("other table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.ExplodeInto(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void ExplodeResultsCachedByUniqueName()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.ExplodeInto("table name", "entry", "into this")).Returns(collection);

            var otherCollection = new[] { "thing 3", "thing 4" };
            mockInnerSelector.Setup(s => s.ExplodeInto("table name", "other entry", "into this")).Returns(otherCollection);

            var result = cachingProxy.ExplodeInto("table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.ExplodeInto("table name", "other entry", "into this");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.ExplodeInto(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));

            result = cachingProxy.ExplodeInto("table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.ExplodeInto(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));

            result = cachingProxy.ExplodeInto("table name", "other entry", "into this");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.ExplodeInto(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void ExplodeResultsCachedByUniqueInto()
        {
            var collection = new[] { "thing 1", "thing 2" };
            mockInnerSelector.Setup(s => s.ExplodeInto("table name", "entry", "into this")).Returns(collection);

            var otherCollection = new[] { "thing 3", "thing 4" };
            mockInnerSelector.Setup(s => s.ExplodeInto("table name", "entry", "other into this")).Returns(otherCollection);

            var result = cachingProxy.ExplodeInto("table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.ExplodeInto("table name", "entry", "other into this");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.ExplodeInto(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));

            result = cachingProxy.ExplodeInto("table name", "entry", "into this");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.ExplodeInto(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));

            result = cachingProxy.ExplodeInto("table name", "entry", "other into this");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.ExplodeInto(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
