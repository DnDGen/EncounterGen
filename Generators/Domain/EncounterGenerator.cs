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

        public Encounter Generate(string environment, int level)
        {
            var tableName = string.Format(TableNameConstants.LevelXEncounterLevel, level);
            var encounterLevel = typeAndAmountPercentileSelector.SelectFrom(tableName).Single();
            var effectiveLevel = Convert.ToInt32(encounterLevel.Key);
            var modifier = Convert.ToInt32(encounterLevel.Value);

            tableName = string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, effectiveLevel, environment);
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

        private IEnumerable<Creature> GetCreatures(string creatureType, string amount, int modifier, int effectiveLevel)
        {
            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.MonsterGroups, GroupConstants.RequiresSubtype);
            if (creaturesRequiringSubtypes.Contains(creatureType))
                return GetCreatureWithSubtype(creatureType, effectiveLevel, modifier);

            var creatures = new List<Creature>();
            var creature = new Creature();
            creature.Type = creatureType;

            var effectiveRoll = rollSelector.SelectFrom(amount, modifier);
            var doubleQuantity = rollSelector.SelectFrom(effectiveRoll);
            creature.Quantity = Convert.ToInt32(doubleQuantity);

            if (creature.Type == CreatureConstants.Dragon)
            {
                var tableName = string.Format(TableNameConstants.LevelXDragons, effectiveLevel);
                creature.Type = percentileSelector.SelectFrom(tableName);
            }
            else if (creature.Type == CreatureConstants.Mephit)
            {
                creature.Type = percentileSelector.SelectFrom(TableNameConstants.Mephits);
            }

            var dieRoll = rollSelector.SelectRollFrom(creature.Type);

            if (string.IsNullOrEmpty(dieRoll))
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

        private IEnumerable<Creature> GetCreatureWithSubtype(string creatureType, int effectiveLevel, int modifier)
        {
            var creatures = new List<Creature>();
            var creature = new Creature();
            creature.Type = creatureType;

            var subtypes = collectionSelector.SelectFrom(TableNameConstants.MonsterGroups, creature.Type);
            var subtype = collectionSelector.SelectRandomFrom(subtypes);

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, creature.Type);
            var challengeRating = collectionSelector.SelectFrom(tableName, subtype).Single();
            var roll = rollSelector.SelectFrom(effectiveLevel, challengeRating);
            var effectiveRoll = rollSelector.SelectFrom(roll, modifier);

            while (roll == RollConstants.Reroll || effectiveRoll == RollConstants.Reroll)
            {
                subtype = collectionSelector.SelectRandomFrom(subtypes);
                challengeRating = collectionSelector.SelectFrom(tableName, subtype).Single();
                roll = rollSelector.SelectFrom(effectiveLevel, challengeRating);
                effectiveRoll = rollSelector.SelectFrom(roll, modifier);
            }

            var doubleQuantity = rollSelector.SelectFrom(effectiveRoll);
            creature.Quantity = Convert.ToInt32(doubleQuantity);
            creature.Subtype = subtype;

            creatures.Add(creature);
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

        private IEnumerable<Character> GetUndeadNPCs(IEnumerable<Creature> creatures, int effectiveLevel)
        {
            var undeadNPCTypes = collectionSelector.SelectFrom(TableNameConstants.MonsterGroups, GroupConstants.UndeadNPC);
            var undeadNPCs = new List<Character>();

            if (creatures.Any(c => undeadNPCTypes.Contains(c.Type)) == false)
                return undeadNPCs;

            var undeadNPCCreature = creatures.Single(c => undeadNPCTypes.Contains(c.Type));
            var undeadNPCQuantity = undeadNPCCreature.Quantity;

            setMetaraceRandomizer.SetMetarace = undeadNPCCreature.Type;

            var tableName = string.Format(TableNameConstants.LevelXUndeadNPC, effectiveLevel);
            setLevelRandomizer.AllowAdjustments = false;

            while (undeadNPCQuantity-- > 0)
            {
                setLevelRandomizer.SetLevel = adjustmentSelector.SelectFrom(tableName, setMetaraceRandomizer.SetMetarace);

                var undeadNPC = characterGenerator.GenerateWith(alignmentRandomizer, classNameRandomizer, setLevelRandomizer, baseRaceRandomizer, setMetaraceRandomizer, statsRandomizer);
                undeadNPCs.Add(undeadNPC);
            }

            return undeadNPCs;
        }

        private int GetCharacterLevel(Creature characterCreature)
        {
            var levelString = characterCreature.Type.Replace(CreatureConstants.Character, string.Empty);
            return Convert.ToInt32(levelString);
        }

        private bool ShouldReroll(IEnumerable<string> amounts, int modifier)
        {
            return amounts.Any(a => rollSelector.SelectFrom(a, modifier) == RollConstants.Reroll);
        }

        private Treasure GenerateTreasureFor(string creature, int level)
        {
            var coinMultiplier = adjustmentSelector.SelectFrom(TableNameConstants.TreasureAdjustments, creature, TreasureConstants.Coin);
            var goodsMultiplier = adjustmentSelector.SelectFrom(TableNameConstants.TreasureAdjustments, creature, TreasureConstants.Goods);
            var itemsMultiplier = adjustmentSelector.SelectFrom(TableNameConstants.TreasureAdjustments, creature, TreasureConstants.Items);

            var treasure = new Treasure();

            treasure.Coin = coinGenerator.GenerateAtLevel(level);

            var doubleQuantity = coinMultiplier * treasure.Coin.Quantity;
            treasure.Coin.Quantity = Convert.ToInt32(doubleQuantity);

            if (booleanPercentileSelector.SelectFrom(goodsMultiplier))
            {
                goodsMultiplier = Math.Ceiling(goodsMultiplier);

                while (goodsMultiplier-- > 0)
                    treasure.Goods = treasure.Goods.Union(goodsGenerator.GenerateAtLevel(level));
            }

            if (booleanPercentileSelector.SelectFrom(itemsMultiplier))
            {
                itemsMultiplier = Math.Ceiling(itemsMultiplier);

                while (itemsMultiplier-- > 0)
                    treasure.Items = treasure.Items.Union(itemsGenerator.GenerateAtLevel(level));
            }

            return treasure;
        }
    }
}
