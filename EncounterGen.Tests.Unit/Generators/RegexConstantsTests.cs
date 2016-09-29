using EncounterGen.Domain.Generators;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class RegexConstantsTests
    {
        [TestCase(RegexConstants.ChallengeRatingPattern, "\\[[^\\[\\]]+\\]")]
        [TestCase(RegexConstants.DescriptionPattern, " \\(.+\\)")]
        [TestCase(RegexConstants.IsMagicPattern, "@.+@")]
        [TestCase(RegexConstants.ItemBonusPattern, "\\(\\d+\\)")]
        [TestCase(RegexConstants.SetCharacterLevelPattern, "\\d+")]
        [TestCase(RegexConstants.SpecialAbilitiesPattern, "\\{.+\\}")]
        [TestCase(RegexConstants.TraitPattern, "#.+#")]
        public void RegexConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void ItemTypePattern()
        {
            Assert.That(RegexConstants.ItemTypePattern, Is.EqualTo("\\[.+\\]"));
        }
    }
}
