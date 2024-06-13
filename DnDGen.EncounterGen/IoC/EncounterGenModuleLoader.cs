using DnDGen.CharacterGen.IoC;
using DnDGen.EncounterGen.IoC.Modules;
using DnDGen.Infrastructure.IoC;
using DnDGen.RollGen.IoC;
using DnDGen.TreasureGen.IoC;
using Ninject;
using System.Linq;

namespace DnDGen.EncounterGen.IoC
{
    public class EncounterGenModuleLoader
    {
        public void LoadModules(IKernel kernel)
        {
            //Dependencies
            var rollGenLoader = new RollGenModuleLoader();
            rollGenLoader.LoadModules(kernel);

            var infrastructureLoader = new InfrastructureModuleLoader();
            infrastructureLoader.LoadModules(kernel);

            var treasureGenLoader = new TreasureGenModuleLoader();
            treasureGenLoader.LoadModules(kernel);

            var characterGenLoader = new CharacterGenModuleLoader();
            characterGenLoader.LoadModules(kernel);

            //EncounterGen
            var modules = kernel.GetModules();

            if (!modules.Any(m => m is GeneratorsModule))
                kernel.Load<GeneratorsModule>();

            if (!modules.Any(m => m is SelectorsModule))
                kernel.Load<SelectorsModule>();
        }
    }
}
