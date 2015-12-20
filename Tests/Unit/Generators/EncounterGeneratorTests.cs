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
        private Dictionary<string, string> encounterTypeAndAmount;
        private Dictionary<string, string> encounterLevelAndModifier;
        private int level;
        private string environment;
        private List<string> requiresSubtype;

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

            encounterLevelAndModifier = new Dictionary<string, string>();
            encounterTypeAndAmount = new Dictionary<string, string>();
            requiresSubtype = new List<string>();

            mockSetLevelRandomizer.SetupAllProperties();
            mockSetLevelRandomizer.Object.AllowAdjustments = true;

            mockSetMetaraceRandomizer.SetupAllProperties();

            level = 9266;
            environment = "environment";
            encounterLevelAndModifier["90210"] = "9876";
            encounterTypeAndAmount["creature"] = "creature amount";

            var tableName = string.Format(TableNameConstants.LevelXEncounterLevel, level);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(encounterLevelAndModifier);

            tableName = string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 90210, environment);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(encounterTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("creature amount", 9876)).Returns("effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("effective roll")).Returns(42);

            mockCoinGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(new Coin { Currency = "currency", Quantity = 600 });
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(It.IsAny<double>())).Returns(true);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.MonsterGroups, GroupConstants.RequiresSubtype))
                .Returns(requiresSubtype);

            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> c) => c.Last());
        }

        [Test]
        public void GenerateEncounter()
        {
            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GenerateEncounterWithCharacters()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[CreatureConstants.Character + "1337"] = "character amount";
            mockRollSelector.Setup(s => s.SelectFrom("character amount", 9876)).Returns("character effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("character effective roll")).Returns(600);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo(CreatureConstants.Character));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(creature.Quantity));
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

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo(monster));
            Assert.That(creature.Quantity, Is.EqualTo(42));
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

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo(monster));
            Assert.That(creature.Quantity, Is.EqualTo(2));
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
            mockRollSelector.Setup(s => s.SelectFrom("dragon amount", 9876)).Returns("dragon effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("dragon effective roll")).Returns(600);

            var tableName = String.Format(TableNameConstants.LevelXDragons, 90210);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("dragon type and age");

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("dragon type and age"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GenerateEncounterWithMephit()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[CreatureConstants.Mephit] = "mephit amount";
            mockRollSelector.Setup(s => s.SelectFrom("mephit amount", 9876)).Returns("mephit effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("mephit effective roll")).Returns(600);

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.Mephits)).Returns("elemental mephit");

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("elemental mephit"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GenerateEncounterWithSubType()
        {
            requiresSubtype.Add("creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.MonsterGroups, "creature"))
                .Returns(new[] { "other creature" });

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "other creature")).Returns(new[] { "other challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(90210, "other challenge rating")).Returns("other roll");
            mockRollSelector.Setup(s => s.SelectFrom("other roll", 9876)).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("creature"));
            Assert.That(creature.Subtype, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GenerateEncounterWithRandomSubType()
        {
            requiresSubtype.Add("creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.MonsterGroups, "creature"))
                .Returns(new[] { "wrong creature", "other creature" });

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "other creature")).Returns(new[] { "other challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(90210, "other challenge rating")).Returns("other roll");
            mockRollSelector.Setup(s => s.SelectFrom("other roll", 9876)).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(90210, "wrong challenge rating")).Returns("wrong roll");
            mockRollSelector.Setup(s => s.SelectFrom("wrong roll", 9876)).Returns("wrong effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("wrong effective roll")).Returns(1337);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("creature"));
            Assert.That(creature.Subtype, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SubTypeIsRerolled()
        {
            requiresSubtype.Add("creature");
            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.MonsterGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns("wrong creature").Returns("other creature");

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "other creature")).Returns(new[] { "other challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(90210, "other challenge rating")).Returns("other roll");
            mockRollSelector.Setup(s => s.SelectFrom("other roll", 9876)).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(90210, "wrong challenge rating")).Returns(RollConstants.Reroll);
            mockRollSelector.Setup(s => s.SelectFrom(RollConstants.Reroll, 9876)).Returns("wrong effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("wrong effective roll")).Returns(1337);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("creature"));
            Assert.That(creature.Subtype, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SubTypeWithModifierIsRerolled()
        {
            requiresSubtype.Add("creature");
            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.MonsterGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns("wrong creature").Returns("other creature");

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "other creature")).Returns(new[] { "other challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(90210, "other challenge rating")).Returns("other roll");
            mockRollSelector.Setup(s => s.SelectFrom("other roll", 9876)).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(90210, "wrong challenge rating")).Returns("wrong roll");
            mockRollSelector.Setup(s => s.SelectFrom("wrong roll", 9876)).Returns(RollConstants.Reroll);
            mockRollSelector.Setup(s => s.SelectFrom(RollConstants.Reroll)).Returns(1337);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("creature"));
            Assert.That(creature.Subtype, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RerollEncounter()
        {
            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            var tableName = string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 90210, environment);
            mockTypeAndAmountPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(encounterTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("wrong creature amount", 9876)).Returns(RollConstants.Reroll);
            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RerollEntireEncounter()
        {
            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["creature"] = "creature amount";
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            var tableName = string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 90210, environment);
            mockTypeAndAmountPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(encounterTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("wrong creature amount", 9876)).Returns(RollConstants.Reroll);
            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GetEncounterWithMultipleTypesOfCreatures()
        {
            encounterTypeAndAmount["other creature"] = "other creature amount";

            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single(c => c.Type == "creature");
            var otherCreature = encounter.Creatures.Single(c => c.Type == "other creature");
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(otherCreature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(2));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GetTreasure()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(1);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(1);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(1);

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
        public void GetDifferentLevelsOfTreasure()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(0);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(1);

            var goods = new[] { new Good(), new Good() };
            var secondGoods = new[] { new Good(), new Good() };
            mockGoodsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(goods).Returns(secondGoods);

            var items = new[] { new Item(), new Item() };
            var secondItems = new[] { new Item(), new Item() };
            mockItemsGenerator.SetupSequence(g => g.GenerateAtLevel(level)).Returns(items).Returns(secondItems);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(goods, Is.SubsetOf(encounter.Treasure.Goods));
            Assert.That(secondGoods, Is.SubsetOf(encounter.Treasure.Goods));
            Assert.That(items, Is.SubsetOf(encounter.Treasure.Items));
            Assert.That(secondItems, Is.Not.SubsetOf(encounter.Treasure.Items));
        }

        [Test]
        public void GetMoreTreasure()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(2);
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
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(2);
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
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(0);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(0);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(0);

            mockCoinGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(new Coin { Currency = "currency", Quantity = 600 });

            var goods = new[] { new Good(), new Good() };
            mockGoodsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(goods);

            var items = new[] { new Item(), new Item() };
            mockItemsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(items);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(0));
            Assert.That(encounter.Treasure.Goods, Is.Empty);
            Assert.That(encounter.Treasure.Items, Is.Empty);
        }

        [Test]
        public void GetPartialTreasureWithGoodsAndItems()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(TreasureConstants.FiftyPercent);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(TreasureConstants.FiftyPercent);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(TreasureConstants.FiftyPercent);

            var goods = new[] { new Good(), new Good() };
            mockGoodsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(goods);

            var items = new[] { new Item(), new Item() };
            mockItemsGenerator.Setup(g => g.GenerateAtLevel(level)).Returns(items);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter.Treasure.Coin.Currency, Is.EqualTo("currency"));
            Assert.That(encounter.Treasure.Coin.Quantity, Is.EqualTo(300));
            Assert.That(goods, Is.SubsetOf(encounter.Treasure.Goods));
            Assert.That(items, Is.SubsetOf(encounter.Treasure.Items));
        }

        [Test]
        public void GetDifferentPartialTreasureWithGoodsAndItems()
        {
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(TreasureConstants.TenPercent);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(TreasureConstants.FiftyPercent);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(TreasureConstants.TenPercent);

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
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(TreasureConstants.TenPercent);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(TreasureConstants.FiftyPercent);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(TreasureConstants.TenPercent);

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TreasureConstants.TenPercent)).Returns(false);

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
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(TreasureConstants.TenPercent);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(TreasureConstants.FiftyPercent);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(TreasureConstants.TenPercent);

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TreasureConstants.FiftyPercent)).Returns(false);

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
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(TreasureConstants.TenPercent);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(TreasureConstants.FiftyPercent);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(TreasureConstants.TenPercent);

            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TreasureConstants.FiftyPercent)).Returns(false);
            mockBooleanPercentileSelector.Setup(s => s.SelectFrom(TreasureConstants.TenPercent)).Returns(false);

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

            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other effective roll")).Returns(600);

            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Coin)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Goods)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "creature", TreasureConstants.Items)).Returns(2);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "other creature", TreasureConstants.Coin)).Returns(1);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "other creature", TreasureConstants.Goods)).Returns(1);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustments, "other creature", TreasureConstants.Items)).Returns(1);

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

        [Test]
        public void ReplaceRollsInCreatureType()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["Hydra with 2d3+4 heads"] = "hydra amount";
            mockRollSelector.Setup(s => s.SelectFrom("hydra amount", 9876)).Returns("hydra effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("hydra effective roll")).Returns(1);
            mockRollSelector.Setup(s => s.SelectRollFrom("Hydra with 2d3+4 heads")).Returns("2d3+4");
            mockRollSelector.Setup(s => s.SelectFrom("2d3+4")).Returns(1337);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("Hydra with 1337 heads"));
            Assert.That(creature.Quantity, Is.EqualTo(1));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RollsInCreatureTypeAreUnique()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["Hydra with 2d3+4 heads"] = "hydra amount";
            mockRollSelector.Setup(s => s.SelectFrom("hydra amount", 9876)).Returns("hydra effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("hydra effective roll")).Returns(2);
            mockRollSelector.Setup(s => s.SelectRollFrom("Hydra with 2d3+4 heads")).Returns("2d3+4");
            mockRollSelector.SetupSequence(s => s.SelectFrom("2d3+4")).Returns(1337).Returns(1234);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var firstCreature = encounter.Creatures.First(c => c.Type == "Hydra with 1337 heads");
            var secondCreature = encounter.Creatures.First(c => c.Type == "Hydra with 1234 heads");

            Assert.That(firstCreature.Quantity, Is.EqualTo(1));
            Assert.That(secondCreature.Quantity, Is.EqualTo(1));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(2));
            Assert.That(encounter.Characters, Is.Empty);
        }
    }
}
