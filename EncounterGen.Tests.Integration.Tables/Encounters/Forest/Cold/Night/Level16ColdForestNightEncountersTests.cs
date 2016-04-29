using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Forest.Cold.Night
{
    [TestFixture]
    public class Level16ColdForestNightEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 16, EnvironmentConstants.ColdForestNight);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 6, CreatureConstants.Cornugon, RollConstants.One)]
        [TestCase(7, 12, CreatureConstants.Ghaele, RollConstants.OneD3Plus1)]
        [TestCase(13, 18, CreatureConstants.Gelugon, RollConstants.OneD3Plus1)]
        [TestCase(19, 24, CreatureConstants.Gelugon, RollConstants.OneD2,
            CreatureConstants.Osyluth, RollConstants.OneD3Plus1,
            CreatureConstants.Barbazu, RollConstants.OneD6Plus5)]
        [TestCase(25, 30, CreatureConstants.Golem_Iron, RollConstants.OneD3Plus1)]
        [TestCase(31, 36, CreatureConstants.Golem_Stone_Greater, RollConstants.One)]
        [TestCase(37, 42, CreatureConstants.Nalfeshnee, RollConstants.One,
            CreatureConstants.Hezrou, RollConstants.One,
            CreatureConstants.Vrock, RollConstants.OneD3Plus1)]
        [TestCase(43, 48, CreatureConstants.Nightwalker, RollConstants.One)]
        [TestCase(49, 54, CreatureConstants.Planetar, RollConstants.One)]
        [TestCase(55, 66, CreatureConstants.Dragon, RollConstants.One)]
        [TestCase(67, 72, CreatureConstants.Skeleton, RollConstants.One)]
        [TestCase(73, 78, CreatureConstants.CelestialCreature, RollConstants.One)]
        [TestCase(79, 84, CreatureConstants.FiendishCreature, RollConstants.One)]
        [TestCase(85, 100, CreatureConstants.Character + "[13]", RollConstants.OneD3Plus1)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}
