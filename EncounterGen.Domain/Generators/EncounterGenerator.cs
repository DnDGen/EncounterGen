using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using EncounterGen.Generators.Exceptions;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TreasureGen;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterGenerator : IEncounterGenerator
    {
        private const int IterationLimit = 30000;

        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private IRollSelector rollSelector;
        private IPercentileSelector percentileSelector;
        private ICollectionSelector collectionSelector;
        private Regex challengeRatingRegex;
        private Regex subTypeRegex;
        private Dice dice;
        private IEncounterCharacterGenerator encounterCharacterGenerator;
        private IEncounterTreasureGenerator encounterTreasureGenerator;
        private IFilterVerifier filterVerifier;
        private IEncounterCollectionSelector creatureCollectionSelector;

        public EncounterGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, IRollSelector rollSelector, IPercentileSelector percentileSelector,
            ICollectionSelector collectionSelector, Dice dice, IEncounterCharacterGenerator encounterCharacterGenerator, IEncounterTreasureGenerator encounterTreasureGenerator,
            IFilterVerifier filterVerifier, IEncounterCollectionSelector creatureCollectionSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.rollSelector = rollSelector;
            this.percentileSelector = percentileSelector;
            this.collectionSelector = collectionSelector;
            this.dice = dice;
            this.encounterTreasureGenerator = encounterTreasureGenerator;
            this.encounterCharacterGenerator = encounterCharacterGenerator;
            this.filterVerifier = filterVerifier;
            this.creatureCollectionSelector = creatureCollectionSelector;

            challengeRatingRegex = new Regex(RegexConstants.ChallengeRatingPattern);
            subTypeRegex = new Regex(RegexConstants.DescriptionPattern);
        }

        public Encounter Generate(string environment, int level, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            var filtersAreValid = filterVerifier.FiltersAreValid(environment, level, temperature, timeOfDay, creatureTypeFilters);
            if (!filtersAreValid)
                throw new ImpossibleEncounterException();

            var tableName = string.Format(TableNameConstants.LevelXEncounterLevel, level);
            var encounterLevelAndModifier = typeAndAmountPercentileSelector.SelectFrom(tableName).Single();
            var encounterLevel = Convert.ToInt32(encounterLevelAndModifier.Key);
            var modifier = Convert.ToInt32(encounterLevelAndModifier.Value);
            var creatures = new List<Creature>();

            while (creatures.Any() == false || creatures.Contains(null))
            {
                creatures.Clear();

                var encounterCreaturesAndAmounts = creatureCollectionSelector.SelectFrom(encounterLevel, environment, temperature, timeOfDay);
                var iterations = 0;

                while (!filterVerifier.EncounterIsValid(encounterCreaturesAndAmounts, modifier, creatureTypeFilters) && iterations++ < IterationLimit)
                {
                    tableName = string.Format(TableNameConstants.LevelXEncounterLevel, level);
                    encounterLevelAndModifier = typeAndAmountPercentileSelector.SelectFrom(tableName).Single();
                    encounterLevel = Convert.ToInt32(encounterLevelAndModifier.Key);
                    modifier = Convert.ToInt32(encounterLevelAndModifier.Value);

                    encounterCreaturesAndAmounts = creatureCollectionSelector.SelectFrom(encounterLevel, environment, temperature, timeOfDay);
                }

                if (!filterVerifier.EncounterIsValid(encounterCreaturesAndAmounts, modifier, creatureTypeFilters))
                    throw new Exception($"Failed to generate level {level} creature for [{string.Join(",", creatureTypeFilters)}] in {temperature} {environment} {timeOfDay} after {iterations} iterations");

                foreach (var kvp in encounterCreaturesAndAmounts)
                {
                    var newCreature = GetCreature(kvp.Key, kvp.Value, modifier, level, encounterLevel);
                    creatures.Add(newCreature);
                }
            }

            var encounter = new Encounter();
            encounter.Characters = encounterCharacterGenerator.GenerateFrom(creatures);
            encounter.Creatures = EditCreatureTypes(creatures);

            var leadCreature = encounter.Creatures.First();
            encounter.Treasures = GetTreasures(encounter.Creatures, level);

            return encounter;
        }

        private IEnumerable<Treasure> GetTreasures(IEnumerable<Creature> creatures, int level)
        {
            var treasures = new List<Treasure>();

            foreach (var creature in creatures)
            {
                var treasure = encounterTreasureGenerator.GenerateFor(creature, level);

                if (treasure.IsAny)
                    treasures.Add(treasure);
            }

            return treasures;
        }

        private IEnumerable<Creature> EditCreatureTypes(IEnumerable<Creature> creatures)
        {
            var newCreatures = new List<Creature>();
            var creaturesToRemove = new List<Creature>();

            foreach (var creature in creatures)
            {
                creature.Name = GetCreatureType(creature.Name);

                if (dice.ContainsRoll(creature.Description, true) == false)
                    continue;

                creaturesToRemove.Add(creature);

                while (creature.Quantity-- > 0)
                {
                    var rolledCreature = new Creature();
                    rolledCreature.Quantity = 1;
                    rolledCreature.Name = creature.Name;
                    rolledCreature.Description = dice.ReplaceExpressionWithTotal(creature.Description, true);

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
            creature.Name = fullCreatureType;
            creature.Description = setSubtype;

            var effectiveRoll = rollSelector.SelectFrom(amount, modifier);
            creature.Quantity = dice.Roll(effectiveRoll);

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
            creature.Name = fullCreatureType;
            creature.Description = GenerateRandomSubtype(fullCreatureType, level, modifier, amount);

            if (creature.Description == null)
                return null;

            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);

            if (creaturesRequiringSubtypes.Contains(creature.Description))
            {
                var setChallengeRating = GetSetChallengeRating(fullCreatureType);
                var subSubtype = GenerateRandomSubtype(creature.Description, level, modifier, amount, setChallengeRating);

                creature.Description = string.Format("{0} ({1})", creature.Description, subSubtype);
            }

            creature.Quantity = GetRandomSubtypeQuantity(creature.Description, fullCreatureType, amount, modifier, level);

            return creature;
        }

        private string GenerateRandomSubtype(string fullCreatureType, int level, int modifier, string amount, string setChallengeRating = "")
        {
            var creatureType = GetCreatureType(fullCreatureType);

            if (string.IsNullOrEmpty(setChallengeRating))
                setChallengeRating = GetSetChallengeRating(fullCreatureType);

            var subtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, creatureType);
            var subtype = collectionSelector.SelectRandomFrom(subtypes);
            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);

            if (IsCharacterCreatureType(subtype) || creaturesRequiringSubtypes.Contains(subtype))
                return subtype;

            var effectiveRoll = GetEffectiveSubtypeRoll(creatureType, subtype, level, amount, modifier, setChallengeRating);
            var iteration = 1;

            while (effectiveRoll == RollConstants.Reroll && iteration++ < IterationLimit)
            {
                subtype = collectionSelector.SelectRandomFrom(subtypes);

                if (IsCharacterCreatureType(subtype) || creaturesRequiringSubtypes.Contains(subtype))
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

            if (string.IsNullOrEmpty(setChallengeRating) == false)
                return dice.Roll(effectiveRoll);

            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);

            if (creaturesRequiringSubtypes.Contains(subtype) == false)
            {
                effectiveRoll = GetEffectiveRoll(creatureType, fullSubtype, level);
                return dice.Roll(effectiveRoll);
            }

            if (string.IsNullOrEmpty(subSubtype))
            {
                effectiveRoll = GetEffectiveRoll(creatureType, subtype, level);
            }
            else
            {
                effectiveRoll = GetEffectiveRoll(subtype, subSubtype, level);
            }

            return dice.Roll(effectiveRoll);
        }

        private string GetEffectiveRoll(string creatureType, string subtype, int level)
        {
            var tableName = string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, creatureType);
            var challengeRating = collectionSelector.SelectFrom(tableName, subtype).Single();

            return rollSelector.SelectFrom(level, challengeRating);
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

        private string GetSetChallengeRating(string creatureType)
        {
            var levelMatch = challengeRatingRegex.Match(creatureType);
            if (string.IsNullOrEmpty(levelMatch.Value))
                return string.Empty;

            return levelMatch.Value.Substring(1, levelMatch.Value.Length - 2);
        }
    }
}
