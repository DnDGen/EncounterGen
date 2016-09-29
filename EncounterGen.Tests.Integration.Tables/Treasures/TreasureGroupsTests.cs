using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System.Linq;
using TreasureGen.Items;
using TreasureGen.Items.Magical;

namespace EncounterGen.Tests.Integration.Tables.Treasures
{
    [TestFixture]
    public class TreasureGroupsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.TreasureGroups;
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var names = new[]
            {
                CreatureConstants.AasimarWarrior,
                CreatureConstants.Aboleth,
                CreatureConstants.Aboleth_Mage,
                CreatureConstants.Achaierai,
                CreatureConstants.Allip,
                CreatureConstants.Androsphinx,
                CreatureConstants.AnimatedObject_Colossal,
                CreatureConstants.AnimatedObject_Gargantuan,
                CreatureConstants.AnimatedObject_Huge,
                CreatureConstants.AnimatedObject_Large,
                CreatureConstants.AnimatedObject_Medium,
                CreatureConstants.AnimatedObject_Small,
                CreatureConstants.AnimatedObject_Tiny,
                CreatureConstants.Ankheg,
                CreatureConstants.Annis,
                CreatureConstants.SeaHag,
                CreatureConstants.Ant_Giant_Soldier,
                CreatureConstants.Ant_Giant_Worker,
                CreatureConstants.Ant_Giant_Queen,
                CreatureConstants.Ape,
                CreatureConstants.Ape_Dire,
                CreatureConstants.Aranea,
                CreatureConstants.Arrowhawk_Adult,
                CreatureConstants.Arrowhawk_Elder,
                CreatureConstants.Arrowhawk_Juvenile,
                CreatureConstants.AssassinVine,
                CreatureConstants.AstralDeva,
                CreatureConstants.Athach,
                CreatureConstants.Avoral,
                CreatureConstants.Azer,
                CreatureConstants.Babau,
                CreatureConstants.Baboon,
                CreatureConstants.Badger,
                CreatureConstants.Badger_Dire,
                CreatureConstants.Badger_Celestial,
                CreatureConstants.Balor,
                CreatureConstants.Barghest,
                CreatureConstants.Barghest_Greater,
                CreatureConstants.Basilisk,
                CreatureConstants.Basilisk_AbyssalGreater,
                CreatureConstants.Bat,
                CreatureConstants.Bat_Dire,
                CreatureConstants.Bat_Swarm,
                CreatureConstants.BeardedDevil,
                CreatureConstants.Bear_Black,
                CreatureConstants.Bear_Brown,
                CreatureConstants.Bear_Dire,
                CreatureConstants.Bear_Polar,
                CreatureConstants.Bebilith,
                CreatureConstants.Bee_Giant,
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
                CreatureConstants.Centaur,
                CreatureConstants.Centipede_Monstrous_Colossal,
                CreatureConstants.Centipede_Monstrous_Gargantuan,
                CreatureConstants.Centipede_Monstrous_Huge,
                CreatureConstants.Centipede_Monstrous_Large,
                CreatureConstants.Centipede_Monstrous_Medium,
                CreatureConstants.Centipede_Monstrous_Small,
                CreatureConstants.Centipede_Monstrous_Tiny,
                CreatureConstants.Centipede_Monstrous_Fiendish_Colossal,
                CreatureConstants.Centipede_Monstrous_Fiendish_Gargantuan,
                CreatureConstants.Centipede_Monstrous_Fiendish_Huge,
                CreatureConstants.Centipede_Monstrous_Fiendish_Large,
                CreatureConstants.Centipede_Monstrous_Fiendish_Medium,
                CreatureConstants.Centipede_Swarm,
                CreatureConstants.ChaosBeast,
                CreatureConstants.Character,
                CreatureConstants.Cheetah,
                CreatureConstants.Chimera,
                CreatureConstants.Choker,
                CreatureConstants.Chuul,
                CreatureConstants.Cloaker,
                CreatureConstants.HornedDevil,
                CreatureConstants.Cockatrice,
                CreatureConstants.Couatl,
                CreatureConstants.Criosphinx,
                CreatureConstants.Crocodile,
                CreatureConstants.Crocodile_Giant,
                CreatureConstants.Cryohydra,
                CreatureConstants.Darkmantle,
                CreatureConstants.Deinonychus,
                CreatureConstants.Delver,
                CreatureConstants.Derro,
                CreatureConstants.Destrachan,
                CreatureConstants.Devourer,
                CreatureConstants.Digester,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Djinni,
                CreatureConstants.Djinni_Noble,
                CreatureConstants.Dog,
                CreatureConstants.Dog_Celestial,
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
                CreatureConstants.Eagle,
                CreatureConstants.Eagle_Giant,
                CreatureConstants.Efreeti,
                CreatureConstants.Elephant,
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
                CreatureConstants.ElfWarrior,
                CreatureConstants.Erinyes,
                CreatureConstants.EtherealFilcher,
                CreatureConstants.EtherealMarauder,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.FireBeetle_Giant_Celestial,
                CreatureConstants.FormianQueen,
                CreatureConstants.FormianTaskmaster,
                CreatureConstants.FormianWarrior,
                CreatureConstants.FormianWorker,
                CreatureConstants.FormianMyrmarch,
                CreatureConstants.FrostWorm,
                CreatureConstants.IceDevil,
                CreatureConstants.Gargoyle,
                CreatureConstants.GelatinousCube,
                CreatureConstants.Ghaele,
                CreatureConstants.Ghast,
                CreatureConstants.Ghost,
                CreatureConstants.Ghoul,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Frost_Jarl,
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
                CreatureConstants.Grig,
                CreatureConstants.Griffon,
                CreatureConstants.Grimlock,
                CreatureConstants.Gynosphinx,
                CreatureConstants.BarbedDevil,
                CreatureConstants.HalflingWarrior,
                CreatureConstants.Harpy,
                CreatureConstants.HarpyArcher,
                CreatureConstants.Hawk,
                CreatureConstants.HellHound,
                CreatureConstants.Hellcat,
                CreatureConstants.Hellwasp_Swarm,
                CreatureConstants.Hezrou,
                CreatureConstants.Hieracosphinx,
                CreatureConstants.Hippogriff,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Homunculus,
                CreatureConstants.Horse_Heavy,
                CreatureConstants.Horse_Heavy_War,
                CreatureConstants.Horse_Light,
                CreatureConstants.Horse_Light_War,
                CreatureConstants.HoundArchon,
                CreatureConstants.HoundArchon_Hero,
                CreatureConstants.Howler,
                CreatureConstants.Hydra,
                CreatureConstants.Hyena,
                CreatureConstants.Imp,
                CreatureConstants.InvisibleStalker,
                CreatureConstants.Janni,
                CreatureConstants.ChainDevil,
                CreatureConstants.Kobold,
                CreatureConstants.Kolyarut,
                CreatureConstants.Krenshar,
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
                CreatureConstants.Livestock_Noncombatant,
                CreatureConstants.Lizard,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.Locust_Swarm,
                CreatureConstants.Magmin,
                CreatureConstants.Manticore,
                CreatureConstants.Marilith,
                CreatureConstants.Marut,
                CreatureConstants.Medusa,
                CreatureConstants.Megaraptor,
                CreatureConstants.Mephit,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.MindFlayer_Sorcerer,
                CreatureConstants.Minotaur,
                CreatureConstants.Mohrg,
                CreatureConstants.Monkey,
                CreatureConstants.Monkey_Celestial,
                CreatureConstants.Mule,
                CreatureConstants.Mummy,
                CreatureConstants.MummyLord,
                CreatureConstants.Naga_Dark,
                CreatureConstants.Naga_Guardian,
                CreatureConstants.Naga_Spirit,
                CreatureConstants.Naga_Water,
                CreatureConstants.Nalfeshnee,
                CreatureConstants.NessianWarhound,
                CreatureConstants.NightHag,
                CreatureConstants.Nightcrawler,
                CreatureConstants.Nightmare,
                CreatureConstants.Nightwalker,
                CreatureConstants.Nightwing,
                CreatureConstants.Nixie,
                CreatureConstants.NPC,
                CreatureConstants.Nymph,
                CreatureConstants.Ogre,
                CreatureConstants.Ogre_Barbarian,
                CreatureConstants.OgreMage,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.Orc,
                CreatureConstants.Otyugh,
                CreatureConstants.BoneDevil,
                CreatureConstants.Owl,
                CreatureConstants.Owl_Giant,
                CreatureConstants.Owl_Celestial,
                CreatureConstants.Owlbear,
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
                CreatureConstants.Rat_Dire_Fiendish,
                CreatureConstants.Rat_Swarm,
                CreatureConstants.Raven,
                CreatureConstants.Raven_Fiendish,
                CreatureConstants.Ravid,
                CreatureConstants.RazorBoar,
                CreatureConstants.Remorhaz,
                CreatureConstants.Retriever,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Roc,
                CreatureConstants.Roper,
                CreatureConstants.RustMonster,
                CreatureConstants.Salamander_Average,
                CreatureConstants.Salamander_Flamebrother,
                CreatureConstants.Salamander_Noble,
                CreatureConstants.Satyr,
                CreatureConstants.Scorpion_Monstrous_Colossal,
                CreatureConstants.Scorpion_Monstrous_Gargantuan,
                CreatureConstants.Scorpion_Monstrous_Huge,
                CreatureConstants.Scorpion_Monstrous_Large,
                CreatureConstants.Scorpion_Monstrous_Medium,
                CreatureConstants.Scorpion_Monstrous_Small,
                CreatureConstants.Scorpion_Monstrous_Tiny,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.Shadow,
                CreatureConstants.Shadow_Greater,
                CreatureConstants.ShadowMastiff,
                CreatureConstants.ShamblingMound,
                CreatureConstants.ShieldGuardian,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Shrieker,
                CreatureConstants.Skeleton,
                CreatureConstants.Skum,
                CreatureConstants.Slaad_Blue,
                CreatureConstants.Slaad_Death,
                CreatureConstants.Slaad_Gray,
                CreatureConstants.Slaad_Green,
                CreatureConstants.Slaad_Red,
                CreatureConstants.Solar,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.Snake_Constrictor_Giant,
                CreatureConstants.Snake_Viper_Huge,
                CreatureConstants.Snake_Viper_Large,
                CreatureConstants.Snake_Viper_Medium,
                CreatureConstants.Snake_Viper_Small,
                CreatureConstants.Snake_Viper_Tiny,
                CreatureConstants.Spectre,
                CreatureConstants.Spider_Monstrous_Colossal,
                CreatureConstants.Spider_Monstrous_Gargantuan,
                CreatureConstants.Spider_Monstrous_Huge,
                CreatureConstants.Spider_Monstrous_Large,
                CreatureConstants.Spider_Monstrous_Medium,
                CreatureConstants.Spider_Monstrous_Small,
                CreatureConstants.Spider_Monstrous_Tiny,
                CreatureConstants.Spider_Swarm,
                CreatureConstants.SpiderEater,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.Stirge,
                CreatureConstants.Succubus,
                CreatureConstants.SvirfneblinWarrior,
                CreatureConstants.Tarrasque,
                CreatureConstants.Tendriculos,
                CreatureConstants.Thoqqua,
                CreatureConstants.TieflingWarrior,
                CreatureConstants.Tiger,
                CreatureConstants.Tiger_Dire,
                CreatureConstants.Titan,
                CreatureConstants.Toad,
                CreatureConstants.Treant,
                CreatureConstants.Triceratops,
                CreatureConstants.Troglodyte,
                CreatureConstants.Troll,
                CreatureConstants.Troll_Hunter,
                CreatureConstants.TrumpetArchon,
                CreatureConstants.Tyrannosaurus,
                CreatureConstants.UmberHulk,
                CreatureConstants.UmberHulk_TrulyHorrid,
                CreatureConstants.Unicorn,
                CreatureConstants.Vampire,
                CreatureConstants.VampireSpawn,
                CreatureConstants.Vargouille,
                CreatureConstants.VioletFungus,
                CreatureConstants.Vrock,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.Weasel,
                CreatureConstants.Weasel_Dire,
                CreatureConstants.Werebear,
                CreatureConstants.Wereboar,
                CreatureConstants.Wereboar_HillGiantDire,
                CreatureConstants.Wererat,
                CreatureConstants.Weretiger,
                CreatureConstants.Werewolf,
                CreatureConstants.WerewolfLord,
                CreatureConstants.Wight,
                CreatureConstants.WillOWisp,
                CreatureConstants.WinterWolf,
                CreatureConstants.Wolf,
                CreatureConstants.Wolf_Dire,
                CreatureConstants.Wolverine,
                CreatureConstants.Wolverine_Dire,
                CreatureConstants.Worg,
                CreatureConstants.Wraith,
                CreatureConstants.Wraith_Dread,
                CreatureConstants.Wyvern,
                CreatureConstants.Xill,
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
                CharacterClassConstants.Commoner,
                CharacterClassConstants.Warrior,
                CharacterClassConstants.Expert,
                CharacterClassConstants.Adept,
                CharacterClassConstants.Aristocrat,
                CharacterClassConstants.Barbarian,
                CharacterClassConstants.Bard,
                CharacterClassConstants.Cleric,
                CharacterClassConstants.Druid,
                CharacterClassConstants.Fighter,
                CharacterClassConstants.Monk,
                CharacterClassConstants.Paladin,
                CharacterClassConstants.Ranger,
                CharacterClassConstants.Rogue,
                CharacterClassConstants.Sorcerer,
                CharacterClassConstants.Wizard,
            };

