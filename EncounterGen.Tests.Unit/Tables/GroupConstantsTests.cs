using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Tables
{
    [TestFixture]
    public class GroupConstantsTests
    {
        [TestCase(GroupConstants.UndeadNPC, "Undead NPC")]
        [TestCase(GroupConstants.RequiresSubtype, "Requires Subtype")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
