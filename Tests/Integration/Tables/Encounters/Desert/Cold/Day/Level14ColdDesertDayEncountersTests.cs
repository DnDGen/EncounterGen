using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Desert.Cold.Day
{
    [TestFixture]
    public class Level14ColdDesertDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 14, EnvironmentConstants.ColdDesertDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, CreatureConstants.AstralDeva, RollConstants.One)]
        [TestCase(6, 10, CreatureConstants.Efreet, RollConstants.OneD6Plus5)]
        [TestCase(11, 15, CreatureConstants.Ghaele, RollConstants.OneD2)]
        [TestCase(16, 20, CreatureConstants.Golem_Stone, RollConstants.OneD3Plus1)]
        [TestCase(21, 25, CreatureConstants.Hezrou, RollConstants.OneD3Plus1)]
        [TestCase(26, 30, CreatureConstants.Nalfeshnee, RollConstants.One)]
        [TestCase(31, 35, CreatureConstants.Slaad_Blue, RollConstants.OneD6Plus5)]
        [TestCase(36, 40, CreatureConstants.Slaad_Death, RollConstants.OneD2)]
        [TestCase(41, 45, CreatureConstants.TrumpetArchon, RollConstants.One)]
        [TestCase(46, 50, CreatureConstants.Xorn_Elder, RollConstants.OneD6Plus5)]
        [TestCase(51, 60, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(61, 65, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(66, 70, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(71, 75, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(76, 80, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(81, 100, CreatureConstants.Character + "[11]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
