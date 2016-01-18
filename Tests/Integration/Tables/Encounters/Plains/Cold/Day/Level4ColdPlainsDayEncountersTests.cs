using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Plains.Cold.Day
{
    [TestFixture]
    public class Level4ColdPlainsDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 4, EnvironmentConstants.ColdPlainsDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 2, CreatureConstants.Barghest, RollConstants.One)]
        [TestCase(3, 6, CreatureConstants.Rat_Dire, RollConstants.OneD4Plus10)]
        [TestCase(7, 10, CreatureConstants.Doppelganger, RollConstants.OneD2)]
        [TestCase(11, 14, CreatureConstants.Gargoyle, RollConstants.One)]
        [TestCase(15, 18, CreatureConstants.Eagle_Giant, RollConstants.OneD2)]
        [TestCase(19, 22, CreatureConstants.Owl_Giant, RollConstants.OneD2)]
        [TestCase(23, 24, CreatureConstants.HellHound, RollConstants.OneD2)]
        [TestCase(25, 26, CreatureConstants.HoundArchon, RollConstants.One)]
        [TestCase(27, 28, CreatureConstants.Janni, RollConstants.One)]
        [TestCase(29, 32, CreatureConstants.Mimic, RollConstants.One)]
        [TestCase(33, 36, CreatureConstants.Ogre, RollConstants.OneD2)]
        [TestCase(37, 40, CreatureConstants.Bear_Polar, RollConstants.One)]
        [TestCase(41, 42, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD2)]
        [TestCase(43, 46, CreatureConstants.Tiger, RollConstants.OneD2)]
        [TestCase(47, 50, CreatureConstants.Werewolf, RollConstants.OneD2)]
        [TestCase(51, 52, CreatureConstants.Wight, RollConstants.OneD2)]
        [TestCase(53, 54, CreatureConstants.Xorn_Minor, RollConstants.OneD2)]
        [TestCase(55, 56, CreatureConstants.YethHound, RollConstants.OneD2)]
        [TestCase(57, 60, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(63, 64, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(67, 68, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(69, 100, CreatureConstants.Character + "[2]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
