using EncounterGen.Mappers;
using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using Moq;
using NUnit.Framework;
using RollGen;
using System;
using System.Collections.Generic;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class TypeAndAmountPercentileSelectorTests
    {
        private ITypeAndAmountPercentileSelector selector;
        private Mock<PercentileMapper> mockPercentileMapper;
        private Mock<IDice> mockDice;
        private Dictionary<Int32, String> table;
        private String tableName;
        private Int32 roll;

        [SetUp]
        public void Setup()
        {
            mockPercentileMapper = new Mock<PercentileMapper>();
            mockDice = new Mock<IDice>();
            selector = new TypeAndAmountPercentileSelector(mockPercentileMapper.Object, mockDice.Object);
            table = new Dictionary<Int32, String>();
            tableName = "table name";
            roll = 9266;

            mockPercentileMapper.Setup(m => m.Map(tableName)).Returns(table);
            mockDice.Setup(d => d.Roll(1).Percentile()).Returns(roll);
        }

        [Test]
        public void SelectTypeAndAmount()
        {
            table[roll] = "type/90210";

            var typesAndAmounts = selector.SelectFrom(tableName);
            Assert.That(typesAndAmounts, Is.Not.Null);
            Assert.That(typesAndAmounts["type"], Is.EqualTo(90210));
            Assert.That(typesAndAmounts.Count, Is.EqualTo(1));
        }

        [Test]
        public void SelectMultipleTypesAndAmounts()
        {
            table[roll] = "type/90210,other type/42";

            var typesAndAmounts = selector.SelectFrom(tableName);
            Assert.That(typesAndAmounts, Is.Not.Null);
            Assert.That(typesAndAmounts["type"], Is.EqualTo(90210));
            Assert.That(typesAndAmounts["other type"], Is.EqualTo(42));
            Assert.That(typesAndAmounts.Count, Is.EqualTo(2));
        }

        [Test]
        public void SelectSetAmount()
        {
            table[roll] = "type/90210";

            var typesAndAmounts = selector.SelectFrom(tableName);
            Assert.That(typesAndAmounts, Is.Not.Null);
            Assert.That(typesAndAmounts["type"], Is.EqualTo(90210));
            Assert.That(typesAndAmounts.Count, Is.EqualTo(1));
        }

        [Test]
        public void SelectRolledAmount()
        {
            table[roll] = "type/90210d42";
            mockDice.Setup(d => d.Roll(90210).d(42)).Returns(600);

            var typesAndAmounts = selector.SelectFrom(tableName);
            Assert.That(typesAndAmounts, Is.Not.Null);
            Assert.That(typesAndAmounts["type"], Is.EqualTo(600));
            Assert.That(typesAndAmounts.Count, Is.EqualTo(1));
        }

        [Test]
        public void SelectRolledAmountWithBonus()
        {
            table[roll] = "type/90210d42+1337";
            mockDice.Setup(d => d.Roll(90210).d(42)).Returns(600);

            var typesAndAmounts = selector.SelectFrom(tableName);
            Assert.That(typesAndAmounts, Is.Not.Null);
            Assert.That(typesAndAmounts["type"], Is.EqualTo(1937));
            Assert.That(typesAndAmounts.Count, Is.EqualTo(1));
        }

        [Test]
        public void SelectMultipleRolledAmountsWithBonuses()
        {
            table[roll] = "type/90210d42+600,other type/1337d12345+23456";
            mockDice.Setup(d => d.Roll(90210).d(42)).Returns(34567);
            mockDice.Setup(d => d.Roll(1337).d(12345)).Returns(45678);

            var typesAndAmounts = selector.SelectFrom(tableName);
            Assert.That(typesAndAmounts, Is.Not.Null);
            Assert.That(typesAndAmounts["type"], Is.EqualTo(35167));
            Assert.That(typesAndAmounts["other type"], Is.EqualTo(69134));
            Assert.That(typesAndAmounts.Count, Is.EqualTo(2));
        }
    }
}
