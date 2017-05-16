using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Selectors.Percentiles;
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
        private readonly ICoinGenerator coinGenerator;
        private readonly IGoodsGenerator goodsGenerator;
        private readonly IItemsGenerator itemsGenerator;
        private readonly IAdjustmentSelector adjustmentSelector;
        private readonly IBooleanPercentileSelector booleanPercentileSelector;
        private readonly ICollectionSelector collectionSelector;
        private readonly IMagicalItemGeneratorRuntimeFactory magicalItemGeneratorRuntimeFactory;
        private readonly IMundaneItemGeneratorRuntimeFactory mundaneItemGeneratorRuntimeFactory;
        private readonly IItemSelector itemSelector;

        public EncounterTreasureGenerator(
            ICoinGenerator coinGenerator,
            IGoodsGenerator goodsGenerator,
            IItemsGenerator itemsGenerator,
            IAdjustmentSelector adjustmentSelector,
            IBooleanPercentileSelector booleanPercentileSelector,
            ICollectionSelector collectionSelector,
            IMagicalItemGeneratorRuntimeFactory magicalItemGeneratorRuntimeFactory,
            IMundaneItemGeneratorRuntimeFactory mundaneItemGeneratorRuntimeFactory,
            IItemSelector itemSelector)
        {
            this.coinGenerator = coinGenerator;
            this.goodsGenerator = goodsGenerator;
            this.itemsGenerator = itemsGenerator;
            this.adjustmentSelector = adjustmentSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.collectionSelector = collectionSelector;
            this.magicalItemGeneratorRuntimeFactory = magicalItemGeneratorRuntimeFactory;
            this.mundaneItemGeneratorRuntimeFactory = mundaneItemGeneratorRuntimeFactory;
            this.itemSelector = itemSelector;
        }

        public Treasure GenerateFor(Creature creature, int level)
        {
            var creatureName = GetCreatureNameForTreasure(creature.Type);
            var coinMultiplier = adjustmentSelector.SelectDouble(TableNameConstants.TreasureAdjustments, creatureName, TreasureConstants.Coin);
            var goodsMultiplier = adjustmentSelector.SelectDouble(TableNameConstants.TreasureAdjustments, creatureName, TreasureConstants.Goods);
            var itemsMultiplier = adjustmentSelector.SelectDouble(TableNameConstants.TreasureAdjustments, creatureName, TreasureConstants.Items);

            var treasure = new Treasure();
            treasure.Coin = coinGenerator.GenerateAtLevel(level);

            var rawQuantity = coinMultiplier * treasure.Coin.Quantity;
            treasure.Coin.Quantity = Convert.ToInt32(rawQuantity);

            while (booleanPercentileSelector.SelectFrom(goodsMultiplier--))
            {
                var goods = goodsGenerator.GenerateAtLevel(level);
                treasure.Goods = treasure.Goods.Union(goods);
            }

            while (booleanPercentileSelector.SelectFrom(itemsMultiplier--))
            {
                var items = itemsGenerator.GenerateAtLevel(level);
                treasure.Items = treasure.Items.Union(items);
            }

            var setTreasure = GetSetTreasure(creatureName, creature.Quantity);
            treasure.Items = treasure.Items.Union(setTreasure);

            return treasure;
        }

        private IEnumerable<Item> GetSetTreasure(string creatureName, int quantity)
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
            if (template.IsMagical == false)
            {
                var mundaneGenerator = mundaneItemGeneratorRuntimeFactory.CreateGeneratorOf(template.ItemType);
                return mundaneGenerator.GenerateFrom(template, true);
            }

            var magicalGenerator = magicalItemGeneratorRuntimeFactory.CreateGeneratorOf(template.ItemType);
            return magicalGenerator.Generate(template, true);
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
