using EncounterGen.Selectors;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class ModifierConstantsTests
    {
        [TestCase(ModifierConstants.Quadruple, "x4")]
        [TestCase(ModifierConstants.Triple, "x3")]
        [TestCase(ModifierConstants.Double, "x2")]
        [TestCase(ModifierConstants.HalfAgain, "x1.5")]
        [TestCase(ModifierConstants.Same, "x1")]
        [TestCase(ModifierConstants.TwoThirds, "x.66")]
        [TestCase(ModifierConstants.Half, "x.5")]
        [TestCase(ModifierConstants.OneThird, "x.33")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
