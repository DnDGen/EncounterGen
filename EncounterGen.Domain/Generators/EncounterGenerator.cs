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
using TreasureGen;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterGenerator : IEncounterGenerator
    {
        private IAmountSelector amountSelector;
        private IPercentileSelector percentileSelector;
        private ICollectionSelector collectionSelector;
        private IEncounterCharacterGenerator encounterCharacterGenerator;
        private IEncounterTreasureGenerator encounterTreasureGenerator;
        private IEncounterVerifier encounterVerifier;
        private IEncounterCollectionSelector encounterCollectionSelector;
        private IEncounterSelector encounterSelector;

        public EncounterGenerator(IAmountSelector amountSelector,
            IPercentileSelector percentileSelector,
            ICollectionSelector collectionSelector,
            IEncounterCharacterGenerator encounterCharacterGenerator,
            IEncounterTreasureGenerator encounterTreasureGenerator,
            IEncounterVerifier encounterVerifier,
            IEncounterCollectionSelector encounterCollectionSelector,
            IEncounterSelector encounterSelector)
        {
            this.amountSelector = amountSelector;
            this.percentileSelector = percentileSelector;
            this.collectionSelector = collectionSelector;
            this.encounterTreasureGenerator = encounterTreasureGenerator;
            this.encounterCharacterGenerator = encounterCharacterGenerator;
            this.encounterVerifier = encounterVerifier;
            this.encounterCollectionSelector = encounterCollectionSelector;
            this.encounterSelector = encounterSelector;
        }

        public Encounter Generate(EncounterSpecifications encounterSpecifications)
        {
            var validEncounterExists = encounterVerifier.ValidEncounterExistsAtLevel(encounterSpecifications);
            if (!validEncounterExists)
                throw new ImpossibleEncounterException();

            var encounter = GenerateEncounter(encounterSpecifications);
            while (!encounterVerifier.EncounterIsValid(encounter, encounterSpecifications.CreatureTypeFilters))
                encounter = GenerateEncounter(encounterSpecifications);

            encounter.Treasures = GetTreasures(encounter.Creatures, encounter.ActualEncounterLevel);
            encounter.Creatures = CleanCreatures(encounter.Creatures);

            return encounter;
        }

        private Encounter GenerateEncounter(EncounterSpecifications encounterSpecifications)
        {
            var modifiedSpecifications = ModifySpecificationsWithEncounterLevel(encounterSpecifications);
            var creaturesAndAmounts = encounterCollectionSelector.SelectRandomFrom(modifiedSpecifications);
            var encounter = new Encounter();

            encounter.Creatures = creaturesAndAmounts.SelectMany(kvp => GetCreatures(kvp.Key, kvp.Value)).ToArray(); //INFO: Need to do immediate execution, as delayed causes problems with verification and cleaning
            encounter.Characters = encounterCharacterGenerator.GenerateFrom(encounter.Creatures);

            encounter.TargetEncounterLevel = encounterSpecifications.Level;
            encounter.AverageEncounterLevel = modifiedSpecifications.Level;
            encounter.ActualEncounterLevel = amountSelector.SelectActualEncounterLevel(encounter);

            return encounter;
        }

        private EncounterSpecifications ModifySpecificationsWithEncounterLevel(EncounterSpecifications source)
        {
            var modifiedSpecifications = source.Clone();

            do
            {
                var encounterLevelModifier = percentileSelector.SelectFrom(TableNameConstants.EncounterLevelModifiers);
                modifiedSpecifications.Level = source.Level + encounterLevelModifier;
            }
            while (!encounterVerifier.ValidEncounterExistsAtLevel(modifiedSpecifications));

            return modifiedSpecifications;
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
                creature.Type = CleanCreatureType(creature.Type);
            }

            return creatures;
        }

        private CreatureType CleanCreatureType(CreatureType creatureType)
        {
            var baseRace = encounterSelector.SelectBaseRaceFrom(creatureType.Name);
            var metarace = encounterSelector.SelectMetaraceFrom(creatureType.Name);

            if (!string.IsNullOrEmpty(baseRace))
                creatureType.Name = baseRace;
            else if (!string.IsNullOrEmpty(metarace))
                creatureType.Name = metarace;
            else
                creatureType.Name = encounterSelector.SelectNameFrom(creatureType.Name);

            if (creatureType.SubType != null)
                creatureType.SubType = CleanCreatureType(creatureType.SubType);

            return creatureType;
        }

        private IEnumerable<Creature> GetCreatures(string fullCreature, string amount)
        {
            var quantity = amountSelector.SelectFrom(amount);
            if (quantity <= 0)
                return Enumerable.Empty<Creature>();

            var creature = new Creature();
            creature.Quantity = quantity;
            creature.Type = GetCreatureType(fullCreature);
            creature.ChallengeRating = collectionSelector.SelectFrom(TableNameConstants.AverageChallengeRatings, fullCreature).Single();

            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);

            if (creaturesRequiringSubtypes.Contains(fullCreature) && (creature.Type.SubType == null || string.IsNullOrEmpty(creature.Type.SubType.Name)))
                return GetCreaturesWithRandomSubtype(creature);

            return new[] { creature };
        }

        private CreatureType GetCreatureType(string fullCreature)
        {
            var creatureType = new CreatureType();
            creatureType.Name = fullCreature;
            creatureType.Description = encounterSelector.SelectDescriptionFrom(fullCreature);

            var subtype = encounterSelector.SelectSubtypeFrom(fullCreature);
            if (!string.IsNullOrEmpty(subtype))
                creatureType.SubType = GetCreatureType(subtype);

            return creatureType;
        }

        private IEnumerable<Creature> GetCreaturesWithRandomSubtype(Creature sourceCreature)
        {
            var creatures = new List<Creature>();

            while (creatures.Sum(c => c.Quantity) < sourceCreature.Quantity)
            {
                var subtype = GetRandomSubtype(sourceCreature.Type);
                var creature = creatures.FirstOrDefault(c => AreEqual(c.Type.SubType, subtype));

                if (creature == null)
                {
                    creature = new Creature();
                    creature.ChallengeRating = sourceCreature.ChallengeRating;
                    creature.Type.SubType = subtype;
                    creature.Type.Name = sourceCreature.Type.Name;
                    creature.Type.Description = sourceCreature.Type.Description;
                    creature.Quantity = 0;

                    creatures.Add(creature);
                }

                creature.Quantity++;
            }

            return creatures;
        }

        private bool AreEqual(CreatureType source, CreatureType target)
        {
            if (source == null && target == null)
                return true;

            if (source == null ^ target == null)
                return false;

            var areEqual = source.Name == target.Name;
            areEqual &= source.Description == target.Description;
            areEqual &= AreEqual(source.SubType, target.SubType);

            return areEqual;
        }

        private CreatureType GetRandomSubtype(CreatureType sourceCreatureType)
        {
            var setChallengeRating = encounterSelector.SelectChallengeRatingFrom(sourceCreatureType.Name);

            if (string.IsNullOrEmpty(setChallengeRating))
                throw new InvalidOperationException($"Cannot generate random subtype of {sourceCreatureType.Name} without a set challenge rating");

            var name = encounterSelector.SelectNameFrom(sourceCreatureType.Name);
            var subtypeNames = collectionSelector.Explode(TableNameConstants.CreatureGroups, name);

            var validSubtypeNames = subtypeNames.Where(s => SubtypeIsValid(s, setChallengeRating));
            var fullSubtype = collectionSelector.SelectRandomFrom(validSubtypeNames);

            var subtype = new CreatureType();
            subtype.Name = fullSubtype;
            subtype.Description = encounterSelector.SelectDescriptionFrom(fullSubtype);

            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);
            var furtherFullSubtype = encounterSelector.SelectSubtypeFrom(fullSubtype);

            if (!string.IsNullOrEmpty(furtherFullSubtype))
            {
                subtype.SubType = GetCreatureType(furtherFullSubtype);
            }
            else if (creaturesRequiringSubtypes.Contains(fullSubtype))
            {
                subtype.SubType = GetRandomSubtype(subtype);
            }

            return subtype;
        }

        private bool SubtypeIsValid(string subtype, string challengeRating)
        {
            var creatureChallengeRating = collectionSelector.SelectFrom(TableNameConstants.AverageChallengeRatings, subtype).Single();
            return creatureChallengeRating == challengeRating;
        }
    }
}
