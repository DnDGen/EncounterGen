using CharacterGen.Common;
using CharacterGen.Common.CharacterClasses;
using CharacterGen.Generators;
using CharacterGen.Generators.Randomizers.Alignments;
using CharacterGen.Generators.Randomizers.CharacterClasses;
using CharacterGen.Generators.Randomizers.Races;
using CharacterGen.Generators.Randomizers.Stats;
using EncounterGen.Common;
using EncounterGen.Generators;
using EncounterGen.Generators.Domain;
using EncounterGen.Selectors;
using EncounterGen.Selectors.Percentiles;
using EncounterGen.Tables;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common.Coins;
using TreasureGen.Common.Goods;
using TreasureGen.Common.Items;
using TreasureGen.Generators.Coins;
using TreasureGen.Generators.Goods;
using TreasureGen.Generators.Items;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterGeneratorTests
    {
        private IEncounterGenerator encounterGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ICoinGenerator> mockCoinGenerator;
        private Mock<IGoodsGenerator> mockGoodsGenerator;
        private Mock<IItemsGenerator> mockItemsGenerator;
        private Mock<ICharacterGenerator> mockCharacterGenerator;
        private Mock<IAlignmentRandomizer> mockAnyAlignmentRandomizer;
        private Mock<IClassNameRandomizer> mockAnyClassNameRandomizer;
        private Mock<ISetLevelRandomizer> mockSetLevelRandomizer;
        private Mock<RaceRandomizer> mockAnyBaseRaceRandomizer;
        private Mock<RaceRandomizer> mockAnyMetaraceRandomizer;
        private Mock<ISetMetaraceRandomizer> mockSetMetaraceRandomizer;
        private Mock<IStatsRandomizer> mockRawStatsRandomizer;
        private Mock<IAdjustmentSelector> mockAdjustmentSelector;
        private Mock<IRollSelector> mockRollSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IBooleanPercentileSelector> mockBooleanPercentileSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Dictionary<String, String> encounterTypeAndAmount;
        private Dictionary<String, String> encounterLevelAndModifier;
        private Int32 level;
        private String environment;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCoinGenerator = new Mock<ICoinGenerator>();
            mockGoodsGenerator = new Mock<IGoodsGenerator>();
            mockItemsGenerator = new Mock<IItemsGenerator>();
            mockCharacterGenerator = new Mock<ICharacterGenerator>();
            mockAnyAlignmentRandomizer = new Mock<IAlignmentRandomizer>();
            mockAnyClassNameRandomizer = new Mock<IClassNameRandomizer>();
            mockSetLevelRandomizer = new Mock<ISetLevelRandomizer>();
            mockAnyBaseRaceRandomizer = new Mock<RaceRandomizer>();
            mockAnyMetaraceRandomizer = new Mock<RaceRandomizer>();
            mockRawStatsRandomizer = new Mock<IStatsRandomizer>();
            mockAdjustmentSelector = new Mock<IAdjustmentSelector>();
            mockRollSelector = new Mock<IRollSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockBooleanPercentileSelector = new Mock<IBooleanPercentileSelector>();
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockSetMetaraceRandomizer = new Mock<ISetMetaraceRandomizer>();

            encounterGenerator = new EncounterGenerator(mockTypeAndAmountPercentileSelector.Object, mockCoinGenerator.Object,
                mockGoodsGenerator.Object, mockItemsGenerator.Object, mockCharacterGenerator.Object, mockAnyAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, mockSetLevelRandomizer.Object,
                mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object, mockAdjustmentSelector.Object,
                mockRollSelector.Object, mockPercentileSelector.Object, mockBooleanPercentileSelector.Object, mockCollectionSelector.Object,
                mockSetMetaraceRandomizer.Object);

            encounterLevelAndModifier = new Dictionary<String, String>();
            encounterTypeAndAmount = new Dictionary<String, String>();

            mockSetLevelRandomizer.SetupAllProperties();
            mockSetLevelRandomizer.Object.AllowAdjustments = true;

            mockSetMetaraceRandomizer.SetupAllProperties();

            level = 9266;
            environment = "environment";
            encounterLevelAndModifier["90210"] = "modifier";
            encounterTypeAndAmount["creature"] = "creature amount";

            var tableName = String.Format(TableNameConstants.LevelXEncounterLevel, level);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(encounterLevelAndModifier);

            tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 90210, environment);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(encounterTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("creature amount", "modifier")).Returns("effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("effective roll")).Returns(42);
        }

        [Test]
        public void GenerateEncounter()
        {
            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo("creature"));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(42));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GenerateEncounterWithCharacters()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[CreatureConstants.Character] = "character amount";
            mockRollSelector.Setup(s => s.SelectFrom("character amount", "modifier")).Returns("character effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("character effective roll")).Returns(600);

            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.CharacterLevel, "90210")).Returns(1337);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo(CreatureConstants.Character));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void GenerateEncounterWithUndeadNPCs()
        {
            var monster = encounterTypeAndAmount.Keys.First();
            var undead = new[] { monster, "other monster" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.MonsterGroups, GroupConstants.UndeadNPC)).Returns(undead);

            var tableName = String.Format(TableNameConstants.LevelXUndeadNPC, 90210);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(tableName, monster)).Returns(1337);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments == false), mockAnyBaseRaceRandomizer.Object, It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == monster), mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo(monster));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(42));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(42));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void UndeadNPCsEachHaveUniqueLevel()
        {
            var monster = encounterTypeAndAmount.Keys.First();
            var undead = new[] { monster, "other monster" };
            mockRollSelector.Setup(s => s.SelectFrom("effective roll")).Returns(2);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.MonsterGroups, GroupConstants.UndeadNPC)).Returns(undead);

            var tableName = String.Format(TableNameConstants.LevelXUndeadNPC, 90210);
            mockAdjustmentSelector.SetupSequence(s => s.SelectFrom(tableName, monster)).Returns(1337).Returns(1234);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments == false), mockAnyBaseRaceRandomizer.Object, It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == monster), mockRawStatsRandomizer.Object))
                .Returns(() => new Character { Class = new CharacterClass { Level = 1337 } });

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1234 && r.AllowAdjustments == false), mockAnyBaseRaceRandomizer.Object, It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == monster), mockRawStatsRandomizer.Object))
                .Returns(() => new Character { Class = new CharacterClass { Level = 1234 } });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo(monster));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(2));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(2));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Any(c => c.Class.Level == 1337), Is.True);
            Assert.That(encounter.Characters.Any(c => c.Class.Level == 1234), Is.True);
        }

        [Test]
        public void GenerateEncounterWithDragons()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[CreatureConstants.Dragon] = "dragon amount";
            mockRollSelector.Setup(s => s.SelectFrom("dragon amount", "modifier")).Returns("dragon effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("dragon effective roll")).Returns(600);

            var tableName = String.Format(TableNameConstants.LevelXDragons, 90210);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("dragon type and age");

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo("dragon type and age"));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RerollEncounter()
        {
            var wrongTypeAndAmount = new Dictionary<String, String>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<String, String>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 90210, environment);
            mockTypeAndAmountPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(encounterTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("wrong creature amount", "modifier")).Returns(EncounterConstants.Reroll);
            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", "modifier")).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo("other creature"));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RerollEntireEncounter()
        {
            var wrongTypeAndAmount = new Dictionary<String, String>();
            wrongTypeAndAmount["creature"] = "creature amount";
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<String, String>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 90210, environment);
            mockTypeAndAmountPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(encounterTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("wrong creature amount", "modifier")).Returns(EncounterConstants.Reroll);
            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", "modifier")).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo("other creature"));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GetEncounterWithMultipleTypesOfCreatures()
        {
            encounterTypeAndAmount["other creature"] = "other creature amount";

            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", "modifier")).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures.Count(c => c == "creature"), Is.EqualTo(42));
            Assert.That(encounter.Creatures.Count(c => c == "other creature"), Is.EqualTo(600));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(642));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GetTreasure()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(1);
            mockCoinGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(new Coin { Currency = "currency", Quantity = 600 });

            var goods = new[] { new Good(), new Good() };
            mockGoodsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(goods);

            var items = new[] { new Item(), new Item() };
            mockItemsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(items);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(600));
            Assert.That(goods, Is.SubsetOf(encounter.Treasure.Goods));
            Assert.That(items, Is.SubsetOf(encounter.Treasure.Items));
        }

        [Test]
        public void GetMoreTreasure()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(2);
            mockCoinGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(new Coin { Currency = "currency", Quantity = 600 })
                .Returns(new Coin { Currency = "wrong currency", Quantity = 666 });

            var goods = new[] { new Good(), new Good() };
            var secondGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods);

            var items = new[] { new Item(), new Item() };
            var secondItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(1200));
            Assert.That(goods, Is.SubsetOf(encounter.Treasure.Goods));
            Assert.That(items, Is.SubsetOf(encounter.Treasure.Items));
            Assert.That(secondGoods, Is.SubsetOf(encounter.Treasure.Goods));
            Assert.That(secondItems, Is.SubsetOf(encounter.Treasure.Items));
        }

        [Test]
        public void GetNoTreasureByChance()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(2);
            mockCoinGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(new Coin())
                .Returns(new Coin { Currency = "wrong currency", Quantity = 666 });

            var goods = Enumerable.Empty<Good>();
            mockGoodsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(goods);

            var items = Enumerable.Empty<Item>();
            mockItemsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(items);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasure.Coin.Currency, Is.Empty);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(encounter.Treasure.Goods, Is.Empty);
            Assert.That(encounter.Treasure.Items, Is.Empty);
        }

        [Test]
        public void GetNoTreasureIntentionally()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(0);

            mockCoinGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(new Coin { Currency = "currency", Quantity = 600 });

            var goods = new[] { new Good(), new Good() };
            mockGoodsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(goods);

            var items = new[] { new Item(), new Item() };
            mockItemsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(items);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter.Treasure.Coin.Currency, Is.Empty);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(encounter.Treasure.Goods, Is.Empty);
            Assert.That(encounter.Treasure.Items, Is.Empty);
        }

        [Test]
        public void GetPartialTreasureWithGoodsAndItems()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(EncounterConstants.PartialTreasure);

            mockCoinGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(new Coin { Currency = "currency", Quantity = 600 });

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.PartialTreasure)).Returns(true);

            var goods = new[] { new Good(), new Good() };
            mockGoodsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(goods);

            var items = new[] { new Item(), new Item() };
            mockItemsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(items);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter.Treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(60));
            Assert.That(goods, Is.SubsetOf(encounter.Treasure.Goods));
            Assert.That(items, Is.SubsetOf(encounter.Treasure.Items));
        }

        [Test]
        public void GetPartialTreasureWithGoods()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(EncounterConstants.PartialTreasure);

            mockCoinGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(new Coin { Currency = "currency", Quantity = 600 });

            mockBooleanPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.PartialTreasure)).Returns(true).Returns(false);

            var goods = new[] { new Good(), new Good() };
            mockGoodsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(goods);

            var items = new[] { new Item(), new Item() };
            mockItemsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(items);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter.Treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(60));
            Assert.That(goods, Is.SubsetOf(encounter.Treasure.Goods));
            Assert.That(encounter.Treasure.Items, Is.Empty);
        }

        [Test]
        public void GetPartialTreasureWithItems()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(EncounterConstants.PartialTreasure);

            mockCoinGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(new Coin { Currency = "currency", Quantity = 600 });

            mockBooleanPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.PartialTreasure)).Returns(false).Returns(true);

            var goods = new[] { new Good(), new Good() };
            mockGoodsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(goods);

            var items = new[] { new Item(), new Item() };
            mockItemsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(items);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter.Treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(60));
            Assert.That(encounter.Treasure.Goods, Is.Empty);
            Assert.That(items, Is.SubsetOf(encounter.Treasure.Items));
        }

        [Test]
        public void GetPartialTreasureWithNoGoodsOrItems()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(EncounterConstants.PartialTreasure);

            mockCoinGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(new Coin { Currency = "currency", Quantity = 600 });

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.PartialTreasure)).Returns(false);

            var goods = new[] { new Good(), new Good() };
            mockGoodsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(goods);

            var items = new[] { new Item(), new Item() };
            mockItemsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(items);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter.Treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(60));
            Assert.That(encounter.Treasure.Goods, Is.Empty);
            Assert.That(encounter.Treasure.Items, Is.Empty);
        }

        [Test]
        public void UseFirstCreatureForTreasure()
        {
            encounterTypeAndAmount["other creature"] = "other creature amount";

            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", "modifier")).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);

            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "other creature")).Returns(1);

            mockCoinGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(new Coin { Currency = "currency", Quantity = 600 })
                .Returns(new Coin { Currency = "wrong currency", Quantity = 666 });

            var goods = new[] { new Good(), new Good() };
            var secondGoods = new[] { new Good(), new Good() };
            var wrongGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods).Returns(wrongGoods);

            var items = new[] { new Item(), new Item() };
            var secondItems = new[] { new Item(), new Item() };
            var wrongItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems).Returns(wrongItems);

            var encounter = encounterGenerator.Generate("environment", 9266);
            Assert.That(encounter.Treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(1200));
            Assert.That(goods, Is.SubsetOf(encounter.Treasure.Goods));
            Assert.That(items, Is.SubsetOf(encounter.Treasure.Items));
            Assert.That(secondGoods, Is.SubsetOf(encounter.Treasure.Goods));
            Assert.That(secondItems, Is.SubsetOf(encounter.Treasure.Items));
            Assert.That(wrongGoods, Is.Not.SubsetOf(encounter.Treasure.Goods));
            Assert.That(wrongItems, Is.Not.SubsetOf(encounter.Treasure.Items));
        }
    }
}
