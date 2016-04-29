using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level7DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 7, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.BlackPudding, RollConstants.One)]
        [TestCase(5, 5, CreatureConstants.Centipede_Monstrous_Gargantuan, RollConstants.OneD2)]
        [TestCase(6, 8, CreatureConstants.Criosphinx, RollConstants.One)]
        [TestCase(9, 10, CreatureConstants.Boar_Dire, RollConstants.OneD3Plus1)]
        [TestCase(11, 14, CreatureConstants.Remorhaz, RollConstants.One)]
        [TestCase(15, 15, CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.OneD2)]
        [TestCase(16, 20, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(21, 22, CreatureConstants.Aranea, RollConstants.OneD3Plus1)]
        [TestCase(23, 24, CreatureConstants.Barghest, RollConstants.OneD3Plus1)]
        [TestCase(25, 26, CreatureConstants.Djinn, RollConstants.OneD3Plus1)]
        [TestCase(27, 28, CreatureConstants.FormianTaskmaster, RollConstants.One,
            CreatureConstants.Minotaur, RollConstants.One)]
        [TestCase(29, 30, CreatureConstants.Janni, RollConstants.OneD3Plus1)]
        [TestCase(31, 35, CreatureConstants.HoundArchon, RollConstants.OneD3Plus1)]
        [TestCase(36, 40, CreatureConstants.Character + "[4]", RollConstants.OneD3Plus1)]
        [TestCase(41, 45, CreatureConstants.Cloaker, RollConstants.OneD3)]
        [TestCase(46, 48, CreatureConstants.Cryohydra + " (1d3+4 heads)", RollConstants.One)]
        [TestCase(49, 52, CreatureConstants.FormianWarrior, RollConstants.OneD4Plus2)]
        [TestCase(53, 57, CreatureConstants.InvisibleStalker, RollConstants.One)]
        [TestCase(58, 60, CreatureConstants.Pyrohydra + " (1d3+4 heads)", RollConstants.One)]
        [TestCase(61, 65, CreatureConstants.Bugbear, RollConstants.OneD3Plus1,
            CreatureConstants.Wolf, RollConstants.OneD3Plus1)]
        [TestCase(66, 70, CreatureConstants.Ettin, RollConstants.One,
            CreatureConstants.Bear_Brown, RollConstants.OneD2)]
        [TestCase(71, 75, CreatureConstants.Minotaur, RollConstants.OneD3Plus1)]
        [TestCase(76, 80, CreatureConstants.Salamander_Average, RollConstants.OneD3Plus1)]
        [TestCase(81, 90, CreatureConstants.Ghost + "[1d3+3]", RollConstants.One)]
        [TestCase(91, 100, CreatureConstants.Vampire + "[1d2+4]", RollConstants.One)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
