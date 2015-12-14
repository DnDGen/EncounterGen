using EncounterGen.Mappers;
using EncounterGen.Mappers.Domain.Collections;
using EncounterGen.Tables;
using Ninject;

namespace EncounterGen.Bootstrap.Factories
{
    public static class CollectionMapperFactory
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
