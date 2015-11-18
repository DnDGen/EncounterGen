using EncounterGen.Tables;
using NUnit.Framework;
using System;

namespace EncounterGen.Tests.Unit.Tables
{
    [TestFixture]
    public class TableNameConstantsTests
    {
        [TestCase(TableNameConstants.CharacterLevel, "CharacterLevel")]
        [TestCase(TableNameConstants.LevelXENVIRONMENTEncounter, "Level{0}{1}Encounter")]
        [TestCase(TableNameConstants.TreasureAdjustment, "TreasureAdjustment")]
        public void Constant(String constant, String value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
