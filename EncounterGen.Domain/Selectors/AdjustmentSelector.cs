using RollGen;
using System.Linq;

namespace EncounterGen.Domain.Selectors
{
    internal class AdjustmentSelector : IAdjustmentSelector
    {
        private ICollectionSelector collectionSelector;
        private Dice dice;

        public AdjustmentSelector(ICollectionSelector collectionSelector, Dice dice)
        {
            this.collectionSelector = collectionSelector;
            this.dice = dice;
        }

        public int Select(string tableName, string entry, int index = 0)
        {
            return Select<int>(tableName, entry, index);
        }

        public T Select<T>(string tableName, string entry, int index = 0)
        {
            var collection = collectionSelector.SelectFrom(tableName, entry);
            var adjustment = collection.ElementAt(index);
            var expression = dice.ReplaceExpressionWithTotal(adjustment, true);
            return dice.Evaluate<T>(expression);
        }
    }
}
