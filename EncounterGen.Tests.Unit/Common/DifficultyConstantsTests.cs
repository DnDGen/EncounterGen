using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class DifficultyConstantsTests
    {
        [TestCase(DifficultyConstants.VeryEasy, "Very Easy")]
        [TestCase(DifficultyConstants.Easy, "Easy")]
        [TestCase(DifficultyConstants.Challenging, "Challenging")]
        [TestCase(DifficultyConstants.VeryDifficult, "Very Difficult")]
        [TestCase(DifficultyConstants.Overpowering, "Overpowering")]
        public void DifficultyConstant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
