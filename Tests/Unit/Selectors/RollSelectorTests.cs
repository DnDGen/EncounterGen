using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using EncounterGen.Tables;
using Moq;
using NUnit.Framework;
using RollGen;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class RollSelectorTests
    {
        private IRollSelector rollSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockDice = new Mock<Dice>();
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
        public void IfBaseRollIsReroll_ReturnReroll()
        {
            var modifiedRoll = rollSelector.SelectFrom(RollConstants.Reroll, -9266);
            Assert.That(modifiedRoll, Is.EqualTo(RollConstants.Reroll));
        }

        [Test]
        public void GetExpressionRoll()
        {
            mockDice.Setup(r => r.Roll("expression roll")).Returns(42);
            var roll = rollSelector.SelectFrom("expression roll");
            Assert.That(roll, Is.EqualTo(42));
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

        [Test]
        public void GetDoubleConstant()
        {
            var roll = rollSelector.SelectFrom(".9266");
            Assert.That(roll, Is.EqualTo(.9266));
        }

        [Test]
        public void GetRollForChallengeRatingAtEffectiveLevel()
        {
            var tableName = string.Format(TableNameConstants.LevelXRolls, 9266);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "challenge rating")).Returns(new[] { "roll" });
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> c) => c.First());

            var roll = rollSelector.SelectFrom(9266, "challenge rating");
            Assert.That(roll, Is.EqualTo("roll"));
        }

        [Test]
        public void GetRandomRollForChallengeRatingAtEffectiveLevel()
        {
            var tableName = string.Format(TableNameConstants.LevelXRolls, 9266);
            var rolls = new[] { "roll", "other roll" };

            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "challenge rating")).Returns(rolls);
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(rolls)).Returns("other roll");

            var roll = rollSelector.SelectFrom(9266, "challenge rating");
            Assert.That(roll, Is.EqualTo("other roll"));
        }
    }
}
