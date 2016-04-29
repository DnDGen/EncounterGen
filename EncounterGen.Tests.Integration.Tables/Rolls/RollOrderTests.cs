using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Rolls
{
    [TestFixture]
    public class RollOrderTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.RollOrder;
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var entries = new[] { "All", "CR" };
            AssertEntriesAreComplete(entries);
        }

        [TestCase("All",
            RollConstants.One,
            RollConstants.One,
            RollConstants.One,
            RollConstants.OneD2,
            RollConstants.OneD3,
            RollConstants.OneD3Plus1,
            RollConstants.OneD4Plus2,
            RollConstants.OneD6Plus3,
            RollConstants.OneD6Plus5,
            RollConstants.OneD4Plus10)]
        [TestCase("CR",
            ChallengeRatingConstants.OneTenth,
            ChallengeRatingConstants.OneEighth,
            ChallengeRatingConstants.OneSixth,
            ChallengeRatingConstants.OneFourth,
            ChallengeRatingConstants.OneThird,
            ChallengeRatingConstants.OneHalf,
            ChallengeRatingConstants.One,
            ChallengeRatingConstants.Two,
            ChallengeRatingConstants.Three,
            ChallengeRatingConstants.Four,
            ChallengeRatingConstants.Five,
            ChallengeRatingConstants.Six,
            ChallengeRatingConstants.Seven,
            ChallengeRatingConstants.Eight,
            ChallengeRatingConstants.Nine,
            ChallengeRatingConstants.Ten,
            ChallengeRatingConstants.Eleven,
            ChallengeRatingConstants.Twelve,
            ChallengeRatingConstants.Thirteen,
            ChallengeRatingConstants.Fourteen,
            ChallengeRatingConstants.Fifteen,
            ChallengeRatingConstants.Sixteen,
            ChallengeRatingConstants.Seventeen,
            ChallengeRatingConstants.Eighteen,
            ChallengeRatingConstants.Nineteen,
            ChallengeRatingConstants.Twenty,
            ChallengeRatingConstants.TwentyOne,
            ChallengeRatingConstants.TwentyTwo,
            ChallengeRatingConstants.TwentyThree,
            ChallengeRatingConstants.TwentyFour,
            ChallengeRatingConstants.TwentyFive,
            ChallengeRatingConstants.TwentySix,
            ChallengeRatingConstants.TwentySeven,
            ChallengeRatingConstants.TwentyEight,
            ChallengeRatingConstants.TwentyNine,
            ChallengeRatingConstants.Thirty)]
        public override void OrderedCollection(string entry, params string[] items)
        {
            base.Collection(entry, items);
        }
    }
}
