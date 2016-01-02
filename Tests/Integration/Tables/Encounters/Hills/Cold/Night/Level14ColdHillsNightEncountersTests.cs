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

        [TestCase(1, 12, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(13, 18, CreatureConstants.AstralDeva, RollConstants.One)]
        [TestCase(19, 24, CreatureConstants.Efreet, RollConstants.OneD6Plus5)]
        [TestCase(25, 30, CreatureConstants.Ghaele, RollConstants.OneD2)]
        [TestCase(31, 36, CreatureConstants.Golem_Stone, RollConstants.OneD3Plus1)]
        [TestCase(37, 42, CreatureConstants.Hezrou, RollConstants.OneD3Plus1)]
        [TestCase(43, 48, CreatureConstants.Nalfeshnee, RollConstants.One)]
        [TestCase(49, 54, CreatureConstants.Nightwing, RollConstants.One)]
        [TestCase(55, 60, CreatureConstants.Slaad_Blue, RollConstants.OneD6Plus5)]
        [TestCase(61, 66, CreatureConstants.Slaad_Death, RollConstants.OneD2)]
        [TestCase(67, 72, CreatureConstants.TrumpetArchon, RollConstants.OneD3Plus1)]
        [TestCase(73, 100, CreatureConstants.Character + "11", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
