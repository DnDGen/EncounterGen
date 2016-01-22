using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Cold.Night
{
    [TestFixture]
    public class Level14ColdHillsNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 14, EnvironmentConstants.ColdHillsNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 10, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(11, 15, CreatureConstants.AstralDeva, RollConstants.One)]
        [TestCase(16, 20, CreatureConstants.Efreet, RollConstants.OneD6Plus5)]
        [TestCase(21, 25, CreatureConstants.Ghaele, RollConstants.OneD2)]
        [TestCase(26, 30, CreatureConstants.Golem_Stone, RollConstants.OneD3Plus1)]
        [TestCase(31, 35, CreatureConstants.Hezrou, RollConstants.OneD3Plus1)]
        [TestCase(36, 40, CreatureConstants.Nalfeshnee, RollConstants.One)]
        [TestCase(41, 45, CreatureConstants.Nightwing, RollConstants.One)]
        [TestCase(46, 50, CreatureConstants.Slaad_Blue, RollConstants.OneD6Plus5)]
        [TestCase(51, 55, CreatureConstants.Slaad_Death, RollConstants.OneD2)]
        [TestCase(56, 60, CreatureConstants.TrumpetArchon, RollConstants.OneD3Plus1)]
        [TestCase(61, 65, CreatureConstants.Xorn_Elder, RollConstants.OneD6Plus5)]
        [TestCase(66, 70, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(71, 75, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(76, 80, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(81, 85, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(86, 100, CreatureConstants.Character + "[11]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
