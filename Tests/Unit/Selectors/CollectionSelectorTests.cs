using EncounterGen.Mappers;
using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class CollectionSelectorTests
    {
        private const String TableName = "table name";

        private ICollectionSelector selector;
        private Mock<CollectionMapper> mockMapper;
        private Dictionary<String, IEnumerable<String>> allCollections;

        [SetUp]
        public void Setup()
        {
            mockMapper = new Mock<CollectionMapper>();
            selector = new CollectionSelector(mockMapper.Object);
            allCollections = new Dictionary<String, IEnumerable<String>>();

            mockMapper.Setup(m => m.Map(TableName)).Returns(allCollections);
        }

        [Test]
        public void SelectCollection()
        {
            allCollections["entry"] = Enumerable.Empty<String>();
            var collection = selector.SelectFrom(TableName, "entry");
            Assert.That(collection, Is.EqualTo(allCollections["entry"]));
        }

        [Test]
        public void IfEntryNotPresentInTable_ThrowException()
        {
            Assert.That(() => selector.SelectFrom(TableName, "entry"), Throws.Exception.With.Message.EqualTo("entry is not a valid entry in the table table name"));
        }
    }
}
