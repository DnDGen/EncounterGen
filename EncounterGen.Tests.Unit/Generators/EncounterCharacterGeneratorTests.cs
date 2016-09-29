using CharacterGen;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using CharacterGen.Randomizers.Stats;
using EncounterGen.Common;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using Moq;
using NUnit.Framework;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterCharacterGeneratorTests
    {
        private IEncounterCharacterGenerator encounterCharacterGenerator;
        private Mock<ICharacterGenerator> mockCharacterGenerator;
        private Mock<IAlignmentRandomizer> mockAnyAlignmentRandomizer;
        private Mock<IClassNameRandomizer> mockAnyPlayerClassNameRandomizer;
        private Mock<IClassNameRandomizer> mockAnyNPCClassNameRandomizer;
        private Mock<ISetLevelRandomizer> mockSetLevelRandomizer;
        private Mock<RaceRandomizer> mockAnyBaseRaceRandomizer;
        private Mock<RaceRandomizer> mockAnyMetaraceRandomizer;
        private Mock<ISetMetaraceRandomizer> mockSetMetaraceRandomizer;
        private Mock<IStatsRandomizer> mockRawStatsRandomizer;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<ISetClassNameRandomizer> mockSetClassNameRandomizer;
        private Mock<Dice> mockDice;
        private List<string> undeadNPCs;
        private List<string> charactersGroup;
        private List<Creature> creatures;

        [SetUp]
        public void Setup()
        {
            mockCharacterGenerator = new Mock<ICharacterGenerator>();
            mockAnyAlignmentRandomizer = new Mock<IAlignmentRandomizer>();
            mockAnyPlayerClassNameRandomizer = new Mock<IClassNameRandomizer>();
            mockSetLevelRandomizer = new Mock<ISetLevelRandomizer>();
            mockAnyBaseRaceRandomizer = new Mock<RaceRandomizer>();
            mockAnyMetaraceRandomizer = new Mock<RaceRandomizer>();
            mockRawStatsRandomizer = new Mock<IStatsRandomizer>();
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockSetMetaraceRandomizer = new Mock<ISetMetaraceRandomizer>();
            mockSetClassNameRandomizer = new Mock<ISetClassNameRandomizer>();
            mockAnyNPCClassNameRandomizer = new Mock<IClassNameRandomizer>();
            mockDice = new Mock<Dice>();

            encounterCharacterGenerator = new EncounterCharacterGenerator(mockCharacterGenerator.Object, mockAnyAlignmentRandomizer.Object, mockAnyPlayerClassNameRandomizer.Object, mockSetLevelRandomizer.Object,
                mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object, mockRawStatsRandomizer.Object, mockCollectionSelector.Object,
                mockSetMetaraceRandomizer.Object, mockAnyNPCClassNameRandomizer.Object, mockSetClassNameRandomizer.Object, mockDice.Object);

            undeadNPCs = new List<string>();
            charactersGroup = new List<string>();
            creatures = new List<Creature>();

            charactersGroup.Add(CreatureConstants.Character);
            charactersGroup.Add(CreatureConstants.NPC);

            creatures.Add(new Creature());
            creatures[0].Quantity = 600;
            creatures[0].Name = $"{CreatureConstants.Character}[1337]";
            creatures[0].Description = "character subtype";

            mockSetLevelRandomizer.SetupAllProperties();
            mockSetLevelRandomizer.Object.AllowAdjustments = true;

            mockSetMetaraceRandomizer.SetupAllProperties();
            mockSetClassNameRandomizer.SetupAllProperties();

            mockDice.Setup(d => d.Roll(It.IsAny<string>())).Returns((string s) => ParseRoll(s));
            mockDice.Setup(d => d.Roll("effective roll").AsSum()).Returns(42);

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character)).Returns(charactersGroup);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UndeadNPC)).Returns(undeadNPCs);
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> c) => c.Last());
        }

        private PartialRoll ParseRoll(string roll)
        {
            var value = 0;
            if (int.TryParse(roll, out value) == false)
                throw new ArgumentException("This roll was not set up to be parsed: " + roll);

            var mockPartialRoll = new Mock<PartialRoll>();
            mockPartialRoll.Setup(r => r.AsSum()).Returns(value);

            return mockPartialRoll.Object;
        }

        [Test]
        public void GenerateCharacters()
        {
            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyPlayerClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments),
                    mockAnyBaseRaceRandomizer.Object,
                    mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);

            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        private Character BuildCharacter(int level, string className = "random class name", string metarace = "random metarace")
        {
            var character = new Character();
            character.InterestingTrait = Guid.NewGuid().ToString();
            character.Class.Name = className;
            character.Class.Level = level;
            character.Race.Metarace = metarace;

            return character;
        }

        [Test]
        public void GenerateCharactersWithVariableLevels()
        {
            creatures[0].Name = $"{CreatureConstants.Character}[13d37]";
            mockDice.Setup(d => d.Roll("13d37").AsSum()).Returns(1337);

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyPlayerClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments),
                    mockAnyBaseRaceRandomizer.Object,
                    mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void VariableLevelsAreUniquePerCharacter()
        {
            creatures[0].Name = $"{CreatureConstants.Character}[13d37]";
            creatures[0].Quantity = 2;

            mockDice.SetupSequence(d => d.Roll("13d37").AsSum()).Returns(1337).Returns(1234);

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyPlayerClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments == true),
                    mockAnyBaseRaceRandomizer.Object,
                    mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337));

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyPlayerClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1234 && r.AllowAdjustments == true),
                    mockAnyBaseRaceRandomizer.Object,
                    mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1234));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(2));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
            Assert.That(characters.Select(c => c.Class.Level), Contains.Item(1337));
            Assert.That(characters.Select(c => c.Class.Level), Contains.Item(1234));
        }

        [Test]
        public void GenerateUndeadNPCs()
        {
            creatures[0].Name = $"creature[1337]";

            undeadNPCs.Add("creature");
            undeadNPCs.Add("other monster");

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyPlayerClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments == false),
                    mockAnyBaseRaceRandomizer.Object,
                    It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == "creature"),
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337, metarace: "creature"));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
            Assert.That(characters.Select(c => c.Race.Metarace), Is.All.EqualTo("creature"));
        }

        [Test]
        public void GenerateUndeadNPCsWithVariableLevels()
        {
            creatures[0].Name = $"creature[13d37]";
            mockDice.Setup(d => d.Roll("13d37").AsSum()).Returns(1337);

            undeadNPCs.Add("creature");
            undeadNPCs.Add("other monster");

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyPlayerClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments == false),
                    mockAnyBaseRaceRandomizer.Object,
                    It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == "creature"),
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337, metarace: "creature"));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
            Assert.That(characters.Select(c => c.Race.Metarace), Is.All.EqualTo("creature"));
        }

        [Test]
        public void VariableLevelsAreUniquePerUndeadNPC()
        {
            creatures[0].Name = $"creature[13d37]";
            creatures[0].Quantity = 2;

            undeadNPCs.Add("creature");
            undeadNPCs.Add("other monster");

            mockDice.SetupSequence(d => d.Roll("13d37").AsSum()).Returns(1337).Returns(1234);

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyPlayerClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments == false),
                    mockAnyBaseRaceRandomizer.Object,
                    It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == "creature"),
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337, metarace: "creature"));

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyPlayerClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1234 && r.AllowAdjustments == false),
                    mockAnyBaseRaceRandomizer.Object,
                    It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == "creature"),
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1234, metarace: "creature"));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count(), Is.EqualTo(2));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
            Assert.That(characters.Select(c => c.Class.Level), Contains.Item(1337));
            Assert.That(characters.Select(c => c.Class.Level), Contains.Item(1234));
            Assert.That(characters.Select(c => c.Race.Metarace), Is.All.EqualTo("creature"));
        }

        [Test]
        public void GenerateCharactersFromSubtype()
        {
            creatures[0].Name = $"creature[1337]";
            creatures[0].Description = CreatureConstants.Character + "[1234]";

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyPlayerClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1234 && r.AllowAdjustments),
                    mockAnyBaseRaceRandomizer.Object,
                    mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1234));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void GenerateCharacterClassFromSubtype()
        {
            creatures[0].Name = $"creature[1337]";
            creatures[0].Description = "character class[1234]";

            charactersGroup.Add("character class");

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    It.Is<ISetClassNameRandomizer>(r => r.SetClassName == "character class"),
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1234 && r.AllowAdjustments),
                    mockAnyBaseRaceRandomizer.Object,
                    mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1234));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void GenerateUndeadNPCFromSubtype()
        {
            creatures[0].Name = $"creature[1337]";
            creatures[0].Description = "undead[1234]";

            undeadNPCs.Add("undead");

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyPlayerClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1234 && r.AllowAdjustments == false),
                    mockAnyBaseRaceRandomizer.Object,
                    It.Is<ISetMetaraceRandomizer>(r => r.SetMetarace == "undead"),
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1234, metarace: "undead"));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void GenerateSpecificClass()
        {
            creatures[0].Name = $"character class[1337]";
            charactersGroup.Add("character class");

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    It.Is<ISetClassNameRandomizer>(r => r.SetClassName == "character class"),
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments),
                    mockAnyBaseRaceRandomizer.Object, mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337, "character class"));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
            Assert.That(characters.Select(c => c.Class.Name), Is.All.EqualTo("character class"));
        }

        [Test]
        public void GenerateSpecificNPCClass()
        {
            creatures[0].Name = $"npc class[1337]";
            charactersGroup.Add("npc class");

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    It.Is<ISetClassNameRandomizer>(r => r.SetClassName == "npc class"),
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments),
                    mockAnyBaseRaceRandomizer.Object,
                    mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337, "npc class"));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
            Assert.That(characters.Select(c => c.Class.Name), Is.All.EqualTo("npc class"));
        }

        [Test]
        public void GenerateRandomNPCClass()
        {
            creatures[0].Name = $"{CreatureConstants.NPC}[1337]";

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyNPCClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments),
                    mockAnyBaseRaceRandomizer.Object,
                    mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void GenerateSpecificNPCClassDescribedAsSomethingElse()
        {
            creatures[0].Name = $"npc class (description)[1337]";
            charactersGroup.Add("npc class");

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    It.Is<ISetClassNameRandomizer>(r => r.SetClassName == "npc class"),
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments),
                    mockAnyBaseRaceRandomizer.Object,
                    mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337, "npc class"));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
            Assert.That(characters.Select(c => c.Class.Name), Is.All.EqualTo("npc class"));
        }

        [Test]
        public void GenerateRandomNPCClassDescribedAsSomethingElse()
        {
            creatures[0].Name = $"{CreatureConstants.NPC} (description)[1337]";

            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    mockAnyNPCClassNameRandomizer.Object,
                    It.Is<ISetLevelRandomizer>(r => r.SetLevel == 1337 && r.AllowAdjustments),
                    mockAnyBaseRaceRandomizer.Object,
                    mockAnyMetaraceRandomizer.Object,
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(1337));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(600));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void GenerateMultipleTypesOfCharacters()
        {
            creatures.Add(new Creature());
            creatures.Add(new Creature());
            creatures.Add(new Creature());
            creatures.Add(new Creature());
            creatures.Add(new Creature());
            creatures.Add(new Creature());

            creatures[0].Name = "creature[6789]";
            creatures[1].Name = $"{CreatureConstants.NPC} (description 1)[1337]";
            creatures[1].Quantity = 12;
            creatures[2].Name = $"npc class[3456]";
            creatures[2].Quantity = 9;
            creatures[3].Name = $"npc class (description 2)[1234]";
            creatures[3].Quantity = 11;
            creatures[4].Name = $"{CreatureConstants.NPC}[2345]";
            creatures[4].Quantity = 10;
            creatures[5].Name = $"{CreatureConstants.Character}[5678]";
            creatures[5].Quantity = 7;
            creatures[6].Name = $"character class[4567]";
            creatures[6].Quantity = 8;

            undeadNPCs.Add("creature");
            undeadNPCs.Add("other monster");
            charactersGroup.Add("other character class");
            charactersGroup.Add("character class");
            charactersGroup.Add("npc class");

            var level = 1;
            mockCharacterGenerator
                .Setup(g => g.GenerateWith(
                    mockAnyAlignmentRandomizer.Object,
                    It.IsAny<IClassNameRandomizer>(),
                    mockSetLevelRandomizer.Object,
                    mockAnyBaseRaceRandomizer.Object,
                    It.IsAny<RaceRandomizer>(),
                    mockRawStatsRandomizer.Object))
                .Returns(() => BuildCharacter(level++));

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.All.Not.Null);
            Assert.That(characters.Count, Is.EqualTo(657));
            Assert.That(characters, Is.Unique);
            Assert.That(characters.Select(c => c.InterestingTrait), Is.Unique);
        }

        [Test]
        public void WholeCreatureTypeMustMatchToBeCharacter()
        {
            creatures[0].Name = $"{CreatureConstants.Character} but not really[6789]";

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.Empty);
        }

        [Test]
        public void WholeCreatureTypeMustMatchToBeCharacterClass()
        {
            creatures[0].Name = $"character class but not really[6789]";
            charactersGroup.Add("character class");

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.Empty);
        }

        [Test]
        public void WholeCreatureTypeMustMatchToBeUndeadNPC()
        {
            creatures[0].Name = $"undead but not really[6789]";
            undeadNPCs.Add("undead");

            var characters = encounterCharacterGenerator.GenerateFrom(creatures);
            Assert.That(characters, Is.Not.Null);
            Assert.That(characters, Is.Empty);
        }

        [Test]
        public void NotSpecifyingLevelForCharacterThrowsException()
        {
            creatures[0].Name = CreatureConstants.Character;
            Assert.That(() => encounterCharacterGenerator.GenerateFrom(creatures), Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("Character level was not provided for a character creature Character (character subtype)"));
        }

        [Test]
        public void NotSpecifyingLevelForCharacterClassThrowsException()
        {
            creatures[0].Name = "character class";
            charactersGroup.Add("character class");

            Assert.That(() => encounterCharacterGenerator.GenerateFrom(creatures), Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("Character level was not provided for a character creature character class (character subtype)"));
        }

        [Test]
        public void NotSpecifyingLevelForUndeadNPCThrowsException()
        {
            creatures[0].Name = "undead";
            undeadNPCs.Add("undead");

            Assert.That(() => encounterCharacterGenerator.GenerateFrom(creatures), Throws.InstanceOf<ArgumentException>().With.Message.EqualTo("Character level was not provided for a character creature undead (character subtype)"));
        }
    }
}
