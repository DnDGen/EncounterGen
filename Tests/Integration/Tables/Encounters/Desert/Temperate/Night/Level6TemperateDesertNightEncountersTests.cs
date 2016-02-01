using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Desert.Temperate.Night
{
    [TestFixture]
    public class Level6TemperateDesertNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 6, EnvironmentConstants.TemperateDesertNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.Lamia, RollConstants.One)]
        [TestCase(5, 8, CreatureConstants.Annis, RollConstants.One)]
        [TestCase(9, 12, CreatureConstants.Beholder, RollConstants.One)]
        [TestCase(13, 16, CreatureConstants.Ogre, RollConstants.OneD3Plus1)]
        [TestCase(17, 20, CreatureConstants.Wererat, RollConstants.OneD3Plus1,
            CreatureConstants.Rat_Dire, RollConstants.OneD6Plus3)]
        [TestCase(21, 24, CreatureConstants.Centipede_Monstrous_Gargantuan, RollConstants.One)]
        [TestCase(25, 28, CreatureConstants.Cockatrice, RollConstants.OneD3Plus1)]
        [TestCase(29, 32, CreatureConstants.Digester, RollConstants.One)]
        [TestCase(33, 36, CreatureConstants.Manticore, RollConstants.OneD2)]
        [TestCase(37, 40, CreatureConstants.Scorpion_Monstrous_Large, RollConstants.OneD3Plus1)]
        [TestCase(41, 44, CreatureConstants.Wasp_Giant, RollConstants.OneD3Plus1)]
        [TestCase(45, 46, CreatureConstants.Arrowhawk_Juvenile, RollConstants.OneD3Plus1)]
        [TestCase(47, 48, CreatureConstants.Barbazu, RollConstants.OneD2)]
        [TestCase(49, 50, CreatureConstants.Belker, RollConstants.One)]
        [TestCase(51, 52, CreatureConstants.FormianWarrior, RollConstants.OneD3Plus1)]
        [TestCase(53, 54, CreatureConstants.Howler, RollConstants.OneD3Plus1)]
        [TestCase(55, 56, CreatureConstants.Kyton, RollConstants.One)]
        [TestCase(57, 58, CreatureConstants.Magmin, RollConstants.OneD3Plus1)]
        [TestCase(59, 60, CreatureConstants.Mephit, RollConstants.OneD3Plus1)]
        [TestCase(61, 62, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD3Plus1)]
        [TestCase(63, 64, CreatureConstants.Salamander_Average, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.Shadow, RollConstants.OneD3Plus1)]
        [TestCase(67, 68, CreatureConstants.ShadowMastiff, RollConstants.OneD2)]
        [TestCase(69, 70, CreatureConstants.Xill, RollConstants.One)]
        [TestCase(71, 72, CreatureConstants.Xorn_Minor, RollConstants.OneD3Plus1)]
        [TestCase(73, 74, CreatureConstants.Xorn_Average, RollConstants.One)]
        [TestCase(75, 78, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(79, 80, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(81, 82, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(85, 86, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(87, 88, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Tiny, RollConstants.OneD4Plus2)]
        [TestCase(89, 90, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Small, RollConstants.OneD2)]
        [TestCase(91, 92, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Medium, RollConstants.One)]
        [TestCase(93, 94, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Large, RollConstants.One)]
        [TestCase(95, 100, CreatureConstants.Character + "[3]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
