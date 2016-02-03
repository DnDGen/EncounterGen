using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Forest.Cold.Night
{
    [TestFixture]
    public class Level3ColdForestNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 3, EnvironmentConstants.ColdForestNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.Eagle_Giant, RollConstants.One)]
        [TestCase(5, 8, CreatureConstants.Owl_Giant, RollConstants.One)]
        [TestCase(9, 12, CreatureConstants.Grig, RollConstants.OneD3Plus1)]
        [TestCase(13, 16, CreatureConstants.Stirge, RollConstants.OneD6Plus3)]
        [TestCase(17, 20, CreatureConstants.Werewolf, RollConstants.One)]
        [TestCase(21, 24, CreatureConstants.Worg, RollConstants.OneD2)]
        [TestCase(25, 28, CreatureConstants.Wolf_Dire, RollConstants.One)]
        [TestCase(29, 32, CreatureConstants.Doppelganger, RollConstants.One)]
        [TestCase(33, 36, CreatureConstants.Ogre, RollConstants.One)]
        [TestCase(37, 40, CreatureConstants.Wererat, RollConstants.OneD2)]
        [TestCase(41, 42, CreatureConstants.Allip, RollConstants.One)]
        [TestCase(43, 44, CreatureConstants.AnimatedObject_Large, RollConstants.One)]
        [TestCase(45, 46, CreatureConstants.LanternArchon, RollConstants.OneD2)]
        [TestCase(47, 48, CreatureConstants.Arrowhawk_Juvenile, RollConstants.One)]
        [TestCase(49, 50, CreatureConstants.Azer, RollConstants.OneD2)]
        [TestCase(51, 52, CreatureConstants.Dretch, RollConstants.OneD2)]
        [TestCase(53, 54, CreatureConstants.Elemental_Air_Medium, RollConstants.One)]
        [TestCase(55, 56, CreatureConstants.Elemental_Earth_Medium, RollConstants.One)]
        [TestCase(57, 58, CreatureConstants.Elemental_Fire_Medium, RollConstants.One)]
        [TestCase(59, 60, CreatureConstants.Elemental_Water_Medium, RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.EtherealFilcher, RollConstants.One)]
        [TestCase(63, 64, CreatureConstants.FormianWarrior, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.HellHound, RollConstants.One)]
        [TestCase(67, 68, CreatureConstants.Howler, RollConstants.One)]
        [TestCase(69, 70, CreatureConstants.Magmin, RollConstants.One)]
        [TestCase(71, 72, CreatureConstants.Mephit, RollConstants.One)]
        [TestCase(73, 74, CreatureConstants.Salamander_Flamebrother, RollConstants.One)]
        [TestCase(75, 76, CreatureConstants.Shadow, RollConstants.One)]
        [TestCase(77, 78, CreatureConstants.Thoqqua, RollConstants.OneD2)]
        [TestCase(79, 80, CreatureConstants.Wight, RollConstants.One)]
        [TestCase(81, 82, CreatureConstants.Xorn_Minor, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.YethHound, RollConstants.One)]
        [TestCase(85, 88, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(89, 90, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(91, 92, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(93, 94, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(95, 96, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(97, 100, CreatureConstants.Character + "[1]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
