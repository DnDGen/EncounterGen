using EncounterGen.Domain.IoC.Providers;
using EncounterGen.Generators;
using Ninject.Modules;

namespace EncounterGen.Domain.IoC.Modules
{
    internal class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEncounterGenerator>().ToProvider<EncounterGeneratorProvider>();
        }
    }
}
