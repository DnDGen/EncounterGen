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
        private IDice dice;
        private Regex rollRegex;

        public RollSelector(ICollectionSelector collectionSelector, IDice dice)
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
            var sections = roll.Split('d', '+');
            if (sections.Length == 1)
                return Convert.ToDouble(sections[0]);

            var bonus = 0;
            if (sections.Length == 3)
                bonus = Convert.ToInt32(sections[2]);

            var quantity = Convert.ToInt32(sections[0]);
            var die = Convert.ToInt32(sections[1]);

            return dice.Roll(quantity).d(die) + bonus;
        }

        public string SelectFrom(string baseRoll, int modifier)
        {
            var rolls = collectionSelector.SelectFrom(TableNameConstants.RollOrder, "All").ToList();
            var index = rolls.IndexOf(baseRoll);

            var modifiedIndex = index + modifier;
            modifiedIndex = Math.Min(modifiedIndex, rolls.Count - 1);
            modifiedIndex = Math.Max(modifiedIndex, 0);

            return rolls[modifiedIndex];
        }

        public string SelectRollFrom(string source)
        {
            var matches = rollRegex.Matches(source);

            if (matches.Count == 0)
                return string.Empty;

            return matches[0].Value;
        }
    }
}
