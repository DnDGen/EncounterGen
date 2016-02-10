using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Mountain.Temperate.Day
{
    [TestFixture]
    public class Level14TemperateMountainDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 14, EnvironmentConstants.TemperateMountainDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 9, CreatureConstants.Gorgon, RollConstants.OneD6Plus5)]
        [TestCase(10, 24, CreatureConstants.Athach, RollConstants.OneD6Plus5)]
        [TestCase(25, 39, CreatureConstants.Giant_Cloud, RollConstants.OneD3Plus1)]
        [TestCase(40, 42, CreatureConstants.TrumpetArchon, RollConstants.One)]
        [TestCase(43, 45, CreatureConstants.AstralDeva, RollConstants.One)]
        [TestCase(46, 48, CreatureConstants.Ghaele, RollConstants.OneD2)]
        [TestCase(49, 51, CreatureConstants.Efreet, RollConstants.OneD6Plus5)]
        [TestCase(52, 54, CreatureConstants.Golem_Stone, RollConstants.OneD3Plus1)]
        [TestCase(55, 57, CreatureConstants.Hezrou, RollConstants.OneD3Plus1)]
        [TestCase(58, 60, CreatureConstants.Nalfeshnee, RollConstants.One)]
        [TestCase(61, 63, CreatureConstants.Slaad_Blue, RollConstants.OneD6Plus5)]
        [TestCase(64, 66, CreatureConstants.Slaad_Death, RollConstants.OneD2)]
        [TestCase(67, 69, CreatureConstants.Xorn_Elder, RollConstants.OneD6Plus5)]
        [TestCase(70, 78, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(79, 81, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(82, 84, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(85, 87, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(88, 90, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(91, 100, CreatureConstants.Character + "[11]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
