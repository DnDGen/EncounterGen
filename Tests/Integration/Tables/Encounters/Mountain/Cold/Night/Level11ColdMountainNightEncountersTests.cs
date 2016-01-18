using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
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

        [TestCase(1, 4, CreatureConstants.Annis, RollConstants.One,
            CreatureConstants.GreenHag, RollConstants.One,
            CreatureConstants.SeaHag, RollConstants.One,
            CreatureConstants.Ogre, RollConstants.OneD4Plus2,
            CreatureConstants.Giant_Hill, RollConstants.OneD3)]
        [TestCase(5, 8, CreatureConstants.Giant_Stone, RollConstants.OneD3Plus1)]
        [TestCase(9, 12, CreatureConstants.Lion_Dire, RollConstants.OneD6Plus5)]
        [TestCase(13, 18, CreatureConstants.Ettin, RollConstants.OneD3Plus1,
            CreatureConstants.Bear_Brown, RollConstants.OneD2,
            CreatureConstants.Goblin, RollConstants.OneD4Plus10)]
        [TestCase(19, 24, CreatureConstants.Ettin, RollConstants.OneD3Plus1,
            CreatureConstants.Bear_Brown, RollConstants.OneD2,
            CreatureConstants.Orc, RollConstants.OneD6Plus5)]
        [TestCase(25, 26, CreatureConstants.Arrowhawk_Elder, RollConstants.OneD3Plus1)]
        [TestCase(27, 28, CreatureConstants.Barbazu, RollConstants.OneD6Plus5)]
        [TestCase(29, 30, CreatureConstants.Bodak, RollConstants.OneD3Plus1)]
        [TestCase(31, 32, CreatureConstants.Devourer, RollConstants.One)]
        [TestCase(33, 34, CreatureConstants.Djinn, RollConstants.OneD6Plus5)]
        [TestCase(35, 36, CreatureConstants.Elemental_Air_Elder, RollConstants.One)]
        [TestCase(37, 38, CreatureConstants.Elemental_Earth_Elder, RollConstants.One)]
        [TestCase(39, 40, CreatureConstants.Elemental_Fire_Elder, RollConstants.One)]
        [TestCase(41, 42, CreatureConstants.Elemental_Water_Elder, RollConstants.One)]
        [TestCase(43, 44, CreatureConstants.Efreet, RollConstants.OneD3Plus1)]
        [TestCase(45, 46, CreatureConstants.Golem_Stone, RollConstants.One)]
        [TestCase(47, 48, CreatureConstants.Hamatula, RollConstants.One)]
        [TestCase(49, 50, CreatureConstants.Hezrou, RollConstants.One)]
        [TestCase(51, 52, CreatureConstants.Mohrg, RollConstants.OneD3Plus1)]
        [TestCase(53, 54, CreatureConstants.Mohrg, RollConstants.OneD3Plus1,
            CreatureConstants.Zombie_HumanCommoner, RollConstants.OneD6Plus5)]
        [TestCase(55, 56, CreatureConstants.Salamander_Noble, RollConstants.OneD2)]
        [TestCase(57, 58, CreatureConstants.ShadowMastiff, RollConstants.OneD6Plus5)]
        [TestCase(59, 60, CreatureConstants.Slaad_Blue, RollConstants.OneD3Plus1)]
        [TestCase(61, 62, CreatureConstants.Slaad_Gray, RollConstants.OneD2)]
        [TestCase(63, 64, CreatureConstants.Wraith, RollConstants.OneD6Plus5)]
        [TestCase(65, 66, CreatureConstants.Wraith_Dread, RollConstants.One)]
        [TestCase(67, 68, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(69, 70, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(71, 74, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(75, 100, CreatureConstants.Character + "[8]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
