using EncounterGen.Domain.Selectors;
using Moq;
using NUnit.Framework;
using RollGen;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class AdjustmentSelectorTests
    {
        private IAdjustmentSelector selector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockDice = new Mock<Dice>();
            selector = new AdjustmentSelector(mockCollectionSelector.Object, mockDice.Object);
        }

        [Test]
        public void SelectAdjustment()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(new[] { "adjustment" });
            mockDice.Setup(d => d.ReplaceExpressionWithTotal("adjustment")).Returns("rolled adjustment");
            mockDice.Setup(d => d.Evaluate<int>("rolled adjustment")).Returns(9266);

            var adjustment = selector.Select("table name", "entry");
            Assert.That(adjustment, Is.EqualTo(9266));
        }

        [Test]
        public void SelectSubAdjustment()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(new[] { "adjustment", "other adjustment" });
            mockDice.Setup(d => d.ReplaceExpressionWithTotal("other adjustment")).Returns("rolled adjustment");
            mockDice.Setup(d => d.Evaluate<int>("rolled adjustment")).Returns(9266);

            var adjustment = selector.Select("table name", "entry", 1);
            Assert.That(adjustment, Is.EqualTo(9266));
        }

        [Test]
        public void SelectDoubleAdjustment()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(new[] { "adjustment" });
            mockDice.Setup(d => d.ReplaceExpressionWithTotal("adjustment")).Returns("rolled adjustment");
            mockDice.Setup(d => d.Evaluate<double>("rolled adjustment")).Returns(.5);

            var adjustment = selector.Select<double>("table name", "entry");
            Assert.That(adjustment, Is.EqualTo(.5));
        }

        [Test]
        public void SelectDoubleSubAdjustment()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom("table name", "entry")).Returns(new[] { "adjustment", "other adjustment" });
            mockDice.Setup(d => d.ReplaceExpressionWithTotal("other adjustment")).Returns("rolled adjustment");
            mockDice.Setup(d => d.Evaluate<double>("rolled adjustment")).Returns(.5);

            var adjustment = selector.Select<double>("table name", "entry", 1);
            Assert.That(adjustment, Is.EqualTo(.5));
        }
    }
}
