using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Forest.Warm.Night
{
    [TestFixture]
    public class Level2WarmForestNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 2, EnvironmentConstants.WarmForestNight);
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
        [TestCase(25, 29, CreatureConstants.Bat_Dire, RollConstants.One)]
        [TestCase(30, 30, CreatureConstants.Dretch, RollConstants.One)]
        [TestCase(31, 31, CreatureConstants.FormianWorker, RollConstants.OneD3Plus1)]
        [TestCase(32, 36, CreatureConstants.Ant_Giant_Soldier, RollConstants.One)]
        [TestCase(37, 38, CreatureConstants.Gnoll, RollConstants.OneD2)]
        [TestCase(39, 40, CreatureConstants.Goblin, RollConstants.OneD6Plus3)]
        [TestCase(41, 42, CreatureConstants.Centipede_Monstrous_Huge, RollConstants.One)]
        [TestCase(43, 43, CreatureConstants.Imp, RollConstants.One)]
        [TestCase(44, 45, CreatureConstants.Kobold, RollConstants.OneD6Plus3)]
        [TestCase(46, 50, CreatureConstants.Krenshar, RollConstants.OneD2)]
        [TestCase(51, 51, CreatureConstants.LanternArchon, RollConstants.One)]
        [TestCase(52, 53, CreatureConstants.Spider_Monstrous_Large, RollConstants.One)]
        [TestCase(54, 55, CreatureConstants.Snake_Viper_Large, RollConstants.One)]
        [TestCase(56, 60, CreatureConstants.Leopard, RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.Centipede_Monstrous_Medium, RollConstants.OneD3Plus1)]
        [TestCase(63, 64, CreatureConstants.Lizard_Monitor, RollConstants.OneD2)]
        [TestCase(65, 66, CreatureConstants.Orc, RollConstants.OneD3Plus1)]
        [TestCase(67, 71, CreatureConstants.Pseudodragon, RollConstants.OneD2)]
        [TestCase(72, 72, CreatureConstants.Quasit, RollConstants.One)]
        [TestCase(73, 74, CreatureConstants.Centipede_Monstrous_Small, RollConstants.OneD6Plus5)]
        [TestCase(75, 76, CreatureConstants.Scorpion_Monstrous_Small, RollConstants.OneD3Plus1)]
        [TestCase(77, 78, CreatureConstants.Spider_Monstrous_Small, RollConstants.OneD3Plus1)]
        [TestCase(79, 80, CreatureConstants.Stirge, RollConstants.OneD3Plus1)]
        [TestCase(81, 81, CreatureConstants.Thoqqua, RollConstants.One)]
        [TestCase(82, 83, CreatureConstants.Centipede_Monstrous_Tiny, RollConstants.OneD4Plus10)]
        [TestCase(84, 85, CreatureConstants.Spider_Monstrous_Tiny, RollConstants.OneD4Plus10)]
        [TestCase(86, 87, CreatureConstants.Wererat, RollConstants.One)]
        [TestCase(88, 89, CreatureConstants.Wolf, RollConstants.OneD2)]
        [TestCase(90, 91, CreatureConstants.Worg, RollConstants.One)]
        [TestCase(92, 93, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(94, 94, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(95, 95, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(96, 96, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(97, 97, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(98, 100, CreatureConstants.Character + "[1]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
