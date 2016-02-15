using EncounterGen.Common;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures
{
    [TestFixture]
    public class CelestialCreatureSubtypeChallengeRatingsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.CREATURESubtypeChallengeRatings, CreatureConstants.CelestialCreature);
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var names = new[]
            {
                CreatureConstants.Androsphinx,
                CreatureConstants.Ankheg,
                CreatureConstants.Ant_Giant_Soldier,
                CreatureConstants.Ant_Giant_Worker,
                CreatureConstants.Ape,
                CreatureConstants.Ape_Dire,
                CreatureConstants.Aranea,
                CreatureConstants.AssassinVine,
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
                CreatureConstants.BlinkDog,
                CreatureConstants.Boar,
                CreatureConstants.Boar_Dire,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Bulette,
                CreatureConstants.Camel,
                CreatureConstants.Cat,
                CreatureConstants.Centaur,
                CreatureConstants.Centipede_Monstrous_Colossal,
                CreatureConstants.Centipede_Monstrous_Gargantuan,
                CreatureConstants.Centipede_Monstrous_Huge,
                CreatureConstants.Centipede_Monstrous_Large,
                CreatureConstants.Centipede_Monstrous_Medium,
                CreatureConstants.Centipede_Monstrous_Small,
                CreatureConstants.Centipede_Monstrous_Tiny,
                CreatureConstants.Cheetah,
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
                CreatureConstants.Digester,
                CreatureConstants.Deinonychus,
                CreatureConstants.Dog,
                CreatureConstants.Donkey,
                CreatureConstants.Doppelganger,
                CreatureConstants.Dragon_Brass_Wyrmling,
                CreatureConstants.Dragon_Brass_VeryYoung,
                CreatureConstants.Dragon_Brass_Young,
                CreatureConstants.Dragon_Brass_Juvenile,
                CreatureConstants.Dragon_Brass_YoungAdult,
                CreatureConstants.Dragon_Brass_Adult,
                CreatureConstants.Dragon_Brass_MatureAdult,
                CreatureConstants.Dragon_Brass_Old,
                CreatureConstants.Dragon_Brass_VeryOld,
                CreatureConstants.Dragon_Brass_Ancient,
                CreatureConstants.Dragon_Brass_Wyrm,
                CreatureConstants.Dragon_Brass_GreatWyrm,
                CreatureConstants.Dragon_Bronze_Wyrmling,
                CreatureConstants.Dragon_Bronze_VeryYoung,
                CreatureConstants.Dragon_Bronze_Young,
                CreatureConstants.Dragon_Bronze_Juvenile,
                CreatureConstants.Dragon_Bronze_YoungAdult,
                CreatureConstants.Dragon_Bronze_Adult,
                CreatureConstants.Dragon_Bronze_MatureAdult,
                CreatureConstants.Dragon_Bronze_Old,
                CreatureConstants.Dragon_Bronze_VeryOld,
                CreatureConstants.Dragon_Bronze_Ancient,
                CreatureConstants.Dragon_Bronze_Wyrm,
                CreatureConstants.Dragon_Bronze_GreatWyrm,
                CreatureConstants.Dragon_Copper_Wyrmling,
                CreatureConstants.Dragon_Copper_VeryYoung,
                CreatureConstants.Dragon_Copper_Young,
                CreatureConstants.Dragon_Copper_Juvenile,
                CreatureConstants.Dragon_Copper_YoungAdult,
                CreatureConstants.Dragon_Copper_Adult,
                CreatureConstants.Dragon_Copper_MatureAdult,
                CreatureConstants.Dragon_Copper_Old,
                CreatureConstants.Dragon_Copper_VeryOld,
                CreatureConstants.Dragon_Copper_Ancient,
                CreatureConstants.Dragon_Copper_Wyrm,
                CreatureConstants.Dragon_Copper_GreatWyrm,
                CreatureConstants.Dragon_Gold_Wyrmling,
                CreatureConstants.Dragon_Gold_VeryYoung,
                CreatureConstants.Dragon_Gold_Young,
                CreatureConstants.Dragon_Gold_Juvenile,
                CreatureConstants.Dragon_Gold_YoungAdult,
                CreatureConstants.Dragon_Gold_Adult,
                CreatureConstants.Dragon_Gold_MatureAdult,
                CreatureConstants.Dragon_Gold_Old,
                CreatureConstants.Dragon_Gold_VeryOld,
                CreatureConstants.Dragon_Gold_Ancient,
                CreatureConstants.Dragon_Gold_Wyrm,
                CreatureConstants.Dragon_Gold_GreatWyrm,
                CreatureConstants.Dragon_Silver_Wyrmling,
                CreatureConstants.Dragon_Silver_VeryYoung,
                CreatureConstants.Dragon_Silver_Young,
                CreatureConstants.Dragon_Silver_Juvenile,
                CreatureConstants.Dragon_Silver_YoungAdult,
                CreatureConstants.Dragon_Silver_Adult,
                CreatureConstants.Dragon_Silver_MatureAdult,
                CreatureConstants.Dragon_Silver_Old,
                CreatureConstants.Dragon_Silver_VeryOld,
                CreatureConstants.Dragon_Silver_Ancient,
                CreatureConstants.Dragon_Silver_Wyrm,
                CreatureConstants.Dragon_Silver_GreatWyrm,
                CreatureConstants.Dragonne,
                CreatureConstants.Dryad,
                CreatureConstants.Dwarf,
                CreatureConstants.Eagle,
                CreatureConstants.Eagle_Giant,
                CreatureConstants.Elephant,
                CreatureConstants.Elf,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.FrostWorm,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Storm,
                CreatureConstants.GibberingMouther,
                CreatureConstants.Girallon,
                CreatureConstants.Gnome,
                CreatureConstants.Gorgon,
                CreatureConstants.GrayRender,
                CreatureConstants.Grick,
                CreatureConstants.Griffon,
                CreatureConstants.Grig,
                CreatureConstants.Gynosphinx,
                CreatureConstants.Halfling,
                CreatureConstants.Hawk,
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
                CreatureConstants.Krenshar,
                CreatureConstants.Lammasu,
                CreatureConstants.Leopard,
                CreatureConstants.Lion,
                CreatureConstants.Lion_Dire,
                CreatureConstants.Lizard,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Megaraptor,
                CreatureConstants.Mimic,
                CreatureConstants.Monkey,
                CreatureConstants.Mule,
                CreatureConstants.Naga_Guardian,
                CreatureConstants.Nymph,
                CreatureConstants.Otyugh,
                CreatureConstants.Owl,
                CreatureConstants.Owl_Giant,
                CreatureConstants.Owlbear,
                CreatureConstants.Pegasus,
                CreatureConstants.PhantomFungus,
                CreatureConstants.PhaseSpider,
                CreatureConstants.Phasm,
                CreatureConstants.Pixie,
                CreatureConstants.Pony,
                CreatureConstants.Pony_War,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Pseudodragon,
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
                CreatureConstants.RustMonster,
                CreatureConstants.Satyr,
                CreatureConstants.Scorpion_Monstrous_Colossal,
                CreatureConstants.Scorpion_Monstrous_Gargantuan,
                CreatureConstants.Scorpion_Monstrous_Huge,
                CreatureConstants.Scorpion_Monstrous_Large,
                CreatureConstants.Scorpion_Monstrous_Medium,
                CreatureConstants.Scorpion_Monstrous_Small,
                CreatureConstants.Scorpion_Monstrous_Tiny,
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
                CreatureConstants.Treant,
                CreatureConstants.Triceratops,
                CreatureConstants.Tyrannosaurus,
                CreatureConstants.Unicorn,
                CreatureConstants.VioletFungus,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.Weasel,
                CreatureConstants.Weasel_Dire,
                CreatureConstants.Wolf,
                CreatureConstants.Wolf_Dire,
                CreatureConstants.Wolverine,
                CreatureConstants.Wolverine_Dire,
                CreatureConstants.Wyvern,
                CreatureConstants.Yrthak
            };

            AssertEntriesAreComplete(names);
        }

        [TestCase(CreatureConstants.Androsphinx, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Ankheg, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Ant_Giant_Worker, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ape, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Ape_Dire, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Aranea, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.AssassinVine, ChallengeRatingConstants.Four)]
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
        [TestCase(CreatureConstants.BlinkDog, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Boar, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Boar_Dire, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.BombardierBeetle_Giant, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Bulette, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Camel, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Cat, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Centaur, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny, ChallengeRatingConstants.OneEighth)]
        [TestCase(CreatureConstants.Cheetah, ChallengeRatingConstants.Two)]
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
        [TestCase(CreatureConstants.Digester, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Deinonychus, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dog, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.Donkey, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Doppelganger, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Brass_Young, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Dragon_Brass_Adult, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Dragon_Brass_Old, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Brass_Ancient, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Brass_GreatWyrm, ChallengeRatingConstants.TwentyFive)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Bronze_Young, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult, ChallengeRatingConstants.Nineteen)]
        [TestCase(CreatureConstants.Dragon_Bronze_Old, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryOld, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient, ChallengeRatingConstants.TwentyFour)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrm, ChallengeRatingConstants.TwentyFive)]
        [TestCase(CreatureConstants.Dragon_Bronze_GreatWyrm, ChallengeRatingConstants.TwentySeven)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Copper_Young, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Dragon_Copper_MatureAdult, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_Copper_Old, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryOld, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient, ChallengeRatingConstants.TwentyFour)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrm, ChallengeRatingConstants.TwentyFive)]
        [TestCase(CreatureConstants.Dragon_Copper_GreatWyrm, ChallengeRatingConstants.TwentySeven)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragon_Gold_Young, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult, ChallengeRatingConstants.Sixteen)]
        [TestCase(CreatureConstants.Dragon_Gold_Adult, ChallengeRatingConstants.Eighteen)]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult, ChallengeRatingConstants.TwentyOne)]
        [TestCase(CreatureConstants.Dragon_Gold_Old, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryOld, ChallengeRatingConstants.TwentyFour)]
        [TestCase(CreatureConstants.Dragon_Gold_Ancient, ChallengeRatingConstants.TwentySix)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrm, ChallengeRatingConstants.TwentySeven)]
        [TestCase(CreatureConstants.Dragon_Gold_GreatWyrm, ChallengeRatingConstants.TwentyNine)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Dragon_Silver_Young, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Dragon_Silver_Adult, ChallengeRatingConstants.Seventeen)]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult, ChallengeRatingConstants.Twenty)]
        [TestCase(CreatureConstants.Dragon_Silver_Old, ChallengeRatingConstants.TwentyTwo)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld, ChallengeRatingConstants.TwentyThree)]
        [TestCase(CreatureConstants.Dragon_Silver_Ancient, ChallengeRatingConstants.TwentyFive)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrm, ChallengeRatingConstants.TwentySix)]
        [TestCase(CreatureConstants.Dragon_Silver_GreatWyrm, ChallengeRatingConstants.TwentyEight)]
        [TestCase(CreatureConstants.Dragonne, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Dryad, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Dwarf, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Eagle, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Eagle_Giant, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Elephant, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Elf, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.FireBeetle_Giant, ChallengeRatingConstants.OneThird)]
        [TestCase(CreatureConstants.FrostWorm, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Giant_Cloud, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Giant_Stone, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Giant_Storm, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.GibberingMouther, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Girallon, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Gnome, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Gorgon, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.GrayRender, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Grick, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Griffon, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Grig, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Gynosphinx, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Halfling, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Hawk, ChallengeRatingConstants.OneThird)]
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
        [TestCase(CreatureConstants.Krenshar, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Lammasu, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Leopard, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Lion, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Lion_Dire, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Lizard, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Lizard_Monitor, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Lizardfolk, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Megaraptor, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Mimic, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Monkey, ChallengeRatingConstants.OneSixth)]
        [TestCase(CreatureConstants.Mule, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Naga_Guardian, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Nymph, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Otyugh, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Owl, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Owl_Giant, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Owlbear, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Pegasus, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.PhantomFungus, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.PhaseSpider, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Phasm, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Pixie, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Pony, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Pony_War, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.PrayingMantis_Giant, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Pseudodragon, ChallengeRatingConstants.One)]
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
        [TestCase(CreatureConstants.RustMonster, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Satyr, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, ChallengeRatingConstants.OneHalf)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny, ChallengeRatingConstants.OneFourth)]
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
        [TestCase(CreatureConstants.Treant, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Triceratops, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Tyrannosaurus, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Unicorn, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.VioletFungus, ChallengeRatingConstants.Three)]
        [TestCase(CreatureConstants.Wasp_Giant, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Weasel, ChallengeRatingConstants.OneFourth)]
        [TestCase(CreatureConstants.Weasel_Dire, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Wolf, ChallengeRatingConstants.One)]
        [TestCase(CreatureConstants.Wolf_Dire, ChallengeRatingConstants.Four)]
        [TestCase(CreatureConstants.Wolverine, ChallengeRatingConstants.Two)]
        [TestCase(CreatureConstants.Wolverine_Dire, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Wyvern, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Yrthak, ChallengeRatingConstants.Eleven)]
        public override void DistinctCollection(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }
    }
}
