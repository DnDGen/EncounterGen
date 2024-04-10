using DnDGen.EncounterGen.Generators.Exceptions;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Percentiles;

namespace DnDGen.EncounterGen.Generators
{
    internal class EncounterGenerator : IEncounterGenerator
    {
        private readonly IEncounterLevelSelector amountSelector;
        private readonly IPercentileSelector percentileSelector;
        private readonly IEncounterCharacterGenerator encounterCharacterGenerator;
        private readonly IEncounterTreasureGenerator encounterTreasureGenerator;
        private readonly IEncounterVerifier encounterVerifier;
        private readonly ICreatureGenerator creatureGenerator;

        public EncounterGenerator(IEncounterLevelSelector amountSelector,
            IPercentileSelector percentileSelector,
            IEncounterCharacterGenerator encounterCharacterGenerator,
            IEncounterTreasureGenerator encounterTreasureGenerator,
            IEncounterVerifier encounterVerifier,
            ICreatureGenerator creatureGenerator)
        {
            this.amountSelector = amountSelector;
            this.percentileSelector = percentileSelector;
            this.encounterTreasureGenerator = encounterTreasureGenerator;
            this.encounterCharacterGenerator = encounterCharacterGenerator;
            this.encounterVerifier = encounterVerifier;
            this.creatureGenerator = creatureGenerator;
        }

        public Encounter Generate(EncounterSpecifications encounterSpecifications)
        {
            var validEncounterExists = encounterVerifier.ValidEncounterExistsAtLevel(encounterSpecifications);
            if (!validEncounterExists)
                throw new ImpossibleEncounterException();

            var encounter = GenerateEncounter(encounterSpecifications);
            while (!encounterVerifier.EncounterIsValid(encounter, encounterSpecifications.CreatureTypeFilters))
                encounter = GenerateEncounter(encounterSpecifications);

            encounter.Treasures = encounterTreasureGenerator.GenerateFor(encounter.Creatures, encounter.ActualEncounterLevel);
            encounter.Creatures = creatureGenerator.CleanCreatures(encounter.Creatures);

            return encounter;
        }

        private Encounter GenerateEncounter(EncounterSpecifications encounterSpecifications)
        {
            var modifiedSpecifications = ModifySpecificationsWithEncounterLevel(encounterSpecifications);
            var encounter = new Encounter();

            encounter.Creatures = creatureGenerator.GenerateFor(modifiedSpecifications);
            encounter.Characters = encounterCharacterGenerator.GenerateFrom(encounter.Creatures);

            encounter.TargetEncounterLevel = encounterSpecifications.Level;
            encounter.AverageEncounterLevel = modifiedSpecifications.Level;
            encounter.ActualEncounterLevel = amountSelector.Select(encounter);

            return encounter;
        }

        private EncounterSpecifications ModifySpecificationsWithEncounterLevel(EncounterSpecifications source)
        {
            var modifiedSpecifications = source.Clone();

            do
            {
                var encounterLevelModifier = percentileSelector.SelectFrom<int>(TableNameConstants.EncounterLevelModifiers);
                modifiedSpecifications.Level = source.Level + encounterLevelModifier;
            }
            while (!encounterVerifier.ValidEncounterExistsAtLevel(modifiedSpecifications));

            return modifiedSpecifications;
        }
    }
}
