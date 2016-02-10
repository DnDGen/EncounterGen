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
        [TestCase(29, 30, CreatureConstants.Golem_Flesh, RollConstants.One)]
        [TestCase(31, 32, CreatureConstants.Hellcat, RollConstants.One)]
        [TestCase(33, 34, CreatureConstants.HoundArchon, RollConstants.OneD3Plus1)]
        [TestCase(35, 36, CreatureConstants.Janni, RollConstants.OneD3Plus1)]
        [TestCase(37, 40, CreatureConstants.Lamia, RollConstants.OneD2)]
        [TestCase(41, 42, CreatureConstants.Lillend, RollConstants.One)]
        [TestCase(43, 46, CreatureConstants.Medusa, RollConstants.One)]
        [TestCase(47, 50, CreatureConstants.Nymph, RollConstants.One)]
        [TestCase(51, 54, CreatureConstants.Phasm, RollConstants.One)]
        [TestCase(55, 58, CreatureConstants.Remorhaz, RollConstants.One)]
        [TestCase(59, 60, CreatureConstants.Salamander_Average, RollConstants.OneD2)]
        [TestCase(61, 62, CreatureConstants.Slaad_Red, RollConstants.One)]
        [TestCase(63, 64, CreatureConstants.Succubus, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.Wight, RollConstants.OneD4Plus2)]
        [TestCase(67, 68, CreatureConstants.Xorn_Average, RollConstants.OneD2)]
        [TestCase(69, 70, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Huge, RollConstants.One)]
        [TestCase(71, 74, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(75, 76, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(77, 78, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(79, 80, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(81, 82, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(83, 100, CreatureConstants.Character + "[4]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
