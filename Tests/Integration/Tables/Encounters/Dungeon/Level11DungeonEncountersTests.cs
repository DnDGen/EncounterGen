using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level11DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 11, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, CreatureConstants.Tiger_Dire, RollConstants.OneD3)]
        [TestCase(6, 15, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(16, 18, CreatureConstants.Annis, RollConstants.One,
            CreatureConstants.SeaHag, RollConstants.One,
            CreatureConstants.GreenHag, RollConstants.One,
            CreatureConstants.Ogre, RollConstants.OneD4Plus2,
            CreatureConstants.Giant_Hill, RollConstants.OneD3)]
        [TestCase(19, 21, CreatureConstants.Efreet, RollConstants.OneD3Plus1)]
        [TestCase(22, 24, CreatureConstants.FormianMyrmarch, RollConstants.One,
            CreatureConstants.FormianWarrior, RollConstants.OneD6Plus3)]
        [TestCase(25, 27, CreatureConstants.Gynosphinx, RollConstants.OneD3Plus1)]
        [TestCase(28, 30, CreatureConstants.Naga_Dark, RollConstants.OneD3Plus1)]
        [TestCase(31, 35, CreatureConstants.Avoral, RollConstants.OneD3)]
        [TestCase(36, 45, CreatureConstants.Character + "[8]", RollConstants.OneD3Plus1)]
        [TestCase(46, 48, CreatureConstants.Arrowhawk_Elder, RollConstants.OneD3Plus1)]
        [TestCase(49, 51, CreatureConstants.Destrachan, RollConstants.OneD3Plus1)]
        [TestCase(52, 54, CreatureConstants.Golem_Clay, RollConstants.OneD2)]
        [TestCase(55, 57, CreatureConstants.Gorgon, RollConstants.OneD3Plus1)]
        [TestCase(58, 59, CreatureConstants.Hydra + " (1d3+7 heads)", RollConstants.One)]
        [TestCase(60, 62, CreatureConstants.Slaad_Blue, RollConstants.OneD3Plus1)]
        [TestCase(63, 65, CreatureConstants.Xorn_Elder, RollConstants.OneD3Plus1)]
        [TestCase(66, 70, CreatureConstants.Giant_Fire, RollConstants.One,
            CreatureConstants.HellHound, RollConstants.OneD6Plus3)]
        [TestCase(71, 75, CreatureConstants.Giant_Stone, RollConstants.OneD3Plus1)]
        [TestCase(76, 80, CreatureConstants.Hamatula, RollConstants.OneD3Plus1)]
        [TestCase(81, 90, CreatureConstants.Devourer, RollConstants.One)]
        [TestCase(91, 100, CreatureConstants.Mohrg, RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
