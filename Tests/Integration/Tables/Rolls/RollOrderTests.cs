using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Rolls
{
    [TestFixture]
    public class RollOrderTests : CollectionTests
    {
        protected override String tableName
        {
            get
            {
                return TableNameConstants.RollOrder;
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var entries = new[] { "All" };
            AssertEntriesAreComplete(entries);
        }

        [TestCase("All",
            RollConstants.One,
            RollConstants.OneD2,
            RollConstants.OneD3,
            RollConstants.OneD3Plus1,
            RollConstants.OneD4Plus2,
            RollConstants.OneD6Plus3,
            RollConstants.OneD6Plus5,
            RollConstants.OneD4Plus10,
            RollConstants.Reroll)]
        public override void OrderedCollection(String entry, params String[] items)
        {
            base.Collection(entry, items);
        }
    }
}
