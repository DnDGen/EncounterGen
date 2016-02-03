using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Desert.Cold.Day
{
    [TestFixture]
    public class Level7ColdDesertDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 7, EnvironmentConstants.ColdDesertDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 2, CreatureConstants.AnimatedObject_Gargantuan, RollConstants.One)]
        [TestCase(3, 4, CreatureConstants.Barbazu, RollConstants.OneD3Plus1)]
        [TestCase(5, 8, CreatureConstants.Beholder, RollConstants.OneD2)]
        [TestCase(9, 10, CreatureConstants.Belker, RollConstants.OneD2)]
        [TestCase(11, 12, CreatureConstants.ChaosBeast, RollConstants.One)]
        [TestCase(13, 16, CreatureConstants.Chimera, RollConstants.One)]
        [TestCase(17, 20, CreatureConstants.Doppelganger, RollConstants.OneD4Plus2)]
        [TestCase(21, 22, CreatureConstants.Elemental_Air_Huge, RollConstants.One)]
        [TestCase(23, 24, CreatureConstants.Elemental_Earth_Huge, RollConstants.One)]
        [TestCase(25, 26, CreatureConstants.Elemental_Fire_Huge, RollConstants.One)]
        [TestCase(27, 28, CreatureConstants.Elemental_Water_Huge, RollConstants.One)]
        [TestCase(29, 30, CreatureConstants.FormianTaskmaster, RollConstants.One)]
        [TestCase(31, 32, CreatureConstants.Golem_Flesh, RollConstants.One)]
        [TestCase(33, 34, CreatureConstants.Hellcat, RollConstants.One)]
        [TestCase(35, 36, CreatureConstants.HoundArchon, RollConstants.OneD3Plus1)]
        [TestCase(37, 38, CreatureConstants.Janni, RollConstants.OneD3Plus1)]
        [TestCase(39, 42, CreatureConstants.Lamia, RollConstants.OneD2)]
        [TestCase(43, 44, CreatureConstants.Lillend, RollConstants.One)]
        [TestCase(45, 48, CreatureConstants.Medusa, RollConstants.One)]
        [TestCase(49, 52, CreatureConstants.Nymph, RollConstants.One)]
        [TestCase(53, 56, CreatureConstants.Phasm, RollConstants.One)]
        [TestCase(57, 60, CreatureConstants.Remorhaz, RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.Salamander_Average, RollConstants.OneD2)]
        [TestCase(63, 64, CreatureConstants.Slaad_Red, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.Succubus, RollConstants.One)]
        [TestCase(67, 68, CreatureConstants.Wight, RollConstants.OneD4Plus2)]
        [TestCase(69, 70, CreatureConstants.Xorn_Average, RollConstants.OneD2)]
        [TestCase(71, 72, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Huge, RollConstants.One)]
        [TestCase(73, 76, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(77, 78, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(79, 80, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(81, 82, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(85, 100, CreatureConstants.Character + "[4]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
