using CharacterGen;
using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterGeneratorTests
    {
        private IEncounterGenerator encounterGenerator;
        private Mock<IAmountSelector> mockAmountSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<IEncounterCharacterGenerator> mockEncounterCharacterGenerator;
        private Mock<IEncounterTreasureGenerator> mockEncounterTreasureGenerator;
        private Dictionary<string, string> creaturesAndAmounts;
        private int level;
        private string environment;
        private string temperature;
        private string timeOfDay;
        private List<string> requiresSubtype;
        private Mock<IEncounterVerifier> mockEncounterVerifier;
        private Mock<IEncounterCollectionSelector> mockCreatureCollectionSelector;
        private Treasure treasure;
        private int levelModifier;
        private int actualEncounterLevel;

        private int encounterLevel
        {
            get
            {
                return level + levelModifier;
            }
        }

        [SetUp]
        public void Setup()
        {
            mockAmountSelector = new Mock<IAmountSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockEncounterCharacterGenerator = new Mock<IEncounterCharacterGenerator>();
            mockEncounterTreasureGenerator = new Mock<IEncounterTreasureGenerator>();
            mockEncounterVerifier = new Mock<IEncounterVerifier>();
            mockCreatureCollectionSelector = new Mock<IEncounterCollectionSelector>();

            encounterGenerator = new EncounterGenerator(mockAmountSelector.Object, mockPercentileSelector.Object, mockCollectionSelector.Object,
                mockEncounterCharacterGenerator.Object, mockEncounterTreasureGenerator.Object, mockEncounterVerifier.Object, mockCreatureCollectionSelector.Object);

            creaturesAndAmounts = new Dictionary<string, string>();
            requiresSubtype = new List<string>();

            level = 10;
            levelModifier = 1;
            environment = "environment";
            temperature = "temperature";
            timeOfDay = "time of day";
            creaturesAndAmounts["creature"] = "creature amount";
            treasure = new Treasure();
            treasure.Coin.Quantity = 8765;
            actualEncounterLevel = 12;

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterLevelModifiers)).Returns(() => levelModifier);

            mockCreatureCollectionSelector.Setup(s => s.SelectRandomFrom(encounterLevel, environment, temperature, timeOfDay)).Returns(creaturesAndAmounts);
            mockCreatureCollectionSelector.Setup(s => s.SelectAllWeightedFrom(level, environment, temperature, timeOfDay)).Returns(new[] { creaturesAndAmounts });

            mockAmountSelector.Setup(d => d.SelectFrom(It.IsAny<string>())).Returns((string s) => ParseRoll(s));
            mockAmountSelector.Setup(d => d.SelectFrom("creature amount")).Returns(42);
            mockAmountSelector.Setup(d => d.SelectEncounterLevel(It.IsAny<IEnumerable<Creature>>())).Returns(actualEncounterLevel);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype)).Returns(requiresSubtype);
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> c) => c.Last());

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, It.IsAny<string>())).Returns(new[] { "default challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature")).Returns(new[] { "challenge rating" });

            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(environment, It.IsAny<int>(), temperature, timeOfDay, It.IsAny<string[]>())).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.IsAny<IEnumerable<Creature>>(), It.IsAny<string[]>())).Returns(true);
            mockEncounterVerifier.SetupGet(v => v.MaximumLevel).Returns(30);
            mockEncounterVerifier.SetupGet(v => v.MinimumLevel).Returns(1);

            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.IsAny<Creature>(), It.IsAny<int>())).Returns(() => new Treasure());
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Name == "creature"), actualEncounterLevel)).Returns(treasure);
        }

        private int ParseRoll(string roll)
        {
            var value = 0;
            if (int.TryParse(roll, out value))
                return value;

            throw new ArgumentException("This roll was not set up to be parsed: " + roll);
        }

        [Test]
        public void GenerateEncounter()
        {
            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.AverageDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(11));
            Assert.That(encounter.ActualDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(12));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
        }

        [TestCase(-9999, DifficultyConstants.VeryEasy)]
        [TestCase(-5, DifficultyConstants.VeryEasy)]
        [TestCase(-4, DifficultyConstants.Easy)]
        [TestCase(-3, DifficultyConstants.Easy)]
        [TestCase(-2, DifficultyConstants.Easy)]
        [TestCase(-1, DifficultyConstants.Easy)]
        [TestCase(0, DifficultyConstants.Challenging)]
        [TestCase(1, DifficultyConstants.VeryDifficult)]
        [TestCase(2, DifficultyConstants.VeryDifficult)]
        [TestCase(3, DifficultyConstants.VeryDifficult)]
        [TestCase(4, DifficultyConstants.VeryDifficult)]
        [TestCase(5, DifficultyConstants.Overpowering)]
        [TestCase(9999, DifficultyConstants.Overpowering)]
        public void GenerateAverageEncounterDifficulty(int newLevelModifier, string difficulty)
        {
            levelModifier = newLevelModifier;
            mockCreatureCollectionSelector.Setup(s => s.SelectRandomFrom(encounterLevel, environment, temperature, timeOfDay)).Returns(creaturesAndAmounts);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.AverageDifficulty, Is.EqualTo(difficulty));
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(level + newLevelModifier));
        }

        [TestCase(-9999, DifficultyConstants.VeryEasy)]
        [TestCase(-5, DifficultyConstants.VeryEasy)]
        [TestCase(-4, DifficultyConstants.Easy)]
        [TestCase(-3, DifficultyConstants.Easy)]
        [TestCase(-2, DifficultyConstants.Easy)]
        [TestCase(-1, DifficultyConstants.Easy)]
        [TestCase(0, DifficultyConstants.Challenging)]
        [TestCase(1, DifficultyConstants.VeryDifficult)]
        [TestCase(2, DifficultyConstants.VeryDifficult)]
        [TestCase(3, DifficultyConstants.VeryDifficult)]
        [TestCase(4, DifficultyConstants.VeryDifficult)]
        [TestCase(5, DifficultyConstants.Overpowering)]
        [TestCase(9999, DifficultyConstants.Overpowering)]
        public void GenerateActualEncounterDifficulty(int actualLevelModifier, string difficulty)
        {
            var actualLevel = level + actualLevelModifier;
            mockAmountSelector.Setup(d => d.SelectEncounterLevel(It.IsAny<IEnumerable<Creature>>())).Returns(actualLevel);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.ActualDifficulty, Is.EqualTo(difficulty));
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(actualLevel));
        }

        [Test]
        public void EncounterLevelCannotBeLessThan1()
        {
            levelModifier = -9999;
            mockCreatureCollectionSelector.Setup(s => s.SelectRandomFrom(1, environment, temperature, timeOfDay)).Returns(creaturesAndAmounts);

            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.EncounterLevelModifiers)).Returns(-9999).Returns(-9);
            mockAmountSelector.Setup(d => d.SelectEncounterLevel(It.IsAny<IEnumerable<Creature>>())).Returns(1);

            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Name == "creature"), 1)).Returns(treasure);
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Name != "creature"), 1)).Returns(() => new Treasure());

            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(environment, -9989, temperature, timeOfDay)).Returns(false);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.AverageDifficulty, Is.EqualTo(DifficultyConstants.VeryEasy));
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(1));
            Assert.That(encounter.ActualDifficulty, Is.EqualTo(DifficultyConstants.VeryEasy));
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(1));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
            mockCreatureCollectionSelector.Verify(s => s.SelectRandomFrom(1, environment, temperature, timeOfDay), Times.Once);
        }

        [Test]
        public void EncounterLevelCanBeMoreThan20()
        {
            levelModifier = 12;
            mockCreatureCollectionSelector.Setup(s => s.SelectRandomFrom(22, environment, temperature, timeOfDay)).Returns(creaturesAndAmounts);

            mockAmountSelector.Setup(d => d.SelectEncounterLevel(It.IsAny<IEnumerable<Creature>>())).Returns(23);

            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Name == "creature"), 23)).Returns(treasure);
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Name != "creature"), 23)).Returns(() => new Treasure());

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(22));
            Assert.That(encounter.AverageDifficulty, Is.EqualTo(DifficultyConstants.Overpowering));
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(23));
            Assert.That(encounter.ActualDifficulty, Is.EqualTo(DifficultyConstants.Overpowering));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
            mockCreatureCollectionSelector.Verify(s => s.SelectRandomFrom(22, environment, temperature, timeOfDay), Times.Once);
        }

        [Test]
        public void EncounterLevelMustBeValid()
        {
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.EncounterLevelModifiers)).Returns(9999).Returns(levelModifier);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(environment, 10009, temperature, timeOfDay)).Returns(false);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.AverageDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(11));
            Assert.That(encounter.ActualDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(12));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
        }

        [Test]
        public void IfCreatureHasCountOf0_ThenRemoveCreature()
        {
            creaturesAndAmounts["other creature"] = "other amount";

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockAmountSelector.Setup(d => d.SelectFrom("creature amount")).Returns(0);
            mockAmountSelector.Setup(d => d.SelectFrom("other amount")).Returns(69);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(69));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
        }

        [Test]
        public void IfCreatureHasCountLessThan0_ThenRemoveCreature()
        {
            creaturesAndAmounts["other creature"] = "other amount";

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockAmountSelector.Setup(d => d.SelectFrom("creature amount")).Returns(-42);
            mockAmountSelector.Setup(d => d.SelectFrom("other amount")).Returns(69);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(69));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
        }

        [Test]
        public void GenerateEncounterWithCharacters()
        {
            var characters = new[] { new Character(), new Character() };
            mockEncounterCharacterGenerator.Setup(g => g.GenerateFrom(It.IsAny<IEnumerable<Creature>>())).Returns(characters);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));

            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(characters, Is.SubsetOf(encounter.Characters));
            Assert.That(encounter.Characters.Count, Is.EqualTo(2));
        }

        [Test]
        public void GenerateEncounterWithDescription()
        {
            creaturesAndAmounts.Clear();
            creaturesAndAmounts["creature (subtype)"] = "creature amount";

            requiresSubtype.Add("creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature"))
                .Returns(new[] { "wrong creature", "other creature" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature (subtype)")).Returns(new[] { "subtype challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("subtype"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("subtype challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void EncounterWithRandomSubTypeShouldUseSetAmountAndSetChallengeRating()
        {
            creaturesAndAmounts.Clear();
            creaturesAndAmounts["creature[challenge rating]"] = "creature amount";
            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature[challenge rating]")).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("specific challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void EncounterWithRandomSubTypeShouldPickNewSubtypeForEachInQuantity()
        {
            creaturesAndAmounts.Clear();
            creaturesAndAmounts["creature[challenge rating]"] = "creature amount";
            requiresSubtype.Add("creature");

            var subtypes = new[] { "other creature", "random creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            var count = 0;
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(subtypes)).Returns(() => subtypes.ElementAt(count++ % 2));

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "random creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature[challenge rating]")).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Creatures.Count, Is.EqualTo(2));

            var first = encounter.Creatures.First();
            Assert.That(first.Name, Is.EqualTo("creature"));
            Assert.That(first.Description, Is.EqualTo("other creature"));
            Assert.That(first.Quantity, Is.EqualTo(21));
            Assert.That(first.ChallengeRating, Is.EqualTo("specific challenge rating"));

            var last = encounter.Creatures.Last();
            Assert.That(last.Name, Is.EqualTo("creature"));
            Assert.That(last.Description, Is.EqualTo("random creature"));
            Assert.That(last.Quantity, Is.EqualTo(21));
            Assert.That(last.ChallengeRating, Is.EqualTo("specific challenge rating"));
        }

        [Test]
        public void EncounterWithRandomSubTypeWithoutSetChallengeRatingThrowsException()
        {
            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });

            Assert.That(() => encounterGenerator.Generate(environment, level, temperature, timeOfDay), Throws.InvalidOperationException.With.Message.EqualTo("Cannot generate random subtype of creature without a set challenge rating"));
        }

        [Test]
        public void EncounterWithRandomSubTypeWithFurtherSubtypeShouldUseSetAmountAndSetChallengeRating()
        {
            creaturesAndAmounts.Clear();
            creaturesAndAmounts["creature[challenge rating]"] = "creature amount";

            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature (subtype)" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature (subtype)")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature[challenge rating]")).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("other creature (subtype)"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("specific challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        //INFO: Example of this might be a dominated mephit
        [Test]
        public void EncounterWithRandomSubtypeHasFurtherRandomSubtype()
        {
            creaturesAndAmounts.Clear();
            creaturesAndAmounts["creature[challenge rating]"] = "creature amount";

            requiresSubtype.Add("creature");
            requiresSubtype.Add("other creature");

            var subSubtypes = new[] { "wrong subtype", "subtype" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "other creature")).Returns(subSubtypes);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(new[] { "wrong creature", "other creature" });

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subSubtypes)).Returns(subSubtypes.First()).Returns(subSubtypes.Last());

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "subtype")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "wrong subtype")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature[challenge rating]")).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("other creature (subtype)"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("specific challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        //INFO: Example of this might be a dominated mephit
        [Test]
        public void EncounterWithRandomSubtypeAndFurtherRandomSubtypeSelectsRandomEachTime()
        {
            creaturesAndAmounts.Clear();
            creaturesAndAmounts["creature[challenge rating]"] = "creature amount";

            requiresSubtype.Add("creature");
            requiresSubtype.Add("other creature");

            var subtypes = new[] { "wrong creature", "random creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            var subSubtypes = new[] { "wrong subtype", "other subtype", "subtype" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "other creature")).Returns(subSubtypes);

            var count = 0;
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> c) => c.ElementAt(GetIndex(count++)));

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "random creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "subtype")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other subtype")).Returns(new[] { "challenge rating" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "wrong subtype")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature[challenge rating]")).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Creatures.Count, Is.EqualTo(3));

            var creatures = encounter.Creatures.ToArray();
            Assert.That(creatures[0].Name, Is.EqualTo("creature"));
            Assert.That(creatures[0].Description, Is.EqualTo("random creature"));
            Assert.That(creatures[0].Quantity, Is.EqualTo(21));
            Assert.That(creatures[0].ChallengeRating, Is.EqualTo("specific challenge rating"));

            Assert.That(creatures[1].Name, Is.EqualTo("creature"));
            Assert.That(creatures[1].Description, Is.EqualTo("other creature (other subtype)"));
            Assert.That(creatures[1].Quantity, Is.EqualTo(11));
            Assert.That(creatures[1].ChallengeRating, Is.EqualTo("specific challenge rating"));

            Assert.That(creatures[2].Name, Is.EqualTo("creature"));
            Assert.That(creatures[2].Description, Is.EqualTo("other creature (subtype)"));
            Assert.That(creatures[2].Quantity, Is.EqualTo(10));
            Assert.That(creatures[2].ChallengeRating, Is.EqualTo("specific challenge rating"));
        }

        private int GetIndex(int count)
        {
            switch (count % 6)
            {
                case 0: return 0;
                case 1: return 1;
                case 2: return 0;
                case 3: return 0;
                case 4: return 1;
                case 5: return 1;
                default: return 0;
            }
        }

        [Test]
        public void CleanUpName()
        {
            creaturesAndAmounts.Clear();
            creaturesAndAmounts["creature (description)[challenge rating]"] = "creature amount";

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("description"));
        }

        [Test]
        public void CleanUpDescription()
        {
            creaturesAndAmounts.Clear();
            creaturesAndAmounts["creature[challenge rating]"] = "creature amount";

            requiresSubtype.Add("creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(new[] { "subtype (description)[subtype challenge rating]" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "subtype (description)[subtype challenge rating]")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature[challenge rating]")).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("subtype (description)"));
        }

        [Test]
        public void CleanUpDescriptionWithSubDescription()
        {
            creaturesAndAmounts.Clear();
            creaturesAndAmounts["creature[challenge rating]"] = "creature amount";

            requiresSubtype.Add("creature");
            requiresSubtype.Add("subtype");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(new[] { "subtype[subtype challenge rating]" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "subtype")).Returns(new[] { "further subtype (description)[further subtype challenge rating]" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "subtype[subtype challenge rating]")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "further subtype (description)[further subtype challenge rating]")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature[challenge rating]")).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("subtype (further subtype (description))"));
        }

        [Test]
        public void RerollEncounter()
        {
            mockAmountSelector.SetupSequence(d => d.SelectFrom("creature amount")).Returns(666).Returns(600);

            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<IEnumerable<Creature>>(cc => cc.Single().Quantity == 600))).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<IEnumerable<Creature>>(cc => cc.Single().Quantity == 666))).Returns(false);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
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

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(encounterLevel, environment, temperature, timeOfDay))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(creaturesAndAmounts);

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockAmountSelector.Setup(d => d.SelectFrom("wrong creature amount")).Returns(666);

            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<IEnumerable<Creature>>(cc => cc.Any(c => c.Name == "other creature")))).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<IEnumerable<Creature>>(cc => cc.Any(c => c.Name == "wrong creature")))).Returns(false);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GetEncounterWithMultipleTypesOfCreatures()
        {
            creaturesAndAmounts["other creature"] = "other creature amount";
            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single(c => c.Name == "creature");
            var otherCreature = encounter.Creatures.Single(c => c.Name == "other creature");
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
            Assert.That(otherCreature.Quantity, Is.EqualTo(600));
            Assert.That(otherCreature.ChallengeRating, Is.EqualTo("other challenge rating"));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(2));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GetTreasure()
        {
            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasures.Single, Is.EqualTo(treasure));
        }

        [Test]
        public void GetTreasureForAllCreatures()
        {
            creaturesAndAmounts["other creature"] = "other creature amount";
            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);

            var otherTreasure = new Treasure();
            otherTreasure.Coin.Quantity = 1337;
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Name == "other creature"), actualEncounterLevel)).Returns(otherTreasure);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasures, Contains.Item(treasure));
            Assert.That(encounter.Treasures, Contains.Item(otherTreasure));
            Assert.That(encounter.Treasures.Count, Is.EqualTo(2));
        }

        [Test]
        public void DoNotGetOnlyEmptyTreasure()
        {
            treasure.Coin.Quantity = 0;

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasures, Is.Empty);
        }

        [Test]
        public void DoNotGetEmptyTreasure()
        {
            creaturesAndAmounts["other creature"] = "other creature amount";

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasures.Single, Is.EqualTo(treasure));
        }

        [Test]
        public void GetTreasureForCreatureWithDescription()
        {
            var monster = creaturesAndAmounts.First();
            creaturesAndAmounts.Clear();

            creaturesAndAmounts[monster.Key + " (description)"] = monster.Value;

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature (description)")).Returns(new[] { "descriptive challenge rating" });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasures.Single(), Is.EqualTo(treasure));
        }

        [Test]
        public void GetTreasureForCreatureWithCharacterLevel()
        {
            var monster = creaturesAndAmounts.First();
            creaturesAndAmounts.Clear();

            creaturesAndAmounts[monster.Key + "[1]"] = monster.Value;

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature[1]")).Returns(new[] { "specific challenge rating" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character))
                .Returns(new[] { "other character class", monster.Key });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasures.Single(), Is.EqualTo(treasure));
        }

        [Test]
        public void GetTreasureForCreatureWithDescriptionAndCharacterLevel()
        {
            var monster = creaturesAndAmounts.First();
            creaturesAndAmounts.Clear();

            creaturesAndAmounts[monster.Key + " (description)[1]"] = monster.Value;

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "creature (description)[1]")).Returns(new[] { "specific challenge rating" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character))
                .Returns(new[] { "other character class", monster.Key });

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasures.Single(), Is.EqualTo(treasure));
        }

        [Test]
        public void FilterCreatureTypes()
        {
            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(environment, level, temperature, timeOfDay, "filter")).Returns(true);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(environment, encounterLevel, temperature, timeOfDay, "filter")).Returns(true);

            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(encounterLevel, environment, temperature, timeOfDay, "filter"))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(creaturesAndAmounts);

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockAmountSelector.Setup(d => d.SelectFrom("wrong creature amount")).Returns(666);

            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<IEnumerable<Creature>>(cc => cc.Any(c => c.Name == "other creature")), "filter")).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<IEnumerable<Creature>>(cc => cc.Any(c => c.Name == "wrong creature")), "filter")).Returns(false);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay, "filter");
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void UseMultipleFiltersForCreatureTypes()
        {
            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(environment, level, temperature, timeOfDay, "filter 1", "filter 2")).Returns(true);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(environment, encounterLevel, temperature, timeOfDay, "filter 1", "filter 2")).Returns(true);

            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(encounterLevel, environment, temperature, timeOfDay, "filter 1", "filter 2"))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(creaturesAndAmounts);

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockAmountSelector.Setup(d => d.SelectFrom("wrong creature amount")).Returns(666);

            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<IEnumerable<Creature>>(cc => cc.Any(c => c.Name == "other creature")), "filter 1", "filter 2")).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<IEnumerable<Creature>>(cc => cc.Any(c => c.Name == "wrong creature")), "filter 1", "filter 2")).Returns(false);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay, "filter 1", "filter 2");
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RerollEffectiveLevelIfEncounterMustBeRerolledForFilter()
        {
            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.EncounterLevelModifiers))
                .Returns(-4)
                .Returns(4);

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(level + 4, environment, temperature, timeOfDay, "filter")).Returns(otherTypeAndAmount);
            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(level - 4, environment, temperature, timeOfDay, "filter")).Returns(wrongTypeAndAmount);

            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(environment, level, temperature, timeOfDay, "filter")).Returns(true);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(environment, level + 4, temperature, timeOfDay, "filter")).Returns(true);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(environment, level - 4, temperature, timeOfDay, "filter")).Returns(false);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockAmountSelector.Setup(d => d.SelectFrom("wrong creature amount")).Returns(666);

            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<IEnumerable<Creature>>(cc => cc.Any(c => c.Name == "other creature")), "filter")).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<IEnumerable<Creature>>(cc => cc.Any(c => c.Name == "wrong creature")), "filter")).Returns(false);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay, "filter");
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RegenerateEncounterIfEncounterActualCreaturesAndAmountsAreInvalid()
        {
            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(encounterLevel, environment, temperature, timeOfDay))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(creaturesAndAmounts);

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockAmountSelector.Setup(d => d.SelectFrom("wrong creature amount")).Returns(666);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.ChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockEncounterVerifier.SetupSequence(d => d.EncounterIsValid(It.IsAny<IEnumerable<Creature>>())).Returns(false).Returns(true);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }
    }
}
