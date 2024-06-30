using DnDGen.EncounterGen.Tables;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit.Tables
{
    [TestFixture]
    public class GroupConstantsTests
    {
        [TestCase(GroupConstants.All, "All")]
        [TestCase(GroupConstants.Character, "Character")]
        [TestCase(GroupConstants.Extraplanar, "Extraplanar")]
        [TestCase(GroupConstants.RequiresSubcreature, "Requires Sub-creature")]
        [TestCase(GroupConstants.UseSubcreatureForTreasure, "Use Sub-creature for Treasure")]
        [TestCase(GroupConstants.Wilderness, "Wilderness")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
