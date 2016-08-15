using EncounterGen.Domain.Selectors;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class TreasureConstantsTests
    {
        [TestCase(TreasureConstants.Coin, 0)]
        [TestCase(TreasureConstants.Goods, 1)]
        [TestCase(TreasureConstants.Items, 2)]
        [TestCase(TreasureConstants.FiftyPercent, .5)]
        [TestCase(TreasureConstants.TenPercent, .1)]
        [TestCase(TreasureConstants.TwentyFivePercent, .25)]
        public void Constant(double constant, double value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
