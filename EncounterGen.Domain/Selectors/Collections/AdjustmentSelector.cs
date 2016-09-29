using System;
using System.Linq;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal class AdjustmentSelector : IAdjustmentSelector
    {
        private ICollectionSelector collectionSelector;

        public AdjustmentSelector(ICollectionSelector collectionSelector)
        {
            this.collectionSelector = collectionSelector;
        }

        public int Select(string tableName, string entry, int index = 0)
        {
            var rawValue = SelectDouble(tableName, entry, index);
            return Convert.ToInt32(rawValue);
        }

        public double SelectDouble(string tableName, string entry, int index = 0)
        {
            var collection = collectionSelector.SelectFrom(tableName, entry);
            var adjustment = collection.ElementAt(index);

            return Convert.ToDouble(adjustment);
        }
    }
}
