﻿using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Day
{
    [TestFixture]
    public class Level7CivilizedDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 7, EnvironmentConstants.CivilizedDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.Commoner_Farmer + "[1d2+9]", RollConstants.OneD3)]
        [TestCase(5, 9, CreatureConstants.Commoner_Herder + "[1d2+9]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(10, 13, CreatureConstants.Commoner_Hunter + "[1d2+7]", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "[1d2+7]", RollConstants.One)]
        [TestCase(14, 18, CreatureConstants.Commoner_Merchant + "[1d2+3]", RollConstants.OneD3,
            CreatureConstants.Warrior_Guard + "[1d2+3]", RollConstants.OneD3,
            CreatureConstants.Expert_Merchant + "[1d2+3]", RollConstants.One)]
        [TestCase(19, 22, CreatureConstants.Commoner_Minstrel + "[1d2+1]", RollConstants.OneD6Plus3,
            CreatureConstants.Expert_Minstrel + "[1d2+1]", RollConstants.One)]
        [TestCase(23, 27, CreatureConstants.Commoner_Minstrel + "[1d2+1]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Bard + "[3]", RollConstants.One)]
        [TestCase(28, 31, CreatureConstants.Warrior_Patrol + "[1d2+3]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_Captain + "[1d2+5]", RollConstants.One)]
        [TestCase(32, 36, CreatureConstants.Warrior_Patrol + "[1d2+1]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Fighter + "[3]", RollConstants.One)]
        [TestCase(37, 40, CreatureConstants.Commoner_Pilgrim + "[1]", RollConstants.OneD6Plus5,
            CreatureConstants.Warrior_Guard + "[1]", RollConstants.OneD3,
            CharacterClassConstants.Cleric + "[2]", RollConstants.One)]
        [TestCase(41, 45, CreatureConstants.Commoner_Pilgrim + "[1d2+1]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Cleric + "[3]", RollConstants.One)]
        [TestCase(46, 49, CreatureConstants.Warrior_Bandit + "[1d2+7]", RollConstants.OneD3Plus1)]
        [TestCase(50, 54, CreatureConstants.Warrior_Bandit + "[1d2+3]", RollConstants.OneD4Plus2,
            CreatureConstants.Warrior_BanditLeader + "[1d2+5]", RollConstants.One)]
        [TestCase(55, 58, CreatureConstants.Warrior_Bandit + "[1d2+1]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_BanditLeader + "[1d2+3]", RollConstants.One)]
        [TestCase(59, 63, CreatureConstants.Warrior_Bandit + "[1]", RollConstants.OneD6Plus5,
            CharacterClassConstants.Fighter + "[2]", RollConstants.One)]
        [TestCase(64, 67, CreatureConstants.NPC_Traveler + "[1d2+9]", RollConstants.OneD3)]
        [TestCase(68, 72, CreatureConstants.NPC_Traveler + "[1d2+7]", RollConstants.OneD3Plus1)]
        [TestCase(73, 76, CreatureConstants.Character + "[7]", RollConstants.One)]
        [TestCase(77, 81, CreatureConstants.Character + "[6]", RollConstants.OneD2)]
        [TestCase(82, 85, CreatureConstants.Character + "[5]", RollConstants.OneD3)]
        [TestCase(86, 90, CreatureConstants.Character + "[4]", RollConstants.OneD3Plus1)]
        [TestCase(91, 100, CreatureConstants.Character + "[3]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}