using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Mountain.Warm.Night
{
    [TestFixture]
    public class Level15WarmMountainNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 15, EnvironmentConstants.WarmMountainNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 7, CreatureConstants.TrumpetArchon, RollConstants.OneD2)]
        [TestCase(8, 14, CreatureConstants.AstralDeva, RollConstants.OneD2)]
        [TestCase(15, 21, CreatureConstants.Glabrezu, RollConstants.One,
            CreatureConstants.Succubus, RollConstants.One,
            CreatureConstants.Vrock, RollConstants.OneD3Plus1)]
        [TestCase(22, 28, CreatureConstants.Hamatula, RollConstants.OneD4Plus2)]
        [TestCase(29, 35, CreatureConstants.Nightwing, RollConstants.OneD2)]
        [TestCase(36, 42, CreatureConstants.Osyluth, RollConstants.OneD6Plus5)]
        [TestCase(43, 49, CreatureConstants.Vrock, RollConstants.OneD6Plus5)]
        [TestCase(50, 63, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(64, 70, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(71, 77, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(78, 84, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(85, 100, CreatureConstants.Character + "[12]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
