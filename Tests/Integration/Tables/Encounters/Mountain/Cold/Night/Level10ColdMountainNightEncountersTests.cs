using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Mountain.Cold.Night
{
    [TestFixture]
    public class Level10ColdMountainNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 10, EnvironmentConstants.ColdMountainNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 6, CreatureConstants.Beholder, RollConstants.OneD4Plus2)]
        [TestCase(7, 12, CreatureConstants.Chimera, RollConstants.OneD3Plus1)]
        [TestCase(13, 18, CreatureConstants.Gargoyle, RollConstants.OneD6Plus5)]
        [TestCase(19, 24, CreatureConstants.Giant_Fire, RollConstants.One)]
        [TestCase(25, 30, CreatureConstants.Medusa, RollConstants.OneD3Plus1)]
        [TestCase(31, 36, CreatureConstants.OgreMage, RollConstants.OneD2,
            CreatureConstants.Ogre, RollConstants.OneD3Plus1)]
        [TestCase(37, 42, CreatureConstants.Giant_Hill, RollConstants.OneD3Plus1)]
        [TestCase(43, 52, CreatureConstants.Ettin, RollConstants.OneD3Plus1,
            CreatureConstants.Bear_Brown, RollConstants.OneD2)]
        [TestCase(53, 54, CreatureConstants.AnimatedObject_Colossal, RollConstants.One)]
        [TestCase(55, 56, CreatureConstants.Bebilith, RollConstants.OneD6Plus5)]
        [TestCase(57, 58, CreatureConstants.FormianMyrmarch, RollConstants.One)]
        [TestCase(59, 60, CreatureConstants.Golem_Clay, RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.Golem_Flesh, RollConstants.One)]
        [TestCase(63, 64, CreatureConstants.Avoral, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.NightHag, RollConstants.One,
            CreatureConstants.Nightmare, RollConstants.One)]
        [TestCase(67, 68, CreatureConstants.NessianWarhound, RollConstants.One)]
        [TestCase(69, 70, CreatureConstants.Janni, RollConstants.One)]
        [TestCase(71, 72, CreatureConstants.Lillend, RollConstants.One)]
        [TestCase(73, 74, CreatureConstants.Salamander_Noble, RollConstants.OneD3Plus1)]
        [TestCase(75, 76, CreatureConstants.Slaad_Gray, RollConstants.OneD3Plus1)]
        [TestCase(77, 78, CreatureConstants.Slaad_Red, RollConstants.OneD2)]
        [TestCase(79, 80, CreatureConstants.Spectre, RollConstants.OneD6Plus5)]
        [TestCase(81, 82, CreatureConstants.Vrock, RollConstants.OneD3Plus1)]
        [TestCase(83, 84, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Colossal, RollConstants.One)]
        [TestCase(85, 86, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(87, 88, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(89, 92, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(93, 94, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(95, 96, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(97, 100, CreatureConstants.Character + "[7]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
