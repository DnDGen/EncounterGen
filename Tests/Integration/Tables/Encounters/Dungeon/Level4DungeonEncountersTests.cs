using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level4DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 4, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.Ankheg, RollConstants.OneD2)]
        [TestCase(5, 8, CreatureConstants.Weasel_Dire, RollConstants.OneD3)]
        [TestCase(9, 12, CreatureConstants.Ooze_Gray, RollConstants.One)]
        [TestCase(13, 15, CreatureConstants.Snake_Viper_Huge, RollConstants.OneD2)]
        [TestCase(16, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 23, CreatureConstants.FormianWarrior, RollConstants.One,
            CreatureConstants.FormianWorker, RollConstants.OneD3)]
        [TestCase(24, 26, CreatureConstants.Imp, RollConstants.One,
            CreatureConstants.Lemure, RollConstants.OneD3)]
        [TestCase(27, 30, CreatureConstants.Quasit, RollConstants.OneD2)]
        [TestCase(31, 35, CreatureConstants.LanternArchon, RollConstants.OneD3)]
        [TestCase(36, 40, CreatureConstants.Character + "2", RollConstants.OneD3)]
        [TestCase(41, 45, CreatureConstants.CarrionCrawler, RollConstants.One)]
        [TestCase(46, 50, CreatureConstants.Mimic, RollConstants.One)]
        [TestCase(51, 55, CreatureConstants.RustMonster, RollConstants.OneD2)]
        [TestCase(56, 60, CreatureConstants.VioletFungus, RollConstants.OneD2)]
        [TestCase(61, 62, CreatureConstants.Bugbear, RollConstants.One,
            CreatureConstants.Hobgoblin, RollConstants.OneD6Plus3)]
        [TestCase(63, 65, CreatureConstants.Ettercap, RollConstants.One)]
        [TestCase(66, 67, CreatureConstants.Gnoll, RollConstants.OneD3,
            CreatureConstants.Hyena, RollConstants.OneD3)]
        [TestCase(68, 70, CreatureConstants.Lizardfolk, RollConstants.OneD3,
            CreatureConstants.Lizard_Giant, RollConstants.One)]
        [TestCase(71, 73, CreatureConstants.Magmin, RollConstants.OneD2)]
        [TestCase(74, 76, CreatureConstants.Ogre, RollConstants.One,
            CreatureConstants.Orc, RollConstants.OneD4Plus2)]
        [TestCase(77, 78, CreatureConstants.Orc, RollConstants.OneD3,
            CreatureConstants.Boar_Dire, RollConstants.OneD2)]
        [TestCase(79, 80, CreatureConstants.Worg, RollConstants.OneD2,
            CreatureConstants.Goblin, RollConstants.OneD4Plus2)]
        [TestCase(81, 85, CreatureConstants.Allip, RollConstants.OneD2)]
        [TestCase(86, 90, CreatureConstants.Ghost, RollConstants.One)]
        [TestCase(91, 95, CreatureConstants.VampireSpawn, RollConstants.One)]
        [TestCase(96, 100, CreatureConstants.Wight, RollConstants.OneD2)]
        public override void Percentile(Int32 lower, Int32 upper, params String[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
