﻿using CharacterGen.CharacterClasses;
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
                CreatureConstants.Aboleth,
                CreatureConstants.Achaierais,
                CreatureConstants.Allip,
                CreatureConstants.Ankheg,
                "Annis",
                CreatureConstants.Ant_Giant_Soldier,
                CreatureConstants.Ant_Giant_Worker,
                CreatureConstants.Ape,
                CreatureConstants.Ape_Dire,
                CreatureConstants.Aranea,
                CreatureConstants.Arrowhawk_Adult,
                CreatureConstants.Arrowhawk_Elder,
                CreatureConstants.Arrowhawk_Juvenile,
                "Astral deva",
                CreatureConstants.Athach,
                CreatureConstants.Avoral,
                CreatureConstants.Azer,
                "Balor",
                CreatureConstants.Badger,
                CreatureConstants.Badger_Dire,
                "Barbazu",
                CreatureConstants.Barghest,
                CreatureConstants.Barghest_Greater,
                CreatureConstants.Basilisk,
                CreatureConstants.Bat,
                CreatureConstants.Bat_Dire,
                CreatureConstants.Bear_Black,
                CreatureConstants.Bear_Brown,
                CreatureConstants.Bear_Dire,
                CreatureConstants.Bear_Polar,
                "Bebilith",
                CreatureConstants.Behir,
                CreatureConstants.Beholder,
                CreatureConstants.Belker,
                CreatureConstants.BlackPudding,
                CreatureConstants.BlinkDog,
                CreatureConstants.Boar,
                CreatureConstants.Boar_Dire,
                CreatureConstants.Bodak,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Bugbear,
                CreatureConstants.Bulette,
                CreatureConstants.CarrionCrawler,
                CreatureConstants.Centipede_Monstrous_Colossal,
                CreatureConstants.Centipede_Monstrous_Gargantuan,
                CreatureConstants.Centipede_Monstrous_Huge,
                CreatureConstants.Centipede_Monstrous_Large,
                CreatureConstants.Centipede_Monstrous_Medium,
                CreatureConstants.Centipede_Monstrous_Small,
                CreatureConstants.Centipede_Monstrous_Tiny,
                CreatureConstants.ChaosBeast,
                CreatureConstants.Character,
                CreatureConstants.Chimera,
                CreatureConstants.Choker,
                CreatureConstants.Cloaker,
                CreatureConstants.Cockatrice,
                CharacterClassConstants.Commoner,
                "Cornugon",
                CreatureConstants.Couatl,
                CreatureConstants.Criosphinx,
                CreatureConstants.Cryohydra,
                CreatureConstants.Chuul,
                CreatureConstants.Darkmantle,
                CreatureConstants.Delver,
                CreatureConstants.Destrachan,
                CreatureConstants.Devourer,
                CreatureConstants.Digester,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Djinn,
                CreatureConstants.Doppelganger,
                CreatureConstants.Dragon,
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
                "Dretch",
                CreatureConstants.Drider,
                CreatureConstants.DwarfWarrior,
                CreatureConstants.Efreet,
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
                "Erinyes",
                CreatureConstants.EtherealFilcher,
                CreatureConstants.EtherealMarauder,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.FormianWarrior,
                CreatureConstants.FormianWorker,
                CreatureConstants.FormianTaskmaster,
                CreatureConstants.FormianMyrmarch,
                CreatureConstants.FrostWorm,
                CreatureConstants.Gargoyle,
                CreatureConstants.GelatinousCube,
                "Gelugon",
                "Ghaele",
                CreatureConstants.Ghast,
                CreatureConstants.Ghost,
                CreatureConstants.Ghoul,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Storm,
                CreatureConstants.GibberingMouther,
                CreatureConstants.Girallon,
                "Glabrezu",
                CreatureConstants.Gnoll,
                CreatureConstants.Goblin,
                CreatureConstants.Golem_Clay,
                CreatureConstants.Golem_Flesh,
                CreatureConstants.Golem_Iron,
                CreatureConstants.Golem_Stone,
                CreatureConstants.Golem_Stone_Greater,
                CreatureConstants.Gorgon,
                CreatureConstants.GrayRender,
                "Green hag",
                CreatureConstants.Grick,
                CreatureConstants.Gynosphinx,
                "Hamatula",
                CreatureConstants.Harpy,
                CreatureConstants.Hellcat,
                CreatureConstants.HellHound,
                "Hezrou",
                CreatureConstants.Hieracosphinx,
                CreatureConstants.Hobgoblin,
                "Hound archon",
                CreatureConstants.Howler,
                CreatureConstants.Hydra,
                CreatureConstants.Hyena,
                "Imp",
                CreatureConstants.InvisibleStalker,
                CreatureConstants.Janni,
                CreatureConstants.Kobold,
                CreatureConstants.Krenshar,
                "Kyton",
                CreatureConstants.Lamia,
                CreatureConstants.Lammasu,
                "Lantern archon",
                "Lemure",
                CreatureConstants.Lich,
                CreatureConstants.Lillend,
                CreatureConstants.Lion_Dire,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.Magmin,
                CreatureConstants.Manticore,
                "Marilith",
                CreatureConstants.Medusa,
                CreatureConstants.Mephit,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.Minotaur,
                CreatureConstants.Mohrg,
                CreatureConstants.Mummy,
                CreatureConstants.Naga_Dark,
                CreatureConstants.Naga_Guardian,
                CreatureConstants.Naga_Spirit,
                CreatureConstants.Naga_Water,
                "Nalfeshnee",
                CreatureConstants.NightHag,
                "Nightcrawler",
                CreatureConstants.Nightmare,
                "Nightwalker",
                "Nightwing",
                CreatureConstants.Ogre,
                CreatureConstants.OgreMage,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.Orc,
                "Osyluth",
                CreatureConstants.Otyugh,
                CreatureConstants.Owl,
                CreatureConstants.Owlbear,
                CreatureConstants.Owl_Giant,
                CreatureConstants.PhantomFungus,
                CreatureConstants.PhaseSpider,
                CreatureConstants.Phasm,
                "Pit fiend",
                "Planetar",
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.PurpleWorm,
                CreatureConstants.Pyrohydra,
                "Quasit",
                CreatureConstants.Rast,
                CreatureConstants.Rat,
                CreatureConstants.Rat_Dire,
                CreatureConstants.Ravid,
                CreatureConstants.Remorhaz,
                CreatureConstants.Retriever,
                CreatureConstants.Roper,
                CreatureConstants.RustMonster,
                CreatureConstants.Salamander_Noble,
                CreatureConstants.Salamander_Average,
                CreatureConstants.Salamander_Flamebrother,
                CreatureConstants.Scorpion_Monstrous_Colossal,
                CreatureConstants.Scorpion_Monstrous_Gargantuan,
                CreatureConstants.Scorpion_Monstrous_Huge,
                CreatureConstants.Scorpion_Monstrous_Large,
                CreatureConstants.Scorpion_Monstrous_Medium,
                CreatureConstants.Scorpion_Monstrous_Small,
                CreatureConstants.Scorpion_Monstrous_Tiny,
                CreatureConstants.Shadow,
                CreatureConstants.ShadowMastiff,
                CreatureConstants.ShamblingMound,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Shrieker,
                CreatureConstants.Skeleton,
                CreatureConstants.Slaad_Death,
                CreatureConstants.Slaad_Green,
                CreatureConstants.Slaad_Blue,
                CreatureConstants.Slaad_Gray,
                CreatureConstants.Slaad_Red,
                CreatureConstants.Snake_Constrictor_Giant,
                CreatureConstants.Snake_Viper_Huge,
                CreatureConstants.Snake_Viper_Tiny,
                "Solar",
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
                CreatureConstants.Thoqqua,
                CreatureConstants.Tiger,
                CreatureConstants.Tiger_Dire,
                CreatureConstants.Troglodyte,
                CreatureConstants.Troll,
                "Trumpet archon",
                CreatureConstants.UmberHulk,
                CreatureConstants.VampireSpawn,
                CreatureConstants.Vampire,
                CreatureConstants.Vargouille,
                CreatureConstants.VioletFungus,
                "Vrock",
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
                CreatureConstants.Wyvern,
                CreatureConstants.Xorn_Average,
                CreatureConstants.Xorn_Elder,
                CreatureConstants.Xorn_Minor,
                CreatureConstants.YethHound,
                CreatureConstants.Yrthak,
                "Yuan-ti",
                CreatureConstants.Zombie,
                CreatureConstants.NPC,
                CharacterClassConstants.Warrior
            };

            AssertEntriesAreComplete(entries);
        }

        [TestCase(CreatureConstants.Aboleth, 2, 2, 2)]
        [TestCase(CreatureConstants.Achaierais, 2, 2, 2)]
        [TestCase(CreatureConstants.Allip, 0, 0, 0)]
        [TestCase(CreatureConstants.Ankheg, 0, 0, 0)]
        [TestCase("Annis", 1, 1, 1)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier, 0, 0, 0)]
        [TestCase(CreatureConstants.Ant_Giant_Worker, 0, 0, 0)]
        [TestCase(CreatureConstants.Ape, 0, 0, 0)]
        [TestCase(CreatureConstants.Ape_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Aranea, 1, 2, 1)]
        [TestCase(CreatureConstants.Arrowhawk_Adult, 0, 0, 0)]
        [TestCase(CreatureConstants.Arrowhawk_Elder, 0, 0, 0)]
        [TestCase(CreatureConstants.Arrowhawk_Juvenile, 0, 0, 0)]
        [TestCase("Astral deva", 0, 2, 1)]
        [TestCase(CreatureConstants.Athach, TreasureConstants.FiftyPercent, 2, 1)]
        [TestCase(CreatureConstants.Avoral, 0, 2, 1)]
        [TestCase(CreatureConstants.Azer, 1, 2, 1)]
        [TestCase("Balor", 1, 2, 1)]
        [TestCase(CreatureConstants.Badger, 0, 0, 0)]
        [TestCase(CreatureConstants.Badger_Dire, 0, 0, 0)]
        [TestCase("Barbazu", 1, 1, 1)]
        [TestCase(CreatureConstants.Barghest, 2, 2, 2)]
        [TestCase(CreatureConstants.Barghest_Greater, 2, 2, 2)]
        [TestCase(CreatureConstants.Basilisk, 0, 0, 0)]
        [TestCase(CreatureConstants.Bat, 0, 0, 0)]
        [TestCase(CreatureConstants.Bat_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Bear_Black, 0, 0, 0)]
        [TestCase(CreatureConstants.Bear_Brown, 0, 0, 0)]
        [TestCase(CreatureConstants.Bear_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Bear_Polar, 0, 0, 0)]
        [TestCase("Bebilith", 0, 0, 0)]
        [TestCase(CreatureConstants.Behir, 1, 1, 1)]
        [TestCase(CreatureConstants.Beholder, 2, 2, 2)]
        [TestCase(CreatureConstants.Belker, 0, 0, 0)]
        [TestCase(CreatureConstants.BlackPudding, 0, 0, 0)]
        [TestCase(CreatureConstants.BlinkDog, 0, 0, 0)]
        [TestCase(CreatureConstants.Boar, 0, 0, 0)]
        [TestCase(CreatureConstants.Boar_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Bodak, 0, 0, 0)]
        [TestCase(CreatureConstants.BombardierBeetle_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Bugbear, 1, 1, 1)]
        [TestCase(CreatureConstants.Bulette, 0, 0, 0)]
        [TestCase(CreatureConstants.CarrionCrawler, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.ChaosBeast, 0, 0, 0)]
        [TestCase(CreatureConstants.Character, 0, 0, 0)]
        [TestCase(CreatureConstants.NPC, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Warrior, 0, 0, 0)]
        [TestCase(CreatureConstants.Chimera, 1, 1, 1)]
        [TestCase(CreatureConstants.Choker, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Chuul, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, 1)]
        [TestCase(CreatureConstants.Cloaker, 1, 1, 1)]
        [TestCase(CreatureConstants.Cockatrice, 0, 0, 0)]
        [TestCase(CharacterClassConstants.Commoner, 0, 0, 0)]
        [TestCase("Cornugon", 1, 2, 1)]
        [TestCase(CreatureConstants.Couatl, 1, 1, 1)]
        [TestCase(CreatureConstants.Criosphinx, 1, 1, 1)]
        [TestCase(CreatureConstants.Cryohydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Darkmantle, 0, 0, 0)]
        [TestCase(CreatureConstants.Delver, 0, 0, 0)]
        [TestCase(CreatureConstants.Destrachan, 0, 0, 0)]
        [TestCase(CreatureConstants.Devourer, 0, 0, 0)]
        [TestCase(CreatureConstants.Digester, 0, 0, 0)]
        [TestCase(CreatureConstants.DisplacerBeast, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Djinn, 1, 1, 1)]
        [TestCase(CreatureConstants.Doppelganger, 2, 2, 2)]
        [TestCase(CreatureConstants.Dragon, 3, 3, 3)]
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
        [TestCase("Dretch", 0, 0, 0)]
        [TestCase(CreatureConstants.Drider, 2, 2, 2)]
        [TestCase(CreatureConstants.DwarfWarrior, 1, 2, 1)]
        [TestCase(CreatureConstants.Efreet, 1, 2, 1)]
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
        [TestCase(CreatureConstants.ElfWarrior, 1, 1, 1)]
        [TestCase("Erinyes", 1, 1, 1)]
        [TestCase(CreatureConstants.EtherealFilcher, 0, 1, 2)]
        [TestCase(CreatureConstants.EtherealMarauder, 0, 0, 0)]
        [TestCase(CreatureConstants.Ettercap, 1, 1, 1)]
        [TestCase(CreatureConstants.Ettin, 1, 1, 1)]
        [TestCase(CreatureConstants.FireBeetle_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.FormianWarrior, 0, 0, 0)]
        [TestCase(CreatureConstants.FormianWorker, 0, 0, 0)]
        [TestCase(CreatureConstants.FormianTaskmaster, 1, 1, 1)]
        [TestCase(CreatureConstants.FormianMyrmarch, 1, 1, 1)]
        [TestCase(CreatureConstants.FrostWorm, 0, 0, 0)]
        [TestCase(CreatureConstants.Gargoyle, 1, 1, 1)]
        [TestCase(CreatureConstants.GelatinousCube, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase("Gelugon", 1, 2, 1)]
        [TestCase("Ghaele", 0, 2, 1)]
        [TestCase(CreatureConstants.Ghast, 1, 1, 1)]
        [TestCase(CreatureConstants.Ghost, 0, 0, 0)]
        [TestCase(CreatureConstants.Ghoul, 0, 0, 0)]
        [TestCase(CreatureConstants.Giant_Cloud, 2, 1, 2)]
        [TestCase(CreatureConstants.Giant_Fire, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Frost, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Hill, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Stone, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Storm, 2, 1, 2)]
        [TestCase(CreatureConstants.GibberingMouther, 0, 0, 0)]
        [TestCase(CreatureConstants.Girallon, 0, 0, 0)]
        [TestCase("Glabrezu", 1, 2, 1)]
        [TestCase(CreatureConstants.Gnoll, 1, 1, 1)]
        [TestCase(CreatureConstants.Goblin, 1, 1, 1)]
        [TestCase(CreatureConstants.Golem_Clay, 0, 0, 0)]
        [TestCase(CreatureConstants.Golem_Flesh, 0, 0, 0)]
        [TestCase(CreatureConstants.Golem_Iron, 0, 0, 0)]
        [TestCase(CreatureConstants.Golem_Stone, 0, 0, 0)]
        [TestCase(CreatureConstants.Golem_Stone_Greater, 0, 0, 0)]
        [TestCase(CreatureConstants.Gorgon, 0, 0, 0)]
        [TestCase(CreatureConstants.GrayRender, 0, 0, 0)]
        [TestCase("Green hag", 1, 1, 1)]
        [TestCase(CreatureConstants.Grick, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Gynosphinx, 2, 2, 2)]
        [TestCase("Hamatula", 1, 1, 1)]
        [TestCase(CreatureConstants.Harpy, 1, 1, 1)]
        [TestCase(CreatureConstants.Hellcat, 0, 0, 0)]
        [TestCase(CreatureConstants.HellHound, 0, 0, 0)]
        [TestCase("Hezrou", 1, 1, 1)]
        [TestCase(CreatureConstants.Hieracosphinx, 0, 0, 0)]
        [TestCase(CreatureConstants.Hobgoblin, 1, 1, 1)]
        [TestCase("Hound archon", 0, 2, 1)]
        [TestCase(CreatureConstants.Howler, 0, 0, 0)]
        [TestCase(CreatureConstants.Hydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Hyena, 0, 0, 0)]
        [TestCase("Imp", 0, 0, 0)]
        [TestCase(CreatureConstants.InvisibleStalker, 0, 0, 0)]
        [TestCase(CreatureConstants.Kobold, 1, 1, 1)]
        [TestCase(CreatureConstants.Krenshar, 0, 0, 0)]
        [TestCase("Kyton", 1, 1, 1)]
        [TestCase(CreatureConstants.Janni, 1, 1, 1)]
        [TestCase(CreatureConstants.Lamia, 1, 1, 1)]
        [TestCase(CreatureConstants.Lammasu, 1, 1, 1)]
        [TestCase("Lantern archon", 0, 0, 0)]
        [TestCase("Lemure", 0, 0, 0)]
        [TestCase(CreatureConstants.Lich, 0, 0, 0)]
        [TestCase(CreatureConstants.Lillend, 1, 1, 1)]
        [TestCase(CreatureConstants.Lion_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Lizardfolk, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Lizard_Monitor, 0, 0, 0)]
        [TestCase(CreatureConstants.Magmin, 1, 1, 1)]
        [TestCase(CreatureConstants.Manticore, 1, 1, 1)]
        [TestCase("Marilith", 2, 1, 2)]
        [TestCase(CreatureConstants.Medusa, 2, 2, 2)]
        [TestCase(CreatureConstants.Mephit, 1, 1, 1)]
        [TestCase(CreatureConstants.Mimic, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.MindFlayer, 2, 2, 2)]
        [TestCase(CreatureConstants.Minotaur, 1, 1, 1)]
        [TestCase(CreatureConstants.Mohrg, 0, 0, 0)]
        [TestCase(CreatureConstants.Mummy, 1, 1, 1)]
        [TestCase(CreatureConstants.Naga_Dark, 1, 1, 1)]
        [TestCase(CreatureConstants.Naga_Guardian, 1, 1, 1)]
        [TestCase(CreatureConstants.Naga_Spirit, 1, 1, 1)]
        [TestCase(CreatureConstants.Naga_Water, 1, 1, 1)]
        [TestCase("Nalfeshnee", 2, 1, 2)]
        [TestCase(CreatureConstants.NightHag, 1, 1, 1)]
        [TestCase("Nightcrawler", 1, 1, 1)]
        [TestCase(CreatureConstants.Nightmare, 0, 0, 0)]
        [TestCase("Nightwalker", 1, 1, 1)]
        [TestCase("Nightwing", 1, 1, 1)]
        [TestCase(CreatureConstants.Ogre, 1, 1, 1)]
        [TestCase(CreatureConstants.OgreMage, 2, 2, 2)]
        [TestCase(CreatureConstants.Ooze_Gray, 0, 0, 0)]
        [TestCase(CreatureConstants.Ooze_OchreJelly, 0, 0, 0)]
        [TestCase(CreatureConstants.Orc, 1, 1, 1)]
        [TestCase("Osyluth", 1, 1, 1)]
        [TestCase(CreatureConstants.Otyugh, 1, 1, 1)]
        [TestCase(CreatureConstants.Owl, 0, 0, 0)]
        [TestCase(CreatureConstants.Owl_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Owlbear, 0, 0, 0)]
        [TestCase(CreatureConstants.PhantomFungus, 0, 0, 0)]
        [TestCase(CreatureConstants.PhaseSpider, 0, 0, 0)]
        [TestCase(CreatureConstants.Phasm, 1, 1, 1)]
        [TestCase("Pit fiend", 2, 1, 2)]
        [TestCase("Planetar", 0, 2, 1)]
        [TestCase(CreatureConstants.PrayingMantis_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.PurpleWorm, 0, TreasureConstants.FiftyPercent, 0)]
        [TestCase(CreatureConstants.Pyrohydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase("Quasit", 0, 0, 0)]
        [TestCase(CreatureConstants.Rast, 0, 0, 0)]
        [TestCase(CreatureConstants.Rat, 0, 0, 0)]
        [TestCase(CreatureConstants.Rat_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Ravid, 0, 0, 0)]
        [TestCase(CreatureConstants.Remorhaz, 0, 0, 0)]
        [TestCase(CreatureConstants.Retriever, 0, 0, 0)]
        [TestCase(CreatureConstants.Roper, 0, TreasureConstants.FiftyPercent, 0)]
        [TestCase(CreatureConstants.RustMonster, 0, 0, 0)]
        [TestCase(CreatureConstants.Salamander_Noble, 2, 2, 2)]
        [TestCase(CreatureConstants.Salamander_Average, 1, 1, 1)]
        [TestCase(CreatureConstants.Salamander_Flamebrother, 1, 1, 1)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.Shadow, 0, 0, 0)]
        [TestCase(CreatureConstants.ShadowMastiff, 0, 0, 0)]
        [TestCase(CreatureConstants.ShamblingMound, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.ShockerLizard, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Shrieker, 0, 0, 0)]
        [TestCase(CreatureConstants.Skeleton, 0, 0, 0)]
        [TestCase(CreatureConstants.Slaad_Death, 2, 2, 2)]
        [TestCase(CreatureConstants.Slaad_Green, 1, 1, 1)]
        [TestCase(CreatureConstants.Slaad_Blue, 1, 1, 1)]
        [TestCase(CreatureConstants.Slaad_Gray, 2, 2, 2)]
        [TestCase(CreatureConstants.Slaad_Red, 1, 1, 1)]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, 0, 0, 0)]
        [TestCase("Solar", 0, 2, 1)]
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
        [TestCase(CreatureConstants.Thoqqua, 0, 0, 0)]
        [TestCase(CreatureConstants.Tiger, 0, 0, 0)]
        [TestCase(CreatureConstants.Tiger_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Troglodyte, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Troll, 1, 1, 1)]
        [TestCase("Trumpet archon", 0, 2, 1)]
        [TestCase(CreatureConstants.UmberHulk, 1, 1, 1)]
        [TestCase(CreatureConstants.VampireSpawn, 1, 1, 1)]
        [TestCase(CreatureConstants.Vampire, 0, 0, 0)]
        [TestCase(CreatureConstants.Vargouille, 0, 0, 0)]
        [TestCase(CreatureConstants.VioletFungus, 0, 0, 0)]
        [TestCase("Vrock", 1, 1, 1)]
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
        [TestCase(CreatureConstants.Wolverine_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Worg, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Wraith, 0, 0, 0)]
        [TestCase(CreatureConstants.Wyvern, 1, 1, 1)]
        [TestCase(CreatureConstants.Xorn_Average, 0, 0, 0)]
        [TestCase(CreatureConstants.Xorn_Elder, 0, 0, 0)]
        [TestCase(CreatureConstants.Xorn_Minor, 0, 0, 0)]
        [TestCase(CreatureConstants.YethHound, 0, 0, 0)]
        [TestCase(CreatureConstants.Yrthak, 0, 0, 0)]
        [TestCase("Yuan-ti", 2, 2, 2)]
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
