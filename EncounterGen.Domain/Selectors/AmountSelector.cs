﻿using EncounterGen.Common;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Selectors
{
    internal class AmountSelector : IAmountSelector
    {
        private const double EncounterLevelCoefficient = 2.885;

        private Dice dice;
        private ICollectionSelector collectionSelector;

        public AmountSelector(Dice dice, ICollectionSelector collectionSelector)
        {
            this.dice = dice;
            this.collectionSelector = collectionSelector;
        }

        public int SelectFrom(string amount)
        {
            return dice.Roll(amount).AsSum();
        }

        public int SelectAverageEncounterLevel(string encounter)
        {
            var encounterCreaturesAndAmounts = encounter.Split(',');
            var challengeRatingsAndAmounts = new Dictionary<string, string>();

            foreach (var creatureAndAmount in encounterCreaturesAndAmounts)
            {
                var sources = creatureAndAmount.Split('/');
                var creature = sources[0];
                var amount = sources[1];
                var challengeRating = collectionSelector.SelectFrom(TableNameConstants.ChallengeRatings, creature).Single();

                if (challengeRatingsAndAmounts.ContainsKey(challengeRating))
                    challengeRatingsAndAmounts[challengeRating] = $"{challengeRatingsAndAmounts[challengeRating]}+{amount}";
                else
                    challengeRatingsAndAmounts[challengeRating] = amount;
            }

            return ComputeAverageEncounterLevel(challengeRatingsAndAmounts);
        }

        private int ComputeAverageEncounterLevel(Dictionary<string, string> challengeRatingsAndAmounts)
        {
            var amountInOnes = 0.0;

            foreach (var challengeRatingAndAmount in challengeRatingsAndAmounts)
            {
                var challengeRating = challengeRatingAndAmount.Key;
                var amount = challengeRatingAndAmount.Value;
                var averageAmount = dice.Roll(amount).AsPotentialAverage();

                amountInOnes += ComputeAmountOfOnes(challengeRating, averageAmount);
            }

            return ComputeEncounterLevelForChallengeRatingOne(amountInOnes);
        }

        private double ComputeAmountOfOnes(string challengeRating, double amount)
        {
            if (challengeRating == ChallengeRatingConstants.Zero)
                return 0;

            if (challengeRating == ChallengeRatingConstants.One)
                return amount;

            var numericChallengeRating = 1;

            if (int.TryParse(challengeRating, out numericChallengeRating))
            {
                var exponent = numericChallengeRating / EncounterLevelCoefficient;
                var challengeRatingInOnes = Math.Pow(Math.E, exponent);

                return challengeRatingInOnes * amount;
            }

            var divisor = GetDivisor(challengeRating);
            return amount / divisor;
        }

        private double GetDivisor(string challengeRating)
        {
            switch (challengeRating)
            {
                case ChallengeRatingConstants.OneEighth: return 8;
                case ChallengeRatingConstants.OneFourth: return 4;
                case ChallengeRatingConstants.OneHalf: return 2;
                case ChallengeRatingConstants.OneSixth: return 6;
                case ChallengeRatingConstants.OneTenth: return 10;
                case ChallengeRatingConstants.OneThird: return 3;
                default: return 1;
            }
        }

        private int ComputeEncounterLevelForChallengeRatingOne(double amountInOnes)
        {
            var encounterLevel = 0.0;

            if (amountInOnes <= 1)
                encounterLevel = 1;
            else if (amountInOnes <= Math.E)
                encounterLevel = Math.Round(amountInOnes, MidpointRounding.AwayFromZero);
            else
                encounterLevel = EncounterLevelCoefficient * Math.Log(amountInOnes);

            return Convert.ToInt32(encounterLevel);
        }

        public int SelectEncounterLevel(IEnumerable<Creature> creatures)
        {
            var challengeRatingsAndAmounts = new Dictionary<string, int>();

            foreach (var creature in creatures)
            {
                if (challengeRatingsAndAmounts.ContainsKey(creature.ChallengeRating))
                    challengeRatingsAndAmounts[creature.ChallengeRating] += creature.Quantity;
                else
                    challengeRatingsAndAmounts[creature.ChallengeRating] = creature.Quantity;
            }

            var formattedChallengeRatingsAndAmounts = challengeRatingsAndAmounts.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToString());
            return ComputeAverageEncounterLevel(formattedChallengeRatingsAndAmounts);
        }
    }
}
