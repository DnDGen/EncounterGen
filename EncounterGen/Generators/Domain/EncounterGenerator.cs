using CharacterGen.Generators;
using CharacterGen.Generators.Randomizers.Alignments;
using CharacterGen.Generators.Randomizers.CharacterClasses;
using CharacterGen.Generators.Randomizers.Races;
using CharacterGen.Generators.Randomizers.Stats;
using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Generators;

namespace EncounterGen.Generators.Domain
{
    public class EncounterGenerator : IEncounterGenerator
    {
        private ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector;
        private ITreasureGenerator treasureGenerator;
        private ICharacterGenerator characterGenerator;
        private IAlignmentRandomizer alignmentRandomizer;
        private IClassNameRandomizer classNameRandomizer;
        private ISetLevelRandomizer setLevelRandomizer;
        private RaceRandomizer baseRaceRandomizer;
        private RaceRandomizer metaraceRandomizer;
        private IStatsRandomizer statsRandomizer;
        private IAdjustmentSelector adjustmentSelector;

        public EncounterGenerator(ITypeAndAmountPercentileSelector typeAndAmountPercentileSelector, ITreasureGenerator treasureGenerator,
            ICharacterGenerator characterGenerator, IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer classNameRandomizer,
            ISetLevelRandomizer setLevelRandomizer, RaceRandomizer baseRaceRandomizer, RaceRandomizer metaraceRandomizer, IStatsRandomizer statsRandomizer,
            IAdjustmentSelector adjustmentSelector)
        {
            this.typeAndAmountPercentileSelector = typeAndAmountPercentileSelector;
            this.treasureGenerator = treasureGenerator;
            this.characterGenerator = characterGenerator;
            this.alignmentRandomizer = alignmentRandomizer;
            this.classNameRandomizer = classNameRandomizer;
            this.setLevelRandomizer = setLevelRandomizer;
            this.baseRaceRandomizer = baseRaceRandomizer;
            this.metaraceRandomizer = metaraceRandomizer;
            this.statsRandomizer = statsRandomizer;
            this.adjustmentSelector = adjustmentSelector;
        }

        public Encounter Generate(String environment, Int32 level)
        {
            var effectiveLevel = level;
            var tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, effectiveLevel, environment);
            var typesAndAmounts = typeAndAmountPercentileSelector.SelectFrom(tableName);

            while (typesAndAmounts.ContainsKey(EncounterConstants.Reroll))
            {
                effectiveLevel = typesAndAmounts[EncounterConstants.Reroll];
                tableName = String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, effectiveLevel, environment);
                typesAndAmounts = typeAndAmountPercentileSelector.SelectFrom(tableName);
            }

            var creatures = new List<String>();

            foreach (var kvp in typesAndAmounts)
                creatures.AddRange(Enumerable.Repeat<String>(kvp.Key, kvp.Value));

            var encounter = new Encounter();
            encounter.Creatures = creatures;

            var leadCreature = typesAndAmounts.First().Key;
            var treasureMultiplier = adjustmentSelector.SelectFrom(TableNameConstants.TreasureAdjustment, leadCreature);

            while (treasureMultiplier-- > 0)
            {
                var treasure = treasureGenerator.GenerateAtLevel(effectiveLevel);
                encounter.Treasures = encounter.Treasures.Union(new[] { treasure });
            }

            if (encounter.Creatures.Any(c => c == CreatureConstants.Character) == false)
                return encounter;

            var quantity = encounter.Creatures.Count(c => c == CreatureConstants.Character);
            setLevelRandomizer.SetLevel = adjustmentSelector.SelectFrom(TableNameConstants.CharacterLevel, effectiveLevel.ToString());

            while (quantity-- > 0)
            {
                var character = characterGenerator.GenerateWith(alignmentRandomizer, classNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer);
                encounter.Characters = encounter.Characters.Union(new[] { character });
            }

            return encounter;
        }
    }
}
