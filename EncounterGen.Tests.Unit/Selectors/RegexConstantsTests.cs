using EncounterGen.Domain.Selectors;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class RegexConstantsTests
    {
        [TestCase(RegexConstants.IsMagicPattern, "@.+@")]
        [TestCase(RegexConstants.ItemBonusPattern, "\\(\\d+\\)")]
        [TestCase(RegexConstants.ItemTypePattern, "\\[.+\\]")]
        [TestCase(RegexConstants.SpecialAbilitiesPattern, "\\{.+\\}")]
        [TestCase(RegexConstants.SpecialAbilitiesBonusPattern, "\\$\\d+\\$")]
        [TestCase(RegexConstants.TraitPattern, "#.+#")]
        public void RegexConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
