using EncounterGen.Domain.Mappers.Collections;
using EncounterGen.Domain.Selectors.Collections;
using Moq;
using NUnit.Framework;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Selectors.Collections
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
            mockDice.Setup(d => d.Roll(1).d(3).AsSum()).Returns(2);

            var item = selector.SelectRandomFrom(collection);
            Assert.That(item, Is.EqualTo("second"));
        }

        [Test]
        public void ThrowExceptionIfCollectionIsEmpty()
        {
            var emptyCollection = Enumerable.Empty<string>();
            Assert.That(() => selector.SelectRandomFrom(emptyCollection), Throws.ArgumentException);
        }

        [Test]
        public void EntryIsGroup()
        {
            allCollections["entry"] = Enumerable.Empty<string>();
            var isGroup = selector.IsGroup(TableName, "entry");
            Assert.That(isGroup, Is.True);
        }

        [Test]
        public void EntryIsNotGroup()
        {
            allCollections["entry"] = Enumerable.Empty<string>();
            var isGroup = selector.IsGroup(TableName, "other entry");
            Assert.That(isGroup, Is.False);
        }

        [Test]
        public void ExplodeGroupWithoutSubgroups()
        {
            var otherCollections = new Dictionary<string, IEnumerable<string>>();
            mockMapper.Setup(m => m.Map("other table name")).Returns(otherCollections);

            otherCollections["first"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["second"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["sub 1"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["sub 2"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["third"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["fourth"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            allCollections["entry"] = new[] { "first", "second", "third" };

            var explodedGroup = selector.ExplodeInto(TableName, "entry", "other table name");
            Assert.That(explodedGroup, Is.SupersetOf(otherCollections["first"]));
            Assert.That(explodedGroup, Is.SupersetOf(otherCollections["second"]));
            Assert.That(explodedGroup, Is.Not.SupersetOf(otherCollections["sub 1"]));
            Assert.That(explodedGroup, Is.Not.SupersetOf(otherCollections["sub 2"]));
            Assert.That(explodedGroup, Is.SupersetOf(otherCollections["third"]));
            Assert.That(explodedGroup, Is.Not.SupersetOf(otherCollections["fourth"]));
            Assert.That(explodedGroup, Does.Not.Contain("first"));
            Assert.That(explodedGroup, Does.Not.Contain("second"));
            Assert.That(explodedGroup, Does.Not.Contain("sub 1"));
            Assert.That(explodedGroup, Does.Not.Contain("sub 2"));
            Assert.That(explodedGroup, Does.Not.Contain("third"));
            Assert.That(explodedGroup, Does.Not.Contain("fourth"));
        }

        [Test] //INFO: An example of this would be Dragons.  Dragons are not encounters, but Dragon subgroups (such as Ancient black dragon) are.
        public void ExplodeGroupWithSubgroups()
        {
            var otherCollections = new Dictionary<string, IEnumerable<string>>();
            mockMapper.Setup(m => m.Map("other table name")).Returns(otherCollections);

            otherCollections["first"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["sub 1"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["sub 2"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["fourth"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["third"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            allCollections["entry"] = new[] { "first", "second", "third" };
            allCollections["second"] = new[] { "sub 1", "sub 2" };

            var explodedGroup = selector.ExplodeInto(TableName, "entry", "other table name");
            Assert.That(explodedGroup, Is.SupersetOf(otherCollections["first"]));
            Assert.That(explodedGroup, Is.SupersetOf(otherCollections["sub 1"]));
            Assert.That(explodedGroup, Is.SupersetOf(otherCollections["sub 2"]));
            Assert.That(explodedGroup, Is.SupersetOf(otherCollections["third"]));
            Assert.That(explodedGroup, Is.Not.SupersetOf(otherCollections["fourth"]));
            Assert.That(explodedGroup, Does.Not.Contain("first"));
            Assert.That(explodedGroup, Does.Not.Contain("second"));
            Assert.That(explodedGroup, Does.Not.Contain("sub 1"));
            Assert.That(explodedGroup, Does.Not.Contain("sub 2"));
            Assert.That(explodedGroup, Does.Not.Contain("third"));
            Assert.That(explodedGroup, Does.Not.Contain("fourth"));
        }

        [Test] //INFO: an example of this would be Characters.  Characters are encounters, but Character subgroups (such as Adept) are not.
        public void GetEncountersFromCreatureGroupWithSubgroupsThatAreNotValidEncounters()
        {
            var otherCollections = new Dictionary<string, IEnumerable<string>>();
            mockMapper.Setup(m => m.Map("other table name")).Returns(otherCollections);

            otherCollections["first"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["second"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["fourth"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            otherCollections["third"] = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };

            allCollections["entry"] = new[] { "first", "second", "third" };
            allCollections["second"] = new[] { "sub 1", "sub 2" };

            var explodedGroup = selector.ExplodeInto(TableName, "entry", "other table name");
            Assert.That(explodedGroup, Is.SupersetOf(otherCollections["first"]));
            Assert.That(explodedGroup, Is.SupersetOf(otherCollections["second"]));
            Assert.That(explodedGroup, Is.SupersetOf(otherCollections["third"]));
            Assert.That(explodedGroup, Is.Not.SupersetOf(otherCollections["fourth"]));
            Assert.That(explodedGroup, Does.Not.Contain("first"));
            Assert.That(explodedGroup, Does.Not.Contain("second"));
            Assert.That(explodedGroup, Does.Not.Contain("sub 1"));
            Assert.That(explodedGroup, Does.Not.Contain("sub 2"));
            Assert.That(explodedGroup, Does.Not.Contain("third"));
            Assert.That(explodedGroup, Does.Not.Contain("fourth"));
        }
    }
}