            AssertEntriesAreComplete(names);
        }

        [TestCase(CreatureConstants.Aboleth)]
        [TestCase(CreatureConstants.Aboleth_Mage)]
        [TestCase(CreatureConstants.Achaierai)]
        [TestCase(CreatureConstants.Allip)]
        [TestCase(CreatureConstants.Androsphinx)]
        [TestCase(CreatureConstants.AnimatedObject_Colossal)]
        [TestCase(CreatureConstants.AnimatedObject_Gargantuan)]
        [TestCase(CreatureConstants.AnimatedObject_Huge)]
        [TestCase(CreatureConstants.AnimatedObject_Large)]
        [TestCase(CreatureConstants.AnimatedObject_Medium)]
        [TestCase(CreatureConstants.AnimatedObject_Small)]
        [TestCase(CreatureConstants.AnimatedObject_Tiny)]
        [TestCase(CreatureConstants.Ankheg)]
        [TestCase(CreatureConstants.Annis)]
        [TestCase(CreatureConstants.SeaHag)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier)]
        [TestCase(CreatureConstants.Ant_Giant_Worker)]
        [TestCase(CreatureConstants.Ant_Giant_Queen)]
        [TestCase(CreatureConstants.Ape)]
        [TestCase(CreatureConstants.Ape_Dire)]
        [TestCase(CreatureConstants.Aranea)]
        [TestCase(CreatureConstants.Arrowhawk_Adult)]
        [TestCase(CreatureConstants.Arrowhawk_Elder)]
        [TestCase(CreatureConstants.Arrowhawk_Juvenile)]
        [TestCase(CreatureConstants.AssassinVine)]
        [TestCase(CreatureConstants.Avoral)]
        [TestCase(CreatureConstants.Babau)]
        [TestCase(CreatureConstants.Baboon)]
        [TestCase(CreatureConstants.Badger)]
        [TestCase(CreatureConstants.Badger_Dire)]
        [TestCase(CreatureConstants.Badger_Celestial)]
        [TestCase(CreatureConstants.Barghest)]
        [TestCase(CreatureConstants.Barghest_Greater)]
        [TestCase(CreatureConstants.Basilisk)]
        [TestCase(CreatureConstants.Basilisk_AbyssalGreater)]
        [TestCase(CreatureConstants.Bat)]
        [TestCase(CreatureConstants.Bat_Dire)]
        [TestCase(CreatureConstants.Bat_Swarm)]
        [TestCase(CreatureConstants.Bear_Black)]
        [TestCase(CreatureConstants.Bear_Brown)]
        [TestCase(CreatureConstants.Bear_Dire)]
        [TestCase(CreatureConstants.Bear_Polar)]
        [TestCase(CreatureConstants.Bebilith)]
        [TestCase(CreatureConstants.Bee_Giant)]
        [TestCase(CreatureConstants.Behir)]
        [TestCase(CreatureConstants.Beholder)]
        [TestCase(CreatureConstants.Belker)]
        [TestCase(CreatureConstants.Bison)]
        [TestCase(CreatureConstants.BlackPudding)]
        [TestCase(CreatureConstants.BlackPudding_Elder)]
        [TestCase(CreatureConstants.BlinkDog)]
        [TestCase(CreatureConstants.Boar)]
        [TestCase(CreatureConstants.Boar_Dire)]
        [TestCase(CreatureConstants.Bodak)]
        [TestCase(CreatureConstants.BombardierBeetle_Giant)]
        [TestCase(CreatureConstants.Bulette)]
        [TestCase(CreatureConstants.Camel)]
        [TestCase(CreatureConstants.CarrionCrawler)]
        [TestCase(CreatureConstants.Cat)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Colossal)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Gargantuan)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Huge)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Large)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Fiendish_Medium)]
        [TestCase(CreatureConstants.Centipede_Swarm)]
        [TestCase(CreatureConstants.ChaosBeast)]
        [TestCase(CreatureConstants.Character)]
        [TestCase(CreatureConstants.Cheetah)]
        [TestCase(CreatureConstants.Chimera)]
        [TestCase(CreatureConstants.Choker)]
        [TestCase(CreatureConstants.Chuul)]
        [TestCase(CreatureConstants.Cloaker)]
        [TestCase(CreatureConstants.Cockatrice)]
        [TestCase(CreatureConstants.Couatl)]
        [TestCase(CreatureConstants.Criosphinx)]
        [TestCase(CreatureConstants.Crocodile)]
        [TestCase(CreatureConstants.Crocodile_Giant)]
        [TestCase(CreatureConstants.Cryohydra)]
        [TestCase(CreatureConstants.Darkmantle)]
        [TestCase(CreatureConstants.Deinonychus)]
        [TestCase(CreatureConstants.Delver)]
        [TestCase(CreatureConstants.Destrachan)]
        [TestCase(CreatureConstants.Devourer)]
        [TestCase(CreatureConstants.Digester)]
        [TestCase(CreatureConstants.DisplacerBeast)]
        [TestCase(CreatureConstants.Djinni)]
        [TestCase(CreatureConstants.Djinni_Noble)]
        [TestCase(CreatureConstants.Dog)]
        [TestCase(CreatureConstants.Dog_Celestial)]
        [TestCase(CreatureConstants.Donkey)]
        [TestCase(CreatureConstants.Doppelganger)]
        [TestCase(CreatureConstants.Dragon_Black_Adult)]
        [TestCase(CreatureConstants.Dragon_Black_Ancient)]
        [TestCase(CreatureConstants.Dragon_Black_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Black_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Black_Old)]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Black_Young)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Blue_Adult)]
        [TestCase(CreatureConstants.Dragon_Blue_Ancient)]
        [TestCase(CreatureConstants.Dragon_Blue_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Blue_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Blue_Old)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Blue_Young)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Green_Adult)]
        [TestCase(CreatureConstants.Dragon_Green_Ancient)]
        [TestCase(CreatureConstants.Dragon_Green_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Green_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Green_Old)]
        [TestCase(CreatureConstants.Dragon_Green_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Green_Young)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Red_Adult)]
        [TestCase(CreatureConstants.Dragon_Red_Ancient)]
        [TestCase(CreatureConstants.Dragon_Red_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Red_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Red_Old)]
        [TestCase(CreatureConstants.Dragon_Red_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Red_Young)]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_White_Adult)]
        [TestCase(CreatureConstants.Dragon_White_Ancient)]
        [TestCase(CreatureConstants.Dragon_White_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile)]
        [TestCase(CreatureConstants.Dragon_White_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_White_Old)]
        [TestCase(CreatureConstants.Dragon_White_VeryOld)]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_White_Wyrm)]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_White_Young)]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult)]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient)]
        [TestCase(CreatureConstants.Dragon_Bronze_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Bronze_Old)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Bronze_Young)]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult)]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient)]
        [TestCase(CreatureConstants.Dragon_Copper_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Copper_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Copper_Old)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Copper_Young)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Silver_Adult)]
        [TestCase(CreatureConstants.Dragon_Silver_Ancient)]
        [TestCase(CreatureConstants.Dragon_Silver_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Silver_Old)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Silver_Young)]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Gold_Adult)]
        [TestCase(CreatureConstants.Dragon_Gold_Ancient)]
        [TestCase(CreatureConstants.Dragon_Gold_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Gold_Old)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Gold_Young)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult)]
        [TestCase(CreatureConstants.Dragon_Brass_Adult)]
        [TestCase(CreatureConstants.Dragon_Brass_Ancient)]
        [TestCase(CreatureConstants.Dragon_Brass_GreatWyrm)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile)]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult)]
        [TestCase(CreatureConstants.Dragon_Brass_Old)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling)]
        [TestCase(CreatureConstants.Dragon_Brass_Young)]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult)]
        [TestCase(CreatureConstants.DragonTurtle)]
        [TestCase(CreatureConstants.Dragonne)]
        [TestCase(CreatureConstants.Dretch)]
        [TestCase(CreatureConstants.Eagle)]
        [TestCase(CreatureConstants.Eagle_Giant)]
        [TestCase(CreatureConstants.Efreeti)]
        [TestCase(CreatureConstants.Elephant)]
        [TestCase(CreatureConstants.Elemental_Air_Elder)]
        [TestCase(CreatureConstants.Elemental_Air_Greater)]
        [TestCase(CreatureConstants.Elemental_Air_Huge)]
        [TestCase(CreatureConstants.Elemental_Air_Large)]
        [TestCase(CreatureConstants.Elemental_Air_Medium)]
        [TestCase(CreatureConstants.Elemental_Air_Small)]
        [TestCase(CreatureConstants.Elemental_Earth_Elder)]
        [TestCase(CreatureConstants.Elemental_Earth_Greater)]
        [TestCase(CreatureConstants.Elemental_Earth_Huge)]
        [TestCase(CreatureConstants.Elemental_Earth_Large)]
        [TestCase(CreatureConstants.Elemental_Earth_Medium)]
        [TestCase(CreatureConstants.Elemental_Earth_Small)]
        [TestCase(CreatureConstants.Elemental_Fire_Elder)]
        [TestCase(CreatureConstants.Elemental_Fire_Greater)]
        [TestCase(CreatureConstants.Elemental_Fire_Huge)]
        [TestCase(CreatureConstants.Elemental_Fire_Large)]
        [TestCase(CreatureConstants.Elemental_Fire_Medium)]
        [TestCase(CreatureConstants.Elemental_Fire_Small)]
        [TestCase(CreatureConstants.Elemental_Water_Elder)]
        [TestCase(CreatureConstants.Elemental_Water_Greater)]
        [TestCase(CreatureConstants.Elemental_Water_Huge)]
        [TestCase(CreatureConstants.Elemental_Water_Large)]
        [TestCase(CreatureConstants.Elemental_Water_Medium)]
        [TestCase(CreatureConstants.Elemental_Water_Small)]
        [TestCase(CreatureConstants.EtherealFilcher)]
        [TestCase(CreatureConstants.EtherealMarauder)]
        [TestCase(CreatureConstants.Ettercap)]
        [TestCase(CreatureConstants.FireBeetle_Giant)]
        [TestCase(CreatureConstants.FireBeetle_Giant_Celestial)]
        [TestCase(CreatureConstants.FormianQueen)]
        [TestCase(CreatureConstants.FormianTaskmaster)]
        [TestCase(CreatureConstants.FormianWarrior)]
        [TestCase(CreatureConstants.FormianWorker)]
        [TestCase(CreatureConstants.FrostWorm)]
        [TestCase(CreatureConstants.Gargoyle)]
        [TestCase(CreatureConstants.GelatinousCube)]//Stone and metal only
        [TestCase(CreatureConstants.Ghast)]
        [TestCase(CreatureConstants.Ghost)]
        [TestCase(CreatureConstants.Ghoul)]
        [TestCase(CreatureConstants.GibberingMouther)]
        [TestCase(CreatureConstants.Girallon)]
        [TestCase(CreatureConstants.Glabrezu)]
        [TestCase(CreatureConstants.Golem_Clay)]
        [TestCase(CreatureConstants.Golem_Flesh)]
        [TestCase(CreatureConstants.Golem_Iron)]
        [TestCase(CreatureConstants.Golem_Stone)]
        [TestCase(CreatureConstants.Golem_Stone_Greater)]
        [TestCase(CreatureConstants.Gorgon)]
        [TestCase(CreatureConstants.GrayRender)]
        [TestCase(CreatureConstants.GreenHag)]
        [TestCase(CreatureConstants.Grick)]
        [TestCase(CreatureConstants.Griffon)]
        [TestCase(CreatureConstants.Gynosphinx)]
        [TestCase(CreatureConstants.BarbedDevil)]
        [TestCase(CreatureConstants.Hawk)]
        [TestCase(CreatureConstants.Hellcat)]
        [TestCase(CreatureConstants.HellHound)]
        [TestCase(CreatureConstants.Hellwasp_Swarm)]
        [TestCase(CreatureConstants.Hezrou)]
        [TestCase(CreatureConstants.Hieracosphinx)]
        [TestCase(CreatureConstants.Hippogriff)]
        [TestCase(CreatureConstants.Homunculus)]
        [TestCase(CreatureConstants.Horse_Heavy)]
        [TestCase(CreatureConstants.Horse_Heavy_War)]
        [TestCase(CreatureConstants.Horse_Light)]
        [TestCase(CreatureConstants.Horse_Light_War)]
        [TestCase(CreatureConstants.Howler)]
        [TestCase(CreatureConstants.Hydra)]
        [TestCase(CreatureConstants.Hyena)]
        [TestCase(CreatureConstants.Imp)]
        [TestCase(CreatureConstants.InvisibleStalker)]
        [TestCase(CreatureConstants.Krenshar)]
        [TestCase(CreatureConstants.Lammasu)]
        [TestCase(CreatureConstants.LanternArchon)]
        [TestCase(CreatureConstants.Lemure)]
        [TestCase(CreatureConstants.Leonal)]
        [TestCase(CreatureConstants.Leopard)]
        [TestCase(CreatureConstants.Lich)]
        [TestCase(CreatureConstants.Lion)]
        [TestCase(CreatureConstants.Lion_Dire)]
        [TestCase(CreatureConstants.Livestock_Noncombatant)]
        [TestCase(CreatureConstants.Lizard)]
        [TestCase(CreatureConstants.Lizard_Monitor)]
        [TestCase(CreatureConstants.Locust_Swarm)]
        [TestCase(CreatureConstants.Magmin)] //Nonflammable
        [TestCase(CreatureConstants.Manticore)]
        [TestCase(CreatureConstants.Marut)]
        [TestCase(CreatureConstants.Megaraptor)]
        [TestCase(CreatureConstants.Mephit)]
        [TestCase(CreatureConstants.Mimic)]
        [TestCase(CreatureConstants.MindFlayer)]
        [TestCase(CreatureConstants.Mohrg)]
        [TestCase(CreatureConstants.Monkey)]
        [TestCase(CreatureConstants.Monkey_Celestial)]
        [TestCase(CreatureConstants.Mule)]
        [TestCase(CreatureConstants.Mummy)]
        [TestCase(CreatureConstants.Naga_Dark)]
        [TestCase(CreatureConstants.Naga_Guardian)]
        [TestCase(CreatureConstants.Naga_Spirit)]
        [TestCase(CreatureConstants.Naga_Water)]
        [TestCase(CreatureConstants.Nalfeshnee)]
        [TestCase(CreatureConstants.NightHag)]
        [TestCase(CreatureConstants.Nightcrawler)]
        [TestCase(CreatureConstants.Nightmare)]
        [TestCase(CreatureConstants.Nightwalker)]
        [TestCase(CreatureConstants.Nightwing)]
        [TestCase(CreatureConstants.NPC)]
        [TestCase(CreatureConstants.Ooze_Gray)]
        [TestCase(CreatureConstants.Ooze_OchreJelly)]
        [TestCase(CreatureConstants.Otyugh)]
        [TestCase(CreatureConstants.BoneDevil)]
        [TestCase(CreatureConstants.Owl)]
        [TestCase(CreatureConstants.Owl_Giant)]
        [TestCase(CreatureConstants.Owl_Celestial)]
        [TestCase(CreatureConstants.Owlbear)]
        [TestCase(CreatureConstants.Pegasus)]
        [TestCase(CreatureConstants.PhantomFungus)]
        [TestCase(CreatureConstants.PhaseSpider)]
        [TestCase(CreatureConstants.Phasm)]
        [TestCase(CreatureConstants.PitFiend)]
        [TestCase(CreatureConstants.Pony)]
        [TestCase(CreatureConstants.Pony_War)]
        [TestCase(CreatureConstants.PrayingMantis_Giant)]
        [TestCase(CreatureConstants.Pseudodragon)]
        [TestCase(CreatureConstants.PurpleWorm)]//Only stone goods
        [TestCase(CreatureConstants.Pyrohydra)]
        [TestCase(CreatureConstants.Quasit)]
        [TestCase(CreatureConstants.Rakshasa)]
        [TestCase(CreatureConstants.Rast)]
        [TestCase(CreatureConstants.Rat)]
        [TestCase(CreatureConstants.Rat_Dire)]
        [TestCase(CreatureConstants.Rat_Dire_Fiendish)]
        [TestCase(CreatureConstants.Rat_Swarm)]
        [TestCase(CreatureConstants.Raven)]
        [TestCase(CreatureConstants.Raven_Fiendish)]
        [TestCase(CreatureConstants.Ravid)]
        [TestCase(CreatureConstants.RazorBoar)]
        [TestCase(CreatureConstants.Remorhaz)]
        [TestCase(CreatureConstants.Retriever)]
        [TestCase(CreatureConstants.Rhinoceras)]
        [TestCase(CreatureConstants.Roc)]
        [TestCase(CreatureConstants.Roper)]//only stone goods
        [TestCase(CreatureConstants.RustMonster)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny)]
        [TestCase(CreatureConstants.Shadow)]
        [TestCase(CreatureConstants.Shadow_Greater)]
        [TestCase(CreatureConstants.ShadowMastiff)]
        [TestCase(CreatureConstants.ShamblingMound)]
        [TestCase(CreatureConstants.ShieldGuardian)]
        [TestCase(CreatureConstants.ShockerLizard)]
        [TestCase(CreatureConstants.Shrieker)]
        [TestCase(CreatureConstants.Skeleton)]
        [TestCase(CreatureConstants.Skum)]
        [TestCase(CreatureConstants.Slaad_Blue)]
        [TestCase(CreatureConstants.Slaad_Death)]
        [TestCase(CreatureConstants.Slaad_Gray)]
        [TestCase(CreatureConstants.Slaad_Green)]
        [TestCase(CreatureConstants.Slaad_Red)]
        [TestCase(CreatureConstants.Snake_Constrictor)]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant)]
        [TestCase(CreatureConstants.Snake_Viper_Huge)]
        [TestCase(CreatureConstants.Snake_Viper_Large)]
        [TestCase(CreatureConstants.Snake_Viper_Medium)]
        [TestCase(CreatureConstants.Snake_Viper_Small)]
        [TestCase(CreatureConstants.Snake_Viper_Tiny)]
        [TestCase(CreatureConstants.Spectre)]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal)]
        [TestCase(CreatureConstants.Spider_Monstrous_Gargantuan)]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge)]
        [TestCase(CreatureConstants.Spider_Monstrous_Large)]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium)]
        [TestCase(CreatureConstants.Spider_Monstrous_Small)]
        [TestCase(CreatureConstants.Spider_Monstrous_Tiny)]
        [TestCase(CreatureConstants.Spider_Swarm)]
        [TestCase(CreatureConstants.SpiderEater)]
        [TestCase(CreatureConstants.StagBeetle_Giant)]
        [TestCase(CreatureConstants.Stirge)]
        [TestCase(CreatureConstants.Succubus)]
        [TestCase(CreatureConstants.Tarrasque)]
        [TestCase(CreatureConstants.Tendriculos)]
        [TestCase(CreatureConstants.Thoqqua)]
        [TestCase(CreatureConstants.Tiger)]
        [TestCase(CreatureConstants.Tiger_Dire)]
        [TestCase(CreatureConstants.Toad)]
        [TestCase(CreatureConstants.Treant)]
        [TestCase(CreatureConstants.Triceratops)]
        [TestCase(CreatureConstants.Troll)]
        [TestCase(CreatureConstants.Tyrannosaurus)]
        [TestCase(CreatureConstants.UmberHulk)]
        [TestCase(CreatureConstants.UmberHulk_TrulyHorrid)]
        [TestCase(CreatureConstants.Unicorn)]
        [TestCase(CreatureConstants.Vampire)]
        [TestCase(CreatureConstants.VampireSpawn)]
        [TestCase(CreatureConstants.Vargouille)]
        [TestCase(CreatureConstants.VioletFungus)]
        [TestCase(CreatureConstants.Vrock)]
        [TestCase(CreatureConstants.Wasp_Giant)]
        [TestCase(CreatureConstants.Weasel)]
        [TestCase(CreatureConstants.Weasel_Dire)]
        [TestCase(CreatureConstants.Wight)]
        [TestCase(CreatureConstants.WillOWisp)]
        [TestCase(CreatureConstants.WinterWolf)]
        [TestCase(CreatureConstants.Wolf)]
        [TestCase(CreatureConstants.Wolf_Dire)]
        [TestCase(CreatureConstants.Wolverine)]
        [TestCase(CreatureConstants.Wolverine_Dire)]
        [TestCase(CreatureConstants.Worg)]
        [TestCase(CreatureConstants.Wraith)]
        [TestCase(CreatureConstants.Wraith_Dread)]
        [TestCase(CreatureConstants.Wyvern)]
        [TestCase(CreatureConstants.Xill)]
        [TestCase(CreatureConstants.Xorn_Average)]
        [TestCase(CreatureConstants.Xorn_Elder)]
        [TestCase(CreatureConstants.Xorn_Minor)]
        [TestCase(CreatureConstants.YethHound)]
        [TestCase(CreatureConstants.Yrthak)]
        [TestCase(CreatureConstants.Zombie)]
        [TestCase(CharacterClassConstants.Warrior)]
        [TestCase(CharacterClassConstants.Expert)]
        [TestCase(CharacterClassConstants.Commoner)]
        [TestCase(CharacterClassConstants.Adept)]
        [TestCase(CharacterClassConstants.Aristocrat)]
        [TestCase(CharacterClassConstants.Barbarian)]
        [TestCase(CharacterClassConstants.Bard)]
        [TestCase(CharacterClassConstants.Cleric)]
        [TestCase(CharacterClassConstants.Druid)]
        [TestCase(CharacterClassConstants.Fighter)]
        [TestCase(CharacterClassConstants.Monk)]
        [TestCase(CharacterClassConstants.Paladin)]
        [TestCase(CharacterClassConstants.Ranger)]
        [TestCase(CharacterClassConstants.Rogue)]
        [TestCase(CharacterClassConstants.Sorcerer)]
        [TestCase(CharacterClassConstants.Wizard)]
        public override void DistinctCollection(string entry, params string[] items)
        {
            base.DistinctCollection(entry, items);
        }

        [TestCase(CreatureConstants.AstralDeva, WeaponConstants.HeavyMace, ItemTypeConstants.Weapon, 3, SpecialAbilityConstants.Disruption)]
        [TestCase(CreatureConstants.BeardedDevil, WeaponConstants.Glaive, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)]
        [TestCase(CreatureConstants.ChainDevil, WeaponConstants.SpikedChain, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)]
        [TestCase(CreatureConstants.FormianMyrmarch, WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Ghaele, WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 4, SpecialAbilityConstants.Holy)]
        [TestCase(CreatureConstants.Giant_Cloud, WeaponConstants.Morningstar, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Gargantuan)]
        [TestCase(CreatureConstants.Giant_Fire, WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Giant_Stone, WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Giant_Stone_Elder, WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Grimlock, WeaponConstants.Battleaxe, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)] //only gems, no art objects
        [TestCase(CreatureConstants.Harpy, WeaponConstants.Club, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)]
        [TestCase(CreatureConstants.HornedDevil, WeaponConstants.SpikedChain, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.HoundArchon, WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)]
        [TestCase(CreatureConstants.IceDevil, WeaponConstants.Longspear, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Kolyarut, WeaponConstants.Longsword, ItemTypeConstants.Weapon, 2, "")]
        [TestCase(CreatureConstants.Lamia, WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Lillend, WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.Minotaur, WeaponConstants.Greataxe, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.NessianWarhound, ArmorConstants.ChainShirt, ItemTypeConstants.Armor, 2, "", "Barding")]
        [TestCase(CreatureConstants.Nymph, WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)]
        [TestCase(CreatureConstants.Planetar, WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 3, "")]
        [TestCase(CreatureConstants.Salamander_Average, WeaponConstants.Shortspear, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Medium)] //Non-flammable
        [TestCase(CreatureConstants.Salamander_Flamebrother, WeaponConstants.Shortspear, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Small)]//Non-flammable
        [TestCase(CreatureConstants.Salamander_Noble, WeaponConstants.Longspear, ItemTypeConstants.Weapon, 3, "")]//Non-flammable
        [TestCase(CreatureConstants.Scorpionfolk, WeaponConstants.Lance, ItemTypeConstants.Weapon, 0, "", TraitConstants.Sizes.Large)]
        [TestCase(CreatureConstants.TrumpetArchon, WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 4, "")]
        public void SetItem(string entry, string itemName, string itemType, int itemBonus, string abilityName, params string[] traits)
        {
            var setItem = FormatSetItem(itemName, itemType, itemBonus, abilityName, false, traits);
            base.DistinctCollection(entry, new[] { setItem });
        }

        private string FormatSetItem(string itemName, string itemType, int itemBonus = 0, string abilityName = "", bool isMagic = false, params string[] traits)
        {
            var setItem = $"{itemName}[{itemType}]";

            if (traits.Any())
                setItem += $"#{string.Join(",", traits)}#";

            if (itemBonus > 0)
                setItem += $"({itemBonus})";

            if (string.IsNullOrEmpty(abilityName) == false)
                setItem += $"{{{abilityName}}}";

            if (isMagic)
                setItem += $"@{isMagic}@";

            return setItem;
        }

        [Test]
        public void AasimarItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var crossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.AasimarWarrior, new[] { longsword, crossbow });
        }

        [Test]
        public void AthachItems()
        {
            var morningstar = FormatSetItem(WeaponConstants.Morningstar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Huge);
            base.Collection(CreatureConstants.Athach, new[] { morningstar, morningstar, morningstar });
        }

        [Test]
        public void AzerItems()
        {
            var warhammer = FormatSetItem(WeaponConstants.Warhammer, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var spear = FormatSetItem(WeaponConstants.Shortspear, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Azer, new[] { warhammer, spear });
        }

        [Test]
        public void BalorItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Vorpal);
            var whip = FormatSetItem(WeaponConstants.Whip, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Flaming);
            base.DistinctCollection(CreatureConstants.Balor, new[] { longsword, whip });
        }

        [Test]
        public void BralaniItems()
        {
            var scimitar = FormatSetItem(WeaponConstants.Scimitar, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Holy);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Holy, false, "+4 Strength bonus");
            base.DistinctCollection(CreatureConstants.Bralani, new[] { scimitar, longbow });
        }

        [Test]
        public void BugbearItems()
        {
            var morningstar = FormatSetItem(WeaponConstants.Morningstar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Bugbear, new[] { morningstar, javelin });
        }

        [Test]
        public void CentaurItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large, "+4 Strength bonus");
            base.DistinctCollection(CreatureConstants.Centaur, new[] { longsword, longbow });
        }

        [Test]
        public void DerroItems()
        {
            var shortSword = FormatSetItem(WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var crossbow = FormatSetItem(WeaponConstants.LightRepeatingCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            base.DistinctCollection(CreatureConstants.Derro, new[] { shortSword, crossbow });
        }

        [Test]
        public void DriderItems()
        {
            var dagger = FormatSetItem(WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var shortbow = FormatSetItem(WeaponConstants.Shortbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            base.Collection(CreatureConstants.Drider, new[] { dagger, dagger, shortbow });
        }

        [Test]
        public void DrowWarriorItems()
        {
            var rapier = FormatSetItem(WeaponConstants.Rapier, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var crossbow = FormatSetItem(WeaponConstants.HandCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.DrowWarrior, new[] { rapier, crossbow });
        }

        [Test]
        public void DryadItems()
        {
            var dagger = FormatSetItem(WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium, TraitConstants.Masterwork);
            base.DistinctCollection(CreatureConstants.Dryad, new[] { dagger, longbow });
        }

        [Test]
        public void DuergarWarriorItems()
        {
            var warhammer = FormatSetItem(WeaponConstants.Warhammer, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var crossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.DuergarWarrior, new[] { warhammer, crossbow });
        }

        [Test]
        public void DwarfWarriorItems()
        {
            var waraxe = FormatSetItem(WeaponConstants.DwarvenWaraxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var shortbow = FormatSetItem(WeaponConstants.Shortbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.DwarfWarrior, new[] { waraxe, shortbow });
        }

        [Test]
        public void ElfWarriorItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.ElfWarrior, new[] { longsword, longbow });
        }

        [Test]
        public void ErinyesItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Flaming, false, "+5 Strength bonus");
            var rope = FormatSetItem("Rope, 50 ft.", ItemTypeConstants.Tool);
            base.DistinctCollection(CreatureConstants.Erinyes, new[] { longsword, longbow, rope });
        }

        [Test]
        public void EttinItems()
        {
            var morningstar = FormatSetItem(WeaponConstants.Morningstar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            base.DistinctCollection(CreatureConstants.Ettin, new[] { morningstar, javelin });
        }

        [Test]
        public void FrostGiantItems()
        {
            var greataxe = FormatSetItem(WeaponConstants.Greataxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var armor = FormatSetItem(ArmorConstants.ChainShirt, ItemTypeConstants.Armor, 0, string.Empty, false, TraitConstants.Sizes.Large);
            base.DistinctCollection(CreatureConstants.Giant_Frost, new[] { greataxe, armor });
        }

        [Test]
        public void FrostGiantJarlItems()
        {
            var greataxe = FormatSetItem(WeaponConstants.Greataxe, ItemTypeConstants.Weapon, 2, SpecialAbilityConstants.Frost, false);
            var armor = FormatSetItem(ArmorConstants.FullPlate, ItemTypeConstants.Armor, 2);
            var cloak = FormatSetItem(WondrousItemConstants.CloakOfCharisma, ItemTypeConstants.WondrousItem, 2);
            var ring = FormatSetItem(RingConstants.FireResistance_Minor, ItemTypeConstants.Ring, isMagic: true);
            var poison = FormatSetItem("Vial of bloodroot poison", ItemTypeConstants.AlchemicalItem);
            base.Collection(CreatureConstants.Giant_Frost_Jarl, new[] { greataxe, armor, cloak, ring, poison, poison });
        }

        [Test]
        public void HillGiantItems()
        {
            var greatclub = FormatSetItem(WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var armor = FormatSetItem(ArmorConstants.HideArmor, ItemTypeConstants.Armor, 0, string.Empty, false, TraitConstants.Sizes.Large);
            base.DistinctCollection(CreatureConstants.Giant_Hill, new[] { greatclub, armor });
        }

        [Test]
        public void GnollItems()
        {
            var battleaxe = FormatSetItem(WeaponConstants.Battleaxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var shortbow = FormatSetItem(WeaponConstants.Shortbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Gnoll, new[] { battleaxe, shortbow });
        }

        [Test]
        public void GnomeWarriorItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var crossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            base.DistinctCollection(CreatureConstants.GnomeWarrior, new[] { longsword, crossbow });
        }

        [Test]
        public void GoblinItems()
        {
            var morningstar = FormatSetItem(WeaponConstants.Morningstar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            base.DistinctCollection(CreatureConstants.Goblin, new[] { morningstar, javelin });
        }

        [Test]
        public void GrigItems()
        {
            var shortSword = FormatSetItem(WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Tiny);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Tiny);
            base.DistinctCollection(CreatureConstants.Grig, new[] { shortSword, longbow });
        }

        [Test]
        public void HalflingWarriorItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var lightCrossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            base.DistinctCollection(CreatureConstants.HalflingWarrior, new[] { longsword, lightCrossbow });
        }

        [Test]
        public void HarpyArcherItems()
        {
            var armor = FormatSetItem(ArmorConstants.StuddedLeatherArmor, ItemTypeConstants.Armor, 3);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 1, SpecialAbilityConstants.Frost, false, "+1 Strength bonus");
            base.DistinctCollection(CreatureConstants.HarpyArcher, new[] { armor, longbow });
        }

        [Test]
        public void HobgoblinItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Hobgoblin, new[] { longsword, javelin });
        }

        [Test]
        public void HoundArchonHeroItems()
        {
            var armor = FormatSetItem(ArmorConstants.FullPlate, ItemTypeConstants.Armor, 3);
            var greatsword = FormatSetItem(WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 2, string.Empty, false, TraitConstants.SpecialMaterials.ColdIron);
            base.DistinctCollection(CreatureConstants.HoundArchon_Hero, new[] { greatsword, armor });
        }

        [Test]
        public void JanniItems()
        {
            var scimitar = FormatSetItem(WeaponConstants.Scimitar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Janni, new[] { scimitar, longbow });
        }

        [Test]
        public void KoboldItems()
        {
            var spear = FormatSetItem(WeaponConstants.Shortspear, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var sling = FormatSetItem(WeaponConstants.Sling, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            base.DistinctCollection(CreatureConstants.Kobold, new[] { spear, sling });
        }

        [Test]
        public void LizardfolkItems()
        {
            var club = FormatSetItem(WeaponConstants.Club, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Lizardfolk, new[] { club, javelin });
        }

        [Test]
        public void MarilithItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            base.Collection(CreatureConstants.Marilith, new[] { longsword, longsword, longsword, longsword, longsword, longsword });
        }

        [Test]
        public void MedusaItems()
        {
            var dagger = FormatSetItem(WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var shortbow = FormatSetItem(WeaponConstants.Shortbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Medusa, new[] { dagger, shortbow });
        }

        [Test]
        public void MindFlayerSorcererItems()
        {
            var armor = FormatSetItem(ArmorConstants.ChainShirt, ItemTypeConstants.Armor, 1, string.Empty, false, TraitConstants.SpecialMaterials.Mithral);
            var cloak = FormatSetItem(WondrousItemConstants.CloakOfCharisma, ItemTypeConstants.WondrousItem, 2);
            var ring = FormatSetItem(RingConstants.Protection, ItemTypeConstants.Ring, 2);

            base.DistinctCollection(CreatureConstants.MindFlayer_Sorcerer, armor, cloak, ring);
        }

        [Test]
        public void MummyLordItems()
        {
            var armor = FormatSetItem(ArmorConstants.HalfPlate, ItemTypeConstants.Armor, 2);
            var cloak = FormatSetItem(WondrousItemConstants.CloakOfResistance, ItemTypeConstants.WondrousItem, 2);
            var ring = FormatSetItem(RingConstants.FireResistance_Minor, ItemTypeConstants.Ring, isMagic: true);
            var brooch = FormatSetItem(WondrousItemConstants.BroochOfShielding, ItemTypeConstants.WondrousItem, isMagic: true);

            base.DistinctCollection(CreatureConstants.MummyLord, armor, cloak, ring, brooch);
        }

        [Test]
        public void NixieItems()
        {
            var shortSword = FormatSetItem(WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var crossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            base.DistinctCollection(CreatureConstants.Nixie, new[] { shortSword, crossbow });
        }

        [Test]
        public void OgreItems()
        {
            var greatclub = FormatSetItem(WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            base.DistinctCollection(CreatureConstants.Ogre, new[] { greatclub, javelin });
        }

        [Test]
        public void OgreBarbarianItems()
        {
            var greatclub = FormatSetItem(WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 1);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var armor = FormatSetItem(ArmorConstants.HideArmor, ItemTypeConstants.Armor, 1);
            var ring = FormatSetItem(RingConstants.Protection, ItemTypeConstants.Ring, 1);
            base.DistinctCollection(CreatureConstants.Ogre_Barbarian, greatclub, javelin, armor, ring);
        }

        [Test]
        public void OgreMageItems()
        {
            var greatsword = FormatSetItem(WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            base.DistinctCollection(CreatureConstants.OgreMage, new[] { greatsword, longbow });
        }

        [Test]
        public void OrcItems()
        {
            var falchion = FormatSetItem(WeaponConstants.Falchion, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Orc, new[] { falchion, javelin });
        }

        [Test]
        public void PixieItems()
        {
            var shortSword = FormatSetItem(WeaponConstants.ShortSword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            base.DistinctCollection(CreatureConstants.Pixie, new[] { shortSword, longbow });
        }

        [Test]
        public void SatyrItems()
        {
            var dagger = FormatSetItem(WeaponConstants.Dagger, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var shortbow = FormatSetItem(WeaponConstants.Shortbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Satyr, new[] { dagger, shortbow });
        }

        [Test]
        public void SolarItems()
        {
            var greatsword = FormatSetItem(WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 5, SpecialAbilityConstants.Dancing);
            //HACK: The slaying arrow trait should really be a special ability, but TreasureGen does not support custom special abilities.
            //This is because it does not know how to compute the bonus equivalent of such an ability, which would factor into intelligence ego.
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 2, string.Empty, false, "+5 Strength bonus", "Creates slaying arrows keyed to any creature type or subtype");
            base.DistinctCollection(CreatureConstants.Solar, new[] { greatsword, longbow });
        }

        [Test]
        public void StormGiantItems()
        {
            var greatsword = FormatSetItem(WeaponConstants.Greatsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Huge);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Huge, "+14 Strength bonus");
            base.DistinctCollection(CreatureConstants.Giant_Storm, new[] { greatsword, longbow });
        }

        [Test]
        public void SvirfneblinWarriorItems()
        {
            var pick = FormatSetItem(WeaponConstants.HeavyPick, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            var crossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Small);
            base.DistinctCollection(CreatureConstants.SvirfneblinWarrior, new[] { pick, crossbow });
        }

        [Test]
        public void TieflingItems()
        {
            var rapier = FormatSetItem(WeaponConstants.Rapier, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var crossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.TieflingWarrior, new[] { rapier, crossbow });
        }

        [Test]
        public void TitanItems()
        {
            var warhammer = FormatSetItem(WeaponConstants.Warhammer, ItemTypeConstants.Weapon, 3, string.Empty, false, TraitConstants.Sizes.Gargantuan, TraitConstants.SpecialMaterials.Adamantine);
            var armor = FormatSetItem(ArmorConstants.HalfPlate, ItemTypeConstants.Armor, 4);
            base.DistinctCollection(CreatureConstants.Titan, new[] { warhammer, armor });
        }

        [Test]
        public void TroglodyteItems()
        {
            var club = FormatSetItem(WeaponConstants.Club, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Troglodyte, new[] { club, javelin });
        }

        [Test]
        public void TrollHunterItems()
        {
            var battleaxe = FormatSetItem(WeaponConstants.Battleaxe, ItemTypeConstants.Weapon, 1);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Troll_Hunter, new[] { battleaxe, javelin });
        }

        [Test]
        public void WerebearItems()
        {
            var greataxe = FormatSetItem(WeaponConstants.Greataxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var throwingAxe = FormatSetItem(WeaponConstants.ThrowingAxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Werebear, new[] { greataxe, throwingAxe });
        }

        [Test]
        public void WereboarItems()
        {
            var battleaxe = FormatSetItem(WeaponConstants.Battleaxe, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var javelin = FormatSetItem(WeaponConstants.Javelin, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var armor = FormatSetItem(ArmorConstants.ScaleMail, ItemTypeConstants.Armor, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var shield = FormatSetItem(ArmorConstants.HeavyWoodenShield, ItemTypeConstants.Armor, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Wereboar, new[] { battleaxe, javelin, armor, shield });
        }

        [Test]
        public void HillGiantDireWereboarItems()
        {
            var greatclub = FormatSetItem(WeaponConstants.Greatclub, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var armor = FormatSetItem(ArmorConstants.HideArmor, ItemTypeConstants.Armor, 0, string.Empty, false, TraitConstants.Sizes.Large);
            base.DistinctCollection(CreatureConstants.Wereboar_HillGiantDire, new[] { greatclub, armor });
        }

        [Test]
        public void WereratItems()
        {
            var rapier = FormatSetItem(WeaponConstants.Rapier, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var lightCrossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Wererat, new[] { rapier, lightCrossbow });
        }

        [Test]
        public void WeretigerItems()
        {
            var glaive = FormatSetItem(WeaponConstants.Glaive, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium, "+1 Strength bonus");
            base.DistinctCollection(CreatureConstants.Weretiger, new[] { glaive, longbow });
        }

        [Test]
        public void WerewolfItems()
        {
            var longsword = FormatSetItem(WeaponConstants.Longsword, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var lightCrossbow = FormatSetItem(WeaponConstants.LightCrossbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.Werewolf, new[] { longsword, lightCrossbow });
        }

        [Test]
        public void WerewolfLordItems()
        {
            var bastardSword = FormatSetItem(WeaponConstants.BastardSword, ItemTypeConstants.Weapon, 2);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium, "+4 Strength bonus", TraitConstants.Masterwork);
            base.DistinctCollection(CreatureConstants.WerewolfLord, new[] { bastardSword, longbow });
        }

        [Test]
        public void YuanTiPurebloodItems()
        {
            var scimitar = FormatSetItem(WeaponConstants.Scimitar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.Longbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            base.DistinctCollection(CreatureConstants.YuanTi_Pureblood, new[] { scimitar, longbow });
        }

        [Test]
        public void YuanTiHalfbloodItems()
        {
            var scimitar = FormatSetItem(WeaponConstants.Scimitar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Medium, "+2 Strength bonus");
            base.DistinctCollection(CreatureConstants.YuanTi_Halfblood, new[] { scimitar, longbow });
        }

        [Test]
        public void YuanTiAbominationItems()
        {
            var scimitar = FormatSetItem(WeaponConstants.Scimitar, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            var longbow = FormatSetItem(WeaponConstants.CompositeLongbow, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large, "+4 Strength bonus");
            base.DistinctCollection(CreatureConstants.YuanTi_Abomination, new[] { scimitar, longbow });
        }

        [Test]
        public void ZelekhutItems()
        {
            var chain = FormatSetItem(WeaponConstants.SpikedChain, ItemTypeConstants.Weapon, 0, string.Empty, false, TraitConstants.Sizes.Large);
            base.Collection(CreatureConstants.Zelekhut, new[] { chain, chain });
        }
    }
}
