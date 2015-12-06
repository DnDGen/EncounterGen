using EncounterGen.Mappers;
using EncounterGen.Mappers.Domain.Collections;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EncounterGen.Tests.Unit.Mappers.Collections
{
    [TestFixture]
    public class CollectionMapperCachingProxyTests
    {
        private CollectionMapper proxy;
        private Mock<CollectionMapper> mockInnerMapper;
        private Dictionary<String, IEnumerable<String>> table;

        [SetUp]
        public void Setup()
        {
            table = new Dictionary<String, IEnumerable<String>>();
            mockInnerMapper = new Mock<CollectionMapper>();
            mockInnerMapper.Setup(m => m.Map("table name")).Returns(table);

            proxy = new CollectionMapperCachingProxy(mockInnerMapper.Object);
        }

        [Test]
        public void ReturnTableFromInnerMapper()
        {
            var result = proxy.Map("table name");
            Assert.That(result, Is.EqualTo(table));
        }

        [Test]
        public void CacheTable()
        {
            proxy.Map("table name");
            var result = proxy.Map("table name");

            Assert.That(result, Is.EqualTo(table));
            mockInnerMapper.Verify(p => p.Map(It.IsAny<String>()), Times.Once);
        }
    }
}
