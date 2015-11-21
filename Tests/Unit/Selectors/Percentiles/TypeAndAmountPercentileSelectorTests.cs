using EncounterGen.Selectors.Domain.Percentiles;
using EncounterGen.Selectors.Percentiles;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EncounterGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class TypeAndAmountPercentileSelectorTests
    {
        private ITypeAndAmountPercentileSelector selector;
        private Mock<IPercentileSelector> mockInnerSelector;
        private Dictionary<Int32, String> table;
        private String tableName;

        [SetUp]
        public void Setup()
        {
            mockInnerSelector = new Mock<IPercentileSelector>();
            selector = new TypeAndAmountPercentileSelector(mockInnerSelector.Object);
            tableName = "table name";

            mockInnerSelector.Setup(m => m.SelectFrom(tableName)).Returns("type/9266");
        }

        [Test]
        public void SelectTypeAndAmount()
        {
            mockInnerSelector.Setup(m => m.SelectFrom(tableName)).Returns("type/amount");

            var typesAndAmounts = selector.SelectFrom(tableName);
            Assert.That(typesAndAmounts, Is.Not.Null);
            Assert.That(typesAndAmounts["type"], Is.EqualTo("amount"));
            Assert.That(typesAndAmounts.Count, Is.EqualTo(1));
        }

        [Test]
        public void SelectMultipleTypesAndAmounts()
        {
            mockInnerSelector.Setup(m => m.SelectFrom(tableName)).Returns("type/amount,other type/other amount");

            var typesAndAmounts = selector.SelectFrom(tableName);
            Assert.That(typesAndAmounts, Is.Not.Null);
            Assert.That(typesAndAmounts["type"], Is.EqualTo("amount"));
            Assert.That(typesAndAmounts["other type"], Is.EqualTo("other amount"));
            Assert.That(typesAndAmounts.Count, Is.EqualTo(2));
        }
    }
}
