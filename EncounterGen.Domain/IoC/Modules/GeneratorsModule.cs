using EncounterGen.Domain.IoC.Factories;
using EncounterGen.Generators;
using Ninject.Modules;

namespace EncounterGen.Domain.IoC.Modules
{
    internal class GeneratorsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEncounterGenerator>().ToMethod(c => EncounterGeneratorFactory.Create(c.Kernel));
        }
    }
}
