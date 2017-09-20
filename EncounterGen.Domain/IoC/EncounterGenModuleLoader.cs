using EncounterGen.Domain.IoC.Modules;
using Ninject;

namespace EncounterGen.Domain.IoC
{
    public class EncounterGenModuleLoader
    {
        public void LoadModules(IKernel kernel)
        {
            kernel.Load<GeneratorsModule>();
            kernel.Load<SelectorsModule>();
        }
    }
}
