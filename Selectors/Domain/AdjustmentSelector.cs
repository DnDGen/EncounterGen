using System;
using System.Linq;

namespace EncounterGen.Selectors.Domain
{
    public class AdjustmentSelector : IAdjustmentSelector
    {
        private ICollectionSelector collectionSelector;
        private IRollSelector rollSelector;

        public AdjustmentSelector(ICollectionSelector collectionSelector, IRollSelector rollSelector)
        {
            this.collectionSelector = collectionSelector;
            this.rollSelector = rollSelector;
        }

        public Int32 SelectFrom(String tableName, String entry)
        {
            var collection = collectionSelector.SelectFrom(tableName, entry);
            var stringAdjustment = collection.Single();
            var doubleAdjustment = rollSelector.SelectFrom(stringAdjustment);

            return Convert.ToInt32(doubleAdjustment);
        }

        public Double SelectFrom(String tableName, String entry, Int32 index)
        {
            var collection = collectionSelector.SelectFrom(tableName, entry);
            var adjustment = collection.ElementAt(index);
            return rollSelector.SelectFrom(adjustment);
        }
    }
}
