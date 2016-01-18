using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Temperate.Day
{
    [TestFixture]
    public class Level6TemperateHillsDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 6, EnvironmentConstants.TemperateHillsDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 2, CreatureConstants.Lamia, RollConstants.One)]
        [TestCase(3, 4, CreatureConstants.Lion_Dire, RollConstants.OneD2)]
        [TestCase(5, 6, CreatureConstants.Werebear, RollConstants.OneD2)]
        [TestCase(7, 8, CreatureConstants.Weretiger, RollConstants.OneD2)]
        [TestCase(9, 11, CreatureConstants.Badger_Dire, RollConstants.OneD4Plus2)]
        [TestCase(12, 14, CreatureConstants.Ettin, RollConstants.One)]
        [TestCase(15, 17, CreatureConstants.Tendriculos, RollConstants.One)]
        [TestCase(18, 20, CreatureConstants.Wyvern, RollConstants.One)]
        [TestCase(21, 22, CreatureConstants.Annis, RollConstants.One)]
        [TestCase(23, 24, CreatureConstants.Beholder, RollConstants.One)]
        [TestCase(25, 26, CreatureConstants.Ogre, RollConstants.OneD3Plus1)]
        [TestCase(27, 28, CreatureConstants.Wererat, RollConstants.OneD3Plus1,
            CreatureConstants.Rat_Dire, RollConstants.OneD6Plus3)]
        [TestCase(29, 30, CreatureConstants.Centipede_Monstrous_Gargantuan, RollConstants.One)]
        [TestCase(31, 32, CreatureConstants.Cockatrice, RollConstants.OneD3Plus1)]
        [TestCase(33, 34, CreatureConstants.Digester, RollConstants.One)]
        [TestCase(35, 36, CreatureConstants.Manticore, RollConstants.OneD2)]
        [TestCase(37, 38, CreatureConstants.Scorpion_Monstrous_Large, RollConstants.OneD3Plus1)]
        [TestCase(39, 40, CreatureConstants.Wasp_Giant, RollConstants.OneD3Plus1)]
        [TestCase(41, 41, CreatureConstants.Arrowhawk_Juvenile, RollConstants.OneD3Plus1)]
        [TestCase(42, 42, CreatureConstants.Barbazu, RollConstants.OneD2)]
        [TestCase(43, 43, CreatureConstants.Belker, RollConstants.One)]
        [TestCase(44, 44, CreatureConstants.FormianWarrior, RollConstants.OneD3Plus1)]
        [TestCase(45, 45, CreatureConstants.Howler, RollConstants.OneD3Plus1)]
        [TestCase(46, 46, CreatureConstants.Kyton, RollConstants.One)]
        [TestCase(47, 47, CreatureConstants.Magmin, RollConstants.OneD3Plus1)]
        [TestCase(48, 48, CreatureConstants.Mephit, RollConstants.OneD3Plus1)]
        [TestCase(49, 49, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD3Plus1)]
        [TestCase(50, 50, CreatureConstants.Salamander_Average, RollConstants.One)]
        [TestCase(51, 51, CreatureConstants.Xill, RollConstants.One)]
        [TestCase(52, 52, CreatureConstants.Xorn_Minor, RollConstants.OneD3Plus1)]
        [TestCase(53, 53, CreatureConstants.Xorn_Average, RollConstants.One)]
        [TestCase(54, 55, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(56, 56, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(57, 57, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(58, 58, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(59, 59, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(60, 100, CreatureConstants.Character + "[3]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
