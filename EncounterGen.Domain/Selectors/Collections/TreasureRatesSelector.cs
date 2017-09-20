using DnDGen.Core.Selectors.Collections;
using EncounterGen.Domain.Selectors.Selections;
using EncounterGen.Domain.Tables;
using System;
using System.Linq;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal class TreasureRatesSelector : ITreasureRatesSelector
    {
        private ICollectionSelector collectionSelector;

        public TreasureRatesSelector(ICollectionSelector collectionSelector)
        {
            this.collectionSelector = collectionSelector;
        }

        public TreasureRatesSelection SelectFor(string creature)
        {
            var collection = collectionSelector.SelectFrom(TableNameConstants.TreasureRates, creature).ToArray();
            var treasureRates = new TreasureRatesSelection();

            treasureRates.Coin = Convert.ToDouble(collection[TreasureConstants.CoinIndex]);
            treasureRates.Goods = Convert.ToDouble(collection[TreasureConstants.GoodsIndex]);
            treasureRates.Items = Convert.ToDouble(collection[TreasureConstants.ItemsIndex]);

            return treasureRates;
        }
    }
}
