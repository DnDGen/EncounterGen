using EncounterGen.Domain.Mappers.Percentiles;
using EncounterGen.Domain.Tables;
using Ninject;

namespace EncounterGen.Domain.IoC.Factories
{
    internal static class PercentileMapperFactory
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
