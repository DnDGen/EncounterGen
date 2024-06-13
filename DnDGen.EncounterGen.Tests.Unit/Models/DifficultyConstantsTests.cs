using DnDGen.EncounterGen.Models;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Unit.Models
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
