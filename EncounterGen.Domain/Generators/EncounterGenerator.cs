using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using EncounterGen.Generators.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TreasureGen;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterGenerator : IEncounterGenerator
    {
        private IAmountSelector amountSelector;
        private IPercentileSelector percentileSelector;
        private ICollectionSelector collectionSelector;
        private Regex challengeRatingRegex;
        private Regex descriptionRegex;
        private IEncounterCharacterGenerator encounterCharacterGenerator;
        private IEncounterTreasureGenerator encounterTreasureGenerator;
        private IEncounterVerifier encounterVerifier;
        private IEncounterCollectionSelector encounterCollectionSelector;

        public EncounterGenerator(IAmountSelector amountSelector, IPercentileSelector percentileSelector,
            ICollectionSelector collectionSelector, IEncounterCharacterGenerator encounterCharacterGenerator, IEncounterTreasureGenerator encounterTreasureGenerator,
            IEncounterVerifier encounterVerifier, IEncounterCollectionSelector encounterCollectionSelector)
        {
            this.amountSelector = amountSelector;
            this.percentileSelector = percentileSelector;
            this.collectionSelector = collectionSelector;
            this.encounterTreasureGenerator = encounterTreasureGenerator;
            this.encounterCharacterGenerator = encounterCharacterGenerator;
            this.encounterVerifier = encounterVerifier;
            this.encounterCollectionSelector = encounterCollectionSelector;

            challengeRatingRegex = new Regex(RegexConstants.ChallengeRatingPattern);
            descriptionRegex = new Regex(RegexConstants.DescriptionPattern);
        }

        public Encounter Generate(string environment, int level, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            var validEncounterExists = encounterVerifier.ValidEncounterExistsAtLevel(environment, level, temperature, timeOfDay, creatureTypeFilters);
            if (!validEncounterExists)
                throw new ImpossibleEncounterException();

            var encounterLevel = GetEncounterLevel(environment, level, temperature, timeOfDay, creatureTypeFilters);
            var creatures = Enumerable.Empty<Creature>();

            do
            {
                var creaturesAndAmounts = encounterCollectionSelector.SelectRandomFrom(encounterLevel, environment, temperature, timeOfDay, creatureTypeFilters);
                creatures = creaturesAndAmounts.SelectMany(kvp => GetCreatures(kvp.Key, kvp.Value)).ToArray(); //INFO: Need to do immediate execution, as delayed causes problems with verification and cleaning
            }
            while (!encounterVerifier.EncounterIsValid(creatures, creatureTypeFilters));

            var encounter = new Encounter();
            encounter.AverageEncounterLevel = encounterLevel;
            encounter.AverageDifficulty = GetDifficulty(level, encounterLevel);
            encounter.ActualEncounterLevel = amountSelector.SelectEncounterLevel(creatures);
            encounter.ActualDifficulty = GetDifficulty(level, encounter.ActualEncounterLevel);

            encounter.Characters = encounterCharacterGenerator.GenerateFrom(creatures);
            encounter.Creatures = CleanCreatures(creatures);
            //TODO: When undead NPCs become Characters with metaraces (as well as monsters with character classes), this will need to happen before cleaning creatures
            encounter.Treasures = GetTreasures(encounter.Creatures, encounter.ActualEncounterLevel);

            return encounter;
        }

        private string GetDifficulty(int level, int encounterLevel)
        {
            var difference = encounterLevel - level;

            if (difference < -4)
                return DifficultyConstants.VeryEasy;

            if (difference < 0)
                return DifficultyConstants.Easy;

            if (difference == 0)
                return DifficultyConstants.Challenging;

            if (difference < 5)
                return DifficultyConstants.VeryDifficult;

            return DifficultyConstants.Overpowering;
        }

        private int GetEncounterLevel(string environment, int level, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            var encounterLevel = 0;

            do
            {
                var encounterLevelModifier = percentileSelector.SelectFrom(TableNameConstants.EncounterLevelModifiers);
                encounterLevel = level + encounterLevelModifier;
            }
            while (!encounterVerifier.ValidEncounterExistsAtLevel(environment, encounterLevel, temperature, timeOfDay, creatureTypeFilters));

            return encounterLevel;
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

        private IEnumerable<Creature> CleanCreatures(IEnumerable<Creature> creatures)
        {
            foreach (var creature in creatures)
            {
                creature.Name = GetName(creature.Name);
                creature.Description = CleanDescription(creature.Description);
            }

            return creatures;
        }

        private IEnumerable<Creature> GetCreatures(string fullCreature, string amount)
        {
            var creature = new Creature();
            creature.Name = fullCreature;
            creature.Description = GetDescription(fullCreature);
            creature.Quantity = amountSelector.SelectFrom(amount);
            creature.ChallengeRating = collectionSelector.SelectFrom(TableNameConstants.ChallengeRatings, fullCreature).Single();

            if (creature.Quantity <= 0)
                return Enumerable.Empty<Creature>();

            var name = GetName(fullCreature);
            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);

            if (creaturesRequiringSubtypes.Contains(name) && string.IsNullOrEmpty(creature.Description))
                return GetCreaturesWithRandomSubtype(creature);

            return new[] { creature };
        }

        private string GetName(string fullCreature)
        {
            var name = descriptionRegex.Replace(fullCreature, string.Empty);
            name = challengeRatingRegex.Replace(name, string.Empty);

            return name;
        }

        private string GetDescription(string fullCreature)
        {
            var descriptionMatch = descriptionRegex.Match(fullCreature);
            if (string.IsNullOrEmpty(descriptionMatch.Value))
                return string.Empty;

            var description = descriptionMatch.Value.Replace(" (", string.Empty).Replace(")", string.Empty);
            description = challengeRatingRegex.Replace(description, string.Empty);

            return description;
        }

        private string CleanDescription(string description)
        {
            return challengeRatingRegex.Replace(description, string.Empty);
        }

        private IEnumerable<Creature> GetCreaturesWithRandomSubtype(Creature sourceCreature)
        {
            var creatures = new List<Creature>();

            for (var count = 0; count < sourceCreature.Quantity; count++)
            {
                var subtype = GetRandomSubtype(sourceCreature);
                var creature = new Creature();

                if (creatures.Any(c => c.Description == subtype))
                {
                    creature = creatures.First(c => c.Description == subtype);
                    creature.Quantity++;
                    continue;
                }

                creature.ChallengeRating = sourceCreature.ChallengeRating;
                creature.Description = subtype;
                creature.Name = sourceCreature.Name;
                creature.Quantity = 1;

                creatures.Add(creature);
            }

            return creatures;
        }

        private string GetRandomSubtype(Creature sourceCreature)
        {
            var setChallengeRating = GetChallengeRating(sourceCreature.Name);

            if (string.IsNullOrEmpty(setChallengeRating))
                throw new InvalidOperationException($"Cannot generate random subtype of {sourceCreature.Name} without a set challenge rating");

            var subtype = GenerateRandomSubtype(sourceCreature.Name, setChallengeRating);

            return subtype;
        }

        private string GenerateRandomSubtype(string fullCreature, string challengeRating)
        {
            var name = GetName(fullCreature);
            var subtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, name);

            var validSubtypes = subtypes.Where(s => SubtypeIsValid(s, challengeRating));
            var subtype = collectionSelector.SelectRandomFrom(validSubtypes);

            var trimmedSubtype = GetName(subtype);
            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);

            if (creaturesRequiringSubtypes.Contains(trimmedSubtype))
            {
                var furtherSubtype = GenerateRandomSubtype(subtype, challengeRating);
                return $"{subtype} ({furtherSubtype})";
            }

            return subtype;
        }

        private bool SubtypeIsValid(string subtype, string challengeRating)
        {
            var creatureChallengeRating = collectionSelector.SelectFrom(TableNameConstants.ChallengeRatings, subtype).Single();
            return creatureChallengeRating == challengeRating;
        }

        private string GetChallengeRating(string fullCreature)
        {
            var levelMatch = challengeRatingRegex.Match(fullCreature);
            if (string.IsNullOrEmpty(levelMatch.Value))
                return string.Empty;

            return levelMatch.Value.Substring(1, levelMatch.Value.Length - 2);
        }
    }
}
