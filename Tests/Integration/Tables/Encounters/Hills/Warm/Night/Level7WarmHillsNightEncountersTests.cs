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
        [TestCase(33, 33, CreatureConstants.FormianTaskmaster, RollConstants.One)]
        [TestCase(34, 36, CreatureConstants.Bee_Giant, RollConstants.OneD4Plus10)]
        [TestCase(37, 39, CreatureConstants.Owl_Giant, RollConstants.OneD4Plus2)]
        [TestCase(40, 43, CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
            CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5)]
        [TestCase(44, 44, CreatureConstants.Golem_Flesh, RollConstants.One)]
        [TestCase(45, 45, CreatureConstants.Hellcat, RollConstants.One)]
        [TestCase(46, 48, CreatureConstants.Giant_Hill, RollConstants.One)]
        [TestCase(49, 49, CreatureConstants.HoundArchon, RollConstants.OneD3Plus1)]
        [TestCase(50, 52, CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.One)]
        [TestCase(53, 53, CreatureConstants.Janni, RollConstants.OneD3Plus1)]
        [TestCase(54, 55, CreatureConstants.Lamia, RollConstants.OneD2)]
        [TestCase(56, 56, CreatureConstants.Lillend, RollConstants.One)]
        [TestCase(57, 59, CreatureConstants.Medusa, RollConstants.One)]
        [TestCase(60, 63, CreatureConstants.Megaraptor, RollConstants.OneD2)]
        [TestCase(64, 65, CreatureConstants.Nymph, RollConstants.One)]
        [TestCase(66, 68, CreatureConstants.Phasm, RollConstants.One)]
        [TestCase(69, 69, CreatureConstants.Salamander_Average, RollConstants.OneD2)]
        [TestCase(70, 70, CreatureConstants.Slaad_Red, RollConstants.One)]
        [TestCase(71, 71, CreatureConstants.Spectre, RollConstants.One)]
        [TestCase(72, 72, CreatureConstants.Succubus, RollConstants.One)]
        [TestCase(73, 75, CreatureConstants.Werewolf, RollConstants.OneD3Plus1,
            CreatureConstants.Wolf, RollConstants.OneD4Plus2)]
        [TestCase(76, 76, CreatureConstants.Wight, RollConstants.OneD4Plus2)]
        [TestCase(77, 79, CreatureConstants.Wolf, RollConstants.OneD4Plus10)]
        [TestCase(80, 83, CreatureConstants.Wyvern, RollConstants.OneD2)]
        [TestCase(84, 84, CreatureConstants.Xorn_Average, RollConstants.OneD2)]
        [TestCase(85, 87, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(88, 88, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(89, 89, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(90, 90, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(91, 91, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(92, 92, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Huge, RollConstants.One)]
        [TestCase(93, 100, CreatureConstants.Character + "[4]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
