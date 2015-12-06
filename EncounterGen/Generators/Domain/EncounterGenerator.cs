using CharacterGen.Generators;
using CharacterGen.Generators.Randomizers.Alignments;
using CharacterGen.Generators.Randomizers.CharacterClasses;
using CharacterGen.Generators.Randomizers.Races;
using CharacterGen.Generators.Randomizers.Stats;
using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Selectors.Percentiles;
using EncounterGen.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common;
using TreasureGen.Generators.Coins;
using TreasureGen.Generators.Goods;
using TreasureGen.Generators.Items;

namespace EncounterGen.Generators.Domain
{
    public class EncounterGenerator : IEncounterGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private ICoinGenerator coinGenerator;
        private IGoodsGenerator goodsGenerator;
        private IItemsGenerator itemsGenerator;
        private ICharacterGenerator characterGenerator;
        private IAlignmentRandomizer alignmentRandomizer;
        private IClassNameRandomizer classNameRandomizer;
        private ISetLevelRandomizer setLevelRandomizer;
        private RaceRandomizer baseRaceRandomizer;
        private RaceRandomizer metaraceRandomizer;
        private IStatsRandomizer statsRandomizer;
        private IAdjustmentSelector adjustmentSelector;
        private IRollSelector rollSelector;
        private IPercentileSelector percentileSelector;
        private IBooleanPercentileSelector booleanPercentileSelector;
        private ICollectionSelector collectionSelector;
        private ISetMetaraceRandomizer setMetaraceRandomizer;

