using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Dungeon
{
    [TestFixture]
    public class Level2DungeonEncountersTests : TypeAndAmountPercentileTests
    {
        protected override String tableName
        {
            get
            {
                return String.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 2, EnvironmentConstants.Dungeon);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 5, CreatureConstants.Centipede_Monstrous_Large, RollConstants.OneD3)]
        [TestCase(6, 10, CreatureConstants.Ant_Giant, RollConstants.OneD3)]
        [TestCase(11, 15, CreatureConstants.Scorpion_Monstrous_Medium, RollConstants.OneD3)]
        [TestCase(16, 20, CreatureConstants.Spider_Monstrous_Medium, RollConstants.OneD3)]
        [TestCase(21, 25, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(26, 30, CreatureConstants.ElfWarrior, RollConstants.OneD4Plus2)]
        [TestCase(31, 35, CreatureConstants.Character + "1", RollConstants.OneD3)]
        [TestCase(36, 37, CreatureConstants.Choker, RollConstants.One)]
        [TestCase(38, 42, CreatureConstants.EtherealMarauder, RollConstants.One)]
        [TestCase(43, 45, CreatureConstants.Shrieker, RollConstants.OneD3)]
        [TestCase(46, 50, CreatureConstants.FormianWorker, RollConstants.OneD4Plus2)]
        [TestCase(51, 55, CreatureConstants.Hobgoblin, RollConstants.OneD4Plus2)]
        [TestCase(56, 60, CreatureConstants.Hobgoblin, RollConstants.OneD3,
            CreatureConstants.Goblin, RollConstants.OneD4Plus2)]
        [TestCase(61, 70, CreatureConstants.Lizardfolk, RollConstants.OneD3)]
        [TestCase(71, 80, CreatureConstants.Orc, RollConstants.OneD4Plus2)]
        [TestCase(81, 90, CreatureConstants.Zombie_HumanCommoner, RollConstants.OneD4Plus2)]
        [TestCase(91, 100, CreatureConstants.Ghoul, RollConstants.OneD3)]
        public override void Percentile(Int32 lower, Int32 upper, params String[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
