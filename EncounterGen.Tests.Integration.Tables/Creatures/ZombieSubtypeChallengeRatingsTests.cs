using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures
{
    [TestFixture]
    public class ZombieSubtypeChallengeRatingsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, CreatureConstants.Zombie);
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
                CreatureConstants.Bat_Dire,
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
                CreatureConstants.Cloaker,
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
                CreatureConstants.DwarfWarrior,
                CreatureConstants.Eagle_Giant,
                CreatureConstants.Eagle,
                CreatureConstants.Elephant,
                CreatureConstants.ElfWarrior,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Storm,
                CreatureConstants.Girallon,
                CreatureConstants.Gnoll,
                CreatureConstants.GnomeWarrior,
                CreatureConstants.Goblin,
                CreatureConstants.Gorgon,
                CreatureConstants.GrayRender,
                CreatureConstants.GreenHag,
                CreatureConstants.Griffon,
                CreatureConstants.Grimlock,
                CreatureConstants.Gynosphinx,
                CreatureConstants.HalflingWarrior,
                CreatureConstants.Harpy,
                CreatureConstants.Hawk,
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
                CreatureConstants.Hyena,
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
                CreatureConstants.Owl,
                CreatureConstants.Owl_Giant,
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
                CreatureConstants.YuanTi_Pureblood,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.Snake_Viper_Huge,
                CreatureConstants.Snake_Viper_Large,
                CreatureConstants.Snake_Viper_Medium,
                CreatureConstants.Snake_Viper_Small,
                CreatureConstants.Wyvern,
            };

            AssertEntriesAreComplete(names);
        }

        [TestCase(CreatureConstants.Androsphinx, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Annis, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ape, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Ape_Dire, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Athach, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Baboon, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Badger, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Badger_Dire, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Bat_Dire, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Basilisk, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bear_Black, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Bear_Brown, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bear_Dire, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Bear_Polar, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Behir, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Bison, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.BlinkDog, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Boar, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Boar_Dire, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bugbear, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Bulette, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Camel, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Cat, ChallengeRatingConstants.OneEighth)]
        [TestCase(CreatureConstants.Centaur, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Cheetah, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Chimera, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Choker, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Cloaker, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Cockatrice, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Criosphinx, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Crocodile, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Crocodile_Giant, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Cryohydra_5Heads, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Cryohydra_6Heads, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Cryohydra_7Heads, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Cryohydra_8Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Cryohydra_9Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Cryohydra_10Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Cryohydra_11Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Cryohydra_12Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Delver, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Derro, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Destrachan, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Digester, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Deinonychus, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Dog, ChallengeRatingConstants.OneEighth)]
        [TestCase(CreatureConstants.Donkey, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Doppelganger, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Black_Young, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Black_Adult, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Blue_Young, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Brass_Young, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Brass_Adult, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Bronze_Young, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Copper_Young, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Gold_Young, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Green_Young, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Red_Young, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_Silver_Young, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_White_Young, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_White_Adult, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragonne, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Dryad, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.DwarfWarrior, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Eagle, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Eagle_Giant, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Elephant, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.ElfWarrior, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Ettercap, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Ettin, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Giant_Cloud, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Giant_Fire, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Giant_Frost, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Giant_Hill, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Giant_Stone, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Giant_Storm, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Girallon, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Gnoll, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.GnomeWarrior, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Goblin, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Gorgon, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.GrayRender, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.GreenHag, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Griffon, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Grimlock, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Gynosphinx, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.HalflingWarrior, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Harpy, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Hawk, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Hieracosphinx, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Hobgoblin, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Horse_Heavy, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Horse_Heavy_War, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Horse_Light, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Horse_Light_War, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Hippogriff, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Hydra_5Heads, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Hydra_6Heads, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Hydra_7Heads, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Hydra_8Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Hydra_9Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Hydra_10Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Hydra_11Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Hydra_12Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Hyena, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Kobold, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Krenshar, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Lamia, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Lammasu, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Leopard, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Lion, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Lion_Dire, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Lizard, ChallengeRatingConstants.OneEighth)]
        [TestCase(CreatureConstants.Lizard_Monitor, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Lizardfolk, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Manticore, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Medusa, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Megaraptor, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.MindFlayer, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Minotaur, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Monkey, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Mule, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Ogre, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.OgreMage, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Orc, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Otyugh, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Owl, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Owl_Giant, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Owlbear, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Pegasus, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Pony, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Pony_War, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Pseudodragon, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Pyrohydra_5Heads, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Pyrohydra_6Heads, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Pyrohydra_7Heads, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Pyrohydra_8Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Pyrohydra_9Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Pyrohydra_10Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Pyrohydra_11Heads, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Pyrohydra_12Heads, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Rat_Dire, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.RazorBoar, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Rhinoceras, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Satyr, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.SeaHag, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.ShockerLizard, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Tiger, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Tiger_Dire, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Triceratops, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Troglodyte, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Troll, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Tyrannosaurus, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Unicorn, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Weasel, ChallengeRatingConstants.OneEighth)]
        [TestCase(CreatureConstants.Weasel_Dire, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.WinterWolf, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Wolf, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Wolf_Dire, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Wolverine, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Wolverine_Dire, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Worg, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.YuanTi_Abomination, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.YuanTi_Halfblood, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.YuanTi_Pureblood, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Snake_Constrictor, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Snake_Viper_Huge, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Snake_Viper_Large, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Snake_Viper_Medium, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Snake_Viper_Small, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Wyvern, ChallengeRatingConstants.Two)]
        public override void DistinctCollection(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }
    }
}
