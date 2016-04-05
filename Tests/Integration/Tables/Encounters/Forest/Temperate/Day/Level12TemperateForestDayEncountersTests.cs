using EncounterGen.Common;
using EncounterGen.Selectors;
using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Forest.Temperate.Day
{
    [TestFixture]
    public class Level12TemperateForestDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 12, EnvironmentConstants.TemperateForestDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.Avoral, RollConstants.OneD3Plus1)]
        [TestCase(5, 16, CreatureConstants.Scorpion_Monstrous_Colossal, RollConstants.One)]
        [TestCase(17, 20, CreatureConstants.FormianMyrmarch, RollConstants.One,
            CreatureConstants.FormianWarrior, RollConstants.OneD6Plus5,
            CreatureConstants.FormianWorker, RollConstants.OneD4Plus10)]
        [TestCase(21, 24, CreatureConstants.Hamatula, RollConstants.OneD2)]
        [TestCase(25, 28, CreatureConstants.Kyton, RollConstants.OneD6Plus5)]
        [TestCase(29, 32, CreatureConstants.NessianWarhound, RollConstants.OneD2,
            CreatureConstants.HellHound, RollConstants.OneD6Plus5)]
        [TestCase(33, 36, CreatureConstants.Osyluth, RollConstants.OneD3Plus1)]
        [TestCase(37, 40, CreatureConstants.Slaad_Green, RollConstants.OneD3Plus1)]
        [TestCase(41, 52, CreatureConstants.Naga_Spirit, RollConstants.OneD3Plus1)]
        [TestCase(53, 64, CreatureConstants.Treant, RollConstants.OneD4Plus2)]
        [TestCase(65, 72, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(73, 76, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(77, 80, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(81, 84, CreatureConstants.Zombie, RollConstants.One)]
        [TestCase(85, 88, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(89, 100, CreatureConstants.Character + "[9]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
