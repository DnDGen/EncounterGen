using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Collections;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class ChallengeRatingSelectorTests
    {
        private IChallengeRatingSelector challengeRatingSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;

        [SetUp]
        public void Setup()
        {
            mockCollectionSelector = new Mock<ICollectionSelector>();
            challengeRatingSelector = new ChallengeRatingSelector(mockCollectionSelector.Object);
        }

        [Test]
        public void SelectAverageChallengeRatingForCreature()
        {
            var creature = Guid.NewGuid().ToString();
            var averageChallengeRating = Guid.NewGuid().ToString();
            mockCollectionSelector.Setup(s => s.SelectFrom(Config.Name, TableNameConstants.AverageChallengeRatings, creature)).Returns([averageChallengeRating]);

            var challengeRating = challengeRatingSelector.SelectAverageForCreature(creature);
            Assert.That(challengeRating, Is.EqualTo(averageChallengeRating));
        }

        [Test]
        public void ThrowExceptionIfNoChallengeRating()
        {
            var creature = Guid.NewGuid().ToString();
            mockCollectionSelector.Setup(s => s.SelectFrom(Config.Name, TableNameConstants.AverageChallengeRatings, creature)).Returns(Enumerable.Empty<string>());

            Assert.That(() => challengeRatingSelector.SelectAverageForCreature(creature), Throws.Exception);
        }

        [Test]
        public void ThrowExceptionIfMultipleChallengeRatings()
        {
            var creature = Guid.NewGuid().ToString();
            var averageChallengeRating = Guid.NewGuid().ToString();
            mockCollectionSelector
                .Setup(s => s.SelectFrom(Config.Name, TableNameConstants.AverageChallengeRatings, creature))
                .Returns([averageChallengeRating, "other challenge rating"]);

            Assert.That(() => challengeRatingSelector.SelectAverageForCreature(creature), Throws.Exception);
        }

        [TestCase(ChallengeRatingConstants.OneTenth, .1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 1d / 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 1d / 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, .25)]
        [TestCase(ChallengeRatingConstants.OneThird, 1d / 3)]
        [TestCase(ChallengeRatingConstants.OneHalf, .5)]
        [TestCase(ChallengeRatingConstants.One, 1)]
        [TestCase(ChallengeRatingConstants.Two, 2)]
        [TestCase(ChallengeRatingConstants.Three, 3)]
        [TestCase(ChallengeRatingConstants.Four, 4)]
        [TestCase(ChallengeRatingConstants.Five, 5)]
        [TestCase(ChallengeRatingConstants.Six, 6)]
        [TestCase(ChallengeRatingConstants.Seven, 7)]
        [TestCase(ChallengeRatingConstants.Eight, 8)]
        [TestCase(ChallengeRatingConstants.Nine, 9)]
        [TestCase(ChallengeRatingConstants.Ten, 10)]
        [TestCase(ChallengeRatingConstants.Eleven, 11)]
        [TestCase(ChallengeRatingConstants.Twelve, 12)]
        [TestCase(ChallengeRatingConstants.Thirteen, 13)]
        [TestCase(ChallengeRatingConstants.Fourteen, 14)]
        [TestCase(ChallengeRatingConstants.Fifteen, 15)]
        [TestCase(ChallengeRatingConstants.Sixteen, 16)]
        [TestCase(ChallengeRatingConstants.Seventeen, 17)]
        [TestCase(ChallengeRatingConstants.Eighteen, 18)]
        [TestCase(ChallengeRatingConstants.Nineteen, 19)]
        [TestCase(ChallengeRatingConstants.Twenty, 20)]
        [TestCase(ChallengeRatingConstants.TwentyOne, 21)]
        [TestCase(ChallengeRatingConstants.TwentyTwo, 22)]
        [TestCase(ChallengeRatingConstants.TwentyThree, 23)]
        [TestCase(ChallengeRatingConstants.TwentyFour, 24)]
        [TestCase(ChallengeRatingConstants.TwentyFive, 25)]
        [TestCase(ChallengeRatingConstants.TwentySix, 26)]
        [TestCase(ChallengeRatingConstants.TwentySeven, 27)]
        [TestCase(ChallengeRatingConstants.TwentyEight, 28)]
        [TestCase(ChallengeRatingConstants.TwentyNine, 29)]
        [TestCase(ChallengeRatingConstants.Thirty, 30)]
        public void SelectNumericChallengeRating(string challengeRating, double numericChallengeRating)
        {
            var result = challengeRatingSelector.Select(challengeRating);
            Assert.That(result, Is.EqualTo(numericChallengeRating));
        }

        [TestCase(ChallengeRatingConstants.OneTenth, .1)]
        [TestCase(ChallengeRatingConstants.OneEighth, 1d / 8)]
        [TestCase(ChallengeRatingConstants.OneSixth, 1d / 6)]
        [TestCase(ChallengeRatingConstants.OneFourth, .25)]
        [TestCase(ChallengeRatingConstants.OneThird, 1d / 3)]
        [TestCase(ChallengeRatingConstants.OneHalf, .5)]
        [TestCase(ChallengeRatingConstants.One, 1)]
        [TestCase(ChallengeRatingConstants.Two, 2)]
        [TestCase(ChallengeRatingConstants.Three, 3)]
        [TestCase(ChallengeRatingConstants.Four, 4)]
        [TestCase(ChallengeRatingConstants.Five, 5)]
        [TestCase(ChallengeRatingConstants.Six, 6)]
        [TestCase(ChallengeRatingConstants.Seven, 7)]
        [TestCase(ChallengeRatingConstants.Eight, 8)]
        [TestCase(ChallengeRatingConstants.Nine, 9)]
        [TestCase(ChallengeRatingConstants.Ten, 10)]
        [TestCase(ChallengeRatingConstants.Eleven, 11)]
        [TestCase(ChallengeRatingConstants.Twelve, 12)]
        [TestCase(ChallengeRatingConstants.Thirteen, 13)]
        [TestCase(ChallengeRatingConstants.Fourteen, 14)]
        [TestCase(ChallengeRatingConstants.Fifteen, 15)]
        [TestCase(ChallengeRatingConstants.Sixteen, 16)]
        [TestCase(ChallengeRatingConstants.Seventeen, 17)]
        [TestCase(ChallengeRatingConstants.Eighteen, 18)]
        [TestCase(ChallengeRatingConstants.Nineteen, 19)]
        [TestCase(ChallengeRatingConstants.Twenty, 20)]
        [TestCase(ChallengeRatingConstants.TwentyOne, 21)]
        [TestCase(ChallengeRatingConstants.TwentyTwo, 22)]
        [TestCase(ChallengeRatingConstants.TwentyThree, 23)]
        [TestCase(ChallengeRatingConstants.TwentyFour, 24)]
        [TestCase(ChallengeRatingConstants.TwentyFive, 25)]
        [TestCase(ChallengeRatingConstants.TwentySix, 26)]
        [TestCase(ChallengeRatingConstants.TwentySeven, 27)]
        [TestCase(ChallengeRatingConstants.TwentyEight, 28)]
        [TestCase(ChallengeRatingConstants.TwentyNine, 29)]
        [TestCase(ChallengeRatingConstants.Thirty, 30)]
        public void SelectStringChallengeRating(string challengeRating, double numericChallengeRating)
        {
            var result = challengeRatingSelector.Select(numericChallengeRating);
            Assert.That(result, Is.EqualTo(challengeRating));
        }
    }
}
