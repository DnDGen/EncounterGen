using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Generators
{
    internal class CreatureGenerator : ICreatureGenerator
    {
        private IAmountSelector amountSelector;
        private ICollectionSelector collectionSelector;
        private IEncounterCollectionSelector encounterCollectionSelector;
        private IEncounterSelector encounterSelector;

        public CreatureGenerator(IAmountSelector amountSelector, ICollectionSelector collectionSelector, IEncounterCollectionSelector encounterCollectionSelector, IEncounterSelector encounterSelector)
        {
            this.amountSelector = amountSelector;
            this.collectionSelector = collectionSelector;
            this.encounterCollectionSelector = encounterCollectionSelector;
            this.encounterSelector = encounterSelector;
        }

        public IEnumerable<Creature> CleanCreatures(IEnumerable<Creature> creatures)
        {
            foreach (var creature in creatures)
            {
                creature.Type = CleanCreatureType(creature.Type);
            }

            return creatures;
        }

        public IEnumerable<Creature> GenerateFor(EncounterSpecifications encounterSpecifications)
        {
            var creaturesAndAmounts = encounterCollectionSelector.SelectRandomFrom(encounterSpecifications);
            var creatures = creaturesAndAmounts.SelectMany(kvp => GetCreatures(kvp.Key, kvp.Value)).ToArray(); //INFO: Need to do immediate execution, as delayed causes problems with verification and cleaning

            return creatures;
        }

        private CreatureType CleanCreatureType(CreatureType creatureType)
        {
            var baseRace = encounterSelector.SelectBaseRaceFrom(creatureType.Name);
            var metarace = encounterSelector.SelectMetaraceFrom(creatureType.Name);
            var subtype = encounterSelector.SelectSubtypeFrom(creatureType.Name);

            if (string.IsNullOrEmpty(creatureType.Description))
                creatureType.Description = encounterSelector.SelectDescriptionFrom(creatureType.Name);

            if (!string.IsNullOrEmpty(subtype) && creatureType.SubType == null)
            {
                creatureType.SubType = new CreatureType();
                creatureType.SubType.Name = subtype;
            }

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
