using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Forest.Warm.Day
{
    [TestFixture]
    public class Level2WarmForestDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 2, EnvironmentConstants.WarmForestDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 1, CreatureConstants.AnimatedObject_Medium, RollConstants.One)]
        [TestCase(2, 2, CreatureConstants.AnimatedObject_Small, RollConstants.OneD2)]
        [TestCase(3, 3, CreatureConstants.AnimatedObject_Tiny, RollConstants.OneD4Plus2)]
        [TestCase(4, 8, CreatureConstants.Ape, RollConstants.One)]
        [TestCase(9, 9, CreatureConstants.Azer, RollConstants.One)]
        [TestCase(10, 14, CreatureConstants.Bear_Black, RollConstants.One)]
        [TestCase(15, 19, CreatureConstants.Boar, RollConstants.One)]
        [TestCase(20, 24, CreatureConstants.Snake_Constrictor, RollConstants.One)]
        [TestCase(25, 25, CreatureConstants.Dretch, RollConstants.One)]
        [TestCase(26, 26, CreatureConstants.FormianWorker, RollConstants.OneD3Plus1)]
        [TestCase(27, 31, CreatureConstants.Ant_Giant_Soldier, RollConstants.One)]
        [TestCase(32, 33, CreatureConstants.Gnoll, RollConstants.OneD2)]
        [TestCase(34, 35, CreatureConstants.Goblin, RollConstants.OneD6Plus3)]
        [TestCase(36, 37, CreatureConstants.Centipede_Monstrous_Huge, RollConstants.One)]
        [TestCase(38, 38, CreatureConstants.Imp, RollConstants.One)]
        [TestCase(39, 40, CreatureConstants.Kobold, RollConstants.OneD6Plus3)]
        [TestCase(41, 45, CreatureConstants.Krenshar, RollConstants.OneD2)]
        [TestCase(46, 46, CreatureConstants.LanternArchon, RollConstants.One)]
        [TestCase(47, 48, CreatureConstants.Spider_Monstrous_Large, RollConstants.One)]
        [TestCase(49, 50, CreatureConstants.Snake_Viper_Large, RollConstants.One)]
        [TestCase(51, 55, CreatureConstants.Leopard, RollConstants.One)]
        [TestCase(56, 57, CreatureConstants.Centipede_Monstrous_Medium, RollConstants.OneD3Plus1)]
        [TestCase(58, 59, CreatureConstants.Lizard_Monitor, RollConstants.OneD2)]
        [TestCase(60, 61, CreatureConstants.Orc, RollConstants.OneD3Plus1)]
        [TestCase(62, 66, CreatureConstants.Pseudodragon, RollConstants.OneD2)]
        [TestCase(67, 67, CreatureConstants.Quasit, RollConstants.One)]
        [TestCase(68, 69, CreatureConstants.Centipede_Monstrous_Small, RollConstants.OneD6Plus5)]
        [TestCase(70, 71, CreatureConstants.Scorpion_Monstrous_Small, RollConstants.OneD3Plus1)]
        [TestCase(72, 73, CreatureConstants.Spider_Monstrous_Small, RollConstants.OneD3Plus1)]
        [TestCase(74, 75, CreatureConstants.Stirge, RollConstants.OneD3Plus1)]
        [TestCase(76, 76, CreatureConstants.Thoqqua, RollConstants.One)]
        [TestCase(77, 78, CreatureConstants.Centipede_Monstrous_Tiny, RollConstants.OneD4Plus10)]
        [TestCase(79, 80, CreatureConstants.Spider_Monstrous_Tiny, RollConstants.OneD4Plus10)]
        [TestCase(81, 82, CreatureConstants.Wererat, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.Wolf, RollConstants.OneD2)]
        [TestCase(85, 86, CreatureConstants.Worg, RollConstants.One)]
        [TestCase(87, 88, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(89, 89, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(90, 90, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(91, 91, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(92, 92, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(93, 100, CreatureConstants.Character + "[1]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
