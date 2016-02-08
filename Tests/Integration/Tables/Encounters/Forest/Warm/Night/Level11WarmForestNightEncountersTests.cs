using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Forest.Warm.Night
{
    [TestFixture]
    public class Level11WarmForestNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 11, EnvironmentConstants.WarmForestNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 2, CreatureConstants.Arrowhawk_Elder, RollConstants.OneD3Plus1)]
        [TestCase(3, 4, CreatureConstants.Barbazu, RollConstants.OneD6Plus5)]
        [TestCase(5, 6, CreatureConstants.Bodak, RollConstants.OneD3Plus1)]
        [TestCase(7, 12, CreatureConstants.Chuul, RollConstants.OneD4Plus2)]
        [TestCase(13, 16, CreatureConstants.Spider_Monstrous_Colossal, RollConstants.One)]
        [TestCase(17, 22, CreatureConstants.Couatl, RollConstants.OneD2)]
        [TestCase(23, 26, CreatureConstants.Naga_Dark, RollConstants.OneD3Plus1)]
        [TestCase(27, 28, CreatureConstants.Devourer, RollConstants.One)]
        [TestCase(29, 32, CreatureConstants.Lion_Dire, RollConstants.OneD6Plus5)]
        [TestCase(33, 34, CreatureConstants.Djinn, RollConstants.OneD6Plus5)]
        [TestCase(35, 36, CreatureConstants.Efreet, RollConstants.OneD3Plus1)]
        [TestCase(37, 38, CreatureConstants.Elemental_Air_Elder, RollConstants.One)]
        [TestCase(39, 40, CreatureConstants.Elemental_Earth_Elder, RollConstants.One)]
        [TestCase(41, 42, CreatureConstants.Elemental_Fire_Elder, RollConstants.One)]
        [TestCase(43, 44, CreatureConstants.Elemental_Water_Elder, RollConstants.One)]
        [TestCase(45, 46, CreatureConstants.Golem_Stone, RollConstants.One)]
        [TestCase(47, 50, CreatureConstants.Gorgon, RollConstants.OneD3Plus1)]
        [TestCase(51, 56, CreatureConstants.Gorillon, RollConstants.OneD6Plus3)]
        [TestCase(57, 62, CreatureConstants.Annis, RollConstants.One,
            CreatureConstants.GreenHag, RollConstants.One,
            CreatureConstants.SeaHag, RollConstants.One,
            CreatureConstants.Ogre, RollConstants.OneD4Plus2,
            CreatureConstants.Giant_Hill, RollConstants.OneD3)]
        [TestCase(63, 64, CreatureConstants.Hamatula, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.Hezrou, RollConstants.One)]
        [TestCase(67, 68, CreatureConstants.Mohrg, RollConstants.OneD3Plus1)]
        [TestCase(69, 70, CreatureConstants.Mohrg, RollConstants.OneD3Plus1,
            CreatureConstants.Zombie_Human, RollConstants.OneD6Plus5)]
        [TestCase(71, 72, CreatureConstants.Salamander_Noble, RollConstants.OneD2)]
        [TestCase(73, 74, CreatureConstants.ShadowMastiff, RollConstants.OneD6Plus5)]
        [TestCase(75, 76, CreatureConstants.Slaad_Blue, RollConstants.OneD3Plus1)]
        [TestCase(77, 78, CreatureConstants.Slaad_Gray, RollConstants.OneD2)]
        [TestCase(79, 80, CreatureConstants.Wraith, RollConstants.OneD6Plus5)]
        [TestCase(81, 82, CreatureConstants.Wraith_Dread, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(85, 86, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(87, 90, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(91, 92, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(93, 94, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(95, 100, CreatureConstants.Character + "[8]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
