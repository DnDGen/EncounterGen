using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using EncounterGen.Selectors.Domain.Percentiles;
using EncounterGen.Selectors.Percentiles;
using Ninject.Modules;

namespace EncounterGen.Bootstrap.Modules
{
    public class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITypeAndAmountPercentileSelector>().To<TypeAndAmountPercentileSelector>();
            Bind<IAdjustmentSelector>().To<AdjustmentSelector>();
            Bind<IRollSelector>().To<RollSelector>();
            Bind<IPercentileSelector>().To<PercentileSelector>();
            Bind<IBooleanPercentileSelector>().To<BooleanPercentileSelector>();
        }
    }
}
