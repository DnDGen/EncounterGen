using EncounterGen.Selectors;
using NUnit.Framework;
using System;

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
        public void Constant(Double constant, Double value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
