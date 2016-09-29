﻿using EncounterGen.Domain.Mappers.Percentiles;
using EncounterGen.Domain.Selectors.Percentiles;
using Moq;
using NUnit.Framework;
using RollGen;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Selectors.Percentiles
{
    [TestFixture]
    public class PercentileSelectorTests
    {
        private const string tableName = "table name";

        private IPercentileSelector selector;
        private Dictionary<int, string> table;
        private Mock<PercentileMapper> mockPercentileMapper;
        private Mock<Dice> mockDice;

        [SetUp]
        public void Setup()
        {
            mockPercentileMapper = new Mock<PercentileMapper>();
            mockDice = new Mock<Dice>();
            selector = new PercentileSelector(mockPercentileMapper.Object, mockDice.Object);
            table = new Dictionary<int, string>();

            for (var i = 1; i <= 5; i++)
                table.Add(i, "-1");

            for (var i = 6; i <= 10; i++)
                table.Add(i, i.ToString());

            mockDice.Setup(d => d.Roll(1).d(100).AsSum()).Returns(1);
            mockPercentileMapper.Setup(p => p.Map(tableName)).Returns(table);
        }

        [TestCase(1, -1)]
        [TestCase(2, -1)]
        [TestCase(3, -1)]
        [TestCase(4, -1)]
        [TestCase(5, -1)]
        [TestCase(6, 6)]
        [TestCase(7, 7)]
        [TestCase(8, 8)]
        [TestCase(9, 9)]
        [TestCase(10, 10)]
        public void GetPercentile(int roll, int content)
        {
            mockDice.Setup(d => d.Roll(1).d(100).AsSum()).Returns(roll);
            var result = selector.SelectFrom(tableName);
            Assert.That(result, Is.EqualTo(content));
        }

        [Test]
        public void IfRollNotPresentInTable_ThrowException()
        {
            mockDice.Setup(d => d.Roll(1).d(100).AsSum()).Returns(11);
            Assert.That(() => selector.SelectFrom(tableName), Throws.Exception.With.Message.EqualTo("11 is not a valid entry in the table table name"));
        }

        [Test]
        public void GetAllDistinctResults()
        {
            var results = selector.SelectAllFrom(tableName);
            Assert.That(results, Contains.Item(-1));
            Assert.That(results, Contains.Item(6));
            Assert.That(results, Contains.Item(7));
            Assert.That(results, Contains.Item(8));
            Assert.That(results, Contains.Item(9));
            Assert.That(results, Contains.Item(10));
            Assert.That(results.Count, Is.EqualTo(6));
        }
    }
}
