using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level9DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 9, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, CreatureConstants.Bulette, RollConstants.OneD3)]
        [TestCase(6, 10, CreatureConstants.Lion_Dire, RollConstants.OneD4Plus2)]
        [TestCase(11, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 21, CreatureConstants.Bebilith, RollConstants.One)]
        [TestCase(22, 22, CreatureConstants.Lamia, RollConstants.OneD3Plus1)]
        [TestCase(23, 24, CreatureConstants.MindFlayer, RollConstants.One,
            CreatureConstants.CharmedCreature + "[6]", RollConstants.One)]
        [TestCase(25, 26, CreatureConstants.Erinyes, RollConstants.OneD2)]
        [TestCase(27, 28, CreatureConstants.Medusa, RollConstants.One,
            CreatureConstants.Grimlock, RollConstants.OneD6Plus3)]
        [TestCase(29, 30, CreatureConstants.MindFlayer, RollConstants.One)]
        [TestCase(31, 33, CreatureConstants.OgreMage, RollConstants.One)]
        [TestCase(34, 35, CreatureConstants.YuanTi_Halfblood, RollConstants.One,
            CreatureConstants.YuanTi_Pureblood, RollConstants.OneD3)]
        [TestCase(36, 40, CreatureConstants.Lammasu, RollConstants.One)]
        [TestCase(41, 45, CreatureConstants.Character + "[6]", RollConstants.OneD3Plus1)]
        [TestCase(46, 47, CreatureConstants.Behir, RollConstants.OneD2)]
        [TestCase(48, 49, CreatureConstants.Belker, RollConstants.OneD3Plus1)]
        [TestCase(50, 50, CreatureConstants.Cryohydra + " (1d3+6 heads)", RollConstants.One)]
        [TestCase(51, 52, CreatureConstants.Delver, RollConstants.One)]
        [TestCase(53, 54, CreatureConstants.DragonTurtle, RollConstants.One)]
        [TestCase(55, 55, CreatureConstants.Pyrohydra + " (1d3+6 heads)", RollConstants.One)]
        [TestCase(56, 57, CreatureConstants.WillOWisp, RollConstants.OneD3Plus1)]
        [TestCase(58, 60, CreatureConstants.Wyvern, RollConstants.OneD3Plus1)]
        [TestCase(61, 64, CreatureConstants.Barbazu, RollConstants.One,
            CreatureConstants.Osyluth, RollConstants.OneD2)]
        [TestCase(65, 68, CreatureConstants.Giant_Hill, RollConstants.One,
            CreatureConstants.Wolf_Dire, RollConstants.OneD3)]
        [TestCase(69, 72, CreatureConstants.Kyton, RollConstants.OneD3Plus1)]
        [TestCase(73, 76, CreatureConstants.Osyluth, RollConstants.OneD3Plus1)]
        [TestCase(77, 80, CreatureConstants.Troll, RollConstants.OneD3Plus1,
            CreatureConstants.Boar_Dire, RollConstants.OneD3)]
        [TestCase(81, 90, CreatureConstants.Bodak, RollConstants.OneD2)]
        [TestCase(91, 100, CreatureConstants.Vampire + "[1d2+6]", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
