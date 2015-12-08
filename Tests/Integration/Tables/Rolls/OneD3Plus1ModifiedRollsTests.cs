using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Rolls
{
    [TestFixture]
    public class OneD3Plus1ModifiedRollsTests : CollectionTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.ROLLModifiedRolls, RollConstants.OneD3Plus1);
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var entries = new[]
            {
                ModifierConstants.OneThird,
                ModifierConstants.Half,
                ModifierConstants.TwoThirds,
                ModifierConstants.Same,
                ModifierConstants.HalfAgain,
                ModifierConstants.Double,
                ModifierConstants.Triple,
                ModifierConstants.Quadruple
            };

            AssertEntriesAreComplete(entries);
        }

        [TestCase(ModifierConstants.OneThird, RollConstants.One)]
        [TestCase(ModifierConstants.Half, RollConstants.OneD2)]
        [TestCase(ModifierConstants.TwoThirds, RollConstants.OneD3)]
        [TestCase(ModifierConstants.Same, RollConstants.OneD3Plus1)]
        [TestCase(ModifierConstants.HalfAgain, RollConstants.OneD4Plus2)]
        [TestCase(ModifierConstants.Double, RollConstants.OneD6Plus3)]
        [TestCase(ModifierConstants.Triple, RollConstants.OneD6Plus5)]
        [TestCase(ModifierConstants.Quadruple, RollConstants.OneD4Plus10)]
        public override void Collection(String entry, params String[] items)
        {
            base.Collection(entry, items);
        }
    }
}
