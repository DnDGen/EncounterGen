using DnDGen.EncounterGen.Tables;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit.Tables
{
    [TestFixture]
    public class GroupConstantsTests
    {
        [TestCase(GroupConstants.RequiresSubtype, "Requires Subtype")]
        [TestCase(GroupConstants.UseSubtypeForTreasure, "Use Subtype for Treasure")]
        [TestCase(GroupConstants.Wilderness, "Wilderness")]
        [TestCase(GroupConstants.Extraplanar, "Extraplanar")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
