using EncounterGen.Domain.Generators;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class RegexConstantsTests
    {
        [TestCase(RegexConstants.ChallengeRatingPattern, "\\[.+\\]")]
        [TestCase(RegexConstants.SetCharacterLevelPattern, "\\d+")]
        [TestCase(RegexConstants.DescriptionPattern, " \\(.+\\)")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
