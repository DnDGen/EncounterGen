using EncounterGen.Mappers;
using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using Moq;
using NUnit.Framework;
using RollGen;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class CollectionSelectorTests
    {
        private const string TableName = "table name";

        private ICollectionSelector selector;
        private Mock<CollectionMapper> mockMapper;
        private Dictionary<string, IEnumerable<string>> allCollections;
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockMapper = new Mock<CollectionMapper>();
            mockDice = new Mock<Dice>();
            selector = new CollectionSelector(mockMapper.Object, mockDice.Object);
            allCollections = new Dictionary<string, IEnumerable<string>>();

            mockMapper.Setup(m => m.Map(TableName)).Returns(allCollections);
        }

        [Test]
        public void SelectCollection()
        {
            allCollections["entry"] = Enumerable.Empty<string>();
            var collection = selector.SelectFrom(TableName, "entry");
            Assert.That(collection, Is.EqualTo(allCollections["entry"]));
        }

        [Test]
        public void IfEntryNotPresentInTable_ThrowException()
        {
            Assert.That(() => selector.SelectFrom(TableName, "entry"), Throws.Exception.With.Message.EqualTo("entry is not a valid entry in the table table name"));
        }

        [Test]
        public void SelectRandomElementOfCollection()
        {
            var collection = new[] { "first", "second", "third" };
            mockDice.Setup(d => d.Roll(1).IndividualRolls(3)).Returns(new[] { 2 });

            var item = selector.SelectRandomFrom(collection);
            Assert.That(item, Is.EqualTo("second"));
        }

        [Test]
        public void ThrowExceptionIfCollectionIsEmpty()
        {
            var emptyCollection = Enumerable.Empty<string>();
            Assert.That(() => selector.SelectRandomFrom(emptyCollection), Throws.ArgumentException);
        }
    }
}
