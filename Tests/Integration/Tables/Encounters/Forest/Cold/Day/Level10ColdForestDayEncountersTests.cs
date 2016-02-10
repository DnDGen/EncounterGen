using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Forest.Cold.Day
{
    [TestFixture]
    public class Level10ColdForestDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 10, EnvironmentConstants.ColdForestDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 6, CreatureConstants.Pixie, RollConstants.OneD6Plus5)]
        [TestCase(7, 12, CreatureConstants.Beholder, RollConstants.OneD4Plus2)]
        [TestCase(13, 18, CreatureConstants.Chimera, RollConstants.OneD3Plus1)]
        [TestCase(19, 24, CreatureConstants.Gargoyle, RollConstants.OneD6Plus5)]
        [TestCase(25, 30, CreatureConstants.Giant_Fire, RollConstants.One)]
        [TestCase(31, 36, CreatureConstants.Medusa, RollConstants.OneD3Plus1)]
        [TestCase(37, 42, CreatureConstants.OgreMage, RollConstants.OneD2,
            CreatureConstants.Ogre, RollConstants.OneD3Plus1)]
        [TestCase(43, 44, CreatureConstants.AnimatedObject_Colossal, RollConstants.One)]
        [TestCase(45, 46, CreatureConstants.Bebilith, RollConstants.One)]
        [TestCase(47, 48, CreatureConstants.FormianMyrmarch, RollConstants.One)]
        [TestCase(49, 50, CreatureConstants.Golem_Clay, RollConstants.One)]
        [TestCase(51, 52, CreatureConstants.Golem_Flesh, RollConstants.OneD3Plus1)]
        [TestCase(53, 54, CreatureConstants.Avoral, RollConstants.OneD2)]
        [TestCase(55, 56, CreatureConstants.NessianWarhound, RollConstants.OneD2)]
        [TestCase(57, 58, CreatureConstants.Janni, RollConstants.OneD6Plus5)]
        [TestCase(59, 60, CreatureConstants.Lillend, RollConstants.OneD3Plus1)]
        [TestCase(61, 62, CreatureConstants.Salamander_Noble, RollConstants.One)]
        [TestCase(63, 64, CreatureConstants.Slaad_Gray, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.Slaad_Red, RollConstants.OneD3Plus1)]
        [TestCase(67, 68, CreatureConstants.Vrock, RollConstants.OneD2)]
        [TestCase(69, 70, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Colossal, RollConstants.One)]
        [TestCase(71, 76, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(77, 78, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(79, 80, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(81, 82, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(85, 100, CreatureConstants.Character + "[7]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
