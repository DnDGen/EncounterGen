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

            fractionalChallengeRatings = new Dictionary<string, double>
            {
                [ChallengeRatingConstants.OneEighth] = 1 / 8d,
                [ChallengeRatingConstants.OneFourth] = 1 / 4d,
                [ChallengeRatingConstants.OneHalf] = 1 / 2d,
                [ChallengeRatingConstants.OneSixth] = 1 / 6d,
                [ChallengeRatingConstants.OneTenth] = 1 / 10d,
                [ChallengeRatingConstants.OneThird] = 1 / 3d
            };
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
            var challengeRating = collectionSelector.SelectFrom(Config.Name, TableNameConstants.AverageChallengeRatings, creature).Single();

            return challengeRating;
        }
    }
}
