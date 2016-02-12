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
        [TestCase(CreatureConstants.Doppelganger, "")]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling, "")]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung, "")]
        [TestCase(CreatureConstants.Dragon_Brass_Young, "")]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile, "")]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult, "")]
        [TestCase(CreatureConstants.Dragon_Brass_Adult, "")]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult, "")]
        [TestCase(CreatureConstants.Dragon_Brass_Old, "")]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld, "")]
        [TestCase(CreatureConstants.Dragon_Brass_Ancient, "")]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm, "")]
        [TestCase(CreatureConstants.Dragon_Brass_GreatWyrm, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_Young, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_Old, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryOld, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrm, "")]
        [TestCase(CreatureConstants.Dragon_Bronze_GreatWyrm, "")]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling, "")]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung, "")]
        [TestCase(CreatureConstants.Dragon_Copper_Young, "")]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile, "")]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult, "")]
        [TestCase(CreatureConstants.Dragon_Copper_Adult, "")]
        [TestCase(CreatureConstants.Dragon_Copper_MatureAdult, "")]
        [TestCase(CreatureConstants.Dragon_Copper_Old, "")]
        [TestCase(CreatureConstants.Dragon_Copper_VeryOld, "")]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient, "")]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrm, "")]
        [TestCase(CreatureConstants.Dragon_Copper_GreatWyrm, "")]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, "")]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung, "")]
        [TestCase(CreatureConstants.Dragon_Gold_Young, "")]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile, "")]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult, "")]
        [TestCase(CreatureConstants.Dragon_Gold_Adult, "")]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult, "")]
        [TestCase(CreatureConstants.Dragon_Gold_Old, "")]
        [TestCase(CreatureConstants.Dragon_Gold_VeryOld, "")]
        [TestCase(CreatureConstants.Dragon_Gold_Ancient, "")]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrm, "")]
        [TestCase(CreatureConstants.Dragon_Gold_GreatWyrm, "")]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, "")]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung, "")]
        [TestCase(CreatureConstants.Dragon_Silver_Young, "")]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile, "")]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult, "")]
        [TestCase(CreatureConstants.Dragon_Silver_Adult, "")]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult, "")]
        [TestCase(CreatureConstants.Dragon_Silver_Old, "")]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld, "")]
        [TestCase(CreatureConstants.Dragon_Silver_Ancient, "")]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrm, "")]
        [TestCase(CreatureConstants.Dragon_Silver_GreatWyrm, "")]
        [TestCase(CreatureConstants.Dragonne, "")]
        [TestCase(CreatureConstants.Dryad, "")]
        [TestCase(CreatureConstants.Dwarf, "")]
        [TestCase(CreatureConstants.Eagle, "")]
        [TestCase(CreatureConstants.Eagle_Giant, "")]
        [TestCase(CreatureConstants.Elephant, "")]
        [TestCase(CreatureConstants.Elf, "")]
        [TestCase(CreatureConstants.FireBeetle_Giant, "")]
        [TestCase(CreatureConstants.FrostWorm, "")]
        [TestCase(CreatureConstants.Giant_Cloud, "")]
        [TestCase(CreatureConstants.Giant_Stone, "")]
        [TestCase(CreatureConstants.Giant_Storm, "")]
        [TestCase(CreatureConstants.GibberingMouther, "")]
        [TestCase(CreatureConstants.Girallon, "")]
        [TestCase(CreatureConstants.Gnome, "")]
        [TestCase(CreatureConstants.Gorgon, "")]
        [TestCase(CreatureConstants.GrayRender, "")]
        [TestCase(CreatureConstants.Grick, "")]
        [TestCase(CreatureConstants.Griffon, "")]
        [TestCase(CreatureConstants.Grig, "")]
        [TestCase(CreatureConstants.Gynosphinx, "")]
        [TestCase(CreatureConstants.Halfling, "")]
        [TestCase(CreatureConstants.Hawk, "")]
        [TestCase(CreatureConstants.Horse_Heavy, "")]
        [TestCase(CreatureConstants.Horse_Heavy_War, "")]
        [TestCase(CreatureConstants.Horse_Light, "")]
        [TestCase(CreatureConstants.Horse_Light_War, "")]
        [TestCase(CreatureConstants.Hippogriff, "")]
        [TestCase(CreatureConstants.Hydra_5Heads, ChallengeRatingConstants.Five)]
        [TestCase(CreatureConstants.Hydra_6Heads, ChallengeRatingConstants.Six)]
        [TestCase(CreatureConstants.Hydra_7Heads, ChallengeRatingConstants.Seven)]
        [TestCase(CreatureConstants.Hydra_8Heads, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Hydra_9Heads, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Hydra_10Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Hydra_11Heads, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Hydra_12Heads, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Hyena, "")]
        [TestCase(CreatureConstants.Krenshar, "")]
        [TestCase(CreatureConstants.Lammasu, "")]
        [TestCase(CreatureConstants.Leopard, "")]
        [TestCase(CreatureConstants.Lion, "")]
        [TestCase(CreatureConstants.Lion_Dire, "")]
        [TestCase(CreatureConstants.Lizard, "")]
        [TestCase(CreatureConstants.Lizard_Monitor, "")]
        [TestCase(CreatureConstants.Lizardfolk, "")]
        [TestCase(CreatureConstants.Megaraptor, "")]
        [TestCase(CreatureConstants.Mimic, "")]
        [TestCase(CreatureConstants.Monkey, "")]
        [TestCase(CreatureConstants.Mule, "")]
        [TestCase(CreatureConstants.Naga_Guardian, "")]
        [TestCase(CreatureConstants.Nymph, "")]
        [TestCase(CreatureConstants.Otyugh, "")]
        [TestCase(CreatureConstants.Owl, "")]
        [TestCase(CreatureConstants.Owl_Giant, "")]
        [TestCase(CreatureConstants.Owlbear, "")]
        [TestCase(CreatureConstants.Pegasus, "")]
        [TestCase(CreatureConstants.PhantomFungus, "")]
        [TestCase(CreatureConstants.PhaseSpider, "")]
        [TestCase(CreatureConstants.Phasm, "")]
        [TestCase(CreatureConstants.Pixie, "")]
        [TestCase(CreatureConstants.Pony, "")]
        [TestCase(CreatureConstants.Pony_War, "")]
        [TestCase(CreatureConstants.PrayingMantis_Giant, "")]
        [TestCase(CreatureConstants.Pseudodragon, "")]
        [TestCase(CreatureConstants.PurpleWorm, "")]
        [TestCase(CreatureConstants.Pyrohydra_5Heads, ChallengeRatingConstants.Eight)]
        [TestCase(CreatureConstants.Pyrohydra_6Heads, ChallengeRatingConstants.Nine)]
        [TestCase(CreatureConstants.Pyrohydra_7Heads, ChallengeRatingConstants.Ten)]
        [TestCase(CreatureConstants.Pyrohydra_8Heads, ChallengeRatingConstants.Eleven)]
        [TestCase(CreatureConstants.Pyrohydra_9Heads, ChallengeRatingConstants.Twelve)]
        [TestCase(CreatureConstants.Pyrohydra_10Heads, ChallengeRatingConstants.Thirteen)]
        [TestCase(CreatureConstants.Pyrohydra_11Heads, ChallengeRatingConstants.Fourteen)]
        [TestCase(CreatureConstants.Pyrohydra_12Heads, ChallengeRatingConstants.Fifteen)]
        [TestCase(CreatureConstants.Rat, "")]
        [TestCase(CreatureConstants.Rat_Dire, "")]
        [TestCase(CreatureConstants.Raven, "")]
        [TestCase(CreatureConstants.RazorBoar, "")]
        [TestCase(CreatureConstants.Remorhaz, "")]
        [TestCase(CreatureConstants.Rhinoceras, "")]
        [TestCase(CreatureConstants.Roc, "")]
        [TestCase(CreatureConstants.RustMonster, "")]
        [TestCase(CreatureConstants.Satyr, "")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, "")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan, "")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge, "")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large, "")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium, "")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, "")]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny, "")]
        [TestCase(CreatureConstants.ShamblingMound, "")]
        [TestCase(CreatureConstants.ShockerLizard, "")]
        [TestCase(CreatureConstants.Shrieker, "")]
        [TestCase(CreatureConstants.Snake_Constrictor, "")]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant, "")]
        [TestCase(CreatureConstants.Snake_Viper_Huge, "")]
        [TestCase(CreatureConstants.Snake_Viper_Large, "")]
        [TestCase(CreatureConstants.Snake_Viper_Small, "")]
        [TestCase(CreatureConstants.Snake_Viper_Medium, "")]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, "")]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal, "")]
        [TestCase(CreatureConstants.Spider_Monstrous_Gargantuan, "")]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge, "")]
        [TestCase(CreatureConstants.Spider_Monstrous_Large, "")]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium, "")]
        [TestCase(CreatureConstants.Spider_Monstrous_Small, "")]
        [TestCase(CreatureConstants.Spider_Monstrous_Tiny, "")]
        [TestCase(CreatureConstants.StagBeetle_Giant, "")]
        [TestCase(CreatureConstants.SpiderEater, "")]
        [TestCase(CreatureConstants.Stirge, "")]
        [TestCase(CreatureConstants.Tendriculos, "")]
        [TestCase(CreatureConstants.Tiger, "")]
        [TestCase(CreatureConstants.Tiger_Dire, "")]
        [TestCase(CreatureConstants.Toad, "")]
        [TestCase(CreatureConstants.Treant, "")]
        [TestCase(CreatureConstants.Triceratops, "")]
        [TestCase(CreatureConstants.Tyrannosaurus, "")]
        [TestCase(CreatureConstants.Unicorn, "")]
        [TestCase(CreatureConstants.VioletFungus, "")]
        [TestCase(CreatureConstants.Wasp_Giant, "")]
        [TestCase(CreatureConstants.Weasel, "")]
        [TestCase(CreatureConstants.Weasel_Dire, "")]
        [TestCase(CreatureConstants.Wolf, "")]
        [TestCase(CreatureConstants.Wolf_Dire, "")]
        [TestCase(CreatureConstants.Wolverine, "")]
        [TestCase(CreatureConstants.Wolverine_Dire, "")]
        [TestCase(CreatureConstants.Wyvern, "")]
        [TestCase(CreatureConstants.Yrthak, "")]
        public override void DistinctCollection(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }
    }
}
