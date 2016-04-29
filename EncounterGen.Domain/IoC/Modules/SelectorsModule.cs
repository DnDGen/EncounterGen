using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Percentiles;
using Ninject.Modules;

namespace EncounterGen.Domain.IoC.Modules
{
    internal class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITypeAndAmountPercentileSelector>().To<TypeAndAmountPercentileSelector>();
            Bind<IAdjustmentSelector>().To<AdjustmentSelector>();
            Bind<IRollSelector>().To<RollSelector>();
            Bind<IPercentileSelector>().To<PercentileSelector>();
            Bind<IBooleanPercentileSelector>().To<BooleanPercentileSelector>();
            Bind<ICollectionSelector>().To<CollectionSelector>();
        }
    }
}
