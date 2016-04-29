using EncounterGen.Domain.Selectors.Percentiles;
using Moq;
using NUnit.Framework;
using RollGen;

namespace EncounterGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class BooleanPercentileSelectorTests
    {
        private IBooleanPercentileSelector booleanPercentileSelector;
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<Dice>();
            booleanPercentileSelector = new BooleanPercentileSelector(mockDice.Object);
        }

        [Test]
        public void SaysTrueIfRollIsLessThanTheshold()
        {
            mockDice.Setup(d => d.Roll(1).IndividualRolls(100)).Returns(new[] { 49 });

            var result = booleanPercentileSelector.SelectFrom(.5);
            Assert.That(result, Is.True);
        }

        [Test]
        public void SaysTrueIfRollIsEqualToTheshold()
        {
            mockDice.Setup(d => d.Roll(1).IndividualRolls(100)).Returns(new[] { 50 });

            var result = booleanPercentileSelector.SelectFrom(.5);
            Assert.That(result, Is.True);
        }

        [Test]
        public void SaysFalseIfRollIsGreaterThanTheshold()
        {
            mockDice.Setup(d => d.Roll(1).IndividualRolls(100)).Returns(new[] { 51 });

            var result = booleanPercentileSelector.SelectFrom(.5);
            Assert.That(result, Is.False);
        }
    }
}
