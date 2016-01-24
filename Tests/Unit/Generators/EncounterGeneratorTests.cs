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
using EncounterGen.Generators.Exceptions;
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
        private Mock<IClassNameRandomizer> mockAnyPlayerClassNameRandomizer;
        private Mock<IClassNameRandomizer> mockAnyNPCClassNameRandomizer;
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
        private Mock<ISetClassNameRandomizer> mockSetClassNameRandomizer;
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
            mockAnyPlayerClassNameRandomizer = new Mock<IClassNameRandomizer>();
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
            mockSetClassNameRandomizer = new Mock<ISetClassNameRandomizer>();
            mockAnyNPCClassNameRandomizer = new Mock<IClassNameRandomizer>();

            encounterGenerator = new EncounterGenerator(mockTypeAndAmountPercentileSelector.Object, mockCoinGenerator.Object,
                mockGoodsGenerator.Object, mockItemsGenerator.Object, mockCharacterGenerator.Object, mockAnyAlignmentRandomizer.Object, mockAnyPlayerClassNameRandomizer.Object, mockSetLevelRandomizer.Object,
                mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object, mockAdjustmentSelector.Object,
                mockRollSelector.Object, mockPercentileSelector.Object, mockBooleanPercentileSelector.Object, mockCollectionSelector.Object,
                mockSetMetaraceRandomizer.Object, mockAnyNPCClassNameRandomizer.Object, mockSetClassNameRandomizer.Object);

            encounterLevelAndModifier = new Dictionary<string, string>();
            encounterTypeAndAmount = new Dictionary<string, string>();
            requiresSubtype = new List<string>();

            mockSetLevelRandomizer.SetupAllProperties();
            mockSetLevelRandomizer.Object.AllowAdjustments = true;

            mockSetMetaraceRandomizer.SetupAllProperties();
            mockSetClassNameRandomizer.SetupAllProperties();

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

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype))
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
            encounterTypeAndAmount[CreatureConstants.Character + "[1337]"] = "character amount";
            mockRollSelector.Setup(s => s.SelectFrom("character amount", 9876)).Returns("character effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("character effective roll")).Returns(600);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyPlayerClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
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
        public void GenerateEncounterWithCharactersWithVariableLevels()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[CreatureConstants.Character + "[13d37]"] = "character amount";
            mockRollSelector.Setup(s => s.SelectFrom("character amount", 9876)).Returns("character effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("character effective roll")).Returns(600);

            mockRollSelector.Setup(s => s.SelectRollFrom("[13d37]")).Returns("character level roll");
            mockRollSelector.Setup(s => s.SelectFrom("character level roll")).Returns(1337);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyPlayerClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
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
        public void VariableLevelsAreUniquePerCharacter()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[CreatureConstants.Character + "[13d37]"] = "character amount";

            mockRollSelector.Setup(s => s.SelectFrom("character amount", 9876)).Returns("character effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("character effective roll")).Returns(2);

            mockRollSelector.Setup(s => s.SelectRollFrom("[13d37]")).Returns("character level roll");
            mockRollSelector.SetupSequence(s => s.SelectFrom("character level roll")).Returns(1337).Returns(1234);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyPlayerClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments == true), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
                .Returns(() => new Character { Class = new CharacterClass { Level = 1337 } });

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyPlayerClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1234 && r.AllowAdjustments == true), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
                .Returns(() => new Character { Class = new CharacterClass { Level = 1234 } });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo(CreatureConstants.Character));
            Assert.That(creature.Quantity, Is.EqualTo(2));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(2));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Any(c => c.Class.Level == 1337), Is.True);
            Assert.That(encounter.Characters.Any(c => c.Class.Level == 1234), Is.True);
        }

        [Test]
        public void GenerateEncounterWithUndeadNPCs()
        {
            var monster = encounterTypeAndAmount.First();
            encounterTypeAndAmount.Clear();

            encounterTypeAndAmount[monster.Key + "[6789]"] = monster.Value;

            var undead = new[] { monster.Key, "other monster" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UndeadNPC)).Returns(undead);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyPlayerClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 6789 && r.AllowAdjustments == false), mockAnyBaseRaceRandomizer.Object, It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == monster.Key), mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo(monster.Key));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(42));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void UndeadNPCsEachHaveUniqueLevel()
        {
            var monster = encounterTypeAndAmount.First();
            encounterTypeAndAmount.Clear();

            encounterTypeAndAmount[monster.Key + "[67d89]"] = monster.Value;

            var undead = new[] { monster.Key, "other monster" };
            mockRollSelector.Setup(s => s.SelectFrom("effective roll")).Returns(2);

            mockRollSelector.Setup(s => s.SelectRollFrom("[67d89]")).Returns("character level roll");
            mockRollSelector.SetupSequence(s => s.SelectFrom("character level roll")).Returns(1337).Returns(1234);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UndeadNPC)).Returns(undead);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyPlayerClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments == false), mockAnyBaseRaceRandomizer.Object, It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == monster.Key), mockRawStatsRandomizer.Object))
                .Returns(() => new Character { Class = new CharacterClass { Level = 1337 } });

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyPlayerClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1234 && r.AllowAdjustments == false), mockAnyBaseRaceRandomizer.Object, It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == monster.Key), mockRawStatsRandomizer.Object))
                .Returns(() => new Character { Class = new CharacterClass { Level = 1234 } });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo(monster.Key));
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

            var tableName = string.Format(TableNameConstants.LevelXDragons, 90210);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("dragon type and age");

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("dragon type and age"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GenerateEncounterWithSubType()
        {
            requiresSubtype.Add("creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature"))
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
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature"))
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
        public void GenerateEncounterWithSetSubType()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["creature (subtype)"] = "creature amount";
            mockRollSelector.Setup(s => s.SelectFrom("creature amount", 9876)).Returns("creature effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("creature effective roll")).Returns(600);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("creature"));
            Assert.That(creature.Subtype, Is.EqualTo("subtype"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SubTypeIsRerolled()
        {
            requiresSubtype.Add("creature");
            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

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
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

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
        public void ImpossibleSubtypeThrowsException()
        {
            requiresSubtype.Add("creature");
            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.Setup(s => s.SelectRandomFrom(subtypes)).Returns("wrong creature");

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(90210, "wrong challenge rating")).Returns(RollConstants.Reroll);
            mockRollSelector.Setup(s => s.SelectFrom(RollConstants.Reroll, 9876)).Returns("wrong effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("wrong effective roll")).Returns(1337);

            Assert.That(() => encounterGenerator.Generate(environment, level), Throws.InstanceOf<ImpossibleEncounterException>());
            mockCollectionSelector.Verify(s => s.SelectRandomFrom(subtypes), Times.Exactly(10000));
            mockCollectionSelector.Verify(s => s.SelectFrom(tableName, "wrong creature"), Times.Exactly(10000));
            mockRollSelector.Verify(s => s.SelectFrom(90210, "wrong challenge rating"), Times.Exactly(10000));
            mockRollSelector.Verify(s => s.SelectFrom(RollConstants.Reroll, 9876), Times.Exactly(10000));
        }

        [Test]
        public void ImpossibleSubtypeWithModifierThrowsException()
        {
            requiresSubtype.Add("creature");
            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.Setup(s => s.SelectRandomFrom(subtypes)).Returns("wrong creature");

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(90210, "wrong challenge rating")).Returns("wrong roll");
            mockRollSelector.Setup(s => s.SelectFrom("wrong roll", 9876)).Returns(RollConstants.Reroll);
            mockRollSelector.Setup(s => s.SelectFrom(RollConstants.Reroll)).Returns(1337);

            Assert.That(() => encounterGenerator.Generate(environment, level), Throws.InstanceOf<ImpossibleEncounterException>());
            mockCollectionSelector.Verify(s => s.SelectRandomFrom(subtypes), Times.Exactly(10000));
            mockCollectionSelector.Verify(s => s.SelectFrom(tableName, "wrong creature"), Times.Exactly(10000));
            mockRollSelector.Verify(s => s.SelectFrom(90210, "wrong challenge rating"), Times.Exactly(10000));
            mockRollSelector.Verify(s => s.SelectFrom("wrong roll", 9876), Times.Exactly(10000));
        }

        [Test]
        public void EncounterSpecificClass()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["character class[1337]"] = "character class amount";
            mockRollSelector.Setup(s => s.SelectFrom("character class amount", 9876)).Returns("character class effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("character class effective roll")).Returns(600);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character))
                .Returns(new[] { "other character class", "character class" });
            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockSetClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("character class"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(creature.Quantity));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Select(c => c.InterestingTrait), Is.Unique);
            Assert.That(mockSetClassNameRandomizer.Object.SetClassName, Is.EqualTo("character class"));
        }

        [Test]
        public void EncounterSpecificNPCClass()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["npc class[1337]"] = "npc class amount";
            mockRollSelector.Setup(s => s.SelectFrom("npc class amount", 9876)).Returns("npc class effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("npc class effective roll")).Returns(600);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character))
                .Returns(new[] { "other character class", "character class", "npc class" });
            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockSetClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("npc class"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(creature.Quantity));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Select(c => c.InterestingTrait), Is.Unique);
            Assert.That(mockSetClassNameRandomizer.Object.SetClassName, Is.EqualTo("npc class"));
        }

        [Test]
        public void EncounterRandomNPCClass()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[CreatureConstants.NPC + "[1337]"] = "npc amount";
            mockRollSelector.Setup(s => s.SelectFrom("npc amount", 9876)).Returns("npc effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("npc effective roll")).Returns(600);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyNPCClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo(CreatureConstants.NPC));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(creature.Quantity));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void EncounterSpecificNPCClassDescribedAsSomethingElse()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["npc class (description)[1337]"] = "npc class amount";
            mockRollSelector.Setup(s => s.SelectFrom("npc class amount", 9876)).Returns("npc class effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("npc class effective roll")).Returns(600);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character))
                .Returns(new[] { "other character class", "character class", "npc class" });
            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockSetClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("npc class"));
            Assert.That(creature.Subtype, Is.EqualTo("description"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(creature.Quantity));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Select(c => c.InterestingTrait), Is.Unique);
            Assert.That(mockSetClassNameRandomizer.Object.SetClassName, Is.EqualTo("npc class"));
        }

        [Test]
        public void EncounterRandomNPCClassDescribedAsSomethingElse()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[CreatureConstants.NPC + " (description)[1337]"] = "npc amount";
            mockRollSelector.Setup(s => s.SelectFrom("npc amount", 9876)).Returns("npc effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("npc effective roll")).Returns(600);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyNPCClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo(CreatureConstants.NPC));
            Assert.That(creature.Subtype, Is.EqualTo("description"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(creature.Quantity));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void EncounterMultipleTypesOfCharacters()
        {
            var monster = encounterTypeAndAmount.First();
            encounterTypeAndAmount.Clear();

            encounterTypeAndAmount[monster.Key + "[6798]"] = monster.Value;
            encounterTypeAndAmount[CreatureConstants.NPC + " (description 1)[1337]"] = "npc with description amount";
            encounterTypeAndAmount["npc class (description 2)[1234]"] = "npc class with description amount";
            encounterTypeAndAmount[CreatureConstants.NPC + "[2345]"] = "npc amount";
            encounterTypeAndAmount["npc class[3456]"] = "npc class amount";
            encounterTypeAndAmount["character class[4567]"] = "character class amount";
            encounterTypeAndAmount[CreatureConstants.Character + "[5678]"] = "character amount";

            var undead = new[] { monster.Key, "other monster" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UndeadNPC)).Returns(undead);

            mockRollSelector.Setup(s => s.SelectFrom("character amount", 9876)).Returns("character effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("character effective roll")).Returns(7);
            mockRollSelector.Setup(s => s.SelectFrom("character class amount", 9876)).Returns("character class effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("character class effective roll")).Returns(8);
            mockRollSelector.Setup(s => s.SelectFrom("npc class amount", 9876)).Returns("npc class effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("npc class effective roll")).Returns(9);
            mockRollSelector.Setup(s => s.SelectFrom("npc amount", 9876)).Returns("npc effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("npc effective roll")).Returns(10);
            mockRollSelector.Setup(s => s.SelectFrom("npc class with description amount", 9876)).Returns("npc class with description effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("npc class with description effective roll")).Returns(11);
            mockRollSelector.Setup(s => s.SelectFrom("npc with description amount", 9876)).Returns("npc with description effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("npc with description effective roll")).Returns(12);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character))
                .Returns(new[] { "other character class", "character class", "npc class" });

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, It.IsAny<IClassNameRandomizer>(), mockSetLevelRandomizer.Object, mockAnyBaseRaceRandomizer.Object, It.IsAny<RaceRandomizer>(), mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creatureList = encounter.Creatures.ToList();
            Assert.That(creatureList.Count, Is.EqualTo(7));
            Assert.That(creatureList[0].Type, Is.EqualTo(monster.Key));
            Assert.That(creatureList[0].Subtype, Is.Empty);
            Assert.That(creatureList[0].Quantity, Is.EqualTo(42));
            Assert.That(creatureList[1].Type, Is.EqualTo(CreatureConstants.NPC));
            Assert.That(creatureList[1].Subtype, Is.EqualTo("description 1"));
            Assert.That(creatureList[1].Quantity, Is.EqualTo(12));
            Assert.That(creatureList[2].Type, Is.EqualTo("npc class"));
            Assert.That(creatureList[2].Subtype, Is.EqualTo("description 2"));
            Assert.That(creatureList[2].Quantity, Is.EqualTo(11));
            Assert.That(creatureList[3].Type, Is.EqualTo(CreatureConstants.NPC));
            Assert.That(creatureList[3].Subtype, Is.Empty);
            Assert.That(creatureList[3].Quantity, Is.EqualTo(10));
            Assert.That(creatureList[4].Type, Is.EqualTo("npc class"));
            Assert.That(creatureList[4].Subtype, Is.Empty);
            Assert.That(creatureList[4].Quantity, Is.EqualTo(9));
            Assert.That(creatureList[5].Type, Is.EqualTo("character class"));
            Assert.That(creatureList[5].Subtype, Is.Empty);
            Assert.That(creatureList[5].Quantity, Is.EqualTo(8));
            Assert.That(creatureList[6].Type, Is.EqualTo(CreatureConstants.Character));
            Assert.That(creatureList[6].Subtype, Is.Empty);
            Assert.That(creatureList[6].Quantity, Is.EqualTo(7));

            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(encounter.Characters.Count(), Is.EqualTo(99));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Select(c => c.InterestingTrait), Is.Unique);
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
        public void GetTreasureFromCreatureWithDescription()
        {
            var monster = encounterTypeAndAmount.First();
            encounterTypeAndAmount.Clear();

            encounterTypeAndAmount[monster.Key + " (description)"] = monster.Value;

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character))
                .Returns(new[] { "other character class", monster.Key });

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
        public void GetTreasureForCreatureWithCharacterLevel()
        {
            var monster = encounterTypeAndAmount.First();
            encounterTypeAndAmount.Clear();

            encounterTypeAndAmount[monster.Key + "[1]"] = monster.Value;

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character))
                .Returns(new[] { "other character class", monster.Key });

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
        public void ReplaceRollsInCreatureType()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["Hydra (2d3+4 heads)"] = "hydra amount";
            mockRollSelector.Setup(s => s.SelectFrom("hydra amount", 9876)).Returns("hydra effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("hydra effective roll")).Returns(1);
            mockRollSelector.Setup(s => s.SelectRollFrom("Hydra (2d3+4 heads)")).Returns("2d3+4");
            mockRollSelector.Setup(s => s.SelectFrom("2d3+4")).Returns(1337);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type, Is.EqualTo("Hydra"));
            Assert.That(creature.Subtype, Is.EqualTo("1337 heads"));
            Assert.That(creature.Quantity, Is.EqualTo(1));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RollsInCreatureTypeAreUnique()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["Hydra (2d3+4 heads)"] = "hydra amount";
            mockRollSelector.Setup(s => s.SelectFrom("hydra amount", 9876)).Returns("hydra effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("hydra effective roll")).Returns(2);
            mockRollSelector.Setup(s => s.SelectRollFrom("Hydra (2d3+4 heads)")).Returns("2d3+4");
            mockRollSelector.SetupSequence(s => s.SelectFrom("2d3+4")).Returns(1337).Returns(1234);

            var encounter = encounterGenerator.Generate(environment, level);
            Assert.That(encounter, Is.Not.Null);

            var firstCreature = encounter.Creatures.First(c => c.Subtype == "1337 heads");
            var secondCreature = encounter.Creatures.First(c => c.Subtype == "1234 heads");

            Assert.That(firstCreature.Quantity, Is.EqualTo(1));
            Assert.That(secondCreature.Quantity, Is.EqualTo(1));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(2));
            Assert.That(encounter.Characters, Is.Empty);
        }
    }
}
