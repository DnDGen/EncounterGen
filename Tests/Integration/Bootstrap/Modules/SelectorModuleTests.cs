using EncounterGen.Selectors;
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
        public void AdjustmentSelectorIsNotASingleton()
        {
            AssertNotSingleton<IAdjustmentSelector>();
        }
    }
}
