using EncounterGen.Generators;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Bootstrap.Modules
{
    [TestFixture]
    public class GeneratorModuleTests : BootstrapTests
    {
        [Test]
        public void EncounterGeneratorIsNotASingleton()
        {
            AssertNotSingleton<IEncounterGenerator>();
        }
    }
}
