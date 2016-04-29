using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level8DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 8, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 3, CreatureConstants.Ant_Giant_Soldier, RollConstants.OneD6Plus5)]
        [TestCase(4, 8, CreatureConstants.Bat_Dire, RollConstants.OneD6Plus5)]
        [TestCase(9, 10, CreatureConstants.Spider_Monstrous_Gargantuan, RollConstants.OneD2)]
        [TestCase(11, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 22, CreatureConstants.Aboleth, RollConstants.One,
            CreatureConstants.Skum, RollConstants.OneD3Plus1)]
        [TestCase(23, 24, CreatureConstants.Barghest_Greater, RollConstants.OneD3Plus1)]
        [TestCase(25, 26, CreatureConstants.Erinyes, RollConstants.OneD2)]
        [TestCase(27, 28, CreatureConstants.Medusa, RollConstants.One,
            CreatureConstants.Grimlock, RollConstants.OneD6Plus3)]
        [TestCase(29, 30, CreatureConstants.MindFlayer, RollConstants.One)]
        [TestCase(31, 33, CreatureConstants.OgreMage, RollConstants.One)]
        [TestCase(34, 35, CreatureConstants.YuanTi_Halfblood, RollConstants.One,
            CreatureConstants.YuanTi_Pureblood, RollConstants.OneD3)]
        [TestCase(36, 40, CreatureConstants.Lammasu, RollConstants.One)]
        [TestCase(41, 45, CreatureConstants.Character + "[5]", RollConstants.OneD3Plus1)]
        [TestCase(46, 47, CreatureConstants.Achaierais, RollConstants.OneD3Plus1)]
        [TestCase(48, 48, CreatureConstants.Arrowhawk_Adult, RollConstants.OneD3Plus1)]
        [TestCase(49, 50, CreatureConstants.Girallon, RollConstants.OneD3Plus1)]
        [TestCase(51, 52, CreatureConstants.Golem_Flesh, RollConstants.OneD2)]
        [TestCase(53, 54, CreatureConstants.GrayRender, RollConstants.One)]
        [TestCase(55, 56, CreatureConstants.Hieracosphinx, RollConstants.OneD3Plus1)]
        [TestCase(57, 60, CreatureConstants.Hydra + " (1d3+7 heads)", RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.PhaseSpider, RollConstants.OneD3Plus1)]
        [TestCase(63, 64, CreatureConstants.Rast, RollConstants.OneD3Plus1)]
        [TestCase(65, 66, CreatureConstants.ShadowMastiff, RollConstants.OneD3Plus1)]
        [TestCase(67, 68, CreatureConstants.WinterWolf, RollConstants.OneD3Plus1)]
        [TestCase(69, 70, CreatureConstants.Xorn_Average, RollConstants.OneD3)]
        [TestCase(71, 74, CreatureConstants.Drider, RollConstants.One,
            CreatureConstants.Spider_Monstrous_Large, RollConstants.OneD3Plus1)]
        [TestCase(75, 78, CreatureConstants.Ettin, RollConstants.OneD3Plus1)]
        [TestCase(79, 82, CreatureConstants.Manticore, RollConstants.OneD3Plus1)]
        [TestCase(83, 86, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD3Plus1)]
        [TestCase(87, 90, CreatureConstants.Troll, RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Spectre, RollConstants.OneD2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
