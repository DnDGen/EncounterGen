using EncounterGen.Domain.Selectors.Collections;
using Moq;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class AdjustmentSelectorTests
    {
        private IAdjustmentSelector selector;
        private Mock<ICollectionSelector> mockCollectionSelector;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            selector = new AdjustmentSelector(mockCollectionSelector.Object);
        }

        [Test]
        public void SelectAdjustment()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(new[] { "9266" });

            var adjustment = selector.Select("table name", "entry");
            Assert.That(adjustment, Is.EqualTo(9266));
        }

        [Test]
        public void SelectSubAdjustment()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(new[] { "9266", "90210" });

            var adjustment = selector.Select("table name", "entry", 1);
            Assert.That(adjustment, Is.EqualTo(90210));
        }

        [Test]
        public void SelectDoubleAdjustment()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(new[] { "92.66" });

            var adjustment = selector.SelectDouble("table name", "entry");
            Assert.That(adjustment, Is.EqualTo(92.66));
        }

        [Test]
        public void SelectDoubleSubAdjustment()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(new[] { "92.66", "902.1" });

            var adjustment = selector.SelectDouble("table name", "entry", 1);
            Assert.That(adjustment, Is.EqualTo(902.1));
        }
    }
}
