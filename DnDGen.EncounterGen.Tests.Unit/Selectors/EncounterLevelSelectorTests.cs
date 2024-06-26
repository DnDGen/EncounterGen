﻿using DnDGen.CharacterGen.Characters;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class EncounterLevelSelectorTests
    {
        private IEncounterLevelSelector encounterLevelSelector;
        private Mock<IChallengeRatingSelector> mockChallengeRatingSelector;
        private Mock<IEncounterFormatter> mockEncounterFormatter;
        private Encounter encounter;

        [SetUp]
        public void Setup()
        {
            mockChallengeRatingSelector = new Mock<IChallengeRatingSelector>();
            mockEncounterFormatter = new Mock<IEncounterFormatter>();
            encounterLevelSelector = new EncounterLevelSelector(mockEncounterFormatter.Object, mockChallengeRatingSelector.Object);

            encounter = new Encounter();

            mockEncounterFormatter.Setup(s => s.SelectNameFrom(It.IsAny<string>())).Returns((string s) => s);
            mockChallengeRatingSelector.Setup(s => s.Select(It.IsAny<string>())).Returns((string s) => Parse(s));
            mockChallengeRatingSelector.Setup(s => s.Select(It.IsAny<double>())).Returns((double d) => Parse(d));
        }

        private double Parse(string challengeRating)
        {
            var output = 0.0;

            if (double.TryParse(challengeRating, out output))
                return output;

            var divisor = Convert.ToDouble(challengeRating.Split('/')[1]);
            return 1 / divisor;
        }

        private string Parse(double challengeRating)
        {
            var rounded = Convert.ToInt32(challengeRating);

            if (rounded == challengeRating)
                return rounded.ToString();

            var divisor = Convert.ToInt32(1 / challengeRating);
            return $"1/{divisor}";
        }

        [Test]
        public void SelectEncounterLevelForCreatures()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 90210, ChallengeRating = "42" }
            };

            var encounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(encounterLevel, Is.EqualTo(75));
        }

        [TestCase(ChallengeRatingConstants.OneTenth, 1, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 2, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 3, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 4, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 5, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 6, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 7, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 8, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 9, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 10, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 11, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 12, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 13, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 14, 1)]
        [TestCase(ChallengeRatingConstants.OneTenth, 15, 2)]
        [TestCase(ChallengeRatingConstants.OneTenth, 16, 2)]
        [TestCase(ChallengeRatingConstants.OneTenth, 17, 2)]
        [TestCase(ChallengeRatingConstants.OneTenth, 18, 2)]
        [TestCase(ChallengeRatingConstants.OneTenth, 19, 2)]
        [TestCase(ChallengeRatingConstants.OneTenth, 20, 2)]
        [TestCase(ChallengeRatingConstants.OneTenth, 21, 2)]
        [TestCase(ChallengeRatingConstants.OneTenth, 22, 2)]
        [TestCase(ChallengeRatingConstants.OneTenth, 23, 2)]
        [TestCase(ChallengeRatingConstants.OneTenth, 24, 2)]
        [TestCase(ChallengeRatingConstants.OneTenth, 25, 3)]
        [TestCase(ChallengeRatingConstants.OneTenth, 26, 3)]
        [TestCase(ChallengeRatingConstants.OneTenth, 27, 3)]
        [TestCase(ChallengeRatingConstants.OneTenth, 28, 3)]
        [TestCase(ChallengeRatingConstants.OneTenth, 29, 3)]
        [TestCase(ChallengeRatingConstants.OneTenth, 30, 3)]
        [TestCase(ChallengeRatingConstants.OneTenth, 31, 3)]
        [TestCase(ChallengeRatingConstants.OneTenth, 32, 3)]
        [TestCase(ChallengeRatingConstants.OneTenth, 33, 3)]
        [TestCase(ChallengeRatingConstants.OneTenth, 34, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 35, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 36, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 37, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 38, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 39, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 40, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 41, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 42, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 43, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 44, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 45, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 46, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 47, 4)]
        [TestCase(ChallengeRatingConstants.OneTenth, 48, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 49, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 50, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 51, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 52, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 53, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 54, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 55, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 56, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 57, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 58, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 59, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 60, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 61, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 62, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 63, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 64, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 65, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 66, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 67, 5)]
        [TestCase(ChallengeRatingConstants.OneTenth, 68, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 69, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 70, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 71, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 72, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 73, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 74, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 75, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 76, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 77, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 78, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 79, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 80, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 81, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 82, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 83, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 84, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 85, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 86, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 87, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 88, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 89, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 90, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 91, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 92, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 93, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 94, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 95, 6)]
        [TestCase(ChallengeRatingConstants.OneTenth, 96, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 97, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 98, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 99, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 100, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 101, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 102, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 103, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 104, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 105, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 106, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 107, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 108, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 109, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 110, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 111, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 112, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 113, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 114, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 115, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 116, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 117, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 118, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 119, 7)]
        [TestCase(ChallengeRatingConstants.OneTenth, 120, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 1, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 2, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 3, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 4, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 5, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 6, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 7, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 8, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 9, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 10, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 11, 1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 12, 2)]
        [TestCase(ChallengeRatingConstants.OneEighth, 13, 2)]
        [TestCase(ChallengeRatingConstants.OneEighth, 14, 2)]
        [TestCase(ChallengeRatingConstants.OneEighth, 15, 2)]
        [TestCase(ChallengeRatingConstants.OneEighth, 16, 2)]
        [TestCase(ChallengeRatingConstants.OneEighth, 17, 2)]
        [TestCase(ChallengeRatingConstants.OneEighth, 18, 2)]
        [TestCase(ChallengeRatingConstants.OneEighth, 19, 2)]
        [TestCase(ChallengeRatingConstants.OneEighth, 20, 3)]
        [TestCase(ChallengeRatingConstants.OneEighth, 21, 3)]
        [TestCase(ChallengeRatingConstants.OneEighth, 22, 3)]
        [TestCase(ChallengeRatingConstants.OneEighth, 23, 3)]
        [TestCase(ChallengeRatingConstants.OneEighth, 24, 3)]
        [TestCase(ChallengeRatingConstants.OneEighth, 25, 3)]
        [TestCase(ChallengeRatingConstants.OneEighth, 26, 3)]
        [TestCase(ChallengeRatingConstants.OneEighth, 27, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 28, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 29, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 30, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 31, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 32, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 33, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 34, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 35, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 36, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 37, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 38, 4)]
        [TestCase(ChallengeRatingConstants.OneEighth, 39, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 40, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 41, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 42, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 43, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 44, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 45, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 46, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 47, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 48, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 49, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 50, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 51, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 52, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 53, 5)]
        [TestCase(ChallengeRatingConstants.OneEighth, 54, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 55, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 56, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 57, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 58, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 59, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 60, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 61, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 62, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 63, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 64, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 65, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 66, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 67, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 68, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 69, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 70, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 71, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 72, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 73, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 74, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 75, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 76, 6)]
        [TestCase(ChallengeRatingConstants.OneEighth, 77, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 78, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 79, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 80, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 81, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 82, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 83, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 84, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 85, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 86, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 87, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 88, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 89, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 90, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 91, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 92, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 93, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 94, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 95, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 96, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 97, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 98, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 99, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 100, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 101, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 102, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 103, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 104, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 105, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 106, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 107, 7)]
        [TestCase(ChallengeRatingConstants.OneEighth, 108, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 109, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 110, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 111, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 112, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 113, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 114, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 115, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 116, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 117, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 118, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 119, 8)]
        [TestCase(ChallengeRatingConstants.OneEighth, 120, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 1, 1)]
        [TestCase(ChallengeRatingConstants.OneSixth, 2, 1)]
        [TestCase(ChallengeRatingConstants.OneSixth, 3, 1)]
        [TestCase(ChallengeRatingConstants.OneSixth, 4, 1)]
        [TestCase(ChallengeRatingConstants.OneSixth, 5, 1)]
        [TestCase(ChallengeRatingConstants.OneSixth, 6, 1)]
        [TestCase(ChallengeRatingConstants.OneSixth, 7, 1)]
        [TestCase(ChallengeRatingConstants.OneSixth, 8, 1)]
        [TestCase(ChallengeRatingConstants.OneSixth, 9, 2)]
        [TestCase(ChallengeRatingConstants.OneSixth, 10, 2)]
        [TestCase(ChallengeRatingConstants.OneSixth, 11, 2)]
        [TestCase(ChallengeRatingConstants.OneSixth, 12, 2)]
        [TestCase(ChallengeRatingConstants.OneSixth, 13, 2)]
        [TestCase(ChallengeRatingConstants.OneSixth, 14, 2)]
        [TestCase(ChallengeRatingConstants.OneSixth, 15, 3)]
        [TestCase(ChallengeRatingConstants.OneSixth, 16, 3)]
        [TestCase(ChallengeRatingConstants.OneSixth, 17, 3)]
        [TestCase(ChallengeRatingConstants.OneSixth, 18, 3)]
        [TestCase(ChallengeRatingConstants.OneSixth, 19, 3)]
        [TestCase(ChallengeRatingConstants.OneSixth, 20, 3)]
        [TestCase(ChallengeRatingConstants.OneSixth, 21, 4)]
        [TestCase(ChallengeRatingConstants.OneSixth, 22, 4)]
        [TestCase(ChallengeRatingConstants.OneSixth, 23, 4)]
        [TestCase(ChallengeRatingConstants.OneSixth, 24, 4)]
        [TestCase(ChallengeRatingConstants.OneSixth, 25, 4)]
        [TestCase(ChallengeRatingConstants.OneSixth, 26, 4)]
        [TestCase(ChallengeRatingConstants.OneSixth, 27, 4)]
        [TestCase(ChallengeRatingConstants.OneSixth, 28, 4)]
        [TestCase(ChallengeRatingConstants.OneSixth, 29, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 30, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 31, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 32, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 33, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 34, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 35, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 36, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 37, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 38, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 39, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 40, 5)]
        [TestCase(ChallengeRatingConstants.OneSixth, 41, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 42, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 43, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 44, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 45, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 46, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 47, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 48, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 49, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 50, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 51, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 52, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 53, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 54, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 55, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 56, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 57, 6)]
        [TestCase(ChallengeRatingConstants.OneSixth, 58, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 59, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 60, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 61, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 62, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 63, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 64, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 65, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 66, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 67, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 68, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 69, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 70, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 71, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 72, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 73, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 74, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 75, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 76, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 77, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 78, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 79, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 80, 7)]
        [TestCase(ChallengeRatingConstants.OneSixth, 81, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 82, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 83, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 84, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 85, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 86, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 87, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 88, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 89, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 90, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 91, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 92, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 93, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 94, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 95, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 96, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 97, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 98, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 99, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 100, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 101, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 102, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 103, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 104, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 105, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 106, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 107, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 108, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 109, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 110, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 111, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 112, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 113, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 114, 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 115, 9)]
        [TestCase(ChallengeRatingConstants.OneSixth, 116, 9)]
        [TestCase(ChallengeRatingConstants.OneSixth, 117, 9)]
        [TestCase(ChallengeRatingConstants.OneSixth, 118, 9)]
        [TestCase(ChallengeRatingConstants.OneSixth, 119, 9)]
        [TestCase(ChallengeRatingConstants.OneSixth, 120, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 1, 1)]
        [TestCase(ChallengeRatingConstants.OneFourth, 2, 1)]
        [TestCase(ChallengeRatingConstants.OneFourth, 3, 1)]
        [TestCase(ChallengeRatingConstants.OneFourth, 4, 1)]
        [TestCase(ChallengeRatingConstants.OneFourth, 5, 1)]
        [TestCase(ChallengeRatingConstants.OneFourth, 6, 2)]
        [TestCase(ChallengeRatingConstants.OneFourth, 7, 2)]
        [TestCase(ChallengeRatingConstants.OneFourth, 8, 2)]
        [TestCase(ChallengeRatingConstants.OneFourth, 9, 2)]
        [TestCase(ChallengeRatingConstants.OneFourth, 10, 3)]
        [TestCase(ChallengeRatingConstants.OneFourth, 11, 3)]
        [TestCase(ChallengeRatingConstants.OneFourth, 12, 3)]
        [TestCase(ChallengeRatingConstants.OneFourth, 13, 3)]
        [TestCase(ChallengeRatingConstants.OneFourth, 14, 4)]
        [TestCase(ChallengeRatingConstants.OneFourth, 15, 4)]
        [TestCase(ChallengeRatingConstants.OneFourth, 16, 4)]
        [TestCase(ChallengeRatingConstants.OneFourth, 17, 4)]
        [TestCase(ChallengeRatingConstants.OneFourth, 18, 4)]
        [TestCase(ChallengeRatingConstants.OneFourth, 19, 4)]
        [TestCase(ChallengeRatingConstants.OneFourth, 20, 5)]
        [TestCase(ChallengeRatingConstants.OneFourth, 21, 5)]
        [TestCase(ChallengeRatingConstants.OneFourth, 22, 5)]
        [TestCase(ChallengeRatingConstants.OneFourth, 23, 5)]
        [TestCase(ChallengeRatingConstants.OneFourth, 24, 5)]
        [TestCase(ChallengeRatingConstants.OneFourth, 25, 5)]
        [TestCase(ChallengeRatingConstants.OneFourth, 26, 5)]
        [TestCase(ChallengeRatingConstants.OneFourth, 27, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 28, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 29, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 30, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 31, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 32, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 33, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 34, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 35, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 36, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 37, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 38, 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, 39, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 40, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 41, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 42, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 43, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 44, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 45, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 46, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 47, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 48, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 49, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 50, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 51, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 52, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 53, 7)]
        [TestCase(ChallengeRatingConstants.OneFourth, 54, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 55, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 56, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 57, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 58, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 59, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 60, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 61, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 62, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 63, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 64, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 65, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 66, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 67, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 68, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 69, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 70, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 71, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 72, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 73, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 74, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 75, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 76, 8)]
        [TestCase(ChallengeRatingConstants.OneFourth, 77, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 78, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 79, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 80, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 81, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 82, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 83, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 84, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 85, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 86, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 87, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 88, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 89, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 90, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 91, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 92, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 93, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 94, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 95, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 96, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 97, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 98, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 99, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 100, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 101, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 102, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 103, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 104, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 105, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 106, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 107, 9)]
        [TestCase(ChallengeRatingConstants.OneFourth, 108, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 109, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 110, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 111, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 112, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 113, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 114, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 115, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 116, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 117, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 118, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 119, 10)]
        [TestCase(ChallengeRatingConstants.OneFourth, 120, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 1, 1)]
        [TestCase(ChallengeRatingConstants.OneThird, 2, 1)]
        [TestCase(ChallengeRatingConstants.OneThird, 3, 1)]
        [TestCase(ChallengeRatingConstants.OneThird, 4, 1)]
        [TestCase(ChallengeRatingConstants.OneThird, 5, 2)]
        [TestCase(ChallengeRatingConstants.OneThird, 6, 2)]
        [TestCase(ChallengeRatingConstants.OneThird, 7, 2)]
        [TestCase(ChallengeRatingConstants.OneThird, 8, 3)]
        [TestCase(ChallengeRatingConstants.OneThird, 9, 3)]
        [TestCase(ChallengeRatingConstants.OneThird, 10, 3)]
        [TestCase(ChallengeRatingConstants.OneThird, 11, 4)]
        [TestCase(ChallengeRatingConstants.OneThird, 12, 4)]
        [TestCase(ChallengeRatingConstants.OneThird, 13, 4)]
        [TestCase(ChallengeRatingConstants.OneThird, 14, 4)]
        [TestCase(ChallengeRatingConstants.OneThird, 15, 5)]
        [TestCase(ChallengeRatingConstants.OneThird, 16, 5)]
        [TestCase(ChallengeRatingConstants.OneThird, 17, 5)]
        [TestCase(ChallengeRatingConstants.OneThird, 18, 5)]
        [TestCase(ChallengeRatingConstants.OneThird, 19, 5)]
        [TestCase(ChallengeRatingConstants.OneThird, 20, 5)]
        [TestCase(ChallengeRatingConstants.OneThird, 21, 6)]
        [TestCase(ChallengeRatingConstants.OneThird, 22, 6)]
        [TestCase(ChallengeRatingConstants.OneThird, 23, 6)]
        [TestCase(ChallengeRatingConstants.OneThird, 24, 6)]
        [TestCase(ChallengeRatingConstants.OneThird, 25, 6)]
        [TestCase(ChallengeRatingConstants.OneThird, 26, 6)]
        [TestCase(ChallengeRatingConstants.OneThird, 27, 6)]
        [TestCase(ChallengeRatingConstants.OneThird, 28, 6)]
        [TestCase(ChallengeRatingConstants.OneThird, 29, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 30, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 31, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 32, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 33, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 34, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 35, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 36, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 37, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 38, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 39, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 40, 7)]
        [TestCase(ChallengeRatingConstants.OneThird, 41, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 42, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 43, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 44, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 45, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 46, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 47, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 48, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 49, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 50, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 51, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 52, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 53, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 54, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 55, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 56, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 57, 8)]
        [TestCase(ChallengeRatingConstants.OneThird, 58, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 59, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 60, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 61, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 62, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 63, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 64, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 65, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 66, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 67, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 68, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 69, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 70, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 71, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 72, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 73, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 74, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 75, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 76, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 77, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 78, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 79, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 80, 9)]
        [TestCase(ChallengeRatingConstants.OneThird, 81, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 82, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 83, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 84, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 85, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 86, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 87, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 88, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 89, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 90, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 91, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 92, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 93, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 94, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 95, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 96, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 97, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 98, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 99, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 100, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 101, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 102, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 103, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 104, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 105, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 106, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 107, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 108, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 109, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 110, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 111, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 112, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 113, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 114, 10)]
        [TestCase(ChallengeRatingConstants.OneThird, 115, 11)]
        [TestCase(ChallengeRatingConstants.OneThird, 116, 11)]
        [TestCase(ChallengeRatingConstants.OneThird, 117, 11)]
        [TestCase(ChallengeRatingConstants.OneThird, 118, 11)]
        [TestCase(ChallengeRatingConstants.OneThird, 119, 11)]
        [TestCase(ChallengeRatingConstants.OneThird, 120, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 1, 1)]
        [TestCase(ChallengeRatingConstants.OneHalf, 2, 1)]
        [TestCase(ChallengeRatingConstants.OneHalf, 3, 2)]
        [TestCase(ChallengeRatingConstants.OneHalf, 4, 2)]
        [TestCase(ChallengeRatingConstants.OneHalf, 5, 3)]
        [TestCase(ChallengeRatingConstants.OneHalf, 6, 3)]
        [TestCase(ChallengeRatingConstants.OneHalf, 7, 4)]
        [TestCase(ChallengeRatingConstants.OneHalf, 8, 4)]
        [TestCase(ChallengeRatingConstants.OneHalf, 9, 4)]
        [TestCase(ChallengeRatingConstants.OneHalf, 10, 5)]
        [TestCase(ChallengeRatingConstants.OneHalf, 11, 5)]
        [TestCase(ChallengeRatingConstants.OneHalf, 12, 5)]
        [TestCase(ChallengeRatingConstants.OneHalf, 13, 5)]
        [TestCase(ChallengeRatingConstants.OneHalf, 14, 6)]
        [TestCase(ChallengeRatingConstants.OneHalf, 15, 6)]
        [TestCase(ChallengeRatingConstants.OneHalf, 16, 6)]
        [TestCase(ChallengeRatingConstants.OneHalf, 17, 6)]
        [TestCase(ChallengeRatingConstants.OneHalf, 18, 6)]
        [TestCase(ChallengeRatingConstants.OneHalf, 19, 6)]
        [TestCase(ChallengeRatingConstants.OneHalf, 20, 7)]
        [TestCase(ChallengeRatingConstants.OneHalf, 21, 7)]
        [TestCase(ChallengeRatingConstants.OneHalf, 22, 7)]
        [TestCase(ChallengeRatingConstants.OneHalf, 23, 7)]
        [TestCase(ChallengeRatingConstants.OneHalf, 24, 7)]
        [TestCase(ChallengeRatingConstants.OneHalf, 25, 7)]
        [TestCase(ChallengeRatingConstants.OneHalf, 26, 7)]
        [TestCase(ChallengeRatingConstants.OneHalf, 27, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 28, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 29, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 30, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 31, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 32, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 33, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 34, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 35, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 36, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 37, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 38, 8)]
        [TestCase(ChallengeRatingConstants.OneHalf, 39, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 40, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 41, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 42, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 43, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 44, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 45, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 46, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 47, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 48, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 49, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 50, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 51, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 52, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 53, 9)]
        [TestCase(ChallengeRatingConstants.OneHalf, 54, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 55, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 56, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 57, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 58, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 59, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 60, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 61, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 62, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 63, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 64, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 65, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 66, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 67, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 68, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 69, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 70, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 71, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 72, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 73, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 74, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 75, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 76, 10)]
        [TestCase(ChallengeRatingConstants.OneHalf, 77, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 78, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 79, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 80, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 81, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 82, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 83, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 84, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 85, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 86, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 87, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 88, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 89, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 90, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 91, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 92, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 93, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 94, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 95, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 96, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 97, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 98, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 99, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 100, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 101, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 102, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 103, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 104, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 105, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 106, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 107, 11)]
        [TestCase(ChallengeRatingConstants.OneHalf, 108, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 109, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 110, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 111, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 112, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 113, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 114, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 115, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 116, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 117, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 118, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 119, 12)]
        [TestCase(ChallengeRatingConstants.OneHalf, 120, 12)]
        [TestCase(ChallengeRatingConstants.One, 1, 1)]
        [TestCase(ChallengeRatingConstants.One, 2, 2)]
        [TestCase(ChallengeRatingConstants.One, 3, 3)]
        [TestCase(ChallengeRatingConstants.One, 4, 4)]
        [TestCase(ChallengeRatingConstants.One, 5, 5)]
        [TestCase(ChallengeRatingConstants.One, 6, 5)]
        [TestCase(ChallengeRatingConstants.One, 7, 6)]
        [TestCase(ChallengeRatingConstants.One, 8, 6)]
        [TestCase(ChallengeRatingConstants.One, 9, 6)]
        [TestCase(ChallengeRatingConstants.One, 10, 7)]
        [TestCase(ChallengeRatingConstants.One, 11, 7)]
        [TestCase(ChallengeRatingConstants.One, 12, 7)]
        [TestCase(ChallengeRatingConstants.One, 13, 7)]
        [TestCase(ChallengeRatingConstants.One, 14, 8)]
        [TestCase(ChallengeRatingConstants.One, 15, 8)]
        [TestCase(ChallengeRatingConstants.One, 16, 8)]
        [TestCase(ChallengeRatingConstants.One, 17, 8)]
        [TestCase(ChallengeRatingConstants.One, 18, 8)]
        [TestCase(ChallengeRatingConstants.One, 19, 8)]
        [TestCase(ChallengeRatingConstants.One, 20, 9)]
        [TestCase(ChallengeRatingConstants.One, 21, 9)]
        [TestCase(ChallengeRatingConstants.One, 22, 9)]
        [TestCase(ChallengeRatingConstants.One, 23, 9)]
        [TestCase(ChallengeRatingConstants.One, 24, 9)]
        [TestCase(ChallengeRatingConstants.One, 25, 9)]
        [TestCase(ChallengeRatingConstants.One, 26, 9)]
        [TestCase(ChallengeRatingConstants.One, 27, 10)]
        [TestCase(ChallengeRatingConstants.One, 28, 10)]
        [TestCase(ChallengeRatingConstants.One, 29, 10)]
        [TestCase(ChallengeRatingConstants.One, 30, 10)]
        [TestCase(ChallengeRatingConstants.One, 31, 10)]
        [TestCase(ChallengeRatingConstants.One, 32, 10)]
        [TestCase(ChallengeRatingConstants.One, 33, 10)]
        [TestCase(ChallengeRatingConstants.One, 34, 10)]
        [TestCase(ChallengeRatingConstants.One, 35, 10)]
        [TestCase(ChallengeRatingConstants.One, 36, 10)]
        [TestCase(ChallengeRatingConstants.One, 37, 10)]
        [TestCase(ChallengeRatingConstants.One, 38, 10)]
        [TestCase(ChallengeRatingConstants.One, 39, 11)]
        [TestCase(ChallengeRatingConstants.One, 40, 11)]
        [TestCase(ChallengeRatingConstants.One, 41, 11)]
        [TestCase(ChallengeRatingConstants.One, 42, 11)]
        [TestCase(ChallengeRatingConstants.One, 43, 11)]
        [TestCase(ChallengeRatingConstants.One, 44, 11)]
        [TestCase(ChallengeRatingConstants.One, 45, 11)]
        [TestCase(ChallengeRatingConstants.One, 46, 11)]
        [TestCase(ChallengeRatingConstants.One, 47, 11)]
        [TestCase(ChallengeRatingConstants.One, 48, 11)]
        [TestCase(ChallengeRatingConstants.One, 49, 11)]
        [TestCase(ChallengeRatingConstants.One, 50, 11)]
        [TestCase(ChallengeRatingConstants.One, 51, 11)]
        [TestCase(ChallengeRatingConstants.One, 52, 11)]
        [TestCase(ChallengeRatingConstants.One, 53, 11)]
        [TestCase(ChallengeRatingConstants.One, 54, 12)]
        [TestCase(ChallengeRatingConstants.One, 55, 12)]
        [TestCase(ChallengeRatingConstants.One, 56, 12)]
        [TestCase(ChallengeRatingConstants.One, 57, 12)]
        [TestCase(ChallengeRatingConstants.One, 58, 12)]
        [TestCase(ChallengeRatingConstants.One, 59, 12)]
        [TestCase(ChallengeRatingConstants.One, 60, 12)]
        [TestCase(ChallengeRatingConstants.One, 61, 12)]
        [TestCase(ChallengeRatingConstants.One, 62, 12)]
        [TestCase(ChallengeRatingConstants.One, 63, 12)]
        [TestCase(ChallengeRatingConstants.One, 64, 12)]
        [TestCase(ChallengeRatingConstants.One, 65, 12)]
        [TestCase(ChallengeRatingConstants.One, 66, 12)]
        [TestCase(ChallengeRatingConstants.One, 67, 12)]
        [TestCase(ChallengeRatingConstants.One, 68, 12)]
        [TestCase(ChallengeRatingConstants.One, 69, 12)]
        [TestCase(ChallengeRatingConstants.One, 70, 12)]
        [TestCase(ChallengeRatingConstants.One, 71, 12)]
        [TestCase(ChallengeRatingConstants.One, 72, 12)]
        [TestCase(ChallengeRatingConstants.One, 73, 12)]
        [TestCase(ChallengeRatingConstants.One, 74, 12)]
        [TestCase(ChallengeRatingConstants.One, 75, 12)]
        [TestCase(ChallengeRatingConstants.One, 76, 12)]
        [TestCase(ChallengeRatingConstants.One, 77, 13)]
        [TestCase(ChallengeRatingConstants.One, 78, 13)]
        [TestCase(ChallengeRatingConstants.One, 79, 13)]
        [TestCase(ChallengeRatingConstants.One, 80, 13)]
        [TestCase(ChallengeRatingConstants.One, 81, 13)]
        [TestCase(ChallengeRatingConstants.One, 82, 13)]
        [TestCase(ChallengeRatingConstants.One, 83, 13)]
        [TestCase(ChallengeRatingConstants.One, 84, 13)]
        [TestCase(ChallengeRatingConstants.One, 85, 13)]
        [TestCase(ChallengeRatingConstants.One, 86, 13)]
        [TestCase(ChallengeRatingConstants.One, 87, 13)]
        [TestCase(ChallengeRatingConstants.One, 88, 13)]
        [TestCase(ChallengeRatingConstants.One, 89, 13)]
        [TestCase(ChallengeRatingConstants.One, 90, 13)]
        [TestCase(ChallengeRatingConstants.One, 91, 13)]
        [TestCase(ChallengeRatingConstants.One, 92, 13)]
        [TestCase(ChallengeRatingConstants.One, 93, 13)]
        [TestCase(ChallengeRatingConstants.One, 94, 13)]
        [TestCase(ChallengeRatingConstants.One, 95, 13)]
        [TestCase(ChallengeRatingConstants.One, 96, 13)]
        [TestCase(ChallengeRatingConstants.One, 97, 13)]
        [TestCase(ChallengeRatingConstants.One, 98, 13)]
        [TestCase(ChallengeRatingConstants.One, 99, 13)]
        [TestCase(ChallengeRatingConstants.One, 100, 13)]
        [TestCase(ChallengeRatingConstants.One, 101, 13)]
        [TestCase(ChallengeRatingConstants.One, 102, 13)]
        [TestCase(ChallengeRatingConstants.One, 103, 13)]
        [TestCase(ChallengeRatingConstants.One, 104, 13)]
        [TestCase(ChallengeRatingConstants.One, 105, 13)]
        [TestCase(ChallengeRatingConstants.One, 106, 13)]
        [TestCase(ChallengeRatingConstants.One, 107, 13)]
        [TestCase(ChallengeRatingConstants.One, 108, 14)]
        [TestCase(ChallengeRatingConstants.One, 109, 14)]
        [TestCase(ChallengeRatingConstants.One, 110, 14)]
        [TestCase(ChallengeRatingConstants.One, 111, 14)]
        [TestCase(ChallengeRatingConstants.One, 112, 14)]
        [TestCase(ChallengeRatingConstants.One, 113, 14)]
        [TestCase(ChallengeRatingConstants.One, 114, 14)]
        [TestCase(ChallengeRatingConstants.One, 115, 14)]
        [TestCase(ChallengeRatingConstants.One, 116, 14)]
        [TestCase(ChallengeRatingConstants.One, 117, 14)]
        [TestCase(ChallengeRatingConstants.One, 118, 14)]
        [TestCase(ChallengeRatingConstants.One, 119, 14)]
        [TestCase(ChallengeRatingConstants.One, 120, 14)]
        [TestCase(ChallengeRatingConstants.Two, 1, 2)]
        [TestCase(ChallengeRatingConstants.Two, 2, 4)]
        [TestCase(ChallengeRatingConstants.Two, 3, 5)]
        [TestCase(ChallengeRatingConstants.Two, 4, 6)]
        [TestCase(ChallengeRatingConstants.Two, 5, 7)]
        [TestCase(ChallengeRatingConstants.Two, 6, 7)]
        [TestCase(ChallengeRatingConstants.Two, 7, 8)]
        [TestCase(ChallengeRatingConstants.Two, 8, 8)]
        [TestCase(ChallengeRatingConstants.Two, 9, 8)]
        [TestCase(ChallengeRatingConstants.Two, 10, 9)]
        [TestCase(ChallengeRatingConstants.Two, 11, 9)]
        [TestCase(ChallengeRatingConstants.Two, 12, 9)]
        [TestCase(ChallengeRatingConstants.Two, 13, 9)]
        [TestCase(ChallengeRatingConstants.Two, 14, 10)]
        [TestCase(ChallengeRatingConstants.Two, 15, 10)]
        [TestCase(ChallengeRatingConstants.Two, 16, 10)]
        [TestCase(ChallengeRatingConstants.Two, 17, 10)]
        [TestCase(ChallengeRatingConstants.Two, 18, 10)]
        [TestCase(ChallengeRatingConstants.Two, 19, 10)]
        [TestCase(ChallengeRatingConstants.Two, 20, 11)]
        [TestCase(ChallengeRatingConstants.Two, 21, 11)]
        [TestCase(ChallengeRatingConstants.Two, 22, 11)]
        [TestCase(ChallengeRatingConstants.Two, 23, 11)]
        [TestCase(ChallengeRatingConstants.Two, 24, 11)]
        [TestCase(ChallengeRatingConstants.Two, 25, 11)]
        [TestCase(ChallengeRatingConstants.Two, 26, 11)]
        [TestCase(ChallengeRatingConstants.Two, 27, 12)]
        [TestCase(ChallengeRatingConstants.Two, 28, 12)]
        [TestCase(ChallengeRatingConstants.Two, 29, 12)]
        [TestCase(ChallengeRatingConstants.Two, 30, 12)]
        [TestCase(ChallengeRatingConstants.Two, 31, 12)]
        [TestCase(ChallengeRatingConstants.Two, 32, 12)]
        [TestCase(ChallengeRatingConstants.Two, 33, 12)]
        [TestCase(ChallengeRatingConstants.Two, 34, 12)]
        [TestCase(ChallengeRatingConstants.Two, 35, 12)]
        [TestCase(ChallengeRatingConstants.Two, 36, 12)]
        [TestCase(ChallengeRatingConstants.Two, 37, 12)]
        [TestCase(ChallengeRatingConstants.Two, 38, 12)]
        [TestCase(ChallengeRatingConstants.Two, 39, 13)]
        [TestCase(ChallengeRatingConstants.Two, 40, 13)]
        [TestCase(ChallengeRatingConstants.Two, 41, 13)]
        [TestCase(ChallengeRatingConstants.Two, 42, 13)]
        [TestCase(ChallengeRatingConstants.Two, 43, 13)]
        [TestCase(ChallengeRatingConstants.Two, 44, 13)]
        [TestCase(ChallengeRatingConstants.Two, 45, 13)]
        [TestCase(ChallengeRatingConstants.Two, 46, 13)]
        [TestCase(ChallengeRatingConstants.Two, 47, 13)]
        [TestCase(ChallengeRatingConstants.Two, 48, 13)]
        [TestCase(ChallengeRatingConstants.Two, 49, 13)]
        [TestCase(ChallengeRatingConstants.Two, 50, 13)]
        [TestCase(ChallengeRatingConstants.Two, 51, 13)]
        [TestCase(ChallengeRatingConstants.Two, 52, 13)]
        [TestCase(ChallengeRatingConstants.Two, 53, 13)]
        [TestCase(ChallengeRatingConstants.Two, 54, 14)]
        [TestCase(ChallengeRatingConstants.Two, 55, 14)]
        [TestCase(ChallengeRatingConstants.Two, 56, 14)]
        [TestCase(ChallengeRatingConstants.Two, 57, 14)]
        [TestCase(ChallengeRatingConstants.Two, 58, 14)]
        [TestCase(ChallengeRatingConstants.Two, 59, 14)]
        [TestCase(ChallengeRatingConstants.Two, 60, 14)]
        [TestCase(ChallengeRatingConstants.Two, 61, 14)]
        [TestCase(ChallengeRatingConstants.Two, 62, 14)]
        [TestCase(ChallengeRatingConstants.Two, 63, 14)]
        [TestCase(ChallengeRatingConstants.Two, 64, 14)]
        [TestCase(ChallengeRatingConstants.Two, 65, 14)]
        [TestCase(ChallengeRatingConstants.Two, 66, 14)]
        [TestCase(ChallengeRatingConstants.Two, 67, 14)]
        [TestCase(ChallengeRatingConstants.Two, 68, 14)]
        [TestCase(ChallengeRatingConstants.Two, 69, 14)]
        [TestCase(ChallengeRatingConstants.Two, 70, 14)]
        [TestCase(ChallengeRatingConstants.Two, 71, 14)]
        [TestCase(ChallengeRatingConstants.Two, 72, 14)]
        [TestCase(ChallengeRatingConstants.Two, 73, 14)]
        [TestCase(ChallengeRatingConstants.Two, 74, 14)]
        [TestCase(ChallengeRatingConstants.Two, 75, 14)]
        [TestCase(ChallengeRatingConstants.Two, 76, 14)]
        [TestCase(ChallengeRatingConstants.Two, 77, 15)]
        [TestCase(ChallengeRatingConstants.Two, 78, 15)]
        [TestCase(ChallengeRatingConstants.Two, 79, 15)]
        [TestCase(ChallengeRatingConstants.Two, 80, 15)]
        [TestCase(ChallengeRatingConstants.Two, 81, 15)]
        [TestCase(ChallengeRatingConstants.Two, 82, 15)]
        [TestCase(ChallengeRatingConstants.Two, 83, 15)]
        [TestCase(ChallengeRatingConstants.Two, 84, 15)]
        [TestCase(ChallengeRatingConstants.Two, 85, 15)]
        [TestCase(ChallengeRatingConstants.Two, 86, 15)]
        [TestCase(ChallengeRatingConstants.Two, 87, 15)]
        [TestCase(ChallengeRatingConstants.Two, 88, 15)]
        [TestCase(ChallengeRatingConstants.Two, 89, 15)]
        [TestCase(ChallengeRatingConstants.Two, 90, 15)]
        [TestCase(ChallengeRatingConstants.Two, 91, 15)]
        [TestCase(ChallengeRatingConstants.Two, 92, 15)]
        [TestCase(ChallengeRatingConstants.Two, 93, 15)]
        [TestCase(ChallengeRatingConstants.Two, 94, 15)]
        [TestCase(ChallengeRatingConstants.Two, 95, 15)]
        [TestCase(ChallengeRatingConstants.Two, 96, 15)]
        [TestCase(ChallengeRatingConstants.Two, 97, 15)]
        [TestCase(ChallengeRatingConstants.Two, 98, 15)]
        [TestCase(ChallengeRatingConstants.Two, 99, 15)]
        [TestCase(ChallengeRatingConstants.Two, 100, 15)]
        [TestCase(ChallengeRatingConstants.Two, 101, 15)]
        [TestCase(ChallengeRatingConstants.Two, 102, 15)]
        [TestCase(ChallengeRatingConstants.Two, 103, 15)]
        [TestCase(ChallengeRatingConstants.Two, 104, 15)]
        [TestCase(ChallengeRatingConstants.Two, 105, 15)]
        [TestCase(ChallengeRatingConstants.Two, 106, 15)]
        [TestCase(ChallengeRatingConstants.Two, 107, 15)]
        [TestCase(ChallengeRatingConstants.Two, 108, 16)]
        [TestCase(ChallengeRatingConstants.Two, 109, 16)]
        [TestCase(ChallengeRatingConstants.Two, 110, 16)]
        [TestCase(ChallengeRatingConstants.Two, 111, 16)]
        [TestCase(ChallengeRatingConstants.Two, 112, 16)]
        [TestCase(ChallengeRatingConstants.Two, 113, 16)]
        [TestCase(ChallengeRatingConstants.Two, 114, 16)]
        [TestCase(ChallengeRatingConstants.Two, 115, 16)]
        [TestCase(ChallengeRatingConstants.Two, 116, 16)]
        [TestCase(ChallengeRatingConstants.Two, 117, 16)]
        [TestCase(ChallengeRatingConstants.Two, 118, 16)]
        [TestCase(ChallengeRatingConstants.Two, 119, 16)]
        [TestCase(ChallengeRatingConstants.Two, 120, 16)]
        public void ComputeEncounterLevelForCreatures(string challengeRating, int quantity, int encounterLevel)
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = quantity, ChallengeRating = challengeRating }
            };

            var computedEncounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(computedEncounterLevel, Is.EqualTo(encounterLevel));
        }

        [TestCase(ChallengeRatingConstants.Three)]
        [TestCase(ChallengeRatingConstants.Four)]
        [TestCase(ChallengeRatingConstants.Five)]
        [TestCase(ChallengeRatingConstants.Six)]
        [TestCase(ChallengeRatingConstants.Seven)]
        [TestCase(ChallengeRatingConstants.Eight)]
        [TestCase(ChallengeRatingConstants.Nine)]
        [TestCase(ChallengeRatingConstants.Ten)]
        [TestCase(ChallengeRatingConstants.Eleven)]
        [TestCase(ChallengeRatingConstants.Twelve)]
        [TestCase(ChallengeRatingConstants.Thirteen)]
        [TestCase(ChallengeRatingConstants.Fourteen)]
        [TestCase(ChallengeRatingConstants.Fifteen)]
        [TestCase(ChallengeRatingConstants.Sixteen)]
        [TestCase(ChallengeRatingConstants.Seventeen)]
        [TestCase(ChallengeRatingConstants.Eighteen)]
        [TestCase(ChallengeRatingConstants.Nineteen)]
        [TestCase(ChallengeRatingConstants.Twenty)]
        [TestCase(ChallengeRatingConstants.TwentyOne)]
        [TestCase(ChallengeRatingConstants.TwentyTwo)]
        [TestCase(ChallengeRatingConstants.TwentyThree)]
        [TestCase(ChallengeRatingConstants.TwentyFour)]
        [TestCase(ChallengeRatingConstants.TwentyFive)]
        [TestCase(ChallengeRatingConstants.TwentySix)]
        [TestCase(ChallengeRatingConstants.TwentySeven)]
        [TestCase(ChallengeRatingConstants.TwentyEight)]
        [TestCase(ChallengeRatingConstants.TwentyNine)]
        [TestCase(ChallengeRatingConstants.Thirty)]
        public void ChallengeRatingHigherThan2ForCreaturesFollowsEncounterLevelForChallengeRating2(string challengeRating)
        {
            var numericChallengeRating = Convert.ToInt32(challengeRating);
            var difference = numericChallengeRating - 2;

            var creature = new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 0, ChallengeRating = challengeRating };
            var cr2Creature = new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 0, ChallengeRating = ChallengeRatingConstants.Two };
            encounter.Creatures = new[] { creature };

            var cr2Encounter = new Encounter();
            cr2Encounter.Creatures = new[] { cr2Creature };

            for (var quantity = 1; quantity <= 120; quantity++)
            {
                creature.Quantity = quantity;
                cr2Creature.Quantity = quantity;

                var crTwoEncounterLevel = encounterLevelSelector.Select(cr2Encounter);
                var encounterLevel = encounterLevelSelector.Select(encounter);

                Assert.That(encounterLevel, Is.EqualTo(crTwoEncounterLevel + difference), $"Quantity {quantity} failed for challenge rating {challengeRating}");
            }
        }

        [Test]
        public void SelectEncounterLevelFromMultipleCreatueres()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 90210, ChallengeRating = "42" },
                new EncounterCreature { Creature = new Creature { Name = "other creature" }, Quantity = 1337, ChallengeRating = "600" },
            };

            var encounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(encounterLevel, Is.EqualTo(621));
        }

        [Test]
        public void SelectEncounterLevelFromMultipleCreatueresOfSameChallengeRating()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 90210, ChallengeRating = "42" },
                new EncounterCreature { Creature = new Creature { Name = "other creature" }, Quantity = 1337, ChallengeRating = "42" },
            };

            var encounterLevel = encounterLevelSelector.Select(encounter);

            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 90210 + 1337, ChallengeRating = "42" },
            };

            var doubledEncounterLevel = encounterLevelSelector.Select(encounter);

            Assert.That(encounterLevel, Is.EqualTo(doubledEncounterLevel));
            Assert.That(encounterLevel, Is.EqualTo(75));
        }

        [Test]
        public void ChallengeRatingOfZeroFromCreatureDoesNotAffectEncounterLevel()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 1, ChallengeRating = ChallengeRatingConstants.One },
                new EncounterCreature { Creature = new Creature { Name = "other creature" }, Quantity = 100, ChallengeRating = ChallengeRatingConstants.Zero },
            };

            var encounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(encounterLevel, Is.EqualTo(1));
        }

        [Test]
        public void AmountOfZeroFromCreatureDoesNotAffectEncounterLevel()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 1, ChallengeRating = ChallengeRatingConstants.One },
                new EncounterCreature { Creature = new Creature { Name = "other creature" }, Quantity = 0, ChallengeRating = "42" },
            };

            var encounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(encounterLevel, Is.EqualTo(1));
        }

        [Test]
        public void NegativeAmountFromCreatureDoesNotAffectEncounterLevel()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 1, ChallengeRating = ChallengeRatingConstants.One },
                new EncounterCreature { Creature = new Creature { Name = "other creature" }, Quantity = -1, ChallengeRating = "42" },
            };

            var encounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(encounterLevel, Is.EqualTo(1));
        }

        [Test]
        public void NegativeAmountFromCreatureOfSameChallengeRatingDoesNotAffectEncounterLevel()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 2, ChallengeRating = ChallengeRatingConstants.One },
                new EncounterCreature { Creature = new Creature { Name = "other creature" }, Quantity = -1, ChallengeRating = ChallengeRatingConstants.One },
            };

            var encounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(encounterLevel, Is.EqualTo(2));
        }

        [Test]
        public void GetEncounterLevelFromCharacters()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = CreatureDataConstants.Character }, Quantity = 90210, ChallengeRating = "42" },
                new EncounterCreature { Creature = new Creature { Name = CreatureDataConstants.Character }, Quantity = 1337, ChallengeRating = "600" },
            };

            encounter.Characters = new[]
            {
                new Character(),
                new Character(),
            };

            encounter.Characters.First().Class.Level = 92;
            encounter.Characters.First().Class.IsNPC = true;
            encounter.Characters.Last().Class.Level = 66;
            encounter.Characters.Last().Race.ChallengeRating = 123;

            var encounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(encounterLevel, Is.EqualTo(189));
        }

        [Test]
        public void GetEncounterLevelFromDirtyCharacters()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 90210, ChallengeRating = "42" },
                new EncounterCreature { Creature = new Creature { Name = "other creature" }, Quantity = 1337, ChallengeRating = "600" },
            };

            encounter.Characters = new[]
            {
                new Character(),
                new Character(),
            };

            encounter.Characters.First().Class.Level = 92;
            encounter.Characters.First().Class.IsNPC = true;
            encounter.Characters.Last().Class.Level = 66;
            encounter.Characters.Last().Race.ChallengeRating = 123;

            mockEncounterFormatter.Setup(s => s.SelectNameFrom("creature")).Returns(CreatureDataConstants.Character);
            mockEncounterFormatter.Setup(s => s.SelectNameFrom("other creature")).Returns(CreatureDataConstants.Character);

            var encounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(encounterLevel, Is.EqualTo(189));
        }

        [Test]
        public void GetEncounterLevelFromCharactersAndCreatures()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature { Name = "creature" }, Quantity = 90, ChallengeRating = "21" },
                new EncounterCreature { Creature = new Creature { Name = "other creature" }, Quantity = 13, ChallengeRating = "37" },
                new EncounterCreature { Creature = new Creature { Name = CreatureDataConstants.Character }, Quantity = 12, ChallengeRating = "34" },
                new EncounterCreature { Creature = new Creature { Name = CreatureDataConstants.Character }, Quantity = 23, ChallengeRating = "45" },
            };

            encounter.Characters = new[]
            {
                new Character(),
                new Character(),
            };

            encounter.Characters.First().Class.Level = 42;
            encounter.Characters.First().Class.IsNPC = true;
            encounter.Characters.Last().Class.Level = 60;
            encounter.Characters.Last().Race.ChallengeRating = 56;

            var encounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(encounterLevel, Is.EqualTo(116));
        }

        [Test]
        public void GetEncounterLevelForCharacterSubtypes()
        {
            encounter.Creatures = new[]
            {
                new EncounterCreature { Creature = new Creature 
                { 
                    Name = "creature", 
                    SubCreature = new Creature { Name = CreatureDataConstants.Character } },
                    Quantity = 90210, 
                    ChallengeRating = "42"
                },
                new EncounterCreature { Creature = new Creature 
                { 
                    Name = "creature",
                    SubCreature = new Creature { Name = CreatureDataConstants.Character } },
                    Quantity = 1337, 
                    ChallengeRating = "600"
                },
            };

            encounter.Characters = new[]
            {
                new Character(),
                new Character(),
            };

            encounter.Characters.First().Class.Level = 92;
            encounter.Characters.First().Class.IsNPC = true;
            encounter.Characters.Last().Class.Level = 66;
            encounter.Characters.Last().Race.ChallengeRating = 123;

            var encounterLevel = encounterLevelSelector.Select(encounter);
            Assert.That(encounterLevel, Is.EqualTo(189));
        }
    }
}