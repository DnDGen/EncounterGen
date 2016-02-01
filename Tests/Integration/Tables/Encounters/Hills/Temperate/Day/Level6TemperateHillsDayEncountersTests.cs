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

        [TestCase(1, 3, CreatureConstants.Lamia, RollConstants.One)]
        [TestCase(4, 6, CreatureConstants.Lion_Dire, RollConstants.OneD2)]
        [TestCase(7, 9, CreatureConstants.Werebear, RollConstants.OneD2)]
        [TestCase(10, 12, CreatureConstants.Weretiger, RollConstants.OneD2)]
        [TestCase(13, 19, CreatureConstants.Badger_Dire, RollConstants.OneD4Plus2)]
        [TestCase(20, 26, CreatureConstants.Ettin, RollConstants.One)]
        [TestCase(27, 33, CreatureConstants.Tendriculos, RollConstants.One)]
        [TestCase(34, 40, CreatureConstants.Wyvern, RollConstants.One)]
        [TestCase(41, 43, CreatureConstants.Annis, RollConstants.One)]
        [TestCase(44, 46, CreatureConstants.Beholder, RollConstants.One)]
        [TestCase(47, 49, CreatureConstants.Ogre, RollConstants.OneD3Plus1)]
        [TestCase(50, 52, CreatureConstants.Wererat, RollConstants.OneD3Plus1,
            CreatureConstants.Rat_Dire, RollConstants.OneD6Plus3)]
        [TestCase(53, 55, CreatureConstants.Centipede_Monstrous_Gargantuan, RollConstants.One)]
        [TestCase(56, 58, CreatureConstants.Cockatrice, RollConstants.OneD3Plus1)]
        [TestCase(59, 61, CreatureConstants.Digester, RollConstants.One)]
        [TestCase(62, 64, CreatureConstants.Manticore, RollConstants.OneD2)]
        [TestCase(65, 67, CreatureConstants.Scorpion_Monstrous_Large, RollConstants.OneD3Plus1)]
        [TestCase(68, 70, CreatureConstants.Wasp_Giant, RollConstants.OneD3Plus1)]
        [TestCase(71, 71, CreatureConstants.Arrowhawk_Juvenile, RollConstants.OneD3Plus1)]
        [TestCase(72, 72, CreatureConstants.Barbazu, RollConstants.OneD2)]
        [TestCase(73, 73, CreatureConstants.Belker, RollConstants.One)]
        [TestCase(74, 74, CreatureConstants.FormianWarrior, RollConstants.OneD3Plus1)]
        [TestCase(75, 75, CreatureConstants.Howler, RollConstants.OneD3Plus1)]
        [TestCase(76, 76, CreatureConstants.Kyton, RollConstants.One)]
        [TestCase(77, 77, CreatureConstants.Magmin, RollConstants.OneD3Plus1)]
        [TestCase(78, 78, CreatureConstants.Mephit, RollConstants.OneD3Plus1)]
        [TestCase(79, 79, CreatureConstants.Salamander_Flamebrother, RollConstants.OneD3Plus1)]
        [TestCase(80, 80, CreatureConstants.Salamander_Average, RollConstants.One)]
        [TestCase(81, 81, CreatureConstants.Xill, RollConstants.One)]
        [TestCase(82, 82, CreatureConstants.Xorn_Minor, RollConstants.OneD3Plus1)]
        [TestCase(83, 83, CreatureConstants.Xorn_Average, RollConstants.One)]
        [TestCase(84, 86, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(87, 87, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(88, 88, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(89, 89, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(90, 90, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(91, 91, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Tiny, RollConstants.OneD4Plus2)]
        [TestCase(92, 92, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Small, RollConstants.OneD2)]
        [TestCase(93, 93, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Medium, RollConstants.One)]
        [TestCase(94, 94, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Large, RollConstants.One)]
        [TestCase(95, 100, CreatureConstants.Character + "[3]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
