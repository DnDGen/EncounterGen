using EncounterGen.Domain.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class EncounterCollectionSelectorCachingProxyTests
    {
        private IEncounterCollectionSelector cachingProxy;
        private Mock<IEncounterCollectionSelector> mockInnerSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IEncounterCollectionSelector>();
            mockCollectionSelector = new Mock<ICollectionSelector>();
            cachingProxy = new EncounterCollectionSelectorCachingProxy(mockInnerSelector.Object, mockCollectionSelector.Object);
        }

        [Test]
        public void CacheResultsFromSelectingAllWeighted()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day")).Returns(collection);

            var result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Once);
        }

        [Test]
        public void CacheKeyIsUniquePerLevel()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day")).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(90210, "environment", "temperature", "time of day")).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(90210, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(90210, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));
        }

        [Test]
        public void CacheKeyIsUniquePerEnvironment()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day")).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "other environment", "temperature", "time of day")).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(9266, "other environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "other environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));
        }

        [Test]
        public void CacheKeyIsUniquePerTimeOfDay()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day")).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "other temperature", "time of day")).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "other temperature", "time of day");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "other temperature", "time of day");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));
        }

        [Test]
        public void CacheKeyIsUniquePerTemperature()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day")).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "other time of day")).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "other time of day");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "other time of day");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));
        }

        [Test]
        public void CacheKeyIsUniqueWithFilter()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day")).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter")).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));
        }

        [Test]
        public void CacheKeyIsUniqueBetweenFilters()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter")).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "other filter")).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "other filter");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "other filter");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));
        }

        [Test]
        public void CacheKeyIsUniqueWithMultipleFilters()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter")).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter", "other filter")).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter");
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter", "other filter");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter");
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day", "filter", "other filter");
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Exactly(2));
        }

        [Test]
        public void SelectRandomFromCachedWeightedEncounters()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day")).Returns(collection);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(collection)).Returns(collection.First()).Returns(collection.Last());

            var result = cachingProxy.SelectRandomFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection.First()));

            result = cachingProxy.SelectRandomFrom(9266, "environment", "temperature", "time of day");
            Assert.That(result, Is.EqualTo(collection.Last()));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Once);
            mockInnerSelector.Verify(s => s.SelectRandomFrom(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string[]>()), Times.Never);
        }

        [Test]
        public void IfCacheIsEmpty_ThrowException()
        {
            var collection = Enumerable.Empty<Dictionary<string, string>>();

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(9266, "environment", "temperature", "time of day")).Returns(collection);

            Assert.That(() => cachingProxy.SelectRandomFrom(9266, "environment", "temperature", "time of day"), Throws.ArgumentException.With.Message.EqualTo("No valid level 9266 encounters exist for temperature environment time of day"));
        }
    }
}
