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
                CreatureConstants.Achaierais,
                CreatureConstants.Allip,
                CreatureConstants.Ankheg,
                CreatureConstants.Ant_Giant_Soldier,
                CreatureConstants.Ant_Giant_Worker,
                "Astral deva",
                CreatureConstants.Azer,
                "Balor",
                CreatureConstants.Barghest,
                CreatureConstants.Barghest_Greater,
                CreatureConstants.Bat,
                CreatureConstants.Bat_Dire,
                CreatureConstants.Beholder,
                CreatureConstants.BlinkDog,
                CreatureConstants.Boar,
                CreatureConstants.Boar_Dire,
                CreatureConstants.Bugbear,
                CreatureConstants.CarrionCrawler,
                CreatureConstants.Centipede_Monstrous_Colossal,
                CreatureConstants.Centipede_Monstrous_Gargantuan,
                CreatureConstants.Centipede_Monstrous_Huge,
                CreatureConstants.Centipede_Monstrous_Large,
                CreatureConstants.Centipede_Monstrous_Medium,
                CreatureConstants.Centipede_Monstrous_Small,
                CreatureConstants.Centipede_Monstrous_Tiny,
                CreatureConstants.Character,
                CreatureConstants.Chimera,
                CreatureConstants.Choker,
                CreatureConstants.Cockatrice,
                "Cornugon",
                CreatureConstants.Cryohydra,
                CreatureConstants.Darkmantle,
                CreatureConstants.Doppelganger,
                CreatureConstants.Dragon,
                CreatureConstants.DwarfWarrior,
                CreatureConstants.ElfWarrior,
                CreatureConstants.EtherealMarauder,
                CreatureConstants.Ettercap,
                CreatureConstants.Ettin,
                CreatureConstants.FireBeetle_Giant,
                CreatureConstants.FormianWarrior,
                CreatureConstants.FormianWorker,
                CreatureConstants.FrostWorm,
                CreatureConstants.Gargoyle,
                "Gelugon",
                "Ghaele",
                CreatureConstants.Ghast,
                CreatureConstants.Ghost,
                CreatureConstants.Ghoul,
                CreatureConstants.Giant_Cloud,
                CreatureConstants.Giant_Frost,
                CreatureConstants.Giant_Hill,
                CreatureConstants.Giant_Storm,
                CreatureConstants.GibberingMouther,
                "Glabrezu",
                CreatureConstants.Gnoll,
                CreatureConstants.Goblin,
                CreatureConstants.Golem_Stone,
                CreatureConstants.GrayRender,
                "Green hag",
                CreatureConstants.Grick,
                "Hamatula",
                "Hezrou",
                CreatureConstants.Hobgoblin,
                CreatureConstants.HoundArchon,
                CreatureConstants.Howler,
                CreatureConstants.Hydra,
                CreatureConstants.Hyena,
                "Imp",
                CreatureConstants.Kobold,
                CreatureConstants.Krenshar,
                CreatureConstants.Lammasu,
                "Lantern archon",
                "Lemure",
                CreatureConstants.Lich,
                CreatureConstants.Lillend,
                CreatureConstants.Lion_Dire,
                CreatureConstants.Lizardfolk,
                CreatureConstants.Lizard_Monitor,
                CreatureConstants.Magmin,
                "Marilith",
                CreatureConstants.Mephit,
                CreatureConstants.Mimic,
                CreatureConstants.MindFlayer,
                CreatureConstants.Mummy,
                CreatureConstants.Naga_Spirit,
                "Nalfeshnee",
                "Nightcrawler",
                CreatureConstants.Nightmare,
                "Nightwalker",
                CreatureConstants.Ogre,
                CreatureConstants.OgreMage,
                CreatureConstants.Ooze_Gray,
                CreatureConstants.Ooze_OchreJelly,
                CreatureConstants.Orc,
                "Pit fiend",
                "Planetar",
                CreatureConstants.PurpleWorm,
                CreatureConstants.Pyrohydra,
                "Quasit",
                CreatureConstants.Rat_Dire,
                CreatureConstants.RustMonster,
                CreatureConstants.Salamander_Noble,
                CreatureConstants.Salamander_Average,
                CreatureConstants.Salamander_Flamebrother,
                CreatureConstants.Scorpion_Monstrous_Colossal,
                CreatureConstants.Scorpion_Monstrous_Gargantuan,
                CreatureConstants.Scorpion_Monstrous_Huge,
                CreatureConstants.Scorpion_Monstrous_Large,
                CreatureConstants.Scorpion_Monstrous_Medium,
                CreatureConstants.Scorpion_Monstrous_Small,
                CreatureConstants.Scorpion_Monstrous_Tiny,
                CreatureConstants.ShockerLizard,
                CreatureConstants.Shrieker,
                CreatureConstants.Skeleton,
                CreatureConstants.Slaad_Death,
                CreatureConstants.Slaad_Green,
                CreatureConstants.Snake_Constrictor_Giant,
                CreatureConstants.Snake_Viper_Huge,
                CreatureConstants.Snake_Viper_Tiny,
                "Solar",
                CreatureConstants.Spectre,
                CreatureConstants.SpiderEater,
                CreatureConstants.Spider_Monstrous_Colossal,
                CreatureConstants.Spider_Monstrous_Gargantuan,
                CreatureConstants.Spider_Monstrous_Huge,
                CreatureConstants.Spider_Monstrous_Large,
                CreatureConstants.Spider_Monstrous_Medium,
                CreatureConstants.Spider_Monstrous_Small,
                CreatureConstants.Spider_Monstrous_Tiny,
                CreatureConstants.Stirge,
                CreatureConstants.Thoqqua,
                CreatureConstants.Troglodyte,
                CreatureConstants.VampireSpawn,
                CreatureConstants.Vampire,
                CreatureConstants.Vargouille,
                CreatureConstants.VioletFungus,
                "Vrock",
                CreatureConstants.Weasel_Dire,
                CreatureConstants.Werebear,
                CreatureConstants.Wereboar,
                CreatureConstants.Wererat,
                CreatureConstants.Weretiger,
                CreatureConstants.Werewolf,
                CreatureConstants.Wight,
                CreatureConstants.Wolverine_Dire,
                CreatureConstants.Worg,
                CreatureConstants.Wraith,
                CreatureConstants.Yrthak,
                CreatureConstants.Zombie
            };

            AssertEntriesAreComplete(entries);
        }

        [TestCase(CreatureConstants.Achaierais, 2, 2, 2)]
        [TestCase(CreatureConstants.Allip, 0, 0, 0)]
        [TestCase(CreatureConstants.Ankheg, 0, 0, 0)]
        [TestCase(CreatureConstants.Ant_Giant_Soldier, 0, 0, 0)]
        [TestCase(CreatureConstants.Ant_Giant_Worker, 0, 0, 0)]
        [TestCase("Astral deva", 0, 2, 1)]
        [TestCase(CreatureConstants.Azer, 1, 2, 1)]
        [TestCase("Balor", 1, 2, 1)]
        [TestCase(CreatureConstants.Barghest, 2, 2, 2)]
        [TestCase(CreatureConstants.Barghest_Greater, 2, 2, 2)]
        [TestCase(CreatureConstants.Bat, 0, 0, 0)]
        [TestCase(CreatureConstants.Bat_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Beholder, 2, 2, 2)]
        [TestCase(CreatureConstants.BlinkDog, 0, 0, 0)]
        [TestCase(CreatureConstants.Boar, 0, 0, 0)]
        [TestCase(CreatureConstants.Boar_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Bugbear, 1, 1, 1)]
        [TestCase(CreatureConstants.CarrionCrawler, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Colossal, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Gargantuan, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Large, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Centipede_Monstrous_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.Character, 0, 0, 0)]
        [TestCase(CreatureConstants.Chimera, 1, 1, 1)]
        [TestCase(CreatureConstants.Choker, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Cockatrice, 0, 0, 0)]
        [TestCase("Cornugon", 1, 2, 1)]
        [TestCase(CreatureConstants.Cryohydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Darkmantle, 0, 0, 0)]
        [TestCase(CreatureConstants.Doppelganger, 2, 2, 2)]
        [TestCase(CreatureConstants.Dragon, 3, 3, 3)]
        [TestCase(CreatureConstants.DwarfWarrior, 1, 2, 1)]
        [TestCase(CreatureConstants.ElfWarrior, 1, 1, 1)]
        [TestCase(CreatureConstants.EtherealMarauder, 0, 0, 0)]
        [TestCase(CreatureConstants.Ettercap, 1, 1, 1)]
        [TestCase(CreatureConstants.Ettin, 1, 1, 1)]
        [TestCase(CreatureConstants.FireBeetle_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.FormianWarrior, 0, 0, 0)]
        [TestCase(CreatureConstants.FormianWorker, 0, 0, 0)]
        [TestCase(CreatureConstants.FrostWorm, 0, 0, 0)]
        [TestCase(CreatureConstants.Gargoyle, 1, 1, 1)]
        [TestCase("Gelugon", 1, 2, 1)]
        [TestCase("Ghaele", 0, 2, 1)]
        [TestCase(CreatureConstants.Ghast, 1, 1, 1)]
        [TestCase(CreatureConstants.Ghost, 0, 0, 0)]
        [TestCase(CreatureConstants.Ghoul, 0, 0, 0)]
        [TestCase(CreatureConstants.Giant_Cloud, 2, 1, 2)]
        [TestCase(CreatureConstants.Giant_Frost, 1, 1, 1)]
        [TestCase(CreatureConstants.Giant_Storm, 2, 1, 2)]
        [TestCase(CreatureConstants.GibberingMouther, 0, 0, 0)]
        [TestCase("Glabrezu", 1, 2, 1)]
        [TestCase(CreatureConstants.Gnoll, 1, 1, 1)]
        [TestCase(CreatureConstants.Goblin, 1, 1, 1)]
        [TestCase(CreatureConstants.Golem_Stone, 0, 0, 0)]
        [TestCase(CreatureConstants.GrayRender, 0, 0, 0)]
        [TestCase("Green hag", 1, 1, 1)]
        [TestCase(CreatureConstants.Grick, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase("Hamatula", 1, 1, 1)]
        [TestCase("Hezrou", 1, 1, 1)]
        [TestCase(CreatureConstants.Hobgoblin, 1, 1, 1)]
        [TestCase(CreatureConstants.HoundArchon, 0, 2, 1)]
        [TestCase(CreatureConstants.Howler, 0, 0, 0)]
        [TestCase(CreatureConstants.Hydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Hyena, 0, 0, 0)]
        [TestCase("Imp", 0, 0, 0)]
        [TestCase(CreatureConstants.Kobold, 1, 1, 1)]
        [TestCase(CreatureConstants.Krenshar, 0, 0, 0)]
        [TestCase(CreatureConstants.Lammasu, 1, 1, 1)]
        [TestCase("Lantern archon", 0, 0, 0)]
        [TestCase("Lemure", 0, 0, 0)]
        [TestCase(CreatureConstants.Lich, 0, 0, 0)]
        [TestCase(CreatureConstants.Lillend, 1, 1, 1)]
        [TestCase(CreatureConstants.Lion_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Lizardfolk, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Lizard_Monitor, 0, 0, 0)]
        [TestCase(CreatureConstants.Magmin, 1, 1, 1)]
        [TestCase("Marilith", 2, 1, 2)]
        [TestCase(CreatureConstants.Mephit, 1, 1, 1)]
        [TestCase(CreatureConstants.Mimic, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.MindFlayer, 2, 2, 2)]
        [TestCase(CreatureConstants.Mummy, 1, 1, 1)]
        [TestCase(CreatureConstants.Naga_Spirit, 1, 1, 1)]
        [TestCase("Nalfeshnee", 2, 1, 2)]
        [TestCase("Nightcrawler", 1, 1, 1)]
        [TestCase(CreatureConstants.Nightmare, 0, 0, 0)]
        [TestCase("Nightwalker", 1, 1, 1)]
        [TestCase(CreatureConstants.Ogre, 1, 1, 1)]
        [TestCase(CreatureConstants.OgreMage, 2, 2, 2)]
        [TestCase(CreatureConstants.Ooze_Gray, 0, 0, 0)]
        [TestCase(CreatureConstants.Ooze_OchreJelly, 0, 0, 0)]
        [TestCase(CreatureConstants.Orc, 1, 1, 1)]
        [TestCase("Pit fiend", 2, 1, 2)]
        [TestCase("Planetar", 0, 2, 1)]
        [TestCase(CreatureConstants.PurpleWorm, 0, TreasureConstants.FiftyPercent, 0)]
        [TestCase(CreatureConstants.Pyrohydra, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase("Quasit", 0, 0, 0)]
        [TestCase(CreatureConstants.Rat_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.RustMonster, 0, 0, 0)]
        [TestCase(CreatureConstants.Salamander_Noble, 2, 2, 2)]
        [TestCase(CreatureConstants.Salamander_Average, 1, 1, 1)]
        [TestCase(CreatureConstants.Salamander_Flamebrother, 1, 1, 1)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Colossal, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Gargantuan, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Huge, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Large, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Medium, 0, 0, 0)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Scorpion_Monstrous_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.ShockerLizard, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Shrieker, 0, 0, 0)]
        [TestCase(CreatureConstants.Skeleton, 0, 0, 0)]
        [TestCase(CreatureConstants.Slaad_Death, 2, 2, 2)]
        [TestCase(CreatureConstants.Slaad_Green, 1, 1, 1)]
        [TestCase(CreatureConstants.Snake_Constrictor_Giant, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Huge, 0, 0, 0)]
        [TestCase(CreatureConstants.Snake_Viper_Tiny, 0, 0, 0)]
        [TestCase("Solar", 0, 2, 1)]
        [TestCase(CreatureConstants.Spectre, 0, 0, 0)]
        [TestCase(CreatureConstants.SpiderEater, 0, 0, 0)]
        [TestCase(CreatureConstants.Spider_Monstrous_Colossal, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Spider_Monstrous_Gargantuan, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Spider_Monstrous_Huge, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Spider_Monstrous_Large, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Spider_Monstrous_Medium, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Spider_Monstrous_Small, 0, 0, 0)]
        [TestCase(CreatureConstants.Spider_Monstrous_Tiny, 0, 0, 0)]
        [TestCase(CreatureConstants.Stirge, 0, 0, 0)]
        [TestCase(CreatureConstants.Thoqqua, 0, 0, 0)]
        [TestCase(CreatureConstants.Troglodyte, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.VampireSpawn, 1, 1, 1)]
        [TestCase(CreatureConstants.Vampire, 0, 0, 0)]
        [TestCase(CreatureConstants.Vargouille, 0, 0, 0)]
        [TestCase(CreatureConstants.VioletFungus, 0, 0, 0)]
        [TestCase("Vrock", 1, 1, 1)]
        [TestCase(CreatureConstants.Weasel_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Werebear, 1, 1, 1)]
        [TestCase(CreatureConstants.Wereboar, 1, 1, 1)]
        [TestCase(CreatureConstants.Wererat, 1, 1, 1)]
        [TestCase(CreatureConstants.Weretiger, 1, 1, 1)]
        [TestCase(CreatureConstants.Werewolf, 1, 1, 1)]
        [TestCase(CreatureConstants.Wight, 0, 0, 0)]
        [TestCase(CreatureConstants.Wolverine_Dire, 0, 0, 0)]
        [TestCase(CreatureConstants.Worg, TreasureConstants.TenPercent, TreasureConstants.FiftyPercent, TreasureConstants.FiftyPercent)]
        [TestCase(CreatureConstants.Wraith, 0, 0, 0)]
        [TestCase(CreatureConstants.Yrthak, 0, 0, 0)]
        [TestCase(CreatureConstants.Zombie, 0, 0, 0)]
        public void Adjustments(string entry, double coin, double goods, double items)
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
