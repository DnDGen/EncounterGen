using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Selectors
{
    internal class ChallengeRatingSelector : IChallengeRatingSelector
    {
        private readonly ICollectionSelector collectionSelector;
        private readonly Dictionary<string, double> fractionalChallengeRatings;

        public ChallengeRatingSelector(ICollectionSelector collectionSelector)
        {
            this.collectionSelector = collectionSelector;

            fractionalChallengeRatings = new Dictionary<string, double>();
            fractionalChallengeRatings[ChallengeRatingConstants.OneEighth] = 1 / 8d;
            fractionalChallengeRatings[ChallengeRatingConstants.OneFourth] = 1 / 4d;
            fractionalChallengeRatings[ChallengeRatingConstants.OneHalf] = 1 / 2d;
            fractionalChallengeRatings[ChallengeRatingConstants.OneSixth] = 1 / 6d;
            fractionalChallengeRatings[ChallengeRatingConstants.OneTenth] = 1 / 10d;
            fractionalChallengeRatings[ChallengeRatingConstants.OneThird] = 1 / 3d;
        }

        public string Select(double numericChallengeRating)
        {
            if (fractionalChallengeRatings.Any(kvp => kvp.Value == numericChallengeRating))
                return fractionalChallengeRatings.First(kvp => kvp.Value == numericChallengeRating).Key;

            return Convert.ToInt32(numericChallengeRating).ToString();
        }

        public double Select(string challengeRating)
        {
            if (fractionalChallengeRatings.ContainsKey(challengeRating))
                return fractionalChallengeRatings[challengeRating];

            return Convert.ToDouble(challengeRating);
        }

        public string SelectAverageForCreature(string creature)
        {
            var challengeRating = collectionSelector.SelectFrom(TableNameConstants.AverageChallengeRatings, creature).Single();

            return challengeRating;
        }
    }
}
