using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using EncounterGen.Tables;
using Moq;
using NUnit.Framework;
using RollGen;
using System;

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
        }

        [Test]
        public void GetModifiedRoll()
        {
            var tableName = String.Format(TableNameConstants.ROLLModifiedRolls, "base roll");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "modifier")).Returns(new[] { "modified roll" });

            var modifiedRoll = rollSelector.SelectFrom("base roll", "modifier");
            Assert.That(modifiedRoll, Is.EqualTo("modified roll"));
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
    }
}
