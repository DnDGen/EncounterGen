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
        [TestCase(4, 6, CreatureConstants.Ape, RollConstants.One)]
        [TestCase(7, 7, CreatureConstants.Azer, RollConstants.One)]
        [TestCase(8, 10, CreatureConstants.Bear_Black, RollConstants.One)]
        [TestCase(11, 13, CreatureConstants.Boar, RollConstants.One)]
        [TestCase(14, 16, CreatureConstants.Snake_Constrictor, RollConstants.One)]
        [TestCase(17, 19, CreatureConstants.Bat_Dire, RollConstants.One)]
        [TestCase(20, 20, CreatureConstants.Dretch, RollConstants.One)]
        [TestCase(21, 21, CreatureConstants.FormianWorker, RollConstants.OneD3Plus1)]
        [TestCase(22, 24, CreatureConstants.Ant_Giant_Soldier, RollConstants.One)]
        [TestCase(25, 26, CreatureConstants.Gnoll, RollConstants.OneD2)]
        [TestCase(27, 28, CreatureConstants.Goblin, RollConstants.OneD6Plus3)]
        [TestCase(29, 30, CreatureConstants.Centipede_Monstrous_Huge, RollConstants.One)]
        [TestCase(31, 31, CreatureConstants.Imp, RollConstants.One)]
        [TestCase(32, 33, CreatureConstants.Kobold, RollConstants.OneD6Plus3)]
        [TestCase(34, 36, CreatureConstants.Krenshar, RollConstants.OneD2)]
        [TestCase(37, 37, CreatureConstants.LanternArchon, RollConstants.One)]
        [TestCase(38, 39, CreatureConstants.Spider_Monstrous_Large, RollConstants.One)]
        [TestCase(40, 41, CreatureConstants.Snake_Viper_Large, RollConstants.One)]
        [TestCase(42, 44, CreatureConstants.Leopard, RollConstants.One)]
        [TestCase(45, 46, CreatureConstants.Centipede_Monstrous_Medium, RollConstants.OneD3Plus1)]
        [TestCase(47, 48, CreatureConstants.Lizard_Monitor, RollConstants.OneD2)]
        [TestCase(49, 50, CreatureConstants.Orc, RollConstants.OneD3Plus1)]
        [TestCase(51, 53, CreatureConstants.Pseudodragon, RollConstants.OneD2)]
        [TestCase(54, 54, CreatureConstants.Quasit, RollConstants.One)]
        [TestCase(55, 56, CreatureConstants.Centipede_Monstrous_Small, RollConstants.OneD6Plus5)]
        [TestCase(57, 58, CreatureConstants.Scorpion_Monstrous_Small, RollConstants.OneD3Plus1)]
        [TestCase(59, 60, CreatureConstants.Spider_Monstrous_Small, RollConstants.OneD3Plus1)]
        [TestCase(61, 62, CreatureConstants.Stirge, RollConstants.OneD3Plus1)]
        [TestCase(63, 63, CreatureConstants.Thoqqua, RollConstants.One)]
        [TestCase(64, 65, CreatureConstants.Centipede_Monstrous_Tiny, RollConstants.OneD4Plus10)]
        [TestCase(66, 67, CreatureConstants.Spider_Monstrous_Tiny, RollConstants.OneD4Plus10)]
        [TestCase(68, 69, CreatureConstants.Wererat, RollConstants.One)]
        [TestCase(70, 71, CreatureConstants.Wolf, RollConstants.OneD2)]
        [TestCase(72, 73, CreatureConstants.Worg, RollConstants.One)]
        [TestCase(74, 75, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(76, 76, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(77, 77, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(78, 78, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(79, 79, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(80, 100, CreatureConstants.Character + "1", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
