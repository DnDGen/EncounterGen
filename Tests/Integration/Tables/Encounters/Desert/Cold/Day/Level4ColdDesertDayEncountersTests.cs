using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Desert.Cold.Day
{
    [TestFixture]
    public class Level4ColdDesertDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 4, EnvironmentConstants.ColdDesertDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 3, CreatureConstants.Barghest, RollConstants.One)]
        [TestCase(4, 9, CreatureConstants.Rat_Dire, RollConstants.OneD4Plus10)]
        [TestCase(10, 15, CreatureConstants.Doppelganger, RollConstants.OneD2)]
        [TestCase(16, 21, CreatureConstants.Gargoyle, RollConstants.One)]
        [TestCase(22, 24, CreatureConstants.HellHound, RollConstants.OneD2)]
        [TestCase(25, 27, CreatureConstants.HoundArchon, RollConstants.One)]
        [TestCase(28, 30, CreatureConstants.Janni, RollConstants.One)]
        [TestCase(31, 36, CreatureConstants.Mimic, RollConstants.One)]
        [TestCase(37, 42, CreatureConstants.Ogre, RollConstants.OneD2)]
        [TestCase(43, 48, CreatureConstants.Bear_Polar, RollConstants.One)]
        [TestCase(49, 51, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD2)]
        [TestCase(52, 54, CreatureConstants.Wight, RollConstants.OneD2)]
        [TestCase(55, 57, CreatureConstants.Xorn_Minor, RollConstants.OneD2)]
        [TestCase(58, 60, CreatureConstants.YethHound, RollConstants.OneD2)]
        [TestCase(61, 66, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(67, 69, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(70, 72, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(73, 75, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(76, 78, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(79, 100, CreatureConstants.Character + "[2]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
