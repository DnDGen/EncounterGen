﻿using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
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
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockDice = new Mock<Dice>();
            rollSelector = new RollSelector(mockCollectionSelector.Object, mockDice.Object);

            var rolls = new[] { "lesser roll", RollConstants.One, "greater roll" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "All")).Returns(rolls);
        }

        [Test]
        public void RerollMinimumModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom(RollConstants.One, -2);
            Assert.That(modifiedRoll, Is.EqualTo(RollConstants.Reroll));
        }

        [Test]
        public void GetLesserModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom(RollConstants.One, -1);
            Assert.That(modifiedRoll, Is.EqualTo("lesser roll"));
        }

        [Test]
        public void GetSameModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom(RollConstants.One, 0);
            Assert.That(modifiedRoll, Is.EqualTo(RollConstants.One));
        }

        [Test]
        public void GetGreaterModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom(RollConstants.One, 1);
            Assert.That(modifiedRoll, Is.EqualTo("greater roll"));
        }

        [Test]
        public void GetMuchLessModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom("greater roll", -2);
            Assert.That(modifiedRoll, Is.EqualTo("lesser roll"));
        }

        [Test]
        public void GetMuchMoreModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom("lesser roll", 2);
            Assert.That(modifiedRoll, Is.EqualTo("greater roll"));
        }

        [Test]
        public void GetMaximumModifiedRoll()
        {
            var modifiedRoll = rollSelector.SelectFrom(RollConstants.One, 2);
            Assert.That(modifiedRoll, Is.EqualTo(RollConstants.Reroll));
        }

        [Test]
        public void IfBaseRollIsReroll_ReturnReroll()
        {
            var modifiedRoll = rollSelector.SelectFrom(RollConstants.Reroll, -2);
            Assert.That(modifiedRoll, Is.EqualTo(RollConstants.Reroll));
        }

        [Test]
        public void GetRollForChallengeRatingAtEffectiveLevel()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "CR")).Returns(new[] { "lesser challenge rating", "challenge rating", "9266", "higher challenge rating" });

            var roll = rollSelector.SelectFrom(9266, "challenge rating");
            Assert.That(roll, Is.EqualTo("greater roll"));
        }

        [Test]
        public void RerollTooHighForChallengeRatingAtEffectiveLevel()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "CR")).Returns(new[] { "lesser challenge rating", "challenge rating", "9266", "higher challenge rating" });

            var roll = rollSelector.SelectFrom(9266, "lesser challenge rating");
            Assert.That(roll, Is.EqualTo(RollConstants.Reroll));
        }

        [Test]
        public void RerollTooLowForChallengeRatingAtEffectiveLevel()
        {
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "CR")).Returns(new[] { "lesser challenge rating", "challenge rating", "9266", "higher challenge rating", "too high" });

            var roll = rollSelector.SelectFrom(9266, "too high");
            Assert.That(roll, Is.EqualTo(RollConstants.Reroll));
        }

        [Test]
        public void CanHaveMultipleLowestLevelModifiedRolls()
        {
            var rolls = new[] { "lesser roll", "lesser roll", "lesser roll", RollConstants.One, "greater roll" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "All")).Returns(rolls);

            var modifiedRoll = rollSelector.SelectFrom(RollConstants.One, -3);
            Assert.That(modifiedRoll, Is.EqualTo("lesser roll"));
        }

        [Test]
        public void CanHaveTooLittleForMultipleLowestLevelModifiedRolls()
        {
            var rolls = new[] { "lesser roll", "lesser roll", "lesser roll", RollConstants.One, "greater roll" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "All")).Returns(rolls);

            var modifiedRoll = rollSelector.SelectFrom(RollConstants.One, -4);
            Assert.That(modifiedRoll, Is.EqualTo(RollConstants.Reroll));
        }

        [Test]
        public void CanIncreaseFromMultipleLowestLevelModifiedRolls()
        {
            var rolls = new[] { "lesser roll", "lesser roll", "lesser roll", RollConstants.One, "greater roll" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "All")).Returns(rolls);

            var modifiedRoll = rollSelector.SelectFrom("lesser roll", 1);
            Assert.That(modifiedRoll, Is.EqualTo(RollConstants.One));
        }

        [Test]
        public void CanDecreaseFromMultipleLowestLevelModifiedRolls()
        {
            var rolls = new[] { "lesser roll", "lesser roll", "lesser roll", RollConstants.One, "greater roll" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "All")).Returns(rolls);

            var modifiedRoll = rollSelector.SelectFrom("lesser roll", -2);
            Assert.That(modifiedRoll, Is.EqualTo("lesser roll"));
        }

        [Test]
        public void GetRollForChallengeRatingAtEffectiveLevelWithMultipleLowestLevels()
        {
            var rolls = new[] { "lesser roll", "lesser roll", "lesser roll", RollConstants.One, "greater roll" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "All")).Returns(rolls);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "CR")).Returns(new[] { "lesser challenge rating", "9266", "90210", "42", "challenge rating", "higher challenge rating" });

            var roll = rollSelector.SelectFrom(9266, "challenge rating");
            Assert.That(roll, Is.EqualTo("lesser roll"));
        }

        [Test]
        public void RerollTooLowForChallengeRatingAtEffectiveLevelWithMultipleLowestLevels()
        {
            var rolls = new[] { "lesser roll", "lesser roll", "lesser roll", RollConstants.One, "greater roll" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "All")).Returns(rolls);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.RollOrder, "CR")).Returns(new[] { "lesser challenge rating", "9266", "90210", "42", "600", "challenge rating", "higher challenge rating" });

            var roll = rollSelector.SelectFrom(9266, "challenge rating");
            Assert.That(roll, Is.EqualTo(RollConstants.Reroll));
        }
    }
}