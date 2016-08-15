using CharacterGen;
using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using Moq;
using NUnit.Framework;
using RollGen;
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
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<IRollSelector> mockRollSelector;
        private Mock<IPercentileSelector> mockPercentileSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<Dice> mockDice;
        private Mock<IEncounterCharacterGenerator> mockEncounterCharacterGenerator;
        private Mock<IEncounterTreasureGenerator> mockEncounterTreasureGenerator;
        private Dictionary<string, string> encounterTypeAndAmount;
        private Dictionary<string, string> encounterLevelAndModifier;
        private int level;
        private string environment;
        private string temperature;
        private string timeOfDay;
        private List<string> requiresSubtype;
        private Mock<IFilterVerifier> mockFilterVerifier;
        private Mock<IEncounterCollectionSelector> mockCreatureCollectionSelector;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockRollSelector = new Mock<IRollSelector>();
            mockPercentileSelector = new Mock<IPercentileSelector>();
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockDice = new Mock<Dice>();
            mockEncounterCharacterGenerator = new Mock<IEncounterCharacterGenerator>();
            mockEncounterTreasureGenerator = new Mock<IEncounterTreasureGenerator>();
            mockFilterVerifier = new Mock<IFilterVerifier>();
            mockCreatureCollectionSelector = new Mock<IEncounterCollectionSelector>();

            encounterGenerator = new EncounterGenerator(mockTypeAndAmountPercentileSelector.Object, mockRollSelector.Object, mockPercentileSelector.Object, mockCollectionSelector.Object,
                mockDice.Object, mockEncounterCharacterGenerator.Object, mockEncounterTreasureGenerator.Object, mockFilterVerifier.Object, mockCreatureCollectionSelector.Object);

            encounterLevelAndModifier = new Dictionary<string, string>();
            encounterTypeAndAmount = new Dictionary<string, string>();
            requiresSubtype = new List<string>();

            level = 9266;
            environment = "environment";
            temperature = "temperature";
            timeOfDay = "time of day";
            encounterLevelAndModifier["90210"] = "9876";
            encounterTypeAndAmount["creature"] = "creature amount";

            var tableName = string.Format(TableNameConstants.LevelXEncounterLevel, level);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns(encounterLevelAndModifier);

            mockCreatureCollectionSelector.Setup(s => s.SelectFrom(90210, environment, temperature, timeOfDay)).Returns(encounterTypeAndAmount);
            mockCreatureCollectionSelector.Setup(s => s.SelectAllFrom(level, environment, temperature, timeOfDay)).Returns(new[] { encounterTypeAndAmount });

            mockRollSelector.Setup(s => s.SelectFrom("creature amount", 9876)).Returns("effective roll");
            mockDice.Setup(d => d.Roll(It.IsAny<string>())).Returns((string s) => ParseRoll(s));
            mockDice.Setup(d => d.Roll("effective roll")).Returns(42);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype)).Returns(requiresSubtype);
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> c) => c.Last());

            mockFilterVerifier.Setup(v => v.FiltersAreValid(environment, level, temperature, timeOfDay)).Returns(true);
            mockFilterVerifier.Setup(v => v.EncounterIsValid(It.IsAny<Dictionary<string, string>>(), It.IsAny<int>())).Returns(true);
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

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(encounter.Characters, Is.Empty);
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

            Assert.That(encounter.Characters, Is.All.Not.Null);
            Assert.That(characters, Is.SubsetOf(encounter.Characters));
            Assert.That(encounter.Characters.Count, Is.EqualTo(2));
        }

        [Test]
        public void GenerateEncounterWithDragons()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[CreatureConstants.Dragon] = "dragon amount";
            mockRollSelector.Setup(s => s.SelectFrom("dragon amount", 9876)).Returns("dragon effective roll");
            mockDice.Setup(d => d.Roll("dragon effective roll")).Returns(600);

            var tableName = string.Format(TableNameConstants.LevelXDragons, 90210);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("dragon type and age");

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo(CreatureConstants.Dragon));
            Assert.That(creature.Description, Is.EqualTo("dragon type and age"));
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
            mockRollSelector.Setup(s => s.SelectFrom(level, "other challenge rating")).Returns("other roll");
            mockDice.Setup(d => d.Roll("other roll")).Returns(600);

            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns("wrong roll");
            mockDice.Setup(d => d.Roll("wrong roll")).Returns(1337);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GenerateEncounterWithRandomSubTypeWithFurtherSubtype()
        {
            requiresSubtype.Add("creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature"))
                .Returns(new[] { "wrong creature", "other creature (further subtype)" });

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "other creature (further subtype)")).Returns(new[] { "other challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "other challenge rating")).Returns("other roll");
            mockDice.Setup(d => d.Roll("other roll")).Returns(600);

            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns("wrong roll");
            mockDice.Setup(d => d.Roll("wrong roll")).Returns(1337);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("other creature (further subtype)"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SpecificTestCase_DominatedCelestialCreature()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[$"{CreatureConstants.DominatedCreature}[4]"] = "creature amount";

            requiresSubtype.Add(CreatureConstants.DominatedCreature);
            requiresSubtype.Add(CreatureConstants.CelestialCreature);

            var subSubtypes = new[] { "wrong subtype", CreatureConstants.Bear_Black };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.CelestialCreature))
                .Returns(subSubtypes);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.DominatedCreature))
                .Returns(new[] { "wrong creature", CreatureConstants.CelestialCreature });

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subSubtypes)).Returns(subSubtypes.First()).Returns(subSubtypes.Last());

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, CreatureConstants.DominatedCreature);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, CreatureConstants.CelestialCreature)).Returns(new[] { "other challenge rating" });

            tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, CreatureConstants.CelestialCreature);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, CreatureConstants.Bear_Black)).Returns(new[] { "4" });
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong subtype")).Returns(new[] { "3" });

            mockRollSelector.Setup(s => s.SelectFrom(level, "4")).Returns("roll");
            mockDice.Setup(d => d.Roll("roll")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns("wrong roll");
            mockDice.Setup(d => d.Roll("wrong roll")).Returns(1337);

            mockRollSelector.Setup(s => s.SelectFrom("creature amount", 9876)).Returns("creature effective roll");
            mockDice.Setup(d => d.Roll("creature effective roll")).Returns(7654);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo(CreatureConstants.DominatedCreature));
            Assert.That(creature.Description, Is.EqualTo($"{CreatureConstants.CelestialCreature} ({CreatureConstants.Bear_Black})"));
            Assert.That(creature.Quantity, Is.EqualTo(7654));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SpecificTestCase_ZombieHydra()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount[CreatureConstants.Zombie] = "creature amount";

            requiresSubtype.Add(CreatureConstants.Zombie);

            var subtypes = new[] { "wrong creature", CreatureConstants.Hydra_10Heads };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Zombie))
                .Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, CreatureConstants.Zombie);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, CreatureConstants.Hydra_10Heads)).Returns(new[] { "challenge rating" });

            mockRollSelector.Setup(s => s.SelectFrom(level, "challenge rating")).Returns("roll");
            mockDice.Setup(d => d.Roll("roll")).Returns(600);

            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns(RollConstants.Reroll);
            mockDice.Setup(d => d.Roll("wrong roll")).Returns(1337);

            mockRollSelector.Setup(s => s.SelectFrom("creature amount", 9876)).Returns("creature effective roll");
            mockDice.Setup(d => d.Roll("creature effective roll")).Returns(7654);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo(CreatureConstants.Zombie));
            Assert.That(creature.Description, Is.EqualTo(CreatureConstants.Hydra_10Heads));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GenerateEncounterWithSetSubType()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["creature (subtype)"] = "creature amount";
            mockRollSelector.Setup(s => s.SelectFrom("creature amount", 9876)).Returns("creature effective roll");
            mockDice.Setup(d => d.Roll("creature effective roll")).Returns(600);

            requiresSubtype.Add("creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature"))
                .Returns(new[] { "wrong creature", "other creature" });

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "other creature")).Returns(new[] { "other challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "other challenge rating")).Returns("other roll");
            mockRollSelector.Setup(s => s.SelectFrom("other roll", 9876)).Returns("other effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(1234);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns("wrong roll");
            mockRollSelector.Setup(s => s.SelectFrom("wrong roll", 9876)).Returns("wrong effective roll");
            mockDice.Setup(d => d.Roll("wrong effective roll")).Returns(1337);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("subtype"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GenerateRandomSubtypeOfSetChallengeRating()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["creature[challenge rating]"] = "creature amount";
            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "other creature")).Returns(new[] { "challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "challenge rating")).Returns("roll");
            mockDice.Setup(d => d.Roll("roll")).Returns(7654);

            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns(RollConstants.Reroll);
            mockDice.Setup(d => d.Roll(RollConstants.Reroll)).Returns(1337);

            mockRollSelector.Setup(s => s.SelectFrom("creature amount", 9876)).Returns("creature effective roll");
            mockDice.Setup(d => d.Roll("creature effective roll")).Returns(8765);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(8765));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SubtypeHasFurtherSetSubtype()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["creature[challenge rating]"] = "creature amount";

            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature (subtype)" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature"))
                .Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "other creature (subtype)")).Returns(new[] { "challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "other challenge rating")).Returns("other roll");
            mockDice.Setup(d => d.Roll("other roll")).Returns(600);

            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns(RollConstants.Reroll);
            mockDice.Setup(d => d.Roll("wrong roll")).Returns(1337);

            mockRollSelector.Setup(s => s.SelectFrom("creature amount", 9876)).Returns("creature effective roll");
            mockDice.Setup(d => d.Roll("creature effective roll")).Returns(7654);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("other creature (subtype)"));
            Assert.That(creature.Quantity, Is.EqualTo(7654));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SubtypeHasFurtherSubtype()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["creature[challenge rating]"] = "creature amount";

            requiresSubtype.Add("creature");
            requiresSubtype.Add("other creature");

            var subSubtypes = new[] { "wrong subtype", "subtype" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "other creature"))
                .Returns(subSubtypes);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature"))
                .Returns(new[] { "wrong creature", "other creature" });

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subSubtypes)).Returns(subSubtypes.First()).Returns(subSubtypes.Last());

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "other creature")).Returns(new[] { "other challenge rating" });

            tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "other creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "subtype")).Returns(new[] { "challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "challenge rating")).Returns("roll");
            mockDice.Setup(d => d.Roll("roll")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong subtype")).Returns(new[] { "wrong challenge rating" });
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns("wrong roll");
            mockDice.Setup(d => d.Roll("wrong roll")).Returns(1337);

            mockRollSelector.Setup(s => s.SelectFrom("creature amount", 9876)).Returns("creature effective roll");
            mockDice.Setup(d => d.Roll("creature effective roll")).Returns(7654);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("other creature (subtype)"));
            Assert.That(creature.Quantity, Is.EqualTo(7654));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void SubtypeIsDragon()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["creature[8765]"] = "creature amount";

            requiresSubtype.Add("creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature"))
                .Returns(new[] { "wrong creature", CreatureConstants.Dragon });

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, CreatureConstants.Dragon)).Returns(new[] { "dragon challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "dragon challenge rating")).Returns("other roll");
            mockRollSelector.Setup(s => s.SelectFrom("other roll", 9876)).Returns("other effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong subtype")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns("wrong roll");
            mockRollSelector.Setup(s => s.SelectFrom("wrong roll", 9876)).Returns("wrong effective roll");
            mockDice.Setup(d => d.Roll("wrong effective roll")).Returns(1337);

            mockRollSelector.Setup(s => s.SelectFrom("creature amount", 9876)).Returns("creature effective roll");
            mockDice.Setup(d => d.Roll("creature effective roll")).Returns(76);

            tableName = string.Format(TableNameConstants.LevelXDragons, 8765);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("dragon type and age");

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("dragon type and age"));
            Assert.That(creature.Quantity, Is.EqualTo(76));
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
            mockRollSelector.Setup(s => s.SelectFrom(level, "other challenge rating")).Returns("other roll");
            mockDice.Setup(d => d.Roll("other roll")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns(RollConstants.Reroll);
            mockDice.Setup(d => d.Roll(RollConstants.Reroll)).Returns(1337);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RerolledSubtypeRequiresFurtherSubtype()
        {
            requiresSubtype.Add("creature");
            requiresSubtype.Add("other creature");

            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "other creature")).Returns(new[] { "wrong subtype", "subtype" });

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns("wrong creature").Returns("other creature");

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "other creature")).Returns(new[] { "other challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "other challenge rating")).Returns("other roll");
            mockDice.Setup(d => d.Roll("other roll")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns(RollConstants.Reroll);
            mockDice.Setup(d => d.Roll(RollConstants.Reroll)).Returns(1337);

            tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "other creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "subtype")).Returns(new[] { "challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "challenge rating")).Returns("roll");
            mockDice.Setup(d => d.Roll("roll")).Returns(8765);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("other creature (subtype)"));
            Assert.That(creature.Quantity, Is.EqualTo(8765));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RerolledSubtypeIsDragon()
        {
            requiresSubtype.Add("creature");

            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["creature[1337]"] = "creature amount";

            var subtypes = new[] { "wrong creature", CreatureConstants.Dragon };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns("wrong creature").Returns(CreatureConstants.Dragon);

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "dragon type and age")).Returns(new[] { "dragon challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "dragon challenge rating")).Returns("dragon roll");
            mockDice.Setup(d => d.Roll("dragon roll")).Returns(600);
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns(RollConstants.Reroll);
            mockDice.Setup(d => d.Roll(RollConstants.Reroll)).Returns(7654);

            tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "other creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "dragon type and age")).Returns(new[] { "challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "challenge rating")).Returns("roll");
            mockDice.Setup(d => d.Roll("roll")).Returns(8765);

            tableName = string.Format(TableNameConstants.LevelXDragons, 1337);
            mockPercentileSelector.Setup(s => s.SelectFrom(tableName)).Returns("dragon type and age");

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("creature"));
            Assert.That(creature.Description, Is.EqualTo("dragon type and age"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void ImpossibleSubtypeForcesReroll()
        {
            var correctEncounterTypeAndAmount = new Dictionary<string, string>();
            correctEncounterTypeAndAmount["correct creature"] = "correct creature amount";
            mockRollSelector.Setup(s => s.SelectFrom("correct creature amount", 9876)).Returns("correct creature effective roll");
            mockDice.Setup(d => d.Roll("correct creature effective roll")).Returns(1234);

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectFrom(90210, environment, temperature, timeOfDay)).Returns(encounterTypeAndAmount).Returns(correctEncounterTypeAndAmount);

            requiresSubtype.Add("creature");
            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.Setup(s => s.SelectRandomFrom(subtypes)).Returns("wrong creature");

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, "creature");
            mockCollectionSelector.Setup(s => s.SelectFrom(tableName, "wrong creature")).Returns(new[] { "wrong challenge rating" });
            mockRollSelector.Setup(s => s.SelectFrom(level, "wrong challenge rating")).Returns(RollConstants.Reroll);
            mockDice.Setup(d => d.Roll(RollConstants.Reroll)).Returns(1337);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("correct creature"));
            Assert.That(creature.Description, Is.Empty);
            Assert.That(creature.Quantity, Is.EqualTo(1234));
            Assert.That(encounter.Characters, Is.Empty);

            mockCollectionSelector.Verify(s => s.SelectRandomFrom(subtypes), Times.Exactly(10000));
            mockCollectionSelector.Verify(s => s.SelectFrom(tableName, "wrong creature"), Times.Exactly(10000));
            mockRollSelector.Verify(s => s.SelectFrom(level, "wrong challenge rating"), Times.Exactly(10000));
        }

        [Test]
        public void RerollEncounter()
        {
            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectFrom(90210, environment, temperature, timeOfDay))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(encounterTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(600);

            mockFilterVerifier.Setup(v => v.EncounterIsValid(otherTypeAndAmount, 9876)).Returns(true);
            mockFilterVerifier.Setup(v => v.EncounterIsValid(wrongTypeAndAmount, 9876)).Returns(false);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
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

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectFrom(90210, environment, temperature, timeOfDay))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(encounterTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(600);

            mockFilterVerifier.Setup(v => v.EncounterIsValid(otherTypeAndAmount, 9876)).Returns(true);
            mockFilterVerifier.Setup(v => v.EncounterIsValid(wrongTypeAndAmount, 9876)).Returns(false);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GetEncounterWithMultipleTypesOfCreatures()
        {
            encounterTypeAndAmount["other creature"] = "other creature amount";

            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(600);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single(c => c.Name == "creature");
            var otherCreature = encounter.Creatures.Single(c => c.Name == "other creature");
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(otherCreature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(2));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void GetTreasure()
        {
            var treasure = new Treasure();
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.IsAny<Creature>(), 9266)).Returns(treasure);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasure, Is.EqualTo(treasure));
        }

        [Test]
        public void UseFirstCreatureForTreasure()
        {
            encounterTypeAndAmount["other creature"] = "other creature amount";

            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(600);

            var treasure = new Treasure();
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Name == "creature"), 9266)).Returns(treasure);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasure, Is.EqualTo(treasure));
        }

        [Test]
        public void GetTreasureForCreatureWithDescription()
        {
            var monster = encounterTypeAndAmount.First();
            encounterTypeAndAmount.Clear();

            encounterTypeAndAmount[monster.Key + " (description)"] = monster.Value;

            var treasure = new Treasure();
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Name == "creature"), 9266)).Returns(treasure);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasure, Is.EqualTo(treasure));
        }

        [Test]
        public void GetTreasureForCreatureWithCharacterLevel()
        {
            var monster = encounterTypeAndAmount.First();
            encounterTypeAndAmount.Clear();

            encounterTypeAndAmount[monster.Key + "[1]"] = monster.Value;

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character))
                .Returns(new[] { "other character class", monster.Key });

            var treasure = new Treasure();
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Name == "creature"), 9266)).Returns(treasure);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasure, Is.EqualTo(treasure));
        }

        [Test]
        public void GetTreasureForCreatureWithDescriptionAndCharacterLevel()
        {
            var monster = encounterTypeAndAmount.First();
            encounterTypeAndAmount.Clear();

            encounterTypeAndAmount[monster.Key + " (description)[1]"] = monster.Value;

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character))
                .Returns(new[] { "other character class", monster.Key });

            var treasure = new Treasure();
            mockEncounterTreasureGenerator.Setup(g => g.GenerateFor(It.Is<Creature>(c => c.Name == "creature"), 9266)).Returns(treasure);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);
            Assert.That(encounter.Treasure, Is.EqualTo(treasure));
        }

        [Test]
        public void ReplaceRollsInCreatureType()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["Hydra (2d3+4 heads)"] = "hydra amount";
            mockRollSelector.Setup(s => s.SelectFrom("hydra amount", 9876)).Returns("hydra effective roll");
            mockDice.Setup(d => d.Roll("hydra effective roll")).Returns(1);
            mockDice.Setup(d => d.ContainsRoll("2d3+4 heads", true)).Returns(true);
            mockDice.Setup(d => d.ReplaceExpressionWithTotal("2d3+4 heads", true)).Returns("1337 heads");

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("Hydra"));
            Assert.That(creature.Description, Is.EqualTo("1337 heads"));
            Assert.That(creature.Quantity, Is.EqualTo(1));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RollsInCreatureTypeAreUnique()
        {
            encounterTypeAndAmount.Clear();
            encounterTypeAndAmount["Hydra (2d3+4 heads)"] = "hydra amount";
            mockRollSelector.Setup(s => s.SelectFrom("hydra amount", 9876)).Returns("hydra effective roll");
            mockDice.Setup(d => d.Roll("hydra effective roll")).Returns(2);
            mockDice.Setup(d => d.ContainsRoll("2d3+4 heads", true)).Returns(true);
            mockDice.SetupSequence(d => d.ReplaceExpressionWithTotal("2d3+4 heads", true)).Returns("1337 heads").Returns("1234 heads");

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay);
            Assert.That(encounter, Is.Not.Null);

            var firstCreature = encounter.Creatures.First(c => c.Description == "1337 heads");
            var secondCreature = encounter.Creatures.First(c => c.Description == "1234 heads");

            Assert.That(firstCreature.Quantity, Is.EqualTo(1));
            Assert.That(secondCreature.Quantity, Is.EqualTo(1));
            Assert.That(encounter.Creatures.Count(), Is.EqualTo(2));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void FilterCreatureTypes()
        {
            mockFilterVerifier.Setup(v => v.FiltersAreValid(environment, level, temperature, timeOfDay, "filter")).Returns(true);

            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectFrom(90210, environment, temperature, timeOfDay))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(encounterTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("wrong creature amount", 9876)).Returns("wrong effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(600);
            mockDice.Setup(d => d.Roll("wrong effective roll")).Returns(666);
            mockFilterVerifier.Setup(v => v.EncounterIsValid(otherTypeAndAmount, 9876, "filter")).Returns(true);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay, "filter");
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void UseMultipleFiltersForCreatureTypes()
        {
            mockFilterVerifier.Setup(v => v.FiltersAreValid(environment, level, temperature, timeOfDay, "filter 1", "filter 2")).Returns(true);

            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectFrom(90210, environment, temperature, timeOfDay))
                .Returns(wrongTypeAndAmount).Returns(otherTypeAndAmount).Returns(encounterTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("wrong creature amount", 9876)).Returns("wrong effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(600);
            mockDice.Setup(d => d.Roll("wrong effective roll")).Returns(666);
            mockFilterVerifier.Setup(v => v.EncounterIsValid(otherTypeAndAmount, 9876, "filter 1", "filter 2")).Returns(true);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay, "filter 1", "filter 2");
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }

        [Test]
        public void RerollEffectiveLevelIfEncounterMustBeRerolledForFilter()
        {
            mockFilterVerifier.Setup(v => v.FiltersAreValid(environment, level, temperature, timeOfDay, "filter")).Returns(true);

            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            var wrongEncounterLevelAndModifier = new Dictionary<string, string>();
            wrongEncounterLevelAndModifier["666"] = "13";

            var tableName = string.Format(TableNameConstants.LevelXEncounterLevel, level);
            mockTypeAndAmountPercentileSelector.SetupSequence(s => s.SelectFrom(tableName))
                .Returns(wrongEncounterLevelAndModifier)
                .Returns(encounterLevelAndModifier);

            mockCreatureCollectionSelector.SetupSequence(s => s.SelectFrom(90210, environment, temperature, timeOfDay)).Returns(otherTypeAndAmount);
            mockCreatureCollectionSelector.SetupSequence(s => s.SelectFrom(666, environment, temperature, timeOfDay)).Returns(wrongTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("wrong creature amount", 9876)).Returns("wrong effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(600);
            mockDice.Setup(d => d.Roll("wrong effective roll")).Returns(666);
            mockFilterVerifier.Setup(v => v.EncounterIsValid(otherTypeAndAmount, 9876, "filter")).Returns(true);
            mockFilterVerifier.Setup(v => v.EncounterIsValid(wrongTypeAndAmount, 13, "filter")).Returns(false);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay, "filter");
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);

            mockFilterVerifier.Verify(v => v.EncounterIsValid(otherTypeAndAmount, 9876, "filter"), Times.AtLeastOnce);
            mockFilterVerifier.Verify(v => v.EncounterIsValid(wrongTypeAndAmount, 13, "filter"), Times.AtLeastOnce);
        }

        [Test]
        public void StopRegenerationDueToRandomFilterIncompatibility()
        {
            mockFilterVerifier.Setup(v => v.FiltersAreValid(environment, level, temperature, timeOfDay, "filter", "other filter")).Returns(true);

            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            mockFilterVerifier.Setup(v => v.EncounterIsValid(wrongTypeAndAmount, 9876, "filter", "other filter")).Returns(false);
            mockCreatureCollectionSelector.Setup(s => s.SelectFrom(90210, environment, temperature, timeOfDay)).Returns(wrongTypeAndAmount);

            mockRollSelector.Setup(s => s.SelectFrom("wrong creature amount", 9876)).Returns("wrong effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(600);

            Assert.That(() => encounterGenerator.Generate(environment, level, temperature, timeOfDay, "filter", "other filter"), Throws.Exception.With.Message.EqualTo("Failed to generate level 9266 creature for [filter,other filter] in temperature environment time of day after 10001 iterations"));
        }

        [Test]
        public void SuccessfulRegenerationAtLimitIsStillValid()
        {
            mockFilterVerifier.Setup(v => v.FiltersAreValid(environment, level, temperature, timeOfDay, "filter", "other filter")).Returns(true);

            var wrongTypeAndAmount = new Dictionary<string, string>();
            wrongTypeAndAmount["wrong creature"] = "wrong creature amount";

            var otherTypeAndAmount = new Dictionary<string, string>();
            otherTypeAndAmount["other creature"] = "other creature amount";

            var count = 0;
            var sequence = mockCreatureCollectionSelector.Setup(s => s.SelectFrom(90210, environment, temperature, timeOfDay)).Returns(() => count++ == 10000 ? otherTypeAndAmount : wrongTypeAndAmount);
            mockFilterVerifier.Setup(v => v.EncounterIsValid(wrongTypeAndAmount, 9876, "filter", "other filter")).Returns(false);
            mockFilterVerifier.Setup(v => v.EncounterIsValid(otherTypeAndAmount, 9876, "filter", "other filter")).Returns(true);

            mockRollSelector.Setup(s => s.SelectFrom("wrong creature amount", 9876)).Returns("wrong effective roll");
            mockRollSelector.Setup(s => s.SelectFrom("other creature amount", 9876)).Returns("other effective roll");
            mockDice.Setup(d => d.Roll("other effective roll")).Returns(600);
            mockDice.Setup(d => d.Roll("wrong effective roll")).Returns(666);

            var encounter = encounterGenerator.Generate(environment, level, temperature, timeOfDay, "filter", "other filter");
            Assert.That(encounter, Is.Not.Null);

            var creature = encounter.Creatures.Single();
            Assert.That(creature.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(600));
            Assert.That(encounter.Characters, Is.Empty);
        }
    }
}
