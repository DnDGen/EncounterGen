using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using Moq;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class TreasureAdjustmentSelectorTests
    {
        private ITreasureAdjustmentSelector treasureAdjustmentsSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            treasureAdjustmentsSelector = new TreasureAdjustmentSelector(mockCollectionSelector.Object);
        }

        [Test]
        public void SelectTreasureRates()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "entry")).Returns(new[] { "92.66", "902.1", "42" });

            var treasureRates = treasureAdjustmentsSelector.SelectFor("entry");
            Assert.That(treasureRates.Coin, Is.EqualTo(92.66));
            Assert.That(treasureRates.Goods, Is.EqualTo(902.1));
            Assert.That(treasureRates.Items, Is.EqualTo(42));
        }
    }
}
