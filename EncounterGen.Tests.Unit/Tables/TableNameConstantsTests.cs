﻿using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Unit.Tables
{
    [TestFixture]
    public class TableNameConstantsTests
    {
        [TestCase(TableNameConstants.AverageChallengeRatings, "AverageChallengeRatings")]
        [TestCase(TableNameConstants.AverageEncounterLevels, "AverageEncounterLevels")]
        [TestCase(TableNameConstants.CreatureGroups, "CreatureGroups")]
        [TestCase(TableNameConstants.EncounterGroups, "EncounterGroups")]
        [TestCase(TableNameConstants.EncounterLevelModifiers, "EncounterLevelModifiers")]
        [TestCase(TableNameConstants.TreasureGroups, "TreasureGroups")]
        [TestCase(TableNameConstants.TreasureRates, "TreasureRates")]
        public void Constant(string constant, string value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }
    }
}
