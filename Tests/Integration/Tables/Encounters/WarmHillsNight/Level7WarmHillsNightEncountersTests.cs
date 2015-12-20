using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.WarmHillsNight
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
        [TestCase(11, 15, CreatureConstants.Deinonychus, RollConstants.OneD4Plus2)]
        [TestCase(16, 20, CreatureConstants.Bat_Dire, RollConstants.OneD6Plus3)]
        [TestCase(21, 23, CreatureConstants.Bear_Dire, RollConstants.One)]
        [TestCase(24, 26, CreatureConstants.Doppelganger, RollConstants.OneD4Plus2)]
        [TestCase(27, 31, CreatureConstants.Dragonne, RollConstants.One)]
        [TestCase(32, 32, CreatureConstants.Elemental_Air_Huge, RollConstants.One)]
        [TestCase(33, 33, CreatureConstants.Elemental_Earth_Huge, RollConstants.One)]
        [TestCase(34, 34, CreatureConstants.Elemental_Fire_Huge, RollConstants.One)]
        [TestCase(35, 35, CreatureConstants.Elemental_Water_Huge, RollConstants.One)]
        [TestCase(36, 36, CreatureConstants.FormianTaskmaster, RollConstants.One)]
        [TestCase(37, 39, CreatureConstants.Bee_Giant, RollConstants.OneD4Plus10)]
        [TestCase(40, 42, CreatureConstants.Owl_Giant, RollConstants.OneD4Plus2)]
        [TestCase(43, 47, CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
            CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5)]
        [TestCase(48, 48, CreatureConstants.Golem_Flesh, RollConstants.One)]
        [TestCase(49, 49, CreatureConstants.Hellcat, RollConstants.One)]
        [TestCase(50, 52, CreatureConstants.Giant_Hill, RollConstants.One)]
        [TestCase(53, 53, CreatureConstants.HoundArchon, RollConstants.OneD3Plus1)]
        [TestCase(54, 56, CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.One)]
        [TestCase(57, 57, CreatureConstants.Janni, RollConstants.OneD3Plus1)]
        [TestCase(58, 60, CreatureConstants.Lamia, RollConstants.OneD2)]
        [TestCase(61, 61, CreatureConstants.Lillend, RollConstants.One)]
        [TestCase(62, 64, CreatureConstants.Medusa, RollConstants.One)]
        [TestCase(65, 69, CreatureConstants.Megaraptor, RollConstants.OneD2)]
        [TestCase(70, 72, CreatureConstants.Nymph, RollConstants.One)]
        [TestCase(73, 75, CreatureConstants.Phasm, RollConstants.One)]
        [TestCase(76, 76, CreatureConstants.Salamander_Average, RollConstants.OneD2)]
        [TestCase(77, 77, CreatureConstants.Slaad_Red, RollConstants.One)]
        [TestCase(78, 78, CreatureConstants.Spectre, RollConstants.One)]
        [TestCase(79, 79, CreatureConstants.Succubus, RollConstants.One)]
        [TestCase(80, 82, CreatureConstants.Werewolf, RollConstants.OneD3Plus1,
            CreatureConstants.Wolf, RollConstants.OneD4Plus2)]
        [TestCase(83, 83, CreatureConstants.Wight, RollConstants.OneD4Plus2)]
        [TestCase(84, 86, CreatureConstants.Wolf, RollConstants.OneD4Plus10)]
        [TestCase(87, 91, CreatureConstants.Wyvern, RollConstants.OneD2)]
        [TestCase(92, 92, CreatureConstants.Xorn_Average, RollConstants.OneD2)]
        [TestCase(93, 95, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(96, 96, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(97, 97, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(98, 98, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(99, 99, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(100, 100, CreatureConstants.Character + "4", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
