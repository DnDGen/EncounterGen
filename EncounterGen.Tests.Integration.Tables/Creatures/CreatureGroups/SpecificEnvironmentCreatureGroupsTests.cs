using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class SpecificEnvironmentCreatureGroupsTests : CreatureGroupsTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

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
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
            CreatureConstants.Ant_Giant,
            CreatureConstants.Bat,
            CreatureConstants.Dragonne,
            CreatureConstants.Donkey)]
        [TestCase(EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Dungeon)]
        [TestCase(EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Dungeon)]
        public void SpecificEnvironmentCreatureGroup(string environment, params string[] creatures)
        {
            base.DistinctCollection(environment, creatures);
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
                CreatureConstants.Krenshar,
                CreatureConstants.Nymph,
                CreatureConstants.Owlbear,
                CreatureConstants.Pegasus,
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
                CreatureConstants.SeaHag,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Medusa,
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
    }
}
