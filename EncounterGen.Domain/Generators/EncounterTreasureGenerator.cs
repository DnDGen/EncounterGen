using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Domain.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        private const int IterationLimit = 10000;

        private ICoinGenerator coinGenerator;
        private IGoodsGenerator goodsGenerator;
        private IItemsGenerator itemsGenerator;
        private IAdjustmentSelector adjustmentSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private ICollectionSelector collectionSelector;
        private Regex subTypeRegex;
        private IMagicalItemGeneratorRuntimeFactory magicalItemGeneratorRuntimeFactory;
        private IMundaneItemGeneratorRuntimeFactory mundaneItemGeneratorRuntimeFactory;
        private Regex itemTypeRegex;
        private Regex itemBonusRegex;
        private Regex specialAbilityRegex;
        private Regex traitRegex;

        public EncounterTreasureGenerator(ICoinGenerator coinGenerator, IGoodsGenerator goodsGenerator, IItemsGenerator itemsGenerator, IAdjustmentSelector adjustmentSelector,
            IBooleanPercentileSelector booleanPercentileSelector, ICollectionSelector collectionSelector, IMagicalItemGeneratorRuntimeFactory magicalItemGeneratorRuntimeFactory, IMundaneItemGeneratorRuntimeFactory mundaneItemGeneratorRuntimeFactory)
        {
            this.coinGenerator = coinGenerator;
            this.goodsGenerator = goodsGenerator;
            this.itemsGenerator = itemsGenerator;
            this.adjustmentSelector = adjustmentSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.collectionSelector = collectionSelector;
            this.magicalItemGeneratorRuntimeFactory = magicalItemGeneratorRuntimeFactory;
            this.mundaneItemGeneratorRuntimeFactory = mundaneItemGeneratorRuntimeFactory;

            subTypeRegex = new Regex(RegexConstants.DescriptionPattern);
            itemTypeRegex = new Regex(RegexConstants.ItemTypePattern);
            itemBonusRegex = new Regex(RegexConstants.ItemBonusPattern);
            specialAbilityRegex = new Regex(RegexConstants.SpecialAbilitiesPattern);
            traitRegex = new Regex(RegexConstants.TraitPattern);
        }

        public Treasure GenerateFor(Creature creature, int level)
        {
            var creatureName = GetCreatureNameForTreasure(creature.Name, creature.Description);
            var coinMultiplier = adjustmentSelector.Select<double>(TableNameConstants.TreasureAdjustments, creatureName, TreasureConstants.Coin);
            var goodsMultiplier = adjustmentSelector.Select<double>(TableNameConstants.TreasureAdjustments, creatureName, TreasureConstants.Goods);
            var itemsMultiplier = adjustmentSelector.Select<double>(TableNameConstants.TreasureAdjustments, creatureName, TreasureConstants.Items);

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
                return mundaneGenerator.Generate(template, true);
            }

            var magicalGenerator = magicalItemGeneratorRuntimeFactory.CreateGeneratorOf(template.ItemType);
            return magicalGenerator.Generate(template, true);
        }

        private IEnumerable<Item> GetTemplates(IEnumerable<string> setTreasure)
        {
            var templates = new List<Item>();

            foreach (var setItemTemplate in setTreasure)
            {
                var template = new Item();
                template.Name = setItemTemplate;
                template.Name = itemTypeRegex.Replace(template.Name, string.Empty);
                template.Name = itemBonusRegex.Replace(template.Name, string.Empty);
                template.Name = specialAbilityRegex.Replace(template.Name, string.Empty);
                template.Name = traitRegex.Replace(template.Name, string.Empty);

                template.ItemType = GetMatchValue(itemTypeRegex, setItemTemplate, "[", "]");

                if (itemBonusRegex.IsMatch(setItemTemplate))
                {
                    var rawBonus = GetMatchValue(itemBonusRegex, setItemTemplate, "(", ")");
                    template.Magic.Bonus = Convert.ToInt32(rawBonus);
                }

                if (specialAbilityRegex.IsMatch(setItemTemplate))
                {
                    var rawSpecialAbilities = GetMatchValue(specialAbilityRegex, setItemTemplate, "{", "}");
                    var specialAbilityNamees = rawSpecialAbilities.Split(',');

                    foreach (var specialAbilityName in specialAbilityNamees)
                    {
                        var specialAbility = new SpecialAbility { Name = specialAbilityName };
                        template.Magic.SpecialAbilities = template.Magic.SpecialAbilities.Union(new[] { specialAbility });
                    }
                }

                if (traitRegex.IsMatch(setItemTemplate))
                {
                    var rawTraits = GetMatchValue(traitRegex, setItemTemplate, "#");
                    var traits = rawTraits.Split(',');

                    foreach (var trait in traits)
                        template.Traits.Add(trait);
                }

                templates.Add(template);
            }

            return templates;
        }

        private string GetMatchValue(Regex regex, string source, params string[] wrappers)
        {
            var matchValue = regex.Match(source).Value;

            foreach (var wrapper in wrappers)
                matchValue = matchValue.Replace(wrapper, string.Empty);

            return matchValue;
        }

        private string GetCreatureNameForTreasure(string name, string description)
        {
            var useSubtypeForTreasure = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UseSubtypeForTreasure);

            if (useSubtypeForTreasure.Contains(name))
            {
                var subType = GetCreatureType(description);
                var subSubType = GetSubtype(description);

                return GetCreatureNameForTreasure(subType, subSubType);
            }

            return name;
        }

        private string GetCreatureType(string fullCreatureType)
        {
            var creatureType = subTypeRegex.Replace(fullCreatureType, string.Empty);

            return creatureType;
        }

        private string GetSubtype(string fullCreatureType)
        {
            var subTypeMatch = subTypeRegex.Match(fullCreatureType);
            if (string.IsNullOrEmpty(subTypeMatch.Value))
                return string.Empty;

            var subType = subTypeMatch.Value.Substring(2, subTypeMatch.Value.Length - 3);

            return subType;
        }
    }
}
