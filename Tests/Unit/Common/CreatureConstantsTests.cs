using EncounterGen.Common;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class CreatureConstantsTests
    {
        [TestCase(CreatureConstants.Character, "Character")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
