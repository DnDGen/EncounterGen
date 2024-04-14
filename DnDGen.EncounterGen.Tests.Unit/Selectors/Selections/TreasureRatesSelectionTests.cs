using DnDGen.EncounterGen.Selectors.Selections;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit.Selectors.Selections
{
    [TestFixture]
    public class TreasureRatesSelectionTests
    {
        private TreasureRatesSelection selection;

        [SetUp]
        public void Setup()
        {
            selection = new TreasureRatesSelection();
        }

        [Test]
        public void TreasureRatesSelectionIsinitialized()
        {
            Assert.That(selection.Coin, Is.EqualTo(0));
            Assert.That(selection.Goods, Is.EqualTo(0));
            Assert.That(selection.Items, Is.EqualTo(0));
        }
    }
}
