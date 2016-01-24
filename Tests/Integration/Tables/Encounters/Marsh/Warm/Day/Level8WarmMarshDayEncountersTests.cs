using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Marsh.Warm.Day
{
    [TestFixture]
    public class Level8WarmMarshDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 8, EnvironmentConstants.WarmMarshDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 2, CreatureConstants.Behir, RollConstants.One)]
        [TestCase(3, 4, CreatureConstants.GrayRender, RollConstants.One)]
        [TestCase(5, 6, CreatureConstants.Ogre, RollConstants.OneD6Plus3)]
        [TestCase(7, 8, CreatureConstants.OgreMage, RollConstants.One)]
        [TestCase(9, 10, CreatureConstants.Troll, RollConstants.OneD3Plus1)]
        [TestCase(11, 12, CreatureConstants.Vargouille, RollConstants.OneD6Plus5)]
        [TestCase(13, 14, CreatureConstants.Wererat, RollConstants.OneD6Plus5)]
        [TestCase(15, 16, CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD6Plus5)]
        [TestCase(17, 18, CreatureConstants.Gorgon, RollConstants.One)]
        [TestCase(19, 20, CreatureConstants.Lammasu, RollConstants.One)]
        [TestCase(21, 22, CreatureConstants.Naga_Dark, RollConstants.One)]
        [TestCase(23, 24, CreatureConstants.Spider_Monstrous_Gargantuan, RollConstants.One)]
        [TestCase(25, 26, CreatureConstants.Spider_Monstrous_Huge, RollConstants.OneD3Plus1)]
        [TestCase(27, 28, CreatureConstants.Hydra_9Heads, RollConstants.One)]
        [TestCase(29, 30, CreatureConstants.Cryohydra_7Heads, RollConstants.One)]
        [TestCase(31, 32, CreatureConstants.Pyrohydra_7Heads, RollConstants.One)]
        [TestCase(33, 35, CreatureConstants.Chuul, RollConstants.OneD2)]
        [TestCase(36, 38, CreatureConstants.Crocodile, RollConstants.OneD6Plus5)]
        [TestCase(39, 42, CreatureConstants.Tyrannosaurus, RollConstants.One)]
        [TestCase(43, 43, CreatureConstants.Arrowhawk_Adult, RollConstants.OneD3Plus1)]
        [TestCase(44, 44, CreatureConstants.Arrowhawk_Elder, RollConstants.One)]
        [TestCase(45, 45, CreatureConstants.Barghest, RollConstants.OneD4Plus2)]
        [TestCase(46, 46, CreatureConstants.Djinn, RollConstants.OneD3Plus1)]
        [TestCase(47, 47, CreatureConstants.Djinn_Noble, RollConstants.One)]
        [TestCase(48, 48, CreatureConstants.Dretch, RollConstants.OneD6Plus5)]
        [TestCase(49, 49, CreatureConstants.Efreet, RollConstants.One)]
        [TestCase(50, 50, CreatureConstants.Erinyes, RollConstants.One)]
        [TestCase(51, 51, CreatureConstants.Hellcat, RollConstants.OneD2)]
        [TestCase(52, 52, CreatureConstants.Mohrg, RollConstants.One)]
        [TestCase(53, 53, CreatureConstants.Slaad_Blue, RollConstants.One)]
        [TestCase(54, 54, CreatureConstants.Slaad_Red, RollConstants.OneD2)]
        [TestCase(55, 55, CreatureConstants.Xorn_Elder, RollConstants.One)]
        [TestCase(56, 57, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(58, 58, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(59, 59, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(60, 60, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(61, 61, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(62, 100, CreatureConstants.Character + "[5]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
