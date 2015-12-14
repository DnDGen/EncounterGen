using EncounterGen.Bootstrap.Modules;
using Ninject;

namespace EncounterGen.Bootstrap
{
    public class EncounterGenModuleLoader
    {
        public void LoadModules(IKernel kernel)
        {
            kernel.Load<GeneratorsModule>();
            kernel.Load<SelectorsModule>();
            kernel.Load<MappersModule>();
            kernel.Load<TablesModule>();
        }
    }
}
