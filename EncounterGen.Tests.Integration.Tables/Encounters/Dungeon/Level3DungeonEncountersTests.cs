using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level3DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 3, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 2, CreatureConstants.BombardierBeetle_Giant, RollConstants.OneD2)]
        [TestCase(3, 4, CreatureConstants.Centipede_Monstrous_Huge, RollConstants.OneD2)]
        [TestCase(5, 6, CreatureConstants.Badger_Dire, RollConstants.OneD2)]
        [TestCase(7, 8, CreatureConstants.Bat_Dire, RollConstants.OneD2)]
        [TestCase(9, 11, CreatureConstants.GelatinousCube, RollConstants.One)]
        [TestCase(12, 13, CreatureConstants.PrayingMantis_Giant, RollConstants.OneD2)]
        [TestCase(14, 14, CreatureConstants.Scorpion_Monstrous_Large, RollConstants.OneD2)]
        [TestCase(15, 15, CreatureConstants.Spider_Monstrous_Large, RollConstants.OneD2)]
        [TestCase(16, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 25, CreatureConstants.Imp, RollConstants.OneD2)]
        [TestCase(26, 30, CreatureConstants.Wererat, RollConstants.One,
            CreatureConstants.Rat_Dire, RollConstants.OneD3Plus1)]
        [TestCase(31, 35, CreatureConstants.DwarfWarrior, RollConstants.OneD6Plus3)]
        [TestCase(36, 40, CreatureConstants.Character + "[1]", RollConstants.OneD3Plus1)]
        [TestCase(41, 44, CreatureConstants.Dretch, RollConstants.OneD2)]
        [TestCase(45, 48, CreatureConstants.EtherealFilcher, RollConstants.One)]
        [TestCase(49, 52, CreatureConstants.PhantomFungus, RollConstants.One)]
        [TestCase(53, 56, CreatureConstants.Thoqqua, RollConstants.OneD2)]
        [TestCase(57, 60, CreatureConstants.Vargouille, RollConstants.OneD2)]
        [TestCase(61, 62, CreatureConstants.Bugbear, RollConstants.One,
            CreatureConstants.Goblin, RollConstants.OneD4Plus2)]
        [TestCase(63, 67, CreatureConstants.Gnoll, RollConstants.OneD3Plus1)]
        [TestCase(68, 69, CreatureConstants.Goblin, RollConstants.OneD4Plus2,
            CreatureConstants.Wolf, RollConstants.OneD3)]
        [TestCase(70, 71, CreatureConstants.Hobgoblin, RollConstants.OneD3,
            CreatureConstants.Wolf, RollConstants.OneD3)]
        [TestCase(72, 75, CreatureConstants.Kobold, RollConstants.OneD6Plus3,
            CreatureConstants.Weasel_Dire, RollConstants.One)]
        [TestCase(76, 80, CreatureConstants.Troglodyte, RollConstants.OneD3Plus1)]
        [TestCase(81, 90, CreatureConstants.Shadow, RollConstants.One)]
        [TestCase(91, 100, CreatureConstants.Skeleton_Ogre, RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
