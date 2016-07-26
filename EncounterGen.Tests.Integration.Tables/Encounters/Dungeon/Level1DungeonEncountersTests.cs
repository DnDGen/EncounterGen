using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level1DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 1, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.Centipede_Monstrous_Medium, RollConstants.OneD3)]
        [TestCase(5, 9, CreatureConstants.Rat_Dire, RollConstants.OneD3Plus1)]
        [TestCase(10, 14, CreatureConstants.FireBeetle_Giant, RollConstants.OneD3Plus1)]
        [TestCase(15, 17, CreatureConstants.Scorpion_Monstrous_Small, RollConstants.OneD3)]
        [TestCase(18, 20, CreatureConstants.Spider_Monstrous_Small, RollConstants.OneD3)]
        [TestCase(21, 25, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(26, 30, CreatureConstants.DwarfWarrior, RollConstants.OneD3)]
        [TestCase(31, 35, CreatureConstants.ElfWarrior, RollConstants.OneD3)]
        [TestCase(36, 40, CreatureConstants.Character + "[1]", RollConstants.One)]
        [TestCase(41, 45, CreatureConstants.Darkmantle, RollConstants.One)]
        [TestCase(46, 55, CreatureConstants.Krenshar, RollConstants.One)]
        [TestCase(56, 60, CreatureConstants.Lemure, RollConstants.One)]
        [TestCase(61, 65, CreatureConstants.Goblin, RollConstants.OneD4Plus2)]
        [TestCase(66, 70, CreatureConstants.Hobgoblin, RollConstants.One,
            CreatureConstants.Goblin, RollConstants.OneD3)]
        [TestCase(71, 80, CreatureConstants.Kobold, RollConstants.OneD6Plus3)]
        [TestCase(81, 90, CreatureConstants.Skeleton_Human, RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Zombie_Human, RollConstants.OneD3)]
        public override void Percentile(Int32 lower, Int32 upper, params String[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
