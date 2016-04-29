using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level6DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 6, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 2, CreatureConstants.Digester, RollConstants.One)]
        [TestCase(3, 4, CreatureConstants.Ape_Dire, RollConstants.OneD3Plus1)]
        [TestCase(5, 6, CreatureConstants.Wolf_Dire, RollConstants.OneD3Plus1)]
        [TestCase(7, 7, CreatureConstants.StagBeetle_Giant, RollConstants.OneD3)]
        [TestCase(8, 9, CreatureConstants.Wasp_Giant, RollConstants.OneD3Plus1)]
        [TestCase(10, 12, CreatureConstants.Owlbear, RollConstants.OneD3)]
        [TestCase(13, 15, CreatureConstants.ShamblingMound, RollConstants.One)]
        [TestCase(16, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 22, CreatureConstants.Annis, RollConstants.One)]
        [TestCase(23, 25, CreatureConstants.Harpy, RollConstants.OneD3)]
        [TestCase(26, 26, CreatureConstants.Quasit, RollConstants.One,
            CreatureConstants.Dretch, RollConstants.OneD2)]
        [TestCase(27, 28, CreatureConstants.Wereboar, RollConstants.OneD3Plus1)]
        [TestCase(29, 30, CreatureConstants.Werewolf, RollConstants.OneD3Plus1)]
        [TestCase(31, 35, CreatureConstants.Werebear, RollConstants.OneD2)]
        [TestCase(36, 40, CreatureConstants.Character + "[3]", RollConstants.OneD3Plus1)]
        [TestCase(41, 43, CreatureConstants.Arrowhawk_Juvenile, RollConstants.OneD3Plus1)]
        [TestCase(44, 46, CreatureConstants.Basilisk, RollConstants.OneD2)]
        [TestCase(47, 50, CreatureConstants.DisplacerBeast, RollConstants.OneD3)]
        [TestCase(51, 53, CreatureConstants.Gargoyle, RollConstants.OneD3)]
        [TestCase(54, 56, CreatureConstants.HellHound, RollConstants.OneD3Plus1)]
        [TestCase(57, 59, CreatureConstants.Howler, RollConstants.OneD3Plus1)]
        [TestCase(60, 62, CreatureConstants.Otyugh, RollConstants.OneD3)]
        [TestCase(63, 65, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Large, RollConstants.One)]
        [TestCase(66, 67, CreatureConstants.Xorn_Minor, RollConstants.OneD3Plus1)]
        [TestCase(68, 70, CreatureConstants.YethHound, RollConstants.OneD3Plus1)]
        [TestCase(71, 77, CreatureConstants.Ettin, RollConstants.One,
            CreatureConstants.Orc, RollConstants.OneD6Plus3)]
        [TestCase(78, 82, CreatureConstants.Ogre, RollConstants.OneD3,
            CreatureConstants.Boar, RollConstants.OneD3)]
        [TestCase(83, 90, CreatureConstants.Weretiger, RollConstants.OneD2)]
        [TestCase(91, 100, CreatureConstants.Zombie_HillGiant, RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
