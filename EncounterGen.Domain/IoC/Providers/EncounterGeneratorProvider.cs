using CharacterGen;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using CharacterGen.Randomizers.Stats;
using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Generators;
using Ninject;
using Ninject.Activation;
using RollGen;
using TreasureGen.Coins;
using TreasureGen.Goods;
using TreasureGen.Items;

namespace EncounterGen.Domain.IoC.Providers
{
    class EncounterGeneratorProvider : Provider<IEncounterGenerator>
    {
        protected override IEncounterGenerator CreateInstance(IContext context)
        {
            var typeAndAmountPercentileSelector = context.Kernel.Get<ITypeAndAmountPercentileSelector>();
            var coinGenerator = context.Kernel.Get<ICoinGenerator>();
            var goodsGenerator = context.Kernel.Get<IGoodsGenerator>();
            var itemsGenerator = context.Kernel.Get<IItemsGenerator>();
            var characterGenerator = context.Kernel.Get<ICharacterGenerator>();
            var alignmentRandomizer = context.Kernel.Get<IAlignmentRandomizer>(AlignmentRandomizerTypeConstants.Any);
            var anyPlayerclassNameRandomizer = context.Kernel.Get<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyPlayer);
            var anyNPCClassNameRandomizer = context.Kernel.Get<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyNPC);
            var setClassNameRandomizer = context.Kernel.Get<ISetClassNameRandomizer>();
            var setLevelRandomizer = context.Kernel.Get<ISetLevelRandomizer>();
            var baseRaceRandomizer = context.Kernel.Get<RaceRandomizer>(RaceRandomizerTypeConstants.BaseRace.AnyBase);
            var metaraceRandomizer = context.Kernel.Get<RaceRandomizer>(RaceRandomizerTypeConstants.Metarace.AnyMeta);
            var statsRandomizer = context.Kernel.Get<IStatsRandomizer>(StatsRandomizerTypeConstants.Raw);
            var adjustmentSelector = context.Kernel.Get<IAdjustmentSelector>();
            var rollSelector = context.Kernel.Get<IRollSelector>();
            var percentileSelector = context.Kernel.Get<IPercentileSelector>();
            var booleanPercentileSelector = context.Kernel.Get<IBooleanPercentileSelector>();
            var collectionSelector = context.Kernel.Get<ICollectionSelector>();
            var setMetaraceRandomizer = context.Kernel.Get<ISetMetaraceRandomizer>();
            var dice = context.Kernel.Get<Dice>();

            return new EncounterGenerator(typeAndAmountPercentileSelector, coinGenerator, goodsGenerator, itemsGenerator, characterGenerator, alignmentRandomizer,
                anyPlayerclassNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer, adjustmentSelector, rollSelector, percentileSelector,
                booleanPercentileSelector, collectionSelector, setMetaraceRandomizer, anyNPCClassNameRandomizer, setClassNameRandomizer, dice);
        }
    }
}
