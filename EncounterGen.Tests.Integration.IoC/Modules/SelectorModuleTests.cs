using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Selectors.Percentiles;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class SelectorModuleTests : IoCTests
    {
        [Test]
        public void AmountSelectorIsNotASingleton()
        {
            AssertNotSingleton<IAmountSelector>();
        }

        [Test]
        public void PercentileSelectorIsNotASingleton()
        {
            AssertNotSingleton<IPercentileSelector>();
        }

        [Test]
        public void BooleanPercentileSelectorIsNotASingleton()
        {
            AssertNotSingleton<IBooleanPercentileSelector>();
        }

        [Test]
        public void AdjustmentSelectorIsNotASingleton()
        {
            AssertNotSingleton<IAdjustmentSelector>();
        }

        [Test]
        public void CollectionSelectorIsASingleton()
        {
            AssertSingleton<ICollectionSelector>();
        }

        [Test]
        public void CollectionSelectorHasCachingProxy()
        {
            AssertInstanceOf<ICollectionSelector, CollectionSelectorCachingProxy>();
        }

        [Test]
        public void EncounterCollectionSelectorIsASingleton()
        {
            AssertSingleton<IEncounterCollectionSelector>();
        }

        [Test]
        public void EncounterCollectionSelectorHasCachingProxy()
        {
            AssertInstanceOf<IEncounterCollectionSelector, EncounterCollectionSelectorCachingProxy>();
        }
    }
}
