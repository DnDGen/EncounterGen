using EncounterGen.Domain.Tables;
using Ninject.Modules;

namespace EncounterGen.Domain.IoC.Modules
{
    internal class TablesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<StreamLoader>().To<EmbeddedResourceStreamLoader>();
        }
    }
}
