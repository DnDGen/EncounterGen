using EncounterGen.Tests.Integration.Common;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables
{
    [TestFixture, Table]
    public abstract class TableTests : IntegrationTests
    {
        protected abstract String tableName { get; }
    }
}
