﻿using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public abstract class CreatureGroupsTableTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.CreatureGroups;
            }
        }

        protected void AssertCreatureGroupEntriesAreComplete()
        {
            var entries = new[]
            {
                string.Empty,
                CreatureDataConstants.Aasimar,
                CreatureDataConstants.Aboleth,
                CreatureDataConstants.Adept_Doctor,
                CreatureDataConstants.Adept_Fortuneteller,
                CreatureDataConstants.Adept_Missionary,
                CreatureDataConstants.Adept_StreetPerformer,
                CreatureDataConstants.Angel,
                CreatureDataConstants.AnimatedObject,
                CreatureDataConstants.Ant_Giant,
                CreatureDataConstants.Ape,
                CreatureDataConstants.Archon,
                CreatureDataConstants.Aristocrat_Businessman,
                CreatureDataConstants.Aristocrat_Gentry,
                CreatureDataConstants.Aristocrat_Politician,
                CreatureDataConstants.Arrowhawk,
                CreatureDataConstants.Azer,
                CreatureDataConstants.Badger,
                CreatureDataConstants.Bard_Leader,
                CreatureDataConstants.Barghest,
                CreatureDataConstants.Bat,
                CreatureDataConstants.Bear,
                CreatureDataConstants.Bear_Brown,
                CreatureDataConstants.BlackPudding,
                CreatureDataConstants.Boar,
                CreatureDataConstants.Bugbear,
                CreatureDataConstants.CelestialCreature,
                CreatureDataConstants.Character,
                CreatureDataConstants.Character_Adventurer,
                CreatureDataConstants.Character_AnimalTrainer,
                CreatureDataConstants.Character_Doctor,
                CreatureDataConstants.Character_FamousEntertainer,
                CreatureDataConstants.Character_FamousPriest,
                CreatureDataConstants.Character_Hitman,
                CreatureDataConstants.Character_Hunter,
                CreatureDataConstants.Character_Merchant,
                CreatureDataConstants.Character_Minstrel,
                CreatureDataConstants.Character_Missionary,
                CreatureDataConstants.Character_RetiredAdventurer,
                CreatureDataConstants.Character_Scholar,
                CreatureDataConstants.Character_Sellsword,
                CreatureDataConstants.Character_StarStudent,
                CreatureDataConstants.Character_StreetPerformer,
                CreatureDataConstants.Character_Student,
                CreatureDataConstants.Character_Teacher,
                CreatureDataConstants.Character_WarHero,
                CreatureDataConstants.Centaur,
                CreatureDataConstants.Centipede_Monstrous,
                CreatureDataConstants.Cleric_Leader,
                CreatureDataConstants.Commoner_Beggar,
                CreatureDataConstants.Commoner_ConstructionWorker,
                CreatureDataConstants.Commoner_Farmer,
                CreatureDataConstants.Commoner_Herder,
                CreatureDataConstants.Commoner_Pilgrim,
                CreatureDataConstants.Commoner_Protestor,
                CreatureDataConstants.Commoner_Servant,
                CreatureDataConstants.Crocodile,
                CreatureDataConstants.Cryohydra,
                CreatureDataConstants.Demon,
                CreatureDataConstants.Derro,
                CreatureDataConstants.Devil,
                CreatureDataConstants.Dinosaur,
                CreatureDataConstants.DisplacerBeast,
                CreatureDataConstants.Djinni,
                CreatureDataConstants.Dog,
                CreatureDataConstants.DominatedCreature,
                CreatureDataConstants.Dragon_Black,
                CreatureDataConstants.Dragon_Blue,
                CreatureDataConstants.Dragon_Brass,
                CreatureDataConstants.Dragon_Bronze,
                CreatureDataConstants.Dragon_Copper,
                CreatureDataConstants.Dragon_Gold,
                CreatureDataConstants.Dragon_Green,
                CreatureDataConstants.Dragon_Red,
                CreatureDataConstants.Dragon_Silver,
                CreatureDataConstants.Dragon_White,
                CreatureDataConstants.Drow,
                CreatureDataConstants.Duergar,
                CreatureDataConstants.Dwarf,
                CreatureDataConstants.Dwarf_Deep,
                CreatureDataConstants.Dwarf_Hill,
                CreatureDataConstants.Dwarf_Mountain,
                CreatureDataConstants.Eagle,
                CreatureDataConstants.Elemental_Air,
                CreatureDataConstants.Elemental_Earth,
                CreatureDataConstants.Elemental_Fire,
                CreatureDataConstants.Elemental_Water,
                CreatureDataConstants.Elf,
                CreatureDataConstants.Elf_Aquatic,
                CreatureDataConstants.Elf_Gray,
                CreatureDataConstants.Elf_Half,
                CreatureDataConstants.Elf_High,
                CreatureDataConstants.Elf_Wild,
                CreatureDataConstants.Elf_Wood,
                CreatureDataConstants.Expert_Adviser,
                CreatureDataConstants.Expert_Architect,
                CreatureDataConstants.Expert_Artisan,
                CreatureDataConstants.FiendishCreature,
                CreatureDataConstants.Fighter_Captain,
                CreatureDataConstants.Fighter_Leader,
                CreatureDataConstants.Formian,
                CreatureDataConstants.Fungus,
                CreatureDataConstants.Genie,
                CreatureDataConstants.Ghost,
                CreatureDataConstants.Ghoul,
                CreatureDataConstants.Giant_Cloud,
                CreatureDataConstants.Giant_Fire,
                CreatureDataConstants.Giant_Frost,
                CreatureDataConstants.Giant_Hill,
                CreatureDataConstants.Giant_Stone,
                CreatureDataConstants.Giant_Storm,
                CreatureDataConstants.Githyanki,
                CreatureDataConstants.Githzerai,
                CreatureDataConstants.Gnoll,
                CreatureDataConstants.Gnome,
                CreatureDataConstants.Gnome_Forest,
                CreatureDataConstants.Gnome_Rock,
                CreatureDataConstants.Goblin,
                CreatureDataConstants.Golem,
                CreatureDataConstants.Grimlock,
                CreatureDataConstants.Hag,
                CreatureDataConstants.Halfling,
                CreatureDataConstants.Halfling_Deep,
                CreatureDataConstants.Halfling_Lightfoot,
                CreatureDataConstants.Halfling_Tallfellow,
                CreatureDataConstants.Harpy,
                CreatureDataConstants.Hellwasp,
                CreatureDataConstants.Hobgoblin,
                CreatureDataConstants.Horse,
                CreatureDataConstants.HoundArchon,
                CreatureDataConstants.Hydra,
                CreatureDataConstants.Inevitable,
                CreatureDataConstants.Kobold,
                CreatureDataConstants.KuoToa,
                CreatureDataConstants.Lammasu,
                CreatureDataConstants.Lich,
                CreatureDataConstants.Lion,
                CreatureDataConstants.Livestock,
                CreatureDataConstants.Lizard,
                CreatureDataConstants.Lizardfolk,
                CreatureDataConstants.Locathah,
                CreatureDataConstants.Locust,
                CreatureDataConstants.Lycanthrope,
                CreatureDataConstants.Mephit,
                CreatureDataConstants.Merfolk,
                CreatureDataConstants.MindFlayer,
                CreatureDataConstants.Mummy,
                CreatureDataConstants.Naga,
                CreatureDataConstants.Nightmare,
                CreatureDataConstants.Nightshade,
                CreatureDataConstants.NPC,
                CreatureDataConstants.NPC_Traveler,
                CreatureDataConstants.Octopus,
                CreatureDataConstants.Ogre,
                CreatureDataConstants.Ogre_Merrow,
                CreatureDataConstants.Orc,
                CreatureDataConstants.Orc_Half,
                CreatureDataConstants.Owl,
                CreatureDataConstants.Paladin_Crusader,
                CreatureDataConstants.Pixie,
                CreatureDataConstants.Pony,
                CreatureDataConstants.Pyrohydra,
                CreatureDataConstants.Rat,
                CreatureDataConstants.Rogue_Pickpocket,
                CreatureDataConstants.Sahuagin,
                CreatureDataConstants.Salamander,
                CreatureDataConstants.Satyr,
                CreatureDataConstants.Scorpion_Monstrous,
                CreatureDataConstants.Scorpionfolk,
                CreatureDataConstants.Shadow,
                CreatureDataConstants.Shark,
                CreatureDataConstants.Skeleton,
                CreatureDataConstants.Slaad,
                CreatureDataConstants.Snake_Constrictor,
                CreatureDataConstants.Snake_Viper,
                CreatureDataConstants.Spider_Monstrous,
                CreatureDataConstants.Sprite,
                CreatureDataConstants.Squid,
                CreatureDataConstants.Svirfneblin,
                CreatureDataConstants.Tiefling,
                CreatureDataConstants.Tiger,
                CreatureDataConstants.Tojanida,
                CreatureDataConstants.Troll,
                CreatureDataConstants.Troll_Scrag,
                CreatureDataConstants.Troglodyte,
                CreatureDataConstants.Unicorn,
                CreatureDataConstants.UmberHulk,
                CreatureDataConstants.Vampire,
                CreatureDataConstants.Warrior_Bandit,
                CreatureDataConstants.Warrior_Captain,
                CreatureDataConstants.Warrior_Guard,
                CreatureDataConstants.Warrior_Leader,
                CreatureDataConstants.Weasel,
                CreatureDataConstants.Wereboar,
                CreatureDataConstants.Werewolf,
                CreatureDataConstants.Whale,
                CreatureDataConstants.Wizard_FamousResearcher,
                CreatureDataConstants.Wolf,
                CreatureDataConstants.Wolverine,
                CreatureDataConstants.Wraith,
                CreatureDataConstants.Xorn,
                CreatureDataConstants.YuanTi,
                CreatureDataConstants.Zombie,
                CreatureDataConstants.Types.Aberration,
                CreatureDataConstants.Types.Animal,
                CreatureDataConstants.Types.Construct,
                CreatureDataConstants.Types.Dragon,
                CreatureDataConstants.Types.Elemental,
                CreatureDataConstants.Types.Fey,
                CreatureDataConstants.Types.Giant,
                CreatureDataConstants.Types.Humanoid,
                CreatureDataConstants.Types.MagicalBeast,
                CreatureDataConstants.Types.MonstrousHumanoid,
                CreatureDataConstants.Types.Ooze,
                CreatureDataConstants.Types.Outsider,
                CreatureDataConstants.Types.Plant,
                CreatureDataConstants.Types.Undead,
                CreatureDataConstants.Types.Vermin,
                EnvironmentConstants.Aquatic,
                EnvironmentConstants.Underground,
                EnvironmentConstants.Any,
                EnvironmentConstants.Land,
                EnvironmentConstants.Civilized,
                EnvironmentConstants.Underground + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Underground,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Underground,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Underground,
                EnvironmentConstants.TimesOfDay.Day,
                EnvironmentConstants.TimesOfDay.Night,
                EnvironmentConstants.Plane_Air,
                EnvironmentConstants.Plane_Astral,
                EnvironmentConstants.Plane_Chaotic,
                EnvironmentConstants.Plane_ChaoticEvil,
                EnvironmentConstants.Plane_ChaoticGood,
                EnvironmentConstants.Plane_Earth,
                EnvironmentConstants.Plane_Ethereal,
                EnvironmentConstants.Plane_Evil,
                EnvironmentConstants.Plane_Fire,
                EnvironmentConstants.Plane_Good,
                EnvironmentConstants.Plane_Lawful,
                EnvironmentConstants.Plane_LawfulEvil,
                EnvironmentConstants.Plane_LawfulGood,
                EnvironmentConstants.Plane_Limbo,
                EnvironmentConstants.Plane_NeutralEvil,
                EnvironmentConstants.Plane_PositiveEnergy,
                EnvironmentConstants.Plane_Shadow,
                EnvironmentConstants.Plane_Water,
                GroupConstants.Extraplanar,
                GroupConstants.RequiresSubtype,
                GroupConstants.UseSubtypeForTreasure,
                GroupConstants.Wilderness,
            };

            AssertEntriesAreComplete(entries);
        }

        protected IEnumerable<string> GetAllCreatures()
        {
            //INFO: Currently, night contains all creatures and acts as an "all" group
            return ExplodeCollection(EnvironmentConstants.TimesOfDay.Night);
        }
    }
}
