using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Common
{
    [TestFixture]
    public class EncounterTests
    {
        private Encounter encounter;

        [SetUp]
        public void Setup()
        {
            encounter = new Encounter();
        }

        [Test]
        public void EncounterInitialized()
        {
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Creatures, Is.Empty);
            Assert.That(encounter.Treasures, Is.Empty);
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(0));
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(0));
            Assert.That(encounter.TargetEncounterLevel, Is.EqualTo(0));
        }

        [TestCase(-9999, DifficultyConstants.VeryEasy)]
        [TestCase(-10, DifficultyConstants.VeryEasy)]
        [TestCase(-9, DifficultyConstants.VeryEasy)]
        [TestCase(-8, DifficultyConstants.VeryEasy)]
        [TestCase(-7, DifficultyConstants.VeryEasy)]
        [TestCase(-6, DifficultyConstants.VeryEasy)]
        [TestCase(-5, DifficultyConstants.VeryEasy)]
        [TestCase(-4, DifficultyConstants.Easy)]
        [TestCase(-3, DifficultyConstants.Easy)]
        [TestCase(-2, DifficultyConstants.Easy)]
        [TestCase(-1, DifficultyConstants.Easy)]
        [TestCase(0, DifficultyConstants.Challenging)]
        [TestCase(1, DifficultyConstants.VeryDifficult)]
        [TestCase(2, DifficultyConstants.VeryDifficult)]
        [TestCase(3, DifficultyConstants.VeryDifficult)]
        [TestCase(4, DifficultyConstants.VeryDifficult)]
        [TestCase(5, DifficultyConstants.Overpowering)]
        [TestCase(6, DifficultyConstants.Overpowering)]
        [TestCase(7, DifficultyConstants.Overpowering)]
        [TestCase(8, DifficultyConstants.Overpowering)]
        [TestCase(9, DifficultyConstants.Overpowering)]
        [TestCase(10, DifficultyConstants.Overpowering)]
        [TestCase(9999, DifficultyConstants.Overpowering)]
        public void AverageEncounterDifficulty(int levelModifier, string difficulty)
        {
            encounter.TargetEncounterLevel = 9266;
            encounter.AverageEncounterLevel = 9266 + levelModifier;
            Assert.That(encounter.AverageDifficulty, Is.EqualTo(difficulty));
        }

        [TestCase(-9999, DifficultyConstants.VeryEasy)]
        [TestCase(-10, DifficultyConstants.VeryEasy)]
        [TestCase(-9, DifficultyConstants.VeryEasy)]
        [TestCase(-8, DifficultyConstants.VeryEasy)]
        [TestCase(-7, DifficultyConstants.VeryEasy)]
        [TestCase(-6, DifficultyConstants.VeryEasy)]
        [TestCase(-5, DifficultyConstants.VeryEasy)]
        [TestCase(-4, DifficultyConstants.Easy)]
        [TestCase(-3, DifficultyConstants.Easy)]
        [TestCase(-2, DifficultyConstants.Easy)]
        [TestCase(-1, DifficultyConstants.Easy)]
        [TestCase(0, DifficultyConstants.Challenging)]
        [TestCase(1, DifficultyConstants.VeryDifficult)]
        [TestCase(2, DifficultyConstants.VeryDifficult)]
        [TestCase(3, DifficultyConstants.VeryDifficult)]
        [TestCase(4, DifficultyConstants.VeryDifficult)]
        [TestCase(5, DifficultyConstants.Overpowering)]
        [TestCase(6, DifficultyConstants.Overpowering)]
        [TestCase(7, DifficultyConstants.Overpowering)]
        [TestCase(8, DifficultyConstants.Overpowering)]
        [TestCase(9, DifficultyConstants.Overpowering)]
        [TestCase(10, DifficultyConstants.Overpowering)]
        [TestCase(9999, DifficultyConstants.Overpowering)]
        public void ActualEncounterDifficulty(int levelModifier, string difficulty)
        {
            encounter.TargetEncounterLevel = 9266;
            encounter.ActualEncounterLevel = 9266 + levelModifier;
            Assert.That(encounter.ActualDifficulty, Is.EqualTo(difficulty));
        }
    }
}
