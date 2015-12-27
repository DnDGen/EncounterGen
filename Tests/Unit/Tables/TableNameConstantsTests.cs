using EncounterGen.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Tables
{
    [TestFixture]
    public class TableNameConstantsTests
    {
        [TestCase(TableNameConstants.CreatureGroups, "CreatureGroups")]
        [TestCase(TableNameConstants.CREATURESubtypeChallengeRatings, "{0}SubtypeChallengeRatings")]
        [TestCase(TableNameConstants.LevelXDragons, "Level{0}Dragons")]
        [TestCase(TableNameConstants.LevelXEncounterLevel, "Level{0}EncounterLevel")]
        [TestCase(TableNameConstants.LevelXENVIRONMENTEncounters, "Level{0}{1}Encounters")]
        [TestCase(TableNameConstants.LevelXRolls, "Level{0}Rolls")]
        [TestCase(TableNameConstants.LevelXUndeadNPC, "Level{0}UndeadNPC")]
        [TestCase(TableNameConstants.RollOrder, "RollOrder")]
        [TestCase(TableNameConstants.TreasureAdjustments, "TreasureAdjustments")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
