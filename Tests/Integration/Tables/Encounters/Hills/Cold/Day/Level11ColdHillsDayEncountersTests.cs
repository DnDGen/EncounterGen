using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Cold.Day
{
    [TestFixture]
    public class Level11ColdHillsDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 11, EnvironmentConstants.ColdHillsDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 8, CreatureConstants.Annis, RollConstants.One,
            CreatureConstants.GreenHag, RollConstants.One,
            CreatureConstants.SeaHag, RollConstants.One,
            CreatureConstants.Ogre, RollConstants.OneD4Plus2,
            CreatureConstants.Giant_Hill, RollConstants.OneD3)]
        [TestCase(9, 10, CreatureConstants.Arrowhawk_Elder, RollConstants.OneD3Plus1)]
        [TestCase(11, 12, CreatureConstants.Barbazu, RollConstants.OneD6Plus5)]
        [TestCase(13, 14, CreatureConstants.Devourer, RollConstants.One)]
        [TestCase(15, 22, CreatureConstants.Lion_Dire, RollConstants.OneD6Plus5)]
        [TestCase(23, 24, CreatureConstants.Djinn, RollConstants.OneD6Plus5)]
        [TestCase(25, 26, CreatureConstants.Efreet, RollConstants.OneD3Plus1)]
        [TestCase(27, 28, CreatureConstants.Elemental_Air_Elder, RollConstants.One)]
        [TestCase(29, 30, CreatureConstants.Elemental_Earth_Elder, RollConstants.One)]
        [TestCase(31, 32, CreatureConstants.Elemental_Fire_Elder, RollConstants.One)]
        [TestCase(33, 34, CreatureConstants.Elemental_Water_Elder, RollConstants.One)]
        [TestCase(35, 46, CreatureConstants.Ettin, RollConstants.OneD3Plus1,
            CreatureConstants.Bear_Brown, RollConstants.OneD2,
            CreatureConstants.Goblin, RollConstants.OneD4Plus10)]
        [TestCase(47, 58, CreatureConstants.Ettin, RollConstants.OneD3Plus1,
            CreatureConstants.Bear_Brown, RollConstants.OneD2,
            CreatureConstants.Orc, RollConstants.OneD6Plus5)]
        [TestCase(59, 60, CreatureConstants.Golem_Stone, RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.Hamatula, RollConstants.One)]
        [TestCase(63, 64, CreatureConstants.Hezrou, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.Mohrg, RollConstants.OneD3Plus1)]
        [TestCase(67, 68, CreatureConstants.Mohrg, RollConstants.OneD3Plus1,
            CreatureConstants.Zombie_HumanCommoner, RollConstants.OneD6Plus5)]
        [TestCase(69, 70, CreatureConstants.Salamander_Noble, RollConstants.OneD2)]
        [TestCase(71, 72, CreatureConstants.Slaad_Blue, RollConstants.OneD3Plus1)]
        [TestCase(73, 74, CreatureConstants.Slaad_Gray, RollConstants.OneD2)]
        [TestCase(75, 76, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(77, 78, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(79, 86, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(87, 88, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(89, 90, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(91, 100, CreatureConstants.Character + "[8]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
