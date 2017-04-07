using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
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
        [TestCase(EnvironmentConstants.Civilized,
            CreatureConstants.Cat,
            CreatureConstants.Character,
            CreatureConstants.Dog)]
        [TestCase(EnvironmentConstants.Desert,
            CreatureConstants.Lamia,
            CreatureConstants.Mummy)]
        [TestCase(EnvironmentConstants.Forest,
            CreatureConstants.Bear_Brown,
            CreatureConstants.Eagle,
            CreatureConstants.Kobold,
            CreatureConstants.Lion,
            CreatureConstants.Owl,
            CreatureConstants.Stirge,
            CreatureConstants.Tiger,
            CreatureConstants.Treant,
            CreatureConstants.Wolf)]
        [TestCase(EnvironmentConstants.Hills,
            CreatureConstants.Bear_Brown,
            CreatureConstants.Eagle,
            CreatureConstants.Giant_Hill,
            CreatureConstants.Lamia,
            CreatureConstants.Lion,
            CreatureConstants.Owl,
            CreatureConstants.Tiger,
            CreatureConstants.Yrthak)]
        [TestCase(EnvironmentConstants.Marsh,
            CreatureConstants.BlackPudding,
            CreatureConstants.Hydra,
            CreatureConstants.Ooze_Gray,
            CreatureConstants.Ooze_OchreJelly,
            CreatureConstants.WillOWisp)]
        [TestCase(EnvironmentConstants.Mountain,
            CreatureConstants.Bear_Brown,
            CreatureConstants.Drider,
            CreatureConstants.Eagle,
            CreatureConstants.Giant_Stone,
            CreatureConstants.Giant_Hill,
            CreatureConstants.Grimlock,
            CreatureConstants.Lion,
            CreatureConstants.Owl,
            CreatureConstants.Tiger,
            CreatureConstants.Troglodyte,
            CreatureConstants.UmberHulk,
            CreatureConstants.Yrthak)]
        [TestCase(EnvironmentConstants.Plains,
            CreatureConstants.Bear_Brown,
            CreatureConstants.Eagle,
            CreatureConstants.Lion,
            CreatureConstants.Owl,
            CreatureConstants.Tiger,
            CreatureConstants.Wolf)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Aquatic,
            CreatureConstants.Shark,
            CreatureConstants.Troll_Scrag,
            CreatureConstants.Whale_Orca)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Dungeon)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills,
            CreatureConstants.Beholder,
            CreatureConstants.Ettin,
            CreatureConstants.OgreMage,
            CreatureConstants.Wolverine)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh,
            CreatureConstants.Annis)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain,
            CreatureConstants.Ettin,
            CreatureConstants.Troll)]
        [TestCase(EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Aquatic,
            CreatureConstants.DragonTurtle,
            CreatureConstants.Elf_Aquatic,
            CreatureConstants.Kraken,
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
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
            CreatureConstants.Ant_Giant,
            CreatureConstants.Bat,
            CreatureConstants.Dragonne,
            CreatureConstants.Donkey)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Dungeon)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Aquatic,
            CreatureConstants.Elasmosaurus,
            CreatureConstants.Locathah,
            CreatureConstants.MantaRay,
            CreatureConstants.Octopus,
            CreatureConstants.Sahuagin,
            CreatureConstants.Whale_Baleen)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Civilized)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Dungeon)]
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
        public void DungeonCreatures()
        {
            var encounters = new[]
            {
                CreatureConstants.Ape,
                CreatureConstants.Ankheg,
                CreatureConstants.Ant_Giant,
                CreatureConstants.Aranea,
                CreatureConstants.Badger,
                CreatureConstants.Bat,
                CreatureConstants.Bear_Black,
                CreatureConstants.Bear_Brown,
                CreatureConstants.BlackPudding,
                CreatureConstants.BlinkDog,
                CreatureConstants.Boar,
                CreatureConstants.Bugbear,
                CreatureConstants.CarrionCrawler,
                CreatureConstants.Choker,
                CreatureConstants.Cloaker,
                CreatureConstants.Couatl,
                CreatureConstants.Criosphinx,
                CreatureConstants.Darkmantle,
                CreatureConstants.Delver,
                CreatureConstants.Derro,
                CreatureConstants.Destrachan,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Dragonne,
                CreatureConstants.Drider,
                CreatureConstants.Drow,
                CreatureConstants.Duergar,
                CreatureConstants.EtherealFilcher,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.Fungus,
                CreatureConstants.GelatinousCube,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Storm,
                CreatureConstants.GibberingMouther,
                CreatureConstants.Girallon,
                CreatureConstants.GreenHag,
                CreatureConstants.Grick,
                CreatureConstants.Gynosphinx,
                CreatureConstants.Hieracosphinx,
                CreatureConstants.Hydra,
                CreatureConstants.Krenshar,
                CreatureConstants.Kobold,
                CreatureConstants.Lamia,
                CreatureConstants.Lion,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.Minotaur,
                CreatureConstants.Mummy,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.Otyugh,
                CreatureConstants.Owlbear,
                CreatureConstants.PhantomFungus,
                CreatureConstants.Phasm,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.PurpleWorm,
                CreatureConstants.Roper,
                CreatureConstants.RustMonster,
                CreatureConstants.ShamblingMound,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Skum,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.Svirfneblin,
                CreatureConstants.Tiger,
                CreatureConstants.Troglodyte,
                CreatureConstants.UmberHulk,
                CreatureConstants.Weasel,
                CreatureConstants.WillOWisp,
                CreatureConstants.Wolf,
                CreatureConstants.Wolverine,
                CreatureConstants.Wyvern,
                CreatureConstants.Yrthak,
            };

            base.DistinctCollection(EnvironmentConstants.Dungeon, encounters);
        }

        [Test]
        public void TemperateForestCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Ankheg,
                CreatureConstants.Ant_Giant,
                CreatureConstants.Aranea,
                CreatureConstants.AssassinVine,
                CreatureConstants.Badger,
                CreatureConstants.Bat,
                CreatureConstants.Bear_Black,
                CreatureConstants.Boar,
                CreatureConstants.Centaur,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Dryad,
                CreatureConstants.Ettercap,
                CreatureConstants.Elf,
                CreatureConstants.GreenHag,
                CreatureConstants.Grig,
                CreatureConstants.Krenshar,
                CreatureConstants.Nymph,
                CreatureConstants.Owlbear,
                CreatureConstants.Pegasus,
                CreatureConstants.Pixie,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Pseudodragon,
                CreatureConstants.Satyr,
                CreatureConstants.ShamblingMound,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.Tendriculos,
                CreatureConstants.Unicorn,
                CreatureConstants.Weasel,
                CreatureConstants.Wolf,
                CreatureConstants.Wolverine,
                CreatureConstants.Wyvern,
                CreatureConstants.RazorBoar,
                CreatureConstants.Hawk,
                CreatureConstants.Raven,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void TemperateHillsCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Ant_Giant,
                CreatureConstants.Badger,
                CreatureConstants.Bat,
                CreatureConstants.Bear_Black,
                CreatureConstants.Chimera,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Dragonne,
                CreatureConstants.Ettin,
                CreatureConstants.Gnome,
                CreatureConstants.Griffon,
                CreatureConstants.Hippogriff,
                CreatureConstants.Naga_Dark,
                CreatureConstants.Ogre,
                CreatureConstants.Orc,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Tendriculos,
                CreatureConstants.Weasel,
                CreatureConstants.Wolverine,
                CreatureConstants.Wyvern,
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
                CreatureConstants.Lizardfolk,
                CreatureConstants.Medusa,
                CreatureConstants.Naga_Spirit,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.ShamblingMound,
                CreatureConstants.Tendriculos,
                CreatureConstants.Toad,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void TemperateMountainCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Bear_Black,
                CreatureConstants.Bugbear,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Dwarf,
                CreatureConstants.Ettin,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Storm,
                CreatureConstants.Griffon,
                CreatureConstants.Roc,
                CreatureConstants.Weasel,
                CreatureConstants.Wyvern,
                CreatureConstants.RazorBoar,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain, creatures);
        }

        [Test]
        public void TemperatePlainsCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Aasimar,
                CreatureConstants.Ankheg,
                CreatureConstants.Ant_Giant,
                CreatureConstants.Badger,
                CreatureConstants.Bat,
                CreatureConstants.Bison,
                CreatureConstants.BlinkDog,
                CreatureConstants.Cat,
                CreatureConstants.Dog,
                CreatureConstants.Hippogriff,
                CreatureConstants.Horse,
                CreatureConstants.Krenshar,
                CreatureConstants.Locust,
                CreatureConstants.Naga_Guardian,
                CreatureConstants.Pony,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Tiefling,
                CreatureConstants.Weasel,
                CreatureConstants.Wolverine,
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
                CreatureConstants.Ant_Giant,
                CreatureConstants.Baboon,
                CreatureConstants.Basilisk,
                CreatureConstants.Bat,
                CreatureConstants.Camel,
                CreatureConstants.Criosphinx,
                CreatureConstants.Dragonne,
                CreatureConstants.Gynosphinx,
                CreatureConstants.Hieracosphinx,
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
                CreatureConstants.Ant_Giant,
                CreatureConstants.Ape,
                CreatureConstants.Aranea,
                CreatureConstants.AssassinVine,
                CreatureConstants.Baboon,
                CreatureConstants.Bat,
                CreatureConstants.Bear_Black,
                CreatureConstants.Boar,
                CreatureConstants.Couatl,
                CreatureConstants.Criosphinx,
                CreatureConstants.Deinonychus,
                CreatureConstants.Dryad,
                CreatureConstants.Elephant,
                CreatureConstants.Ettercap,
                CreatureConstants.Girallon,
                CreatureConstants.GreenHag,
                CreatureConstants.Krenshar,
                CreatureConstants.Leopard,
                CreatureConstants.Lizard,
                CreatureConstants.Megaraptor,
                CreatureConstants.Monkey,
                CreatureConstants.Pegasus,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Pseudodragon,
                CreatureConstants.Rakshasa,
                CreatureConstants.RazorBoar,
                CreatureConstants.ShamblingMound,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.Tendriculos,
                CreatureConstants.Wyvern,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void WarmHillsCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Ant_Giant,
                CreatureConstants.Athach,
                CreatureConstants.Bat,
                CreatureConstants.Bear_Black,
                CreatureConstants.Behir,
                CreatureConstants.Dinosaur,
                CreatureConstants.Dragonne,
                CreatureConstants.Griffon,
                CreatureConstants.Hieracosphinx,
                CreatureConstants.Hippogriff,
                CreatureConstants.PhaseSpider,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.Tendriculos,
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
                CreatureConstants.Criosphinx,
                CreatureConstants.Deinonychus,
                CreatureConstants.GreenHag,
                CreatureConstants.SeaHag,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Megaraptor,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Rakshasa,
                CreatureConstants.ShamblingMound,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Tendriculos,
                CreatureConstants.Tyrannosaurus,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void WarmMountainCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Ape,
                CreatureConstants.Athach,
                CreatureConstants.Bear_Black,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Girallon,
                CreatureConstants.Griffon,
                CreatureConstants.Roc,
                CreatureConstants.Wyvern,
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
                CreatureConstants.Ant_Giant,
                CreatureConstants.Bat,
                CreatureConstants.Cheetah,
                CreatureConstants.Dinosaur,
                CreatureConstants.Elephant,
                CreatureConstants.Halfling,
                CreatureConstants.Hippogriff,
                CreatureConstants.Krenshar,
                CreatureConstants.Leopard,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Scorpionfolk,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains, creatures);
        }

        [Test]
        public void ColdCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Giant_Frost,
                CreatureConstants.FrostWorm,
                CreatureConstants.Remorhaz,
                CreatureConstants.WinterWolf,
                CreatureConstants.Bear_Polar,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Cold, creatures);
        }

        [Test]
        public void WarmCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Bee_Giant,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Bulette,
                CreatureConstants.Centipede_Monstrous,
                CreatureConstants.Centipede_Swarm,
                CreatureConstants.Cockatrice,
                CreatureConstants.Digester,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.Gnoll,
                CreatureConstants.Goblin,
                CreatureConstants.Gorgon,
                CreatureConstants.Harpy,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Lammasu,
                CreatureConstants.Manticore,
                CreatureConstants.Scorpion_Monstrous,
                CreatureConstants.Snake_Viper,
                CreatureConstants.Spider_Monstrous,
                CreatureConstants.Spider_Swarm,
                CreatureConstants.SpiderEater,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.YuanTi,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Warm, creatures);
        }

        [Test]
        public void TemperateCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Athach,
                CreatureConstants.Bee_Giant,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Bulette,
                CreatureConstants.Centipede_Monstrous,
                CreatureConstants.Cockatrice,
                CreatureConstants.Digester,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.Gnoll,
                CreatureConstants.Goblin,
                CreatureConstants.Gorgon,
                CreatureConstants.Harpy,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Lammasu,
                CreatureConstants.Manticore,
                CreatureConstants.Scorpion_Monstrous,
                CreatureConstants.Snake_Viper,
                CreatureConstants.Spider_Monstrous,
                CreatureConstants.SpiderEater,
                CreatureConstants.Wasp_Giant,
                CreatureConstants.YuanTi,
            };

            base.DistinctCollection(EnvironmentConstants.Temperatures.Temperate, creatures);
        }
    }
}
