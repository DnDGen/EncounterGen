using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Cold.Day
{
    [TestFixture]
    public class Level15ColdHillsDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 15, EnvironmentConstants.ColdHillsDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 7, CreatureConstants.AstralDeva, RollConstants.OneD2)]
        [TestCase(8, 14, CreatureConstants.Glabrezu, RollConstants.One,
            CreatureConstants.Succubus, RollConstants.One,
            CreatureConstants.Vrock, RollConstants.OneD3Plus1)]
        [TestCase(15, 21, CreatureConstants.Hamatula, RollConstants.OneD4Plus2)]
        [TestCase(22, 28, CreatureConstants.Osyluth, RollConstants.OneD6Plus5)]
        [TestCase(29, 35, CreatureConstants.TrumpetArchon, RollConstants.OneD2)]
        [TestCase(36, 42, CreatureConstants.Vrock, RollConstants.OneD6Plus5)]
        [TestCase(43, 56, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(57, 63, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(64, 70, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(71, 77, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(78, 100, CreatureConstants.Character + "[12]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
