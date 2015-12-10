using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using Moq;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class AdjustmentSelectorTests
    {
        private IAdjustmentSelector selector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<IRollSelector> mockRollSelector;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockRollSelector = new Mock<IRollSelector>();
            selector = new AdjustmentSelector(mockCollectionSelector.Object, mockRollSelector.Object);
        }

        [Test]
        public void SelectAdjustment()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(new[] { "adjustment" });
            mockRollSelector.Setup(s => s.SelectFrom("adjustment")).Returns(9266);

            var adjustment = selector.SelectFrom("table name", "entry");
            Assert.That(adjustment, Is.EqualTo(9266));
        }
    }
}
