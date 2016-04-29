using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Plains.Temperate.Night
{
    [TestFixture]
    public class Level9TemperatePlainsNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 9, EnvironmentConstants.TemperatePlainsNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 3, CreatureConstants.Basilisk, RollConstants.OneD4Plus2)]
        [TestCase(4, 6, CreatureConstants.Behir, RollConstants.OneD2)]
        [TestCase(7, 9, CreatureConstants.OgreMage, RollConstants.OneD2)]
        [TestCase(10, 12, CreatureConstants.Centipede_Monstrous_Colossal, RollConstants.One)]
        [TestCase(13, 15, CreatureConstants.Cockatrice, RollConstants.OneD6Plus5)]
        [TestCase(16, 18, CreatureConstants.Gorgon, RollConstants.OneD2)]
        [TestCase(19, 21, CreatureConstants.Manticore, RollConstants.OneD4Plus2)]
        [TestCase(22, 24, CreatureConstants.Naga_Spirit, RollConstants.One)]
        [TestCase(25, 27, CreatureConstants.Eagle_Giant, RollConstants.OneD6Plus5)]
        [TestCase(28, 30, CreatureConstants.Tiger_Dire, RollConstants.OneD2)]
        [TestCase(31, 35, CreatureConstants.BlinkDog, RollConstants.OneD4Plus10)]
        [TestCase(36, 37, CreatureConstants.Barghest_Greater, RollConstants.OneD4Plus2)]
        [TestCase(38, 39, CreatureConstants.Belker, RollConstants.OneD3Plus1)]
        [TestCase(40, 41, CreatureConstants.Dretch, RollConstants.OneD4Plus10)]
        [TestCase(42, 43, CreatureConstants.Elemental_Air_Greater, RollConstants.One)]
        [TestCase(44, 45, CreatureConstants.Elemental_Earth_Greater, RollConstants.One)]
        [TestCase(46, 47, CreatureConstants.Elemental_Fire_Greater, RollConstants.One)]
        [TestCase(48, 49, CreatureConstants.Elemental_Water_Greater, RollConstants.One)]
        [TestCase(50, 51, CreatureConstants.FormianWarrior, RollConstants.OneD6Plus5)]
        [TestCase(52, 53, CreatureConstants.Avoral, RollConstants.One)]
        [TestCase(54, 55, CreatureConstants.NightHag, RollConstants.One)]
        [TestCase(56, 57, CreatureConstants.HellHound, RollConstants.OneD6Plus5)]
        [TestCase(58, 59, CreatureConstants.NessianWarhound, RollConstants.One)]
        [TestCase(60, 61, CreatureConstants.Howler, RollConstants.OneD6Plus5)]
        [TestCase(62, 63, CreatureConstants.Kyton, RollConstants.OneD3Plus1)]
        [TestCase(64, 65, CreatureConstants.Magmin, RollConstants.OneD6Plus5)]
        [TestCase(66, 67, CreatureConstants.Mephit, RollConstants.OneD6Plus5)]
        [TestCase(68, 69, CreatureConstants.Osyluth, RollConstants.One)]
        [TestCase(70, 71, CreatureConstants.PhaseSpider, RollConstants.OneD4Plus2)]
        [TestCase(72, 73, CreatureConstants.Salamander_Average, RollConstants.OneD3Plus1)]
        [TestCase(74, 75, CreatureConstants.Shadow, RollConstants.OneD6Plus5)]
        [TestCase(76, 77, CreatureConstants.Slaad_Blue, RollConstants.OneD2)]
        [TestCase(78, 79, CreatureConstants.Slaad_Green, RollConstants.One)]
        [TestCase(80, 81, CreatureConstants.Vrock, RollConstants.One)]
        [TestCase(82, 83, CreatureConstants.Xill, RollConstants.One)]
        [TestCase(84, 85, CreatureConstants.Xorn_Average, RollConstants.OneD3Plus1)]
        [TestCase(86, 87, CreatureConstants.Xorn_Elder, RollConstants.One)]
        [TestCase(88, 90, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(91, 92, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(93, 94, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(95, 96, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(97, 98, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(99, 100, CreatureConstants.Character + "[6]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
