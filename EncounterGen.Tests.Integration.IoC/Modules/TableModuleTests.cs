using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.IoC.Modules
{
    [TestFixture]
    public class TableModuleTests : IoCTests
    {
        [Test]
        public void StreamLoaderIsNotASingleton()
        {
            AssertNotSingleton<StreamLoader>();
        }
    }
}