        public EncounterGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICoinGenerator coinGenerator,
            IGoodsGenerator goodsGenerator, IItemsGenerator itemsGenerator, ICharacterGenerator characterGenerator, IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer classNameRandomizer,
            ISetLevelRandomizer setLevelRandomizer, RaceRandomizer baseRaceRandomizer, RaceRandomizer metaraceRandomizer, IStatsRandomizer statsRandomizer,
            IAdjustmentSelector adjustmentSelector, IRollSelector rollSelector, IPercentileSelector percentileSelector, IBooleanPercentileSelector booleanPercentileSelector,
            ICollectionSelector collectionSelector, ISetMetaraceRandomizer setMetaraceRandomizer)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.coinGenerator = coinGenerator;
            this.goodsGenerator = goodsGenerator;
            this.itemsGenerator = itemsGenerator;
            this.characterGenerator = characterGenerator;
            this.alignmentRandomizer = alignmentRandomizer;
            this.classNameRandomizer = classNameRandomizer;
            this.setLevelRandomizer = setLevelRandomizer;
            this.baseRaceRandomizer = baseRaceRandomizer;
            this.metaraceRandomizer = metaraceRandomizer;
            this.statsRandomizer = statsRandomizer;
            this.adjustmentSelector = adjustmentSelector;
            this.rollSelector = rollSelector;
            this.percentileSelector = percentileSelector;
            this.booleanPercentileSelector = booleanPercentileSelector;
            this.collectionSelector = collectionSelector;
            this.setMetaraceRandomizer = setMetaraceRandomizer;
        }

        public Encounter Generate(String environment, Int32 level)
        {
            var tableName = String.Format(TableNameConstants.LevelXEncounterLevel, level);
            var encounterLevel = typeAndAmountPercentileSelector.SelectFrom(tableName);
            var effectiveLevel = Convert.ToInt32(encounterLevel.Single().Key);
            var modifier = encounterLevel.Single().Value;

            tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, effectiveLevel, environment);
            var encounterCreaturesAndAmounts = typeAndAmountPercentileSelector.SelectFrom(tableName);

            while (ShouldReroll(encounterCreaturesAndAmounts.Values, modifier))
                encounterCreaturesAndAmounts = typeAndAmountPercentileSelector.SelectFrom(tableName);

            var creatures = new List<String>();

            foreach (var kvp in encounterCreaturesAndAmounts)
            {
                var effectiveRoll = rollSelector.SelectFrom(kvp.Value, modifier);
                var amount = rollSelector.SelectFrom(effectiveRoll);
                var creature = kvp.Key;

                if (creature == CreatureConstants.Dragon)
                {
                    tableName = String.Format(TableNameConstants.LevelXDragons, effectiveLevel);
                    creature = percentileSelector.SelectFrom(tableName);
                }

                creatures.AddRange(Enumerable.Repeat(creature, amount));
            }

            var encounter = new Encounter();
            encounter.Creatures = creatures;

            var leadCreature = encounterCreaturesAndAmounts.First().Key;
            encounter.Treasure = GenerateTreasureFor(leadCreature, level);

            var undeadNPCs = collectionSelector.SelectFrom(TableNameConstants.MonsterGroups, GroupConstants.UndeadNPC);

            if (encounter.Creatures.Any(c => c == CreatureConstants.Character) == false && encounter.Creatures.Intersect(undeadNPCs).Any() == false)
                return encounter;

            var characterQuantity = encounter.Creatures.Count(c => c == CreatureConstants.Character);
            setLevelRandomizer.SetLevel = adjustmentSelector.SelectFrom(TableNameConstants.CharacterLevel, effectiveLevel.ToString());

            while (characterQuantity-- > 0)
            {
                var character = characterGenerator.GenerateWith(alignmentRandomizer, classNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer);
                encounter.Characters = encounter.Characters.Union(new[] { character });
            }

            var undeadNPCQuantity = encounter.Creatures.Count(c => undeadNPCs.Contains(c));
            if (undeadNPCQuantity == 0)
                return encounter;

            setMetaraceRandomizer.SetMetarace = encounter.Creatures.Intersect(undeadNPCs).Single();

            tableName = String.Format(TableNameConstants.LevelXUndeadNPC, effectiveLevel);
            setLevelRandomizer.AllowAdjustments = false;

            while (undeadNPCQuantity-- > 0)
            {
                setLevelRandomizer.SetLevel = adjustmentSelector.SelectFrom(tableName, setMetaraceRandomizer.SetMetarace);
                var undeadNPC = characterGenerator.GenerateWith(alignmentRandomizer, classNameRandomizer, setLevelRandomizer, baseRaceRandomizer, setMetaraceRandomizer, statsRandomizer);
                encounter.Characters = encounter.Characters.Union(new[] { undeadNPC });
            }

            return encounter;
        }

        private Boolean ShouldReroll(IEnumerable<String> amounts, String modifier)
        {
            return amounts.Any(a => rollSelector.SelectFrom(a, modifier) == EncounterConstants.Reroll);
        }

        private Treasure GenerateTreasureFor(String creature, Int32 level)
        {
            var treasureMultiplier = adjustmentSelector.SelectFrom(TableNameConstants.TreasureAdjustment, creature);
            var treasure = new Treasure();

            if (treasureMultiplier == 0)
                return treasure;

            if (treasureMultiplier == EncounterConstants.PartialTreasure)
            {
                treasure.Coin = coinGenerator.GenerateAtLevel(level);
                treasure.Coin.Quantity /= 10;

                if (booleanPercentileSelector.SelectFrom(TableNameConstants.PartialTreasure))
                    treasure.Goods = goodsGenerator.GenerateAtLevel(level);

                if (booleanPercentileSelector.SelectFrom(TableNameConstants.PartialTreasure))
                    treasure.Items = itemsGenerator.GenerateAtLevel(level);

                return treasure;
            }

            treasure.Coin = coinGenerator.GenerateAtLevel(level);
            treasure.Coin.Quantity *= treasureMultiplier;

            while (treasureMultiplier-- > 0)
            {
                treasure.Goods = treasure.Goods.Union(goodsGenerator.GenerateAtLevel(level));
                treasure.Items = treasure.Items.Union(itemsGenerator.GenerateAtLevel(level));
            }

            return treasure;
        }
    }
}
