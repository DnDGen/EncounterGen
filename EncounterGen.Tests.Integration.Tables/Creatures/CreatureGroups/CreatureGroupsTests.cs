﻿using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public abstract class CreatureGroupsTests : CollectionTests
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
                CreatureConstants.Aasimar,
                CreatureConstants.Aboleth,
                CreatureConstants.Adept_Doctor,
                CreatureConstants.Adept_Fortuneteller,
                CreatureConstants.Adept_Missionary,
                CreatureConstants.Adept_StreetPerformer,
                CreatureConstants.Angel,
                CreatureConstants.AnimatedObject,
                CreatureConstants.Ant_Giant,
                CreatureConstants.Ape,
                CreatureConstants.Archon,
                CreatureConstants.Aristocrat_Businessman,
                CreatureConstants.Aristocrat_Gentry,
                CreatureConstants.Aristocrat_Politician,
                CreatureConstants.Arrowhawk,
                CreatureConstants.Azer,
                CreatureConstants.Badger,
                CreatureConstants.Bard_Leader,
                CreatureConstants.Barghest,
                CreatureConstants.Bat,
                CreatureConstants.Bear,
                CreatureConstants.Bear_Brown,
                CreatureConstants.BlackPudding,
                CreatureConstants.Boar,
                CreatureConstants.Bugbear,
                CreatureConstants.CelestialCreature,
                CreatureConstants.Character,
                CreatureConstants.Character_Adventurer,
                CreatureConstants.Character_AnimalTrainer,
                CreatureConstants.Character_Doctor,
                CreatureConstants.Character_FamousEntertainer,
                CreatureConstants.Character_FamousPriest,
                CreatureConstants.Character_Hitman,
                CreatureConstants.Character_Hunter,
                CreatureConstants.Character_Merchant,
                CreatureConstants.Character_Minstrel,
                CreatureConstants.Character_Missionary,
                CreatureConstants.Character_RetiredAdventurer,
                CreatureConstants.Character_Scholar,
                CreatureConstants.Character_Sellsword,
                CreatureConstants.Character_StarStudent,
                CreatureConstants.Character_StreetPerformer,
                CreatureConstants.Character_Student,
                CreatureConstants.Character_Teacher,
                CreatureConstants.Character_WarHero,
                CreatureConstants.Centaur,
                CreatureConstants.Centipede_Monstrous,
                CreatureConstants.Cleric_Leader,
                CreatureConstants.Commoner_Beggar,
                CreatureConstants.Commoner_ConstructionWorker,
                CreatureConstants.Commoner_Farmer,
                CreatureConstants.Commoner_Herder,
                CreatureConstants.Commoner_Pilgrim,
                CreatureConstants.Commoner_Protestor,
                CreatureConstants.Commoner_Servant,
                CreatureConstants.Crocodile,
                CreatureConstants.Cryohydra,
                CreatureConstants.Demon,
                CreatureConstants.Derro,
                CreatureConstants.Devil,
                CreatureConstants.Dinosaur,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Djinni,
                CreatureConstants.Dog,
                CreatureConstants.DominatedCreature,
                CreatureConstants.Dragon_Black,
                CreatureConstants.Dragon_Blue,
                CreatureConstants.Dragon_Brass,
                CreatureConstants.Dragon_Bronze,
                CreatureConstants.Dragon_Copper,
                CreatureConstants.Dragon_Gold,
                CreatureConstants.Dragon_Green,
                CreatureConstants.Dragon_Red,
                CreatureConstants.Dragon_Silver,
                CreatureConstants.Dragon_White,
                CreatureConstants.Drow,
                CreatureConstants.Duergar,
                CreatureConstants.Dwarf,
                CreatureConstants.Eagle,
                CreatureConstants.Elemental_Air,
                CreatureConstants.Elemental_Earth,
                CreatureConstants.Elemental_Fire,
                CreatureConstants.Elemental_Water,
                CreatureConstants.Elf,
                CreatureConstants.Expert_Adviser,
                CreatureConstants.Expert_Architect,
                CreatureConstants.Expert_Artisan,
                CreatureConstants.FiendishCreature,
                CreatureConstants.Fighter_Captain,
                CreatureConstants.Fighter_Leader,
                CreatureConstants.Formian,
                CreatureConstants.Fungus,
                CreatureConstants.Genie,
                CreatureConstants.Ghost,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Storm,
                CreatureConstants.Gnoll,
                CreatureConstants.Gnome,
                CreatureConstants.Goblin,
                CreatureConstants.Golem,
                CreatureConstants.Grimlock,
                CreatureConstants.Hag,
                CreatureConstants.Halfling,
                CreatureConstants.Harpy,
                CreatureConstants.Hellwasp,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Horse,
                CreatureConstants.HoundArchon,
                CreatureConstants.Hydra,
                CreatureConstants.Inevitable,
                CreatureConstants.Kobold,
                CreatureConstants.Lammasu,
                CreatureConstants.Lich,
                CreatureConstants.Lion,
                CreatureConstants.Livestock,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Locust,
                CreatureConstants.Lycanthrope,
                CreatureConstants.Mephit,
                CreatureConstants.MindFlayer,
                CreatureConstants.Mummy,
                CreatureConstants.Naga,
                CreatureConstants.Nightmare,
                CreatureConstants.Nightshade,
                CreatureConstants.NPC,
                CreatureConstants.NPC_Traveler,
                CreatureConstants.Ogre,
                CreatureConstants.Orc,
                CreatureConstants.Owl,
                CreatureConstants.Paladin_Crusader,
                CreatureConstants.Pixie,
                CreatureConstants.Pony,
                CreatureConstants.Pyrohydra,
                CreatureConstants.Rat,
                CreatureConstants.Rogue_Pickpocket,
                CreatureConstants.Salamander,
                CreatureConstants.Satyr,
                CreatureConstants.Scorpion_Monstrous,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.Shadow,
                CreatureConstants.Skeleton,
                CreatureConstants.Slaad,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.Snake_Viper,
                CreatureConstants.Spider_Monstrous,
                CreatureConstants.Sprite,
                CreatureConstants.Svirfneblin,
                CreatureConstants.Tiefling,
                CreatureConstants.Tiger,
                CreatureConstants.Troll,
                CreatureConstants.Troglodyte,
                CreatureConstants.Unicorn,
                CreatureConstants.UmberHulk,
                CreatureConstants.Vampire,
                CreatureConstants.Warrior_Bandit,
                CreatureConstants.Warrior_Captain,
                CreatureConstants.Warrior_Guard,
                CreatureConstants.Warrior_Leader,
                CreatureConstants.Weasel,
                CreatureConstants.Wereboar,
                CreatureConstants.Werewolf,
                CreatureConstants.Wizard_FamousResearcher,
                CreatureConstants.Wolf,
                CreatureConstants.Wolverine,
                CreatureConstants.Wraith,
                CreatureConstants.Xorn,
                CreatureConstants.YuanTi,
                CreatureConstants.Zombie,
                CreatureConstants.Types.Aberration,
                CreatureConstants.Types.Animal,
                CreatureConstants.Types.Construct,
                CreatureConstants.Types.Dragon,
                CreatureConstants.Types.Elemental,
                CreatureConstants.Types.Fey,
                CreatureConstants.Types.Giant,
                CreatureConstants.Types.Humanoid,
                CreatureConstants.Types.MagicalBeast,
                CreatureConstants.Types.MonstrousHumanoid,
                CreatureConstants.Types.Ooze,
                CreatureConstants.Types.Outsider,
                CreatureConstants.Types.Plant,
                CreatureConstants.Types.Undead,
                CreatureConstants.Types.Vermin,
                EnvironmentConstants.Civilized,
                EnvironmentConstants.Desert,
                EnvironmentConstants.Dungeon,
                EnvironmentConstants.Forest,
                EnvironmentConstants.Hills,
                EnvironmentConstants.Marsh,
                EnvironmentConstants.Mountain,
                EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Cold,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Warm,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Dungeon,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Dungeon,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Dungeon,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains,
                EnvironmentConstants.TimesOfDay.Day,
                EnvironmentConstants.TimesOfDay.Night,
                GroupConstants.Land,
                GroupConstants.Magic,
                GroupConstants.RequiresSubtype,
                GroupConstants.UseSubtypeForTreasure,
                GroupConstants.Wilderness,
            };

            AssertEntriesAreComplete(entries);
        }
    }
}
