using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class EnvironmentCreatureGroupsTests : CreatureGroupsTableTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [TestCase(EnvironmentConstants.Aquatic,
            CreatureDataConstants.Gargoyle_Kapoacinth,
            CreatureDataConstants.Ghoul_Lacedon)]
        [TestCase(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic,
            CreatureDataConstants.Aboleth,
            CreatureDataConstants.Skum)]
        [TestCase(EnvironmentConstants.Civilized,
            CreatureDataConstants.Cat,
            CreatureDataConstants.Character,
            CreatureDataConstants.Dog,
            CreatureDataConstants.NPC_Traveler,
            CreatureDataConstants.Donkey,
            CreatureDataConstants.Horse,
            CreatureDataConstants.Livestock,
            CreatureDataConstants.Mule,
            CreatureDataConstants.Pony)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic,
            CreatureDataConstants.Shark,
            CreatureDataConstants.Troll_Scrag,
            CreatureDataConstants.Whale_Orca)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert,
            CreatureDataConstants.Remorhaz)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest,
            CreatureDataConstants.Bear_Brown,
            CreatureDataConstants.WinterWolf,
            CreatureDataConstants.Wolverine)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills,
            CreatureDataConstants.Beholder,
            CreatureDataConstants.Ettin,
            CreatureDataConstants.Skeleton_Ettin,
            CreatureDataConstants.OgreMage)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh,
            CreatureDataConstants.Annis,
            CreatureDataConstants.Cryohydra,
            CreatureDataConstants.Ooze_Gray)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain,
            CreatureDataConstants.Dragon_White,
            CreatureDataConstants.Skeleton_Troll,
            CreatureDataConstants.Giant_Frost,
            CreatureDataConstants.Troll)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains,
            CreatureDataConstants.Bear_Polar,
            CreatureDataConstants.FrostWorm)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic,
            CreatureDataConstants.DragonTurtle,
            CreatureDataConstants.Elf_Aquatic,
            CreatureDataConstants.Kraken,
            CreatureDataConstants.KuoToa,
            CreatureDataConstants.Merfolk,
            CreatureDataConstants.Naga_Water,
            CreatureDataConstants.Nixie,
            CreatureDataConstants.Ogre_Merrow,
            CreatureDataConstants.Porpoise,
            CreatureDataConstants.SeaCat,
            CreatureDataConstants.SeaHag,
            CreatureDataConstants.Squid,
            CreatureDataConstants.Triton,
            CreatureDataConstants.Whale_Cachalot)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
            CreatureDataConstants.Bat,
            CreatureDataConstants.Dragon_Blue,
            CreatureDataConstants.Dragonne,
            CreatureDataConstants.Donkey,
            CreatureDataConstants.Lamia,
            CreatureDataConstants.Lammasu)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic,
            CreatureDataConstants.Elasmosaurus,
            CreatureDataConstants.Locathah,
            CreatureDataConstants.MantaRay,
            CreatureDataConstants.Octopus,
            CreatureDataConstants.Sahuagin,
            CreatureDataConstants.Whale_Baleen)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Plane_Air,
            CreatureDataConstants.Arrowhawk,
            CreatureDataConstants.Belker,
            CreatureDataConstants.Djinni,
            CreatureDataConstants.Elemental_Air,
            CreatureDataConstants.InvisibleStalker,
            CreatureDataConstants.Mephit_Air,
            CreatureDataConstants.Mephit_Dust,
            CreatureDataConstants.Mephit_Ice)]
        [TestCase(EnvironmentConstants.Plane_Astral,
            CreatureDataConstants.Githyanki)]
        [TestCase(EnvironmentConstants.Plane_Chaotic,
            CreatureDataConstants.Howler,
            CreatureDataConstants.Lillend)]
        [TestCase(EnvironmentConstants.Plane_ChaoticEvil,
            CreatureDataConstants.Demon,
            CreatureDataConstants.Basilisk_AbyssalGreater,
            CreatureDataConstants.Bodak)]
        [TestCase(EnvironmentConstants.Plane_ChaoticGood,
            CreatureDataConstants.Bralani,
            CreatureDataConstants.Ghaele,
            CreatureDataConstants.Titan,
            CreatureDataConstants.Unicorn_CelestialCharger)]
        [TestCase(EnvironmentConstants.Plane_Earth,
            CreatureDataConstants.Xorn,
            CreatureDataConstants.Elemental_Earth,
            CreatureDataConstants.Mephit_Earth,
            CreatureDataConstants.Mephit_Salt)]
        [TestCase(EnvironmentConstants.Plane_Ethereal,
            CreatureDataConstants.EtherealMarauder,
            CreatureDataConstants.Xill)]
        [TestCase(EnvironmentConstants.Plane_Evil,
            CreatureDataConstants.FiendishCreature,
            CreatureDataConstants.Barghest,
            CreatureDataConstants.Hellwasp,
            CreatureDataConstants.NightHag,
            CreatureDataConstants.Nightmare,
            CreatureDataConstants.YethHound,
            CreatureDataConstants.Vargouille)]
        [TestCase(EnvironmentConstants.Plane_Fire,
            CreatureDataConstants.Azer,
            CreatureDataConstants.Elemental_Fire,
            CreatureDataConstants.Salamander,
            CreatureDataConstants.Efreeti,
            CreatureDataConstants.Magmin,
            CreatureDataConstants.Mephit_Fire,
            CreatureDataConstants.Mephit_Magma,
            CreatureDataConstants.Mephit_Steam,
            CreatureDataConstants.Rast,
            CreatureDataConstants.Thoqqua)]
        [TestCase(EnvironmentConstants.Plane_Good,
            CreatureDataConstants.Angel,
            CreatureDataConstants.Avoral,
            CreatureDataConstants.CelestialCreature,
            CreatureDataConstants.Leonal)]
        [TestCase(EnvironmentConstants.Plane_Lawful,
            CreatureDataConstants.Achaierai,
            CreatureDataConstants.Formian,
            CreatureDataConstants.Inevitable)]
        [TestCase(EnvironmentConstants.Plane_LawfulEvil,
            CreatureDataConstants.Devil,
            CreatureDataConstants.HellHound,
            CreatureDataConstants.NessianWarhound)]
        [TestCase(EnvironmentConstants.Plane_LawfulGood,
            CreatureDataConstants.Archon,
            CreatureDataConstants.Lammasu_GoldenProtector)]
        [TestCase(EnvironmentConstants.Plane_Limbo,
            CreatureDataConstants.ChaosBeast,
            CreatureDataConstants.Githzerai,
            CreatureDataConstants.Slaad)]
        [TestCase(EnvironmentConstants.Plane_NeutralEvil,
            CreatureDataConstants.Nightmare_Cauchemar)]
        [TestCase(EnvironmentConstants.Plane_PositiveEnergy,
            CreatureDataConstants.Ravid)]
        [TestCase(EnvironmentConstants.Plane_Shadow,
            CreatureDataConstants.Nightshade,
            CreatureDataConstants.ShadowMastiff)]
        [TestCase(EnvironmentConstants.Plane_Water,
            CreatureDataConstants.Tojanida,
            CreatureDataConstants.Elemental_Water,
            CreatureDataConstants.Mephit_Ooze,
            CreatureDataConstants.Mephit_Water)]
        [TestCase(GroupConstants.Extraplanar,
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
            EnvironmentConstants.Plane_Water)]
        public void EnvironmentCreatures(string environment, params string[] creatures)
        {
            base.DistinctCollection(environment, creatures);
        }

        [Test]
        public void AnyCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Allip,
                CreatureDataConstants.AnimatedObject,
                CreatureDataConstants.Mummy,
                CreatureDataConstants.Lich,
                CreatureDataConstants.Ghost,
                CreatureDataConstants.Vampire,
                CreatureDataConstants.Devourer,
                CreatureDataConstants.Doppelganger,
                CreatureDataConstants.Skeleton,
                CreatureDataConstants.Gargoyle,
                CreatureDataConstants.Ghoul,
                CreatureDataConstants.Golem,
                CreatureDataConstants.Homunculus,
                CreatureDataConstants.Mohrg,
                CreatureDataConstants.Shadow,
                CreatureDataConstants.ShieldGuardian,
                CreatureDataConstants.Tarrasque,
                CreatureDataConstants.Wight,
                CreatureDataConstants.Wraith,
                CreatureDataConstants.Zombie_Human,
            };

            base.DistinctCollection(EnvironmentConstants.Any, creatures);
        }

        [Test]
        public void LandCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Character_Adventurer,
                CreatureDataConstants.Character_Hunter,
                CreatureDataConstants.Commoner_Farmer,
                CreatureDataConstants.Commoner_Herder,
                CreatureDataConstants.Commoner_Pilgrim,
                CreatureDataConstants.Doppelganger,
                CreatureDataConstants.Gargoyle,
                CreatureDataConstants.NPC_Traveler,
                CreatureDataConstants.Rat,
                CreatureDataConstants.Warrior_Bandit,
                CreatureDataConstants.Character_AnimalTrainer,
                CreatureDataConstants.Fighter_Captain,
                CreatureDataConstants.Warrior_Captain,
                CreatureDataConstants.Paladin_Crusader,
                CreatureDataConstants.Character_FamousEntertainer,
                CreatureDataConstants.Character_FamousPriest,
                CreatureDataConstants.Wizard_FamousResearcher,
                CreatureDataConstants.Adept_Fortuneteller,
                CreatureDataConstants.Warrior_Guard,
                CreatureDataConstants.Character_Hitman,
                CreatureDataConstants.Bard_Leader,
                CreatureDataConstants.Cleric_Leader,
                CreatureDataConstants.Fighter_Leader,
                CreatureDataConstants.Warrior_Leader,
                CreatureDataConstants.Character_Merchant,
                CreatureDataConstants.Character_Minstrel,
                CreatureDataConstants.Adept_Missionary,
                CreatureDataConstants.Character_Missionary,
                CreatureDataConstants.Rogue_Pickpocket,
                CreatureDataConstants.Character_RetiredAdventurer,
                CreatureDataConstants.Character_Scholar,
                CreatureDataConstants.Character_Sellsword,
                CreatureDataConstants.Character_StarStudent,
                CreatureDataConstants.Character_Student,
                CreatureDataConstants.Character_Teacher,
                CreatureDataConstants.Character_WarHero,
                CreatureDataConstants.NPC,
                CreatureDataConstants.Livestock,
                CreatureDataConstants.Spectre,
                CreatureDataConstants.Zombie,
            };

            base.DistinctCollection(EnvironmentConstants.Land, creatures);
        }

        [Test]
        public void UndergroundCreatures()
        {
            var encounters = new[]
            {
                CreatureDataConstants.BlackPudding,
                CreatureDataConstants.CarrionCrawler,
                CreatureDataConstants.Centipede_Monstrous,
                CreatureDataConstants.Centipede_Swarm,
                CreatureDataConstants.Choker,
                CreatureDataConstants.Cloaker,
                CreatureDataConstants.Darkmantle,
                CreatureDataConstants.Delver,
                CreatureDataConstants.Derro,
                CreatureDataConstants.Destrachan,
                CreatureDataConstants.Drider,
                CreatureDataConstants.Drow,
                CreatureDataConstants.Duergar,
                CreatureDataConstants.Dwarf_Deep,
                CreatureDataConstants.EtherealFilcher,
                CreatureDataConstants.Fungus,
                CreatureDataConstants.GelatinousCube,
                CreatureDataConstants.GibberingMouther,
                CreatureDataConstants.Grick,
                CreatureDataConstants.Grimlock,
                CreatureDataConstants.Mimic,
                CreatureDataConstants.MindFlayer,
                CreatureDataConstants.Minotaur,
                CreatureDataConstants.Otyugh,
                CreatureDataConstants.PhantomFungus,
                CreatureDataConstants.Phasm,
                CreatureDataConstants.PurpleWorm,
                CreatureDataConstants.Roper,
                CreatureDataConstants.RustMonster,
                CreatureDataConstants.Skum,
                CreatureDataConstants.Svirfneblin,
                CreatureDataConstants.Troglodyte,
                CreatureDataConstants.UmberHulk,
                CreatureDataConstants.Spectre,
                CreatureDataConstants.Zombie,
            };

            base.DistinctCollection(EnvironmentConstants.Underground, encounters);
        }

        [Test]
        public void TemperateForestCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Aranea,
                CreatureDataConstants.AssassinVine,
                CreatureDataConstants.Badger,
                CreatureDataConstants.Bear_Black,
                CreatureDataConstants.Boar,
                CreatureDataConstants.Centaur,
                CreatureDataConstants.Dragon_Green,
                CreatureDataConstants.Dryad,
                CreatureDataConstants.Elf_High,
                CreatureDataConstants.Elf_Half,
                CreatureDataConstants.Elf_Wood,
                CreatureDataConstants.Gnome_Forest,
                CreatureDataConstants.Grig,
                CreatureDataConstants.Halfling_Tallfellow,
                CreatureDataConstants.Hawk,
                CreatureDataConstants.Kobold,
                CreatureDataConstants.Zombie_Kobold,
                CreatureDataConstants.Krenshar,
                CreatureDataConstants.Nymph,
                CreatureDataConstants.Owl,
                CreatureDataConstants.Owlbear,
                CreatureDataConstants.Skeleton_Owlbear,
                CreatureDataConstants.Pegasus,
                CreatureDataConstants.Pixie,
                CreatureDataConstants.PrayingMantis_Giant,
                CreatureDataConstants.Pseudodragon,
                CreatureDataConstants.Raven,
                CreatureDataConstants.RazorBoar,
                CreatureDataConstants.Satyr,
                CreatureDataConstants.Spider_Monstrous,
                CreatureDataConstants.SpiderEater,
                CreatureDataConstants.StagBeetle_Giant,
                CreatureDataConstants.Tendriculos,
                CreatureDataConstants.Treant,
                CreatureDataConstants.Unicorn,
                CreatureDataConstants.Wasp_Giant,
                CreatureDataConstants.Wolf,
                CreatureDataConstants.Skeleton_Wolf,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void TemperateHillsCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Athach,
                CreatureDataConstants.Bulette,
                CreatureDataConstants.Chimera,
                CreatureDataConstants.Skeleton_Chimera,
                CreatureDataConstants.DisplacerBeast,
                CreatureDataConstants.Dragon_Bronze,
                CreatureDataConstants.Giant_Hill,
                CreatureDataConstants.Wereboar_HillGiantDire,
                CreatureDataConstants.Gnome_Rock,
                CreatureDataConstants.Griffon,
                CreatureDataConstants.Hippogriff,
                CreatureDataConstants.Naga_Dark,
                CreatureDataConstants.Ogre,
                CreatureDataConstants.Zombie_Ogre,
                CreatureDataConstants.Orc,
                CreatureDataConstants.Orc_Half,
                CreatureDataConstants.Weasel,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills, creatures);
        }

        [Test]
        public void TemperateMarshCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Chuul,
                CreatureDataConstants.GrayRender,
                CreatureDataConstants.Zombie_GrayRender,
                CreatureDataConstants.GreenHag,
                CreatureDataConstants.Harpy,
                CreatureDataConstants.Hydra,
                CreatureDataConstants.Lizardfolk,
                CreatureDataConstants.Medusa,
                CreatureDataConstants.Naga_Spirit,
                CreatureDataConstants.Ooze_OchreJelly,
                CreatureDataConstants.ShamblingMound,
                CreatureDataConstants.Snake_Viper,
                CreatureDataConstants.Toad,
                CreatureDataConstants.WillOWisp,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void TemperateMountainCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Bugbear,
                CreatureDataConstants.Zombie_Bugbear,
                CreatureDataConstants.Dragon_Silver,
                CreatureDataConstants.Dwarf_Hill,
                CreatureDataConstants.Dwarf_Mountain,
                CreatureDataConstants.Eagle,
                CreatureDataConstants.Elf_Gray,
                CreatureDataConstants.Giant_Cloud,
                CreatureDataConstants.Skeleton_Giant_Cloud,
                CreatureDataConstants.Giant_Stone,
                CreatureDataConstants.RazorBoar,
                CreatureDataConstants.Yrthak,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain, creatures);
        }

        [Test]
        public void TemperatePlainsCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Aasimar,
                CreatureDataConstants.Ant_Giant,
                CreatureDataConstants.Bee_Giant,
                CreatureDataConstants.Bison,
                CreatureDataConstants.BlinkDog,
                CreatureDataConstants.Cat,
                CreatureDataConstants.Cockatrice,
                CreatureDataConstants.Dog,
                CreatureDataConstants.Goblin,
                CreatureDataConstants.Gorgon,
                CreatureDataConstants.Horse,
                CreatureDataConstants.Locust,
                CreatureDataConstants.Naga_Guardian,
                CreatureDataConstants.Pony,
                CreatureDataConstants.Tiefling,
                CreatureDataConstants.Triceratops,
                CreatureDataConstants.Worg,
                CreatureDataConstants.Orc_Half,
                CreatureDataConstants.Skeleton_Human,
                CreatureDataConstants.Human,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains, creatures);
        }

        [Test]
        public void WarmDesertCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Androsphinx,
                CreatureDataConstants.Basilisk,
                CreatureDataConstants.Camel,
                CreatureDataConstants.Criosphinx,
                CreatureDataConstants.Dragon_Brass,
                CreatureDataConstants.Gynosphinx,
                CreatureDataConstants.Hieracosphinx,
                CreatureDataConstants.Scorpion_Monstrous,
                CreatureDataConstants.Scorpionfolk,
                CreatureDataConstants.Hyena,
                CreatureDataConstants.Janni,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, creatures);
        }

        [Test]
        public void WarmForestCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Ape,
                CreatureDataConstants.BombardierBeetle_Giant,
                CreatureDataConstants.Couatl,
                CreatureDataConstants.Deinonychus,
                CreatureDataConstants.Digester,
                CreatureDataConstants.Elf_Wild,
                CreatureDataConstants.Ettercap,
                CreatureDataConstants.Girallon,
                CreatureDataConstants.Leopard,
                CreatureDataConstants.Lizard,
                CreatureDataConstants.Megaraptor,
                CreatureDataConstants.Skeleton_Megaraptor,
                CreatureDataConstants.Monkey,
                CreatureDataConstants.RazorBoar,
                CreatureDataConstants.Snake_Constrictor,
                CreatureDataConstants.Spider_Swarm,
                CreatureDataConstants.Tiger,
                CreatureDataConstants.YuanTi,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void WarmHillsCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Behir,
                CreatureDataConstants.Dragon_Copper,
                CreatureDataConstants.Halfling_Deep,
                CreatureDataConstants.Hobgoblin,
                CreatureDataConstants.PhaseSpider,
                CreatureDataConstants.Scorpionfolk,
                CreatureDataConstants.Wyvern,
                CreatureDataConstants.Zombie_Wyvern,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills, creatures);
        }

        [Test]
        public void WarmMarshCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Crocodile,
                CreatureDataConstants.Dragon_Black,
                CreatureDataConstants.Manticore,
                CreatureDataConstants.Pyrohydra,
                CreatureDataConstants.Rakshasa,
                CreatureDataConstants.ShockerLizard,
                CreatureDataConstants.Stirge,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void WarmMountainCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Dragon_Red,
                CreatureDataConstants.Skeleton_Dragon_Red_YoungAdult,
                CreatureDataConstants.Giant_Fire,
                CreatureDataConstants.Giant_Storm,
                CreatureDataConstants.Roc,
                CreatureDataConstants.RazorBoar,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain, creatures);
        }

        [Test]
        public void WarmPlainsCreatures()
        {
            var creatures = new[]
            {
                CreatureDataConstants.Ankheg,
                CreatureDataConstants.Baboon,
                CreatureDataConstants.Cheetah,
                CreatureDataConstants.Dragon_Gold,
                CreatureDataConstants.Elephant,
                CreatureDataConstants.FireBeetle_Giant,
                CreatureDataConstants.Gnoll,
                CreatureDataConstants.Halfling_Lightfoot,
                CreatureDataConstants.Lion,
                CreatureDataConstants.Rhinoceras,
                CreatureDataConstants.Scorpionfolk,
                CreatureDataConstants.Tyrannosaurus,
                CreatureDataConstants.Mule,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains, creatures);
        }

        [TestCase(CreatureDataConstants.Aboleth, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Aboleth_Mage, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Achaierai, EnvironmentConstants.Plane_Lawful)]
        [TestCase(CreatureDataConstants.Allip, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.AstralDeva, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.Planetar, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.Solar, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.AnimatedObject_Colossal, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.AnimatedObject_Gargantuan, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.AnimatedObject_Huge, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.AnimatedObject_Large, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.AnimatedObject_Medium, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.AnimatedObject_Small, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.AnimatedObject_Tiny, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ankheg, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Aranea, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.LanternArchon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(CreatureDataConstants.HoundArchon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(CreatureDataConstants.HoundArchon_Hero, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(CreatureDataConstants.TrumpetArchon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(CreatureDataConstants.Arrowhawk_Adult, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Arrowhawk_Elder, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Arrowhawk_Juvenile, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.AssassinVine, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Athach, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Avoral, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.Azer, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Barghest, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Barghest_Greater, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Basilisk, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Basilisk_AbyssalGreater, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Behir, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Belker, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.BlinkDog, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Bodak, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Bralani, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(CreatureDataConstants.Bugbear, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Bugbear_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Bugbear_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Bugbear_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Bulette, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Badger_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.Dog_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.FireBeetle_Giant_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.Monkey_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.Owl_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.Porpoise_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.Centaur, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Centaur_Leader_2ndTo5th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Centaur_Leader_5thTo9th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Centaur_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Centaur_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Centaur_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.ChaosBeast, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.Chimera, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Choker, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Chuul, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Cloaker, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Cockatrice, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Couatl, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Darkmantle, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Delver, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Babau, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Balor, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Bebilith, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Dretch, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Glabrezu, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Hezrou, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Marilith, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Nalfeshnee, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Quasit, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Retriever, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Succubus, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Vrock, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureDataConstants.Derro, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Derro_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Derro_Sorcerer_3rd, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Derro_Sorcerer_5thTo8th, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Destrachan, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.BarbedDevil_Hamatula, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.BeardedDevil_Barbazu, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.BoneDevil_Osyluth, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.ChainDevil_Kyton, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.Erinyes, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.Hellcat_Bezekira, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.HornedDevil_Cornugon, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.IceDevil_Gelugon, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.Imp, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.Lemure, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.PitFiend, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.Devourer, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Digester, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Deinonychus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elasmosaurus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Megaraptor, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Triceratops, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Tyrannosaurus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Ape_Dire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Badger_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Bat_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Bear_Dire, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Boar_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Lion_Dire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Rat_Dire, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rat_Dire_Fiendish, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Shark_Dire, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Tiger_Dire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Weasel_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Wolf_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Wolverine_Dire, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Doppelganger, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Dragon_Black_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Black_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Blue_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Brass_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Bronze_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Copper_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Gold_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dragon_Green_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Green_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dragon_Red_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Red_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_Silver_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_Adult, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_Ancient, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_GreatWyrm, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_Juvenile, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_MatureAdult, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_Old, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_VeryOld, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_VeryYoung, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_Wyrm, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_Wyrmling, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_Young, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dragon_White_YoungAdult, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.DragonTurtle, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Dragonne, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Drider, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Dryad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Hill_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Mountain_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Captain, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Leader, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Lieutenant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Dwarf_Deep_Warrior, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Duergar_Captain, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Duergar_Leader, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Duergar_Lieutenant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Duergar_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Duergar_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Duergar_Warrior, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Eagle_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Elemental_Air_Elder, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Elemental_Air_Greater, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Elemental_Air_Huge, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Elemental_Air_Large, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Elemental_Air_Medium, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Elemental_Air_Small, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Elder, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Greater, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Huge, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Large, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Medium, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.Elemental_Earth_Small, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Elder, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Greater, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Huge, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Large, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Medium, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Elemental_Fire_Small, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Elemental_Water_Elder, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Elemental_Water_Greater, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Elemental_Water_Huge, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Elemental_Water_Large, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Elemental_Water_Medium, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Elemental_Water_Small, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Elf_High_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_High_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_High_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_High_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_High_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_High_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Half_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Half_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Half_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Half_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Half_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Half_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Elf_Aquatic_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Elf_Gray_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Elf_Gray_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Elf_Gray_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Elf_Gray_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Elf_Gray_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Elf_Gray_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Elf_Wild_Captain, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wild_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wild_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wild_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wild_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wild_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wood_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wood_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wood_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wood_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wood_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Elf_Wood_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Drow_Captain, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Drow_Leader, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Drow_Lieutenant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Drow_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Drow_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Drow_Warrior, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.EtherealFilcher, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.EtherealMarauder, EnvironmentConstants.Plane_Ethereal)]
        [TestCase(CreatureDataConstants.Ettercap, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Ettin, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Fiendish_Colossal, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Fiendish_Gargantuan, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Fiendish_Huge, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Fiendish_Large, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Fiendish_Medium, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Raven_Fiendish, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.FormianMyrmarch, EnvironmentConstants.Plane_Lawful)]
        [TestCase(CreatureDataConstants.FormianQueen, EnvironmentConstants.Plane_Lawful)]
        [TestCase(CreatureDataConstants.FormianTaskmaster, EnvironmentConstants.Plane_Lawful)]
        [TestCase(CreatureDataConstants.FormianWarrior, EnvironmentConstants.Plane_Lawful)]
        [TestCase(CreatureDataConstants.FormianWorker, EnvironmentConstants.Plane_Lawful)]
        [TestCase(CreatureDataConstants.FrostWorm, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Shrieker, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.VioletFungus, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Gargoyle, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Gargoyle_Kapoacinth, EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Djinni, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Djinni_Noble, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Efreeti, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Janni, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Ghaele, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(CreatureDataConstants.Ghost_Level1, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level10, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level11, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level12, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level13, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level14, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level15, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level16, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level17, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level18, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level19, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level2, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level20, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level3, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level4, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level5, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level6, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level7, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level8, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghost_Level9, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghoul, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghoul_Ghast, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Ghoul_Lacedon, EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Giant_Cloud, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Cloud_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Cloud_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Fire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Fire_Adept_1stTo2nd, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Fire_Adept_3rdTo5th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Fire_Adept_6thTo7th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Fire_Cleric_1stTo2nd, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Fire_Leader_6thTo7th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Fire_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Fire_Sorcerer_3rdTo5th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Frost, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Frost_Adept_1stTo2nd, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Frost_Adept_3rdTo5th, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Frost_Adept_6thTo7th, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Frost_Cleric_1stTo2nd, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Frost_Jarl, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Frost_Leader_6thTo7th, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Frost_Noncombatant, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Frost_Sorcerer_3rdTo5th, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Hill, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Giant_Hill_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Giant_Stone, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Stone_Elder, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Stone_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Storm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Storm_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Giant_Storm_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.GibberingMouther, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Girallon, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Gnoll, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Gnoll_Leader_4thTo6th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Gnoll_Leader_6thTo8th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Gnoll_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Gnoll_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Gnoll_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Lieutenant_3rd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Lieutenant_5th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Gnome_Rock_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Lieutenant_3rd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Lieutenant_5th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Gnome_Forest_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Svirfneblin_Captain, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Svirfneblin_Leader, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Svirfneblin_Lieutenant_3rd, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Svirfneblin_Lieutenant_5th, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Svirfneblin_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Svirfneblin_Warrior, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Goblin_Leader_4thTo6th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Goblin_Leader_6thTo8th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Goblin_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Goblin_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Goblin_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Goblin_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Golem_Clay, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Golem_Flesh, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Golem_Iron, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Golem_Stone, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Golem_Stone_Greater, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Gorgon, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.GrayRender, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Grick, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Griffon, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Grimlock, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Grimlock_Leader, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Doctor_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_StreetPerformer_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Student_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Student_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Student_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Student_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Student_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Student_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Student_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Student_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Student_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Student_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Doctor_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Adept_StreetPerformer_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Businessman_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Gentry_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Aristocrat_Politician_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Beggar_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_ConstructionWorker_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Protestor_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Commoner_Servant_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Adviser_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Architect_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Expert_Artisan_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Livestock_Noncombatant, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level10, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level12, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level14, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level16, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level18, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level2, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level20, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level4, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level6, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level8, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level1, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level10To11, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level12To13, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level14To15, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level16To17, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level18To19, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level2To3, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level4To5, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level6To7, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level8To9, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Adventurer_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_AnimalTrainer_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousEntertainer_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_FamousPriest_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hitman_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Hunter_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Merchant_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Minstrel_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Missionary_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_RetiredAdventurer_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Scholar_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Sellsword_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_StarStudent_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Student_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Student_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Student_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Student_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Student_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Student_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Student_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Student_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Student_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Student_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_Teacher_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Character_WarHero_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Wizard_FamousResearcher_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Fortuneteller_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Adept_Missionary_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Bard_Leader_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Cleric_Leader_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Farmer_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Herder_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Commoner_Pilgrim_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Captain_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Fighter_Leader_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Livestock_Noncombatant, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.NPC_Traveler_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Paladin_Crusader_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level10, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level12, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level14, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level16, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level18, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level2, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level20, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level4, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level6, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level8, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Rogue_Pickpocket_Level9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Bandit_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Captain_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level1, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Guard_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level10To11, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level12To13, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level14To15, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level16To17, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level18To19, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level2To3, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level4To5, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level6To7, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Warrior_Leader_Level8To9, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Annis, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.GreenHag, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.SeaHag, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Captain, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Halfling_Lightfoot_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Captain, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Halfling_Deep_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Halfling_Tallfellow_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Harpy, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.HarpyArcher, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Human_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Human_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Human_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Human_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Human_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Human_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Hydra_10Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Hydra_11Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Hydra_12Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Hydra_5Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Hydra_6Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Hydra_7Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Hydra_8Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Hydra_9Heads, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Cryohydra_10Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Cryohydra_11Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Cryohydra_12Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Cryohydra_5Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Cryohydra_6Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Cryohydra_7Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Cryohydra_8Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Cryohydra_9Heads, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Pyrohydra_10Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Pyrohydra_11Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Pyrohydra_12Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Pyrohydra_5Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Pyrohydra_6Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Pyrohydra_7Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Pyrohydra_8Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Pyrohydra_9Heads, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Howler, EnvironmentConstants.Plane_Chaotic)]
        [TestCase(CreatureDataConstants.Homunculus, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Hobgoblin_Leader_4thTo6th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Hobgoblin_Leader_6thTo8th, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Hobgoblin_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Hobgoblin_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Hobgoblin_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Hobgoblin_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Hippogriff, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.HellHound, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.NessianWarhound, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureDataConstants.Kolyarut, EnvironmentConstants.Plane_Lawful)]
        [TestCase(CreatureDataConstants.Marut, EnvironmentConstants.Plane_Lawful)]
        [TestCase(CreatureDataConstants.Zelekhut, EnvironmentConstants.Plane_Lawful)]
        [TestCase(CreatureDataConstants.InvisibleStalker, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Kobold_Leader_4thTo6th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Kobold_Leader_6thTo8th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Kobold_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Kobold_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Kobold_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Kobold_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Kraken, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Krenshar, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Lamia, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Lammasu, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Lammasu_GoldenProtector, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(CreatureDataConstants.Leonal, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureDataConstants.Lich_Level11, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Lich_Level12, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Lich_Level13, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Lich_Level14, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Lich_Level15, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Lich_Level16, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Lich_Level17, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Lich_Level18, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Lich_Level19, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Lich_Level20, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Lillend, EnvironmentConstants.Plane_Chaotic)]
        [TestCase(CreatureDataConstants.Lizardfolk, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Lizardfolk_Leader_3rdTo6th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Lizardfolk_Leader_4thTo10th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Lizardfolk_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Lizardfolk_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Locathah_Captain, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Locathah_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Locathah_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Locathah_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Locathah_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Locathah_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Werebear, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Wereboar, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Wereboar_HillGiantDire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Wererat, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Weretiger, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Werewolf, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.WerewolfLord, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Magmin, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Manticore, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Medusa, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Mephit_Air, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Mephit_Dust, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Mephit_Earth, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.Mephit_Fire, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Mephit_Ice, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureDataConstants.Mephit_Magma, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Mephit_Ooze, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Mephit_Salt, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.Mephit_Steam, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Mephit_Water, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Merfolk_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Merfolk_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Merfolk_Lieutenant_3rd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Merfolk_Lieutenant_5th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Merfolk_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Merfolk_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Mimic, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Minotaur, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Mohrg, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Mummy, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.MummyLord, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Naga_Dark, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Naga_Guardian, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Naga_Spirit, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Naga_Water, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.NightHag, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Nightmare, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Nightmare_Cauchemar, EnvironmentConstants.Plane_NeutralEvil)]
        [TestCase(CreatureDataConstants.Nightcrawler, EnvironmentConstants.Plane_Shadow)]
        [TestCase(CreatureDataConstants.Nightwalker, EnvironmentConstants.Plane_Shadow)]
        [TestCase(CreatureDataConstants.Nightwing, EnvironmentConstants.Plane_Shadow)]
        [TestCase(CreatureDataConstants.Nymph, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Ogre, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Ogre_Barbarian, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Ogre_Merrow, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Ogre_Merrow_Barbarian, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.OgreMage, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.BlackPudding, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.BlackPudding_Elder, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.GelatinousCube, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Ooze_Gray, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Ooze_OchreJelly, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Orc_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Half_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Half_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Orc_Half_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Half_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Orc_Half_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Half_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Orc_Half_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Half_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Orc_Half_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Half_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Orc_Half_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Orc_Half_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Otyugh, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Owl_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Owlbear, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Pegasus, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.PhantomFungus, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.PhaseSpider, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Phasm, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Aasimar_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Tiefling_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Pseudodragon, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.PurpleWorm, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Rakshasa, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Rast, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Ravid, EnvironmentConstants.Plane_PositiveEnergy)]
        [TestCase(CreatureDataConstants.RazorBoar, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.RazorBoar, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.RazorBoar, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.RazorBoar, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Remorhaz, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Roc, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Roper, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.RustMonster, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.ShockerLizard, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.ShieldGuardian, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.ShamblingMound, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.ShadowMastiff, EnvironmentConstants.Plane_Shadow)]
        [TestCase(CreatureDataConstants.Shadow, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Shadow_Greater, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.SeaCat, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Scorpionfolk, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Scorpionfolk, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Scorpionfolk, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Satyr, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Satyr_WithPipes, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Salamander_Average, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Salamander_Flamebrother, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Salamander_Noble, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Sahuagin, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Sahuagin_Baron, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Sahuagin_Chieftan, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Sahuagin_Guard, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Sahuagin_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Sahuagin_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Sahuagin_Priest, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Sahuagin_Underpriest, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Skeleton_Chimera, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Skeleton_Chimera, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Skeleton_Dragon_Red_YoungAdult, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Skeleton_Dragon_Red_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Skeleton_Ettin, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Skeleton_Ettin, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Skeleton_Giant_Cloud, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Skeleton_Giant_Cloud, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Skeleton_Human, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Skeleton_Human, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Skeleton_Megaraptor, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Skeleton_Megaraptor, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Skeleton_Owlbear, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Skeleton_Owlbear, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Skeleton_Troll, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Skeleton_Troll, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Skeleton_Wolf, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Skeleton_Wolf, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Skum, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Spectre, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Spectre, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Androsphinx, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Criosphinx, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Gynosphinx, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Hieracosphinx, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.SpiderEater, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Grig, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Nixie, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Pixie, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Pixie_WithIrresistableDance, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Stirge, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Bat_Swarm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Centipede_Swarm, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Hellwasp_Swarm, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Locust_Swarm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Rat_Swarm, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Spider_Swarm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Tarrasque, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Tendriculos, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Thoqqua, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureDataConstants.Titan, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(CreatureDataConstants.Tojanida_Adult, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Tojanida_Elder, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Tojanida_Juvenile, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureDataConstants.Treant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Triton, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Troglodyte, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Troglodyte_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Troll, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Troll_Hunter, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Troll_Scrag, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Troll_Scrag_Hunter, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Unicorn, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Unicorn_CelestialCharger, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(CreatureDataConstants.Vampire_Level1, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level10, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level11, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level12, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level13, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level14, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level15, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level16, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level17, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level18, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level19, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level2, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level20, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level3, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level4, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level5, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level6, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level7, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level8, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vampire_Level9, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.VampireSpawn, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Vargouille, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Wight, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.WillOWisp, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.WinterWolf, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Worg, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Wraith, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Wraith_Dread, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Wyvern, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Xill, EnvironmentConstants.Plane_Ethereal)]
        [TestCase(CreatureDataConstants.Xorn_Average, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.Xorn_Elder, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.Xorn_Minor, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureDataConstants.YethHound, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureDataConstants.Yrthak, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Zombie_Kobold, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Zombie_Kobold, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Zombie_Kobold, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Zombie_Human, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Zombie_Human, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Zombie_Human, EnvironmentConstants.Any)]
        [TestCase(CreatureDataConstants.Zombie_Troglodyte, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Zombie_Troglodyte, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Zombie_Bugbear, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Zombie_Bugbear, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Zombie_Bugbear, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Zombie_Ogre, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Zombie_Ogre, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Zombie_Ogre, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Zombie_Minotaur, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Zombie_Minotaur, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Zombie_Wyvern, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Zombie_Wyvern, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Zombie_Wyvern, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Zombie_GrayRender, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Zombie_GrayRender, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Zombie_GrayRender, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Ape, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Baboon, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Badger, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Bat, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Bear_Black, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Bear_Brown, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Bear_Polar, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Bison, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Boar, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Camel, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Cat, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Cat, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Cheetah, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Crocodile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Crocodile_Giant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Dog, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dog, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Dog_Riding, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Dog_Riding, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Donkey, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Donkey, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Eagle, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureDataConstants.Elephant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Hawk, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Horse_Heavy, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Horse_Heavy, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Horse_Heavy_War, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Horse_Heavy_War, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Horse_Light, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Horse_Light, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Horse_Light_War, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Horse_Light_War, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Hyena, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Leopard, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Lion, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Lizard, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Lizard_Monitor, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.MantaRay, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Monkey, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Mule, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Mule, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Octopus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Octopus_Giant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Owl, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Pony, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Pony, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Pony_War, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Pony_War, EnvironmentConstants.Civilized)]
        [TestCase(CreatureDataConstants.Porpoise, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Rat, EnvironmentConstants.Land)]
        [TestCase(CreatureDataConstants.Raven, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Rhinoceras, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Shark_Medium, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Shark_Large, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Shark_Huge, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Snake_Constrictor, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Snake_Constrictor_Giant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Snake_Viper_Tiny, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Snake_Viper_Small, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Snake_Viper_Medium, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Snake_Viper_Large, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Snake_Viper_Huge, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Squid, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Squid_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Tiger, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Toad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureDataConstants.Weasel, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Whale_Baleen, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Whale_Cachalot, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Whale_Orca, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Wolf, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Wolverine, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Ant_Giant_Queen, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Ant_Giant_Soldier, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Ant_Giant_Worker, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.Bee_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.BombardierBeetle_Giant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.FireBeetle_Giant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureDataConstants.StagBeetle_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.PrayingMantis_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Wasp_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Colossal, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Gargantuan, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Huge, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Large, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Medium, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Small, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Centipede_Monstrous_Tiny, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Colossal, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Gargantuan, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Huge, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Large, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Medium, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Small, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Scorpion_Monstrous_Tiny, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Colossal, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Gargantuan, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Huge, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Large, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Medium, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Small, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Spider_Monstrous_Tiny, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.Beholder, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.CarrionCrawler, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.DisplacerBeast, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.DisplacerBeast_PackLord, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureDataConstants.Githyanki_Captain, EnvironmentConstants.Plane_Astral)]
        [TestCase(CreatureDataConstants.Githyanki_Fighter, EnvironmentConstants.Plane_Astral)]
        [TestCase(CreatureDataConstants.Githyanki_Lieutenant, EnvironmentConstants.Plane_Astral)]
        [TestCase(CreatureDataConstants.Githyanki_Sergeant, EnvironmentConstants.Plane_Astral)]
        [TestCase(CreatureDataConstants.Githyanki_SupremeLeader, EnvironmentConstants.Plane_Astral)]
        [TestCase(CreatureDataConstants.Githzerai_Master, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.Githzerai_Mentor, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.Githzerai_Sensei, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.Githzerai_Student, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.Githzerai_Teacher, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.MindFlayer, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.MindFlayer_Sorcerer, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.KuoToa, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.KuoToa_Fighter_10th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.KuoToa_Fighter_8th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.KuoToa_Monitor, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.KuoToa_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.KuoToa_Whip_10th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.KuoToa_Whip_3rd, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureDataConstants.Slaad_Blue, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.Slaad_Death, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.Slaad_Gray, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.Slaad_Green, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.Slaad_Red, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureDataConstants.UmberHulk, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.UmberHulk_TrulyHorrid, EnvironmentConstants.Underground)]
        [TestCase(CreatureDataConstants.YuanTi_Pureblood, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.YuanTi_Halfblood, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureDataConstants.YuanTi_Abomination, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        public void CreatureIsInCorrectEnvironment(string creature, string environment)
        {
            var creatures = collectionSelector.Explode(TableNameConstants.CreatureGroups, environment);
            Assert.That(creatures, Contains.Item(creature));
        }
    }
}
