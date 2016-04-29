using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Mountain.Temperate.Day
{
    [TestFixture]
    public class Level4TemperateMountainDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 4, EnvironmentConstants.TemperateMountainDay);
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
        [TestCase(61, 69, CreatureConstants.DisplacerBeast, RollConstants.One)]
        [TestCase(70, 78, CreatureConstants.Griffon, RollConstants.One)]
        [TestCase(79, 79, CreatureConstants.HoundArchon, RollConstants.One)]
        [TestCase(80, 80, CreatureConstants.Barghest, RollConstants.One)]
        [TestCase(81, 81, CreatureConstants.HellHound, RollConstants.OneD2)]
        [TestCase(82, 82, CreatureConstants.Janni, RollConstants.One)]
        [TestCase(83, 83, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD2)]
        [TestCase(84, 84, CreatureConstants.Wight, RollConstants.OneD2)]
        [TestCase(85, 85, CreatureConstants.Xorn_Minor, RollConstants.OneD2)]
        [TestCase(86, 86, CreatureConstants.YethHound, RollConstants.OneD2)]
        [TestCase(87, 90, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(91, 91, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(92, 92, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(93, 93, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(94, 94, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(95, 100, CreatureConstants.Character + "[2]", RollConstants.OneD3)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
