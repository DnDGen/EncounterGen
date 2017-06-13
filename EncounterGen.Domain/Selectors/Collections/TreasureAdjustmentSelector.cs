using EncounterGen.Domain.Selectors.Selections;
using EncounterGen.Domain.Tables;
using System;
using System.Linq;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal class TreasureAdjustmentSelector : ITreasureAdjustmentSelector
    {
        private ICollectionSelector collectionSelector;

        public TreasureAdjustmentSelector(ICollectionSelector collectionSelector)
        {
            this.collectionSelector = collectionSelector;
        }

        public TreasureRatesSelection SelectFor(string creature)
        {
            var collection = collectionSelector.SelectFrom(TableNameConstants.TreasureAdjustments, creature).ToArray();
            var treasureRates = new TreasureRatesSelection();

            treasureRates.Coin = Convert.ToDouble(collection[TreasureConstants.Coin]);
            treasureRates.Goods = Convert.ToDouble(collection[TreasureConstants.Goods]);
            treasureRates.Items = Convert.ToDouble(collection[TreasureConstants.Items]);

            return treasureRates;
        }
    }
}
