using EncounterGen.Bootstrap.Factories;
using EncounterGen.Generators;
using Ninject.Modules;

namespace EncounterGen.Bootstrap.Modules
{
    public class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEncounterGenerator>().ToMethod(c => EncounterGeneratorFactory.Create(c.Kernel));
        }
    }
}
