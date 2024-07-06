using DnDGen.CharacterGen.Characters;
using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Selectors.Collections;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Percentiles;
using DnDGen.TreasureGen;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterGeneratorTests
    {
        private IEncounterGenerator encounterGenerator;
        private Mock<IEncounterLevelSelector> mockAmountSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<IEncounterCharacterGenerator> mockEncounterCharacterGenerator;
        private Mock<IEncounterTreasureGenerator> mockEncounterTreasureGenerator;
        private Mock<ICreatureGenerator> mockCreatureGenerator;
        private Mock<IEncounterVerifier> mockEncounterVerifier;
        private Mock<IEncounterCollectionSelector> mockEncounterCollectionSelector;
        private Treasure treasure;
        private int levelModifier;
        private int actualEncounterLevel;
        private EncounterSpecifications specifications;
        private List<EncounterCreature> creatures;
        private List<Treasure> treasures;

        private int EncounterLevel => specifications.Level + levelModifier;

        [SetUp]
        public void Setup()
        {
            mockAmountSelector = new Mock<IEncounterLevelSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockEncounterCharacterGenerator = new Mock<IEncounterCharacterGenerator>();
            mockEncounterTreasureGenerator = new Mock<IEncounterTreasureGenerator>();
            mockEncounterVerifier = new Mock<IEncounterVerifier>();
            mockCreatureGenerator = new Mock<ICreatureGenerator>();
            mockEncounterCollectionSelector = new Mock<IEncounterCollectionSelector>();

            encounterGenerator = new EncounterGenerator(
                mockAmountSelector.Object,
                mockPercentileSelector.Object,
                mockEncounterCharacterGenerator.Object,
                mockEncounterTreasureGenerator.Object,
                mockEncounterVerifier.Object,
                mockCreatureGenerator.Object,
                mockEncounterCollectionSelector.Object);

            specifications = new EncounterSpecifications();
            treasure = new Treasure();
            creatures = new List<EncounterCreature>();
            treasures = new List<Treasure>();

            levelModifier = 1;
            specifications.Level = 10;
            specifications.Environment = "environment";
            specifications.Temperature = "temperature";
            specifications.TimeOfDay = "time of day";
            treasure.Coin.Quantity = 8765;
            actualEncounterLevel = 12;

            treasures.Add(treasure);

            var creature = new EncounterCreature();
            creature.Creature.Name = "creature";
            creature.Quantity = 42;
            creature.ChallengeRating = "challenge rating";
            creatures.Add(creature);

            mockPercentileSelector.Setup(s => s.SelectFrom<int>(Config.Name, TableNameConstants.EncounterLevelModifiers)).Returns(() => levelModifier);
            mockEncounterCollectionSelector
                .Setup(g => g.SelectRandomEncounterFrom(It.Is<EncounterSpecifications>(es => es.Level == EncounterLevel)))
                .Returns("my encounter");
            mockCreatureGenerator.Setup(g => g.GenerateFor("my encounter")).Returns(creatures);
            mockCreatureGenerator.Setup(g => g.CleanCreatures(It.IsAny<IEnumerable<EncounterCreature>>())).Returns((IEnumerable<EncounterCreature> cc) => cc);
            mockAmountSelector.Setup(d => d.Select(It.IsAny<Encounter>())).Returns(actualEncounterLevel);

            mockEncounterVerifier.Setup(v => v.ValidEncounterExists(specifications)).Returns(true);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExists(It.Is<EncounterSpecifications>(es => es.Level == EncounterLevel))).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.IsAny<Encounter>(), specifications.CreatureTypeFilters)).Returns(true);

            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.IsAny<IEnumerable<EncounterCreature>>(), It.IsAny<int>())).Returns(Enumerable.Empty<Treasure>());
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(creatures, actualEncounterLevel)).Returns(treasures);
        }

        [Test]
        public void GenerateEncounter()
        {
            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Description, Is.EqualTo("my encounter"));
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.AverageDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(11));
            Assert.That(encounter.ActualDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(12));
            Assert.That(encounter.Creatures, Is.EqualTo(creatures));
            Assert.That(encounter.Treasures, Is.EqualTo(treasures));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Creature.Description, Is.Empty);
            Assert.That(creature.Creature.SubCreature, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
        }

        [Test]
        public void EncounterLevelMustBeValid()
        {
            mockPercentileSelector.SetupSequence(s => s.SelectFrom<int>(Config.Name, TableNameConstants.EncounterLevelModifiers)).Returns(9999).Returns(levelModifier);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExists(It.Is<EncounterSpecifications>(s => s.Level == 10009))).Returns(false);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Description, Is.EqualTo("my encounter"));
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.AverageDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(11));
            Assert.That(encounter.ActualDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(12));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Creature.Description, Is.Empty);
            Assert.That(creature.Creature.SubCreature, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
        }

        [Test]
        public void GenerateEncounterWithCharacters()
        {
            var characters = new[] { new Character(), new Character() };
            mockEncounterCharacterGenerator.Setup(g => g.GenerateFrom(It.IsAny<IEnumerable<EncounterCreature>>())).Returns(characters);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Description, Is.EqualTo("my encounter"));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Creature.Description, Is.Empty);
            Assert.That(creature.Creature.SubCreature, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));

            Assert.That(encounter.Characters, Is.EquivalentTo(characters));
        }

        [Test]
        public void CleanUpCreatures()
        {
            var cleanedCreatures = new[]
            {
                new EncounterCreature()
            };

            cleanedCreatures[0].Creature.Name = "cleaned creature";
            mockCreatureGenerator.Setup(g => g.CleanCreatures(creatures)).Returns(cleanedCreatures);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Description, Is.EqualTo("my encounter"));
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Creatures, Is.EqualTo(cleanedCreatures));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Creature.Name, Is.EqualTo("cleaned creature"));
        }

        //INFO: This may occur if an encounter has a chance of a creature occurring that matches a filter
        //Example: % chance of having a dragon in the encounter, so enocunter matches filter, but when actually generating, no dragon.
        //Therefore, regenerate the entire encounter
        [Test]
        public void RerollEncounter_IfEncounterCreaturesDoNotMatchFilters_SameEncounter()
        {
            mockCreatureGenerator
                .SetupSequence(g => g.GenerateFor("my encounter"))
                .Returns(new[] { new EncounterCreature { Creature = new Creature { Name = "bad creature" }, Quantity = 666 } })
                .Returns(creatures);

            mockEncounterVerifier
                .Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Single().Quantity == 600), specifications.CreatureTypeFilters))
                .Returns(true);
            mockEncounterVerifier
                .Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Single().Quantity == 666), specifications.CreatureTypeFilters))
                .Returns(false);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Description, Is.EqualTo("my encounter"));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);

            mockCreatureGenerator.Verify(g => g.GenerateFor("my encounter"), Times.Exactly(2));
        }

        [Test]
        public void RerollEncounter_IfEncounterCreaturesDoNotMatchFilters_DifferentEncounter()
        {
            mockEncounterCollectionSelector
                .SetupSequence(g => g.SelectRandomEncounterFrom(It.Is<EncounterSpecifications>(es => es.Level == EncounterLevel)))
                .Returns("my encounter")
                .Returns("my other encounter");

            var wrongCreatures = new[]
            {
                new EncounterCreature(),
                new EncounterCreature(),
            };

            wrongCreatures[0].Creature.Name = "creature";
            wrongCreatures[0].Quantity = 42;
            wrongCreatures[1].Creature.Name = "wrong creature";
            wrongCreatures[1].Quantity = 666;

            var otherCreatures = new[]
            {
                new EncounterCreature(),
            };

            otherCreatures[0].Creature.Name = "other creature";
            otherCreatures[0].Quantity = 600;

            mockCreatureGenerator
                .Setup(s => s.GenerateFor("my encounter"))
                .Returns(wrongCreatures);

            mockCreatureGenerator
                .Setup(s => s.GenerateFor("my other encounter"))
                .Returns(otherCreatures);

            mockEncounterVerifier
                .Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Creature.Name == "other creature")), specifications.CreatureTypeFilters))
                .Returns(true);
            mockEncounterVerifier
                .Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Creature.Name == "wrong creature")), specifications.CreatureTypeFilters))
                .Returns(false);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Description, Is.EqualTo("my other encounter"));
            Assert.That(encounter.Creatures, Is.EqualTo(otherCreatures));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GetTreasure()
        {
            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Description, Is.EqualTo("my encounter"));
            Assert.That(encounter.Treasures.Single, Is.EqualTo(treasure));
        }

        [Test]
        public void GetTreasureForAllCreatures()
        {
            var otherCreature = new EncounterCreature();
            otherCreature.Creature.Name = "other creature";
            otherCreature.Quantity = 600;
            creatures.Add(otherCreature);

            var otherTreasure = new Treasure();
            otherTreasure.Coin.Quantity = 1337;
            treasures.Add(otherTreasure);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Description, Is.EqualTo("my encounter"));
            Assert.That(encounter.Creatures, Is.EqualTo(creatures));
            Assert.That(encounter.Creatures.Count, Is.EqualTo(2));
            Assert.That(encounter.Treasures, Is.EqualTo(treasures));
            Assert.That(encounter.Treasures, Contains.Item(treasure));
            Assert.That(encounter.Treasures, Contains.Item(otherTreasure));
            Assert.That(encounter.Treasures.Count, Is.EqualTo(2));
        }

        [Test]
        public void RerollEncounterLevelIfEncounterMustBeRerolledForFilter()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var wrongCreatures = new[]
            {
                new EncounterCreature(),
                new EncounterCreature(),
            };

            wrongCreatures[0].Creature.Name = "creature";
            wrongCreatures[0].Quantity = 42;
            wrongCreatures[1].Creature.Name = "wrong creature";
            wrongCreatures[1].Quantity = 666;

            var otherCreatures = new[]
            {
                new EncounterCreature(),
            };

            otherCreatures[0].Creature.Name = "other creature";
            otherCreatures[0].Quantity = 600;

            mockPercentileSelector
                .SetupSequence(s => s.SelectFrom<int>(Config.Name, TableNameConstants.EncounterLevelModifiers))
                .Returns(-4)
                .Returns(4);

            mockEncounterCollectionSelector
                .Setup(g => g.SelectRandomEncounterFrom(It.Is<EncounterSpecifications>(es => es.Level == 14)))
                .Returns("my other encounter");
            mockEncounterCollectionSelector
                .Setup(g => g.SelectRandomEncounterFrom(It.Is<EncounterSpecifications>(es => es.Level == 6)))
                .Returns("my wrong encounter");

            mockCreatureGenerator.Setup(s => s.GenerateFor("my other encounter")).Returns(otherCreatures);
            mockCreatureGenerator.Setup(s => s.GenerateFor("my wrong encounter")).Returns(wrongCreatures);

            mockEncounterVerifier.Setup(v => v.ValidEncounterExists(It.Is<EncounterSpecifications>(es => es.Level == specifications.Level + 4))).Returns(true);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExists(It.Is<EncounterSpecifications>(es => es.Level == specifications.Level - 4))).Returns(false);

            mockEncounterVerifier
                .Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Creature.Name == "other creature")), specifications.CreatureTypeFilters))
                .Returns(true);
            mockEncounterVerifier
                .Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Creature.Name == "wrong creature")), specifications.CreatureTypeFilters))
                .Returns(false);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Description, Is.EqualTo("my other encounter"));
            Assert.That(encounter.Creatures, Is.EqualTo(otherCreatures));
        }

        [Test]
        public void RegenerateEncounterIfEncounterActualCreaturesAndAmountsAreInvalid()
        {
            var wrongCreatures = new[]
            {
                new EncounterCreature(),
                new EncounterCreature(),
            };

            wrongCreatures[0].Creature.Name = "creature";
            wrongCreatures[0].Quantity = 42;
            wrongCreatures[1].Creature.Name = "wrong creature";
            wrongCreatures[1].Quantity = 666;

            var otherCreatures = new[]
            {
                new EncounterCreature(),
            };

            otherCreatures[0].Creature.Name = "other creature";
            otherCreatures[0].Quantity = 600;

            mockCreatureGenerator
                .SetupSequence(s => s.GenerateFor("my encounter"))
                .Returns(wrongCreatures)
                .Returns(otherCreatures)
                .Returns(creatures);

            mockEncounterVerifier.SetupSequence(d => d.EncounterIsValid(It.IsAny<Encounter>(), specifications.CreatureTypeFilters)).Returns(false).Returns(true);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Description, Is.EqualTo("my encounter"));
            Assert.That(encounter.Creatures, Is.EqualTo(otherCreatures));
        }
    }
}
