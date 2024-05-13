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

        public IEnumerable<EncounterCreature> CleanCreatures(IEnumerable<EncounterCreature> creatures)
        {
            foreach (var creature in creatures)
            {
                creature.Creature = CleanCreature(creature.Creature);
            }

            return creatures;
        }

        private Creature CleanCreature(Creature creature)
        {
            var baseRace = encounterFormatter.SelectBaseRaceFrom(creature.Name);
            var metarace = encounterFormatter.SelectMetaraceFrom(creature.Name);
            var subcreature = encounterFormatter.SelectSubCreatureFrom(creature.Name);

            if (string.IsNullOrEmpty(creature.Description))
                creature.Description = encounterFormatter.SelectDescriptionFrom(creature.Name);

            if (!string.IsNullOrEmpty(subcreature) && creature.SubCreature == null)
            {
                creature.SubCreature = new Creature();
                creature.SubCreature.Name = subcreature;
            }

            if (!string.IsNullOrEmpty(baseRace))
                creature.Name = baseRace;
            else if (!string.IsNullOrEmpty(metarace))
                creature.Name = metarace;
            else
                creature.Name = encounterFormatter.SelectNameFrom(creature.Name);

            if (creature.SubCreature != null)
                creature.SubCreature = CleanCreature(creature.SubCreature);

            return creature;
        }

        private IEnumerable<EncounterCreature> GetCreatures(string fullCreature, string amountRoll)
        {
            var quantity = dice.Roll(amountRoll).AsSum();
            if (quantity <= 0)
                return Enumerable.Empty<EncounterCreature>();

            var creature = new EncounterCreature();
            creature.Quantity = quantity;
            creature.Creature = GetCreature(fullCreature);
            creature.ChallengeRating = challengeRatingSelector.SelectAverageForCreature(fullCreature);

            var creaturesRequiringSubcreatures = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubcreature);

            if (creaturesRequiringSubcreatures.Contains(fullCreature) && SubcreatureNotFilled(creature))
                return GetCreaturesWithRandomSubcreature(creature);

            return new[] { creature };
        }

        private bool SubcreatureNotFilled(EncounterCreature creature) => string.IsNullOrEmpty(creature.Creature.SubCreature?.Name);

        private Creature GetCreature(string fullCreature)
        {
            var creature = new Creature
            {
                Name = fullCreature,
                Description = encounterFormatter.SelectDescriptionFrom(fullCreature)
            };

            var subcreature = encounterFormatter.SelectSubCreatureFrom(fullCreature);
            if (!string.IsNullOrEmpty(subcreature))
                creature.SubCreature = GetCreature(subcreature);

            return creature;
        }

        private IEnumerable<EncounterCreature> GetCreaturesWithRandomSubcreature(EncounterCreature sourceCreature)
        {
            var creatures = new List<EncounterCreature>();

            while (creatures.Sum(c => c.Quantity) < sourceCreature.Quantity)
            {
                var subcreature = GetRandomSubcreature(sourceCreature.Creature);
                var creature = creatures.FirstOrDefault(c => Creature.AreEqual(c.Creature.SubCreature, subcreature));

                if (creature == null)
                {
                    creature = new EncounterCreature();
                    creature.ChallengeRating = sourceCreature.ChallengeRating;
                    creature.Creature.SubCreature = subcreature;
                    creature.Creature.Name = sourceCreature.Creature.Name;
                    creature.Creature.Description = sourceCreature.Creature.Description;
                    creature.Quantity = 0;

                    creatures.Add(creature);
                }

                creature.Quantity++;
            }

            return creatures;
        }

        private Creature GetRandomSubcreature(Creature sourceCreature)
        {
            var setChallengeRating = encounterFormatter.SelectChallengeRatingFrom(sourceCreature.Name);

            if (string.IsNullOrEmpty(setChallengeRating))
                throw new InvalidOperationException($"Cannot generate random sub-creature of {sourceCreature.Name} without a set challenge rating");

            var name = encounterFormatter.SelectNameFrom(sourceCreature.Name);
            var subcreatureNames = collectionSelector.Explode(TableNameConstants.CreatureGroups, name);

            //var challengeRatings = collectionSelector.SelectAllFrom(TableNameConstants.AverageChallengeRatings);
            //var validSubcreatureNames = subcreatureNames.Where(s => challengeRatings[s].Single() == setChallengeRating);
            var challengeRatingCreatures = collectionSelector.SelectFrom(TableNameConstants.AverageChallengeRatings, setChallengeRating);
            var validSubcreatureNames = subcreatureNames.Intersect(challengeRatingCreatures);

            var fullSubcreature = collectionSelector.SelectRandomFrom(validSubcreatureNames);

            var subcreature = new Creature();
            subcreature.Name = fullSubcreature;
            subcreature.Description = encounterFormatter.SelectDescriptionFrom(fullSubcreature);

            var creaturesRequiringSubcreatures = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.RequiresSubcreature);
            var furtherFullSubcreature = encounterFormatter.SelectSubCreatureFrom(fullSubcreature);

            if (!string.IsNullOrEmpty(furtherFullSubcreature))
            {
                subcreature.SubCreature = GetCreature(furtherFullSubcreature);
            }
            else if (creaturesRequiringSubcreatures.Contains(fullSubcreature))
            {
                subcreature.SubCreature = GetRandomSubcreature(subcreature);
            }

            return subcreature;
        }

        public IEnumerable<EncounterCreature> GenerateFor(string encounter)
        {
            var creatureData = collectionSelector.SelectFrom(TableNameConstants.EncounterCreatures, encounter);
            var creaturesAndAmounts = encounterFormatter.SelectCreaturesAndAmountsFrom(creatureData);
            var creatures = new List<EncounterCreature>();

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
