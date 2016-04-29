using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Percentiles;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class SelectorModuleTests : BootstrapTests
    {
        [Test]
        public void TypeAndAmountPercentileSelectorIsNotASingleton()
        {
            AssertNotSingleton<ITypeAndAmountPercentileSelector>();
        }

        [Test]
        public void RollSelectorIsNotASingleton()
        {
            AssertNotSingleton<IRollSelector>();
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
        public void CollectionSelectorIsNotASingleton()
        {
            AssertNotSingleton<ICollectionSelector>();
        }
    }
}
