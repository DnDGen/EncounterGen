using EncounterGen.Selectors;
using EncounterGen.Selectors.Percentiles;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Bootstrap.Modules
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
    }
}
