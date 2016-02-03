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
using System.Text.RegularExpressions;
using TreasureGen.Common;
using TreasureGen.Generators.Coins;
using TreasureGen.Generators.Goods;
using TreasureGen.Generators.Items;

namespace EncounterGen.Generators.Domain
{
    public class EncounterGenerator : IEncounterGenerator
    {
        private const int IterationLimit = 10000;

        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private ICoinGenerator coinGenerator;
        private IGoodsGenerator goodsGenerator;
        private IItemsGenerator itemsGenerator;
        private ICharacterGenerator characterGenerator;
        private IAlignmentRandomizer alignmentRandomizer;
        private IClassNameRandomizer anyPlayerClassNameRandomizer;
        private IClassNameRandomizer anyNPCClassNameRandomizer;
        private ISetClassNameRandomizer setClassNameRandomizer;
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
        private Regex characterLevelRegex;
        private Regex setCharacterLevelRegex;
        private Regex subTypeRegex;

        public EncounterGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ICoinGenerator coinGenerator,
            IGoodsGenerator goodsGenerator, IItemsGenerator itemsGenerator, ICharacterGenerator characterGenerator, IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer anyPlayerClassNameRandomizer,
            ISetLevelRandomizer setLevelRandomizer, RaceRandomizer baseRaceRandomizer, RaceRandomizer metaraceRandomizer, IStatsRandomizer statsRandomizer,
            IAdjustmentSelector adjustmentSelector, IRollSelector rollSelector, IPercentileSelector percentileSelector, IBooleanPercentileSelector booleanPercentileSelector,
            ICollectionSelector collectionSelector, ISetMetaraceRandomizer setMetaraceRandomizer, IClassNameRandomizer anyNPCClassNameRandomizer,
            ISetClassNameRandomizer setClassNameRandomizer)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.coinGenerator = coinGenerator;
            this.goodsGenerator = goodsGenerator;
            this.itemsGenerator = itemsGenerator;
            this.characterGenerator = characterGenerator;
            this.alignmentRandomizer = alignmentRandomizer;
            this.anyPlayerClassNameRandomizer = anyPlayerClassNameRandomizer;
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
            this.anyNPCClassNameRandomizer = anyNPCClassNameRandomizer;
            this.setClassNameRandomizer = setClassNameRandomizer;

