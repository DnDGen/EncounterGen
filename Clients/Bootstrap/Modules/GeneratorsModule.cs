using EncounterGen.Generators;
using EncounterGen.Generators.Domain;
using Ninject.Modules;

namespace EncounterGen.Bootstrap.Modules
{
    public class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEncounterGenerator>().To<EncounterGenerator>();
        }
    }
}
