using EncounterGen.Mappers;
using EncounterGen.Mappers.Domain.Percentiles;
using EncounterGen.Tables;
using Ninject;

namespace EncounterGen.Bootstrap.Factories
{
    public static class PercentileMapperFactory
    {
        public static PercentileMapper Create(IKernel kernel)
        {
            var streamLoader = kernel.Get<StreamLoader>();
            PercentileMapper mapper = new PercentileXmlMapper(streamLoader);

            mapper = new PercentileMapperCachingProxy(mapper);

            return mapper;
        }
    }
}
