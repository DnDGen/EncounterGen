using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Warm.Night
{
    [TestFixture]
    public class Level7WarmHillsNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 7, EnvironmentConstants.WarmHillsNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 1, CreatureConstants.AnimatedObject_Gargantuan, RollConstants.One)]
        [TestCase(2, 2, CreatureConstants.Barbazu, RollConstants.OneD3Plus1)]
        [TestCase(3, 5, CreatureConstants.Beholder, RollConstants.OneD2)]
        [TestCase(6, 6, CreatureConstants.Belker, RollConstants.OneD2)]
        [TestCase(7, 7, CreatureConstants.ChaosBeast, RollConstants.One)]
        [TestCase(8, 10, CreatureConstants.Chimera, RollConstants.One)]
        [TestCase(11, 14, CreatureConstants.Deinonychus, RollConstants.OneD4Plus2)]
        [TestCase(15, 18, CreatureConstants.Bat_Dire, RollConstants.OneD6Plus3)]
        [TestCase(19, 21, CreatureConstants.Bear_Dire, RollConstants.One)]
        [TestCase(22, 24, CreatureConstants.Doppelganger, RollConstants.OneD4Plus2)]
        [TestCase(25, 28, CreatureConstants.Dragonne, RollConstants.One)]
        [TestCase(29, 29, CreatureConstants.Elemental_Air_Huge, RollConstants.One)]
        [TestCase(30, 30, CreatureConstants.Elemental_Earth_Huge, RollConstants.One)]
        [TestCase(31, 31, CreatureConstants.Elemental_Fire_Huge, RollConstants.One)]
        [TestCase(32, 32, CreatureConstants.Elemental_Water_Huge, RollConstants.One)]
        [TestCase(33, 35, CreatureConstants.Bee_Giant, RollConstants.OneD4Plus10)]
        [TestCase(36, 38, CreatureConstants.Owl_Giant, RollConstants.OneD4Plus2)]
        [TestCase(39, 42, CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
            CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5)]
        [TestCase(43, 43, CreatureConstants.Golem_Flesh, RollConstants.One)]
        [TestCase(44, 44, CreatureConstants.Hellcat, RollConstants.One)]
        [TestCase(45, 47, CreatureConstants.Giant_Hill, RollConstants.One)]
        [TestCase(48, 48, CreatureConstants.HoundArchon, RollConstants.OneD3Plus1)]
        [TestCase(49, 51, CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.One)]
        [TestCase(52, 52, CreatureConstants.Janni, RollConstants.OneD3Plus1)]
        [TestCase(53, 54, CreatureConstants.Lamia, RollConstants.OneD2)]
        [TestCase(55, 55, CreatureConstants.Lillend, RollConstants.One)]
        [TestCase(56, 58, CreatureConstants.Medusa, RollConstants.One)]
        [TestCase(59, 62, CreatureConstants.Megaraptor, RollConstants.OneD2)]
        [TestCase(63, 64, CreatureConstants.Nymph, RollConstants.One)]
        [TestCase(65, 67, CreatureConstants.Phasm, RollConstants.One)]
        [TestCase(68, 68, CreatureConstants.Salamander_Average, RollConstants.OneD2)]
        [TestCase(69, 69, CreatureConstants.Slaad_Red, RollConstants.One)]
        [TestCase(70, 70, CreatureConstants.Spectre, RollConstants.One)]
        [TestCase(71, 71, CreatureConstants.Succubus, RollConstants.One)]
        [TestCase(72, 74, CreatureConstants.Werewolf, RollConstants.OneD3Plus1,
            CreatureConstants.Wolf, RollConstants.OneD4Plus2)]
        [TestCase(75, 75, CreatureConstants.Wight, RollConstants.OneD4Plus2)]
        [TestCase(76, 78, CreatureConstants.Wolf, RollConstants.OneD4Plus10)]
        [TestCase(79, 82, CreatureConstants.Wyvern, RollConstants.OneD2)]
        [TestCase(83, 83, CreatureConstants.Xorn_Average, RollConstants.OneD2)]
        [TestCase(84, 84, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Huge, RollConstants.One)]
        [TestCase(85, 87, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(88, 88, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(89, 89, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(90, 90, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(91, 91, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(92, 100, CreatureConstants.Character + "[4]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
