using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level12DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 12, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.PurpleWorm, RollConstants.One)]
        [TestCase(5, 5, CreatureConstants.Scorpion_Monstrous_Colossal, RollConstants.OneD2)]
        [TestCase(6, 15, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(16, 20, CreatureConstants.MindFlayer, RollConstants.OneD4Plus2)]
        [TestCase(21, 25, CreatureConstants.Naga_Spirit, RollConstants.OneD3Plus1)]
        [TestCase(26, 30, CreatureConstants.Slaad_Green, RollConstants.OneD3Plus1)]
        [TestCase(31, 35, CreatureConstants.Giant_Cloud + " (good)", RollConstants.One,
            CreatureConstants.Lion_Dire, RollConstants.OneD4Plus2)]
        [TestCase(36, 50, CreatureConstants.Character + "9", RollConstants.OneD3Plus1)]
        [TestCase(51, 55, CreatureConstants.Cryohydra + ", 1d3+9 heads", RollConstants.One)]
        [TestCase(56, 60, CreatureConstants.Golem_Stone, RollConstants.OneD2)]
        [TestCase(61, 65, CreatureConstants.Pyrohydra + ", 1d3+9 heads", RollConstants.One)]
        [TestCase(66, 70, CreatureConstants.Yrthak, RollConstants.OneD3Plus1)]
        [TestCase(71, 75, CreatureConstants.Cornugon, RollConstants.One,
            CreatureConstants.Hamatula, RollConstants.OneD3)]
        [TestCase(76, 80, CreatureConstants.Giant_Cloud + " (evil)", RollConstants.One,
            CreatureConstants.Lion_Dire, RollConstants.OneD4Plus2)]
        [TestCase(81, 85, CreatureConstants.Giant_Frost, RollConstants.OneD3Plus1)]
        [TestCase(86, 90, CreatureConstants.Salamander_Large, RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Vampire, RollConstants.One)]
        public override void Percentile(Int32 lower, Int32 upper, params String[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
