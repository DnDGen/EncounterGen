using CharacterGen.Common;
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
            var encounterLevel = typeAndAmountPercentileSelector.SelectFrom(tableName).Single();
            var effectiveLevel = Convert.ToInt32(encounterLevel.Key);
            var modifier = Convert.ToInt32(encounterLevel.Value);

            tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, effectiveLevel, environment);
            var encounterCreaturesAndAmounts = typeAndAmountPercentileSelector.SelectFrom(tableName);

            while (ShouldReroll(encounterCreaturesAndAmounts.Values, modifier))
                encounterCreaturesAndAmounts = typeAndAmountPercentileSelector.SelectFrom(tableName);

            var creatures = new List<Creature>();

            foreach (var kvp in encounterCreaturesAndAmounts)
            {
                var newCreatures = GetCreatures(kvp.Key, kvp.Value, modifier, effectiveLevel);
                creatures.AddRange(newCreatures);
            }

            var encounter = new Encounter();
            encounter.Creatures = creatures;

            var leadCreature = encounterCreaturesAndAmounts.First().Key;
            encounter.Treasure = GenerateTreasureFor(leadCreature, level);

            var characters = GetCharacters(encounter.Creatures);
            encounter.Characters = encounter.Characters.Union(characters);

            var undeadNPCs = GetUndeadNPCs(encounter.Creatures, effectiveLevel);
            encounter.Characters = encounter.Characters.Union(undeadNPCs);

            foreach (var creature in encounter.Creatures)
                if (creature.Type.Contains(CreatureConstants.Character))
                    creature.Type = CreatureConstants.Character;

            return encounter;
        }

        private IEnumerable<Creature> GetCreatures(String creatureType, String amount, Int32 modifier, Int32 effectiveLevel)
        {
            var effectiveRoll = rollSelector.SelectFrom(amount, modifier);

            var creatures = new List<Creature>();
            var creature = new Creature();
            creature.Type = creatureType;
            creature.Quantity = rollSelector.SelectFrom(effectiveRoll);

            if (creature.Type == CreatureConstants.Dragon)
            {
                var tableName = String.Format(TableNameConstants.LevelXDragons, effectiveLevel);
                creature.Type = percentileSelector.SelectFrom(tableName);
            }

            var dieRoll = rollSelector.SelectRollFrom(creature.Type);

            if (String.IsNullOrEmpty(dieRoll))
            {
                creatures.Add(creature);
                return creatures;
            }

            while (creature.Quantity-- > 0)
            {
                var rolledCreature = new Creature();
                rolledCreature.Quantity = 1;

                var roll = rollSelector.SelectFrom(dieRoll);
                rolledCreature.Type = creature.Type.Replace(dieRoll, roll.ToString());

                creatures.Add(rolledCreature);
            }

            return creatures;
        }

        private IEnumerable<Character> GetCharacters(IEnumerable<Creature> creatures)
        {
            var characters = new List<Character>();

            if (creatures.Any(c => c.Type.Contains(CreatureConstants.Character)) == false)
                return characters;

            var characterCreature = creatures.Single(c => c.Type.Contains(CreatureConstants.Character));
            var characterQuantity = characterCreature.Quantity;
            setLevelRandomizer.SetLevel = GetCharacterLevel(characterCreature);

            while (characterQuantity-- > 0)
            {
                var character = characterGenerator.GenerateWith(alignmentRandomizer, classNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer);
                characters.Add(character);
            }

            return characters;
        }

        private IEnumerable<Character> GetUndeadNPCs(IEnumerable<Creature> creatures, Int32 effectiveLevel)
        {
            var undeadNPCTypes = collectionSelector.SelectFrom(TableNameConstants.MonsterGroups, GroupConstants.UndeadNPC);
            var undeadNPCs = new List<Character>();

            if (creatures.Any(c => undeadNPCTypes.Contains(c.Type)) == false)
                return undeadNPCs;

            var undeadNPCCreature = creatures.Single(c => undeadNPCTypes.Contains(c.Type));
            var undeadNPCQuantity = undeadNPCCreature.Quantity;

            setMetaraceRandomizer.SetMetarace = undeadNPCCreature.Type;

            var tableName = String.Format(TableNameConstants.LevelXUndeadNPC, effectiveLevel);
            setLevelRandomizer.AllowAdjustments = false;

            while (undeadNPCQuantity-- > 0)
            {
                setLevelRandomizer.SetLevel = adjustmentSelector.SelectFrom(tableName, setMetaraceRandomizer.SetMetarace);
                var undeadNPC = characterGenerator.GenerateWith(alignmentRandomizer, classNameRandomizer, setLevelRandomizer, baseRaceRandomizer, setMetaraceRandomizer, statsRandomizer);
                undeadNPCs.Add(undeadNPC);
            }

            return undeadNPCs;
        }

        private Int32 GetCharacterLevel(Creature characterCreature)
        {
            var levelString = characterCreature.Type.Replace(CreatureConstants.Character, String.Empty);
            return Convert.ToInt32(levelString);
        }

        private Boolean ShouldReroll(IEnumerable<String> amounts, Int32 modifier)
        {
            return amounts.Any(a => rollSelector.SelectFrom(a, modifier) == RollConstants.Reroll);
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
