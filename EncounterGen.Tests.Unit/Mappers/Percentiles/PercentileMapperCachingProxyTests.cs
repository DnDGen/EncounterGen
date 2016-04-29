using EncounterGen.Domain.Mappers.Percentiles;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace EncounterGen.Tests.Unit.Mappers.Percentiles
{
    [TestFixture]
    public class PercentileMapperCachingProxyTests
    {
        private PercentileMapper proxy;
        private Mock<PercentileMapper> mockInnerMapper;
        private Dictionary<int, string> table;
        private string tableName;

        [SetUp]
        public void Setup()
        {
            mockInnerMapper = new Mock<PercentileMapper>();
            proxy = new PercentileMapperCachingProxy(mockInnerMapper.Object);
            table = new Dictionary<int, string>();
            tableName = "table name";

            mockInnerMapper.Setup(m => m.Map(tableName)).Returns(table);
        }

        [Test]
        public void ReturnTable()
        {
            var mappedTable = proxy.Map(tableName);
            Assert.That(mappedTable, Is.EqualTo(table));
        }


        [Test]
        public void ReturnCachedTable()
        {
            proxy.Map(tableName);

            var mappedTable = proxy.Map(tableName);
            Assert.That(mappedTable, Is.EqualTo(table));
            mockInnerMapper.Verify(m => m.Map(tableName), Times.Once);
            mockInnerMapper.Verify(m => m.Map(It.IsAny<string>()), Times.Once);
        }
    }
}
