using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.RollGen;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class CreatureGeneratorTests
    {
        private ICreatureGenerator creatureGenerator;
        private Mock<Dice> mockDice;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<IEncounterFormatter> mockEncounterFormatter;
        private Dictionary<string, string> creaturesAndAmounts;
        private List<string> requiresSubtype;
        private Mock<IChallengeRatingSelector> mockChallengeRatingSelector;
        private Dictionary<string, IEnumerable<string>> challengeRatings;

        [SetUp]
        public void Setup()
        {
            mockDice = new Mock<Dice>();
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockEncounterFormatter = new Mock<IEncounterFormatter>();
            mockChallengeRatingSelector = new Mock<IChallengeRatingSelector>();

            creatureGenerator = new CreatureGenerator(
                mockDice.Object,
                mockCollectionSelector.Object,
                mockEncounterFormatter.Object,
                mockChallengeRatingSelector.Object);

            creaturesAndAmounts = new Dictionary<string, string>();
            requiresSubtype = new List<string>();
            challengeRatings = new Dictionary<string, IEnumerable<string>>();

            creaturesAndAmounts["creature"] = "creature amount";
            challengeRatings["creature"] = new[] { "challenge rating" };

            mockDice.Setup(d => d.Roll(It.IsAny<string>())).Returns(ParseRoll);
            mockDice.Setup(d => d.Roll("creature amount")).Returns(ParseRoll("42"));

            mockCollectionSelector.Setup(s => s.SelectAllFrom(TableNameConstants.AverageChallengeRatings)).Returns(challengeRatings);
            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype)).Returns(requiresSubtype);
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> c) => c.Last());

            mockChallengeRatingSelector.Setup(s => s.SelectAverageForCreature(It.IsAny<string>())).Returns((string s) => challengeRatings[s].Single());

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(It.IsAny<string>())).Returns((string s) => s);
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(It.IsAny<string>())).Returns(string.Empty);
        }

        private PartialRoll ParseRoll(string roll)
        {
            var mockPartialRoll = new Mock<PartialRoll>();
            var value = 0;

            if (int.TryParse(roll, out value))
            {
                mockPartialRoll.Setup(r => r.AsSum<int>()).Returns(value);
                return mockPartialRoll.Object;
            }

            throw new ArgumentException("This roll was not set up to be parsed: " + roll);
        }

        private int GetIndex(int count)
        {
            return (count % 6) switch
            {
                0 or 2 or 3 => 0,
                1 or 4 or 5 => 1,
                _ => 0,
            };
        }

        [Test]
        public void GenerateForEncounter_GenerateCreatures()
        {
            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            var creatures = creatureGenerator.GenerateFor("my encounter");
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);

            var creature = creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.Description, Is.Empty);
            Assert.That(creature.Type.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
        }

        [Test]
        public void GenerateForEncounter_IfCreatureHasCountOf0OrLess_ThenRemoveCreature()
        {
            creaturesAndAmounts["other creature"] = "other amount";
            creaturesAndAmounts["another creature"] = "another amount";
            challengeRatings["other creature"] = new[] { "other challenge rating" };
            challengeRatings["another creature"] = new[] { "another challenge rating" };

            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            mockDice.Setup(d => d.Roll("creature amount")).Returns(ParseRoll("0"));
            mockDice.Setup(d => d.Roll("another amount")).Returns(ParseRoll("-42"));
            mockDice.Setup(d => d.Roll("other amount")).Returns(ParseRoll("69"));

            var creatures = creatureGenerator.GenerateFor("my encounter");
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);

            var creature = creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Type.Description, Is.Empty);
            Assert.That(creature.Type.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(69));
            Assert.That(creature.ChallengeRating, Is.EqualTo("other challenge rating"));
        }

        [Test]
        public void GenerateForEncounter_GenerateCreatureWithDescription()
        {
            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");

            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            var creatures = creatureGenerator.GenerateFor("my encounter");
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);

            var creature = creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
        }

        [Test]
        public void GenerateForEncounter_GenerateCreatureWithSetSubtype()
        {
            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectSubtypeFrom(creaturesAndAmounts.First().Key)).Returns("subtype");

            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            var creatures = creatureGenerator.GenerateFor("my encounter");
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);

            var creature = creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.Description, Is.Empty);
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype"));
            Assert.That(creature.Type.SubType.Description, Is.Empty);
            Assert.That(creature.Type.SubType.SubType, Is.Null);
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
        }

        [Test]
        public void GenerateForEncounter_CreatureWithRandomSubTypeShouldUseSetAmountAndSetChallengeRating()
        {
            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("challenge rating");

            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            challengeRatings["other creature"] = new[] { "challenge rating" };
            challengeRatings["wrong creature"] = new[] { "wrong challenge rating" };
            challengeRatings[creaturesAndAmounts.Keys.First()] = new[] { "specific challenge rating" };

            var creatures = creatureGenerator.GenerateFor("my encounter");
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);

            var creature = creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("specific challenge rating"));
        }

        [Test]
        public void GenerateForEncounter_CreatureWithRandomSubTypeShouldPickNewSubtypeForEachInQuantity()
        {
            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("challenge rating");

            requiresSubtype.Add("creature");

            var subtypes = new[] { "other creature", "random creature" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            var count = 0;
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(subtypes)).Returns((IEnumerable<string> c) => c.ElementAt(GetIndex(count++)));

            challengeRatings["other creature"] = new[] { "challenge rating" };
            challengeRatings["wrong creature"] = new[] { "wrong challenge rating" };
            challengeRatings["random creature"] = new[] { "challenge rating" };
            challengeRatings[creaturesAndAmounts.Keys.First()] = new[] { "specific challenge rating" };

            var creatures = creatureGenerator.GenerateFor("my encounter");
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);
            Assert.That(creatures.Count, Is.EqualTo(2));

            var first = creatures.First();
            Assert.That(first.Type.Name, Is.EqualTo("creature"));
            Assert.That(first.Type.SubType.Name, Is.EqualTo("other creature"));
            Assert.That(first.Quantity, Is.EqualTo(21));
            Assert.That(first.ChallengeRating, Is.EqualTo("specific challenge rating"));

            var last = creatures.Last();
            Assert.That(last.Type.Name, Is.EqualTo("creature"));
            Assert.That(last.Type.SubType.Name, Is.EqualTo("random creature"));
            Assert.That(last.Quantity, Is.EqualTo(21));
            Assert.That(last.ChallengeRating, Is.EqualTo("specific challenge rating"));
        }

        [Test]
        public void GenerateForEncounter_CreatureWithRandomSubTypeWithoutSetChallengeRatingThrowsException()
        {
            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            challengeRatings["other creature"] = new[] { "challenge rating" };
            challengeRatings["wrong creature"] = new[] { "wrong challenge rating" };

            Assert.That(
                () => creatureGenerator.GenerateFor("my encounter"),
                Throws.InvalidOperationException.With.Message.EqualTo("Cannot generate random subtype of creature without a set challenge rating"));
        }

        [Test]
        public void GenerateForEncounter_CreatureWithRandomSubTypeWithFurtherSubtypeShouldUseSetAmountAndSetChallengeRating()
        {
            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("challenge rating");
            mockEncounterFormatter.Setup(s => s.SelectSubtypeFrom("other creature")).Returns("subtype");

            requiresSubtype.Add("creature");

            var subtypes = new[] { "wrong creature", "other creature" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subtypes)).Returns(subtypes.First()).Returns(subtypes.Last());

            challengeRatings["other creature"] = new[] { "challenge rating" };
            challengeRatings["wrong creature"] = new[] { "wrong challenge rating" };
            challengeRatings[creaturesAndAmounts.Keys.First()] = new[] { "specific challenge rating" };

            var creatures = creatureGenerator.GenerateFor("my encounter");
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);

            var creature = creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("subtype"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("specific challenge rating"));
        }

        //INFO: Example of this might be a dominated mephit
        [Test]
        public void GenerateForEncounter_CreatureWithRandomSubtypeHasFurtherRandomSubtype()
        {
            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("challenge rating");
            mockEncounterFormatter.Setup(s => s.SelectSubtypeFrom("other creature")).Returns("subtype");
            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom("other creature")).Returns("other challenge rating");

            requiresSubtype.Add("creature");
            requiresSubtype.Add("other creature");

            var subSubtypes = new[] { "wrong subtype", "subtype" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "other creature")).Returns(subSubtypes);
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(new[] { "wrong creature", "other creature" });

            mockCollectionSelector.SetupSequence(s => s.SelectRandomFrom(subSubtypes)).Returns(subSubtypes.First()).Returns(subSubtypes.Last());

            challengeRatings["other creature"] = new[] { "challenge rating" };
            challengeRatings["subtype"] = new[] { "other challenge rating" };
            challengeRatings["wrong creature"] = new[] { "wrong challenge rating" };
            challengeRatings["wrong subtype"] = new[] { "wrong challenge rating" };
            challengeRatings[creaturesAndAmounts.Keys.First()] = new[] { "specific challenge rating" };

            var creatures = creatureGenerator.GenerateFor("my encounter");
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);

            var creature = creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("other creature"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("subtype"));
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("specific challenge rating"));
        }

        //INFO: Example of this might be a dominated mephit
        [Test]
        public void GenerateForEncounter_CreatureWithRandomSubtypeAndFurtherRandomSubtypeSelectsRandomEachTime()
        {
            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("challenge rating");
            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom("other creature")).Returns("other challenge rating");

            requiresSubtype.Add("creature");
            requiresSubtype.Add("other creature");

            var subtypes = new[] { "wrong creature", "random creature", "other creature" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(subtypes);

            var subSubtypes = new[] { "wrong subtype", "other subtype", "subtype" };
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "other creature")).Returns(subSubtypes);

            var count = 0;
            mockCollectionSelector.Setup(s => s.SelectRandomFrom(It.IsAny<IEnumerable<string>>())).Returns((IEnumerable<string> c) => c.ElementAt(GetIndex(count++)));

            challengeRatings["other creature"] = new[] { "challenge rating" };
            challengeRatings["random creature"] = new[] { "challenge rating" };
            challengeRatings["subtype"] = new[] { "other challenge rating" };
            challengeRatings["other subtype"] = new[] { "other challenge rating" };
            challengeRatings["wrong creature"] = new[] { "wrong challenge rating" };
            challengeRatings["wrong subtype"] = new[] { "wrong challenge rating" };
            challengeRatings[creaturesAndAmounts.Keys.First()] = new[] { "specific challenge rating" };

            var creatures = creatureGenerator.GenerateFor("my encounter").ToArray();
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);
            Assert.That(creatures.Length, Is.EqualTo(3));

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

        [Test]
        public void GenerateForEncounter_DoNotGetRandomSubtypeIfSet()
        {
            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");
            mockEncounterFormatter.Setup(s => s.SelectSubtypeFrom(creaturesAndAmounts.First().Key)).Returns("subtype");
            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("creature challenge rating");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");

            requiresSubtype.Add("creature");
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature")).Returns(new[] { "wrong subtype" });

            challengeRatings["wrong subtype"] = new[] { "creature challenge rating" };

            var creatures = creatureGenerator.GenerateFor("my encounter").ToArray();
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);

            var creature = creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType, Is.Null);
        }

        //INFO: There is no current example of this in the system, but it is a good thing to test
        [Test]
        public void GenerateForEncounter_DeepRecursiveTypesAreOkay()
        {
            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creaturesAndAmounts.First().Key)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creaturesAndAmounts.First().Key)).Returns("creature description");
            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom(creaturesAndAmounts.First().Key)).Returns("creature challenge rating");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");
            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom("subtype")).Returns("subtype challenge rating");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("further subtype")).Returns("further subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("further subtype")).Returns("further subtype description");
            mockEncounterFormatter.Setup(s => s.SelectSubtypeFrom("further subtype")).Returns("last subtype");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("last subtype")).Returns("last subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("last subtype")).Returns("last subtype description");

            requiresSubtype.Add(creaturesAndAmounts.First().Key);
            requiresSubtype.Add("subtype");
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "creature name")).Returns(new[] { "subtype" });
            mockCollectionSelector.Setup(s => s.Explode(TableNameConstants.CreatureGroups, "subtype name")).Returns(new[] { "further subtype" });

            challengeRatings["further subtype"] = new[] { "subtype challenge rating" };
            challengeRatings["subtype"] = new[] { "creature challenge rating" };

            var creatures = creatureGenerator.GenerateFor("my encounter");
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);

            var creature = creatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("further subtype"));
            Assert.That(creature.Type.SubType.SubType.Description, Is.EqualTo("further subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType.Name, Is.EqualTo("last subtype"));
            Assert.That(creature.Type.SubType.SubType.SubType.Description, Is.EqualTo("last subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType.SubType, Is.Null);
        }

        [Test]
        public void GenerateForEncounter_GetMultipleCreatures()
        {
            creaturesAndAmounts["other creature"] = "other creature amount";
            mockDice.Setup(d => d.Roll("other creature amount")).Returns(ParseRoll("600"));

            var creatureData = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            mockCollectionSelector
                .Setup(s => s.SelectFrom(TableNameConstants.EncounterCreatures, "my encounter"))
                .Returns(creatureData);
            mockEncounterFormatter
                .Setup(f => f.SelectCreaturesAndAmountsFrom(creatureData))
                .Returns(creaturesAndAmounts);

            challengeRatings["other creature"] = new[] { "other challenge rating" };

            var creatures = creatureGenerator.GenerateFor("my encounter");
            Assert.That(creatures, Is.Not.Null);
            Assert.That(creatures, Is.Not.Empty);

            var creature = creatures.Single(c => c.Type.Name == "creature");
            var otherCreature = creatures.Single(c => c.Type.Name == "other creature");
            Assert.That(creature.Quantity, Is.EqualTo(42));
            Assert.That(creature.ChallengeRating, Is.EqualTo("challenge rating"));
            Assert.That(otherCreature.Quantity, Is.EqualTo(600));
            Assert.That(otherCreature.ChallengeRating, Is.EqualTo("other challenge rating"));
        }

        [Test]
        public void CleanCreatures_CleanUpCreatureName()
        {
            var creatures = new[]
            {
                new Creature(),
            };

            creatures[0].Type.Name = "creature";

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creatures[0].Type.Name)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creatures[0].Type.Name)).Returns("creature description");

            var cleanedCreatures = creatureGenerator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.Not.Null);
            Assert.That(cleanedCreatures, Is.Not.Empty);
            Assert.That(cleanedCreatures, Is.EqualTo(creatures));

            var creature = cleanedCreatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType, Is.Null);
        }

        [Test]
        public void CleanCreatures_DoNotOverwriteExistingDescriptionWhenCleaningCreature()
        {
            var creatures = new[]
            {
                new Creature(),
            };

            creatures[0].Type.Name = "creature";
            creatures[0].Type.Description = "description";

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creatures[0].Type.Name)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creatures[0].Type.Name)).Returns("wrong description");

            var cleanedCreatures = creatureGenerator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.Not.Null);
            Assert.That(cleanedCreatures, Is.Not.Empty);
            Assert.That(cleanedCreatures, Is.EqualTo(creatures));

            var creature = cleanedCreatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("description"));
            Assert.That(creature.Type.SubType, Is.Null);
        }

        [Test]
        public void CleanCreatures_CleanUpRandomSubtype()
        {
            var creatures = new[]
            {
                new Creature(),
            };

            creatures[0].Type.Name = "creature";
            creatures[0].Type.SubType = new CreatureType();
            creatures[0].Type.SubType.Name = "subtype";

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creatures[0].Type.Name)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creatures[0].Type.Name)).Returns("creature description");
            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom(creatures[0].Type.Name)).Returns("creature challenge rating");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");

            var cleanedCreatures = creatureGenerator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.Not.Null);
            Assert.That(cleanedCreatures, Is.Not.Empty);
            Assert.That(cleanedCreatures, Is.EqualTo(creatures));

            var creature = cleanedCreatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType, Is.Null);
        }

        [Test]
        public void CleanCreatures_CleanUpSetSubtype()
        {
            var creatures = new[]
            {
                new Creature(),
            };

            creatures[0].Type.Name = "creature";

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creatures[0].Type.Name)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creatures[0].Type.Name)).Returns("creature description");
            mockEncounterFormatter.Setup(s => s.SelectSubtypeFrom(creatures[0].Type.Name)).Returns("subtype");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");

            var cleanedCreatures = creatureGenerator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.Not.Null);
            Assert.That(cleanedCreatures, Is.Not.Empty);
            Assert.That(cleanedCreatures, Is.EqualTo(creatures));

            var creature = cleanedCreatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType, Is.Null);
        }

        [Test]
        public void CleanCreatures_DoNotOverwriteExistingSubtypeWhenCleaning()
        {
            var creatures = new[]
            {
                new Creature(),
            };

            creatures[0].Type.Name = "creature";
            creatures[0].Type.SubType = new CreatureType();
            creatures[0].Type.SubType.Name = "existing subtype";

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creatures[0].Type.Name)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creatures[0].Type.Name)).Returns("creature description");
            mockEncounterFormatter.Setup(s => s.SelectSubtypeFrom(creatures[0].Type.Name)).Returns("subtype");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("existing subtype")).Returns("existing subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("existing subtype")).Returns("existing subtype description");

            var cleanedCreatures = creatureGenerator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.Not.Null);
            Assert.That(cleanedCreatures, Is.Not.Empty);
            Assert.That(cleanedCreatures, Is.EqualTo(creatures));

            var creature = cleanedCreatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("existing subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("existing subtype description"));
            Assert.That(creature.Type.SubType.SubType, Is.Null);
        }

        [Test]
        public void CleanCreatures_CleanUpRandomSubtypeWithFurtherRandomSubtype()
        {
            var creatures = new[]
            {
                new Creature(),
            };

            creatures[0].Type.Name = "creature";
            creatures[0].Type.SubType = new CreatureType();
            creatures[0].Type.SubType.Name = "subtype";
            creatures[0].Type.SubType.SubType = new CreatureType();
            creatures[0].Type.SubType.SubType.Name = "further subtype";

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creatures[0].Type.Name)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creatures[0].Type.Name)).Returns("creature description");
            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom(creatures[0].Type.Name)).Returns("creature challenge rating");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");
            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom("subtype")).Returns("subtype challenge rating");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("further subtype")).Returns("further subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("further subtype")).Returns("further subtype description");

            var cleanedCreatures = creatureGenerator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.Not.Null);
            Assert.That(cleanedCreatures, Is.Not.Empty);
            Assert.That(cleanedCreatures, Is.EqualTo(creatures));

            var creature = cleanedCreatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("further subtype name"));
            Assert.That(creature.Type.SubType.SubType.Description, Is.EqualTo("further subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType, Is.Null);
        }

        [Test]
        public void CleanCreatures_CleanUpRandomSubtypeWithFurtherSetSubtype()
        {
            var creatures = new[]
            {
                new Creature(),
            };

            creatures[0].Type.Name = "creature";
            creatures[0].Type.SubType = new CreatureType();
            creatures[0].Type.SubType.Name = "subtype";

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creatures[0].Type.Name)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creatures[0].Type.Name)).Returns("creature description");
            mockEncounterFormatter.Setup(s => s.SelectChallengeRatingFrom(creatures[0].Type.Name)).Returns("creature challenge rating");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");
            mockEncounterFormatter.Setup(s => s.SelectSubtypeFrom("subtype")).Returns("further subtype");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("further subtype")).Returns("further subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("further subtype")).Returns("further subtype description");

            var cleanedCreatures = creatureGenerator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.Not.Null);
            Assert.That(cleanedCreatures, Is.Not.Empty);
            Assert.That(cleanedCreatures, Is.EqualTo(creatures));

            var creature = cleanedCreatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("further subtype name"));
            Assert.That(creature.Type.SubType.SubType.Description, Is.EqualTo("further subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType, Is.Null);
        }

        [Test]
        public void CleanCreatures_CleanUpSetSubtypeWithFurtherSetSubtype()
        {
            var creatures = new[]
            {
                new Creature(),
            };

            creatures[0].Type.Name = "creature";

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(creatures[0].Type.Name)).Returns("creature name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creatures[0].Type.Name)).Returns("creature description");
            mockEncounterFormatter.Setup(s => s.SelectSubtypeFrom(creatures[0].Type.Name)).Returns("subtype");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("subtype")).Returns("subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("subtype")).Returns("subtype description");
            mockEncounterFormatter.Setup(s => s.SelectSubtypeFrom("subtype")).Returns("further subtype");
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("further subtype")).Returns("further subtype name");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom("further subtype")).Returns("further subtype description");

            var cleanedCreatures = creatureGenerator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.Not.Null);
            Assert.That(cleanedCreatures, Is.Not.Empty);
            Assert.That(cleanedCreatures, Is.EqualTo(creatures));

            var creature = cleanedCreatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("creature name"));
            Assert.That(creature.Type.Description, Is.EqualTo("creature description"));
            Assert.That(creature.Type.SubType.Name, Is.EqualTo("subtype name"));
            Assert.That(creature.Type.SubType.Description, Is.EqualTo("subtype description"));
            Assert.That(creature.Type.SubType.SubType.Name, Is.EqualTo("further subtype name"));
            Assert.That(creature.Type.SubType.SubType.Description, Is.EqualTo("further subtype description"));
            Assert.That(creature.Type.SubType.SubType.SubType, Is.Null);
        }

        [Test]
        public void CleanCreatures_IfCreatureHasSetMetarace_UseThatAsNameWhenCleaningUp()
        {
            var creatures = new[]
            {
                new Creature(),
            };

            creatures[0].Type.Name = "creature";

            mockEncounterFormatter.Setup(s => s.SelectMetaraceFrom(creatures[0].Type.Name)).Returns("metarace");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creatures[0].Type.Name)).Returns("description");

            var cleanedCreatures = creatureGenerator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.Not.Null);
            Assert.That(cleanedCreatures, Is.Not.Empty);
            Assert.That(cleanedCreatures, Is.EqualTo(creatures));

            var creature = cleanedCreatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("metarace"));
            Assert.That(creature.Type.Description, Is.EqualTo("description"));
            Assert.That(creature.Type.SubType, Is.Null);
        }

        [Test]
        public void CleanCreatures_IfCreatureHasSetBaseRace_UseThatAsNameWhenCleaningUp()
        {
            var creatures = new[]
            {
                new Creature(),
            };

            creatures[0].Type.Name = "creature";

            mockEncounterFormatter.Setup(s => s.SelectBaseRaceFrom(creatures[0].Type.Name)).Returns("base race");
            mockEncounterFormatter.Setup(s => s.SelectDescriptionFrom(creatures[0].Type.Name)).Returns("description");

            var cleanedCreatures = creatureGenerator.CleanCreatures(creatures);
            Assert.That(cleanedCreatures, Is.Not.Null);
            Assert.That(cleanedCreatures, Is.Not.Empty);
            Assert.That(cleanedCreatures, Is.EqualTo(creatures));

            var creature = cleanedCreatures.Single();
            Assert.That(creature.Type.Name, Is.EqualTo("base race"));
            Assert.That(creature.Type.Description, Is.EqualTo("description"));
            Assert.That(creature.Type.SubType, Is.Null);
        }
    }
}
