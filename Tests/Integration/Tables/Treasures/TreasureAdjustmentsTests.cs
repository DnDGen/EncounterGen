using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Treasures
{
    [TestFixture]
    public class TreasureAdjustmentsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.TreasureAdjustments;
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var entries = new[]
            {
                CreatureConstants.Allip,
                CreatureConstants.Ankheg,
                CreatureConstants.Ant_Giant_Soldier,
                CreatureConstants.Ant_Giant_Worker,
                CreatureConstants.AstralDeva,
                CreatureConstants.Azer,
                CreatureConstants.Balor,
                CreatureConstants.Beholder,
                CreatureConstants.BlinkDog,
                CreatureConstants.Boar_Dire,
                CreatureConstants.Bugbear,
                CreatureConstants.CarrionCrawler,
                CreatureConstants.Centipede_Monstrous_Large,
                CreatureConstants.Centipede_Monstrous_Medium,
                CreatureConstants.Character,
                CreatureConstants.Choker,
                CreatureConstants.Cockatrice,
                CreatureConstants.Cornugon,
                CreatureConstants.Cryohydra,
                CreatureConstants.Darkmantle,
                CreatureConstants.Doppelganger,
                CreatureConstants.Dragon,
                CreatureConstants.DwarfWarrior,
                CreatureConstants.ElfWarrior,
                CreatureConstants.EtherealMarauder,
                CreatureConstants.Ettercap,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.FormianWarrior,
                CreatureConstants.FormianWorker,
                CreatureConstants.Gelugon,
                CreatureConstants.Ghaele,
                CreatureConstants.Ghast,
                CreatureConstants.Ghost,
                CreatureConstants.Ghoul,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Storm,
                CreatureConstants.GibberingMouther,
                CreatureConstants.Glabrezu,
                CreatureConstants.Gnoll,
                CreatureConstants.Goblin,
                CreatureConstants.Golem_Stone,
                CreatureConstants.GreenHag,
                CreatureConstants.Grick,
                CreatureConstants.Hamatula,
                CreatureConstants.Hezrou,
                CreatureConstants.Hobgoblin,
                CreatureConstants.Hydra,
                CreatureConstants.Hyena,
                CreatureConstants.Imp,
                CreatureConstants.Kobold,
                CreatureConstants.Krenshar,
                CreatureConstants.LanternArchon,
                CreatureConstants.Lemure,
                CreatureConstants.Lich,
                CreatureConstants.Lion_Dire,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.Magmin,
                CreatureConstants.Marilith,
                CreatureConstants.Mephit,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.Mummy,
                CreatureConstants.Naga_Spirit,
                CreatureConstants.Nalfeshnee,
                CreatureConstants.Nightcrawler,
                CreatureConstants.Nightmare,
                CreatureConstants.Nightwalker,
                CreatureConstants.Ogre,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.Orc,
                CreatureConstants.PitFiend,
                CreatureConstants.Planetar,
                CreatureConstants.PurpleWorm,
                CreatureConstants.Pyrohydra,
                CreatureConstants.Quasit,
                CreatureConstants.Rat_Dire,
                CreatureConstants.RustMonster,
                CreatureConstants.Salamander_Noble,
                CreatureConstants.Salamander_Average,
                CreatureConstants.Salamander_Flamebrother,
                CreatureConstants.Scorpion_Monstrous_Colossal,
                CreatureConstants.Scorpion_Monstrous_Medium,
                CreatureConstants.Scorpion_Monstrous_Small,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Shrieker,
                CreatureConstants.Skeleton_Giant,
                CreatureConstants.Skeleton_HumanWarrior,
                CreatureConstants.Slaad_Death,
                CreatureConstants.Slaad_Green,
                CreatureConstants.Snake_Constrictor_Giant,
                CreatureConstants.Snake_Viper_Huge,
                CreatureConstants.Snake_Viper_Tiny,
                CreatureConstants.Solar,
                CreatureConstants.SpiderEater,
                CreatureConstants.Spider_Monstrous_Huge,
                CreatureConstants.Spider_Monstrous_Medium,
                CreatureConstants.Spider_Monstrous_Small,
                CreatureConstants.Stirge,
                CreatureConstants.Troglodyte,
                CreatureConstants.VampireSpawn,
                CreatureConstants.Vampire,
                CreatureConstants.VioletFungus,
                CreatureConstants.Vrock,
                CreatureConstants.Weasel_Dire,
                CreatureConstants.Wererat,
                CreatureConstants.Wight,
                CreatureConstants.Wolverine_Dire,
                CreatureConstants.Worg,
                CreatureConstants.Wraith,
                CreatureConstants.Yrthak,
                CreatureConstants.Zombie_HumanCommoner
            };

            AssertEntriesAreComplete(entries);
        }


        [TestCase(CreatureConstants.Allip, 0, 0, 0)]
        [TestCase(CreatureConstants.Ankheg, 0, 0, 0)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier, 0, 0, 0)]
        [TestCase(CreatureConstants.Ant_Giant_Worker, 0, 0, 0)]
        [TestCase(CreatureConstants.AstralDeva, 0, 2, 1)]
        [TestCase(CreatureConstants.Azer, 1, 2, 1)]
        [TestCase(CreatureConstants.Balor, 1, 2, 1)]
        [TestCase(CreatureConstants.Beholder, 2, 2, 2)]
        [TestCase(CreatureConstants.BlinkDog, 0, 0, 0)]
        [TestCase(CreatureConstants.Boar_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Bugbear, 1, 1, 1)]
        [TestCase(CreatureConstants.CarrionCrawler, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Character, 0, 0, 0)]
        [TestCase(CreatureConstants.Choker, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Cockatrice, 0, 0, 0)]
        [TestCase(CreatureConstants.Cornugon, 1, 2, 1)]
        [TestCase(CreatureConstants.Cryohydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Darkmantle, 0, 0, 0)]
        [TestCase(CreatureConstants.Doppelganger, 2, 2, 2)]
        [TestCase(CreatureConstants.Dragon, 3, 3, 3)]
        [TestCase(CreatureConstants.DwarfWarrior, 1, 2, 1)]
        [TestCase(CreatureConstants.ElfWarrior, 1, 1, 1)]
        [TestCase(CreatureConstants.EtherealMarauder, 0, 0, 0)]
        [TestCase(CreatureConstants.Ettercap, 1, 1, 1)]
        [TestCase(CreatureConstants.FireBeetle_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.FormianWarrior, 0, 0, 0)]
        [TestCase(CreatureConstants.FormianWorker, 0, 0, 0)]
        [TestCase(CreatureConstants.Gelugon, 1, 2, 1)]
        [TestCase(CreatureConstants.Ghaele, 0, 2, 1)]
        [TestCase(CreatureConstants.Ghast, 1, 1, 1)]
        [TestCase(CreatureConstants.Ghost, 0, 0, 0)]
        [TestCase(CreatureConstants.Ghoul, 0, 0, 0)]
        [TestCase(CreatureConstants.Giant_Cloud, 2, 1, 2)]
        [TestCase(CreatureConstants.Giant_Frost, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Storm, 2, 1, 2)]
        [TestCase(CreatureConstants.GibberingMouther, 0, 0, 0)]
        [TestCase(CreatureConstants.Glabrezu, 1, 2, 1)]
        [TestCase(CreatureConstants.Gnoll, 1, 1, 1)]
        [TestCase(CreatureConstants.Goblin, 1, 1, 1)]
        [TestCase(CreatureConstants.Golem_Stone, 0, 0, 0)]
        [TestCase(CreatureConstants.GreenHag, 1, 1, 1)]
        [TestCase(CreatureConstants.Grick, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Hamatula, 1, 1, 1)]
        [TestCase(CreatureConstants.Hezrou, 1, 1, 1)]
        [TestCase(CreatureConstants.Hobgoblin, 1, 1, 1)]
        [TestCase(CreatureConstants.Hydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Hyena, 0, 0, 0)]
        [TestCase(CreatureConstants.Imp, 0, 0, 0)]
        [TestCase(CreatureConstants.Kobold, 1, 1, 1)]
        [TestCase(CreatureConstants.Krenshar, 0, 0, 0)]
        [TestCase(CreatureConstants.LanternArchon, 0, 0, 0)]
        [TestCase(CreatureConstants.Lemure, 0, 0, 0)]
        [TestCase(CreatureConstants.Lich, 0, 0, 0)]
        [TestCase(CreatureConstants.Lion_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Lizardfolk, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Lizard_Monitor, 0, 0, 0)]
        [TestCase(CreatureConstants.Magmin, 1, 1, 1)]
        [TestCase(CreatureConstants.Marilith, 2, 1, 2)]
        [TestCase(CreatureConstants.Mephit, 1, 1, 1)]
        [TestCase(CreatureConstants.Mimic, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.MindFlayer, 2, 2, 2)]
        [TestCase(CreatureConstants.Mummy, 1, 1, 1)]
        [TestCase(CreatureConstants.Naga_Spirit, 1, 1, 1)]
        [TestCase(CreatureConstants.Nalfeshnee, 2, 1, 2)]
        [TestCase(CreatureConstants.Nightcrawler, 1, 1, 1)]
        [TestCase(CreatureConstants.Nightmare, 0, 0, 0)]
        [TestCase(CreatureConstants.Nightwalker, 1, 1, 1)]
        [TestCase(CreatureConstants.Ogre, 1, 1, 1)]
        [TestCase(CreatureConstants.Ooze_Gray, 0, 0, 0)]
        [TestCase(CreatureConstants.Ooze_OchreJelly, 0, 0, 0)]
        [TestCase(CreatureConstants.Orc, 1, 1, 1)]
        [TestCase(CreatureConstants.PitFiend, 2, 1, 2)]
        [TestCase(CreatureConstants.Planetar, 0, 2, 1)]
        [TestCase(CreatureConstants.PurpleWorm, 0, TreasureConstants.FiftyPercent, 0)]
        [TestCase(CreatureConstants.Pyrohydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Quasit, 0, 0, 0)]
        [TestCase(CreatureConstants.Rat_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.RustMonster, 0, 0, 0)]
        [TestCase(CreatureConstants.Salamander_Noble, 2, 2, 2)]
        [TestCase(CreatureConstants.Salamander_Average, 1, 1, 1)]
        [TestCase(CreatureConstants.Salamander_Flamebrother, 1, 1, 1)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, 0, 0, 0)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.ShockerLizard, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Shrieker, 0, 0, 0)]
        [TestCase(CreatureConstants.Skeleton_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Skeleton_HumanWarrior, 0, 0, 0)]
        [TestCase(CreatureConstants.Slaad_Death, 2, 2, 2)]
        [TestCase(CreatureConstants.Slaad_Green, 1, 1, 1)]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.Solar, 0, 2, 1)]
        [TestCase(CreatureConstants.SpiderEater, 0, 0, 0)]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Spider_Monstrous_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Stirge, 0, 0, 0)]
        [TestCase(CreatureConstants.Troglodyte, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.VampireSpawn, 1, 1, 1)]
        [TestCase(CreatureConstants.Vampire, 0, 0, 0)]
        [TestCase(CreatureConstants.VioletFungus, 0, 0, 0)]
        [TestCase(CreatureConstants.Vrock, 1, 1, 1)]
        [TestCase(CreatureConstants.Weasel_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Wererat, 1, 1, 1)]
        [TestCase(CreatureConstants.Wight, 0, 0, 0)]
        [TestCase(CreatureConstants.Wolverine_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Worg, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Wraith, 0, 0, 0)]
        [TestCase(CreatureConstants.Yrthak, 0, 0, 0)]
        [TestCase(CreatureConstants.Zombie_HumanCommoner, 0, 0, 0)]
        public void Adjustments(String entry, Double coin, Double goods, Double items)
        {
            var collection = new[]
            {
                Convert.ToString(coin),
                Convert.ToString(goods),
                Convert.ToString(items)
            };

            base.OrderedCollection(entry, collection);
        }
    }
}
