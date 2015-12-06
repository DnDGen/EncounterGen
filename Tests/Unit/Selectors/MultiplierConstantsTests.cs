using EncounterGen.Selectors;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class MultiplierConstantsTests
    {
        [TestCase(MultiplierConstants.Quadruple, "x4")]
        [TestCase(MultiplierConstants.Triple, "x3")]
        [TestCase(MultiplierConstants.Double, "x2")]
        [TestCase(MultiplierConstants.HalfAgain, "x1.5")]
        [TestCase(MultiplierConstants.Same, "x1")]
        [TestCase(MultiplierConstants.TwoThirds, "x.66")]
        [TestCase(MultiplierConstants.Half, "x.5")]
        [TestCase(MultiplierConstants.OneThird, "x.33")]
        public void Constant(String constant, String value)
        {

        }
    }
}
