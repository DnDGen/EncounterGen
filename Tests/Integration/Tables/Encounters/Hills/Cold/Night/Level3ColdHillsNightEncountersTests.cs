using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Cold.Night
{
    [TestFixture]
    public class Level3ColdHillsNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 3, EnvironmentConstants.ColdHillsNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 2, CreatureConstants.Allip, RollConstants.One)]
        [TestCase(3, 4, CreatureConstants.AnimatedObject_Large, RollConstants.One)]
        [TestCase(5, 6, CreatureConstants.Arrowhawk_Juvenile, RollConstants.One)]
        [TestCase(7, 8, CreatureConstants.Azer, RollConstants.OneD2)]
        [TestCase(9, 12, CreatureConstants.Wolf_Dire, RollConstants.One)]
        [TestCase(13, 16, CreatureConstants.Doppelganger, RollConstants.One)]
        [TestCase(17, 18, CreatureConstants.Dretch, RollConstants.OneD2)]
        [TestCase(19, 20, CreatureConstants.Elemental_Air_Medium, RollConstants.One)]
        [TestCase(21, 22, CreatureConstants.Elemental_Earth_Medium, RollConstants.One)]
        [TestCase(23, 24, CreatureConstants.Elemental_Fire_Medium, RollConstants.One)]
        [TestCase(25, 26, CreatureConstants.Elemental_Water_Medium, RollConstants.One)]
        [TestCase(27, 28, CreatureConstants.EtherealFilcher, RollConstants.One)]
        [TestCase(29, 30, CreatureConstants.FormianWarrior, RollConstants.One)]
        [TestCase(31, 34, CreatureConstants.Eagle_Giant, RollConstants.One)]
        [TestCase(35, 38, CreatureConstants.Owl_Giant, RollConstants.One)]
        [TestCase(39, 40, CreatureConstants.HellHound, RollConstants.One)]
        [TestCase(41, 42, CreatureConstants.Howler, RollConstants.One)]
        [TestCase(43, 44, CreatureConstants.LanternArchon, RollConstants.OneD2)]
        [TestCase(45, 46, CreatureConstants.Magmin, RollConstants.One)]
        [TestCase(47, 48, CreatureConstants.Mephit, RollConstants.One)]
        [TestCase(49, 52, CreatureConstants.Ogre, RollConstants.One)]
        [TestCase(53, 54, CreatureConstants.Salamander_Flamebrother, RollConstants.One)]
        [TestCase(55, 56, CreatureConstants.Shadow, RollConstants.One)]
        [TestCase(57, 58, CreatureConstants.Thoqqua, RollConstants.OneD2)]
        [TestCase(59, 62, CreatureConstants.Wererat, RollConstants.OneD2)]
        [TestCase(63, 66, CreatureConstants.Werewolf, RollConstants.One)]
        [TestCase(67, 68, CreatureConstants.Wight, RollConstants.One)]
        [TestCase(69, 72, CreatureConstants.Worg, RollConstants.OneD2)]
        [TestCase(73, 74, CreatureConstants.Xorn_Minor, RollConstants.One)]
        [TestCase(75, 76, CreatureConstants.YethHound, RollConstants.One)]
        [TestCase(77, 80, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(81, 82, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(85, 86, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(87, 88, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(89, 100, CreatureConstants.Character + "[1]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
