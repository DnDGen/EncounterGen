using CharacterGen.Common;
using CharacterGen.Generators;
using CharacterGen.Generators.Randomizers.Alignments;
using CharacterGen.Generators.Randomizers.CharacterClasses;
using CharacterGen.Generators.Randomizers.Races;
using CharacterGen.Generators.Randomizers.Stats;
using EncounterGen.Common;
using EncounterGen.Generators;
using EncounterGen.Generators.Domain;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common;
using TreasureGen.Generators;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterGeneratorTests
    {
        private IEncounterGenerator encounterGenerator;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ITreasureGenerator> mockTreasureGenerator;
        private Mock<ICharacterGenerator> mockCharacterGenerator;
        private Mock<IAlignmentRandomizer> mockAnyAlignmentRandomizer;
        private Mock<IClassNameRandomizer> mockAnyClassNameRandomizer;
        private Mock<ISetLevelRandomizer> mockSetLevelRandomizer;
        private Mock<RaceRandomizer> mockAnyBaseRaceRandomizer;
        private Mock<RaceRandomizer> mockAnyMetaraceRandomizer;
        private Mock<IStatsRandomizer> mockRawStatsRandomizer;
        private Mock<IAdjustmentSelector> mockAdjustmentSelector;
        private Dictionary<String, Int32> typesAndAmounts;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockTreasureGenerator = new Mock<ITreasureGenerator>();
            mockCharacterGenerator = new Mock<ICharacterGenerator>();
            mockAnyAlignmentRandomizer = new Mock<IAlignmentRandomizer>();
            mockAnyClassNameRandomizer = new Mock<IClassNameRandomizer>();
            mockSetLevelRandomizer = new Mock<ISetLevelRandomizer>();
            mockAnyBaseRaceRandomizer = new Mock<RaceRandomizer>();
            mockAnyMetaraceRandomizer = new Mock<RaceRandomizer>();
            mockRawStatsRandomizer = new Mock<IStatsRandomizer>();
            mockAdjustmentSelector = new Mock<IAdjustmentSelector>();
            typesAndAmounts = new Dictionary<String, Int32>();

            encounterGenerator = new EncounterGenerator(mockTypeAndAmountPercentileSelector.Object, mockTreasureGenerator.Object,
                mockCharacterGenerator.Object, mockAnyAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, mockSetLevelRandomizer.Object,
                mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object, mockAdjustmentSelector.Object);

            mockSetLevelRandomizer.SetupAllProperties();

            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, It.IsAny<String>())).Returns(1);
        }

        [Test]
        public void GenerateEncounter()
        {
            typesAndAmounts["creature"] = 12345;

            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 9266, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(typesAndAmounts);

            var treasure = new Treasure();
            mockTreasureGenerator.Setup(g => g.GenerateAtLevel(9266)).Returns(treasure);

            var encounter = encounterGenerator.Generate("environment", 9266);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo("creature"));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(12345));
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Treasures.Single(), Is.EqualTo(treasure));
        }

        [Test]
        public void GenerateEncounterWithCharacters()
        {
            typesAndAmounts[CreatureConstants.Character] = 42;

            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 9266, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(typesAndAmounts);

            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.CharacterLevel, "9266")).Returns(23456);

            mockCharacterGenerator.Setup(g => g.GenerateWith(mockAnyAlignmentRandomizer.Object, mockAnyClassNameRandomizer.Object, It.Is<ISetLevelRandomizer>(r => r.SetLevel == 23456), mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object))
                .Returns(() => new Character { InterestingTrait = Guid.NewGuid().ToString() });

            var encounter = encounterGenerator.Generate("environment", 9266);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo(CreatureConstants.Character));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(42));
            Assert.That(encounter.Characters.Count(), Is.EqualTo(42));
            Assert.That(encounter.Characters, Is.Unique);
            Assert.That(encounter.Characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void RollEncounterAgainAtDifferentLevel()
        {
            var rerollTypesAndAmounts = new Dictionary<String, Int32>();
            rerollTypesAndAmounts[EncounterConstants.Reroll] = 90210;

            typesAndAmounts["creature"] = 12345;

            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 9266, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(rerollTypesAndAmounts);

            tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 90210, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(typesAndAmounts);

            var treasure = new Treasure();
            mockTreasureGenerator.Setup(g => g.GenerateAtLevel(90210)).Returns(treasure);

            var encounter = encounterGenerator.Generate("environment", 9266);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo("creature"));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(12345));
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Treasures.Single(), Is.EqualTo(treasure));
        }

        [Test]
        public void RerollUntilNonRerollEncounterIsRolled()
        {
            var rerollTypesAndAmounts = new Dictionary<String, Int32>();
            rerollTypesAndAmounts[EncounterConstants.Reroll] = 90210;

            var rerollAgainTypesAndAmounts = new Dictionary<String, Int32>();
            rerollAgainTypesAndAmounts[EncounterConstants.Reroll] = 23456;

            typesAndAmounts["creature"] = 12345;

            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 9266, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(rerollTypesAndAmounts);

            tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 90210, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(rerollAgainTypesAndAmounts);

            tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 23456, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(typesAndAmounts);

            var treasure = new Treasure();
            mockTreasureGenerator.Setup(g => g.GenerateAtLevel(23456)).Returns(treasure);

            var encounter = encounterGenerator.Generate("environment", 9266);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo("creature"));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(12345));
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Treasures.Single(), Is.EqualTo(treasure));
        }

        [Test]
        public void GetEncounterWithMultipleTypesOfCreatures()
        {
            typesAndAmounts["creature"] = 12345;
            typesAndAmounts["other creature"] = 90210;

            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 9266, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(typesAndAmounts);

            var treasure = new Treasure();
            mockTreasureGenerator.Setup(g => g.GenerateAtLevel(9266)).Returns(treasure);

            var encounter = encounterGenerator.Generate("environment", 9266);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures.Count(c => c == "creature"), Is.EqualTo(12345));
            Assert.That(encounter.Creatures.Count(c => c == "other creature"), Is.EqualTo(90210));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(12345 + 90210));
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Treasures.Single(), Is.EqualTo(treasure));
        }

        [Test]
        public void GetMoreTreasure()
        {
            typesAndAmounts["creature"] = 12345;

            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 9266, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(typesAndAmounts);

            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(2);

            var treasure = new Treasure();
            var secondTreasure = new Treasure();
            mockTreasureGenerator.SetupSequence(g => g.GenerateAtLevel(9266)).Returns(treasure).Returns(secondTreasure);

            var encounter = encounterGenerator.Generate("environment", 9266);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo("creature"));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(12345));
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Treasures, Contains.Item(treasure));
            Assert.That(encounter.Treasures, Contains.Item(secondTreasure));
            Assert.That(encounter.Treasures.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetNoTreasure()
        {
            typesAndAmounts["creature"] = 12345;

            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 9266, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(typesAndAmounts);

            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(0);

            var treasure = new Treasure();
            mockTreasureGenerator.Setup(g => g.GenerateAtLevel(9266)).Returns(treasure);

            var encounter = encounterGenerator.Generate("environment", 9266);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures, Is.All.EqualTo("creature"));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(12345));
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Treasures, Is.Empty);
        }

        [Test]
        public void UseFirstCreatureForTreasure()
        {
            typesAndAmounts["creature"] = 12345;
            typesAndAmounts["other creature"] = 90210;

            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 9266, "environment");
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(typesAndAmounts);

            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "creature")).Returns(600);
            mockAdjustmentSelector.Setup(s => s.SelectFrom(TableNameConstants.TreasureAdjustment, "other creature")).Returns(1);

            mockTreasureGenerator.Setup(g => g.GenerateAtLevel(9266)).Returns(() => new Treasure());

            var encounter = encounterGenerator.Generate("environment", 9266);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Creatures.Count(c => c == "creature"), Is.EqualTo(12345));
            Assert.That(encounter.Creatures.Count(c => c == "other creature"), Is.EqualTo(90210));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(12345 + 90210));
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Treasures.Count(), Is.EqualTo(600));
        }
    }
}
