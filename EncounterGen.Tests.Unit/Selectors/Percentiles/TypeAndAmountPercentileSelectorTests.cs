using EncounterGen.Domain.Selectors.Percentiles;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class TypeAndAmountPercentileSelectorTests
    {
        private ITypeAndAmountPercentileSelector selector;
        private Mock<IPercentileSelector> mockInnerSelector;
        private string tableName;

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
            mockInnerSelector.Setup(s => s.SelectFrom(tableName)).Returns("type/amount,other type/other amount");

            var typesAndAmounts = selector.SelectFrom(tableName);
            Assert.That(typesAndAmounts, Is.Not.Null);
            Assert.That(typesAndAmounts["type"], Is.EqualTo("amount"));
            Assert.That(typesAndAmounts["other type"], Is.EqualTo("other amount"));
            Assert.That(typesAndAmounts.Count, Is.EqualTo(2));
        }

        [Test]
        public void SelectAllTypesAndAmounts()
        {
            var allTypesAndAmounts = new List<string>();
            allTypesAndAmounts.Add("type/amount");
            allTypesAndAmounts.Add("type/amount,other type/other amount");

            mockInnerSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(allTypesAndAmounts);

            var typesAndAmounts = selector.SelectAllFrom(tableName);
            Assert.That(typesAndAmounts, Is.Not.Null);
            Assert.That(typesAndAmounts.Count, Is.EqualTo(2));

            var typesAndAmountsList = typesAndAmounts.ToList();
            Assert.That(typesAndAmountsList[0], Is.Not.Null);
            Assert.That(typesAndAmountsList[0]["type"], Is.EqualTo("amount"));
            Assert.That(typesAndAmountsList[0].Count, Is.EqualTo(1));
            Assert.That(typesAndAmountsList[1], Is.Not.Null);
            Assert.That(typesAndAmountsList[1]["type"], Is.EqualTo("amount"));
            Assert.That(typesAndAmountsList[1]["other type"], Is.EqualTo("other amount"));
            Assert.That(typesAndAmountsList[1].Count, Is.EqualTo(2));
        }
    }
}
