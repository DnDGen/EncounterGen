using EncounterGen.Common;
using EncounterGen.Domain.Generators.Factories;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Domain.Selectors.Selections;
using EncounterGen.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen;
using TreasureGen.Coins;
using TreasureGen.Goods;
using TreasureGen.Items;
using TreasureGen.Items.Magical;
using TreasureGen.Items.Mundane;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterTreasureGenerator : IEncounterTreasureGenerator
    {
        private readonly ITreasureAdjustmentSelector treasureAdjustmentSelector;
        private readonly IBooleanPercentileSelector booleanPercentileSelector;
        private readonly ICollectionSelector collectionSelector;
        private readonly IItemSelector itemSelector;
        private readonly JustInTimeFactory justInTimeFactory;

        public EncounterTreasureGenerator(ITreasureAdjustmentSelector treasureAdjustmentSelector, IBooleanPercentileSelector booleanPercentileSelector, ICollectionSelector collectionSelector, IItemSelector itemSelector, JustInTimeFactory justInTimeFactory)
        {
            this.treasureAdjustmentSelector = treasureAdjustmentSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.collectionSelector = collectionSelector;
            this.itemSelector = itemSelector;
            this.justInTimeFactory = justInTimeFactory;
        }

        public IEnumerable<Treasure> GenerateFor(IEnumerable<Creature> creatures, int level)
        {
            var treasures = new List<Treasure>();

            foreach (var creature in creatures)
            {
                var treasure = GenerateFor(creature, level);

                if (treasure.IsAny)
                    treasures.Add(treasure);
            }

            return treasures;
        }

        private Treasure GenerateFor(Creature creature, int level)
        {
            var creatureName = GetCreatureNameForTreasure(creature.Type);
            var treasureRates = treasureAdjustmentSelector.SelectFor(creatureName);

            var treasure = new Treasure();
            treasure.Coin = GetCoin(treasureRates, level);
            treasure.Goods = GetGoods(treasureRates, level);
            treasure.Items = GetItems(treasureRates, level, creatureName, creature.Quantity);

            return treasure;
        }

        private Coin GetCoin(TreasureRatesSelection treasureRates, int level)
        {
            var coinGenerator = justInTimeFactory.Build<ICoinGenerator>();
            var coin = coinGenerator.GenerateAtLevel(level);

            var rawQuantity = treasureRates.Coin * coin.Quantity;
            coin.Quantity = Convert.ToInt32(rawQuantity);

            return coin;
        }

        private IEnumerable<Good> GetGoods(TreasureRatesSelection treasureRates, int level)
        {
            var goods = new List<Good>();
            var goodsGenerator = justInTimeFactory.Build<IGoodsGenerator>();

            while (booleanPercentileSelector.SelectFrom(treasureRates.Goods--))
            {
                var generatedGoods = goodsGenerator.GenerateAtLevel(level);
                goods.AddRange(generatedGoods);
            }

            return goods;
        }

        private IEnumerable<Item> GetItems(TreasureRatesSelection treasureRates, int level, string creatureName, int quantity)
        {
            var items = new List<Item>();
            var itemsGenerator = justInTimeFactory.Build<IItemsGenerator>();

            while (booleanPercentileSelector.SelectFrom(treasureRates.Items--))
            {
                var generatedItems = itemsGenerator.GenerateAtLevel(level);
                items.AddRange(generatedItems);
            }

            var setItems = GetSetItems(creatureName, quantity);
            items.AddRange(setItems);

            return items;
        }

        private IEnumerable<Item> GetSetItems(string creatureName, int quantity)
        {
            var setItems = new List<Item>();
            var setTreasure = collectionSelector.SelectFrom(TableNameConstants.TreasureGroups, creatureName);
            var setItemTemplates = GetTemplates(setTreasure);

            while (quantity-- > 0)
            {
                foreach (var template in setItemTemplates)
                {
                    var item = GetItemFrom(template);
                    setItems.Add(item);
                }
            }

            return setItems;
        }

        private Item GetItemFrom(Item template)
        {
            if (template.IsMagical)
            {
                var magicalItemGeneratorFactory = justInTimeFactory.Build<IMagicalItemGeneratorFactory>();
                var magicalGenerator = magicalItemGeneratorFactory.CreateGeneratorOf(template.ItemType);
                return magicalGenerator.Generate(template, true);
            }

            var mundaneItemGeneratorFactory = justInTimeFactory.Build<IMundaneItemGeneratorFactory>();
            var mundaneGenerator = mundaneItemGeneratorFactory.CreateGeneratorOf(template.ItemType);
            return mundaneGenerator.GenerateFrom(template, true);
        }

        private IEnumerable<Item> GetTemplates(IEnumerable<string> setTreasure)
        {
            var templates = new List<Item>();

            foreach (var setItemTemplate in setTreasure)
            {
                var template = itemSelector.SelectFrom(setItemTemplate);
                templates.Add(template);
            }

            return templates;
        }

        private string GetCreatureNameForTreasure(CreatureType creatureType)
        {
            var useSubtypeForTreasure = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UseSubtypeForTreasure);

            if (useSubtypeForTreasure.Contains(creatureType.Name))
            {
                return GetCreatureNameForTreasure(creatureType.SubType);
            }

            return creatureType.Name;
        }
    }
}
