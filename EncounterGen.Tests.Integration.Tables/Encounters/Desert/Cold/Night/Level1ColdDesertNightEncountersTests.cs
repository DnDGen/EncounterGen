using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Desert.Cold.Night
{
    [TestFixture]
    public class Level1ColdDesertNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 1, EnvironmentConstants.ColdDesertNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 12, CreatureConstants.Rat_Dire, RollConstants.One)]
        [TestCase(13, 18, CreatureConstants.Elemental_Air_Small, RollConstants.One)]
        [TestCase(19, 24, CreatureConstants.Elemental_Earth_Small, RollConstants.One)]
        [TestCase(25, 30, CreatureConstants.Elemental_Fire_Small, RollConstants.One)]
        [TestCase(31, 36, CreatureConstants.Elemental_Water_Small, RollConstants.One)]
        [TestCase(37, 42, CreatureConstants.Homunculus, RollConstants.One)]
        [TestCase(43, 54, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(55, 60, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(61, 66, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(67, 72, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(73, 78, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(79, 100, CreatureConstants.Character + "[1]", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
