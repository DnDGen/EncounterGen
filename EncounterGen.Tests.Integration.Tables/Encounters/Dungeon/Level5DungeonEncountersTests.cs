using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level5DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 5, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 2, CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
            CreatureConstants.Ant_Giant_Worker, RollConstants.OneD4Plus2)]
        [TestCase(3, 5, CreatureConstants.Wolverine_Dire, RollConstants.OneD2)]
        [TestCase(6, 9, CreatureConstants.Ooze_OchreJelly, RollConstants.One)]
        [TestCase(10, 11, CreatureConstants.Snake_Constrictor_Giant, RollConstants.One)]
        [TestCase(12, 12, CreatureConstants.Spider_Monstrous_Huge, RollConstants.OneD2)]
        [TestCase(13, 15, CreatureConstants.SpiderEater, RollConstants.One)]
        [TestCase(16, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 23, CreatureConstants.Doppelganger, RollConstants.OneD3)]
        [TestCase(24, 25, CreatureConstants.GreenHag, RollConstants.One)]
        [TestCase(26, 27, CreatureConstants.Mephit, RollConstants.OneD3)]
        [TestCase(28, 30, CreatureConstants.Wererat, RollConstants.OneD3Plus1)]
        [TestCase(31, 35, CreatureConstants.BlinkDog, RollConstants.OneD3Plus1)]
        [TestCase(36, 40, CreatureConstants.Character + "[2]", RollConstants.OneD3Plus1)]
        [TestCase(41, 43, CreatureConstants.Cockatrice, RollConstants.OneD3)]
        [TestCase(44, 47, CreatureConstants.GibberingMouther, RollConstants.One)]
        [TestCase(48, 50, CreatureConstants.Grick, RollConstants.OneD3)]
        [TestCase(51, 52, CreatureConstants.Hydra + " (1d3+4 heads)", RollConstants.One)]
        [TestCase(53, 55, CreatureConstants.Nightmare, RollConstants.One)]
        [TestCase(56, 58, CreatureConstants.ShockerLizard, RollConstants.OneD3Plus1)]
        [TestCase(59, 60, CreatureConstants.VioletFungus, RollConstants.One,
            CreatureConstants.Shrieker, RollConstants.OneD3Plus1)]
        [TestCase(61, 64, CreatureConstants.Azer, RollConstants.OneD3Plus1)]
        [TestCase(65, 67, CreatureConstants.Bugbear, RollConstants.OneD3Plus1)]
        [TestCase(68, 69, CreatureConstants.Ettercap, RollConstants.One,
            CreatureConstants.Spider_Monstrous_Medium, RollConstants.OneD3)]
        [TestCase(70, 72, CreatureConstants.Ogre, RollConstants.OneD3Plus1)]
        [TestCase(73, 75, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD3Plus1)]
        [TestCase(76, 77, CreatureConstants.Troglodyte, RollConstants.OneD3Plus1,
            CreatureConstants.Lizard_Monitor, RollConstants.OneD2)]
        [TestCase(78, 80, CreatureConstants.Worg, RollConstants.OneD3Plus1)]
        [TestCase(81, 85, CreatureConstants.Ghast, RollConstants.One,
            CreatureConstants.Ghoul, RollConstants.OneD3Plus1)]
        [TestCase(86, 90, CreatureConstants.Mummy, RollConstants.OneD3)]
        [TestCase(91, 95, CreatureConstants.Skeleton_HillGiant, RollConstants.OneD3Plus1)]
        [TestCase(96, 100, CreatureConstants.Wraith, RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
