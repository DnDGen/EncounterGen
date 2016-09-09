using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Treasures
{
    [TestFixture]
    public class TreasureAdjustmentsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.TreasureAdjustments;
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var entries = new[]
            {
                CreatureConstants.AasimarWarrior,
                CreatureConstants.Androsphinx,
                CreatureConstants.AssassinVine,
                CreatureConstants.Horse_Heavy,
                CreatureConstants.Horse_Heavy_War,
                CreatureConstants.Horse_Light,
                CreatureConstants.Horse_Light_War,
                CreatureConstants.Hippogriff,
                CreatureConstants.Succubus,
                CreatureConstants.Wolverine,
                CreatureConstants.Xill,
                CreatureConstants.Aboleth,
                CreatureConstants.Achaierai,
                CreatureConstants.Allip,
                CreatureConstants.Ankheg,
                CreatureConstants.AnimatedObject_Colossal,
                CreatureConstants.AnimatedObject_Gargantuan,
                CreatureConstants.AnimatedObject_Huge,
                CreatureConstants.AnimatedObject_Large,
                CreatureConstants.AnimatedObject_Medium,
                CreatureConstants.AnimatedObject_Small,
                CreatureConstants.AnimatedObject_Tiny,
                CreatureConstants.Annis,
                CreatureConstants.Ant_Giant_Soldier,
                CreatureConstants.Ant_Giant_Worker,
                CreatureConstants.Ant_Giant_Queen,
                CreatureConstants.Ape,
                CreatureConstants.Ape_Dire,
                CreatureConstants.Aranea,
                CreatureConstants.Arrowhawk_Adult,
                CreatureConstants.Arrowhawk_Elder,
                CreatureConstants.Arrowhawk_Juvenile,
                CreatureConstants.AstralDeva,
                CreatureConstants.Athach,
                CreatureConstants.Avoral,
                CreatureConstants.Azer,
                CreatureConstants.Babau,
                CreatureConstants.Baboon,
                CreatureConstants.Badger,
                CreatureConstants.Badger_Dire,
                CreatureConstants.Balor,
                CreatureConstants.BeardedDevil,
                CreatureConstants.Barghest,
                CreatureConstants.Barghest_Greater,
                CreatureConstants.Basilisk,
                CreatureConstants.Basilisk_AbyssalGreater,
                CreatureConstants.Bat,
                CreatureConstants.Bat_Dire,
                CreatureConstants.Bee_Giant,
                CreatureConstants.Bear_Black,
                CreatureConstants.Bear_Brown,
                CreatureConstants.Bear_Dire,
                CreatureConstants.Bear_Polar,
                CreatureConstants.Bebilith,
                CreatureConstants.Behir,
                CreatureConstants.Beholder,
                CreatureConstants.Belker,
                CreatureConstants.Bison,
                CreatureConstants.BlackPudding,
                CreatureConstants.BlackPudding_Elder,
                CreatureConstants.BlinkDog,
                CreatureConstants.Boar,
                CreatureConstants.Boar_Dire,
                CreatureConstants.Bodak,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Bralani,
                CreatureConstants.Bugbear,
                CreatureConstants.Bulette,
                CreatureConstants.Camel,
                CreatureConstants.CarrionCrawler,
                CreatureConstants.Cat,
                CreatureConstants.Centipede_Monstrous_Colossal,
                CreatureConstants.Centipede_Monstrous_Gargantuan,
                CreatureConstants.Centipede_Monstrous_Huge,
                CreatureConstants.Centipede_Monstrous_Large,
                CreatureConstants.Centipede_Monstrous_Medium,
                CreatureConstants.Centipede_Monstrous_Small,
                CreatureConstants.Centipede_Monstrous_Tiny,
                CreatureConstants.ChaosBeast,
                CreatureConstants.Centaur,
                CreatureConstants.Character,
                CreatureConstants.Cheetah,
                CreatureConstants.Chimera,
                CreatureConstants.Choker,
                CreatureConstants.Cloaker,
                CreatureConstants.Cockatrice,
                CharacterClassConstants.Commoner,
                CreatureConstants.HornedDevil,
                CreatureConstants.Couatl,
                CreatureConstants.Criosphinx,
                CreatureConstants.Crocodile,
                CreatureConstants.Crocodile_Giant,
                CreatureConstants.Cryohydra,
                CreatureConstants.Chuul,
                CreatureConstants.Darkmantle,
                CreatureConstants.Delver,
                CreatureConstants.Derro,
                CreatureConstants.Destrachan,
                CreatureConstants.Devourer,
                CreatureConstants.Digester,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Djinni,
                CreatureConstants.Djinni_Noble,
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
                CreatureConstants.DragonTurtle,
                CreatureConstants.Dragonne,
                CreatureConstants.Dretch,
                CreatureConstants.Drider,
                CreatureConstants.DrowWarrior,
                CreatureConstants.Dryad,
                CreatureConstants.DuergarWarrior,
                CreatureConstants.DwarfWarrior,
                CreatureConstants.Eagle_Giant,
                CreatureConstants.Eagle,
                CreatureConstants.Efreeti,
                CreatureConstants.Elemental_Air_Elder,
                CreatureConstants.Elemental_Air_Greater,
                CreatureConstants.Elemental_Air_Huge,
                CreatureConstants.Elemental_Air_Large,
                CreatureConstants.Elemental_Air_Medium,
                CreatureConstants.Elemental_Air_Small,
                CreatureConstants.Elemental_Earth_Elder,
                CreatureConstants.Elemental_Earth_Greater,
                CreatureConstants.Elemental_Earth_Huge,
                CreatureConstants.Elemental_Earth_Large,
                CreatureConstants.Elemental_Earth_Medium,
                CreatureConstants.Elemental_Earth_Small,
                CreatureConstants.Elemental_Fire_Elder,
                CreatureConstants.Elemental_Fire_Greater,
                CreatureConstants.Elemental_Fire_Huge,
                CreatureConstants.Elemental_Fire_Large,
                CreatureConstants.Elemental_Fire_Medium,
                CreatureConstants.Elemental_Fire_Small,
                CreatureConstants.Elemental_Water_Elder,
                CreatureConstants.Elemental_Water_Greater,
                CreatureConstants.Elemental_Water_Huge,
                CreatureConstants.Elemental_Water_Large,
                CreatureConstants.Elemental_Water_Medium,
                CreatureConstants.Elemental_Water_Small,
                CreatureConstants.Elephant,
                CreatureConstants.ElfWarrior,
                CreatureConstants.Erinyes,
                CreatureConstants.EtherealFilcher,
                CreatureConstants.EtherealMarauder,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.FormianWarrior,
                CreatureConstants.FormianWorker,
                CreatureConstants.FormianTaskmaster,
                CreatureConstants.FormianMyrmarch,
                CreatureConstants.FormianQueen,
                CreatureConstants.FrostWorm,
                CreatureConstants.Gargoyle,
                CreatureConstants.GelatinousCube,
                CreatureConstants.IceDevil,
                CreatureConstants.Ghaele,
                CreatureConstants.Ghast,
                CreatureConstants.Ghost,
                CreatureConstants.Ghoul,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Stone_Elder,
                CreatureConstants.Giant_Storm,
                CreatureConstants.GibberingMouther,
                CreatureConstants.Girallon,
                CreatureConstants.Glabrezu,
                CreatureConstants.Gnoll,
                CreatureConstants.GnomeWarrior,
                CreatureConstants.Goblin,
                CreatureConstants.Golem_Clay,
                CreatureConstants.Golem_Flesh,
                CreatureConstants.Golem_Iron,
                CreatureConstants.Golem_Stone,
                CreatureConstants.Golem_Stone_Greater,
                CreatureConstants.Gorgon,
                CreatureConstants.GrayRender,
                CreatureConstants.GreenHag,
                CreatureConstants.Grick,
                CreatureConstants.Griffon,
                CreatureConstants.Grig,
                CreatureConstants.Grimlock,
                CreatureConstants.Gynosphinx,
                CreatureConstants.HalflingWarrior,
                CreatureConstants.BarbedDevil,
                CreatureConstants.Harpy,
                CreatureConstants.Hawk,
                CreatureConstants.Hellcat,
                CreatureConstants.HellHound,
                CreatureConstants.NessianWarhound,
                CreatureConstants.Hezrou,
                CreatureConstants.Hieracosphinx,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Homunculus,
                CreatureConstants.HoundArchon,
                CreatureConstants.Howler,
                CreatureConstants.Hydra,
                CreatureConstants.Hyena,
                CreatureConstants.Imp,
                CreatureConstants.InvisibleStalker,
                CreatureConstants.Janni,
                CreatureConstants.Kobold,
                CreatureConstants.Kolyarut,
                CreatureConstants.Krenshar,
                CreatureConstants.ChainDevil,
                CreatureConstants.Lamia,
                CreatureConstants.Lammasu,
                CreatureConstants.LanternArchon,
                CreatureConstants.Lemure,
                CreatureConstants.Leonal,
                CreatureConstants.Leopard,
                CreatureConstants.Lich,
                CreatureConstants.Lillend,
                CreatureConstants.Lion,
                CreatureConstants.Lion_Dire,
                CreatureConstants.Livestock,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Lizard,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.Magmin,
                CreatureConstants.Manticore,
                CreatureConstants.Marilith,
                CreatureConstants.Marut,
                CreatureConstants.Medusa,
                CreatureConstants.Mephit,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.Minotaur,
                CreatureConstants.Mohrg,
                CreatureConstants.Monkey,
                CreatureConstants.Mule,
                CreatureConstants.Mummy,
                CreatureConstants.Naga_Dark,
                CreatureConstants.Naga_Guardian,
                CreatureConstants.Naga_Spirit,
                CreatureConstants.Naga_Water,
                CreatureConstants.Nalfeshnee,
                CreatureConstants.NightHag,
                CreatureConstants.Nightcrawler,
                CreatureConstants.Nightmare,
                CreatureConstants.Nightwalker,
                CreatureConstants.Nightwing,
                CreatureConstants.Nymph,
                CreatureConstants.Ogre,
                CreatureConstants.OgreMage,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.Orc,
                CreatureConstants.BoneDevil,
                CreatureConstants.Otyugh,
                CreatureConstants.Owl,
                CreatureConstants.Owlbear,
                CreatureConstants.Owl_Giant,
                CreatureConstants.Pegasus,
                CreatureConstants.PhantomFungus,
                CreatureConstants.PhaseSpider,
                CreatureConstants.Phasm,
                CreatureConstants.PitFiend,
                CreatureConstants.Pixie,
                CreatureConstants.Planetar,
                CreatureConstants.Pony,
                CreatureConstants.Pony_War,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Pseudodragon,
                CreatureConstants.PurpleWorm,
                CreatureConstants.Pyrohydra,
                CreatureConstants.Quasit,
                CreatureConstants.Rakshasa,
                CreatureConstants.Rast,
                CreatureConstants.Rat,
                CreatureConstants.Rat_Dire,
                CreatureConstants.Raven,
                CreatureConstants.Ravid,
                CreatureConstants.RazorBoar,
                CreatureConstants.Remorhaz,
                CreatureConstants.Retriever,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Roc,
                CreatureConstants.Roper,
                CreatureConstants.RustMonster,
                CreatureConstants.Salamander_Noble,
                CreatureConstants.Salamander_Average,
                CreatureConstants.Salamander_Flamebrother,
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
                CreatureConstants.Shadow,
                CreatureConstants.Shadow_Greater,
                CreatureConstants.ShadowMastiff,
                CreatureConstants.ShamblingMound,
                CreatureConstants.ShieldGuardian,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Shrieker,
                CreatureConstants.Skeleton,
                CreatureConstants.Slaad_Death,
                CreatureConstants.Slaad_Green,
                CreatureConstants.Slaad_Blue,
                CreatureConstants.Slaad_Gray,
                CreatureConstants.Slaad_Red,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.Snake_Constrictor_Giant,
                CreatureConstants.Snake_Viper_Huge,
                CreatureConstants.Snake_Viper_Large,
                CreatureConstants.Snake_Viper_Medium,
                CreatureConstants.Snake_Viper_Small,
                CreatureConstants.Snake_Viper_Tiny,
                CreatureConstants.Solar,
                CreatureConstants.Spectre,
                CreatureConstants.SpiderEater,
                CreatureConstants.Spider_Monstrous_Colossal,
                CreatureConstants.Spider_Monstrous_Gargantuan,
                CreatureConstants.Spider_Monstrous_Huge,
                CreatureConstants.Spider_Monstrous_Large,
                CreatureConstants.Spider_Monstrous_Medium,
                CreatureConstants.Spider_Monstrous_Small,
                CreatureConstants.Spider_Monstrous_Tiny,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.Stirge,
                CreatureConstants.SvirfneblinWarrior,
                CreatureConstants.Tarrasque,
                CreatureConstants.Tendriculos,
                CreatureConstants.Thoqqua,
                CreatureConstants.TieflingWarrior,
                CreatureConstants.Tiger,
                CreatureConstants.Tiger_Dire,
                CreatureConstants.Toad,
                CreatureConstants.Deinonychus,
                CreatureConstants.Megaraptor,
                CreatureConstants.Triceratops,
                CreatureConstants.Treant,
                CreatureConstants.Tyrannosaurus,
                CreatureConstants.Troglodyte,
                CreatureConstants.Troll,
                CreatureConstants.TrumpetArchon,
                CreatureConstants.UmberHulk,
                CreatureConstants.UmberHulk_TrulyHorrid,
                CreatureConstants.Unicorn,
                CreatureConstants.VampireSpawn,
                CreatureConstants.Vampire,
                CreatureConstants.Vargouille,
                CreatureConstants.VioletFungus,
                CreatureConstants.Vrock,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.Weasel,
                CreatureConstants.Weasel_Dire,
                CreatureConstants.Werebear,
                CreatureConstants.Wereboar,
                CreatureConstants.Wererat,
                CreatureConstants.Weretiger,
                CreatureConstants.Werewolf,
                CreatureConstants.Wight,
                CreatureConstants.WillOWisp,
                CreatureConstants.WinterWolf,
                CreatureConstants.Wolf,
                CreatureConstants.Wolf_Dire,
                CreatureConstants.Wolverine_Dire,
                CreatureConstants.Worg,
                CreatureConstants.Wraith,
                CreatureConstants.Wraith_Dread,
                CreatureConstants.Wyvern,
                CreatureConstants.Xorn_Average,
                CreatureConstants.Xorn_Elder,
                CreatureConstants.Xorn_Minor,
                CreatureConstants.YethHound,
                CreatureConstants.Yrthak,
                CreatureConstants.YuanTi_Abomination,
                CreatureConstants.YuanTi_Halfblood,
                CreatureConstants.YuanTi_Pureblood,
                CreatureConstants.Zelekhut,
                CreatureConstants.Zombie,
                CreatureConstants.NPC,
                CharacterClassConstants.Warrior,
                CharacterClassConstants.Adept,
                CharacterClassConstants.Aristocrat,
                CharacterClassConstants.Barbarian,
                CharacterClassConstants.Bard,
                CharacterClassConstants.Cleric,
                CharacterClassConstants.Druid,
                CharacterClassConstants.Expert,
                CharacterClassConstants.Fighter,
                CharacterClassConstants.Monk,
                CharacterClassConstants.Paladin,
                CharacterClassConstants.Ranger,
                CharacterClassConstants.Rogue,
                CharacterClassConstants.Sorcerer,
                CharacterClassConstants.Wizard,
            };

            AssertEntriesAreComplete(entries);
        }

        [TestCase(CreatureConstants.AasimarWarrior, 1, 1, 1)]
        [TestCase(CreatureConstants.Aboleth, 2, 2, 2)]
        [TestCase(CreatureConstants.Achaierai, 2, 2, 2)]
        [TestCase(CreatureConstants.Allip, 0, 0, 0)]
        [TestCase(CreatureConstants.Androsphinx, 1, 1, 1)]
        [TestCase(CreatureConstants.AnimatedObject_Colossal, 0, 0, 0)]
        [TestCase(CreatureConstants.AnimatedObject_Gargantuan, 0, 0, 0)]
        [TestCase(CreatureConstants.AnimatedObject_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.AnimatedObject_Large, 0, 0, 0)]
        [TestCase(CreatureConstants.AnimatedObject_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.AnimatedObject_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.AnimatedObject_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.Ankheg, 0, 0, 0)]
        [TestCase(CreatureConstants.Annis, 1, 1, 1)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier, 0, 0, 0)]
        [TestCase(CreatureConstants.Ant_Giant_Worker, 0, 0, 0)]
        [TestCase(CreatureConstants.Ant_Giant_Queen, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Ape, 0, 0, 0)]
        [TestCase(CreatureConstants.Ape_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Aranea, 1, 2, 1)]
        [TestCase(CreatureConstants.Arrowhawk_Adult, 0, 0, 0)]
        [TestCase(CreatureConstants.Arrowhawk_Elder, 0, 0, 0)]
        [TestCase(CreatureConstants.Arrowhawk_Juvenile, 0, 0, 0)]
        [TestCase(CreatureConstants.AssassinVine, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.AstralDeva, 0, 2, 1)]
        [TestCase(CreatureConstants.Athach, TreasureConstants.FiftyPercent, 2, 1)]
        [TestCase(CreatureConstants.Avoral, 0, 2, 1)]
        [TestCase(CreatureConstants.Azer, 1, 2, 1)]
        [TestCase(CreatureConstants.Babau, 1, 1, 1)]
        [TestCase(CreatureConstants.Baboon, 0, 0, 0)]
        [TestCase(CreatureConstants.Badger, 0, 0, 0)]
        [TestCase(CreatureConstants.Badger_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Balor, 1, 2, 1)]
        [TestCase(CreatureConstants.BeardedDevil, 1, 1, 1)]
        [TestCase(CreatureConstants.Barghest, 2, 2, 2)]
        [TestCase(CreatureConstants.Barghest_Greater, 2, 2, 2)]
        [TestCase(CreatureConstants.Basilisk, 0, 0, 0)]
        [TestCase(CreatureConstants.Basilisk_AbyssalGreater, 1, 1, 1)]
        [TestCase(CreatureConstants.Bat, 0, 0, 0)]
        [TestCase(CreatureConstants.Bat_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Bear_Black, 0, 0, 0)]
        [TestCase(CreatureConstants.Bear_Brown, 0, 0, 0)]
        [TestCase(CreatureConstants.Bear_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Bear_Polar, 0, 0, 0)]
        [TestCase(CreatureConstants.Bee_Giant, 0, TreasureConstants.TwentyFivePercent, 0)]
        [TestCase(CreatureConstants.Bebilith, 0, 0, 0)]
        [TestCase(CreatureConstants.Behir, 1, 1, 1)]
        [TestCase(CreatureConstants.Beholder, 2, 2, 2)]
        [TestCase(CreatureConstants.Belker, 0, 0, 0)]
        [TestCase(CreatureConstants.Bison, 0, 0, 0)]
        [TestCase(CreatureConstants.BlackPudding, 0, 0, 0)]
        [TestCase(CreatureConstants.BlackPudding_Elder, 0, 0, 0)]
        [TestCase(CreatureConstants.BlinkDog, 0, 0, 0)]
        [TestCase(CreatureConstants.Boar, 0, 0, 0)]
        [TestCase(CreatureConstants.Boar_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Bodak, 0, 0, 0)]
        [TestCase(CreatureConstants.BombardierBeetle_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Bralani, 0, 2, 1)]
        [TestCase(CreatureConstants.Bugbear, 1, 1, 1)]
        [TestCase(CreatureConstants.Bulette, 0, 0, 0)]
        [TestCase(CreatureConstants.Camel, 0, 0, 0)]
        [TestCase(CreatureConstants.CarrionCrawler, 0, 0, 0)]
        [TestCase(CreatureConstants.Cat, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.Centaur, 1, 1, 1)]
        [TestCase(CreatureConstants.ChaosBeast, 0, 0, 0)]
        [TestCase(CreatureConstants.Character, 0, 0, 0)]
        [TestCase(CreatureConstants.Cheetah, 0, 0, 0)]
        [TestCase(CreatureConstants.NPC, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Warrior, 0, 0, 0)]
        [TestCase(CreatureConstants.Chimera, 1, 1, 1)]
        [TestCase(CreatureConstants.Choker, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Chuul, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, 1)]
        [TestCase(CreatureConstants.Cloaker, 1, 1, 1)]
        [TestCase(CreatureConstants.Cockatrice, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Commoner, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Adept, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Expert, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Aristocrat, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Barbarian, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Bard, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Cleric, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Druid, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Fighter, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Monk, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Paladin, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Ranger, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Rogue, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Sorcerer, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Wizard, 0, 0, 0)]
        [TestCase(CreatureConstants.HornedDevil, 1, 2, 1)]
        [TestCase(CreatureConstants.Couatl, 1, 1, 1)]
        [TestCase(CreatureConstants.Criosphinx, 1, 1, 1)]
        [TestCase(CreatureConstants.Crocodile, 0, 0, 0)]
        [TestCase(CreatureConstants.Crocodile_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Cryohydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Darkmantle, 0, 0, 0)]
        [TestCase(CreatureConstants.Delver, 0, 0, 0)]
        [TestCase(CreatureConstants.Derro, 1, 2, 1)]
        [TestCase(CreatureConstants.Destrachan, 0, 0, 0)]
        [TestCase(CreatureConstants.Devourer, 0, 0, 0)]
        [TestCase(CreatureConstants.Digester, 0, 0, 0)]
        [TestCase(CreatureConstants.DisplacerBeast, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Djinni, 1, 1, 1)]
        [TestCase(CreatureConstants.Djinni_Noble, 1, 1, 1)]
        [TestCase(CreatureConstants.Dog, 0, 0, 0)]
        [TestCase(CreatureConstants.Donkey, 0, 0, 0)]
        [TestCase(CreatureConstants.Doppelganger, 2, 2, 2)]
        [TestCase(CreatureConstants.Dragon_Black_Adult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_Ancient, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_GreatWyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_MatureAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_Old, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_Young, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_Adult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_Ancient, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_GreatWyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_MatureAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_Old, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryOld, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_Young, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_Adult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_Ancient, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_GreatWyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_MatureAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_Old, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_VeryOld, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_Young, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_Adult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_Ancient, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_GreatWyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_MatureAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_Old, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_VeryOld, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_Young, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_Adult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_Ancient, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_GreatWyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_MatureAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_Old, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_VeryOld, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_Wyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_Young, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_GreatWyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_Old, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryOld, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_Young, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_GreatWyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_MatureAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_Old, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryOld, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_Young, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_Adult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_Ancient, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_GreatWyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_Old, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_Young, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_Adult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_Ancient, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_GreatWyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_Old, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryOld, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_Young, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_Adult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_Ancient, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_GreatWyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_Old, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_Young, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult, 3, 3, 3)]
        [TestCase(CreatureConstants.DragonTurtle, 3, 3, 3)]
        [TestCase(CreatureConstants.Dragonne, 2, 2, 2)]
        [TestCase(CreatureConstants.Dretch, 0, 0, 0)]
        [TestCase(CreatureConstants.Drider, 2, 2, 2)]
        [TestCase(CreatureConstants.DrowWarrior, 1, 1, 1)]
        [TestCase(CreatureConstants.Dryad, 1, 1, 1)]
        [TestCase(CreatureConstants.DuergarWarrior, 1, 2, 1)]
        [TestCase(CreatureConstants.DwarfWarrior, 1, 2, 1)]
        [TestCase(CreatureConstants.Eagle, 0, 0, 0)]
        [TestCase(CreatureConstants.Eagle_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Efreeti, 1, 2, 1)]
        [TestCase(CreatureConstants.Elemental_Air_Elder, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Air_Greater, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Air_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Air_Large, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Air_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Air_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Earth_Elder, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Earth_Greater, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Earth_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Earth_Large, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Earth_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Earth_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Fire_Elder, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Fire_Greater, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Fire_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Fire_Large, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Fire_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Fire_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Water_Elder, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Water_Greater, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Water_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Water_Large, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Water_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Elemental_Water_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Elephant, 0, 0, 0)]
        [TestCase(CreatureConstants.ElfWarrior, 1, 1, 1)]
        [TestCase(CreatureConstants.HalflingWarrior, 1, 1, 1)]
        [TestCase(CreatureConstants.GnomeWarrior, 1, 1, 1)]
        [TestCase(CreatureConstants.Erinyes, 1, 1, 1)]
        [TestCase(CreatureConstants.EtherealFilcher, 0, 1, 2)]
        [TestCase(CreatureConstants.EtherealMarauder, 0, 0, 0)]
        [TestCase(CreatureConstants.Ettercap, 1, 1, 1)]
        [TestCase(CreatureConstants.Ettin, 1, 1, 1)]
        [TestCase(CreatureConstants.FireBeetle_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.FormianWarrior, 0, 0, 0)]
        [TestCase(CreatureConstants.FormianWorker, 0, 0, 0)]
        [TestCase(CreatureConstants.FormianTaskmaster, 1, 1, 1)]
        [TestCase(CreatureConstants.FormianMyrmarch, 1, 1, 1)]
        [TestCase(CreatureConstants.FormianQueen, 2, 2, 2)]
        [TestCase(CreatureConstants.FrostWorm, 0, 0, 0)]
        [TestCase(CreatureConstants.Gargoyle, 1, 1, 1)]
        [TestCase(CreatureConstants.GelatinousCube, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.IceDevil, 1, 2, 1)]
        [TestCase(CreatureConstants.Ghaele, 0, 2, 1)]
        [TestCase(CreatureConstants.Ghast, 1, 1, 1)]
        [TestCase(CreatureConstants.Ghost, 0, 0, 0)]
        [TestCase(CreatureConstants.Ghoul, 0, 0, 0)]
        [TestCase(CreatureConstants.Giant_Cloud, 2, 1, 2)]
        [TestCase(CreatureConstants.Giant_Fire, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Frost, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Hill, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Stone, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Stone_Elder, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Storm, 2, 1, 2)]
        [TestCase(CreatureConstants.GibberingMouther, 0, 0, 0)]
        [TestCase(CreatureConstants.Girallon, 0, 0, 0)]
        [TestCase(CreatureConstants.Glabrezu, 1, 2, 1)]
        [TestCase(CreatureConstants.Gnoll, 1, 1, 1)]
        [TestCase(CreatureConstants.Goblin, 1, 1, 1)]
        [TestCase(CreatureConstants.Golem_Clay, 0, 0, 0)]
        [TestCase(CreatureConstants.Golem_Flesh, 0, 0, 0)]
        [TestCase(CreatureConstants.Golem_Iron, 0, 0, 0)]
        [TestCase(CreatureConstants.Golem_Stone, 0, 0, 0)]
        [TestCase(CreatureConstants.Golem_Stone_Greater, 0, 0, 0)]
        [TestCase(CreatureConstants.Gorgon, 0, 0, 0)]
        [TestCase(CreatureConstants.GrayRender, 0, 0, 0)]
        [TestCase(CreatureConstants.GreenHag, 1, 1, 1)]
        [TestCase(CreatureConstants.Grick, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Griffon, 0, 0, 0)]
        [TestCase(CreatureConstants.Grig, 0, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Grimlock, 1, 1, 1)]
        [TestCase(CreatureConstants.Gynosphinx, 2, 2, 2)]
        [TestCase(CreatureConstants.BarbedDevil, 1, 1, 1)]
        [TestCase(CreatureConstants.Hawk, 0, 0, 0)]
        [TestCase(CreatureConstants.Harpy, 1, 1, 1)]
        [TestCase(CreatureConstants.Hellcat, 0, 0, 0)]
        [TestCase(CreatureConstants.HellHound, 0, 0, 0)]
        [TestCase(CreatureConstants.NessianWarhound, 0, 0, 0)]
        [TestCase(CreatureConstants.Hezrou, 1, 1, 1)]
        [TestCase(CreatureConstants.Hieracosphinx, 0, 0, 0)]
        [TestCase(CreatureConstants.Hippogriff, 0, 0, 0)]
        [TestCase(CreatureConstants.Hobgoblin, 1, 1, 1)]
        [TestCase(CreatureConstants.Homunculus, 0, 0, 0)]
        [TestCase(CreatureConstants.Horse_Heavy, 0, 0, 0)]
        [TestCase(CreatureConstants.Horse_Heavy_War, 0, 0, 0)]
        [TestCase(CreatureConstants.Horse_Light, 0, 0, 0)]
        [TestCase(CreatureConstants.Horse_Light_War, 0, 0, 0)]
        [TestCase(CreatureConstants.HoundArchon, 0, 2, 1)]
        [TestCase(CreatureConstants.Howler, 0, 0, 0)]
        [TestCase(CreatureConstants.Hydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Hyena, 0, 0, 0)]
        [TestCase(CreatureConstants.Imp, 0, 0, 0)]
        [TestCase(CreatureConstants.InvisibleStalker, 0, 0, 0)]
        [TestCase(CreatureConstants.Kobold, 1, 1, 1)]
        [TestCase(CreatureConstants.Kolyarut, 0, 0, 0)]
        [TestCase(CreatureConstants.Krenshar, 0, 0, 0)]
        [TestCase(CreatureConstants.ChainDevil, 1, 1, 1)]
        [TestCase(CreatureConstants.Janni, 1, 1, 1)]
        [TestCase(CreatureConstants.Lamia, 1, 1, 1)]
        [TestCase(CreatureConstants.Lammasu, 1, 1, 1)]
        [TestCase(CreatureConstants.LanternArchon, 0, 0, 0)]
        [TestCase(CreatureConstants.Lemure, 0, 0, 0)]
        [TestCase(CreatureConstants.Leonal, 0, 2, 1)]
        [TestCase(CreatureConstants.Leopard, 0, 0, 0)]
        [TestCase(CreatureConstants.Lich, 1, 2, 2)]
        [TestCase(CreatureConstants.Livestock, 0, 0, 0)]
        [TestCase(CreatureConstants.Lillend, 1, 1, 1)]
        [TestCase(CreatureConstants.Lion, 0, 0, 0)]
        [TestCase(CreatureConstants.Lion_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Lizardfolk, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Lizard, 0, 0, 0)]
        [TestCase(CreatureConstants.Lizard_Monitor, 0, 0, 0)]
        [TestCase(CreatureConstants.Magmin, 1, 1, 1)]
        [TestCase(CreatureConstants.Manticore, 1, 1, 1)]
        [TestCase(CreatureConstants.Marilith, 2, 1, 2)]
        [TestCase(CreatureConstants.Marut, 0, 0, 0)]
        [TestCase(CreatureConstants.Medusa, 2, 2, 2)]
        [TestCase(CreatureConstants.Mephit, 1, 1, 1)]
        [TestCase(CreatureConstants.Mimic, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.MindFlayer, 2, 2, 2)]
        [TestCase(CreatureConstants.Minotaur, 1, 1, 1)]
        [TestCase(CreatureConstants.Mohrg, 0, 0, 0)]
        [TestCase(CreatureConstants.Monkey, 0, 0, 0)]
        [TestCase(CreatureConstants.Mule, 0, 0, 0)]
        [TestCase(CreatureConstants.Mummy, 1, 1, 1)]
        [TestCase(CreatureConstants.Naga_Dark, 1, 1, 1)]
        [TestCase(CreatureConstants.Naga_Guardian, 1, 1, 1)]
        [TestCase(CreatureConstants.Naga_Spirit, 1, 1, 1)]
        [TestCase(CreatureConstants.Naga_Water, 1, 1, 1)]
        [TestCase(CreatureConstants.Nalfeshnee, 2, 1, 2)]
        [TestCase(CreatureConstants.NightHag, 1, 1, 1)]
        [TestCase(CreatureConstants.Nightcrawler, 1, 1, 1)]
        [TestCase(CreatureConstants.Nightmare, 0, 0, 0)]
        [TestCase(CreatureConstants.Nightwalker, 1, 1, 1)]
        [TestCase(CreatureConstants.Nightwing, 1, 1, 1)]
        [TestCase(CreatureConstants.Nymph, 1, 1, 1)]
        [TestCase(CreatureConstants.Ogre, 1, 1, 1)]
        [TestCase(CreatureConstants.OgreMage, 2, 2, 2)]
        [TestCase(CreatureConstants.Ooze_Gray, 0, 0, 0)]
        [TestCase(CreatureConstants.Ooze_OchreJelly, 0, 0, 0)]
        [TestCase(CreatureConstants.Orc, 1, 1, 1)]
        [TestCase(CreatureConstants.BoneDevil, 1, 1, 1)]
        [TestCase(CreatureConstants.Otyugh, 1, 1, 1)]
        [TestCase(CreatureConstants.Owl, 0, 0, 0)]
        [TestCase(CreatureConstants.Owl_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Owlbear, 0, 0, 0)]
        [TestCase(CreatureConstants.Pegasus, 0, 0, 0)]
        [TestCase(CreatureConstants.PhantomFungus, 0, 0, 0)]
        [TestCase(CreatureConstants.PhaseSpider, 0, 0, 0)]
        [TestCase(CreatureConstants.Phasm, 1, 1, 1)]
        [TestCase(CreatureConstants.PitFiend, 2, 1, 2)]
        [TestCase(CreatureConstants.Pixie, 0, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Planetar, 0, 2, 1)]
        [TestCase(CreatureConstants.PrayingMantis_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Pseudodragon, 0, 0, 0)]
        [TestCase(CreatureConstants.PurpleWorm, 0, TreasureConstants.FiftyPercent, 0)]
        [TestCase(CreatureConstants.Pyrohydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Quasit, 0, 0, 0)]
        [TestCase(CreatureConstants.Rakshasa, 1, 2, 1)]
        [TestCase(CreatureConstants.Rast, 0, 0, 0)]
        [TestCase(CreatureConstants.Rat, 0, 0, 0)]
        [TestCase(CreatureConstants.Rat_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Ravid, 0, 0, 0)]
        [TestCase(CreatureConstants.RazorBoar, 0, 0, 0)]
        [TestCase(CreatureConstants.Remorhaz, 0, 0, 0)]
        [TestCase(CreatureConstants.Retriever, 0, 0, 0)]
        [TestCase(CreatureConstants.Rhinoceras, 0, 0, 0)]
        [TestCase(CreatureConstants.Roc, 0, 0, 0)]
        [TestCase(CreatureConstants.Roper, 0, TreasureConstants.FiftyPercent, 0)]
        [TestCase(CreatureConstants.RustMonster, 0, 0, 0)]
        [TestCase(CreatureConstants.Salamander_Noble, 2, 2, 2)]
        [TestCase(CreatureConstants.Salamander_Average, 1, 1, 1)]
        [TestCase(CreatureConstants.Salamander_Flamebrother, 1, 1, 1)]
        [TestCase(CreatureConstants.Satyr, 1, 1, 1)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.Scorpionfolk, 1, 1, 1)]
        [TestCase(CreatureConstants.SeaHag, 1, 1, 1)]
        [TestCase(CreatureConstants.Shadow, 0, 0, 0)]
        [TestCase(CreatureConstants.Shadow_Greater, 0, 0, 0)]
        [TestCase(CreatureConstants.ShadowMastiff, 0, 0, 0)]
        [TestCase(CreatureConstants.ShamblingMound, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.ShieldGuardian, 0, 0, 0)]
        [TestCase(CreatureConstants.ShockerLizard, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Shrieker, 0, 0, 0)]
        [TestCase(CreatureConstants.Skeleton, 0, 0, 0)]
        [TestCase(CreatureConstants.Slaad_Death, 2, 2, 2)]
        [TestCase(CreatureConstants.Slaad_Green, 1, 1, 1)]
        [TestCase(CreatureConstants.Slaad_Blue, 1, 1, 1)]
        [TestCase(CreatureConstants.Slaad_Gray, 2, 2, 2)]
        [TestCase(CreatureConstants.Slaad_Red, 1, 1, 1)]
        [TestCase(CreatureConstants.Snake_Constrictor, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Large, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.Solar, 0, 2, 1)]
        [TestCase(CreatureConstants.Spectre, 0, 0, 0)]
        [TestCase(CreatureConstants.SpiderEater, 0, 0, 0)]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Spider_Monstrous_Gargantuan, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Spider_Monstrous_Large, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Spider_Monstrous_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Spider_Monstrous_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.StagBeetle_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Stirge, 0, 0, 0)]
        [TestCase(CreatureConstants.Succubus, 1, 1, 1)]
        [TestCase(CreatureConstants.SvirfneblinWarrior, 1, 1, 1)]
        [TestCase(CreatureConstants.Tarrasque, 0, 0, 0)]
        [TestCase(CreatureConstants.Tendriculos, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Thoqqua, 0, 0, 0)]
        [TestCase(CreatureConstants.TieflingWarrior, 1, 1, 1)]
        [TestCase(CreatureConstants.Tiger, 0, 0, 0)]
        [TestCase(CreatureConstants.Tiger_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Deinonychus, 0, 0, 0)]
        [TestCase(CreatureConstants.Megaraptor, 0, 0, 0)]
        [TestCase(CreatureConstants.Treant, 1, 1, 1)]
        [TestCase(CreatureConstants.Triceratops, 0, 0, 0)]
        [TestCase(CreatureConstants.Tyrannosaurus, 0, 0, 0)]
        [TestCase(CreatureConstants.Troglodyte, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Troll, 1, 1, 1)]
        [TestCase(CreatureConstants.TrumpetArchon, 0, 2, 1)]
        [TestCase(CreatureConstants.UmberHulk, 1, 1, 1)]
        [TestCase(CreatureConstants.UmberHulk_TrulyHorrid, 1, 1, 1)]
        [TestCase(CreatureConstants.Unicorn, 0, 0, 0)]
        [TestCase(CreatureConstants.VampireSpawn, 1, 1, 1)]
        [TestCase(CreatureConstants.Vampire, 2, 2, 2)]
        [TestCase(CreatureConstants.Vargouille, 0, 0, 0)]
        [TestCase(CreatureConstants.VioletFungus, 0, 0, 0)]
        [TestCase(CreatureConstants.Vrock, 1, 1, 1)]
        [TestCase(CreatureConstants.Pony_War, 0, 0, 0)]
        [TestCase(CreatureConstants.Wasp_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Weasel, 0, 0, 0)]
        [TestCase(CreatureConstants.Weasel_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Werebear, 1, 1, 1)]
        [TestCase(CreatureConstants.Wereboar, 1, 1, 1)]
        [TestCase(CreatureConstants.Wererat, 1, 1, 1)]
        [TestCase(CreatureConstants.Weretiger, 1, 1, 1)]
        [TestCase(CreatureConstants.Werewolf, 1, 1, 1)]
        [TestCase(CreatureConstants.Wight, 0, 0, 0)]
        [TestCase(CreatureConstants.WillOWisp, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.WinterWolf, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Wolf, 0, 0, 0)]
        [TestCase(CreatureConstants.Wolf_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Wolverine, 0, 0, 0)]
        [TestCase(CreatureConstants.Wolverine_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Worg, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Wraith, 0, 0, 0)]
        [TestCase(CreatureConstants.Wraith_Dread, 0, 0, 0)]
        [TestCase(CreatureConstants.Wyvern, 1, 1, 1)]
        [TestCase(CreatureConstants.Xill, 1, 1, 1)]
        [TestCase(CreatureConstants.Xorn_Average, 0, 0, 0)]
        [TestCase(CreatureConstants.Xorn_Elder, 0, 0, 0)]
        [TestCase(CreatureConstants.Xorn_Minor, 0, 0, 0)]
        [TestCase(CreatureConstants.YethHound, 0, 0, 0)]
        [TestCase(CreatureConstants.Yrthak, 0, 0, 0)]
        [TestCase(CreatureConstants.YuanTi_Abomination, 2, 2, 2)]
        [TestCase(CreatureConstants.YuanTi_Halfblood, 2, 2, 2)]
        [TestCase(CreatureConstants.YuanTi_Pureblood, 2, 2, 2)]
        [TestCase(CreatureConstants.Zelekhut, 0, 0, 0)]
        [TestCase(CreatureConstants.Zombie, 0, 0, 0)]
        public void Adjustments(string entry, double coin, double goods, double items)
        {
            var collection = new[]
            {
                Convert.ToString(coin),
                Convert.ToString(goods),
                Convert.ToString(items)
            };

            base.OrderedCollection(entry, collection);
        }
    }
}
