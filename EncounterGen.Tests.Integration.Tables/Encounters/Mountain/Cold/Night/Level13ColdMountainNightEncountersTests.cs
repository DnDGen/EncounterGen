using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Mountain.Cold.Night
{
    [TestFixture]
    public class Level13ColdMountainNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 13, EnvironmentConstants.ColdMountainNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 9, CreatureConstants.Chimera, RollConstants.OneD6Plus5)]
        [TestCase(10, 18, CreatureConstants.Giant_Fire, RollConstants.OneD3Plus1)]
        [TestCase(19, 27, CreatureConstants.Giant_Hill, RollConstants.OneD6Plus3,
            CreatureConstants.Wolf_Dire, RollConstants.OneD3Plus1)]
        [TestCase(28, 36, CreatureConstants.Giant_Stone, RollConstants.OneD6Plus3)]
        [TestCase(37, 39, CreatureConstants.Ghaele, RollConstants.One)]
        [TestCase(40, 42, CreatureConstants.FormianMyrmarch, RollConstants.OneD3Plus1)]
        [TestCase(43, 45, CreatureConstants.Gelugon, RollConstants.One)]
        [TestCase(46, 48, CreatureConstants.Glabrezu, RollConstants.One)]
        [TestCase(49, 51, CreatureConstants.Golem_Clay, RollConstants.OneD3Plus1)]
        [TestCase(52, 54, CreatureConstants.Golem_Iron, RollConstants.One)]
        [TestCase(55, 57, CreatureConstants.Hellcat, RollConstants.OneD6Plus5)]
        [TestCase(58, 60, CreatureConstants.Kyton, RollConstants.OneD4Plus10)]
        [TestCase(61, 63, CreatureConstants.Slaad_Death, RollConstants.One)]
        [TestCase(64, 66, CreatureConstants.Slaad_Red, RollConstants.OneD6Plus5)]
        [TestCase(67, 69, CreatureConstants.Spectre, RollConstants.OneD6Plus5)]
        [TestCase(70, 72, CreatureConstants.Vrock, RollConstants.OneD4Plus2)]
        [TestCase(73, 75, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(76, 78, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(79, 84, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(85, 87, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(88, 90, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(91, 100, CreatureConstants.Character + "[10]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
