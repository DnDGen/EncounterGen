using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
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

        [TestCase(1, 3, CreatureConstants.Aranea, RollConstants.OneD4Plus2)]
        [TestCase(4, 4, CreatureConstants.Arrowhawk_Adult, RollConstants.OneD3Plus1)]
        [TestCase(5, 5, CreatureConstants.Arrowhawk_Elder, RollConstants.One)]
        [TestCase(6, 6, CreatureConstants.Barghest, RollConstants.OneD4Plus2)]
        [TestCase(7, 8, CreatureConstants.Behir, RollConstants.One)]
        [TestCase(9, 11, CreatureConstants.Chuul, RollConstants.OneD2)]
        [TestCase(12, 13, CreatureConstants.Naga_Dark, RollConstants.One)]
        [TestCase(14, 16, CreatureConstants.Ape_Dire, RollConstants.OneD6Plus3)]
        [TestCase(17, 18, CreatureConstants.Bear_Dire, RollConstants.OneD2)]
        [TestCase(19, 20, CreatureConstants.Tiger_Dire, RollConstants.One)]
        [TestCase(21, 22, CreatureConstants.Wolf_Dire, RollConstants.OneD6Plus3)]
        [TestCase(23, 23, CreatureConstants.Djinn, RollConstants.OneD3Plus1)]
        [TestCase(24, 24, CreatureConstants.Dretch, RollConstants.OneD6Plus5)]
        [TestCase(25, 25, CreatureConstants.Efreet, RollConstants.One)]
        [TestCase(26, 26, CreatureConstants.Erinyes, RollConstants.One)]
        [TestCase(27, 28, CreatureConstants.Spider_Monstrous_Gargantuan, RollConstants.One)]
        [TestCase(29, 30, CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD6Plus5)]
        [TestCase(31, 33, CreatureConstants.StagBeetle_Giant, RollConstants.OneD4Plus2)]
        [TestCase(34, 35, CreatureConstants.Gorgon, RollConstants.One)]
        [TestCase(36, 37, CreatureConstants.GrayRender, RollConstants.One)]
        [TestCase(38, 38, CreatureConstants.Hellcat, RollConstants.OneD2)]
        [TestCase(39, 40, CreatureConstants.Spider_Monstrous_Huge, RollConstants.One)]
        [TestCase(41, 42, CreatureConstants.Lammasu, RollConstants.One)]
        [TestCase(43, 43, CreatureConstants.Mohrg, RollConstants.One)]
        [TestCase(44, 44, CreatureConstants.Djinn_Noble, RollConstants.One)]
        [TestCase(45, 46, CreatureConstants.Ogre, RollConstants.OneD6Plus3)]
        [TestCase(47, 48, CreatureConstants.OgreMage, RollConstants.One)]
        [TestCase(49, 49, CreatureConstants.Slaad_Blue, RollConstants.One)]
        [TestCase(50, 50, CreatureConstants.Slaad_Red, RollConstants.OneD2)]
        [TestCase(51, 52, CreatureConstants.Treant, RollConstants.One)]
        [TestCase(53, 54, CreatureConstants.Troll, RollConstants.OneD3Plus1)]
        [TestCase(55, 56, CreatureConstants.Vargouille, RollConstants.OneD6Plus5)]
        [TestCase(57, 58, CreatureConstants.Werebear, RollConstants.OneD3Plus1)]
        [TestCase(59, 61, CreatureConstants.Wereboar, RollConstants.OneD3Plus1,
            CreatureConstants.Boar, RollConstants.OneD3)]
        [TestCase(62, 63, CreatureConstants.Wererat, RollConstants.OneD6Plus5)]
        [TestCase(64, 65, CreatureConstants.Werewolf, RollConstants.OneD6Plus3)]
        [TestCase(66, 67, CreatureConstants.Worg, RollConstants.OneD6Plus5)]
        [TestCase(68, 68, CreatureConstants.Xorn_Elder, RollConstants.One)]
        [TestCase(69, 70, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(71, 71, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(72, 72, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(73, 73, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(74, 74, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(75, 100, CreatureConstants.Character + "[5]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
