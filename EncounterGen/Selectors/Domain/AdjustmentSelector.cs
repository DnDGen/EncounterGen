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
            var adjustment = collection.Single();
            return rollSelector.SelectFrom(adjustment);
        }
    }
}
