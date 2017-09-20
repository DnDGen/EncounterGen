using DnDGen.Core.Selectors.Collections;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using Moq;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Selectors.Collections
{
    [TestFixture]
    public class TreasureRatesSelectorTests
    {
        private ITreasureRatesSelector treasureRatesSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            treasureRatesSelector = new TreasureRatesSelector(mockCollectionSelector.Object);
        }

        [Test]
        public void SelectTreasureRates()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureRates, "entry")).Returns(new[] { "92.66", "902.1", "42" });

            var treasureRates = treasureRatesSelector.SelectFor("entry");
            Assert.That(treasureRates.Coin, Is.EqualTo(92.66));
            Assert.That(treasureRates.Goods, Is.EqualTo(902.1));
            Assert.That(treasureRates.Items, Is.EqualTo(42));
        }
    }
}
