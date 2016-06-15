using EncounterGen.Domain.Generators;
using EncounterGen.Domain.IoC.Providers;
using EncounterGen.Generators;
using Ninject.Modules;

namespace EncounterGen.Domain.IoC.Modules
{
    internal class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEncounterGenerator>().To<EncounterGenerator>();
            Bind<IEncounterCharacterGenerator>().ToProvider<EncounterCharacterGeneratorProvider>();
            Bind<IEncounterTreasureGenerator>().To<EncounterTreasureGenerator>();
            Bind<IFilterVerifier>().To<FilterVerifier>();
        }
    }
}
