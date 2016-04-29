using EncounterGen.Domain.Mappers.Collections;
using EncounterGen.Domain.Tables;
using Ninject;

namespace EncounterGen.Domain.IoC.Factories
{
    internal static class CollectionMapperFactory
    {
        public static CollectionMapper Create(IKernel kernel)
        {
            var streamLoader = kernel.Get<StreamLoader>();
            CollectionMapper mapper = new CollectionXmlMapper(streamLoader);

            mapper = new CollectionMapperCachingProxy(mapper);

            return mapper;
        }
    }
}
