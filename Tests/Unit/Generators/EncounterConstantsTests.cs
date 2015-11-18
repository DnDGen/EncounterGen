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
    }
}
