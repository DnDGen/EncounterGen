using DnDGen.EncounterGen.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Selectors
{
    internal class EncounterLevelSelector : IEncounterLevelSelector
    {
        private const double EncounterLevelCoefficient = 2.885;

        private readonly IEncounterFormatter encounterFormatter;
        private readonly IChallengeRatingSelector challengeRatingSelector;

        public EncounterLevelSelector(IEncounterFormatter encounterFormatter, IChallengeRatingSelector challengeRatingSelector)
        {
            this.encounterFormatter = encounterFormatter;
            this.challengeRatingSelector = challengeRatingSelector;
        }

        public int Select(Encounter encounter)
        {
            var challengeRatingsAndAmounts = new Dictionary<string, double>();
            var nonCharacterCreatures = encounter.Creatures.Where(c => !IsCharacter(c.Type));

            foreach (var creature in nonCharacterCreatures)
            {
                if (!challengeRatingsAndAmounts.ContainsKey(creature.ChallengeRating))
                    challengeRatingsAndAmounts[creature.ChallengeRating] = 0;

                challengeRatingsAndAmounts[creature.ChallengeRating] += Math.Max(creature.Quantity, 0);
            }

            foreach (var character in encounter.Characters)
            {
                var characterChallengeRating = challengeRatingSelector.Select(character.ChallengeRating);

                if (!challengeRatingsAndAmounts.ContainsKey(characterChallengeRating))
                    challengeRatingsAndAmounts[characterChallengeRating] = 0;

                challengeRatingsAndAmounts[characterChallengeRating]++;
            }

            return ComputeEncounterLevel(challengeRatingsAndAmounts);
        }

        private int ComputeEncounterLevel(Dictionary<string, double> challengeRatingsAndAmounts)
        {
            var amountInOnes = 0.0;

            foreach (var challengeRatingAndAmount in challengeRatingsAndAmounts)
            {
                var challengeRating = challengeRatingAndAmount.Key;
                var amount = challengeRatingAndAmount.Value;

                amountInOnes += ComputeAmountOfOnes(challengeRating, amount);
            }

            return ComputeEncounterLevelForChallengeRatingOne(amountInOnes);
        }

        private double ComputeAmountOfOnes(string challengeRating, double amount)
        {
            var challengeRatingInOnes = challengeRatingSelector.Select(challengeRating);

            if (challengeRatingInOnes > 1)
            {
                var exponent = challengeRatingInOnes / EncounterLevelCoefficient;
                challengeRatingInOnes = Math.Pow(Math.E, exponent);
            }

            return amount * challengeRatingInOnes;
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

        private bool IsCharacter(CreatureType creatureType)
        {
            if (creatureType == null)
                return false;

            var name = encounterFormatter.SelectNameFrom(creatureType.Name);
            if (name == CreatureConstants.Character)
                return true;

            return IsCharacter(creatureType.SubType);
        }
    }
}
