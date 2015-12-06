using EncounterGen.Bootstrap.Factories;
using EncounterGen.Mappers;
using Ninject.Modules;

namespace EncounterGen.Bootstrap.Modules
{
    public class MappersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PercentileMapper>().ToMethod(c => PercentileMapperFactory.Create(c.Kernel)).InSingletonScope();
            Bind<CollectionMapper>().ToMethod(c => CollectionMapperFactory.Create(c.Kernel)).InSingletonScope();
        }
    }
}
