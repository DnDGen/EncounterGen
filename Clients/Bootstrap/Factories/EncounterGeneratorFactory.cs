using CharacterGen.Generators;
using CharacterGen.Generators.Randomizers.Alignments;
using CharacterGen.Generators.Randomizers.CharacterClasses;
using CharacterGen.Generators.Randomizers.Races;
using CharacterGen.Generators.Randomizers.Stats;
using EncounterGen.Generators;
using EncounterGen.Generators.Domain;
using EncounterGen.Selectors;
using EncounterGen.Selectors.Percentiles;
using Ninject;
using TreasureGen.Generators.Coins;
using TreasureGen.Generators.Goods;
using TreasureGen.Generators.Items;

namespace EncounterGen.Bootstrap.Factories
{
    public static class EncounterGeneratorFactory
    {
        public static IEncounterGenerator Create(IKernel kernel)
        {
            var typeAndAmountPercentileSelector = kernel.Get<ITypeAndAmountPercentileSelector>();
            var coinGenerator = kernel.Get<ICoinGenerator>();
            var goodsGenerator = kernel.Get<IGoodsGenerator>();
            var itemsGenerator = kernel.Get<IItemsGenerator>();
            var characterGenerator = kernel.Get<ICharacterGenerator>();
            var alignmentRandomizer = kernel.Get<IAlignmentRandomizer>(AlignmentRandomizerTypeConstants.Any);
            var classNameRandomizer = kernel.Get<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.Any);
            var setLevelRandomizer = kernel.Get<ISetLevelRandomizer>();
            var baseRaceRandomizer = kernel.Get<RaceRandomizer>(RaceRandomizerTypeConstants.BaseRace.AnyBase);
            var metaraceRandomizer = kernel.Get<RaceRandomizer>(RaceRandomizerTypeConstants.Metarace.AnyMeta);
            var statsRandomizer = kernel.Get<IStatsRandomizer>(StatsRandomizerTypeConstants.Raw);
            var adjustmentSelector = kernel.Get<IAdjustmentSelector>();
            var rollSelector = kernel.Get<IRollSelector>();
            var percentileSelector = kernel.Get<IPercentileSelector>();
            var booleanPercentileSelector = kernel.Get<IBooleanPercentileSelector>();

            return new EncounterGenerator(typeAndAmountPercentileSelector, coinGenerator, goodsGenerator, itemsGenerator, characterGenerator, alignmentRandomizer,
                classNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer, adjustmentSelector, rollSelector, percentileSelector,
                booleanPercentileSelector);
        }
    }
}
