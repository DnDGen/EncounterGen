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

        [TestCase(1, 6, CreatureConstants.Baboon, RollConstants.One)]
        [TestCase(7, 12, CreatureConstants.Bat, RollConstants.OneD4Plus10)]
        [TestCase(13, 16, CreatureConstants.Rat_Dire, RollConstants.One)]
        [TestCase(17, 20, CreatureConstants.Dog, RollConstants.One)]
        [TestCase(21, 22, CreatureConstants.Elemental_Air_Small, RollConstants.One)]
        [TestCase(23, 24, CreatureConstants.Elemental_Earth_Small, RollConstants.One)]
        [TestCase(25, 26, CreatureConstants.Elemental_Fire_Small, RollConstants.One)]
        [TestCase(27, 28, CreatureConstants.Elemental_Water_Small, RollConstants.One)]
        [TestCase(29, 32, CreatureConstants.Bee_Giant, RollConstants.One)]
        [TestCase(33, 36, CreatureConstants.FireBeetle_Giant, RollConstants.OneD3Plus1)]
        [TestCase(37, 40, CreatureConstants.Gnoll, RollConstants.One)]
        [TestCase(41, 42, CreatureConstants.Homunculus, RollConstants.One)]
        [TestCase(43, 46, CreatureConstants.Centipede_Monstrous_Large, RollConstants.One)]
        [TestCase(47, 50, CreatureConstants.Centipede_Monstrous_Medium, RollConstants.One)]
        [TestCase(51, 54, CreatureConstants.Scorpion_Monstrous_Medium, RollConstants.One)]
        [TestCase(55, 58, CreatureConstants.Spider_Monstrous_Medium, RollConstants.One)]
        [TestCase(59, 62, CreatureConstants.Snake_Viper_Small, RollConstants.One)]
        [TestCase(63, 66, CreatureConstants.Snake_Viper_Tiny, RollConstants.One)]
        [TestCase(67, 70, CreatureConstants.Centipede_Monstrous_Small, RollConstants.OneD3Plus1)]
        [TestCase(71, 74, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(75, 76, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(77, 78, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(79, 80, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(81, 82, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(83, 100, CreatureConstants.Character + "1", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
