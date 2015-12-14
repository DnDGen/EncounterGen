using EncounterGen.Tables;
using EncounterGen.Tables.Domain;
using Ninject.Modules;

namespace EncounterGen.Bootstrap.Modules
{
    public class TablesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<StreamLoader>().To<EmbeddedResourceStreamLoader>();
        }
    }
}
