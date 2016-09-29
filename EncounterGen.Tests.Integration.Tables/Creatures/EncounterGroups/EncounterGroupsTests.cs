﻿using EncounterGen.Common;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;

namespace EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public abstract class EncounterGroupsTests : CollectionTests
    {
        [Inject]
        internal IEncounterCollectionSelector EncounterCollectionSelector { get; set; }
        [Inject]
        internal ICollectionSelector CollectionSelector { get; set; }

        protected override string tableName
        {
            get
            {
                return TableNameConstants.EncounterGroups;
            }
        }

        protected void AssertEncounterGroupEntriesAreComplete()
        {
            var entries = new[]
            {
                string.Empty,
                CreatureConstants.AasimarWarrior,
                CreatureConstants.Aboleth,
                CreatureConstants.Achaierai,
                CreatureConstants.Adept_Doctor,
                CreatureConstants.Adept_Fortuneteller,
                CreatureConstants.Adept_Missionary,
                CreatureConstants.Adept_StreetPerformer,
                CreatureConstants.Allip,
                CreatureConstants.Androsphinx,
                CreatureConstants.Angel,
                CreatureConstants.AnimatedObject,
                CreatureConstants.Ankheg,
                CreatureConstants.Annis,
                CreatureConstants.Ant_Giant,
                CreatureConstants.Ape,
                CreatureConstants.Aranea,
                CreatureConstants.Archon,
                CreatureConstants.Aristocrat_Businessman,
                CreatureConstants.Aristocrat_Gentry,
                CreatureConstants.Aristocrat_Politician,
                CreatureConstants.Arrowhawk,
                CreatureConstants.AssassinVine,
                CreatureConstants.Athach,
                CreatureConstants.Avoral,
                CreatureConstants.Azer,
                CreatureConstants.Baboon,
                CreatureConstants.Badger,
                CreatureConstants.Barbarian_CombatInstructor,
                CreatureConstants.Barbarian_WarHero,
                CreatureConstants.Bard_FamousEntertainer,
                CreatureConstants.Bard_StreetPerformer,
                CreatureConstants.Barghest,
                CreatureConstants.Basilisk,
                CreatureConstants.Bat,
                CreatureConstants.Bear_Black,
                CreatureConstants.Bear_Brown,
                CreatureConstants.Bear_Polar,
                CreatureConstants.Bee_Giant,
                CreatureConstants.Behir,
                CreatureConstants.Beholder,
                CreatureConstants.Belker,
                CreatureConstants.Bison,
                CreatureConstants.BlackPudding,
                CreatureConstants.BlinkDog,
                CreatureConstants.Boar,
                CreatureConstants.Bodak,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Bralani,
                CreatureConstants.Bugbear,
                CreatureConstants.Bulette,
                CreatureConstants.Camel,
                CreatureConstants.CarrionCrawler,
                CreatureConstants.Cat,
                CreatureConstants.CelestialCreature,
                CreatureConstants.Centaur,
                CreatureConstants.Centipede_Monstrous,
                CreatureConstants.ChaosBeast,
                CreatureConstants.Character,
                CreatureConstants.Character_RetiredAdventurer,
                CreatureConstants.Character_Sellsword,
                CreatureConstants.Cheetah,
                CreatureConstants.Chimera,
                CreatureConstants.Choker,
                CreatureConstants.Chuul,
                CreatureConstants.Cleric_Doctor,
                CreatureConstants.Cleric_FamousPriest,
                CreatureConstants.Cleric_WarHero,
                CreatureConstants.Cloaker,
                CreatureConstants.Cockatrice,
                CreatureConstants.Commoner_Beggar,
                CreatureConstants.Commoner_ConstructionWorker,
                CreatureConstants.Commoner_Farmer,
                CreatureConstants.Commoner_Herder,
                CreatureConstants.Commoner_Hunter,
                CreatureConstants.Commoner_Merchant,
                CreatureConstants.Commoner_Minstrel,
                CreatureConstants.Commoner_Pilgrim,
                CreatureConstants.Commoner_Protestor,
                CreatureConstants.Couatl,
                CreatureConstants.Criosphinx,
                CreatureConstants.Crocodile,
                CreatureConstants.Darkmantle,
                CreatureConstants.Deinonychus,
                CreatureConstants.Delver,
                CreatureConstants.Demon,
                CreatureConstants.Derro,
                CreatureConstants.Destrachan,
                CreatureConstants.Devil,
                CreatureConstants.Devourer,
                CreatureConstants.Digester,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Dog,
                CreatureConstants.Donkey,
                CreatureConstants.Doppelganger,
                CreatureConstants.Dragon_Black_Adult,
                CreatureConstants.Dragon_Black_Ancient,
                CreatureConstants.Dragon_Black_GreatWyrm,
                CreatureConstants.Dragon_Black_Juvenile,
                CreatureConstants.Dragon_Black_MatureAdult,
                CreatureConstants.Dragon_Black_Old,
                CreatureConstants.Dragon_Black_VeryOld,
                CreatureConstants.Dragon_Black_VeryYoung,
                CreatureConstants.Dragon_Black_Wyrm,
                CreatureConstants.Dragon_Black_Wyrmling,
                CreatureConstants.Dragon_Black_Young,
                CreatureConstants.Dragon_Black_YoungAdult,
                CreatureConstants.Dragon_Blue_Adult,
                CreatureConstants.Dragon_Blue_Ancient,
                CreatureConstants.Dragon_Blue_GreatWyrm,
                CreatureConstants.Dragon_Blue_Juvenile,
                CreatureConstants.Dragon_Blue_MatureAdult,
                CreatureConstants.Dragon_Blue_Old,
                CreatureConstants.Dragon_Blue_VeryOld,
                CreatureConstants.Dragon_Blue_VeryYoung,
                CreatureConstants.Dragon_Blue_Wyrm,
                CreatureConstants.Dragon_Blue_Wyrmling,
                CreatureConstants.Dragon_Blue_Young,
                CreatureConstants.Dragon_Blue_YoungAdult,
                CreatureConstants.Dragon_Brass_Adult,
                CreatureConstants.Dragon_Brass_Ancient,
                CreatureConstants.Dragon_Brass_GreatWyrm,
                CreatureConstants.Dragon_Brass_Juvenile,
                CreatureConstants.Dragon_Brass_MatureAdult,
                CreatureConstants.Dragon_Brass_Old,
                CreatureConstants.Dragon_Brass_VeryOld,
                CreatureConstants.Dragon_Brass_VeryYoung,
                CreatureConstants.Dragon_Brass_Wyrm,
                CreatureConstants.Dragon_Brass_Wyrmling,
                CreatureConstants.Dragon_Brass_Young,
                CreatureConstants.Dragon_Brass_YoungAdult,
                CreatureConstants.Dragon_Bronze_Adult,
                CreatureConstants.Dragon_Bronze_Ancient,
                CreatureConstants.Dragon_Bronze_GreatWyrm,
                CreatureConstants.Dragon_Bronze_Juvenile,
                CreatureConstants.Dragon_Bronze_MatureAdult,
                CreatureConstants.Dragon_Bronze_Old,
                CreatureConstants.Dragon_Bronze_VeryOld,
                CreatureConstants.Dragon_Bronze_VeryYoung,
                CreatureConstants.Dragon_Bronze_Wyrm,
                CreatureConstants.Dragon_Bronze_Wyrmling,
                CreatureConstants.Dragon_Bronze_Young,
                CreatureConstants.Dragon_Bronze_YoungAdult,
                CreatureConstants.Dragon_Copper_Adult,
                CreatureConstants.Dragon_Copper_Ancient,
                CreatureConstants.Dragon_Copper_GreatWyrm,
                CreatureConstants.Dragon_Copper_Juvenile,
                CreatureConstants.Dragon_Copper_MatureAdult,
                CreatureConstants.Dragon_Copper_Old,
                CreatureConstants.Dragon_Copper_VeryOld,
                CreatureConstants.Dragon_Copper_VeryYoung,
                CreatureConstants.Dragon_Copper_Wyrm,
                CreatureConstants.Dragon_Copper_Wyrmling,
                CreatureConstants.Dragon_Copper_Young,
                CreatureConstants.Dragon_Copper_YoungAdult,
                CreatureConstants.Dragon_Gold_Adult,
                CreatureConstants.Dragon_Gold_Ancient,
                CreatureConstants.Dragon_Gold_GreatWyrm,
                CreatureConstants.Dragon_Gold_Juvenile,
                CreatureConstants.Dragon_Gold_MatureAdult,
                CreatureConstants.Dragon_Gold_Old,
                CreatureConstants.Dragon_Gold_VeryOld,
                CreatureConstants.Dragon_Gold_VeryYoung,
                CreatureConstants.Dragon_Gold_Wyrm,
                CreatureConstants.Dragon_Gold_Wyrmling,
                CreatureConstants.Dragon_Gold_Young,
                CreatureConstants.Dragon_Gold_YoungAdult,
                CreatureConstants.Dragon_Green_Adult,
                CreatureConstants.Dragon_Green_Ancient,
                CreatureConstants.Dragon_Green_GreatWyrm,
                CreatureConstants.Dragon_Green_Juvenile,
                CreatureConstants.Dragon_Green_MatureAdult,
                CreatureConstants.Dragon_Green_Old,
                CreatureConstants.Dragon_Green_VeryOld,
                CreatureConstants.Dragon_Green_VeryYoung,
                CreatureConstants.Dragon_Green_Wyrm,
                CreatureConstants.Dragon_Green_Wyrmling,
                CreatureConstants.Dragon_Green_Young,
                CreatureConstants.Dragon_Green_YoungAdult,
                CreatureConstants.Dragon_Red_Adult,
                CreatureConstants.Dragon_Red_Ancient,
                CreatureConstants.Dragon_Red_GreatWyrm,
                CreatureConstants.Dragon_Red_Juvenile,
                CreatureConstants.Dragon_Red_MatureAdult,
                CreatureConstants.Dragon_Red_Old,
                CreatureConstants.Dragon_Red_VeryOld,
                CreatureConstants.Dragon_Red_VeryYoung,
                CreatureConstants.Dragon_Red_Wyrm,
                CreatureConstants.Dragon_Red_Wyrmling,
                CreatureConstants.Dragon_Red_Young,
                CreatureConstants.Dragon_Red_YoungAdult,
                CreatureConstants.Dragon_Silver_Adult,
                CreatureConstants.Dragon_Silver_Ancient,
                CreatureConstants.Dragon_Silver_GreatWyrm,
                CreatureConstants.Dragon_Silver_Juvenile,
                CreatureConstants.Dragon_Silver_MatureAdult,
                CreatureConstants.Dragon_Silver_Old,
                CreatureConstants.Dragon_Silver_VeryOld,
                CreatureConstants.Dragon_Silver_VeryYoung,
                CreatureConstants.Dragon_Silver_Wyrm,
                CreatureConstants.Dragon_Silver_Wyrmling,
                CreatureConstants.Dragon_Silver_Young,
                CreatureConstants.Dragon_Silver_YoungAdult,
                CreatureConstants.Dragon_White_Adult,
                CreatureConstants.Dragon_White_Ancient,
                CreatureConstants.Dragon_White_GreatWyrm,
                CreatureConstants.Dragon_White_Juvenile,
                CreatureConstants.Dragon_White_MatureAdult,
                CreatureConstants.Dragon_White_Old,
                CreatureConstants.Dragon_White_VeryOld,
                CreatureConstants.Dragon_White_VeryYoung,
                CreatureConstants.Dragon_White_Wyrm,
                CreatureConstants.Dragon_White_Wyrmling,
                CreatureConstants.Dragon_White_Young,
                CreatureConstants.Dragon_White_YoungAdult,
                CreatureConstants.DragonTurtle,
                CreatureConstants.Dragonne,
                CreatureConstants.Drider,
                CreatureConstants.DrowWarrior,
                CreatureConstants.Druid_AnimalTrainer,
                CreatureConstants.Druid_Doctor,
                CreatureConstants.Druid_FamousPriest,
                CreatureConstants.Dryad,
                CreatureConstants.DuergarWarrior,
                CreatureConstants.DwarfWarrior,
                CreatureConstants.Eagle,
                CreatureConstants.Elemental,
                CreatureConstants.Elephant,
                CreatureConstants.ElfWarrior,
                CreatureConstants.EtherealFilcher,
                CreatureConstants.EtherealMarauder,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.Expert_Artisan,
                CreatureConstants.FiendishCreature,
                CreatureConstants.Fighter_CombatInstructor,
                CreatureConstants.Fighter_Hitman,
                CreatureConstants.Fighter_WarHero,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.Formian,
                CreatureConstants.FrostWorm,
                CreatureConstants.Fungus,
                CreatureConstants.Gargoyle,
                CreatureConstants.GelatinousCube,
                CreatureConstants.Genie,
                CreatureConstants.Ghaele,
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
                CreatureConstants.Gnoll,
                CreatureConstants.GnomeWarrior,
                CreatureConstants.Goblin,
                CreatureConstants.Golem,
                CreatureConstants.Gorgon,
                CreatureConstants.GrayRender,
                CreatureConstants.GreenHag,
                CreatureConstants.Grick,
                CreatureConstants.Griffon,
                CreatureConstants.Grimlock,
                CreatureConstants.Gynosphinx,
                CreatureConstants.HalflingWarrior,
                CreatureConstants.Harpy,
                CreatureConstants.Hawk,
                CreatureConstants.HellHound,
                CreatureConstants.Hellwasp,
                CreatureConstants.Hieracosphinx,
                CreatureConstants.Hippogriff,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Homunculus,
                CreatureConstants.Horse,
                CreatureConstants.Howler,
                CreatureConstants.Hydra,
                CreatureConstants.Hyena,
                CreatureConstants.Inevitable,
                CreatureConstants.InvisibleStalker,
                CreatureConstants.Kobold,
                CreatureConstants.Krenshar,
                CreatureConstants.Lamia,
                CreatureConstants.Lammasu,
                CreatureConstants.Leonal,
                CreatureConstants.Leopard,
                CreatureConstants.Lich,
                CreatureConstants.Lillend,
                CreatureConstants.Lion,
                CreatureConstants.Lizard,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Locust,
                CreatureConstants.Magmin,
                CreatureConstants.Manticore,
                CreatureConstants.Medusa,
                CreatureConstants.Megaraptor,
                CreatureConstants.Mephit,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.Minotaur,
                CreatureConstants.Mohrg,
                CreatureConstants.Monk_CombatInstructor,
                CreatureConstants.Monk_Scholar,
                CreatureConstants.Monk_WarHero,
                CreatureConstants.Monkey,
                CreatureConstants.Mummy,
                CreatureConstants.Naga,
                CreatureConstants.NightHag,
                CreatureConstants.Nightmare,
                CreatureConstants.Nightshade,
                CreatureConstants.NPC,
                CreatureConstants.NPC_Traveler,
                CreatureConstants.Nymph,
                CreatureConstants.Ogre,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.Orc,
                CreatureConstants.Otyugh,
                CreatureConstants.Owl,
                CreatureConstants.Owlbear,
                CreatureConstants.Paladin_CombatInstructor,
                CreatureConstants.Paladin_Crusader,
                CreatureConstants.Paladin_WarHero,
                CreatureConstants.Pegasus,
                CreatureConstants.PhantomFungus,
                CreatureConstants.PhaseSpider,
                CreatureConstants.Phasm,
                CreatureConstants.Pony,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Pseudodragon,
                CreatureConstants.PurpleWorm,
                CreatureConstants.Rakshasa,
                CreatureConstants.Ranger_AnimalTrainer,
                CreatureConstants.Ranger_CombatInstructor,
                CreatureConstants.Ranger_Hitman,
                CreatureConstants.Ranger_WarHero,
                CreatureConstants.Rast,
                CreatureConstants.Rat,
                CreatureConstants.Raven,
                CreatureConstants.Ravid,
                CreatureConstants.RazorBoar,
                CreatureConstants.Remorhaz,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Roc,
                CreatureConstants.Rogue_Hitman,
                CreatureConstants.Rogue_Pickpocket,
                CreatureConstants.Rogue_StreetPerformer,
                CreatureConstants.Roper,
                CreatureConstants.RustMonster,
                CreatureConstants.Salamander,
                CreatureConstants.Satyr,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.Scorpion_Monstrous,
                CreatureConstants.SeaHag,
                CreatureConstants.Shadow,
                CreatureConstants.ShadowMastiff,
                CreatureConstants.ShamblingMound,
                CreatureConstants.ShieldGuardian,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Skeleton,
                CreatureConstants.Skum,
                CreatureConstants.Slaad,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.Snake_Viper,
                CreatureConstants.Sorcerer_FamousEntertainer,
                CreatureConstants.Sorcerer_StreetPerformer,
                CreatureConstants.Spectre,
                CreatureConstants.SpiderEater,
                CreatureConstants.Spider_Monstrous,
                CreatureConstants.Sprite,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.Stirge,
                CreatureConstants.SvirfneblinWarrior,
                CreatureConstants.Tarrasque,
                CreatureConstants.Tendriculos,
                CreatureConstants.Thoqqua,
                CreatureConstants.TieflingWarrior,
                CreatureConstants.Tiger,
                CreatureConstants.Titan,
                CreatureConstants.Toad,
                CreatureConstants.Treant,
                CreatureConstants.Triceratops,
                CreatureConstants.Troglodyte,
                CreatureConstants.Troll,
                CreatureConstants.Tyrannosaurus,
                CreatureConstants.UmberHulk,
                CreatureConstants.Unicorn,
                CreatureConstants.Vampire,
                CreatureConstants.Vargouille,
                CreatureConstants.Warrior_Bandit,
                CreatureConstants.Warrior_Patrol,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.Weasel,
                CreatureConstants.Wight,
                CreatureConstants.WillOWisp,
                CreatureConstants.WinterWolf,
                CreatureConstants.Wizard_FamousResearcher,
                CreatureConstants.Wizard_Scholar,
                CreatureConstants.Wolf,
                CreatureConstants.Wolverine,
                CreatureConstants.Wraith,
                CreatureConstants.Wyvern,
                CreatureConstants.Xill,
                CreatureConstants.Xorn,
                CreatureConstants.YethHound,
                CreatureConstants.Yrthak,
                CreatureConstants.YuanTi,
                CreatureConstants.Zombie,
            };

            AssertEntriesAreComplete(entries);
        }

        protected IEnumerable<string> GetCreaturesWithDescription(string encounter)
        {
            var typesAndAmounts = encounter.Split(',');
            var creatures = new List<string>();

            foreach (var typeAndAmount in typesAndAmounts)
            {
                var creature = typeAndAmount.Split('/', '[')[0];
                creatures.Add(creature);
            }

            return creatures;
        }

        protected string GetCreature(string creature)
        {
            var levelStart = creature.IndexOf('[');
            var descriptionStart = creature.IndexOf('(');

            if (levelStart == -1 && descriptionStart == -1)
                return creature;

            var creatureLength = creature.Length;

            if (descriptionStart > -1)
            {
                creatureLength = descriptionStart - 1;
            }
            else if (levelStart > -1)
            {
                creatureLength = levelStart;
            }

            return creature.Substring(0, creatureLength);
        }

        protected IEnumerable<string> GetEncountersFromCreatureGroup(string creatureGroup)
        {
            return CollectionSelector.ExplodeInto(TableNameConstants.CreatureGroups, creatureGroup, TableNameConstants.EncounterGroups);
        }
    }
}
