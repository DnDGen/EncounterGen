using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Selectors.Percentiles;
using Ninject.Modules;

namespace EncounterGen.Domain.IoC.Modules
{
    internal class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAdjustmentSelector>().To<AdjustmentSelector>();
            Bind<IEncounterSelector>().To<EncounterSelector>();
            Bind<IAmountSelector>().To<AmountSelector>();
            Bind<IPercentileSelector>().To<PercentileSelector>();
            Bind<IBooleanPercentileSelector>().To<BooleanPercentileSelector>();
            Bind<IItemSelector>().To<ItemSelector>();

            Bind<ICollectionSelector>().To<CollectionSelector>().WhenInjectedInto<CollectionSelectorCachingProxy>();
            Bind<ICollectionSelector>().To<CollectionSelectorCachingProxy>().InSingletonScope();

            Bind<IEncounterCollectionSelector>().To<EncounterCollectionSelector>().WhenInjectedInto<EncounterCollectionSelectorCachingProxy>();
            Bind<IEncounterCollectionSelector>().To<EncounterCollectionSelectorCachingProxy>().InSingletonScope();
        }
    }
}
