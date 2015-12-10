using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using EncounterGen.Tables;
using Moq;
using NUnit.Framework;
using RollGen;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class RollSelectorTests
    {
        private IRollSelector rollSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<IDice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockDice = new Mock<IDice>();
            rollSelector = new RollSelector(mockCollectionSelector.Object, mockDice.Object);

            var rolls = new[] { RollConstants.One, "lesser roll", "base roll", "greater roll", RollConstants.Reroll };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "All")).Returns(rolls);
        }

        [Test]
        public void GetMinimumModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom("base roll", -9266);
            Assert.That(modifiedRoll, Is.EqualTo(RollConstants.One));
        }

        [Test]
        public void GetLesserModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom("base roll", -1);
            Assert.That(modifiedRoll, Is.EqualTo("lesser roll"));
        }

        [Test]
        public void GetSameModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom("base roll", 0);
            Assert.That(modifiedRoll, Is.EqualTo("base roll"));
        }

        [Test]
        public void GetGreaterModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom("base roll", 1);
            Assert.That(modifiedRoll, Is.EqualTo("greater roll"));
        }

        [Test]
        public void GetMaximumModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom("base roll", 9266);
            Assert.That(modifiedRoll, Is.EqualTo(RollConstants.Reroll));
        }

        [Test]
        public void GetConstant()
        {
            var roll = rollSelector.SelectFrom("9266");
            Assert.That(roll, Is.EqualTo(9266));
        }

        [Test]
        public void GetDieRoll()
        {
            mockDice.Setup(r => r.Roll(9266).d(90210)).Returns(42);
            var roll = rollSelector.SelectFrom("9266d90210");
            Assert.That(roll, Is.EqualTo(42));
        }

        [Test]
        public void GetDieRollWithBonus()
        {
            mockDice.Setup(r => r.Roll(9266).d(90210)).Returns(42);
            var roll = rollSelector.SelectFrom("9266d90210+600");
            Assert.That(roll, Is.EqualTo(642));
        }

        [Test]
        public void FindRollInString()
        {
            var roll = rollSelector.SelectRollFrom("this string contains a roll 9266d90210, doesn't it?");
            Assert.That(roll, Is.EqualTo("9266d90210"));
        }

        [Test]
        public void FindRollWithBonusInString()
        {
            var roll = rollSelector.SelectRollFrom("this string contains a roll 9266d90210+600, doesn't it?");
            Assert.That(roll, Is.EqualTo("9266d90210+600"));
        }

        [Test]
        public void FindNoRollInString()
        {
            var roll = rollSelector.SelectRollFrom("this string does not contain a roll, does it?");
            Assert.That(roll, Is.Empty);
        }

        [Test]
        public void DoNotFindConstantNumberInString()
        {
            var roll = rollSelector.SelectRollFrom("this string contains 5 rolls - or not");
            Assert.That(roll, Is.Empty);
        }
    }
}
