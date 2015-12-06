using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Tables
{
    [TestFixture]
    public class GroupConstantsTests
    {
        [TestCase(GroupConstants.UndeadNPC, "Undead NPC")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
