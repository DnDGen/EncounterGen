using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures
{
    [TestFixture]
    public class DominatedCreatureSubtypeChallengeRatingsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, CreatureConstants.DominatedCreature);
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var names = new[]
            {
                CreatureConstants.Aranea,
                CreatureConstants.HoundArchon,
                "Hound archon",
                CreatureConstants.Barghest,
                CreatureConstants.Bear_Brown,
                CreatureConstants.Boar_Dire,
                CreatureConstants.Wolverine_Dire,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Gargoyle,
                CreatureConstants.Crocodile_Giant,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Griffon,
                CreatureConstants.Harpy,
                CreatureConstants.Hydra_5Heads,
                CreatureConstants.Janni,
                CreatureConstants.Mimic,
                CreatureConstants.Otyugh,
                CreatureConstants.Owlbear,
                CreatureConstants.Pixie,
                CreatureConstants.Bear_Polar,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Tiger,
                CreatureConstants.VampireSpawn,
                CreatureConstants.Wereboar,
                CreatureConstants.Minotaur,
                CreatureConstants.CelestialCreature,
                CreatureConstants.FiendishCreature,
                CreatureConstants.Skeleton,
                CreatureConstants.Zombie,
                CreatureConstants.Character,
                CreatureConstants.Dragon_Black_VeryYoung,
                CreatureConstants.Dragon_Blue_VeryYoung,
                CreatureConstants.Dragon_Green_VeryYoung,
                CreatureConstants.Dragon_Red_Wyrmling,
                CreatureConstants.Dragon_White_Young,
                CreatureConstants.Dragon_Brass_VeryYoung,
                CreatureConstants.Dragon_Silver_Wyrmling,
            };

            AssertEntriesAreComplete(names);
        }

        [TestCase(CreatureConstants.Aranea, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.HoundArchon, ChallengeRatingConstants.Four)]
        [TestCase("Hound archon", ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Barghest, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Bear_Brown, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Boar_Dire, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Wolverine_Dire, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.DisplacerBeast, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Gargoyle, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Crocodile_Giant, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.StagBeetle_Giant, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Ooze_Gray, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Griffon, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Harpy, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Hydra_5Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Janni, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Mimic, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Otyugh, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Owlbear, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Pixie, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Bear_Polar, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Rhinoceras, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Tiger, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.VampireSpawn, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Wereboar, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Minotaur, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.CelestialCreature, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.FiendishCreature, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Skeleton, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Zombie, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Character, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_White_Young, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, ChallengeRatingConstants.Four)]
        public override void DistinctCollection(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }
    }
}
