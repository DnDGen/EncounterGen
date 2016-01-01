using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Desert.Warm.Night
{
    [TestFixture]
    public class Level1WarmDesertNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 1, EnvironmentConstants.WarmDesertNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 9, CreatureConstants.Baboon, RollConstants.One)]
        [TestCase(10, 14, CreatureConstants.Rat_Dire, RollConstants.One)]
        [TestCase(15, 19, CreatureConstants.Dog, RollConstants.One)]
        [TestCase(20, 21, CreatureConstants.Elemental_Air_Small, RollConstants.One)]
        [TestCase(22, 23, CreatureConstants.Elemental_Earth_Small, RollConstants.One)]
        [TestCase(24, 28, CreatureConstants.Elemental_Fire_Small, RollConstants.One)]
        [TestCase(29, 30, CreatureConstants.Elemental_Water_Small, RollConstants.One)]
        [TestCase(31, 35, CreatureConstants.Bee_Giant, RollConstants.One)]
        [TestCase(36, 40, CreatureConstants.FireBeetle_Giant, RollConstants.OneD3Plus1)]
        [TestCase(41, 45, CreatureConstants.Gnoll, RollConstants.One)]
        [TestCase(46, 47, CreatureConstants.Homunculus, RollConstants.One)]
        [TestCase(48, 52, CreatureConstants.Centipede_Monstrous_Large, RollConstants.One)]
        [TestCase(53, 57, CreatureConstants.Centipede_Monstrous_Medium, RollConstants.One)]
        [TestCase(58, 62, CreatureConstants.Scorpion_Monstrous_Medium, RollConstants.One)]
        [TestCase(63, 67, CreatureConstants.Spider_Monstrous_Medium, RollConstants.One)]
        [TestCase(68, 72, CreatureConstants.Snake_Viper_Small, RollConstants.One)]
        [TestCase(73, 77, CreatureConstants.Snake_Viper_Tiny, RollConstants.One)]
        [TestCase(78, 82, CreatureConstants.Centipede_Monstrous_Small, RollConstants.OneD3Plus1)]
        [TestCase(83, 87, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(88, 89, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(90, 91, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(92, 93, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(94, 95, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(96, 100, CreatureConstants.Character + "1", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
