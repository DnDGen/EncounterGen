using DnDGen.EncounterGen.Tables;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit.Tables
{
    [TestFixture]
    public class GroupConstantsTests
    {
        [TestCase(GroupConstants.RequiresSubcreature, "Requires Sub-creature")]
        [TestCase(GroupConstants.UseSubcreatureForTreasure, "Use Sub-creature for Treasure")]
        [TestCase(GroupConstants.Wilderness, "Wilderness")]
        [TestCase(GroupConstants.Extraplanar, "Extraplanar")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
