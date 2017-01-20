using EncounterGen.Common;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Creatures.CreatureGroups
{
    [TestFixture]
    public class EnvironmentCreatureGroupsTests : CreatureGroupsTests
    {
        [Test]
        public override void EntriesAreComplete()
        {
            AssertCreatureGroupEntriesAreComplete();
        }

        [Test]
        public void DungeonCreatures()
        {
            var encounters = new[]
            {
                CreatureConstants.Aboleth,
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
        public void CivilizedCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Cat,
                CreatureConstants.Character,
                CreatureConstants.Dog,
            };

            base.DistinctCollection(EnvironmentConstants.Civilized, creatures);
        }

        [Test]
        public void DesertCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Lamia,
                CreatureConstants.Mummy,
            };

            base.DistinctCollection(EnvironmentConstants.Desert, creatures);
        }

        [Test]
        public void MountainCreatures()
        {
            var creatures = new[]
            {
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
                CreatureConstants.Yrthak,
            };

            base.DistinctCollection(EnvironmentConstants.Mountain, creatures);
        }

        [Test]
        public void HillsCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Bear_Brown,
                CreatureConstants.Eagle,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Lamia,
                CreatureConstants.Lion,
                CreatureConstants.Owl,
                CreatureConstants.Tiger,
                CreatureConstants.Yrthak,
            };

            base.DistinctCollection(EnvironmentConstants.Hills, creatures);
        }

        [Test]
        public void MarshCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.BlackPudding,
                CreatureConstants.Hydra,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.WillOWisp,
            };

            base.DistinctCollection(EnvironmentConstants.Marsh, creatures);
        }

        [Test]
        public void ForestCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Bear_Brown,
                CreatureConstants.Eagle,
                CreatureConstants.Kobold,
                CreatureConstants.Lion,
                CreatureConstants.Owl,
                CreatureConstants.Sprite,
                CreatureConstants.Stirge,
                CreatureConstants.Tiger,
                CreatureConstants.Treant,
                CreatureConstants.Wolf,
            };

            base.DistinctCollection(EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void PlainsCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Bear_Brown,
                CreatureConstants.Eagle,
                CreatureConstants.Lion,
                CreatureConstants.Owl,
                CreatureConstants.Tiger,
                CreatureConstants.Wolf,
            };

            base.DistinctCollection(EnvironmentConstants.Plains, creatures);
        }
    }
}
