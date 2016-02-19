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
        private Regex challengeRatingRegex;
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

            challengeRatingRegex = new Regex("\\[.+\\]");
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
                    var newCreature = GetCreature(kvp.Key, kvp.Value, modifier, level, effectiveLevel);
                    creatures.Add(newCreature);
                }
            }

            var encounter = new Encounter();
            encounter.Characters = GetCharacters(creatures);
            encounter.Creatures = EditCreatureTypes(creatures);

            var leadCreature = encounter.Creatures.First();
            encounter.Treasure = GenerateTreasureFor(leadCreature.Type, level);

            return encounter;
        }

        private IEnumerable<Creature> EditCreatureTypes(IEnumerable<Creature> creatures)
        {
            var newCreatures = new List<Creature>();
            var creaturesToRemove = new List<Creature>();

            foreach (var creature in creatures)
            {
                creature.Type = GetCreatureType(creature.Type);

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

        private Creature GetCreature(string fullCreatureType, string amount, int modifier, int level, int effectiveLevel)
        {
            var creatureType = GetCreatureType(fullCreatureType);
            var setSubtype = GetSubtype(fullCreatureType, effectiveLevel);
            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);

            if (creaturesRequiringSubtypes.Contains(creatureType) && string.IsNullOrEmpty(setSubtype))
                return GetCreatureWithRandomSubtype(fullCreatureType, level, modifier, amount, effectiveLevel);

            var creature = new Creature();
            creature.Type = fullCreatureType;
            creature.Subtype = setSubtype;

            var effectiveRoll = rollSelector.SelectFrom(amount, modifier);
            var doubleQuantity = rollSelector.SelectFrom(effectiveRoll);
            creature.Quantity = Convert.ToInt32(doubleQuantity);

            return creature;
        }

        private string GetCreatureType(string fullCreatureType)
        {
            var creatureType = subTypeRegex.Replace(fullCreatureType, string.Empty);
            creatureType = challengeRatingRegex.Replace(creatureType, string.Empty);

            return creatureType;
        }

        private string GetSubtype(string fullCreatureType, int effectiveLevel)
        {
            if (fullCreatureType == CreatureConstants.Dragon)
            {
                var tableName = string.Format(TableNameConstants.LevelXDragons, effectiveLevel);
                return percentileSelector.SelectFrom(tableName);
            }

            var subTypeMatch = subTypeRegex.Match(fullCreatureType);
            if (string.IsNullOrEmpty(subTypeMatch.Value))
                return string.Empty;

            var subType = subTypeMatch.Value.Replace(" (", string.Empty).Replace(")", string.Empty);
            subType = challengeRatingRegex.Replace(subType, string.Empty);

            return subType;
        }

        private Creature GetCreatureWithRandomSubtype(string fullCreatureType, int level, int modifier, string amount, int effectiveLevel)
        {
            var creature = new Creature();
            creature.Type = fullCreatureType;
            creature.Subtype = GenerateRandomSubtype(fullCreatureType, level, modifier, amount);

            if (creature.Subtype == null)
                return null;

            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);

            if (creaturesRequiringSubtypes.Contains(creature.Subtype))
            {
                var setChallengeRating = GetSetChallengeRating(fullCreatureType);
                var subSubtype = GenerateRandomSubtype(creature.Subtype, level, modifier, amount, setChallengeRating);

                creature.Subtype = string.Format("{0} ({1})", creature.Subtype, subSubtype);
            }

            creature.Quantity = GetRandomSubtypeQuantity(creature.Subtype, fullCreatureType, amount, modifier, level);

            return creature;
        }

        private string GenerateRandomSubtype(string fullCreatureType, int level, int modifier, string amount, string setChallengeRating = "")
        {
            var creatureType = GetCreatureType(fullCreatureType);

            if (string.IsNullOrEmpty(setChallengeRating))
                setChallengeRating = GetSetChallengeRating(fullCreatureType);

            var subtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, creatureType);
            var subtype = collectionSelector.SelectRandomFrom(subtypes);

            if (subtype == CreatureConstants.Dragon)
            {
                var dragonLevel = Convert.ToInt32(setChallengeRating);
                var dragonTableName = string.Format(TableNameConstants.LevelXDragons, dragonLevel);
                return percentileSelector.SelectFrom(dragonTableName);
            }

            if (IsCharacterCreatureType(subtype))
                return subtype;

            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);
            if (creaturesRequiringSubtypes.Contains(subtype))
                return subtype;

            var effectiveRoll = GetEffectiveSubtypeRoll(creatureType, subtype, level, amount, modifier, setChallengeRating);
            var iteration = 1;

            while (effectiveRoll == RollConstants.Reroll && iteration++ < IterationLimit)
            {
                subtype = collectionSelector.SelectRandomFrom(subtypes);

                if (creaturesRequiringSubtypes.Contains(subtype))
                    return subtype;

                effectiveRoll = GetEffectiveSubtypeRoll(creatureType, subtype, level, amount, modifier, setChallengeRating);
            }

            if (effectiveRoll == RollConstants.Reroll)
                return null;

            return subtype;
        }

        private string GetEffectiveSubtypeRoll(string creatureType, string subtype, int level, string amount, int modifier, string setChallengeRating)
        {
            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, creatureType);
            var challengeRating = collectionSelector.SelectFrom(tableName, subtype).Single();

            if (string.IsNullOrEmpty(setChallengeRating))
                return rollSelector.SelectFrom(level, challengeRating);

            if (challengeRating != setChallengeRating)
                return RollConstants.Reroll;

            return rollSelector.SelectFrom(amount, modifier);
        }

        private int GetRandomSubtypeQuantity(string fullSubtype, string fullCreatureType, string amount, int modifier, int level)
        {
            var creatureType = GetCreatureType(fullCreatureType);
            var subtype = GetCreatureType(fullSubtype);
            var subSubtype = GetSubtype(fullSubtype, level);
            var setChallengeRating = GetSetChallengeRating(fullCreatureType);
            var effectiveRoll = rollSelector.SelectFrom(amount, modifier);

            if (string.IsNullOrEmpty(setChallengeRating) && string.IsNullOrEmpty(subSubtype))
            {
                effectiveRoll = GetEffectiveRoll(creatureType, subtype, level);
            }
            else if (string.IsNullOrEmpty(setChallengeRating) && string.IsNullOrEmpty(subSubtype) == false)
            {
                effectiveRoll = GetEffectiveRoll(subtype, subSubtype, level);
            }

            var doubleQuantity = rollSelector.SelectFrom(effectiveRoll);

            return Convert.ToInt32(doubleQuantity);
        }

        private string GetEffectiveRoll(string creatureType, string subtype, int level)
        {
            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, creatureType);
            var challengeRating = collectionSelector.SelectFrom(tableName, subtype).Single();

            return rollSelector.SelectFrom(level, challengeRating);
        }

        private IEnumerable<Character> GetCharacters(IEnumerable<Creature> creatures)
        {
            var characters = new List<Character>();
            var characterCreatures = creatures.Where(c => IsCharacterCreatureType(c.Type) || IsCharacterCreatureType(c.Subtype));

            foreach (var characterCreature in characterCreatures)
            {
                var characterQuantity = characterCreature.Quantity;

                while (characterQuantity-- > 0)
                {
                    var character = GenerateCharacter(characterCreature);
                    characters.Add(character);
                }
            }

            return characters;
        }

        private bool IsCharacterCreatureType(string fullCreatureType)
        {
            var characterCreatureType = GetCreatureTypeCharacter(fullCreatureType);

            return string.IsNullOrEmpty(characterCreatureType) == false;
        }

        private string GetCreatureTypeCharacter(string fullCreatureType)
        {
            var creatureType = GetCreatureType(fullCreatureType);

            var undeadNPCCreatures = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UndeadNPC);
            if (undeadNPCCreatures.Contains(creatureType))
                return creatureType;

            var classes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character);
            if (classes.Contains(creatureType))
                return creatureType;

            return string.Empty;
        }

        private string GetCharacterCreatureType(Creature creature)
        {
            var creatureType = GetCreatureTypeCharacter(creature.Type);

            if (string.IsNullOrEmpty(creatureType))
                return GetCreatureTypeCharacter(creature.Subtype);

            return creatureType;
        }

        private Character GenerateCharacter(Creature creature)
        {
            var characterCreatureType = GetCharacterCreatureType(creature);

            setLevelRandomizer.SetLevel = GetCharacterLevel(creature.Type);
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

        private int GetCharacterLevel(string characterCreatureType)
        {
            var challengeRating = GetSetChallengeRating(characterCreatureType);
            if (string.IsNullOrEmpty(challengeRating))
            {
                var message = string.Format("Character level was not provided for a character creature type \"{0}\"", characterCreatureType);
                throw new ArgumentException(message);
            }

            var doubleRoll = rollSelector.SelectFrom(challengeRating);
            return Convert.ToInt32(doubleRoll);
        }

        private string GetSetChallengeRating(string creatureType)
        {
            var levelMatch = challengeRatingRegex.Match(creatureType);
            if (string.IsNullOrEmpty(levelMatch.Value))
                return string.Empty;

            return levelMatch.Value.Substring(1, levelMatch.Value.Length - 2);
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
