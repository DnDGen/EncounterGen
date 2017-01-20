using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Tables
{
    [TestFixture]
    public class GroupConstantsTests
    {
        [TestCase(GroupConstants.RequiresSubtype, "Requires Subtype")]
        [TestCase(GroupConstants.UseSubtypeForTreasure, "Use Subtype for Treasure")]
        [TestCase(GroupConstants.Magic, "Magic")]
        [TestCase(GroupConstants.Land, "Land")]
        [TestCase(GroupConstants.Wilderness, "Wilderness")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
