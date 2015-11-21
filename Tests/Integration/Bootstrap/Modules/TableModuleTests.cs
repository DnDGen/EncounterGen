using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Bootstrap.Modules
{
    [TestFixture]
    public class TableModuleTests : BootstrapTests
    {
        [Test]
        public void StreamLoaderIsNotASingleton()
        {
            AssertNotSingleton<StreamLoader>();
        }
    }
}
