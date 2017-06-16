using EncounterGen.Domain.Generators.Factories;
using EncounterGen.Domain.Mappers.Collections;
using EncounterGen.Domain.Mappers.Percentiles;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class MapperModuleTests : IoCTests
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

        [Test]
        public void JustInTimeFactoryIsNotASingleton()
        {
            AssertNotSingleton<JustInTimeFactory>();
        }
    }
}
