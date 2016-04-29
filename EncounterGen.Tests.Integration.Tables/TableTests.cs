using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture, Table]
    public abstract class TableTests : IntegrationTests
    {
        protected abstract string tableName { get; }
    }
}
