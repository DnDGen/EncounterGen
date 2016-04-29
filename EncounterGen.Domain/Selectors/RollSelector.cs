using EncounterGen.Domain.Tables;
using RollGen;
using System.Linq;

namespace EncounterGen.Domain.Selectors
{
    internal class RollSelector : IRollSelector
    {
        private ICollectionSelector collectionSelector;
        private Dice dice;

        public RollSelector(ICollectionSelector collectionSelector, Dice dice)
        {
            this.collectionSelector = collectionSelector;
            this.dice = dice;
        }

        public string SelectFrom(int effectiveLevel, string challengeRating)
        {
            var challengeRatings = collectionSelector.SelectFrom(TableNameConstants.RollOrder, "CR").ToList();

            var levelIndex = challengeRatings.IndexOf(effectiveLevel.ToString());
            var challengeRatingIndex = challengeRatings.IndexOf(challengeRating);
            var modifer = levelIndex - challengeRatingIndex;

            return SelectFrom(RollConstants.One, modifer);
        }

        public string SelectFrom(string baseRoll, int modifier)
        {
            if (baseRoll == RollConstants.Reroll)
                return baseRoll;

            var rolls = collectionSelector.SelectFrom(TableNameConstants.RollOrder, "All").ToList();
            var index = rolls.LastIndexOf(baseRoll);

            var modifiedIndex = index + modifier;

            if (modifiedIndex > rolls.Count - 1 || modifiedIndex < 0)
                return RollConstants.Reroll;

            return rolls[modifiedIndex];
        }
    }
}
