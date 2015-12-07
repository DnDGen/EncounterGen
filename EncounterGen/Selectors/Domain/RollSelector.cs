using EncounterGen.Tables;
using RollGen;
using System;
using System.Linq;

namespace EncounterGen.Selectors.Domain
{
    public class RollSelector : IRollSelector
    {
        private ICollectionSelector collectionSelector;
        private IDice dice;

        public RollSelector(ICollectionSelector collectionSelector, IDice dice)
        {
            this.collectionSelector = collectionSelector;
            this.dice = dice;
        }

        public Int32 SelectFrom(String roll)
        {
            var sections = roll.Split('d', '+');
            if (sections.Length == 1)
                return Convert.ToInt32(sections[0]);

            var bonus = 0;
            if (sections.Length == 3)
                bonus = Convert.ToInt32(sections[2]);

            var quantity = Convert.ToInt32(sections[0]);
            var die = Convert.ToInt32(sections[1]);

            return dice.Roll(quantity).d(die) + bonus;
        }

        public String SelectFrom(String baseRoll, String modifier)
        {
            var tableName = String.Format(TableNameConstants.ROLLModifiedRolls, baseRoll);
            return collectionSelector.SelectFrom(tableName, modifier).Single();
        }
    }
}
