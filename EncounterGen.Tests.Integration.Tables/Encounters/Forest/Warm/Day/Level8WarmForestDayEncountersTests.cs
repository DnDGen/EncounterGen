using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Forest.Warm.Day
{
    [TestFixture]
    public class Level8WarmForestDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 8, EnvironmentConstants.WarmForestDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 7, CreatureConstants.Aranea, RollConstants.OneD4Plus2)]
        [TestCase(8, 8, CreatureConstants.Arrowhawk_Adult, RollConstants.OneD3Plus1)]
        [TestCase(9, 9, CreatureConstants.Arrowhawk_Elder, RollConstants.One)]
        [TestCase(10, 10, CreatureConstants.Barghest, RollConstants.OneD4Plus2)]
        [TestCase(11, 12, CreatureConstants.Behir, RollConstants.One)]
        [TestCase(13, 19, CreatureConstants.Chuul, RollConstants.OneD2)]
        [TestCase(20, 21, CreatureConstants.Naga_Dark, RollConstants.One)]
        [TestCase(22, 28, CreatureConstants.Ape_Dire, RollConstants.OneD6Plus3)]
        [TestCase(29, 30, CreatureConstants.Bear_Dire, RollConstants.OneD2)]
        [TestCase(31, 32, CreatureConstants.Tiger_Dire, RollConstants.One)]
        [TestCase(33, 34, CreatureConstants.Wolf_Dire, RollConstants.OneD6Plus3)]
        [TestCase(35, 35, CreatureConstants.Djinn, RollConstants.OneD3Plus1)]
        [TestCase(36, 36, CreatureConstants.Dretch, RollConstants.OneD6Plus5)]
        [TestCase(37, 37, CreatureConstants.Efreet, RollConstants.One)]
        [TestCase(38, 38, CreatureConstants.Erinyes, RollConstants.One)]
        [TestCase(39, 40, CreatureConstants.Spider_Monstrous_Gargantuan, RollConstants.One)]
        [TestCase(41, 42, CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD6Plus5)]
        [TestCase(43, 49, CreatureConstants.StagBeetle_Giant, RollConstants.OneD4Plus2)]
        [TestCase(50, 51, CreatureConstants.Gorgon, RollConstants.One)]
        [TestCase(52, 53, CreatureConstants.GrayRender, RollConstants.One)]
        [TestCase(54, 54, CreatureConstants.Hellcat, RollConstants.OneD2)]
        [TestCase(55, 56, CreatureConstants.Spider_Monstrous_Huge, RollConstants.One)]
        [TestCase(57, 58, CreatureConstants.Lammasu, RollConstants.One)]
        [TestCase(59, 59, CreatureConstants.Mohrg, RollConstants.One)]
        [TestCase(60, 60, CreatureConstants.Djinn_Noble, RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.Ogre, RollConstants.OneD6Plus3)]
        [TestCase(63, 64, CreatureConstants.OgreMage, RollConstants.One)]
        [TestCase(65, 65, CreatureConstants.Slaad_Blue, RollConstants.One)]
        [TestCase(66, 66, CreatureConstants.Slaad_Red, RollConstants.OneD2)]
        [TestCase(67, 68, CreatureConstants.Treant, RollConstants.One)]
        [TestCase(69, 70, CreatureConstants.Troll, RollConstants.OneD3Plus1)]
        [TestCase(71, 72, CreatureConstants.Vargouille, RollConstants.OneD6Plus5)]
        [TestCase(73, 74, CreatureConstants.Werebear, RollConstants.OneD3Plus1)]
        [TestCase(75, 81, CreatureConstants.Wereboar, RollConstants.OneD3Plus1,
            CreatureConstants.Boar, RollConstants.OneD3)]
        [TestCase(82, 83, CreatureConstants.Wererat, RollConstants.OneD6Plus5)]
        [TestCase(84, 85, CreatureConstants.Werewolf, RollConstants.OneD6Plus3)]
        [TestCase(86, 87, CreatureConstants.Worg, RollConstants.OneD6Plus5)]
        [TestCase(88, 88, CreatureConstants.Xorn_Elder, RollConstants.One)]
        [TestCase(89, 89, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Gargantuan, RollConstants.One)]
        [TestCase(90, 90, CreatureConstants.FormianTaskmaster, RollConstants.One,
            CreatureConstants.DominatedCreature + "[4]", RollConstants.One)]
        [TestCase(91, 92, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(93, 93, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(94, 94, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(95, 95, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(96, 96, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(97, 100, CreatureConstants.Character + "[5]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
