using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Mountain.Warm.Day
{
    [TestFixture]
    public class Level4WarmMountainDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 4, EnvironmentConstants.WarmMountainDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.Cockatrice, RollConstants.OneD2)]
        [TestCase(5, 8, CreatureConstants.Gnoll, RollConstants.OneD3Plus1,
            CreatureConstants.Hyena, RollConstants.OneD2)]
        [TestCase(9, 12, CreatureConstants.Harpy, RollConstants.One)]
        [TestCase(13, 16, CreatureConstants.Scorpion_Monstrous_Small, RollConstants.OneD6Plus5)]
        [TestCase(17, 20, CreatureConstants.Spider_Monstrous_Small, RollConstants.OneD6Plus5)]
        [TestCase(21, 24, CreatureConstants.Doppelganger, RollConstants.OneD2)]
        [TestCase(25, 28, CreatureConstants.Gargoyle, RollConstants.One)]
        [TestCase(29, 32, CreatureConstants.Mimic, RollConstants.One)]
        [TestCase(33, 36, CreatureConstants.Ogre, RollConstants.OneD2)]
        [TestCase(37, 40, CreatureConstants.Rat_Dire, RollConstants.OneD4Plus10)]
        [TestCase(41, 44, CreatureConstants.Bear_Brown, RollConstants.One)]
        [TestCase(45, 48, CreatureConstants.Eagle_Giant, RollConstants.OneD2)]
        [TestCase(49, 52, CreatureConstants.Owl_Giant, RollConstants.OneD2)]
        [TestCase(53, 56, CreatureConstants.Tiger, RollConstants.One)]
        [TestCase(57, 60, CreatureConstants.Werewolf, RollConstants.OneD2)]
        [TestCase(61, 66, CreatureConstants.Griffon, RollConstants.One)]
        [TestCase(67, 68, CreatureConstants.HoundArchon, RollConstants.One)]
        [TestCase(69, 70, CreatureConstants.Barghest, RollConstants.One)]
        [TestCase(71, 72, CreatureConstants.HellHound, RollConstants.OneD2)]
        [TestCase(73, 74, CreatureConstants.Janni, RollConstants.One)]
        [TestCase(75, 76, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD2)]
        [TestCase(77, 78, CreatureConstants.Wight, RollConstants.OneD2)]
        [TestCase(79, 80, CreatureConstants.Xorn_Minor, RollConstants.OneD2)]
        [TestCase(81, 82, CreatureConstants.YethHound, RollConstants.OneD2)]
        [TestCase(83, 86, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(87, 88, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(89, 90, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(91, 92, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(93, 94, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(95, 100, CreatureConstants.Character + "[2]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
