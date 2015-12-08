using EncounterGen.Selectors;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class RollConstantsTests
    {
        [TestCase(RollConstants.One, "1")]
        [TestCase(RollConstants.OneD2, "1d2")]
        [TestCase(RollConstants.OneD3, "1d3")]
        [TestCase(RollConstants.OneD3Plus1, "1d3+1")]
        [TestCase(RollConstants.OneD4Plus2, "1d4+2")]
        [TestCase(RollConstants.OneD6Plus3, "1d6+3")]
        [TestCase(RollConstants.OneD6Plus5, "1d6+5")]
        [TestCase(RollConstants.OneD4Plus10, "1d4+10")]
        [TestCase(RollConstants.Reroll, "Reroll")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
