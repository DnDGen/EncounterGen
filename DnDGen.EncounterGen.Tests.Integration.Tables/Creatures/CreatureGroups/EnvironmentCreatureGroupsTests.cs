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
            CreatureConstants.Gargoyle_Kapoacinth,
            CreatureConstants.Ghoul_Lacedon)]
        [TestCase(EnvironmentConstants.Underground + EnvironmentConstants.Aquatic,
            CreatureConstants.Aboleth,
            CreatureConstants.Skum)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic,
            CreatureConstants.Shark,
            CreatureConstants.Troll_Scrag,
            CreatureConstants.Whale_Orca)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized,
            CreatureConstants.Cat,
            CreatureConstants.Character,
            CreatureConstants.Dog)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert,
            CreatureConstants.Remorhaz)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest,
            CreatureConstants.Bear_Brown,
            CreatureConstants.WinterWolf,
            CreatureConstants.Wolverine)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills,
            CreatureConstants.Beholder,
            CreatureConstants.Ettin,
            CreatureConstants.OgreMage)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh,
            CreatureConstants.Annis,
            CreatureConstants.Cryohydra,
            CreatureConstants.Ooze_Gray)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain,
            CreatureConstants.Dragon_White,
            CreatureConstants.Giant_Frost,
            CreatureConstants.Troll)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains,
            CreatureConstants.Bear_Polar,
            CreatureConstants.FrostWorm)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic,
            CreatureConstants.DragonTurtle,
            CreatureConstants.Elf_Aquatic,
            CreatureConstants.Kraken,
            CreatureConstants.KuoToa,
            CreatureConstants.Merfolk,
            CreatureConstants.Naga_Water,
            CreatureConstants.Nixie,
            CreatureConstants.Ogre_Merrow,
            CreatureConstants.Porpoise,
            CreatureConstants.SeaCat,
            CreatureConstants.SeaHag,
            CreatureConstants.Squid,
            CreatureConstants.Triton,
            CreatureConstants.Whale_Cachalot)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized,
            CreatureConstants.Cat,
            CreatureConstants.Character,
            CreatureConstants.Dog)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
            CreatureConstants.Bat,
            CreatureConstants.Dragon_Blue,
            CreatureConstants.Dragonne,
            CreatureConstants.Donkey,
            CreatureConstants.Lamia,
            CreatureConstants.Lammasu)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Underground)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic,
            CreatureConstants.Elasmosaurus,
            CreatureConstants.Locathah,
            CreatureConstants.MantaRay,
            CreatureConstants.Octopus,
            CreatureConstants.Sahuagin,
            CreatureConstants.Whale_Baleen)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized,
            CreatureConstants.Cat,
            CreatureConstants.Character,
            CreatureConstants.Dog)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Underground)]
        [TestCase(GroupConstants.Extraplanar,
            EnvironmentConstants.Plane_Air,
            EnvironmentConstants.Plane_ChaoticEvil,
            EnvironmentConstants.Plane_ChaoticGood,
            EnvironmentConstants.Plane_Earth,
            EnvironmentConstants.Plane_Evil,
            EnvironmentConstants.Plane_Fire,
            EnvironmentConstants.Plane_Good,
            EnvironmentConstants.Plane_Lawful,
            EnvironmentConstants.Plane_LawfulEvil,
            EnvironmentConstants.Plane_LawfulGood,
            EnvironmentConstants.Plane_Limbo,
            EnvironmentConstants.Plane_Water)]
        public void EnvironmentCreatures(string environment, params string[] creatures)
        {
            base.DistinctCollection(environment, creatures);
        }

        [Test]
        public void LandCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Character_Adventurer,
                CreatureConstants.Character_Hunter,
                CreatureConstants.Commoner_Farmer,
                CreatureConstants.Commoner_Herder,
                CreatureConstants.Commoner_Pilgrim,
                CreatureConstants.Doppelganger,
                CreatureConstants.Gargoyle,
                CreatureConstants.NPC_Traveler,
                CreatureConstants.Rat,
                CreatureConstants.Tarrasque,
                CreatureConstants.Warrior_Bandit,
            };

            base.DistinctCollection(EnvironmentConstants.Land, creatures);
        }

        [Test]
        public void UndergroundCreatures()
        {
            var encounters = new[]
            {
                CreatureConstants.BlackPudding,
                CreatureConstants.CarrionCrawler,
                CreatureConstants.Centipede_Monstrous,
                CreatureConstants.Centipede_Swarm,
                CreatureConstants.Choker,
                CreatureConstants.Cloaker,
                CreatureConstants.Darkmantle,
                CreatureConstants.Delver,
                CreatureConstants.Derro,
                CreatureConstants.Destrachan,
                CreatureConstants.Drider,
                CreatureConstants.Drow,
                CreatureConstants.Duergar,
                CreatureConstants.Dwarf_Deep,
                CreatureConstants.EtherealFilcher,
                CreatureConstants.Fungus,
                CreatureConstants.GelatinousCube,
                CreatureConstants.GibberingMouther,
                CreatureConstants.Grick,
                CreatureConstants.Grimlock,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.Minotaur,
                CreatureConstants.Otyugh,
                CreatureConstants.PhantomFungus,
                CreatureConstants.Phasm,
                CreatureConstants.PurpleWorm,
                CreatureConstants.Roper,
                CreatureConstants.RustMonster,
                CreatureConstants.Skum,
                CreatureConstants.Svirfneblin,
                CreatureConstants.Troglodyte,
                CreatureConstants.UmberHulk,
            };

            base.DistinctCollection(EnvironmentConstants.Underground, encounters);
        }

        [Test]
        public void TemperateForestCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Aranea,
                CreatureConstants.AssassinVine,
                CreatureConstants.Badger,
                CreatureConstants.Bear_Black,
                CreatureConstants.Boar,
                CreatureConstants.Centaur,
                CreatureConstants.Dragon_Green,
                CreatureConstants.Dryad,
                CreatureConstants.Elf_High,
                CreatureConstants.Elf_Half,
                CreatureConstants.Elf_Wood,
                CreatureConstants.Gnome_Forest,
                CreatureConstants.Grig,
                CreatureConstants.Halfling_Tallfellow,
                CreatureConstants.Hawk,
                CreatureConstants.Kobold,
                CreatureConstants.Krenshar,
                CreatureConstants.Nymph,
                CreatureConstants.Owl,
                CreatureConstants.Owlbear,
                CreatureConstants.Pegasus,
                CreatureConstants.Pixie,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Pseudodragon,
                CreatureConstants.Raven,
                CreatureConstants.RazorBoar,
                CreatureConstants.Satyr,
                CreatureConstants.Spider_Monstrous,
                CreatureConstants.SpiderEater,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.Tendriculos,
                CreatureConstants.Treant,
                CreatureConstants.Unicorn,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.Wolf,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void TemperateHillsCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Athach,
                CreatureConstants.Bulette,
                CreatureConstants.Chimera,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Dragon_Bronze,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Wereboar_HillGiantDire,
                CreatureConstants.Gnome_Rock,
                CreatureConstants.Griffon,
                CreatureConstants.Hippogriff,
                CreatureConstants.Naga_Dark,
                CreatureConstants.Ogre,
                CreatureConstants.Orc,
                CreatureConstants.Orc_Half,
                CreatureConstants.Weasel,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills, creatures);
        }

        [Test]
        public void TemperateMarshCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Chuul,
                CreatureConstants.GrayRender,
                CreatureConstants.GreenHag,
                CreatureConstants.Harpy,
                CreatureConstants.Hydra,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Medusa,
                CreatureConstants.Naga_Spirit,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.ShamblingMound,
                CreatureConstants.Snake_Viper,
                CreatureConstants.Toad,
                CreatureConstants.WillOWisp,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void TemperateMountainCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Bugbear,
                CreatureConstants.Dragon_Silver,
                CreatureConstants.Dwarf_Hill,
                CreatureConstants.Dwarf_Mountain,
                CreatureConstants.Eagle,
                CreatureConstants.Elf_Gray,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Stone,
                CreatureConstants.RazorBoar,
                CreatureConstants.Yrthak,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain, creatures);
        }

        [Test]
        public void TemperatePlainsCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Aasimar,
                CreatureConstants.Ant_Giant,
                CreatureConstants.Bee_Giant,
                CreatureConstants.Bison,
                CreatureConstants.BlinkDog,
                CreatureConstants.Cat,
                CreatureConstants.Cockatrice,
                CreatureConstants.Dog,
                CreatureConstants.Goblin,
                CreatureConstants.Gorgon,
                CreatureConstants.Horse,
                CreatureConstants.Locust,
                CreatureConstants.Naga_Guardian,
                CreatureConstants.Pony,
                CreatureConstants.Tiefling,
                CreatureConstants.Triceratops,
                CreatureConstants.Worg,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains, creatures);
        }

        [Test]
        public void WarmDesertCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Androsphinx,
                CreatureConstants.Basilisk,
                CreatureConstants.Camel,
                CreatureConstants.Criosphinx,
                CreatureConstants.Dragon_Brass,
                CreatureConstants.Gynosphinx,
                CreatureConstants.Hieracosphinx,
                CreatureConstants.Scorpion_Monstrous,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.Hyena,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert, creatures);
        }

        [Test]
        public void WarmForestCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Ape,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Couatl,
                CreatureConstants.Deinonychus,
                CreatureConstants.Digester,
                CreatureConstants.Elf_Wild,
                CreatureConstants.Ettercap,
                CreatureConstants.Girallon,
                CreatureConstants.Leopard,
                CreatureConstants.Lizard,
                CreatureConstants.Megaraptor,
                CreatureConstants.Monkey,
                CreatureConstants.RazorBoar,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.Spider_Swarm,
                CreatureConstants.Tiger,
                CreatureConstants.YuanTi,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void WarmHillsCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Behir,
                CreatureConstants.Dragon_Copper,
                CreatureConstants.Halfling_Deep,
                CreatureConstants.Hobgoblin,
                CreatureConstants.PhaseSpider,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.Wyvern,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills, creatures);
        }

        [Test]
        public void WarmMarshCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Crocodile,
                CreatureConstants.Dragon_Black,
                CreatureConstants.Manticore,
                CreatureConstants.Pyrohydra,
                CreatureConstants.Rakshasa,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Stirge,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void WarmMountainCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Dragon_Red,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Giant_Storm,
                CreatureConstants.Roc,
                CreatureConstants.RazorBoar,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain, creatures);
        }

        [Test]
        public void WarmPlainsCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Ankheg,
                CreatureConstants.Baboon,
                CreatureConstants.Cheetah,
                CreatureConstants.Dragon_Gold,
                CreatureConstants.Elephant,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.Gnoll,
                CreatureConstants.Halfling_Lightfoot,
                CreatureConstants.Lion,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.Tyrannosaurus,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains, creatures);
        }

        [TestCase(CreatureConstants.Aboleth, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Aboleth_Mage, EnvironmentConstants.Underground + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Achaierai, EnvironmentConstants.Plane_Lawful)]
        [TestCase(CreatureConstants.Allip, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.Angel, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.AstralDeva, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.Planetar, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.Solar, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.AnimatedObject, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.AnimatedObject_Colossal, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.AnimatedObject_Gargantuan, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.AnimatedObject_Huge, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.AnimatedObject_Large, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.AnimatedObject_Medium, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.AnimatedObject_Small, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.AnimatedObject_Tiny, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.Ankheg, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Aranea, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Archon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(CreatureConstants.LanternArchon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(CreatureConstants.HoundArchon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(CreatureConstants.HoundArchon_Hero, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(CreatureConstants.TrumpetArchon, EnvironmentConstants.Plane_LawfulGood)]
        [TestCase(CreatureConstants.Arrowhawk, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.Arrowhawk_Adult, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.Arrowhawk_Elder, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.Arrowhawk_Juvenile, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.AssassinVine, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Athach, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Avoral, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.Azer, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureConstants.Barghest, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureConstants.Barghest_Greater, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureConstants.Basilisk, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Basilisk_AbyssalGreater, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Behir, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Belker, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.BlinkDog, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Bodak, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Bralani, EnvironmentConstants.Plane_ChaoticGood)]
        [TestCase(CreatureConstants.Bugbear, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Bugbear_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Bugbear_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Bugbear_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Bulette, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.CelestialCreature, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.Badger_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.Dog_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.FireBeetle_Giant_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.Monkey_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.Owl_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.Porpoise_Celestial, EnvironmentConstants.Plane_Good)]
        [TestCase(CreatureConstants.Centaur, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Centaur_Leader_2ndTo5th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Centaur_Leader_5thTo9th, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Centaur_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Centaur_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Centaur_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.ChaosBeast, EnvironmentConstants.Plane_Limbo)]
        [TestCase(CreatureConstants.Chimera, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Choker, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Chuul, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Cloaker, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Cockatrice, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Couatl, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Darkmantle, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Delver, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Babau, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Balor, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Bebilith, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Dretch, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Glabrezu, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Hezrou, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Marilith, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Nalfeshnee, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Quasit, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Retriever, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Succubus, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Vrock, EnvironmentConstants.Plane_ChaoticEvil)]
        [TestCase(CreatureConstants.Derro, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Derro_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Derro_Sorcerer_3rd, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Derro_Sorcerer_5thTo8th, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Destrachan, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.BarbedDevil, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.BarbedDevil_Hamatula, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.BeardedDevil, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.BeardedDevil_Barbazu, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.BoneDevil, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.BoneDevil_Osyluth, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.ChainDevil, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.ChainDevil_Kyton, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.Erinyes, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.Hellcat, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.Hellcat_Bezekira, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.HornedDevil, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.HornedDevil_Cornugon, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.IceDevil, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.IceDevil_Gelugon, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.Imp, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.Lemure, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.PitFiend, EnvironmentConstants.Plane_LawfulEvil)]
        [TestCase(CreatureConstants.Devourer, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.Digester, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Deinonychus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elasmosaurus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Megaraptor, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Triceratops, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Tyrannosaurus, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Ape_Dire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Badger_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Bat_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Bear_Dire, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Boar_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Lion_Dire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Rat_Dire, EnvironmentConstants.Land)]
        [TestCase(CreatureConstants.Rat_Dire_Fiendish, EnvironmentConstants.Plane_Evil)]
        [TestCase(CreatureConstants.Shark_Dire, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Tiger_Dire, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Weasel_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Wolf_Dire, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Wolverine_Dire, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Doppelganger, EnvironmentConstants.Any)]
        [TestCase(CreatureConstants.Dragon_Black, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Black_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh)]
        [TestCase(CreatureConstants.Dragon_Blue, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Blue_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Brass_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Dragon_Bronze, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Bronze_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Copper_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills)]
        [TestCase(CreatureConstants.Dragon_Gold, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Gold_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains)]
        [TestCase(CreatureConstants.Dragon_Green, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Green_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dragon_Red, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_Adult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_Ancient, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_GreatWyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_Juvenile, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_MatureAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_Old, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_VeryOld, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_VeryYoung, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrm, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_Wyrmling, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_Young, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Red_YoungAdult, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_Adult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_Ancient, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_GreatWyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_Juvenile, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_MatureAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_Old, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryOld, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_VeryYoung, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrm, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_Wyrmling, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_Young, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_Silver_YoungAdult, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_Adult, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_Ancient, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_GreatWyrm, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_Juvenile, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_MatureAdult, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_Old, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_VeryOld, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_VeryYoung, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_Wyrm, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_Wyrmling, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_Young, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dragon_White_YoungAdult, EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.DragonTurtle, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Dragonne, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert)]
        [TestCase(CreatureConstants.Drider, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Dryad, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Dwarf_Hill, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Hill_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Hill_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Hill_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Hill_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Hill_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Hill_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Mountain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Mountain_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Dwarf_Deep, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Dwarf_Deep_Captain, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Dwarf_Deep_Leader, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Dwarf_Deep_Lieutenant, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Dwarf_Deep_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Dwarf_Deep_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Dwarf_Deep_Warrior, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Duergar, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Duergar_Captain, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Duergar_Leader, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Duergar_Lieutenant, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Duergar_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Duergar_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Duergar_Warrior, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Eagle_Giant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Elemental_Air, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.Elemental_Air_Elder, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.Elemental_Air_Greater, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.Elemental_Air_Huge, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.Elemental_Air_Large, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.Elemental_Air_Medium, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.Elemental_Air_Small, EnvironmentConstants.Plane_Air)]
        [TestCase(CreatureConstants.Elemental_Earth, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureConstants.Elemental_Earth_Elder, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureConstants.Elemental_Earth_Greater, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureConstants.Elemental_Earth_Huge, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureConstants.Elemental_Earth_Large, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureConstants.Elemental_Earth_Medium, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureConstants.Elemental_Earth_Small, EnvironmentConstants.Plane_Earth)]
        [TestCase(CreatureConstants.Elemental_Fire, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureConstants.Elemental_Fire_Elder, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureConstants.Elemental_Fire_Greater, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureConstants.Elemental_Fire_Huge, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureConstants.Elemental_Fire_Large, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureConstants.Elemental_Fire_Medium, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureConstants.Elemental_Fire_Small, EnvironmentConstants.Plane_Fire)]
        [TestCase(CreatureConstants.Elemental_Water, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureConstants.Elemental_Water_Elder, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureConstants.Elemental_Water_Greater, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureConstants.Elemental_Water_Huge, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureConstants.Elemental_Water_Large, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureConstants.Elemental_Water_Medium, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureConstants.Elemental_Water_Small, EnvironmentConstants.Plane_Water)]
        [TestCase(CreatureConstants.Elf_High, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_High_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_High_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_High_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_High_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_High_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_High_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Half, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Half_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Half_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Half_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Half_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Half_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Half_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Aquatic, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Elf_Aquatic_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Elf_Aquatic_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Elf_Aquatic_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Elf_Aquatic_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Elf_Aquatic_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Elf_Aquatic_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic)]
        [TestCase(CreatureConstants.Elf_Gray, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Elf_Gray_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Elf_Gray_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Elf_Gray_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Elf_Gray_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Elf_Gray_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Elf_Gray_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain)]
        [TestCase(CreatureConstants.Elf_Wild, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wild_Captain, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wild_Leader, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wild_Lieutenant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wild_Noncombatant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wild_Sergeant, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wild_Warrior, EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wood, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wood_Captain, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wood_Leader, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wood_Lieutenant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wood_Noncombatant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wood_Sergeant, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Elf_Wood_Warrior, EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest)]
        [TestCase(CreatureConstants.Drow, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Drow_Captain, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Drow_Leader, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Drow_Lieutenant, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Drow_Noncombatant, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Drow_Sergeant, EnvironmentConstants.Underground)]
        [TestCase(CreatureConstants.Drow_Warrior, EnvironmentConstants.Underground)]
        public void CreaturesAreInCorrectEnvironment(string creature, string environment)
        {
            var creatures = collectionSelector.Explode(TableNameConstants.CreatureGroups, environment);
            Assert.That(creatures, Contains.Item(creature));

            Assert.Fail("not finished");
        }
    }
}
