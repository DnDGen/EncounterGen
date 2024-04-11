using DnDGen.Infrastructure.IoC;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration.Tables
{
    [TestFixture, Table]
    public abstract class TableTests : IntegrationTests
    {
        protected abstract string tableName { get; }

        [OneTimeSetUp]
        public void TableOneTimeSetup()
        {
            var infrastructureLoader = new InfrastructureModuleLoader();
            infrastructureLoader.ReplaceAssemblyLoaderWith<EncounterGenAssemblyLoader>(kernel);
        }
    }
}
