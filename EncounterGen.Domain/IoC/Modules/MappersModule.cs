using EncounterGen.Domain.IoC.Factories;
using EncounterGen.Domain.Mappers.Collections;
using EncounterGen.Domain.Mappers.Percentiles;
using Ninject.Modules;

namespace EncounterGen.Domain.IoC.Modules
{
    internal class MappersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PercentileMapper>().ToMethod(c => PercentileMapperFactory.Create(c.Kernel)).InSingletonScope();
            Bind<CollectionMapper>().ToMethod(c => CollectionMapperFactory.Create(c.Kernel)).InSingletonScope();
        }
    }
}
