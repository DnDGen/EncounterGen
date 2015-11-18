using EncounterGen.Selectors;
using EncounterGen.Selectors.Domain;
using Ninject.Modules;

namespace EncounterGen.Bootstrap.Modules
{
    public class SelectorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITypeAndAmountPercentileSelector>().To<TypeAndAmountPercentileSelector>();
            Bind<IAdjustmentSelector>().To<AdjustmentSelector>();
        }
    }
}
