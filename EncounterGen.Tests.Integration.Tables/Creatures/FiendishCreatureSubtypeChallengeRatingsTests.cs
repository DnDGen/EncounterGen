using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures
{
    [TestFixture]
    public class FiendishCreatureSubtypeChallengeRatingsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, CreatureConstants.FiendishCreature);
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var names = new[]
            {
                CreatureConstants.Ankheg,
                CreatureConstants.Annis,
                CreatureConstants.Ant_Giant_Soldier,
                CreatureConstants.Ant_Giant_Worker,
                CreatureConstants.Ape,
                CreatureConstants.Ape_Dire,
                CreatureConstants.Aranea,
                CreatureConstants.AssassinVine,
                CreatureConstants.Athach,
                CreatureConstants.Baboon,
                CreatureConstants.Badger,
                CreatureConstants.Badger_Dire,
                CreatureConstants.Basilisk,
                CreatureConstants.Bat,
                CreatureConstants.Bat_Dire,
                CreatureConstants.Bear_Black,
                CreatureConstants.Bear_Brown,
                CreatureConstants.Bear_Dire,
                CreatureConstants.Bear_Polar,
                CreatureConstants.Bee_Giant,
                CreatureConstants.Behir,
                CreatureConstants.Bison,
                CreatureConstants.Boar,
                CreatureConstants.Boar_Dire,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Bugbear,
                CreatureConstants.Bulette,
                CreatureConstants.Camel,
                CreatureConstants.Cat,
                CreatureConstants.Centipede_Monstrous_Colossal,
                CreatureConstants.Centipede_Monstrous_Gargantuan,
                CreatureConstants.Centipede_Monstrous_Huge,
                CreatureConstants.Centipede_Monstrous_Large,
                CreatureConstants.Centipede_Monstrous_Medium,
                CreatureConstants.Centipede_Monstrous_Small,
                CreatureConstants.Centipede_Monstrous_Tiny,
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
                CreatureConstants.Darkmantle,
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
                CreatureConstants.Dragon_Black_MatureAdult,
                CreatureConstants.Dragon_Black_Old,
                CreatureConstants.Dragon_Black_VeryOld,
                CreatureConstants.Dragon_Black_Ancient,
                CreatureConstants.Dragon_Black_Wyrm,
                CreatureConstants.Dragon_Black_GreatWyrm,
                CreatureConstants.Dragon_Blue_Wyrmling,
                CreatureConstants.Dragon_Blue_VeryYoung,
                CreatureConstants.Dragon_Blue_Young,
                CreatureConstants.Dragon_Blue_Juvenile,
                CreatureConstants.Dragon_Blue_YoungAdult,
                CreatureConstants.Dragon_Blue_Adult,
                CreatureConstants.Dragon_Blue_MatureAdult,
                CreatureConstants.Dragon_Blue_Old,
                CreatureConstants.Dragon_Blue_VeryOld,
                CreatureConstants.Dragon_Blue_Ancient,
                CreatureConstants.Dragon_Blue_Wyrm,
                CreatureConstants.Dragon_Blue_GreatWyrm,
                CreatureConstants.Dragon_Green_Wyrmling,
                CreatureConstants.Dragon_Green_VeryYoung,
                CreatureConstants.Dragon_Green_Young,
                CreatureConstants.Dragon_Green_Juvenile,
                CreatureConstants.Dragon_Green_YoungAdult,
                CreatureConstants.Dragon_Green_Adult,
                CreatureConstants.Dragon_Green_MatureAdult,
                CreatureConstants.Dragon_Green_Old,
                CreatureConstants.Dragon_Green_VeryOld,
                CreatureConstants.Dragon_Green_Ancient,
                CreatureConstants.Dragon_Green_Wyrm,
                CreatureConstants.Dragon_Green_GreatWyrm,
                CreatureConstants.Dragon_Red_Wyrmling,
                CreatureConstants.Dragon_Red_VeryYoung,
                CreatureConstants.Dragon_Red_Young,
                CreatureConstants.Dragon_Red_Juvenile,
                CreatureConstants.Dragon_Red_YoungAdult,
                CreatureConstants.Dragon_Red_Adult,
                CreatureConstants.Dragon_Red_MatureAdult,
                CreatureConstants.Dragon_Red_Old,
                CreatureConstants.Dragon_Red_VeryOld,
                CreatureConstants.Dragon_Red_Ancient,
                CreatureConstants.Dragon_Red_Wyrm,
                CreatureConstants.Dragon_Red_GreatWyrm,
                CreatureConstants.Dragon_White_Wyrmling,
                CreatureConstants.Dragon_White_VeryYoung,
                CreatureConstants.Dragon_White_Young,
                CreatureConstants.Dragon_White_Juvenile,
                CreatureConstants.Dragon_White_YoungAdult,
                CreatureConstants.Dragon_White_Adult,
                CreatureConstants.Dragon_White_MatureAdult,
                CreatureConstants.Dragon_White_Old,
                CreatureConstants.Dragon_White_VeryOld,
                CreatureConstants.Dragon_White_Ancient,
                CreatureConstants.Dragon_White_Wyrm,
                CreatureConstants.Dragon_White_GreatWyrm,
                CreatureConstants.Dragonne,
                CreatureConstants.Drider,
                CreatureConstants.Dwarf,
                CreatureConstants.Eagle,
                CreatureConstants.Elephant,
                CreatureConstants.Elf,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.FrostWorm,
                CreatureConstants.Gargoyle,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Stone,
                CreatureConstants.GibberingMouther,
                CreatureConstants.Girallon,
                CreatureConstants.Gnoll,
                CreatureConstants.Goblin,
                CreatureConstants.Gorgon,
                CreatureConstants.GrayRender,
                CreatureConstants.GreenHag,
                CreatureConstants.Grick,
                CreatureConstants.Griffon,
                CreatureConstants.Grimlock,
                CreatureConstants.Gynosphinx,
                CreatureConstants.Halfling,
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
                CreatureConstants.Leopard,
                CreatureConstants.Lion,
                CreatureConstants.Lion_Dire,
                CreatureConstants.Lizard,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Manticore,
                CreatureConstants.Medusa,
                CreatureConstants.Megaraptor,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.Minotaur,
                CreatureConstants.Monkey,
                CreatureConstants.Mule,
                CreatureConstants.Naga_Dark,
                CreatureConstants.Naga_Spirit,
                CreatureConstants.Ogre,
                CreatureConstants.OgreMage,
                CreatureConstants.Orc,
                CreatureConstants.Otyugh,
                CreatureConstants.Owl,
                CreatureConstants.Owlbear,
                CreatureConstants.PhantomFungus,
                CreatureConstants.PhaseSpider,
                CreatureConstants.Phasm,
                CreatureConstants.Pony,
                CreatureConstants.Pony_War,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.PurpleWorm,
                CreatureConstants.Pyrohydra_5Heads,
                CreatureConstants.Pyrohydra_6Heads,
                CreatureConstants.Pyrohydra_7Heads,
                CreatureConstants.Pyrohydra_8Heads,
                CreatureConstants.Pyrohydra_9Heads,
                CreatureConstants.Pyrohydra_10Heads,
                CreatureConstants.Pyrohydra_11Heads,
                CreatureConstants.Pyrohydra_12Heads,
                CreatureConstants.Rat,
                CreatureConstants.Rat_Dire,
                CreatureConstants.Raven,
                CreatureConstants.RazorBoar,
                CreatureConstants.Remorhaz,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Roc,
                CreatureConstants.Roper,
                CreatureConstants.RustMonster,
                CreatureConstants.Satyr,
                CreatureConstants.Scorpion_Monstrous_Colossal,
                CreatureConstants.Scorpion_Monstrous_Gargantuan,
                CreatureConstants.Scorpion_Monstrous_Huge,
                CreatureConstants.Scorpion_Monstrous_Large,
                CreatureConstants.Scorpion_Monstrous_Medium,
                CreatureConstants.Scorpion_Monstrous_Small,
                CreatureConstants.Scorpion_Monstrous_Tiny,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.SeaHag,
                CreatureConstants.ShamblingMound,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Shrieker,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.Snake_Constrictor_Giant,
                CreatureConstants.Snake_Viper_Huge,
                CreatureConstants.Snake_Viper_Large,
                CreatureConstants.Snake_Viper_Small,
                CreatureConstants.Snake_Viper_Medium,
                CreatureConstants.Snake_Viper_Tiny,
                CreatureConstants.Spider_Monstrous_Colossal,
                CreatureConstants.Spider_Monstrous_Gargantuan,
                CreatureConstants.Spider_Monstrous_Huge,
                CreatureConstants.Spider_Monstrous_Large,
                CreatureConstants.Spider_Monstrous_Medium,
                CreatureConstants.Spider_Monstrous_Small,
                CreatureConstants.Spider_Monstrous_Tiny,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.SpiderEater,
                CreatureConstants.Stirge,
                CreatureConstants.Tendriculos,
                CreatureConstants.Tiger,
                CreatureConstants.Tiger_Dire,
                CreatureConstants.Toad,
                CreatureConstants.Triceratops,
                CreatureConstants.Troglodyte,
                CreatureConstants.Troll,
                CreatureConstants.Tyrannosaurus,
                CreatureConstants.UmberHulk,
                CreatureConstants.VioletFungus,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.Weasel,
                CreatureConstants.Weasel_Dire,
                CreatureConstants.WillOWisp,
                CreatureConstants.WinterWolf,
                CreatureConstants.Wolf,
                CreatureConstants.Wolf_Dire,
                CreatureConstants.Wolverine,
                CreatureConstants.Wolverine_Dire,
                CreatureConstants.Worg,
                CreatureConstants.Wyvern,
                CreatureConstants.Yrthak,
                CreatureConstants.YuanTi_Abomination,
                CreatureConstants.YuanTi_Halfblood,
                CreatureConstants.YuanTi_Pureblood
            };

            AssertEntriesAreComplete(names);
        }

        [TestCase(CreatureConstants.Ankheg, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Annis, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Ant_Giant_Worker, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ape, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ape_Dire, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Aranea, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.AssassinVine, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Athach, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Baboon, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Badger, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Badger_Dire, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Basilisk, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Bat, ChallengeRatingConstants.OneTenth)]
        [TestCase(CreatureConstants.Bat_Dire, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Bear_Black, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Bear_Brown, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Bear_Dire, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Bear_Polar, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Bee_Giant, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Behir, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Bison, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Boar, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Boar_Dire, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.BombardierBeetle_Giant, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bugbear, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bulette, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Camel, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Cat, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny, ChallengeRatingConstants.OneEighth)]
        [TestCase(CreatureConstants.Cheetah, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Chimera, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Choker, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Cloaker, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Cockatrice, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Criosphinx, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Crocodile, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Crocodile_Giant, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Cryohydra_5Heads, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Cryohydra_6Heads, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Cryohydra_7Heads, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Cryohydra_8Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Cryohydra_9Heads, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Cryohydra_10Heads, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Cryohydra_11Heads, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Cryohydra_12Heads, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Darkmantle, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Delver, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Derro, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Destrachan, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Digester, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Deinonychus, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dog, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Donkey, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Doppelganger, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Black_Young, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Black_Adult, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Dragon_Black_MatureAdult, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Dragon_Black_Old, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Black_Ancient, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrm, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Black_GreatWyrm, ChallengeRatingConstants.TwentyFour)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Blue_Young, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Dragon_Blue_Adult, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Dragon_Blue_MatureAdult, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_Blue_Old, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryOld, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Blue_Ancient, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrm, ChallengeRatingConstants.TwentyFive)]
        [TestCase(CreatureConstants.Dragon_Blue_GreatWyrm, ChallengeRatingConstants.TwentySeven)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_Green_Young, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Dragon_Green_Adult, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Dragon_Green_MatureAdult, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_Green_Old, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Green_VeryOld, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Green_Ancient, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrm, ChallengeRatingConstants.TwentyFour)]
        [TestCase(CreatureConstants.Dragon_Green_GreatWyrm, ChallengeRatingConstants.TwentySix)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Red_Young, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Dragon_Red_Adult, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Dragon_Red_MatureAdult, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Red_Old, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Red_VeryOld, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Red_Ancient, ChallengeRatingConstants.TwentyFive)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrm, ChallengeRatingConstants.TwentySix)]
        [TestCase(CreatureConstants.Dragon_Red_GreatWyrm, ChallengeRatingConstants.TwentyEight)]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_White_Young, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Dragon_White_Adult, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Dragon_White_MatureAdult, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Dragon_White_Old, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Dragon_White_VeryOld, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_White_Ancient, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_White_Wyrm, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_White_GreatWyrm, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragonne, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Drider, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dwarf, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Eagle, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Elephant, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Elf, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Ettercap, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Ettin, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.FireBeetle_Giant, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.FrostWorm, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Gargoyle, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Giant_Cloud, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Giant_Fire, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Giant_Frost, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Giant_Hill, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Giant_Stone, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.GibberingMouther, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Girallon, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Gnoll, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Goblin, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Gorgon, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.GrayRender, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.GreenHag, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Grick, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Griffon, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Grimlock, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Gynosphinx, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Halfling, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Harpy, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Hawk, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Hieracosphinx, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Hobgoblin, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Horse_Heavy, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Horse_Heavy_War, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Horse_Light, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Horse_Light_War, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Hippogriff, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Hydra_5Heads, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Hydra_6Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Hydra_7Heads, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Hydra_8Heads, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Hydra_9Heads, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Hydra_10Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Hydra_11Heads, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Hydra_12Heads, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Hyena, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Kobold, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Krenshar, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Lamia, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Leopard, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Lion, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Lion_Dire, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Lizard, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Lizard_Monitor, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Lizardfolk, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Manticore, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Medusa, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Megaraptor, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.MindFlayer, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Minotaur, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Mimic, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Monkey, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Mule, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Naga_Dark, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Naga_Spirit, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Ogre, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.OgreMage, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Orc, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Otyugh, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Owl, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Owlbear, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.PhantomFungus, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.PhaseSpider, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Phasm, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Pony, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Pony_War, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.PrayingMantis_Giant, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.PurpleWorm, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Pyrohydra_5Heads, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Pyrohydra_6Heads, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Pyrohydra_7Heads, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Pyrohydra_8Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Pyrohydra_9Heads, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Pyrohydra_10Heads, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Pyrohydra_11Heads, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Pyrohydra_12Heads, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Rat, ChallengeRatingConstants.OneEighth)]
        [TestCase(CreatureConstants.Rat_Dire, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Raven, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.RazorBoar, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Remorhaz, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Rhinoceras, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Roc, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Roper, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.RustMonster, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Satyr, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Scorpionfolk, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.SeaHag, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.ShamblingMound, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.ShockerLizard, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Shrieker, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Snake_Constrictor, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Snake_Viper_Huge, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Snake_Viper_Large, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Snake_Viper_Small, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Snake_Viper_Medium, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Spider_Monstrous_Gargantuan, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Spider_Monstrous_Large, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Spider_Monstrous_Small, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Spider_Monstrous_Tiny, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.StagBeetle_Giant, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.SpiderEater, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Stirge, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Tendriculos, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Tiger, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Tiger_Dire, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Toad, ChallengeRatingConstants.OneTenth)]
        [TestCase(CreatureConstants.Triceratops, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Troglodyte, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Troll, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Tyrannosaurus, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.UmberHulk, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.VioletFungus, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Wasp_Giant, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Weasel, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Weasel_Dire, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.WillOWisp, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.WinterWolf, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Wolf, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Wolf_Dire, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Wolverine, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Wolverine_Dire, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Worg, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Wyvern, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Yrthak, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.YuanTi_Abomination, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.YuanTi_Halfblood, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.YuanTi_Pureblood, ChallengeRatingConstants.Four)]
        public override void DistinctCollection(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }
    }
}
