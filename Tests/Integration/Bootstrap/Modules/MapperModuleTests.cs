using EncounterGen.Mappers;
using EncounterGen.Mappers.Domain.Collections;
using EncounterGen.Mappers.Domain.Percentiles;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Bootstrap.Modules
{
    [TestFixture]
    public class MapperModuleTests : BootstrapTests
    {
        [Test]
        public void PercentileMapperIsASingleton()
        {
            AssertSingleton<PercentileMapper>();
        }

        [Test]
        public void PercentileMapperHasCachingProxy()
        {
            AssertInstanceOf<PercentileMapper, PercentileMapperCachingProxy>();
        }

        [Test]
        public void CollectionMapperIsASingleton()
        {
            AssertSingleton<CollectionMapper>();
        }

        [Test]
        public void CollectionMapperHasCachingProxy()
        {
            AssertInstanceOf<CollectionMapper, CollectionMapperCachingProxy>();
        }
    }
}
