using CharacterGen.Generators;
using CharacterGen.Generators.Randomizers.Alignments;
using CharacterGen.Generators.Randomizers.CharacterClasses;
using CharacterGen.Generators.Randomizers.Races;
using CharacterGen.Generators.Randomizers.Stats;
using EncounterGen.Generators;
using EncounterGen.Generators.Domain;
using EncounterGen.Selectors;
using Ninject;
using TreasureGen.Generators;

namespace EncounterGen.Bootstrap.Factories
{
    public static class EncounterGeneratorFactory
    {
        public static IEncounterGenerator Create(IKernel kernel)
        {
            var typeAndAmountPercentileSelector = kernel.Get<ITypeAndAmountPercentileSelector>();
            var treasureGenerator = kernel.Get<ITreasureGenerator>();
            var characterGenerator = kernel.Get<ICharacterGenerator>();
            var alignmentRandomizer = kernel.Get<IAlignmentRandomizer>(AlignmentRandomizerTypeConstants.Any);
            var classNameRandomizer = kernel.Get<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.Any);
            var setLevelRandomizer = kernel.Get<ISetLevelRandomizer>();
            var baseRaceRandomizer = kernel.Get<RaceRandomizer>(RaceRandomizerTypeConstants.BaseRace.AnyBase);
            var metaraceRandomizer = kernel.Get<RaceRandomizer>(RaceRandomizerTypeConstants.Metarace.AnyMeta);
            var statsRandomizer = kernel.Get<IStatsRandomizer>(StatsRandomizerTypeConstants.Raw);
            var adjustmentSelector = kernel.Get<IAdjustmentSelector>();

            return new EncounterGenerator(typeAndAmountPercentileSelector, treasureGenerator, characterGenerator, alignmentRandomizer,
                classNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer, adjustmentSelector);
        }
    }
}
