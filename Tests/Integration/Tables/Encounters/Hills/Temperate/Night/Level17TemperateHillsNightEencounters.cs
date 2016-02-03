using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Temperate.Night
{
    [TestFixture]
    public class Level17TemperateHillsNightEencounters : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 17, EnvironmentConstants.TemperateHillsNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 7, CreatureConstants.TrumpetArchon, RollConstants.OneD3Plus1)]
        [TestCase(8, 14, CreatureConstants.AstralDeva, RollConstants.OneD3Plus1)]
        [TestCase(15, 21, CreatureConstants.Hamatula, RollConstants.OneD6Plus5)]
        [TestCase(22, 28, CreatureConstants.Marilith, RollConstants.One)]
        [TestCase(29, 35, CreatureConstants.Nightwalker, RollConstants.OneD2)]
        [TestCase(36, 42, CreatureConstants.Planetar, RollConstants.OneD2)]
        [TestCase(43, 49, CreatureConstants.Salamander_Noble, RollConstants.OneD4Plus10)]
        [TestCase(50, 63, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(64, 70, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(71, 77, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(78, 100, CreatureConstants.Character + "[14]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
