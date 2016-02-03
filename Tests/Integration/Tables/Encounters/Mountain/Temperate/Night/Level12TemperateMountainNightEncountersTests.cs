using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Mountain.Temperate.Night
{
    [TestFixture]
    public class Level12TemperateMountainNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 12, EnvironmentConstants.TemperateMountainNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 8, CreatureConstants.Naga_Spirit, RollConstants.OneD3Plus1)]
        [TestCase(9, 16, CreatureConstants.Scorpion_Monstrous_Colossal, RollConstants.One)]
        [TestCase(17, 24, CreatureConstants.Giant_Hill, RollConstants.OneD6Plus3)]
        [TestCase(25, 32, CreatureConstants.Yrthak, RollConstants.OneD3Plus1)]
        [TestCase(33, 36, CreatureConstants.FormianMyrmarch, RollConstants.One,
            CreatureConstants.FormianWarrior, RollConstants.OneD6Plus5,
            CreatureConstants.FormianWorker, RollConstants.OneD4Plus10)]
        [TestCase(37, 40, CreatureConstants.Avoral, RollConstants.OneD3Plus1)]
        [TestCase(41, 44, CreatureConstants.NightHag, RollConstants.OneD3,
            CreatureConstants.Nightmare, RollConstants.OneD3)]
        [TestCase(45, 48, CreatureConstants.Hamatula, RollConstants.OneD2)]
        [TestCase(49, 52, CreatureConstants.NessianWarhound, RollConstants.OneD2,
            CreatureConstants.HellHound, RollConstants.OneD6Plus5)]
        [TestCase(53, 56, CreatureConstants.Kyton, RollConstants.OneD6Plus5)]
        [TestCase(57, 60, CreatureConstants.Osyluth, RollConstants.OneD3Plus1)]
        [TestCase(61, 64, CreatureConstants.Slaad_Green, RollConstants.OneD3Plus1)]
        [TestCase(65, 68, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(69, 72, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(73, 80, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(81, 84, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(85, 88, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(89, 100, CreatureConstants.Character + "[9]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
