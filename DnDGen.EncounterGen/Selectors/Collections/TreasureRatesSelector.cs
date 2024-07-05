using DnDGen.EncounterGen.Selectors.Selections;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Collections;
using System;
using System.Linq;

namespace DnDGen.EncounterGen.Selectors.Collections
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
            var collection = collectionSelector.SelectFrom(Config.Name, TableNameConstants.TreasureRates, creature).ToArray();
            var treasureRates = new TreasureRatesSelection();

            treasureRates.Coin = Convert.ToDouble(collection[TreasureConstants.CoinIndex]);
            treasureRates.Goods = Convert.ToDouble(collection[TreasureConstants.GoodsIndex]);
            treasureRates.Items = Convert.ToDouble(collection[TreasureConstants.ItemsIndex]);

            return treasureRates;
        }
    }
}
