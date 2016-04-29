using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Plains.Warm.Day
{
    [TestFixture]
    public class Level7WarmPlainsDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 7, EnvironmentConstants.WarmPlainsDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 3, CreatureConstants.Beholder, RollConstants.OneD2)]
        [TestCase(4, 6, CreatureConstants.Chimera, RollConstants.One)]
        [TestCase(7, 9, CreatureConstants.Doppelganger, RollConstants.OneD4Plus2)]
        [TestCase(10, 12, CreatureConstants.Medusa, RollConstants.One)]
        [TestCase(13, 15, CreatureConstants.Nymph, RollConstants.One)]
        [TestCase(16, 18, CreatureConstants.Phasm, RollConstants.One)]
        [TestCase(19, 21, CreatureConstants.Bee_Giant, RollConstants.OneD4Plus10)]
        [TestCase(22, 24, CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.One)]
        [TestCase(25, 27, CreatureConstants.Bear_Dire, RollConstants.One)]
        [TestCase(28, 30, CreatureConstants.Owl_Giant, RollConstants.OneD4Plus2)]
        [TestCase(31, 33, CreatureConstants.Werewolf, RollConstants.OneD3Plus1,
            CreatureConstants.Wolf, RollConstants.OneD4Plus2)]
        [TestCase(34, 36, CreatureConstants.Wolf, RollConstants.OneD4Plus10)]
        [TestCase(37, 43, CreatureConstants.Ant_Giant_Soldier, RollConstants.One,
            CreatureConstants.Ant_Giant_Worker, RollConstants.OneD6Plus5)]
        [TestCase(44, 50, CreatureConstants.Deinonychus, RollConstants.OneD4Plus2)]
        [TestCase(51, 57, CreatureConstants.Elephant, RollConstants.One)]
        [TestCase(58, 64, CreatureConstants.Krenshar, RollConstants.OneD6Plus5)]
        [TestCase(65, 71, CreatureConstants.Megaraptor, RollConstants.OneD2)]
        [TestCase(72, 72, CreatureConstants.AnimatedObject_Gargantuan, RollConstants.One)]
        [TestCase(73, 73, CreatureConstants.HoundArchon, RollConstants.OneD3Plus1)]
        [TestCase(74, 74, CreatureConstants.Barbazu, RollConstants.OneD3Plus1)]
        [TestCase(75, 75, CreatureConstants.Belker, RollConstants.OneD2)]
        [TestCase(76, 76, CreatureConstants.ChaosBeast, RollConstants.One)]
        [TestCase(77, 77, CreatureConstants.Elemental_Air_Huge, RollConstants.One)]
        [TestCase(78, 78, CreatureConstants.Elemental_Earth_Huge, RollConstants.One)]
        [TestCase(79, 79, CreatureConstants.Elemental_Fire_Huge, RollConstants.One)]
        [TestCase(80, 80, CreatureConstants.Elemental_Water_Huge, RollConstants.One)]
        [TestCase(81, 81, CreatureConstants.Golem_Flesh, RollConstants.One)]
        [TestCase(82, 82, CreatureConstants.Hellcat, RollConstants.One)]
        [TestCase(83, 83, CreatureConstants.Janni, RollConstants.OneD3Plus1)]
        [TestCase(84, 84, CreatureConstants.Lillend, RollConstants.One)]
        [TestCase(85, 85, CreatureConstants.Salamander_Average, RollConstants.OneD2)]
        [TestCase(86, 86, CreatureConstants.Slaad_Red, RollConstants.One)]
        [TestCase(87, 87, CreatureConstants.Succubus, RollConstants.One)]
        [TestCase(88, 88, CreatureConstants.Wight, RollConstants.OneD4Plus2)]
        [TestCase(89, 89, CreatureConstants.Xorn_Average, RollConstants.OneD2)]
        [TestCase(90, 90, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Huge, RollConstants.One)]
        [TestCase(91, 93, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(94, 94, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(95, 95, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(96, 96, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(97, 97, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(98, 100, CreatureConstants.Character + "[4]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
