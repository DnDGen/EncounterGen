using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Cold.Night
{
    [TestFixture]
    public class Level1ColdHillsNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 1, EnvironmentConstants.ColdHillsNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 10, CreatureConstants.Rat_Dire, RollConstants.One)]
        [TestCase(11, 20, CreatureConstants.Eagle, RollConstants.OneD2)]
        [TestCase(21, 25, CreatureConstants.Elemental_Air_Small, RollConstants.One)]
        [TestCase(26, 30, CreatureConstants.Elemental_Earth_Small, RollConstants.One)]
        [TestCase(31, 35, CreatureConstants.Elemental_Fire_Small, RollConstants.One)]
        [TestCase(36, 40, CreatureConstants.Elemental_Water_Small, RollConstants.One)]
        [TestCase(41, 45, CreatureConstants.Homunculus, RollConstants.One)]
        [TestCase(46, 55, CreatureConstants.Wolf, RollConstants.One)]
        [TestCase(56, 65, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(66, 70, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(71, 75, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(76, 80, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(81, 85, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(86, 100, CreatureConstants.Character + "[1]", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
