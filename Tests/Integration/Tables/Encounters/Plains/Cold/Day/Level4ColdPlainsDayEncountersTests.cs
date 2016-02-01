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
        [TestCase(3, 8, CreatureConstants.Rat_Dire, RollConstants.OneD4Plus10)]
        [TestCase(9, 14, CreatureConstants.Doppelganger, RollConstants.OneD2)]
        [TestCase(15, 20, CreatureConstants.Gargoyle, RollConstants.One)]
        [TestCase(21, 26, CreatureConstants.Eagle_Giant, RollConstants.OneD2)]
        [TestCase(27, 32, CreatureConstants.Owl_Giant, RollConstants.OneD2)]
        [TestCase(33, 34, CreatureConstants.HellHound, RollConstants.OneD2)]
        [TestCase(35, 36, CreatureConstants.HoundArchon, RollConstants.One)]
        [TestCase(37, 38, CreatureConstants.Janni, RollConstants.One)]
        [TestCase(39, 44, CreatureConstants.Mimic, RollConstants.One)]
        [TestCase(45, 50, CreatureConstants.Ogre, RollConstants.OneD2)]
        [TestCase(51, 56, CreatureConstants.Bear_Polar, RollConstants.One)]
        [TestCase(57, 58, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD2)]
        [TestCase(59, 64, CreatureConstants.Tiger, RollConstants.OneD2)]
        [TestCase(65, 70, CreatureConstants.Werewolf, RollConstants.OneD2)]
        [TestCase(71, 72, CreatureConstants.Wight, RollConstants.OneD2)]
        [TestCase(73, 74, CreatureConstants.Xorn_Minor, RollConstants.OneD2)]
        [TestCase(75, 76, CreatureConstants.YethHound, RollConstants.OneD2)]
        [TestCase(77, 82, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(85, 86, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(87, 88, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(89, 90, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(91, 100, CreatureConstants.Character + "[2]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
