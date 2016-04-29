using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Warm.Night
{
    [TestFixture]
    public class Level2WarmHillsNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 2, EnvironmentConstants.WarmHillsNight);
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
        [TestCase(4, 4, CreatureConstants.Azer, RollConstants.One)]
        [TestCase(5, 12, CreatureConstants.Bear_Black, RollConstants.One)]
        [TestCase(13, 20, CreatureConstants.Bat_Dire, RollConstants.One)]
        [TestCase(21, 21, CreatureConstants.Dretch, RollConstants.One)]
        [TestCase(22, 22, CreatureConstants.FormianWorker, RollConstants.OneD3Plus1)]
        [TestCase(23, 30, CreatureConstants.Ant_Giant_Soldier, RollConstants.One)]
        [TestCase(31, 33, CreatureConstants.Gnoll, RollConstants.OneD2)]
        [TestCase(34, 36, CreatureConstants.Goblin, RollConstants.OneD6Plus3)]
        [TestCase(37, 42, CreatureConstants.Hippogriff, RollConstants.One)]
        [TestCase(43, 45, CreatureConstants.Centipede_Monstrous_Huge, RollConstants.One)]
        [TestCase(46, 46, CreatureConstants.Imp, RollConstants.One)]
        [TestCase(47, 47, CreatureConstants.LanternArchon, RollConstants.One)]
        [TestCase(48, 50, CreatureConstants.Spider_Monstrous_Large, RollConstants.One)]
        [TestCase(51, 53, CreatureConstants.Snake_Viper_Large, RollConstants.One)]
        [TestCase(54, 56, CreatureConstants.Centipede_Monstrous_Medium, RollConstants.OneD3Plus1)]
        [TestCase(57, 59, CreatureConstants.Lizard_Monitor, RollConstants.OneD2)]
        [TestCase(60, 62, CreatureConstants.Orc, RollConstants.OneD3Plus1)]
        [TestCase(63, 63, CreatureConstants.Quasit, RollConstants.One)]
        [TestCase(64, 66, CreatureConstants.Centipede_Monstrous_Small, RollConstants.OneD6Plus5)]
        [TestCase(67, 69, CreatureConstants.Scorpion_Monstrous_Small, RollConstants.OneD3Plus1)]
        [TestCase(70, 72, CreatureConstants.Spider_Monstrous_Small, RollConstants.OneD3Plus1)]
        [TestCase(73, 73, CreatureConstants.Thoqqua, RollConstants.One)]
        [TestCase(74, 76, CreatureConstants.Centipede_Monstrous_Tiny, RollConstants.OneD4Plus10)]
        [TestCase(77, 79, CreatureConstants.Spider_Monstrous_Tiny, RollConstants.OneD4Plus10)]
        [TestCase(80, 82, CreatureConstants.Wererat, RollConstants.One)]
        [TestCase(83, 85, CreatureConstants.Wolf, RollConstants.OneD2)]
        [TestCase(86, 88, CreatureConstants.Worg, RollConstants.One)]
        [TestCase(89, 91, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(92, 92, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(93, 93, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(94, 94, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(95, 95, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(96, 100, CreatureConstants.Character + "[1]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
