using EncounterGen.Common;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures
{
    [TestFixture]
    public class MephitSubtypeChallengeRatingsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, CreatureConstants.Mephit);
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var names = new[]
            {
                CreatureConstants.Mephit_Air,
                CreatureConstants.Mephit_Dust,
                CreatureConstants.Mephit_Earth,
                CreatureConstants.Mephit_Fire,
                CreatureConstants.Mephit_Ice,
                CreatureConstants.Mephit_Magma,
                CreatureConstants.Mephit_Ooze,
                CreatureConstants.Mephit_Salt,
                CreatureConstants.Mephit_Steam,
                CreatureConstants.Mephit_Water
            };

            AssertEntriesAreComplete(names);
        }

        [TestCase(CreatureConstants.Mephit_Air, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Dust, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Earth, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Fire, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Ice, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Magma, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Ooze, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Salt, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Steam, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Mephit_Water, ChallengeRatingConstants.Three)]
        public override void DistinctCollection(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }
    }
}
