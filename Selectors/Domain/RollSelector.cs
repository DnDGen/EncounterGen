using EncounterGen.Tables;
using RollGen;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace EncounterGen.Selectors.Domain
{
    public class RollSelector : IRollSelector
    {
        private ICollectionSelector collectionSelector;
        private Dice dice;
        private Regex rollRegex;

        public RollSelector(ICollectionSelector collectionSelector, Dice dice)
        {
            this.collectionSelector = collectionSelector;
            this.dice = dice;

            rollRegex = new Regex("\\d+d\\d+(\\+\\d+)*");
        }

        public string SelectFrom(int effectiveLevel, string challengeRating)
        {
            var tableName = string.Format(TableNameConstants.LevelXRolls, effectiveLevel);
            var rolls = collectionSelector.SelectFrom(tableName, challengeRating);
            var roll = collectionSelector.SelectRandomFrom(rolls);

            return roll;
        }

        public double SelectFrom(string roll)
        {
            double testDouble;
            if (double.TryParse(roll, out testDouble))
                return testDouble;

            return dice.Roll(roll);
        }

        public string SelectFrom(string baseRoll, int modifier)
        {
            if (baseRoll == RollConstants.Reroll)
                return baseRoll;

            var rolls = collectionSelector.SelectFrom(TableNameConstants.RollOrder, "All").ToList();
            var index = rolls.IndexOf(baseRoll);

            var modifiedIndex = index + modifier;
            modifiedIndex = Math.Min(modifiedIndex, rolls.Count - 1);
            modifiedIndex = Math.Max(modifiedIndex, 0);

            return rolls[modifiedIndex];
        }

        public string SelectRollFrom(string source)
        {
            var match = rollRegex.Match(source);
            return match.Value;
        }
    }
}
