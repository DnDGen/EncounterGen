using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Selectors.Collections;
using DnDGen.Infrastructure.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class EncounterCollectionSelectorCachingProxyTests
    {
        private IEncounterCollectionSelector cachingProxy;
        private Mock<IEncounterCollectionSelector> mockInnerSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private EncounterSpecifications specifications;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IEncounterCollectionSelector>();
            mockCollectionSelector = new Mock<ICollectionSelector>();
            cachingProxy = new EncounterCollectionSelectorCachingProxy(mockInnerSelector.Object, mockCollectionSelector.Object);
            specifications = new EncounterSpecifications();

            specifications.Level = 9266;
            specifications.Environment = "environment";
            specifications.Temperature = "temperature";
            specifications.TimeOfDay = "time of day";
        }

        [Test]
        public void SelectAllWeightedFrom_CacheResultsFromSelectingAllWeighted()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            var result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Once);
        }

        [Test]
        public void SelectAllWeightedFrom_CacheSimilarResultsFromSelectingAllWeighted()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            var result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            var clone = specifications.Clone();

            result = cachingProxy.SelectAllWeightedFrom(clone);

            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Once);
        }

        [Test]
        public void SelectAllWeightedFrom_CacheKeyIsUniquePerLevel()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            var otherSpecs = specifications.Clone();
            otherSpecs.Level = 90210;

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedFrom_CacheKeyIsUniquePerEnvironment()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            var otherSpecs = specifications.Clone();
            otherSpecs.Environment = "other environment";

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedFrom_CacheKeyIsUniquePerTimeOfDay()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            var otherSpecs = specifications.Clone();
            otherSpecs.TimeOfDay = "other time of day";

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedFrom_CacheKeyIsUniquePerTemperature()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            var otherSpecs = specifications.Clone();
            otherSpecs.Temperature = "other temperature";

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedFrom_CacheKeyIsUniqueWithFilter()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            var otherSpecs = specifications.Clone();
            otherSpecs.CreatureTypeFilters = new[] { "filter" };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedFrom_CacheKeyIsUniqueBetweenFilters()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            var otherSpecs = specifications.Clone();
            otherSpecs.CreatureTypeFilters = new[] { "other filter" };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedFrom_CacheKeyIsUniqueWithMultipleFilters()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            var otherCollection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            var otherSpecs = specifications.Clone();
            otherSpecs.CreatureTypeFilters = new[] { "filter", "other filter" };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectRandomFrom_SelectRandomFromCachedWeightedEncounters()
        {
            var collection = new[]
            {
                new Dictionary<string, string>(),
                new Dictionary<string, string>(),
            };

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(collection)).Returns(collection.First()).Returns(collection.Last());

            var result = cachingProxy.SelectRandomFrom(specifications);
            Assert.That(result, Is.EqualTo(collection.First()));

            result = cachingProxy.SelectRandomFrom(specifications);
            Assert.That(result, Is.EqualTo(collection.Last()));
            mockInnerSelector.Verify(s => s.SelectAllWeightedFrom(It.IsAny<EncounterSpecifications>()), Times.Once);
            mockInnerSelector.Verify(s => s.SelectRandomFrom(It.IsAny<EncounterSpecifications>()), Times.Never);
        }

        [Test]
        public void SelectRandomFrom_IfCacheIsEmpty_ThrowException()
        {
            var collection = Enumerable.Empty<Dictionary<string, string>>();

            mockInnerSelector.Setup(s => s.SelectAllWeightedFrom(specifications)).Returns(collection);

            Assert.That(() => cachingProxy.SelectRandomFrom(specifications), Throws.ArgumentException.With.Message.EqualTo($"No valid encounters exist for {specifications.Description}"));
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CacheResultsFromSelectingAllWeighted()
        {
            var collection = new[] { "encounter 1", "encounter 2" };
            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            var result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Once);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CacheSimilarResultsFromSelectingAllWeighted()
        {
            var collection = new[] { "encounter 1", "encounter 2" };
            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            var result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            var clone = specifications.Clone();

            result = cachingProxy.SelectAllWeightedEncountersFrom(clone);

            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Once);
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CacheKeyIsUniquePerLevel()
        {
            var collection = new[] { "encounter 1", "encounter 2" };
            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            var otherCollection = new[] { "other encounter 1", "other encounter 2" };

            var otherSpecs = specifications.Clone();
            otherSpecs.Level = 90210;

            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CacheKeyIsUniquePerEnvironment()
        {
            var collection = new[] { "encounter 1", "encounter 2" };
            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            var otherCollection = new[] { "other encounter 1", "other encounter 2" };

            var otherSpecs = specifications.Clone();
            otherSpecs.Environment = "other environment";

            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CacheKeyIsUniquePerTimeOfDay()
        {
            var collection = new[] { "encounter 1", "encounter 2" };
            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            var otherCollection = new[] { "other encounter 1", "other encounter 2" };

            var otherSpecs = specifications.Clone();
            otherSpecs.TimeOfDay = "other time of day";

            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CacheKeyIsUniquePerTemperature()
        {
            var collection = new[] { "encounter 1", "encounter 2" };
            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            var otherCollection = new[] { "other encounter 1", "other encounter 2" };

            var otherSpecs = specifications.Clone();
            otherSpecs.Temperature = "other temperature";

            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CacheKeyIsUniqueWithFilter()
        {
            var collection = new[] { "encounter 1", "encounter 2" };
            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            var otherCollection = new[] { "other encounter 1", "other encounter 2" };

            var otherSpecs = specifications.Clone();
            otherSpecs.CreatureTypeFilters = new[] { "filter" };

            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CacheKeyIsUniqueBetweenFilters()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var collection = new[] { "encounter 1", "encounter 2" };
            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            var otherCollection = new[] { "other encounter 1", "other encounter 2" };

            var otherSpecs = specifications.Clone();
            otherSpecs.CreatureTypeFilters = new[] { "other filter" };

            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectAllWeightedEncountersFrom_CacheKeyIsUniqueWithMultipleFilters()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var collection = new[] { "encounter 1", "encounter 2" };
            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            var otherCollection = new[] { "other encounter 1", "other encounter 2" };

            var otherSpecs = specifications.Clone();
            otherSpecs.CreatureTypeFilters = new[] { "filter", "other filter" };

            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(otherSpecs)).Returns(otherCollection);

            var result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(specifications);
            Assert.That(result, Is.EqualTo(collection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));

            result = cachingProxy.SelectAllWeightedEncountersFrom(otherSpecs);
            Assert.That(result, Is.EqualTo(otherCollection));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Exactly(2));
        }

        [Test]
        public void SelectRandomEncounterFrom_SelectRandomFromCachedWeightedEncounters()
        {
            var collection = new[] { "encounter 1", "encounter 2" };
            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(collection)).Returns(collection.First()).Returns(collection.Last());

            var result = cachingProxy.SelectRandomEncounterFrom(specifications);
            Assert.That(result, Is.EqualTo(collection.First()));

            result = cachingProxy.SelectRandomEncounterFrom(specifications);
            Assert.That(result, Is.EqualTo(collection.Last()));
            mockInnerSelector.Verify(s => s.SelectAllWeightedEncountersFrom(It.IsAny<EncounterSpecifications>()), Times.Once);
            mockInnerSelector.Verify(s => s.SelectRandomEncounterFrom(It.IsAny<EncounterSpecifications>()), Times.Never);
        }

        [Test]
        public void SelectRandomEncounterFrom_IfCacheIsEmpty_ThrowException()
        {
            var collection = Enumerable.Empty<string>();

            mockInnerSelector.Setup(s => s.SelectAllWeightedEncountersFrom(specifications)).Returns(collection);

            Assert.That(() => cachingProxy.SelectRandomEncounterFrom(specifications), Throws.ArgumentException.With.Message.EqualTo($"No valid encounters exist for {specifications.Description}"));
        }
    }
}
