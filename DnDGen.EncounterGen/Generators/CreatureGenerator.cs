using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.RollGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Generators
{
    internal class CreatureGenerator : ICreatureGenerator
    {
        private readonly Dice dice;
        private readonly ICollectionSelector collectionSelector;
        private readonly IEncounterFormatter encounterFormatter;
        private readonly IChallengeRatingSelector challengeRatingSelector;

        public CreatureGenerator(
            Dice dice,
            ICollectionSelector collectionSelector,
            IEncounterFormatter encounterFormatter,
            IChallengeRatingSelector challengeRatingSelector)
        {
            this.dice = dice;
            this.collectionSelector = collectionSelector;
            this.encounterFormatter = encounterFormatter;
            this.challengeRatingSelector = challengeRatingSelector;
        }

        public IEnumerable<Creature> CleanCreatures(IEnumerable<Creature> creatures)
        {
            foreach (var creature in creatures)
            {
                creature.Type = CleanCreatureType(creature.Type);
            }

            return creatures;
        }

        private EncounterCreature CleanCreatureType(EncounterCreature creatureType)
        {
            var baseRace = encounterFormatter.SelectBaseRaceFrom(creatureType.Name);
            var metarace = encounterFormatter.SelectMetaraceFrom(creatureType.Name);
            var subtype = encounterFormatter.SelectSubtypeFrom(creatureType.Name);

            if (string.IsNullOrEmpty(creatureType.Description))
                creatureType.Description = encounterFormatter.SelectDescriptionFrom(creatureType.Name);

            if (!string.IsNullOrEmpty(subtype) && creatureType.SubCreature == null)
            {
                creatureType.SubCreature = new EncounterCreature();
                creatureType.SubCreature.Name = subtype;
            }

            if (!string.IsNullOrEmpty(baseRace))
                creatureType.Name = baseRace;
            else if (!string.IsNullOrEmpty(metarace))
                creatureType.Name = metarace;
            else
                creatureType.Name = encounterFormatter.SelectNameFrom(creatureType.Name);

            if (creatureType.SubCreature != null)
                creatureType.SubCreature = CleanCreatureType(creatureType.SubCreature);

            return creatureType;
        }

        private IEnumerable<Creature> GetCreatures(string fullCreature, string amountRoll)
        {
            var quantity = dice.Roll(amountRoll).AsSum();
            if (quantity <= 0)
                return Enumerable.Empty<Creature>();

            var creature = new Creature();
            creature.Quantity = quantity;
            creature.Type = GetCreatureType(fullCreature);
            creature.ChallengeRating = challengeRatingSelector.SelectAverageForCreature(fullCreature);

            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);

            if (creaturesRequiringSubtypes.Contains(fullCreature) && SubtypeNotFilled(creature))
                return GetCreaturesWithRandomSubtype(creature);

            return new[] { creature };
        }

        private bool SubtypeNotFilled(Creature creature) => creature.Type.SubCreature == null || string.IsNullOrEmpty(creature.Type.SubCreature.Name);

        private EncounterCreature GetCreatureType(string fullCreature)
        {
            var creatureType = new EncounterCreature();
            creatureType.Name = fullCreature;
            creatureType.Description = encounterFormatter.SelectDescriptionFrom(fullCreature);

            var subtype = encounterFormatter.SelectSubtypeFrom(fullCreature);
            if (!string.IsNullOrEmpty(subtype))
                creatureType.SubCreature = GetCreatureType(subtype);

            return creatureType;
        }

        private IEnumerable<Creature> GetCreaturesWithRandomSubtype(Creature sourceCreature)
        {
            var creatures = new List<Creature>();

            while (creatures.Sum(c => c.Quantity) < sourceCreature.Quantity)
            {
                var subtype = GetRandomSubtype(sourceCreature.Type);
                var creature = creatures.FirstOrDefault(c => EncounterCreature.AreEqual(c.Type.SubCreature, subtype));

                if (creature == null)
                {
                    creature = new Creature();
                    creature.ChallengeRating = sourceCreature.ChallengeRating;
                    creature.Type.SubCreature = subtype;
                    creature.Type.Name = sourceCreature.Type.Name;
                    creature.Type.Description = sourceCreature.Type.Description;
                    creature.Quantity = 0;

                    creatures.Add(creature);
                }

                creature.Quantity++;
            }

            return creatures;
        }

        private EncounterCreature GetRandomSubtype(EncounterCreature sourceCreatureType)
        {
            var setChallengeRating = encounterFormatter.SelectChallengeRatingFrom(sourceCreatureType.Name);

            if (string.IsNullOrEmpty(setChallengeRating))
                throw new InvalidOperationException($"Cannot generate random subtype of {sourceCreatureType.Name} without a set challenge rating");

            var name = encounterFormatter.SelectNameFrom(sourceCreatureType.Name);
            var subtypeNames = collectionSelector.Explode(TableNameConstants.CreatureGroups, name);

            var challengeRatings = collectionSelector.SelectAllFrom(TableNameConstants.AverageChallengeRatings);
            var validSubtypeNames = subtypeNames.Where(s => challengeRatings[s].Single() == setChallengeRating);
            var fullSubtype = collectionSelector.SelectRandomFrom(validSubtypeNames);

            var subtype = new EncounterCreature();
            subtype.Name = fullSubtype;
            subtype.Description = encounterFormatter.SelectDescriptionFrom(fullSubtype);

            var creaturesRequiringSubtypes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubtype);
            var furtherFullSubtype = encounterFormatter.SelectSubtypeFrom(fullSubtype);

            if (!string.IsNullOrEmpty(furtherFullSubtype))
            {
                subtype.SubCreature = GetCreatureType(furtherFullSubtype);
            }
            else if (creaturesRequiringSubtypes.Contains(fullSubtype))
            {
                subtype.SubCreature = GetRandomSubtype(subtype);
            }

            return subtype;
        }

        public IEnumerable<Creature> GenerateFor(string encounter)
        {
            var creatureData = collectionSelector.SelectFrom(TableNameConstants.EncounterCreatures, encounter);
            var creaturesAndAmounts = encounterFormatter.SelectCreaturesAndAmountsFrom(creatureData);
            var creatures = new List<Creature>();

            foreach (var kvp in creaturesAndAmounts)
            {
                var creatureName = kvp.Key;
                var amount = kvp.Value;

                var subCreatures = GetCreatures(creatureName, amount);
                creatures.AddRange(subCreatures);
            }

            return creatures;
        }
    }
}
