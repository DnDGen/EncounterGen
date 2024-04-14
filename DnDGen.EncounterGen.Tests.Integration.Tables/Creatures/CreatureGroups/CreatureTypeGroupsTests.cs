using DnDGen.EncounterGen.Models;
using NUnit.Framework;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class CreatureTypeGroupsTests : CreatureGroupsTableTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [Test]
        public void AberrationGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Aboleth,
                CreatureConstants.Athach,
                CreatureConstants.Beholder,
                CreatureConstants.CarrionCrawler,
                CreatureConstants.Choker,
                CreatureConstants.Chuul,
                CreatureConstants.Cloaker,
                CreatureConstants.Delver,
                CreatureConstants.Destrachan,
                CreatureConstants.Drider,
                CreatureConstants.EtherealFilcher,
                CreatureConstants.Ettercap,
                CreatureConstants.GibberingMouther,
                CreatureConstants.Grick,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.Naga,
                CreatureConstants.Otyugh,
                CreatureConstants.Phasm,
                CreatureConstants.RustMonster,
                CreatureConstants.Skum,
                CreatureConstants.UmberHulk,
                CreatureConstants.WillOWisp,
            };

            base.DistinctCollection(CreatureConstants.Types.Aberration, creatures);
        }

        [Test]
        public void AnimalGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Ape,
                CreatureConstants.Baboon,
                CreatureConstants.Badger,
                CreatureConstants.Bat,
                CreatureConstants.Bear,
                CreatureConstants.Bison,
                CreatureConstants.Boar,
                CreatureConstants.Camel,
                CreatureConstants.Cat,
                CreatureConstants.Cheetah,
                CreatureConstants.Crocodile,
                CreatureConstants.Dinosaur,
                CreatureConstants.Dog,
                CreatureConstants.Donkey,
                CreatureConstants.Eagle,
                CreatureConstants.Elephant,
                CreatureConstants.Hawk,
                CreatureConstants.Horse,
                CreatureConstants.Hyena,
                CreatureConstants.Leopard,
                CreatureConstants.Lion,
                CreatureConstants.Livestock,
                CreatureConstants.Lizard,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.MantaRay,
                CreatureConstants.Monkey,
                CreatureConstants.Mule,
                CreatureConstants.Octopus,
                CreatureConstants.Owl,
                CreatureConstants.Pony,
                CreatureConstants.Porpoise,
                CreatureConstants.Rat,
                CreatureConstants.Raven,
                CreatureConstants.Rhinoceras,
                CreatureConstants.Roc,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.Snake_Viper,
                CreatureConstants.Shark,
                CreatureConstants.Squid,
                CreatureConstants.Tiger,
                CreatureConstants.Toad,
                CreatureConstants.Weasel,
                CreatureConstants.Whale,
                CreatureConstants.Wolf,
                CreatureConstants.Wolverine,
            };

            base.DistinctCollection(CreatureConstants.Types.Animal, creatures);
        }

        [Test]
        public void ConstructGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Inevitable,
                CreatureConstants.AnimatedObject,
                CreatureConstants.Golem,
                CreatureConstants.Homunculus,
                CreatureConstants.Retriever,
                CreatureConstants.ShieldGuardian,
            };

            base.DistinctCollection(CreatureConstants.Types.Construct, creatures);
        }

        [Test]
        public void DragonGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Dragon_Black,
                CreatureConstants.Dragon_Blue,
                CreatureConstants.Dragon_Green,
                CreatureConstants.Dragon_Red,
                CreatureConstants.Dragon_White,
                CreatureConstants.Dragon_Brass,
                CreatureConstants.Dragon_Bronze,
                CreatureConstants.Dragon_Copper,
                CreatureConstants.Dragon_Gold,
                CreatureConstants.Dragon_Silver,
                CreatureConstants.DragonTurtle,
                CreatureConstants.Pseudodragon,
                CreatureConstants.Wyvern,
            };

            base.DistinctCollection(CreatureConstants.Types.Dragon, creatures);
        }

        [Test]
        public void ElementalGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Belker,
                CreatureConstants.Elemental_Air,
                CreatureConstants.Elemental_Earth,
                CreatureConstants.Elemental_Fire,
                CreatureConstants.Elemental_Water,
                CreatureConstants.InvisibleStalker,
                CreatureConstants.Magmin,
                CreatureConstants.Thoqqua
            };

            base.DistinctCollection(CreatureConstants.Types.Elemental, creatures);
        }

        [Test]
        public void FeyGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Dryad,
                CreatureConstants.Nymph,
                CreatureConstants.Satyr,
                CreatureConstants.Sprite,
            };

            base.DistinctCollection(CreatureConstants.Types.Fey, creatures);
        }

        [Test]
        public void GiantGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Ettin,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Fire,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Storm,
                CreatureConstants.Ogre,
                CreatureConstants.Ogre_Merrow,
                CreatureConstants.OgreMage,
                CreatureConstants.Troll,
                CreatureConstants.Troll_Scrag,
            };

            base.DistinctCollection(CreatureConstants.Types.Giant, creatures);
        }

        [Test]
        public void HumanoidGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Aasimar,
                CreatureConstants.Bugbear,
                CreatureConstants.Character,
                CreatureConstants.Drow,
                CreatureConstants.Duergar,
                CreatureConstants.Dwarf,
                CreatureConstants.Elf,
                CreatureConstants.Elf_Aquatic,
                CreatureConstants.Gnoll,
                CreatureConstants.Gnome,
                CreatureConstants.Goblin,
                CreatureConstants.Halfling,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Kobold,
                CreatureConstants.KuoToa,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Locathah,
                CreatureConstants.Merfolk,
                CreatureConstants.Orc,
                CreatureConstants.Orc_Half,
                CreatureConstants.Svirfneblin,
                CreatureConstants.Tiefling,
                CreatureConstants.Troglodyte,
            };

            base.DistinctCollection(CreatureConstants.Types.Humanoid, creatures);
        }

        [Test]
        public void MagicalBeastsGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Ankheg,
                CreatureConstants.Aranea,
                CreatureConstants.Basilisk,
                CreatureConstants.Behir,
                CreatureConstants.BlinkDog,
                CreatureConstants.Bulette,
                CreatureConstants.CelestialCreature,
                CreatureConstants.Chimera,
                CreatureConstants.Cockatrice,
                CreatureConstants.Darkmantle,
                CreatureConstants.Digester,
                CreatureConstants.DisplacerBeast,
                CreatureConstants.Dragonne,
                CreatureConstants.Eagle_Giant,
                CreatureConstants.EtherealMarauder,
                CreatureConstants.FiendishCreature,
                CreatureConstants.FrostWorm,
                CreatureConstants.Girallon,
                CreatureConstants.Gorgon,
                CreatureConstants.GrayRender,
                CreatureConstants.Griffon,
                CreatureConstants.Hippogriff,
                CreatureConstants.Hydra,
                CreatureConstants.Kraken,
                CreatureConstants.Krenshar,
                CreatureConstants.Lamia,
                CreatureConstants.Lammasu,
                CreatureConstants.Manticore,
                CreatureConstants.Owl_Giant,
                CreatureConstants.Owlbear,
                CreatureConstants.Pegasus,
                CreatureConstants.PhaseSpider,
                CreatureConstants.PurpleWorm,
                CreatureConstants.RazorBoar,
                CreatureConstants.Remorhaz,
                CreatureConstants.Roper,
                CreatureConstants.SeaCat,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Androsphinx,
                CreatureConstants.Criosphinx,
                CreatureConstants.Gynosphinx,
                CreatureConstants.Hieracosphinx,
                CreatureConstants.SpiderEater,
                CreatureConstants.Stirge,
                CreatureConstants.Tarrasque,
                CreatureConstants.Unicorn,
                CreatureConstants.WinterWolf,
                CreatureConstants.Worg,
                CreatureConstants.Yrthak,
            };

            base.DistinctCollection(CreatureConstants.Types.MagicalBeast, creatures);
        }

        [Test]
        public void MonstrousHumanoidGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Centaur,
                CreatureConstants.Derro,
                CreatureConstants.Doppelganger,
                CreatureConstants.Gargoyle,
                CreatureConstants.Gargoyle_Kapoacinth,
                CreatureConstants.Grimlock,
                CreatureConstants.Hag,
                CreatureConstants.Harpy,
                CreatureConstants.Lycanthrope,
                CreatureConstants.Medusa,
                CreatureConstants.Minotaur,
                CreatureConstants.Sahuagin,
                CreatureConstants.Scorpionfolk,
                CreatureConstants.YuanTi,
            };

            base.DistinctCollection(CreatureConstants.Types.MonstrousHumanoid, creatures);
        }

        [Test]
        public void OozeGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.BlackPudding,
                CreatureConstants.GelatinousCube,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Ooze_OchreJelly,
            };

            base.DistinctCollection(CreatureConstants.Types.Ooze, creatures);
        }

        [Test]
        public void OutsiderGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Achaierai,
                CreatureConstants.Angel,
                CreatureConstants.Archon,
                CreatureConstants.Arrowhawk,
                CreatureConstants.Avoral,
                CreatureConstants.Azer,
                CreatureConstants.Barghest,
                CreatureConstants.Basilisk_AbyssalGreater,
                CreatureConstants.Bralani,
                CreatureConstants.CelestialCreature,
                CreatureConstants.ChaosBeast,
                CreatureConstants.Couatl,
                CreatureConstants.Demon,
                CreatureConstants.Devil,
                CreatureConstants.EtherealMarauder,
                CreatureConstants.FiendishCreature,
                CreatureConstants.Formian,
                CreatureConstants.Genie,
                CreatureConstants.Ghaele,
                CreatureConstants.Githyanki,
                CreatureConstants.Githzerai,
                CreatureConstants.HellHound,
                CreatureConstants.Hellwasp,
                CreatureConstants.Howler,
                CreatureConstants.Inevitable,
                CreatureConstants.Leonal,
                CreatureConstants.Lillend,
                CreatureConstants.Mephit,
                CreatureConstants.Mephit_CR3,
                CreatureConstants.NessianWarhound,
                CreatureConstants.NightHag,
                CreatureConstants.Nightmare,
                CreatureConstants.Rakshasa,
                CreatureConstants.Rast,
                CreatureConstants.Ravid,
                CreatureConstants.Salamander,
                CreatureConstants.ShadowMastiff,
                CreatureConstants.Slaad,
                CreatureConstants.Titan,
                CreatureConstants.Tojanida,
                CreatureConstants.Triton,
                CreatureConstants.Vargouille,
                CreatureConstants.Xill,
                CreatureConstants.Xorn,
                CreatureConstants.YethHound,
            };

            base.DistinctCollection(CreatureConstants.Types.Outsider, creatures);
        }

        [Test]
        public void PlantGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.AssassinVine,
                CreatureConstants.Fungus,
                CreatureConstants.PhantomFungus,
                CreatureConstants.ShamblingMound,
                CreatureConstants.Tendriculos,
                CreatureConstants.Treant,
            };

            base.DistinctCollection(CreatureConstants.Types.Plant, creatures);
        }

        [Test]
        public void UndeadGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Allip,
                CreatureConstants.Bodak,
                CreatureConstants.Devourer,
                CreatureConstants.Ghost,
                CreatureConstants.Ghoul,
                CreatureConstants.Ghoul_Lacedon,
                CreatureConstants.Lich,
                CreatureConstants.Mohrg,
                CreatureConstants.Mummy,
                CreatureConstants.Nightshade,
                CreatureConstants.Shadow,
                CreatureConstants.Skeleton,
                CreatureConstants.Spectre,
                CreatureConstants.Vampire,
                CreatureConstants.Wight,
                CreatureConstants.Wraith,
                CreatureConstants.Zombie,
            };

            base.DistinctCollection(CreatureConstants.Types.Undead, creatures);
        }

        [Test]
        public void VerminGroup()
        {
            var creatures = new[]
            {
                CreatureConstants.Ant_Giant,
                CreatureConstants.Bee_Giant,
                CreatureConstants.BombardierBeetle_Giant,
                CreatureConstants.Centipede_Monstrous,
                CreatureConstants.Centipede_Swarm,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.Locust,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.Scorpion_Monstrous,
                CreatureConstants.Spider_Monstrous,
                CreatureConstants.Spider_Swarm,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.Wasp_Giant,
            };

            base.DistinctCollection(CreatureConstants.Types.Vermin, creatures);
        }
    }
}
