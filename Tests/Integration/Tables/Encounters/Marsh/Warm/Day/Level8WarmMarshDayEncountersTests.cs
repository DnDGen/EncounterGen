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

        [TestCase(1, 3, CreatureConstants.Behir, RollConstants.One)]
        [TestCase(4, 6, CreatureConstants.GrayRender, RollConstants.One)]
        [TestCase(7, 9, CreatureConstants.Ogre, RollConstants.OneD6Plus3)]
        [TestCase(10, 12, CreatureConstants.OgreMage, RollConstants.One)]
        [TestCase(13, 15, CreatureConstants.Troll, RollConstants.OneD3Plus1)]
        [TestCase(16, 18, CreatureConstants.Vargouille, RollConstants.OneD6Plus5)]
        [TestCase(19, 21, CreatureConstants.Wererat, RollConstants.OneD6Plus5)]
        [TestCase(22, 24, CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD6Plus5)]
        [TestCase(25, 27, CreatureConstants.Gorgon, RollConstants.One)]
        [TestCase(28, 30, CreatureConstants.Lammasu, RollConstants.One)]
        [TestCase(31, 33, CreatureConstants.Naga_Dark, RollConstants.One)]
        [TestCase(34, 36, CreatureConstants.Spider_Monstrous_Gargantuan, RollConstants.One)]
        [TestCase(37, 39, CreatureConstants.Spider_Monstrous_Huge, RollConstants.OneD3Plus1)]
        [TestCase(40, 42, CreatureConstants.Hydra_9Heads, RollConstants.One)]
        [TestCase(43, 45, CreatureConstants.Cryohydra_7Heads, RollConstants.One)]
        [TestCase(46, 48, CreatureConstants.Pyrohydra_7Heads, RollConstants.One)]
        [TestCase(49, 57, CreatureConstants.Chuul, RollConstants.OneD2)]
        [TestCase(58, 66, CreatureConstants.Crocodile, RollConstants.OneD6Plus5)]
        [TestCase(67, 75, CreatureConstants.Tyrannosaurus, RollConstants.One)]
        [TestCase(76, 76, CreatureConstants.Arrowhawk_Adult, RollConstants.OneD3Plus1)]
        [TestCase(77, 77, CreatureConstants.Arrowhawk_Elder, RollConstants.One)]
        [TestCase(78, 78, CreatureConstants.Barghest, RollConstants.OneD4Plus2)]
        [TestCase(79, 79, CreatureConstants.Djinn, RollConstants.OneD3Plus1)]
        [TestCase(80, 80, CreatureConstants.Djinn_Noble, RollConstants.One)]
        [TestCase(81, 81, CreatureConstants.Dretch, RollConstants.OneD6Plus5)]
        [TestCase(82, 82, CreatureConstants.Efreet, RollConstants.One)]
        [TestCase(83, 83, CreatureConstants.Erinyes, RollConstants.One)]
        [TestCase(84, 84, CreatureConstants.Hellcat, RollConstants.OneD2)]
        [TestCase(85, 85, CreatureConstants.Mohrg, RollConstants.One)]
        [TestCase(86, 86, CreatureConstants.Slaad_Blue, RollConstants.One)]
        [TestCase(87, 87, CreatureConstants.Slaad_Red, RollConstants.OneD2)]
        [TestCase(88, 88, CreatureConstants.Xorn_Elder, RollConstants.One)]
        [TestCase(89, 89, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Gargantuan, RollConstants.One)]
        [TestCase(90, 90, CreatureConstants.FormianTaskmaster, RollConstants.One,
            CreatureConstants.DominatedCreature + "[4]", RollConstants.One)]
        [TestCase(91, 93, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(94, 94, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(95, 95, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(96, 96, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(97, 97, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(98, 100, CreatureConstants.Character + "[5]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
