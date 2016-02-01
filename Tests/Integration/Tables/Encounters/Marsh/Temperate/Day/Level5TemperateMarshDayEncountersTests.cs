using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Marsh.Temperate.Day
{
    [TestFixture]
    public class Level5TemperateMarshDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 5, EnvironmentConstants.TemperateMarshDay);
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
        [TestCase(5, 5, CreatureConstants.Barghest_Greater, RollConstants.One)]
        [TestCase(6, 9, CreatureConstants.Basilisk, RollConstants.One)]
        [TestCase(10, 10, CreatureConstants.Djinn, RollConstants.One)]
        [TestCase(11, 11, CreatureConstants.Dretch, RollConstants.OneD3Plus1)]
        [TestCase(12, 12, CreatureConstants.Elemental_Air_Large, RollConstants.One)]
        [TestCase(13, 13, CreatureConstants.Elemental_Earth_Large, RollConstants.One)]
        [TestCase(14, 14, CreatureConstants.Elemental_Fire_Large, RollConstants.One)]
        [TestCase(15, 15, CreatureConstants.Elemental_Water_Large, RollConstants.One)]
        [TestCase(16, 16, CreatureConstants.FormianWorker, RollConstants.OneD4Plus10)]
        [TestCase(17, 20, CreatureConstants.Gargoyle, RollConstants.OneD2)]
        [TestCase(21, 24, CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD3Plus1)]
        [TestCase(25, 28, CreatureConstants.GibberingMouther, RollConstants.One)]
        [TestCase(29, 36, CreatureConstants.GreenHag, RollConstants.One)]
        [TestCase(37, 40, CreatureConstants.Harpy, RollConstants.OneD2)]
        [TestCase(41, 41, CreatureConstants.HoundArchon, RollConstants.OneD2)]
        [TestCase(42, 45, CreatureConstants.Centipede_Monstrous_Huge, RollConstants.OneD3Plus1)]
        [TestCase(46, 49, CreatureConstants.Spider_Monstrous_Huge, RollConstants.One)]
        [TestCase(50, 53, CreatureConstants.Hydra_6Heads, RollConstants.One)]
        [TestCase(54, 54, CreatureConstants.LanternArchon, RollConstants.OneD3Plus1)]
        [TestCase(55, 58, CreatureConstants.Spider_Monstrous_Large, RollConstants.OneD3Plus1)]
        [TestCase(59, 62, CreatureConstants.Manticore, RollConstants.One)]
        [TestCase(63, 66, CreatureConstants.Ooze_OchreJelly, RollConstants.One)]
        [TestCase(67, 67, CreatureConstants.PhaseSpider, RollConstants.One)]
        [TestCase(68, 71, CreatureConstants.SpiderEater, RollConstants.One)]
        [TestCase(72, 75, CreatureConstants.Troll, RollConstants.One)]
        [TestCase(76, 79, CreatureConstants.Vargouille, RollConstants.OneD3Plus1)]
        [TestCase(80, 80, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Tiny, RollConstants.OneD3)]
        [TestCase(81, 81, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Small, RollConstants.One)]
        [TestCase(82, 85, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(86, 86, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(87, 87, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(88, 88, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(89, 89, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(90, 100, CreatureConstants.Character + "[2]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            throw new NotImplementedException();
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
