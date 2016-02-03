using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Plains.Cold.Night
{
    [TestFixture]
    public class Level13ColdPlainsNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 13, EnvironmentConstants.ColdPlainsNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 12, CreatureConstants.Chimera, RollConstants.OneD6Plus5)]
        [TestCase(13, 24, CreatureConstants.Giant_Fire, RollConstants.OneD3Plus1)]
        [TestCase(25, 27, CreatureConstants.FormianMyrmarch, RollConstants.OneD3Plus1)]
        [TestCase(28, 30, CreatureConstants.Gelugon, RollConstants.One)]
        [TestCase(31, 33, CreatureConstants.Ghaele, RollConstants.One)]
        [TestCase(34, 36, CreatureConstants.Glabrezu, RollConstants.One)]
        [TestCase(37, 39, CreatureConstants.Golem_Clay, RollConstants.OneD3Plus1)]
        [TestCase(40, 42, CreatureConstants.Golem_Iron, RollConstants.One)]
        [TestCase(43, 54, CreatureConstants.Naga_Guardian, RollConstants.OneD3Plus1)]
        [TestCase(55, 57, CreatureConstants.Hellcat, RollConstants.OneD6Plus5)]
        [TestCase(58, 60, CreatureConstants.Kyton, RollConstants.OneD4Plus10)]
        [TestCase(61, 63, CreatureConstants.Slaad_Death, RollConstants.One)]
        [TestCase(64, 66, CreatureConstants.Slaad_Red, RollConstants.OneD6Plus5)]
        [TestCase(67, 69, CreatureConstants.Spectre, RollConstants.OneD6Plus5)]
        [TestCase(70, 72, CreatureConstants.Vrock, RollConstants.OneD4Plus2)]
        [TestCase(73, 81, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(82, 84, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(85, 87, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(88, 90, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(91, 93, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(94, 100, CreatureConstants.Character + "[10]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
