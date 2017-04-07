using CharacterGen.Characters;
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
        private Mock<IEncounterSelector> mockEncounterSelector;
        private Dictionary<string, string> creaturesAndAmounts;
        private List<string> requiresSubtype;
        private Mock<IEncounterVerifier> mockEncounterVerifier;
        private Mock<IEncounterCollectionSelector> mockCreatureCollectionSelector;
        private Treasure treasure;
        private int levelModifier;
        private int actualEncounterLevel;
        private EncounterSpecifications specifications;

        private int encounterLevel
        {
            get
            {
                return specifications.Level + levelModifier;
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
            mockEncounterSelector = new Mock<IEncounterSelector>();

            encounterGenerator = new EncounterGenerator(
                mockAmountSelector.Object,
                mockPercentileSelector.Object,
                mockCollectionSelector.Object,
                mockEncounterCharacterGenerator.Object,
                mockEncounterTreasureGenerator.Object,
                mockEncounterVerifier.Object,
                mockCreatureCollectionSelector.Object,
                mockEncounterSelector.Object);

            creaturesAndAmounts = new Dictionary<string, string>();
            requiresSubtype = new List<string>();
            specifications = new EncounterSpecifications();

            levelModifier = 1;
            specifications.Level = 10;
            specifications.Environment = "environment";
            specifications.Temperature = "temperature";
            specifications.TimeOfDay = "time of day";
            creaturesAndAmounts["creature"] = "creature amount";
            treasure = new Treasure();
            treasure.Coin.Quantity = 8765;
            actualEncounterLevel = 12;

            mockPercentileSelector.Setup(s => s.SelectFrom(TableNameConstants.EncounterLevelModifiers)).Returns(() => levelModifier);

            mockCreatureCollectionSelector.Setup(s => s.SelectRandomFrom(It.Is<EncounterSpecifications>(es => es.Level == encounterLevel))).Returns(creaturesAndAmounts);

            mockAmountSelector.Setup(d => d.SelectFrom(It.IsAny<string>())).Returns((string s) => ParseRoll(s));
            mockAmountSelector.Setup(d => d.SelectFrom("creature amount")).Returns(42);
            mockAmountSelector.Setup(d => d.SelectActualEncounterLevel(It.IsAny<Encounter>())).Returns(actualEncounterLevel);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype)).Returns(requiresSubtype);
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> c) => c.Last());

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, It.IsAny<string>())).Returns(new[] { "default challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "creature")).Returns(new[] { "challenge rating" });

            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(specifications)).Returns(true);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(It.Is<EncounterSpecifications>(es => es.Level == encounterLevel))).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.IsAny<Encounter>(), specifications.CreatureTypeFilters)).Returns(true);

            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.IsAny<Creature>(), It.IsAny<int>())).Returns(() => new Treasure());
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Type.Name == "creature"), actualEncounterLevel)).Returns(treasure);

            mockEncounterSelector.Setup(s => s.SelectNameFrom(It.IsAny<string>())).Returns((string s) => s);
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(It.IsAny<string>())).Returns(string.Empty);
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
            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.AverageDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(11));
            Assert.That(encounter.ActualDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(12));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.Description, Is.Empty);
            Assert.That(creature.Type.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
        }

        [Test]
        public void EncounterLevelMustBeValid()
        {
            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.EncounterLevelModifiers)).Returns(9999).Returns(levelModifier);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(It.Is<EncounterSpecifications>(s => s.Level == 10009))).Returns(false);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.AverageDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.AverageEncounterLevel, Is.EqualTo(11));
            Assert.That(encounter.ActualDifficulty, Is.EqualTo(DifficultyConstants.VeryDifficult));
            Assert.That(encounter.ActualEncounterLevel, Is.EqualTo(12));

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.Description, Is.Empty);
            Assert.That(creature.Type.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
        }

        [Test]
        public void IfCreatureHasCountOf0_ThenRemoveCreature()
        {
            creaturesAndAmounts["other creature"] = "other amount";

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockAmountSelector.Setup(d => d.SelectFrom("creature amount")).Returns(0);
            mockAmountSelector.Setup(d => d.SelectFrom("other amount")).Returns(69);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Type.Description, Is.Empty);
            Assert.That(creature.Type.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(69));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
        }

        [Test]
        public void IfCreatureHasCountLessThan0_ThenRemoveCreature()
        {
            creaturesAndAmounts["other creature"] = "other amount";

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockAmountSelector.Setup(d => d.SelectFrom("creature amount")).Returns(-42);
            mockAmountSelector.Setup(d => d.SelectFrom("other amount")).Returns(69);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Type.Description, Is.Empty);
            Assert.That(creature.Type.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(69));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
        }

        [Test]
        public void GenerateEncounterWithCharacters()
        {
            var characters = new[] { new Character(), new Character() };
            mockEncounterCharacterGenerator.Setup(g => g.GenerateFrom(It.IsAny<IEnumerable<Creature>>())).Returns(characters);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.Description, Is.Empty);
            Assert.That(creature.Type.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));

            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(characters, Is.SubsetOf(encounter.Characters));
            Assert.That(encounter.Characters.Count, Is.EqualTo(2));
        }

        [Test]
        public void GenerateEncounterWithDescription()
        {
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GenerateEncounterWithSetSubtype()
        {
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectSubtypeFrom(creaturesAndAmounts.First().Key)).Returns("subtype");

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.Empty);
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype"));
            Assert.That(creature.Type.SubType.Description, Is.Empty);
            Assert.That(creature.Type.SubType.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void EncounterWithRandomSubTypeShouldUseSetAmountAndSetChallengeRating()
        {
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("challenge rating");

            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, creaturesAndAmounts.First().Key)).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("specific challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void EncounterWithRandomSubTypeShouldPickNewSubtypeForEachInQuantity()
        {
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("challenge rating");

            requiresSubtype.Add("creature");

            var subtypes = new[] { "other creature", "random creature" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            var count = 0;
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(subtypes)).Returns((IEnumerable<string> c) => c.ElementAt(GetIndex(count++)));

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "random creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, creaturesAndAmounts.First().Key)).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Creatures.Count, Is.EqualTo(2));

            var first = encounter.Creatures.First();
            Assert.That(first.Type.Name, Is.EqualTo("creature"));
            Assert.That(first.Type.SubType.Name, Is.EqualTo("other creature"));
            Assert.That(first.Quantity, Is.EqualTo(21));
            Assert.That(first.ChallengeRating, Is.EqualTo("specific challenge rating"));

            var last = encounter.Creatures.Last();
            Assert.That(last.Type.Name, Is.EqualTo("creature"));
            Assert.That(last.Type.SubType.Name, Is.EqualTo("random creature"));
            Assert.That(last.Quantity, Is.EqualTo(21));
            Assert.That(last.ChallengeRating, Is.EqualTo("specific challenge rating"));
        }

        [Test]
        public void EncounterWithRandomSubTypeWithoutSetChallengeRatingThrowsException()
        {
            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });

            Assert.That(() => encounterGenerator.Generate(specifications), Throws.InvalidOperationException.With.Message.EqualTo("Cannot generate random subtype of creature without a set challenge rating"));
        }

        [Test]
        public void EncounterWithRandomSubTypeWithFurtherSubtypeShouldUseSetAmountAndSetChallengeRating()
        {
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("challenge rating");
            mockEncounterSelector.Setup(s => s.SelectSubtypeFrom("other creature")).Returns("subtype");

            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, creaturesAndAmounts.First().Key)).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("subtype"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("specific challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        //INFO: Example of this might be a dominated mephit
        [Test]
        public void EncounterWithRandomSubtypeHasFurtherRandomSubtype()
        {
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("challenge rating");
            mockEncounterSelector.Setup(s => s.SelectSubtypeFrom("other creature")).Returns("subtype");
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom("other creature")).Returns("other challenge rating");

            requiresSubtype.Add("creature");
            requiresSubtype.Add("other creature");

            var subSubtypes = new[] { "wrong subtype", "subtype" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "other creature")).Returns(subSubtypes);
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(new[] { "wrong creature", "other creature" });

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subSubtypes)).Returns(subSubtypes.First()).Returns(subSubtypes.Last());

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "subtype")).Returns(new[] { "other challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "wrong subtype")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, creaturesAndAmounts.First().Key)).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("subtype"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("specific challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        //INFO: Example of this might be a dominated mephit
        [Test]
        public void EncounterWithRandomSubtypeAndFurtherRandomSubtypeSelectsRandomEachTime()
        {
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("challenge rating");
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom("other creature")).Returns("other challenge rating");

            requiresSubtype.Add("creature");
            requiresSubtype.Add("other creature");

            var subtypes = new[] { "wrong creature", "random creature", "other creature" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            var subSubtypes = new[] { "wrong subtype", "other subtype", "subtype" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "other creature")).Returns(subSubtypes);

            var count = 0;
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> c) => c.ElementAt(GetIndex(count++)));

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "random creature")).Returns(new[] { "challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "subtype")).Returns(new[] { "other challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other subtype")).Returns(new[] { "other challenge rating" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "wrong subtype")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "wrong creature")).Returns(new[] { "wrong challenge rating" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, creaturesAndAmounts.First().Key)).Returns(new[] { "specific challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);
            Assert.That(encounter.Creatures.Count, Is.EqualTo(3));

            var creatures = encounter.Creatures.ToArray();
            Assert.That(creatures[0].Type.Name, Is.EqualTo("creature"));
            Assert.That(creatures[0].Type.SubType.Name, Is.EqualTo("random creature"));
            Assert.That(creatures[0].Quantity, Is.EqualTo(21));
            Assert.That(creatures[0].ChallengeRating, Is.EqualTo("specific challenge rating"));

            Assert.That(creatures[1].Type.Name, Is.EqualTo("creature"));
            Assert.That(creatures[1].Type.SubType.Name, Is.EqualTo("other creature"));
            Assert.That(creatures[1].Type.SubType.SubType.Name, Is.EqualTo("other subtype"));
            Assert.That(creatures[1].Quantity, Is.EqualTo(11));
            Assert.That(creatures[1].ChallengeRating, Is.EqualTo("specific challenge rating"));

            Assert.That(creatures[2].Type.Name, Is.EqualTo("creature"));
            Assert.That(creatures[2].Type.SubType.Name, Is.EqualTo("other creature"));
            Assert.That(creatures[2].Type.SubType.SubType.Name, Is.EqualTo("subtype"));
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
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType, Is.Null);
        }

        [Test]
        public void CleanUpRandomSubtype()
        {
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("creature challenge rating");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");

            requiresSubtype.Add(creaturesAndAmounts.First().Key);

            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature name")).Returns(new[] { "subtype" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "subtype")).Returns(new[] { "creature challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType, Is.Null);
        }

        [Test]
        public void CleanUpSetSubtype()
        {
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");
            mockEncounterSelector.Setup(s => s.SelectSubtypeFrom(creaturesAndAmounts.First().Key)).Returns("subtype");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType, Is.Null);
        }

        [Test]
        public void CleanUpRandomSubtypeWithFurtherRandomSubtype()
        {
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("creature challenge rating");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom("subtype")).Returns("subtype challenge rating");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("further subtype")).Returns("further subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("further subtype")).Returns("further subtype description");

            requiresSubtype.Add(creaturesAndAmounts.First().Key);
            requiresSubtype.Add("subtype");
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature name")).Returns(new[] { "subtype" });
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "subtype name")).Returns(new[] { "further subtype" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "further subtype")).Returns(new[] { "subtype challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "subtype")).Returns(new[] { "creature challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("further subtype name"));
            Assert.That(creature.Type.SubType.SubType.Description, Is.EqualTo("further subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType, Is.Null);
        }

        [Test]
        public void CleanUpRandomSubtypeWithFurtherSetSubtype()
        {
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("creature challenge rating");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");
            mockEncounterSelector.Setup(s => s.SelectSubtypeFrom("subtype")).Returns("further subtype");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("further subtype")).Returns("further subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("further subtype")).Returns("further subtype description");

            requiresSubtype.Add(creaturesAndAmounts.First().Key);
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature name")).Returns(new[] { "subtype" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "subtype")).Returns(new[] { "creature challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("further subtype name"));
            Assert.That(creature.Type.SubType.SubType.Description, Is.EqualTo("further subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType, Is.Null);
        }

        [Test, Ignore("While logical, partically in the game this does not have a real-world match, so will ignore until a genuine use case arises")]
        public void CleanUpSetSubtypeWithFurtherRandomSubtype()
        {
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");
            mockEncounterSelector.Setup(s => s.SelectSubtypeFrom(creaturesAndAmounts.First().Key)).Returns("subtype");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom("subtype")).Returns("subtype challenge rating");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("further subtype")).Returns("further subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("further subtype")).Returns("further subtype description");

            requiresSubtype.Add("subtype name");
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "subtype name")).Returns(new[] { "further subtype" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "further subtype")).Returns(new[] { "subtype challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("further subtype name"));
            Assert.That(creature.Type.SubType.SubType.Description, Is.EqualTo("further subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType, Is.Null);
        }

        [Test]
        public void CleanUpSetSubtypeWithFurtherSetSubtype()
        {
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");
            mockEncounterSelector.Setup(s => s.SelectSubtypeFrom(creaturesAndAmounts.First().Key)).Returns("subtype");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");
            mockEncounterSelector.Setup(s => s.SelectSubtypeFrom("subtype")).Returns("further subtype");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("further subtype")).Returns("further subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("further subtype")).Returns("further subtype description");

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("further subtype name"));
            Assert.That(creature.Type.SubType.SubType.Description, Is.EqualTo("further subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType, Is.Null);
        }

        [Test]
        public void DoNotGetRandomSubtypeIfSet()
        {
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");
            mockEncounterSelector.Setup(s => s.SelectSubtypeFrom(creaturesAndAmounts.First().Key)).Returns("subtype");
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("creature challenge rating");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");

            requiresSubtype.Add("creature");
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(new[] { "wrong subtype" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "wrong subtype")).Returns(new[] { "creature challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType, Is.Null);
        }

        //INFO: There is no current example of this in the system, but it is a good thing to test
        [Test]
        public void DeepRecursiveTypesAreOkay()
        {
            mockEncounterSelector.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("creature challenge rating");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");
            mockEncounterSelector.Setup(s => s.SelectChallengeRatingFrom("subtype")).Returns("subtype challenge rating");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("further subtype")).Returns("further subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("further subtype")).Returns("further subtype description");
            mockEncounterSelector.Setup(s => s.SelectSubtypeFrom("further subtype")).Returns("last subtype");
            mockEncounterSelector.Setup(s => s.SelectNameFrom("last subtype")).Returns("last subtype name");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom("last subtype")).Returns("last subtype description");

            requiresSubtype.Add(creaturesAndAmounts.First().Key);
            requiresSubtype.Add("subtype");
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature name")).Returns(new[] { "subtype" });
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "subtype name")).Returns(new[] { "further subtype" });

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "further subtype")).Returns(new[] { "subtype challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "subtype")).Returns(new[] { "creature challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("further subtype name"));
            Assert.That(creature.Type.SubType.SubType.Description, Is.EqualTo("further subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType.Name, Is.EqualTo("last subtype name"));
            Assert.That(creature.Type.SubType.SubType.SubType.Description, Is.EqualTo("last subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType.SubType, Is.Null);
        }

        [Test]
        public void IfCreatureHasSetMetarace_UseThatAsNameWhenCleaningUp()
        {
            mockEncounterSelector.Setup(s => s.SelectMetaraceFrom(creaturesAndAmounts.First().Key)).Returns("metarace");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("description");

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("metarace"));
            Assert.That(creature.Type.Description, Is.EqualTo("description"));
            Assert.That(creature.Type.SubType, Is.Null);
        }

        [Test]
        public void IfCreatureHasSetBaseRace_UseThatAsNameWhenCleaningUp()
        {
            mockEncounterSelector.Setup(s => s.SelectBaseRaceFrom(creaturesAndAmounts.First().Key)).Returns("base race");
            mockEncounterSelector.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("description");

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Characters, Is.Empty);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("base race"));
            Assert.That(creature.Type.Description, Is.EqualTo("description"));
            Assert.That(creature.Type.SubType, Is.Null);
        }

        [Test]
        public void RerollEncounter()
        {
            mockAmountSelector.SetupSequence(d => d.SelectFrom("creature amount")).Returns(666).Returns(600);

            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Single().Quantity == 600), specifications.CreatureTypeFilters)).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Single().Quantity == 666), specifications.CreatureTypeFilters)).Returns(false);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
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

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(It.Is<EncounterSpecifications>(es => es.Level == encounterLevel)))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(creaturesAndAmounts);

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockAmountSelector.Setup(d => d.SelectFrom("wrong creature amount")).Returns(666);

            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Type.Name == "other creature")), specifications.CreatureTypeFilters)).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Type.Name == "wrong creature")), specifications.CreatureTypeFilters)).Returns(false);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GetEncounterWithMultipleTypesOfCreatures()
        {
            creaturesAndAmounts["other creature"] = "other creature amount";
            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single(c => c.Type.Name == "creature");
            var otherCreature = encounter.Creatures.Single(c => c.Type.Name == "other creature");
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
            var encounter = encounterGenerator.Generate(specifications);
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
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Type.Name == "other creature"), actualEncounterLevel)).Returns(otherTreasure);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasures, Contains.Item(treasure));
            Assert.That(encounter.Treasures, Contains.Item(otherTreasure));
            Assert.That(encounter.Treasures.Count, Is.EqualTo(2));
        }

        [Test]
        public void DoNotGetOnlyEmptyTreasure()
        {
            treasure.Coin.Quantity = 0;

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasures, Is.Empty);
        }

        [Test]
        public void DoNotGetEmptyTreasure()
        {
            creaturesAndAmounts["other creature"] = "other creature amount";

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasures.Single, Is.EqualTo(treasure));
        }

        [Test]
        public void FilterCreatureTypes()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(It.Is<EncounterSpecifications>(es => es.Level == encounterLevel)))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(creaturesAndAmounts);

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockAmountSelector.Setup(d => d.SelectFrom("wrong creature amount")).Returns(666);

            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Type.Name == "other creature")), specifications.CreatureTypeFilters)).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Type.Name == "wrong creature")), specifications.CreatureTypeFilters)).Returns(false);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void UseMultipleFiltersForCreatureTypes()
        {
            specifications.CreatureTypeFilters = new[] { "filter 1", "filter 2" };

            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(It.Is<EncounterSpecifications>(es => es.Level == encounterLevel)))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(creaturesAndAmounts);

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockAmountSelector.Setup(d => d.SelectFrom("wrong creature amount")).Returns(666);

            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Type.Name == "other creature")), specifications.CreatureTypeFilters)).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Type.Name == "wrong creature")), specifications.CreatureTypeFilters)).Returns(false);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RerollEncounterLevelIfEncounterMustBeRerolledForFilter()
        {
            specifications.CreatureTypeFilters = new[] { "filter" };

            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            mockPercentileSelector.SetupSequence(s => s.SelectFrom(TableNameConstants.EncounterLevelModifiers))
                .Returns(-4)
                .Returns(4);

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(It.Is<EncounterSpecifications>(es => es.Level == specifications.Level + 4))).Returns(otherTypeAndAmount);
            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(It.Is<EncounterSpecifications>(es => es.Level == specifications.Level - 4))).Returns(wrongTypeAndAmount);

            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(It.Is<EncounterSpecifications>(es => es.Level == specifications.Level + 4))).Returns(true);
            mockEncounterVerifier.Setup(v => v.ValidEncounterExistsAtLevel(It.Is<EncounterSpecifications>(es => es.Level == specifications.Level - 4))).Returns(false);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockAmountSelector.Setup(d => d.SelectFrom("wrong creature amount")).Returns(666);

            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Type.Name == "other creature")), specifications.CreatureTypeFilters)).Returns(true);
            mockEncounterVerifier.Setup(v => v.EncounterIsValid(It.Is<Encounter>(e => e.Creatures.Any(c => c.Type.Name == "wrong creature")), specifications.CreatureTypeFilters)).Returns(false);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("other creature"));
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

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectRandomFrom(It.Is<EncounterSpecifications>(es => es.Level == encounterLevel)))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(creaturesAndAmounts);

            mockAmountSelector.Setup(d => d.SelectFrom("other creature amount")).Returns(600);
            mockAmountSelector.Setup(d => d.SelectFrom("wrong creature amount")).Returns(666);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.AverageChallengeRatings, "other creature")).Returns(new[] { "other challenge rating" });

            mockEncounterVerifier.SetupSequence(d => d.EncounterIsValid(It.IsAny<Encounter>(), specifications.CreatureTypeFilters)).Returns(false).Returns(true);

            var encounter = encounterGenerator.Generate(specifications);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
            Assert.That(encounter.Characters, Is.Empty);
        }
    }
}
