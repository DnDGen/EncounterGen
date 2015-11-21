using EncounterGen.Generators;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterConstantsTests
    {
        [TestCase(EncounterConstants.Reroll, "Reroll")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [TestCase(EncounterConstants.PartialTreasure, -1)]
        public void Constant(Int32 constant, Int32 value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
