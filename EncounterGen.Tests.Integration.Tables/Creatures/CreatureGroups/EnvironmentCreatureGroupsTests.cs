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
                CreatureConstants.DrowWarrior,
                CreatureConstants.DuergarWarrior,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.Fungus,
                CreatureConstants.GelatinousCube,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Storm,
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
                CreatureConstants.MindFlayer,
                CreatureConstants.Minotaur,
                CreatureConstants.Mummy,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.Otyugh,
                CreatureConstants.Owlbear,
                CreatureConstants.PhantomFungus,
                CreatureConstants.PrayingMantis_Giant,
                CreatureConstants.PurpleWorm,
                CreatureConstants.Roper,
                CreatureConstants.RustMonster,
                CreatureConstants.ShamblingMound,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Skum,
                CreatureConstants.Snake_Constrictor,
                CreatureConstants.StagBeetle_Giant,
                CreatureConstants.SvirfneblinWarrior,
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
                CreatureConstants.Adept_Doctor,
                CreatureConstants.Adept_Fortuneteller,
                CreatureConstants.Adept_Missionary,
                CreatureConstants.Adept_StreetPerformer,
                CreatureConstants.Aristocrat_Businessman,
                CreatureConstants.Aristocrat_Gentry,
                CreatureConstants.Aristocrat_Politician,
                CreatureConstants.Barbarian_CombatInstructor,
                CreatureConstants.Barbarian_WarHero,
                CreatureConstants.Bard_FamousEntertainer,
                CreatureConstants.Bard_StreetPerformer,
                CreatureConstants.Cat,
                CreatureConstants.Character_RetiredAdventurer,
                CreatureConstants.Character_Sellsword,
                CreatureConstants.Cleric_Doctor,
                CreatureConstants.Cleric_FamousPriest,
                CreatureConstants.Cleric_WarHero,
                CreatureConstants.Commoner_Beggar,
                CreatureConstants.Commoner_ConstructionWorker,
                CreatureConstants.Commoner_Merchant,
                CreatureConstants.Commoner_Minstrel,
                CreatureConstants.Commoner_Protestor,
                CreatureConstants.Druid_AnimalTrainer,
                CreatureConstants.Druid_Doctor,
                CreatureConstants.Druid_FamousPriest,
                CreatureConstants.Expert_Artisan,
                CreatureConstants.Fighter_CombatInstructor,
                CreatureConstants.Fighter_Hitman,
                CreatureConstants.Fighter_WarHero,
                CreatureConstants.Monk_CombatInstructor,
                CreatureConstants.Monk_Scholar,
                CreatureConstants.Monk_WarHero,
                CreatureConstants.NPC,
                CreatureConstants.Paladin_CombatInstructor,
                CreatureConstants.Paladin_Crusader,
                CreatureConstants.Paladin_WarHero,
                CreatureConstants.Ranger_AnimalTrainer,
                CreatureConstants.Ranger_CombatInstructor,
                CreatureConstants.Ranger_Hitman,
                CreatureConstants.Ranger_WarHero,
                CreatureConstants.Rogue_Hitman,
                CreatureConstants.Rogue_Pickpocket,
                CreatureConstants.Rogue_StreetPerformer,
                CreatureConstants.Sorcerer_FamousEntertainer,
                CreatureConstants.Sorcerer_StreetPerformer,
                CreatureConstants.Warrior_Patrol,
                CreatureConstants.Wizard_FamousResearcher,
                CreatureConstants.Wizard_Scholar,
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
                CreatureConstants.Lion,
                CreatureConstants.Wolf,
                CreatureConstants.Eagle,
                CreatureConstants.Owl,
                CreatureConstants.UmberHulk,
                CreatureConstants.Drider,
                CreatureConstants.Giant_Stone,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Grimlock,
                CreatureConstants.Tiger,
                CreatureConstants.Troglodyte,
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
                CreatureConstants.Lion,
                CreatureConstants.Tiger,
                CreatureConstants.Wolf,
                CreatureConstants.Eagle,
                CreatureConstants.Owl,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Lamia,
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
                CreatureConstants.Lion,
                CreatureConstants.Tiger,
                CreatureConstants.Wolf,
                CreatureConstants.Eagle,
                CreatureConstants.Owl,
                CreatureConstants.Sprite,
                CreatureConstants.Kobold,
                CreatureConstants.Stirge,
                CreatureConstants.Treant,
            };

            base.DistinctCollection(EnvironmentConstants.Forest, creatures);
        }

        [Test]
        public void PlainsCreatures()
        {
            var creatures = new[]
            {
                CreatureConstants.Bear_Brown,
                CreatureConstants.Lion,
                CreatureConstants.Tiger,
                CreatureConstants.Wolf,
                CreatureConstants.Eagle,
                CreatureConstants.Owl,
            };

            base.DistinctCollection(EnvironmentConstants.Plains, creatures);
        }
    }
}
