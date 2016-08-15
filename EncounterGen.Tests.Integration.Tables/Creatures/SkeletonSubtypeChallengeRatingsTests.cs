using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures
{
    [TestFixture]
    public class SkeletonSubtypeChallengeRatingsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, CreatureConstants.Skeleton);
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var names = new[]
            {
                CreatureConstants.Androsphinx,
                CreatureConstants.Annis,
                CreatureConstants.Ape,
                CreatureConstants.Ape_Dire,
                CreatureConstants.Athach,
                CreatureConstants.Baboon,
                CreatureConstants.Badger,
                CreatureConstants.Badger_Dire,
                CreatureConstants.Basilisk,
                CreatureConstants.Bear_Black,
                CreatureConstants.Bear_Brown,
                CreatureConstants.Bear_Dire,
                CreatureConstants.Bear_Polar,
                CreatureConstants.Behir,
                CreatureConstants.Bison,
                CreatureConstants.BlinkDog,
                CreatureConstants.Boar,
                CreatureConstants.Boar_Dire,
                CreatureConstants.Bugbear,
                CreatureConstants.Bulette,
                CreatureConstants.Camel,
                CreatureConstants.Cat,
                CreatureConstants.Centaur,
                CreatureConstants.Cheetah,
                CreatureConstants.Chimera,
                CreatureConstants.Choker,
                CreatureConstants.Cockatrice,
                CreatureConstants.Criosphinx,
                CreatureConstants.Crocodile,
                CreatureConstants.Crocodile_Giant,
                CreatureConstants.Cryohydra_5Heads,
                CreatureConstants.Cryohydra_6Heads,
                CreatureConstants.Cryohydra_7Heads,
                CreatureConstants.Cryohydra_8Heads,
                CreatureConstants.Cryohydra_9Heads,
                CreatureConstants.Cryohydra_10Heads,
                CreatureConstants.Cryohydra_11Heads,
                CreatureConstants.Cryohydra_12Heads,
                CreatureConstants.Delver,
                CreatureConstants.Derro,
                CreatureConstants.Destrachan,
                CreatureConstants.Digester,
                CreatureConstants.Deinonychus,
                CreatureConstants.Dog,
                CreatureConstants.Donkey,
                CreatureConstants.Doppelganger,
                CreatureConstants.Dragon_Black_Wyrmling,
                CreatureConstants.Dragon_Black_VeryYoung,
                CreatureConstants.Dragon_Black_Young,
                CreatureConstants.Dragon_Black_Juvenile,
                CreatureConstants.Dragon_Black_YoungAdult,
                CreatureConstants.Dragon_Black_Adult,
                CreatureConstants.Dragon_Blue_Wyrmling,
                CreatureConstants.Dragon_Blue_VeryYoung,
                CreatureConstants.Dragon_Blue_Young,
                CreatureConstants.Dragon_Blue_Juvenile,
                CreatureConstants.Dragon_Blue_YoungAdult,
                CreatureConstants.Dragon_Brass_Wyrmling,
                CreatureConstants.Dragon_Brass_VeryYoung,
                CreatureConstants.Dragon_Brass_Young,
                CreatureConstants.Dragon_Brass_Juvenile,
                CreatureConstants.Dragon_Brass_YoungAdult,
                CreatureConstants.Dragon_Brass_Adult,
                CreatureConstants.Dragon_Bronze_Wyrmling,
                CreatureConstants.Dragon_Bronze_VeryYoung,
                CreatureConstants.Dragon_Bronze_Young,
                CreatureConstants.Dragon_Bronze_Juvenile,
                CreatureConstants.Dragon_Bronze_YoungAdult,
                CreatureConstants.Dragon_Copper_Wyrmling,
                CreatureConstants.Dragon_Copper_VeryYoung,
                CreatureConstants.Dragon_Copper_Young,
                CreatureConstants.Dragon_Copper_Juvenile,
                CreatureConstants.Dragon_Copper_YoungAdult,
                CreatureConstants.Dragon_Copper_Adult,
                CreatureConstants.Dragon_Gold_Wyrmling,
                CreatureConstants.Dragon_Gold_VeryYoung,
                CreatureConstants.Dragon_Gold_Young,
                CreatureConstants.Dragon_Gold_Juvenile,
                CreatureConstants.Dragon_Gold_YoungAdult,
                CreatureConstants.Dragon_Green_Wyrmling,
                CreatureConstants.Dragon_Green_VeryYoung,
                CreatureConstants.Dragon_Green_Young,
                CreatureConstants.Dragon_Green_Juvenile,
                CreatureConstants.Dragon_Green_YoungAdult,
                CreatureConstants.Dragon_Red_Wyrmling,
                CreatureConstants.Dragon_Red_VeryYoung,
                CreatureConstants.Dragon_Red_Young,
                CreatureConstants.Dragon_Red_Juvenile,
                CreatureConstants.Dragon_Red_YoungAdult,
                CreatureConstants.Dragon_Silver_Wyrmling,
                CreatureConstants.Dragon_Silver_VeryYoung,
                CreatureConstants.Dragon_Silver_Young,
                CreatureConstants.Dragon_Silver_Juvenile,
                CreatureConstants.Dragon_Silver_YoungAdult,
                CreatureConstants.Dragon_White_Wyrmling,
                CreatureConstants.Dragon_White_VeryYoung,
                CreatureConstants.Dragon_White_Young,
                CreatureConstants.Dragon_White_Juvenile,
                CreatureConstants.Dragon_White_YoungAdult,
                CreatureConstants.Dragon_White_Adult,
                CreatureConstants.Dragonne,
                CreatureConstants.Dryad,
                CreatureConstants.Dwarf,
                CreatureConstants.Elephant,
                CreatureConstants.Elf,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Stone_Elder,
                CreatureConstants.Giant_Storm,
                CreatureConstants.Girallon,
                CreatureConstants.Gnoll,
                CreatureConstants.Gnome,
                CreatureConstants.Goblin,
                CreatureConstants.Gorgon,
                CreatureConstants.GrayRender,
                CreatureConstants.GreenHag,
                CreatureConstants.Griffon,
                CreatureConstants.Grimlock,
                CreatureConstants.Gynosphinx,
                CreatureConstants.Halfling,
                CreatureConstants.Harpy,
                CreatureConstants.Hieracosphinx,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Horse_Heavy,
                CreatureConstants.Horse_Heavy_War,
                CreatureConstants.Horse_Light,
                CreatureConstants.Horse_Light_War,
                CreatureConstants.Hippogriff,
                CreatureConstants.Hydra_5Heads,
                CreatureConstants.Hydra_6Heads,
                CreatureConstants.Hydra_7Heads,
                CreatureConstants.Hydra_8Heads,
                CreatureConstants.Hydra_9Heads,
                CreatureConstants.Hydra_10Heads,
                CreatureConstants.Hydra_11Heads,
                CreatureConstants.Hydra_12Heads,
                CreatureConstants.Dog_Hyena,
                CreatureConstants.Kobold,
                CreatureConstants.Krenshar,
                CreatureConstants.Lamia,
                CreatureConstants.Lammasu,
                CreatureConstants.Leopard,
                CreatureConstants.Lion,
                CreatureConstants.Lion_Dire,
                CreatureConstants.Lizard,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Manticore,
                CreatureConstants.Medusa,
                CreatureConstants.Megaraptor,
                CreatureConstants.MindFlayer,
                CreatureConstants.Minotaur,
                CreatureConstants.Monkey,
                CreatureConstants.Mule,
                CreatureConstants.Ogre,
                CreatureConstants.OgreMage,
                CreatureConstants.Orc,
                CreatureConstants.Otyugh,
                CreatureConstants.Owlbear,
                CreatureConstants.Pegasus,
                CreatureConstants.Pony,
                CreatureConstants.Pony_War,
                CreatureConstants.Pseudodragon,
                CreatureConstants.Pyrohydra_5Heads,
                CreatureConstants.Pyrohydra_6Heads,
                CreatureConstants.Pyrohydra_7Heads,
                CreatureConstants.Pyrohydra_8Heads,
                CreatureConstants.Pyrohydra_9Heads,
                CreatureConstants.Pyrohydra_10Heads,
                CreatureConstants.Pyrohydra_11Heads,
                CreatureConstants.Pyrohydra_12Heads,
                CreatureConstants.Rat_Dire,
                CreatureConstants.RazorBoar,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Satyr,
                CreatureConstants.SeaHag,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Tiger,
                CreatureConstants.Tiger_Dire,
                CreatureConstants.Triceratops,
                CreatureConstants.Troglodyte,
                CreatureConstants.Troll,
                CreatureConstants.Tyrannosaurus,
                CreatureConstants.Unicorn,
                CreatureConstants.Weasel,
                CreatureConstants.Weasel_Dire,
                CreatureConstants.WinterWolf,
                CreatureConstants.Wolf,
                CreatureConstants.Wolf_Dire,
                CreatureConstants.Wolverine,
                CreatureConstants.Wolverine_Dire,
                CreatureConstants.Worg,
                CreatureConstants.YuanTi_Abomination,
                CreatureConstants.YuanTi_Halfblood,
                CreatureConstants.YuanTi_Pureblood
            };

            AssertEntriesAreComplete(names);
        }

        [TestCase(CreatureConstants.Androsphinx, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Annis, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ape, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ape_Dire, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Athach, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Baboon, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Badger, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Badger_Dire, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Basilisk, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Bear_Black, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Bear_Brown, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Bear_Dire, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Bear_Polar, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Behir, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Bison, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.BlinkDog, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Boar, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Boar_Dire, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Bugbear, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Bulette, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Camel, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Cat, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Centaur, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Cheetah, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Chimera, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Choker, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Cockatrice, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Criosphinx, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Crocodile, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Crocodile_Giant, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Cryohydra_5Heads, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Cryohydra_6Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Cryohydra_7Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Cryohydra_8Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Cryohydra_9Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Cryohydra_10Heads, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Cryohydra_11Heads, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Cryohydra_12Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Delver, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Derro, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Destrachan, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Digester, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Deinonychus, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dog, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Donkey, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Doppelganger, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Black_Young, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Black_Adult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Blue_Young, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Brass_Young, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Brass_Adult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Bronze_Young, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Copper_Young, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Gold_Young, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Green_Young, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Red_Young, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Silver_Young, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_White_Young, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_White_Adult, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragonne, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dryad, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dwarf, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Elephant, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Elf, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Ettercap, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ettin, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Giant_Cloud, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Giant_Fire, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Giant_Frost, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Giant_Hill, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Giant_Stone, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Giant_Stone_Elder, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Giant_Storm, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Girallon, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Gnoll, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Gnome, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Goblin, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Gorgon, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.GrayRender, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.GreenHag, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Griffon, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Grimlock, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Gynosphinx, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Halfling, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Harpy, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Hieracosphinx, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Hobgoblin, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Horse_Heavy, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Horse_Heavy_War, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Horse_Light, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Horse_Light_War, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Hippogriff, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Hydra_5Heads, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Hydra_6Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Hydra_7Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Hydra_8Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Hydra_9Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Hydra_10Heads, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Hydra_11Heads, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Hydra_12Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dog_Hyena, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Kobold, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Krenshar, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Lamia, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Lammasu, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Leopard, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Lion, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Lion_Dire, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Lizard, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Lizard_Monitor, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Lizardfolk, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Manticore, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Medusa, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Megaraptor, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.MindFlayer, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Minotaur, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Monkey, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Mule, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Ogre, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.OgreMage, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Orc, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Otyugh, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Owlbear, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Pegasus, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Pony, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Pony_War, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Pseudodragon, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Pyrohydra_5Heads, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Pyrohydra_6Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Pyrohydra_7Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Pyrohydra_8Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Pyrohydra_9Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Pyrohydra_10Heads, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Pyrohydra_11Heads, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Pyrohydra_12Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Rat_Dire, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.RazorBoar, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Rhinoceras, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Satyr, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.SeaHag, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.ShockerLizard, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Tiger, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Tiger_Dire, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Triceratops, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Troglodyte, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Troll, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Tyrannosaurus, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Unicorn, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Weasel, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Weasel_Dire, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.WinterWolf, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Wolf, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Wolf_Dire, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Wolverine, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Wolverine_Dire, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Worg, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.YuanTi_Abomination, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.YuanTi_Halfblood, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.YuanTi_Pureblood, ChallengeRatingConstants.Three)]
        public override void DistinctCollection(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }
    }
}