            characterLevelRegex = new Regex("\\[.+\\]");
            setCharacterLevelRegex = new Regex("\\d+");
            subTypeRegex = new Regex(" \\(.+\\)");
        }

        public Encounter Generate(string environment, int level)
        {
            var tableName = string.Format(TableNameConstants.LevelXEncounterLevel, level);
            var encounterLevel = typeAndAmountPercentileSelector.SelectFrom(tableName).Single();
            var effectiveLevel = Convert.ToInt32(encounterLevel.Key);
            var modifier = Convert.ToInt32(encounterLevel.Value);
            var creatures = new List<Creature>();

            while (creatures.Any() == false || creatures.Contains(null))
            {
                creatures.Clear();

                tableName = string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, effectiveLevel, environment);
                var encounterCreaturesAndAmounts = typeAndAmountPercentileSelector.SelectFrom(tableName);

                while (ShouldReroll(encounterCreaturesAndAmounts.Values, modifier))
                    encounterCreaturesAndAmounts = typeAndAmountPercentileSelector.SelectFrom(tableName);

                foreach (var kvp in encounterCreaturesAndAmounts)
                {
                    var newCreature = GetCreature(kvp.Key, kvp.Value, modifier, level);
                    creatures.Add(newCreature);
                }
            }

            var encounter = new Encounter();
            encounter.Characters = GetCharacters(creatures, effectiveLevel);
            encounter.Creatures = EditCreatureTypes(creatures, effectiveLevel);

            var leadCreature = encounter.Creatures.First();
            encounter.Treasure = GenerateTreasureFor(leadCreature.Type, level);

            return encounter;
        }

        private IEnumerable<Creature> EditCreatureTypes(IEnumerable<Creature> creatures, int effectiveLevel)
        {
            var newCreatures = new List<Creature>();
            var creaturesToRemove = new List<Creature>();

            foreach (var creature in creatures)
            {
                if (creature.Subtype == string.Empty)
                    creature.Subtype = GetSubtype(creature.Type);

                creature.Type = GetCreatureType(creature.Type, effectiveLevel);

                var dieRoll = rollSelector.SelectRollFrom(creature.Subtype);

                if (string.IsNullOrEmpty(dieRoll))
                    continue;

                creaturesToRemove.Add(creature);

                while (creature.Quantity-- > 0)
                {
                    var rolledCreature = new Creature();
                    rolledCreature.Quantity = 1;
                    rolledCreature.Type = creature.Type;

                    var roll = rollSelector.SelectFrom(dieRoll);
                    rolledCreature.Subtype = creature.Subtype.Replace(dieRoll, roll.ToString());

                    newCreatures.Add(rolledCreature);
                }
            }

            return creatures.Union(newCreatures).Except(creaturesToRemove);
        }

        private Creature GetCreature(string fullCreatureType, string amount, int modifier, int level)
        {
            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);
            if (creaturesRequiringSubtypes.Contains(fullCreatureType))
                return GetCreatureWithRandomSubtype(fullCreatureType, level, modifier);

            var creature = new Creature();
            creature.Type = fullCreatureType;

            var effectiveRoll = rollSelector.SelectFrom(amount, modifier);
            var doubleQuantity = rollSelector.SelectFrom(effectiveRoll);
            creature.Quantity = Convert.ToInt32(doubleQuantity);

            return creature;
        }

        private string GetCreatureType(string fullCreatureType, int effectiveLevel)
        {
            var creatureType = subTypeRegex.Replace(fullCreatureType, string.Empty);
            creatureType = characterLevelRegex.Replace(creatureType, string.Empty);

            if (creatureType != CreatureConstants.Dragon)
                return creatureType;

            var tableName = string.Format(TableNameConstants.LevelXDragons, effectiveLevel);
            return percentileSelector.SelectFrom(tableName);
        }

        private string GetSubtype(string fullCreatureType)
        {
            var subTypeMatch = subTypeRegex.Match(fullCreatureType);
            if (string.IsNullOrEmpty(subTypeMatch.Value))
                return string.Empty;

            var subType = subTypeMatch.Value.Replace(" (", string.Empty).Replace(")", string.Empty);
            subType = characterLevelRegex.Replace(subType, string.Empty);

            return subType;
        }

        private Creature GetCreatureWithRandomSubtype(string creatureType, int level, int modifier)
        {
            var creature = new Creature();
            creature.Type = creatureType;

            var subtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, creature.Type);
            var subtype = collectionSelector.SelectRandomFrom(subtypes);

            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, creature.Type);
            var challengeRating = collectionSelector.SelectFrom(tableName, subtype).Single();
            var roll = rollSelector.SelectFrom(level, challengeRating);
            var effectiveRoll = rollSelector.SelectFrom(roll, modifier);
            var iteration = 1;

            while ((roll == RollConstants.Reroll || effectiveRoll == RollConstants.Reroll) && iteration++ < IterationLimit)
            {
                subtype = collectionSelector.SelectRandomFrom(subtypes);
                challengeRating = collectionSelector.SelectFrom(tableName, subtype).Single();
                roll = rollSelector.SelectFrom(level, challengeRating);
                effectiveRoll = rollSelector.SelectFrom(roll, modifier);
            }

            if (roll == RollConstants.Reroll || effectiveRoll == RollConstants.Reroll)
                return null;

            var doubleQuantity = rollSelector.SelectFrom(effectiveRoll);
            creature.Quantity = Convert.ToInt32(doubleQuantity);
            creature.Subtype = subtype;

            return creature;
        }

        private IEnumerable<Character> GetCharacters(IEnumerable<Creature> creatures, int effectiveLevel)
        {
            var characters = new List<Character>();
            var characterCreatures = creatures.Where(c => IsCharacterCreature(c.Type));

            if (characterCreatures.Any() == false)
                return characters;

            foreach (var characterCreature in characterCreatures)
            {
                var characterQuantity = characterCreature.Quantity;

                while (characterQuantity-- > 0)
                {
                    var character = GenerateCharacter(characterCreature, effectiveLevel);
                    characters.Add(character);
                }
            }

            return characters;
        }

        private bool IsCharacterCreature(string creatureType)
        {
            var characterCreatureType = GetCharacterCreatureType(creatureType);
            return string.IsNullOrEmpty(characterCreatureType) == false;
        }

        private string GetCharacterCreatureType(string fullCreatureType)
        {
            if (fullCreatureType.StartsWith(CreatureConstants.Character))
                return CreatureConstants.Character;

            if (fullCreatureType.StartsWith(CreatureConstants.NPC))
                return CreatureConstants.NPC;

            var undeadNPCCreatures = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UndeadNPC);
            if (undeadNPCCreatures.Any(c => fullCreatureType.StartsWith(c)))
                return undeadNPCCreatures.First(c => fullCreatureType.StartsWith(c));

            var classes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character);
            return classes.FirstOrDefault(cl => fullCreatureType.StartsWith(cl));
        }

        private Character GenerateCharacter(Creature creature, int effectiveLevel)
        {
            var characterCreatureType = GetCharacterCreatureType(creature.Type);
            setLevelRandomizer.SetLevel = GetCharacterLevel(creature.Type, effectiveLevel);
            setLevelRandomizer.AllowAdjustments = true;

            var undeadNPCCreatures = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UndeadNPC);
            if (undeadNPCCreatures.Contains(characterCreatureType))
            {
                setMetaraceRandomizer.SetMetarace = characterCreatureType;
                setLevelRandomizer.AllowAdjustments = false;

                return characterGenerator.GenerateWith(alignmentRandomizer, anyPlayerClassNameRandomizer, setLevelRandomizer, baseRaceRandomizer, setMetaraceRandomizer, statsRandomizer);
            }

            if (characterCreatureType == CreatureConstants.Character)
                return characterGenerator.GenerateWith(alignmentRandomizer, anyPlayerClassNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer);

            if (characterCreatureType == CreatureConstants.NPC)
                return characterGenerator.GenerateWith(alignmentRandomizer, anyNPCClassNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer);

            setClassNameRandomizer.SetClassName = characterCreatureType;
            return characterGenerator.GenerateWith(alignmentRandomizer, setClassNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer);
        }

        private int GetCharacterLevel(string characterCreatureType, int effectiveLevel)
        {
            var levelMatch = characterLevelRegex.Match(characterCreatureType);
            if (string.IsNullOrEmpty(levelMatch.Value))
                return 0;

            var roll = rollSelector.SelectRollFrom(levelMatch.Value);
            if (string.IsNullOrEmpty(roll))
            {
                var setLevel = setCharacterLevelRegex.Match(levelMatch.Value);
                return Convert.ToInt32(setLevel.Value);
            }

            var doubleRoll = rollSelector.SelectFrom(roll);
            return Convert.ToInt32(doubleRoll);
        }

        private bool ShouldReroll(IEnumerable<string> amounts, int modifier)
        {
            return amounts.Any(a => rollSelector.SelectFrom(a, modifier) == RollConstants.Reroll);
        }

        private Treasure GenerateTreasureFor(string creatureType, int level)
        {
            var coinMultiplier = adjustmentSelector.SelectFrom(TableNameConstants.TreasureAdjustments, creatureType, TreasureConstants.Coin);
            var goodsMultiplier = adjustmentSelector.SelectFrom(TableNameConstants.TreasureAdjustments, creatureType, TreasureConstants.Goods);
            var itemsMultiplier = adjustmentSelector.SelectFrom(TableNameConstants.TreasureAdjustments, creatureType, TreasureConstants.Items);

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
