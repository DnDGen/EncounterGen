using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Mountain.Cold.Day
{
    [TestFixture]
    public class Level6ColdMountainDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 6, EnvironmentConstants.ColdMountainDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.WinterWolf, RollConstants.OneD2)]
        [TestCase(5, 8, CreatureConstants.Annis, RollConstants.One)]
        [TestCase(9, 12, CreatureConstants.Beholder, RollConstants.One)]
        [TestCase(13, 16, CreatureConstants.Ogre, RollConstants.OneD3Plus1)]
        [TestCase(17, 20, CreatureConstants.Wererat, RollConstants.OneD3Plus1,
            CreatureConstants.Rat_Dire, RollConstants.OneD6Plus3)]
        [TestCase(21, 24, CreatureConstants.Lion_Dire, RollConstants.OneD2)]
        [TestCase(25, 28, CreatureConstants.Werebear, RollConstants.OneD2)]
        [TestCase(29, 32, CreatureConstants.Weretiger, RollConstants.OneD2)]
        [TestCase(33, 50, CreatureConstants.Ettin, RollConstants.One)]
        [TestCase(51, 52, CreatureConstants.Arrowhawk_Juvenile, RollConstants.OneD3Plus1)]
        [TestCase(53, 54, CreatureConstants.Barbazu, RollConstants.OneD2)]
        [TestCase(55, 56, CreatureConstants.Belker, RollConstants.One)]
        [TestCase(57, 58, CreatureConstants.FormianWarrior, RollConstants.OneD3Plus1)]
        [TestCase(59, 60, CreatureConstants.Howler, RollConstants.OneD3Plus1)]
        [TestCase(61, 62, CreatureConstants.Kyton, RollConstants.One)]
        [TestCase(63, 64, CreatureConstants.Magmin, RollConstants.OneD3Plus1)]
        [TestCase(65, 66, CreatureConstants.Mephit, RollConstants.OneD3Plus1)]
        [TestCase(67, 68, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD3Plus1)]
        [TestCase(69, 70, CreatureConstants.Salamander_Average, RollConstants.One)]
        [TestCase(71, 72, CreatureConstants.Xill, RollConstants.One)]
        [TestCase(73, 74, CreatureConstants.Xorn_Minor, RollConstants.OneD3Plus1)]
        [TestCase(75, 76, CreatureConstants.Xorn_Average, RollConstants.One)]
        [TestCase(77, 78, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Tiny, RollConstants.OneD4Plus2)]
        [TestCase(79, 80, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Small, RollConstants.OneD2)]
        [TestCase(81, 82, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Medium, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Large, RollConstants.One)]
        [TestCase(85, 86, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(87, 88, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(89, 92, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(93, 94, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(95, 96, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(97, 100, CreatureConstants.Character + "[3]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
