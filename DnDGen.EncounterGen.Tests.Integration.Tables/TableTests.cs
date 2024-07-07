using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration.Tables
{
    [TestFixture, Table]
    public abstract class TableTests : IntegrationTests
    {
        protected abstract string tableName { get; }
    }
}
