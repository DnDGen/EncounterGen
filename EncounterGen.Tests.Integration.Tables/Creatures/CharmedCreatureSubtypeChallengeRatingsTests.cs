using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures
{
    [TestFixture]
    public class CharmedCreatureSubtypeChallengeRatingsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, CreatureConstants.CharmedCreature);
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var names = new[]
            {
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Spider_Monstrous_Colossal,
                CreatureConstants.Cryohydra_10Heads,
                CreatureConstants.Devourer,
                CreatureConstants.Elemental_Air_Elder,
                CreatureConstants.Elemental_Earth_Elder,
                CreatureConstants.Elemental_Fire_Elder,
                CreatureConstants.Elemental_Water_Elder,
                CreatureConstants.Hamatula,
                CreatureConstants.Hezrou,
                CreatureConstants.Hydra_12Heads,
                CreatureConstants.Pyrohydra_10Heads,
                CreatureConstants.Annis,
                CreatureConstants.Xorn_Average,
                CreatureConstants.Salamander_Average,
                CreatureConstants.Babau,
                CreatureConstants.Belker,
                CreatureConstants.Kyton,
                CreatureConstants.Digester,
                CreatureConstants.Ettin,
                CreatureConstants.Hydra_7Heads,
                CreatureConstants.Centipede_Monstrous_Gargantuan,
                CreatureConstants.Girallon,
                CreatureConstants.Lamia,
                CreatureConstants.Megaraptor,
                CreatureConstants.Pyrohydra_5Heads,
                CreatureConstants.Cryohydra_5Heads,
                CreatureConstants.ShamblingMound,
                CreatureConstants.Tendriculos,
                CreatureConstants.WillOWisp,
                CreatureConstants.Wyvern,
                CreatureConstants.Xill,
                CreatureConstants.Dragon_Blue_Young,
                CreatureConstants.Dragon_White_Juvenile,
                CreatureConstants.Dragon_Brass_Young,
                CreatureConstants.Dragon_Black_Adult,
                CreatureConstants.Dragon_Blue_YoungAdult,
                CreatureConstants.Dragon_Green_YoungAdult,
                CreatureConstants.Dragon_Copper_YoungAdult,
                CreatureConstants.Dragon_Gold_Juvenile,
            };

            AssertEntriesAreComplete(names);
        }

        [TestCase(CreatureConstants.Giant_Cloud, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Cryohydra_10Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Devourer, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Elemental_Air_Elder, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Elemental_Earth_Elder, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Elemental_Fire_Elder, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Elemental_Water_Elder, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Hamatula, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Hezrou, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Hydra_12Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Pyrohydra_10Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Annis, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Xorn_Average, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Salamander_Average, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Babau, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Belker, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Kyton, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Digester, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Ettin, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Hydra_7Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Girallon, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Lamia, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Megaraptor, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Pyrohydra_5Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Cryohydra_5Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.ShamblingMound, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Tendriculos, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.WillOWisp, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Wyvern, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Xill, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Blue_Young, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Brass_Young, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Black_Adult, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile, ChallengeRatingConstants.Eleven)]
        public override void DistinctCollection(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }
    }
}
