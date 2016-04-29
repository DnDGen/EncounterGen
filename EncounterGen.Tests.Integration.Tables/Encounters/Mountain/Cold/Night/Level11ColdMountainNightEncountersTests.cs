using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Mountain.Cold.Night
{
    [TestFixture]
    public class Level11ColdMountainNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 11, EnvironmentConstants.ColdMountainNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 6, CreatureConstants.Annis, RollConstants.One,
            CreatureConstants.GreenHag, RollConstants.One,
            CreatureConstants.SeaHag, RollConstants.One,
            CreatureConstants.Ogre, RollConstants.OneD4Plus2,
            CreatureConstants.Giant_Hill, RollConstants.OneD3)]
        [TestCase(7, 12, CreatureConstants.Giant_Stone, RollConstants.OneD3Plus1)]
        [TestCase(13, 18, CreatureConstants.Lion_Dire, RollConstants.OneD6Plus5)]
        [TestCase(19, 26, CreatureConstants.Ettin, RollConstants.OneD3Plus1,
            CreatureConstants.Bear_Brown, RollConstants.OneD2,
            CreatureConstants.Goblin, RollConstants.OneD4Plus10)]
        [TestCase(27, 34, CreatureConstants.Ettin, RollConstants.OneD3Plus1,
            CreatureConstants.Bear_Brown, RollConstants.OneD2,
            CreatureConstants.Orc, RollConstants.OneD6Plus5)]
        [TestCase(35, 36, CreatureConstants.Arrowhawk_Elder, RollConstants.OneD3Plus1)]
        [TestCase(37, 38, CreatureConstants.Barbazu, RollConstants.OneD6Plus5)]
        [TestCase(39, 40, CreatureConstants.Bodak, RollConstants.OneD3Plus1)]
        [TestCase(41, 42, CreatureConstants.Devourer, RollConstants.One)]
        [TestCase(43, 44, CreatureConstants.Djinn, RollConstants.OneD6Plus5)]
        [TestCase(45, 46, CreatureConstants.Elemental_Air_Elder, RollConstants.One)]
        [TestCase(47, 48, CreatureConstants.Elemental_Earth_Elder, RollConstants.One)]
        [TestCase(49, 50, CreatureConstants.Elemental_Fire_Elder, RollConstants.One)]
        [TestCase(51, 52, CreatureConstants.Elemental_Water_Elder, RollConstants.One)]
        [TestCase(53, 54, CreatureConstants.Efreet, RollConstants.OneD3Plus1)]
        [TestCase(55, 56, CreatureConstants.Golem_Stone, RollConstants.One)]
        [TestCase(57, 58, CreatureConstants.Hamatula, RollConstants.One)]
        [TestCase(59, 60, CreatureConstants.Hezrou, RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.Mohrg, RollConstants.OneD3Plus1)]
        [TestCase(63, 64, CreatureConstants.Mohrg, RollConstants.OneD3Plus1,
            CreatureConstants.Zombie_Human, RollConstants.OneD6Plus5)]
        [TestCase(65, 66, CreatureConstants.Salamander_Noble, RollConstants.OneD2)]
        [TestCase(67, 68, CreatureConstants.ShadowMastiff, RollConstants.OneD6Plus5)]
        [TestCase(69, 70, CreatureConstants.Slaad_Blue, RollConstants.OneD3Plus1)]
        [TestCase(71, 72, CreatureConstants.Slaad_Gray, RollConstants.OneD2)]
        [TestCase(73, 74, CreatureConstants.Wraith, RollConstants.OneD6Plus5)]
        [TestCase(75, 76, CreatureConstants.Wraith_Dread, RollConstants.One)]
        [TestCase(77, 78, CreatureConstants.FormianTaskmaster, RollConstants.OneD3Plus1,
            CreatureConstants.DominatedCreature + "[4]", RollConstants.OneD3Plus1)]
        [TestCase(79, 80, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(81, 82, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(83, 88, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(89, 90, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(91, 92, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(93, 100, CreatureConstants.Character + "[8]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
