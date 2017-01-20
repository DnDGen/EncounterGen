using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Domain.Tables;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Coins;
using TreasureGen.Goods;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

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
        private Mock<IMagicalItemGeneratorRuntimeFactory> mockMagicalItemGeneratorFactory;
        private Mock<IMundaneItemGeneratorRuntimeFactory> mockMundaneItemGeneratorFactory;

        [SetUp]
        public void Setup()
        {
            mockCoinGenerator = new Mock<ICoinGenerator>();
            mockGoodsGenerator = new Mock<IGoodsGenerator>();
            mockItemsGenerator = new Mock<IItemsGenerator>();
            mockAdjustmentSelector = new Mock<IAdjustmentSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockMagicalItemGeneratorFactory = new Mock<IMagicalItemGeneratorRuntimeFactory>();
            mockMundaneItemGeneratorFactory = new Mock<IMundaneItemGeneratorRuntimeFactory>();

            encounterTreasureGenerator = new EncounterTreasureGenerator(mockCoinGenerator.Object, mockGoodsGenerator.Object, mockItemsGenerator.Object,
                mockAdjustmentSelector.Object, mockBooleanPercentileSelector.Object, mockCollectionSelector.Object, mockMagicalItemGeneratorFactory.Object, mockMundaneItemGeneratorFactory.Object);

            creature = new Creature();
            usesSubtypeForTreasure = new List<string>();

            level = 9266;
            creature.Type.Name = "creature";
            creature.Type.SubType = new CreatureType();
            creature.Type.SubType.Name = "subtype";
            creature.Quantity = 1;
            coinMultiplier = 1;
            goodsMultiplier = 1;
            itemsMultiplier = 1;
            goods = new List<Good>() { new Good(), new Good() };
            items = new List<Item>() { new Item(), new Item() };
            coin = new Coin { Currency = "currency", Quantity = 600 };

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<double>())).Returns((double d) => d > 0);

            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.Name, TreasureConstants.Coin)).Returns(() => coinMultiplier);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.Name, TreasureConstants.Goods)).Returns(() => goodsMultiplier);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.Name, TreasureConstants.Items)).Returns(() => itemsMultiplier);

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
            Assert.That(treasure.IsAny, Is.False);
        }

        [Test]
        public void GetNoTreasureIntentionally()
        {
            coinMultiplier = 0;
            goodsMultiplier = 0;
            itemsMultiplier = 0;

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure, Is.Not.Null);
            Assert.That(treasure.IsAny, Is.False);
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
            usesSubtypeForTreasure.Add(creature.Type.Name);

            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.Name, TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.Name, TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.Name, TreasureConstants.Items)).Returns(2);

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
            creature.Type.SubType.SubType = new CreatureType();
            creature.Type.SubType.SubType.Name = "further subtype";

            usesSubtypeForTreasure.Add(creature.Type.Name);

            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.Name, TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.Name, TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.Name, TreasureConstants.Items)).Returns(2);

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
            creature.Type.SubType.SubType = new CreatureType();
            creature.Type.SubType.SubType.Name = "further subtype";

            usesSubtypeForTreasure.Add(creature.Type.Name);
            usesSubtypeForTreasure.Add(creature.Type.SubType.Name);

            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.SubType.Name, TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.SubType.Name, TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.SubType.Name, TreasureConstants.Items)).Returns(2);

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
        public void GetSetTreasure()
        {
            var setTreasureItems = new[] { "item 1[item type]", "item 2[other item type]" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureGroups, creature.Type.Name)).Returns(setTreasureItems);

            var mockMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            var mockOtherMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("other item type")).Returns(mockOtherMundaneItemGenerator.Object);

            var setItem = new Item();
            var otherSetItem = new Item();
            mockMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 1"), true)).Returns(setItem);
            mockOtherMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 2"), true)).Returns(otherSetItem);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Items, Contains.Item(setItem));
            Assert.That(treasure.Items, Contains.Item(otherSetItem));
        }

        [Test]
        public void GetSetTreasureWithMagicBonus()
        {
            var setTreasureItems = new[] { "item 1[item type](90210)", "item 2[other item type]" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureGroups, creature.Type.Name)).Returns(setTreasureItems);

            var mockMagicalItemGenerator = new Mock<MagicalItemGenerator>();
            var mockMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("other item type")).Returns(mockMundaneItemGenerator.Object);

            var setItem = new Item();
            var otherSetItem = new Item();
            mockMagicalItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 1" && i.Magic.Bonus == 90210), true)).Returns(setItem);
            mockMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 2" && i.IsMagical == false), true)).Returns(otherSetItem);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Items, Contains.Item(setItem));
            Assert.That(treasure.Items, Contains.Item(otherSetItem));
        }

        [Test]
        public void GetSetTreasureWithSpecialAbilities()
        {
            var setTreasureItems = new[] { "item 1[item type](90210)", "item 2[other item type]#Trait#(42){ability 1,ability 2}" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureGroups, creature.Type.Name)).Returns(setTreasureItems);

            var mockMagicalItemGenerator = new Mock<MagicalItemGenerator>();
            var mockOtherMagicalItemGenerator = new Mock<MagicalItemGenerator>();
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("other item type")).Returns(mockOtherMagicalItemGenerator.Object);

            var setItem = new Item();
            var otherSetItem = new Item();
            mockMagicalItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 1" && i.Magic.Bonus == 90210), true)).Returns(setItem);
            mockOtherMagicalItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 2" && i.Magic.Bonus == 42 && i.Traits.Single() == "Trait"
                && i.Magic.SpecialAbilities.Count() == 2 && i.Magic.SpecialAbilities.Any(a => a.Name == "ability 1") && i.Magic.SpecialAbilities.Any(a => a.Name == "ability 2")), true))
                .Returns(otherSetItem);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Items, Contains.Item(setItem));
            Assert.That(treasure.Items, Contains.Item(otherSetItem));
        }

        [Test]
        public void GetSetTreasureWithTraits()
        {
            var setTreasureItems = new[] { "item 1[item type]#size#", "item 2[other item type]#other size,trait#" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureGroups, creature.Type.Name)).Returns(setTreasureItems);

            var mockMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            var mockOtherMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("other item type")).Returns(mockOtherMundaneItemGenerator.Object);

            var setItem = new Item();
            var otherSetItem = new Item();
            mockMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 1" && i.Traits.Single() == "size"), true)).Returns(setItem);
            mockOtherMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 2" && i.Traits.First() == "other size" && i.Traits.Last() == "trait" && i.Traits.Count() == 2), true)).Returns(otherSetItem);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Items, Contains.Item(setItem));
            Assert.That(treasure.Items, Contains.Item(otherSetItem));
        }

        [Test]
        public void GetSetMagicTreasure()
        {
            var setTreasureItems = new[] { "item 1[item type](90210)", "item 2[item type]@True@", "item 3[item type]@False@", "item 4[item type]" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureGroups, creature.Type.Name)).Returns(setTreasureItems);

            var mockMagicalItemGenerator = new Mock<MagicalItemGenerator>();
            var mockOtherMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            mockMagicalItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("item type")).Returns(mockMagicalItemGenerator.Object);
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("item type")).Returns(mockOtherMundaneItemGenerator.Object);

            var firstItem = new Item();
            var secondItem = new Item();
            var thirdItem = new Item();
            var fourthItem = new Item();
            mockMagicalItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 1" && i.IsMagical), true)).Returns(firstItem);
            mockMagicalItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 2" && i.IsMagical), true)).Returns(secondItem);
            mockOtherMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 3" && !i.IsMagical), true)).Returns(thirdItem);
            mockOtherMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 4" && !i.IsMagical), true)).Returns(fourthItem);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Items, Contains.Item(firstItem));
            Assert.That(treasure.Items, Contains.Item(secondItem));
            Assert.That(treasure.Items, Contains.Item(thirdItem));
            Assert.That(treasure.Items, Contains.Item(fourthItem));
        }

        [Test]
        public void GetSetTreasurePerCreature()
        {
            var setTreasureItems = new[] { "item 1[item type]", "item 2[other item type]" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureGroups, creature.Type.Name)).Returns(setTreasureItems);

            var mockMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            var mockOtherMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("other item type")).Returns(mockOtherMundaneItemGenerator.Object);

            mockMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 1"), true)).Returns((Item t, bool a) => t.Copy());
            mockOtherMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 2"), true)).Returns((Item t, bool a) => t.Copy());

            creature.Quantity = 42;

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Items.Count(i => i.Name == "item 1"), Is.EqualTo(42));
            Assert.That(treasure.Items.Count(i => i.Name == "item 2"), Is.EqualTo(42));
        }

        [Test]
        public void UseSubtypeForSetTreasure()
        {
            usesSubtypeForTreasure.Add(creature.Type.Name);

            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.Name, TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.Name, TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.Name, TreasureConstants.Items)).Returns(2);

            var secondGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods);

            var secondItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems);

            var setTreasureItems = new[] { "item 1[item type]", "item 2[other item type]" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureGroups, creature.Type.SubType.Name)).Returns(setTreasureItems);

            var mockMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            var mockOtherMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("other item type")).Returns(mockOtherMundaneItemGenerator.Object);

            var setItem = new Item();
            var otherSetItem = new Item();
            mockMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 1"), true)).Returns(setItem);
            mockOtherMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 2"), true)).Returns(otherSetItem);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(1200));
            Assert.That(treasure.Goods.Count, Is.EqualTo(4));
            Assert.That(treasure.Items.Count, Is.EqualTo(6));
            Assert.That(secondGoods, Is.SubsetOf(treasure.Goods));
            Assert.That(goods, Is.SubsetOf(treasure.Goods));
            Assert.That(items, Is.SubsetOf(treasure.Items));
            Assert.That(secondItems, Is.SubsetOf(treasure.Items));
            Assert.That(treasure.Items, Contains.Item(setItem));
            Assert.That(treasure.Items, Contains.Item(otherSetItem));
        }

        [Test]
        public void UseFurtherSubtypeForSetTreasure()
        {
            creature.Type.SubType.SubType = new CreatureType();
            creature.Type.SubType.SubType.Name = "further subtype";

            usesSubtypeForTreasure.Add(creature.Type.Name);
            usesSubtypeForTreasure.Add(creature.Type.SubType.Name);

            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.SubType.Name, TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.SubType.Name, TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectDouble(TableNameConstants.TreasureAdjustments, creature.Type.SubType.SubType.Name, TreasureConstants.Items)).Returns(2);

            var secondGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods);

            var secondItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems);

            var setTreasureItems = new[] { "item 1[item type]", "item 2[other item type]" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureGroups, creature.Type.SubType.SubType.Name)).Returns(setTreasureItems);

            var mockMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            var mockOtherMundaneItemGenerator = new Mock<MundaneItemGenerator>();
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("item type")).Returns(mockMundaneItemGenerator.Object);
            mockMundaneItemGeneratorFactory.Setup(f => f.CreateGeneratorOf("other item type")).Returns(mockOtherMundaneItemGenerator.Object);

            var setItem = new Item();
            var otherSetItem = new Item();
            mockMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 1"), true)).Returns(setItem);
            mockOtherMundaneItemGenerator.Setup(g => g.Generate(It.Is<Item>(i => i.Name == "item 2"), true)).Returns(otherSetItem);

            var treasure = encounterTreasureGenerator.GenerateFor(creature, level);
            Assert.That(treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(treasure.Coin.Quantity, Is.EqualTo(1200));
            Assert.That(treasure.Goods.Count, Is.EqualTo(4));
            Assert.That(treasure.Items.Count, Is.EqualTo(6));
            Assert.That(secondGoods, Is.SubsetOf(treasure.Goods));
            Assert.That(goods, Is.SubsetOf(treasure.Goods));
            Assert.That(items, Is.SubsetOf(treasure.Items));
            Assert.That(secondItems, Is.SubsetOf(treasure.Items));
            Assert.That(treasure.Items, Contains.Item(setItem));
            Assert.That(treasure.Items, Contains.Item(otherSetItem));
        }
    }
}
