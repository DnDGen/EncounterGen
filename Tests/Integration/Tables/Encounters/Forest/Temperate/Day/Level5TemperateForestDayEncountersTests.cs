using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Forest.Temperate.Day
{
    [TestFixture]
    public class Level5TemperateForestDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 5, EnvironmentConstants.TemperateForestDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 1, CreatureConstants.AnimatedObject_Huge, RollConstants.One)]
        [TestCase(2, 2, CreatureConstants.Arrowhawk_Adult, RollConstants.One)]
        [TestCase(3, 3, CreatureConstants.Azer, RollConstants.OneD3Plus1)]
        [TestCase(4, 4, CreatureConstants.Barbazu, RollConstants.One)]
        [TestCase(5, 5, CreatureConstants.Barghest, RollConstants.One)]
        [TestCase(6, 7, CreatureConstants.Basilisk, RollConstants.One)]
        [TestCase(8, 9, CreatureConstants.Bear_Brown, RollConstants.OneD2)]
        [TestCase(10, 11, CreatureConstants.Lion_Dire, RollConstants.One)]
        [TestCase(12, 17, CreatureConstants.Wolverine_Dire, RollConstants.OneD2)]
        [TestCase(18, 23, CreatureConstants.TrumpetArchon, RollConstants.One)]
        [TestCase(24, 24, CreatureConstants.DisplacerBeast, RollConstants.OneD2)]
        [TestCase(25, 25, CreatureConstants.Djinn, RollConstants.One)]
        [TestCase(26, 26, CreatureConstants.Dretch, RollConstants.OneD3Plus1)]
        [TestCase(27, 27, CreatureConstants.Elemental_Air_Large, RollConstants.One)]
        [TestCase(28, 28, CreatureConstants.Elemental_Earth_Large, RollConstants.One)]
        [TestCase(29, 29, CreatureConstants.Elemental_Fire_Large, RollConstants.One)]
        [TestCase(30, 30, CreatureConstants.Elemental_Water_Large, RollConstants.One)]
        [TestCase(31, 31, CreatureConstants.FormianWorker, RollConstants.OneD4Plus10)]
        [TestCase(32, 33, CreatureConstants.Gargoyle, RollConstants.OneD2)]
        [TestCase(34, 35, CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD3Plus1)]
        [TestCase(36, 41, CreatureConstants.Ant_Giant_Soldier, RollConstants.OneD3Plus1)]
        [TestCase(42, 43, CreatureConstants.GibberingMouther, RollConstants.One)]
        [TestCase(44, 49, CreatureConstants.GreenHag, RollConstants.One)]
        [TestCase(50, 51, CreatureConstants.Harpy, RollConstants.OneD2)]
        [TestCase(52, 52, CreatureConstants.HoundArchon, RollConstants.OneD2)]
        [TestCase(53, 54, CreatureConstants.Centipede_Monstrous_Huge, RollConstants.OneD3Plus1)]
        [TestCase(55, 56, CreatureConstants.Spider_Monstrous_Huge, RollConstants.One)]
        [TestCase(57, 57, CreatureConstants.LanternArchon, RollConstants.OneD3Plus1)]
        [TestCase(58, 59, CreatureConstants.Spider_Monstrous_Large, RollConstants.OneD3Plus1)]
        [TestCase(60, 61, CreatureConstants.Manticore, RollConstants.One)]
        [TestCase(62, 67, CreatureConstants.Owlbear, RollConstants.OneD2)]
        [TestCase(68, 68, CreatureConstants.PhaseSpider, RollConstants.One)]
        [TestCase(69, 70, CreatureConstants.SpiderEater, RollConstants.One)]
        [TestCase(71, 72, CreatureConstants.Stirge, RollConstants.OneD4Plus10)]
        [TestCase(73, 74, CreatureConstants.Troll, RollConstants.One)]
        [TestCase(75, 76, CreatureConstants.Vargouille, RollConstants.OneD3Plus1)]
        [TestCase(77, 78, CreatureConstants.Werebear, RollConstants.One)]
        [TestCase(79, 84, CreatureConstants.Wereboar, RollConstants.OneD2)]
        [TestCase(85, 86, CreatureConstants.Weretiger, RollConstants.One)]
        [TestCase(87, 87, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Tiny, RollConstants.OneD3)]
        [TestCase(88, 88, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Small, RollConstants.One)]
        [TestCase(89, 90, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(91, 91, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(92, 92, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(93, 93, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(94, 94, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(95, 100, CreatureConstants.Character + "[2]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
