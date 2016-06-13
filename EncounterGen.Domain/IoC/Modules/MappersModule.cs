using EncounterGen.Domain.Mappers.Collections;
using EncounterGen.Domain.Mappers.Percentiles;
using Ninject.Modules;

namespace EncounterGen.Domain.IoC.Modules
{
    internal class MappersModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PercentileMapper>().To<PercentileXmlMapper>().WhenInjectedInto<PercentileMapperCachingProxy>();
            Bind<PercentileMapper>().To<PercentileMapperCachingProxy>().InSingletonScope();

            Bind<CollectionMapper>().To<CollectionXmlMapper>().WhenInjectedInto<CollectionMapperCachingProxy>();
            Bind<CollectionMapper>().To<CollectionMapperCachingProxy>().InSingletonScope();
        }
    }
}
