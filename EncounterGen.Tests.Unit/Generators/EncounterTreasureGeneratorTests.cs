using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Domain.Tables;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Coins;
using TreasureGen.Goods;
using TreasureGen.Items;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterTreasureGeneratorTests
    {
        private IEncounterTreasureGenerator encounterTreasureGenerator;
        private Mock<ICoinGenerator> mockCoinGenerator;
        private Mock<IGoodsGenerator> mockGoodsGenerator;
        private Mock<IItemsGenerator> mockItemsGenerator;
        private Mock<IAdjustmentSelector> mockAdjustmentSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private int level;
        private Creature creature;
        private double coinMultiplier;
        private double goodsMultiplier;
        private double itemsMultiplier;
        private List<Good> goods;
        private List<Item> items;
        private Coin coin;
        private List<string> usesSubtypeForTreasure;

        [SetUp]
        public void Setup()
        {
            mockCoinGenerator = new Mock<ICoinGenerator>();
            mockGoodsGenerator = new Mock<IGoodsGenerator>();
            mockItemsGenerator = new Mock<IItemsGenerator>();
            mockAdjustmentSelector = new Mock<IAdjustmentSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockCollectionSelector = new Mock<ICollectionSelector>();

            encounterTreasureGenerator = new EncounterTreasureGenerator(mockCoinGenerator.Object, mockGoodsGenerator.Object, mockItemsGenerator.Object,
                mockAdjustmentSelector.Object, mockBooleanPercentileSelector.Object, mockCollectionSelector.Object);

            creature = new Creature();
            usesSubtypeForTreasure = new List<string>();

            level = 9266;
            creature.Name = "creature";
            creature.Description = "subtype";
            coinMultiplier = 1;
            goodsMultiplier = 1;
            itemsMultiplier = 1;
            goods = new List<Good>() { new Good(), new Good() };
            items = new List<Item>() { new Item(), new Item() };
            coin = new Coin { Currency = "currency", Quantity = 600 };

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<double>())).Returns((double d) => d > 0);

            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, creature.Name, TreasureConstants.Coin)).Returns(() => coinMultiplier);
            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, creature.Name, TreasureConstants.Goods)).Returns(() => goodsMultiplier);
            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, creature.Name, TreasureConstants.Items)).Returns(() => itemsMultiplier);

            mockCoinGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(coin);
            mockGoodsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(goods);
            mockItemsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(items);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UseSubtypeForTreasure)).Returns(usesSubtypeForTreasure);
        }

        [Test]
        public void GetTreasure()
        {
            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure, Is.Not.Null);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(600));
            Assert.That(goods, Is.SubsetOf(treasure.Goods));
            Assert.That(treasure.Goods.Count, Is.EqualTo(2));
            Assert.That(items, Is.SubsetOf(treasure.Items));
            Assert.That(treasure.Items.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetDifferentLevelsOfTreasure()
        {
            coinMultiplier = 0;
            goodsMultiplier = 2;
            itemsMultiplier = 1;

            var secondGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods);

            var secondItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure, Is.Not.Null);
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(goods, Is.SubsetOf(treasure.Goods));
            Assert.That(secondGoods, Is.SubsetOf(treasure.Goods));
            Assert.That(treasure.Goods.Count, Is.EqualTo(4));
            Assert.That(items, Is.SubsetOf(treasure.Items));
            Assert.That(secondItems, Is.Not.SubsetOf(treasure.Items));
            Assert.That(treasure.Items.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetMoreTreasure()
        {
            coinMultiplier = 2;
            goodsMultiplier = 2;
            itemsMultiplier = 2;

            mockCoinGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(coin)
                .Returns(new Coin { Currency = "wrong currency", Quantity = 666 });

            var secondGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods);

            var secondItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure, Is.Not.Null);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(1200));
            Assert.That(goods, Is.SubsetOf(treasure.Goods));
            Assert.That(items, Is.SubsetOf(treasure.Items));
            Assert.That(secondGoods, Is.SubsetOf(treasure.Goods));
            Assert.That(secondItems, Is.SubsetOf(treasure.Items));
            Assert.That(treasure.Goods.Count, Is.EqualTo(4));
            Assert.That(treasure.Items.Count, Is.EqualTo(4));
        }

        [Test]
        public void GetNoTreasureByChance()
        {
            coinMultiplier = 2;
            goodsMultiplier = 2;
            itemsMultiplier = 2;

            mockCoinGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(coin)
                .Returns(new Coin { Currency = "wrong currency", Quantity = 666 });

            goods.Clear();
            items.Clear();
            coin.Quantity = 0;

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure, Is.Not.Null);
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(treasure.Goods, Is.Empty);
            Assert.That(treasure.Items, Is.Empty);
        }

        [Test]
        public void GetNoTreasureIntentionally()
        {
            coinMultiplier = 0;
            goodsMultiplier = 0;
            itemsMultiplier = 0;

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure, Is.Not.Null);
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(treasure.Goods, Is.Empty);
            Assert.That(treasure.Items, Is.Empty);
        }

        [Test]
        public void GetPartialTreasureWithGoodsAndItems()
        {
            coinMultiplier = .5;
            goodsMultiplier = .5;
            itemsMultiplier = .5;

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(300));
            Assert.That(goods, Is.SubsetOf(treasure.Goods));
            Assert.That(items, Is.SubsetOf(treasure.Items));
            Assert.That(treasure.Goods.Count, Is.EqualTo(2));
            Assert.That(treasure.Items.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetDifferentPartialTreasureWithGoodsAndItems()
        {
            coinMultiplier = .1;
            goodsMultiplier = .2;
            itemsMultiplier = .3;

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(60));
            Assert.That(goods, Is.SubsetOf(treasure.Goods));
            Assert.That(items, Is.SubsetOf(treasure.Items));
            Assert.That(treasure.Goods.Count, Is.EqualTo(2));
            Assert.That(treasure.Items.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetPartialTreasureWithGoods()
        {
            coinMultiplier = .1;
            goodsMultiplier = .2;
            itemsMultiplier = .3;

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(.3)).Returns(false);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(60));
            Assert.That(goods, Is.SubsetOf(treasure.Goods));
            Assert.That(treasure.Goods.Count, Is.EqualTo(2));
            Assert.That(treasure.Items, Is.Empty);
        }

        [Test]
        public void GetPartialTreasureWithItems()
        {
            coinMultiplier = .1;
            goodsMultiplier = .2;
            itemsMultiplier = .3;

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(.2)).Returns(false);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(60));
            Assert.That(treasure.Goods, Is.Empty);
            Assert.That(items, Is.SubsetOf(treasure.Items));
            Assert.That(treasure.Items.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetPartialTreasureWithNoGoodsOrItems()
        {
            coinMultiplier = .1;
            goodsMultiplier = .2;
            itemsMultiplier = .3;

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(.2)).Returns(false);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(.3)).Returns(false);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(60));
            Assert.That(treasure.Goods, Is.Empty);
            Assert.That(treasure.Items, Is.Empty);
        }

        [Test]
        public void GetMoreAndPartialTreasure()
        {
            coinMultiplier = 2.1;
            goodsMultiplier = 2.2;
            itemsMultiplier = 2.3;

            var secondGoods = new[] { new Good(), new Good() };
            var thirdGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods).Returns(thirdGoods);

            var secondItems = new[] { new Item(), new Item() };
            var thirdItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems).Returns(thirdItems);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(1260));
            Assert.That(treasure.Goods.Count, Is.EqualTo(6));
            Assert.That(treasure.Items.Count, Is.EqualTo(6));
        }

        [Test]
        public void GetMoreAndNoPartialTreasure()
        {
            coinMultiplier = 2.1;
            goodsMultiplier = 2.2;
            itemsMultiplier = 2.3;

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(.2)).Returns(false);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(.3)).Returns(false);

            var secondGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods);

            var secondItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(1260));
            Assert.That(treasure.Goods.Count, Is.EqualTo(4));
            Assert.That(treasure.Items.Count, Is.EqualTo(4));
        }

        [Test]
        public void UseSubtypeForTreasure()
        {
            usesSubtypeForTreasure.Add(creature.Name);

            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, creature.Description, TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, creature.Description, TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, creature.Description, TreasureConstants.Items)).Returns(2);

            var secondGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods);

            var secondItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(1200));
            Assert.That(treasure.Goods.Count, Is.EqualTo(4));
            Assert.That(treasure.Items.Count, Is.EqualTo(4));
        }

        [Test]
        public void UseSubtypeWithoutFurtherSubtypeForTreasure()
        {
            creature.Description = "subtype (further subtype)";

            usesSubtypeForTreasure.Add(creature.Name);

            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, "subtype", TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, "subtype", TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, "subtype", TreasureConstants.Items)).Returns(2);

            var secondGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods);

            var secondItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(1200));
            Assert.That(treasure.Goods.Count, Is.EqualTo(4));
            Assert.That(treasure.Items.Count, Is.EqualTo(4));
        }

        [Test]
        public void UseFurtherSubtypeForTreasure()
        {
            creature.Description = "subtype (further subtype)";

            usesSubtypeForTreasure.Add(creature.Name);
            usesSubtypeForTreasure.Add("subtype");

            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, "further subtype", TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, "further subtype", TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.Select<double>(TableNameConstants.TreasureAdjustments, "further subtype", TreasureConstants.Items)).Returns(2);

            var secondGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods);

            var secondItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(1200));
            Assert.That(treasure.Goods.Count, Is.EqualTo(4));
            Assert.That(treasure.Items.Count, Is.EqualTo(4));
        }
    }
}
