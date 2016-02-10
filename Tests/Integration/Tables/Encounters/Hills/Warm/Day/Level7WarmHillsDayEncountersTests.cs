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
        [TestCase(11, 16, CreatureConstants.Deinonychus, RollConstants.OneD4Plus2)]
        [TestCase(17, 19, CreatureConstants.Bear_Dire, RollConstants.One)]
        [TestCase(20, 22, CreatureConstants.Doppelganger, RollConstants.OneD4Plus2)]
        [TestCase(23, 28, CreatureConstants.Dragonne, RollConstants.One)]
        [TestCase(29, 29, CreatureConstants.Elemental_Air_Huge, RollConstants.One)]
        [TestCase(30, 30, CreatureConstants.Elemental_Earth_Huge, RollConstants.One)]
        [TestCase(31, 31, CreatureConstants.Elemental_Fire_Huge, RollConstants.One)]
        [TestCase(32, 32, CreatureConstants.Elemental_Water_Huge, RollConstants.One)]
        [TestCase(33, 35, CreatureConstants.Bee_Giant, RollConstants.OneD4Plus10)]
        [TestCase(36, 38, CreatureConstants.Owl_Giant, RollConstants.OneD4Plus2)]
        [TestCase(39, 44, CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
            CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5)]
        [TestCase(45, 45, CreatureConstants.Golem_Flesh, RollConstants.One)]
        [TestCase(46, 46, CreatureConstants.Hellcat, RollConstants.One)]
        [TestCase(47, 49, CreatureConstants.Giant_Hill, RollConstants.One)]
        [TestCase(50, 50, CreatureConstants.HoundArchon, RollConstants.OneD3Plus1)]
        [TestCase(51, 53, CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.One)]
        [TestCase(54, 54, CreatureConstants.Janni, RollConstants.OneD3Plus1)]
        [TestCase(55, 57, CreatureConstants.Lamia, RollConstants.OneD2)]
        [TestCase(58, 58, CreatureConstants.Lillend, RollConstants.One)]
        [TestCase(59, 61, CreatureConstants.Medusa, RollConstants.One)]
        [TestCase(62, 67, CreatureConstants.Megaraptor, RollConstants.OneD2)]
        [TestCase(68, 70, CreatureConstants.Nymph, RollConstants.One)]
        [TestCase(71, 73, CreatureConstants.Phasm, RollConstants.One)]
        [TestCase(74, 74, CreatureConstants.Salamander_Average, RollConstants.OneD2)]
        [TestCase(75, 75, CreatureConstants.Slaad_Red, RollConstants.One)]
        [TestCase(76, 76, CreatureConstants.Succubus, RollConstants.One)]
        [TestCase(77, 79, CreatureConstants.Werewolf, RollConstants.OneD3Plus1,
            CreatureConstants.Wolf, RollConstants.OneD4Plus2)]
        [TestCase(80, 82, CreatureConstants.Wolf, RollConstants.OneD4Plus10)]
        [TestCase(83, 88, CreatureConstants.Wyvern, RollConstants.OneD2)]
        [TestCase(89, 89, CreatureConstants.Xorn_Average, RollConstants.OneD2)]
        [TestCase(90, 90, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Huge, RollConstants.One)]
        [TestCase(91, 93, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(94, 94, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(95, 95, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(96, 96, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(97, 97, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(98, 100, CreatureConstants.Character + "[4]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
