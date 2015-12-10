using EncounterGen.Selectors;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class ModifierConstantsTests
    {
        [TestCase(ModifierConstants.Quadruple, 4)]
        [TestCase(ModifierConstants.Triple, 3)]
        [TestCase(ModifierConstants.Double, 2)]
        [TestCase(ModifierConstants.HalfAgain, 1)]
        [TestCase(ModifierConstants.Same, 0)]
        [TestCase(ModifierConstants.TwoThirds, -1)]
        [TestCase(ModifierConstants.Half, -2)]
        [TestCase(ModifierConstants.OneThird, -3)]
        public void Constant(Int32 constant, Int32 value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
