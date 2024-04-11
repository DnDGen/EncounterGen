using DnDGen.EncounterGen.Selectors;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class TreasureConstantsTests
    {
        [TestCase(TreasureConstants.CoinIndex, 0)]
        [TestCase(TreasureConstants.GoodsIndex, 1)]
        [TestCase(TreasureConstants.ItemsIndex, 2)]
        [TestCase(TreasureConstants.FiftyPercent, .5)]
        [TestCase(TreasureConstants.TenPercent, .1)]
        [TestCase(TreasureConstants.TwentyFivePercent, .25)]
        public void Constant(double constant, double value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
