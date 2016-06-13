using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Desert.Temperate.Night
{
    [TestFixture]
    public class Level10TemperateDesertNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 10, EnvironmentConstants.TemperateDesertNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.Beholder, RollConstants.OneD4Plus2)]
        [TestCase(5, 8, CreatureConstants.Chimera, RollConstants.OneD3Plus1)]
        [TestCase(9, 12, CreatureConstants.Gargoyle, RollConstants.OneD6Plus5)]
        [TestCase(13, 16, CreatureConstants.Giant_Fire, RollConstants.One)]
        [TestCase(17, 20, CreatureConstants.Medusa, RollConstants.OneD3Plus1)]
        [TestCase(21, 24, CreatureConstants.OgreMage, RollConstants.OneD2,
            CreatureConstants.Ogre, RollConstants.OneD3Plus1)]
        [TestCase(25, 28, CreatureConstants.Digester, RollConstants.OneD4Plus2)]
        [TestCase(29, 32, CreatureConstants.Harpy, RollConstants.OneD6Plus5)]
        [TestCase(33, 36, CreatureConstants.Naga_Guardian, RollConstants.One)]
        [TestCase(37, 40, CreatureConstants.Scorpion_Monstrous_Huge, RollConstants.OneD3Plus1)]
        [TestCase(41, 44, CreatureConstants.Scorpion_Monstrous_Gargantuan, RollConstants.One)]
        [TestCase(45, 48, CreatureConstants.Wasp_Giant, RollConstants.OneD4Plus10)]
        [TestCase(49, 50, CreatureConstants.AnimatedObject_Colossal, RollConstants.One)]
        [TestCase(51, 52, CreatureConstants.Bebilith, RollConstants.OneD6Plus5)]
        [TestCase(53, 54, CreatureConstants.FormianMyrmarch, RollConstants.One)]
        [TestCase(55, 56, CreatureConstants.Golem_Clay, RollConstants.One)]
        [TestCase(57, 58, CreatureConstants.Golem_Flesh, RollConstants.One)]
        [TestCase(59, 60, CreatureConstants.Avoral, RollConstants.One)]
        [TestCase(61, 62, CreatureConstants.NightHag, RollConstants.One,
            CreatureConstants.Nightmare, RollConstants.One)]
        [TestCase(63, 64, CreatureConstants.NessianWarhound, RollConstants.One)]
        [TestCase(65, 66, CreatureConstants.Janni, RollConstants.One)]
        [TestCase(67, 68, CreatureConstants.Lillend, RollConstants.One)]
        [TestCase(69, 70, CreatureConstants.Salamander_Noble, RollConstants.OneD3Plus1)]
        [TestCase(71, 72, CreatureConstants.Slaad_Gray, RollConstants.OneD3Plus1)]
        [TestCase(73, 74, CreatureConstants.Slaad_Red, RollConstants.OneD2)]
        [TestCase(75, 76, CreatureConstants.Spectre, RollConstants.OneD6Plus5)]
        [TestCase(77, 78, CreatureConstants.Vrock, RollConstants.OneD3Plus1)]
        [TestCase(79, 80, CreatureConstants.Ravid, RollConstants.One,
            CreatureConstants.AnimatedObject_Colossal, RollConstants.One)]
        [TestCase(81, 82, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(83, 84, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(85, 88, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(89, 90, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(91, 92, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(93, 100, CreatureConstants.Character + "[7]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
