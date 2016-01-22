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

        [TestCase(1, 6, CreatureConstants.Annis, RollConstants.One,
            CreatureConstants.GreenHag, RollConstants.One,
            CreatureConstants.SeaHag, RollConstants.One,
            CreatureConstants.Ogre, RollConstants.OneD4Plus2,
            CreatureConstants.Giant_Hill, RollConstants.OneD3)]
        [TestCase(7, 12, CreatureConstants.Giant_Stone, RollConstants.OneD3Plus1)]
        [TestCase(13, 18, CreatureConstants.Lion_Dire, RollConstants.OneD6Plus5)]
        [TestCase(19, 28, CreatureConstants.Ettin, RollConstants.OneD3Plus1,
            CreatureConstants.Bear_Brown, RollConstants.OneD2,
            CreatureConstants.Goblin, RollConstants.OneD4Plus10)]
        [TestCase(29, 38, CreatureConstants.Ettin, RollConstants.OneD3Plus1,
            CreatureConstants.Bear_Brown, RollConstants.OneD2,
            CreatureConstants.Orc, RollConstants.OneD6Plus5)]
        [TestCase(39, 40, CreatureConstants.Arrowhawk_Elder, RollConstants.OneD3Plus1)]
        [TestCase(41, 42, CreatureConstants.Barbazu, RollConstants.OneD6Plus5)]
        [TestCase(43, 44, CreatureConstants.Bodak, RollConstants.OneD3Plus1)]
        [TestCase(45, 46, CreatureConstants.Devourer, RollConstants.One)]
        [TestCase(47, 48, CreatureConstants.Djinn, RollConstants.OneD6Plus5)]
        [TestCase(49, 50, CreatureConstants.Elemental_Air_Elder, RollConstants.One)]
        [TestCase(51, 52, CreatureConstants.Elemental_Earth_Elder, RollConstants.One)]
        [TestCase(53, 54, CreatureConstants.Elemental_Fire_Elder, RollConstants.One)]
        [TestCase(55, 56, CreatureConstants.Elemental_Water_Elder, RollConstants.One)]
        [TestCase(57, 58, CreatureConstants.Efreet, RollConstants.OneD3Plus1)]
        [TestCase(59, 60, CreatureConstants.Golem_Stone, RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.Hamatula, RollConstants.One)]
        [TestCase(63, 64, CreatureConstants.Hezrou, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.Mohrg, RollConstants.OneD3Plus1)]
        [TestCase(67, 68, CreatureConstants.Mohrg, RollConstants.OneD3Plus1,
            CreatureConstants.Zombie_HumanCommoner, RollConstants.OneD6Plus5)]
        [TestCase(69, 70, CreatureConstants.Salamander_Noble, RollConstants.OneD2)]
        [TestCase(71, 72, CreatureConstants.ShadowMastiff, RollConstants.OneD6Plus5)]
        [TestCase(73, 74, CreatureConstants.Slaad_Blue, RollConstants.OneD3Plus1)]
        [TestCase(75, 76, CreatureConstants.Slaad_Gray, RollConstants.OneD2)]
        [TestCase(77, 78, CreatureConstants.Wraith, RollConstants.OneD6Plus5)]
        [TestCase(79, 80, CreatureConstants.Wraith_Dread, RollConstants.One)]
        [TestCase(81, 82, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(85, 90, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(91, 92, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(93, 94, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(95, 100, CreatureConstants.Character + "[8]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
