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

            base.DistinctCollection(GroupConstants.Land, creatures);
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
    }
}
