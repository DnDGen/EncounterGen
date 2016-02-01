using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Hills.Warm.Day
{
    [TestFixture]
    public class Level7WarmHillsDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 7, EnvironmentConstants.WarmHillsDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 1, CreatureConstants.AnimatedObject_Gargantuan, RollConstants.One)]
        [TestCase(2, 2, CreatureConstants.Barbazu, RollConstants.OneD3Plus1)]
        [TestCase(3, 5, CreatureConstants.Beholder, RollConstants.OneD2)]
        [TestCase(6, 6, CreatureConstants.Belker, RollConstants.OneD2)]
        [TestCase(7, 7, CreatureConstants.ChaosBeast, RollConstants.One)]
        [TestCase(8, 10, CreatureConstants.Chimera, RollConstants.One)]
        [TestCase(11, 15, CreatureConstants.Deinonychus, RollConstants.OneD4Plus2)]
        [TestCase(16, 18, CreatureConstants.Bear_Dire, RollConstants.One)]
        [TestCase(19, 21, CreatureConstants.Doppelganger, RollConstants.OneD4Plus2)]
        [TestCase(22, 26, CreatureConstants.Dragonne, RollConstants.One)]
        [TestCase(27, 27, CreatureConstants.Elemental_Air_Huge, RollConstants.One)]
        [TestCase(28, 28, CreatureConstants.Elemental_Earth_Huge, RollConstants.One)]
        [TestCase(29, 29, CreatureConstants.Elemental_Fire_Huge, RollConstants.One)]
        [TestCase(30, 30, CreatureConstants.Elemental_Water_Huge, RollConstants.One)]
        [TestCase(31, 31, CreatureConstants.FormianTaskmaster, RollConstants.One)]
        [TestCase(32, 34, CreatureConstants.Bee_Giant, RollConstants.OneD4Plus10)]
        [TestCase(35, 37, CreatureConstants.Owl_Giant, RollConstants.OneD4Plus2)]
        [TestCase(38, 42, CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
            CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5)]
        [TestCase(43, 43, CreatureConstants.Golem_Flesh, RollConstants.One)]
        [TestCase(44, 44, CreatureConstants.Hellcat, RollConstants.One)]
        [TestCase(45, 47, CreatureConstants.Giant_Hill, RollConstants.One)]
        [TestCase(48, 48, CreatureConstants.HoundArchon, RollConstants.OneD3Plus1)]
        [TestCase(49, 51, CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.One)]
        [TestCase(52, 52, CreatureConstants.Janni, RollConstants.OneD3Plus1)]
        [TestCase(53, 55, CreatureConstants.Lamia, RollConstants.OneD2)]
        [TestCase(56, 56, CreatureConstants.Lillend, RollConstants.One)]
        [TestCase(57, 59, CreatureConstants.Medusa, RollConstants.One)]
        [TestCase(60, 64, CreatureConstants.Megaraptor, RollConstants.OneD2)]
        [TestCase(65, 67, CreatureConstants.Nymph, RollConstants.One)]
        [TestCase(68, 70, CreatureConstants.Phasm, RollConstants.One)]
        [TestCase(71, 71, CreatureConstants.Salamander_Average, RollConstants.OneD2)]
        [TestCase(72, 72, CreatureConstants.Slaad_Red, RollConstants.One)]
        [TestCase(73, 73, CreatureConstants.Succubus, RollConstants.One)]
        [TestCase(74, 76, CreatureConstants.Werewolf, RollConstants.OneD3Plus1,
            CreatureConstants.Wolf, RollConstants.OneD4Plus2)]
        [TestCase(77, 79, CreatureConstants.Wolf, RollConstants.OneD4Plus10)]
        [TestCase(80, 84, CreatureConstants.Wyvern, RollConstants.OneD2)]
        [TestCase(85, 85, CreatureConstants.Xorn_Average, RollConstants.OneD2)]
        [TestCase(86, 88, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(89, 89, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(90, 90, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(91, 91, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(92, 92, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(93, 93, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Huge, RollConstants.One)]
        [TestCase(94, 100, CreatureConstants.Character + "[4]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
