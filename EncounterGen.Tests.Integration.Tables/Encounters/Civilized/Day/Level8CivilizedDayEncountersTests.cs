﻿using CharacterGen.CharacterClasses;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using NUnit.Framework;

namespace EncounterGen.Tests.Integration.Tables.Encounters.Civilized.Day
{
    [TestFixture]
    public class Level8CivilizedDayEncountersTests : TypeAndAmountPercentileTests
    {
        protected override string tableName
        {
            get
            {
                return string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, 8, EnvironmentConstants.CivilizedDay);
            }
        }

        [Test]
        public override void TableIsComplete()
        {
            AssertTableIsComplete();
        }

        [TestCase(1, 4, CreatureConstants.Commoner_Farmer + "[1d2+11]", RollConstants.OneD3)]
        [TestCase(5, 8, CreatureConstants.Commoner_Herder + "[1d2+11]", RollConstants.OneD3,
            CreatureConstants.Livestock, RollConstants.OneD4Plus10)]
        [TestCase(9, 12, CreatureConstants.Commoner_Hunter + "[1d2+9]", RollConstants.OneD3,
            CreatureConstants.Warrior_Hunter + "[1d2+9]", RollConstants.One)]
        [TestCase(13, 16, CreatureConstants.Commoner_Merchant + "[1d2+5]", RollConstants.OneD3,
            CreatureConstants.Warrior_Guard + "[1d2+5]", RollConstants.OneD3,
            CreatureConstants.Expert_Merchant + "[1d2+5]", RollConstants.One)]
        [TestCase(17, 20, CreatureConstants.Commoner_Minstrel + "[1d2+3]", RollConstants.OneD6Plus3,
            CreatureConstants.Expert_Minstrel + "[1d2+3]", RollConstants.One)]
        [TestCase(21, 24, CreatureConstants.Commoner_Minstrel + "[1d2+3]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Bard + "[4]", RollConstants.One)]
        [TestCase(25, 28, CreatureConstants.Warrior_Patrol + "[1d2+5]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_Captain + "[1d2+7]", RollConstants.One)]
        [TestCase(29, 32, CreatureConstants.Warrior_Patrol + "[1d2+3]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Fighter + "[4]", RollConstants.One)]
        [TestCase(33, 36, CreatureConstants.Commoner_Pilgrim + "[1d2+1]", RollConstants.OneD6Plus5,
            CreatureConstants.Warrior_Guard + "[1d2+1]", RollConstants.OneD3,
            CharacterClassConstants.Cleric + "[3]", RollConstants.One)]
        [TestCase(37, 40, CreatureConstants.Commoner_Pilgrim + "[1d2+3]", RollConstants.OneD6Plus3,
            CharacterClassConstants.Cleric + "[4]", RollConstants.One)]
        [TestCase(41, 44, CreatureConstants.Warrior_Bandit + "[1d2+9]", RollConstants.OneD3Plus1)]
        [TestCase(45, 48, CreatureConstants.Warrior_Bandit + "[1d2+5]", RollConstants.OneD4Plus2,
            CreatureConstants.Warrior_BanditLeader + "[1d2+7]", RollConstants.One)]
        [TestCase(49, 52, CreatureConstants.Warrior_Bandit + "[1d2+3]", RollConstants.OneD6Plus3,
            CreatureConstants.Warrior_BanditLeader + "[1d2+5]", RollConstants.One)]
        [TestCase(53, 56, CreatureConstants.Warrior_Bandit + "[1d2+1]", RollConstants.OneD6Plus5,
            CharacterClassConstants.Fighter + "[3]", RollConstants.One)]
        [TestCase(57, 60, CreatureConstants.Warrior_Bandit + "[1]", RollConstants.OneD4Plus10,
            CharacterClassConstants.Fighter + "[3]", RollConstants.One)]
        [TestCase(61, 64, CreatureConstants.NPC_Traveler + "[1d2+11]", RollConstants.OneD3)]
        [TestCase(65, 68, CreatureConstants.NPC_Traveler + "[1d2+9]", RollConstants.OneD3Plus1)]
        [TestCase(69, 74, CreatureConstants.Character + "[8]", RollConstants.One)]
        [TestCase(75, 80, CreatureConstants.Character + "[7]", RollConstants.OneD2)]
        [TestCase(81, 86, CreatureConstants.Character + "[6]", RollConstants.OneD3)]
        [TestCase(87, 92, CreatureConstants.Character + "[5]", RollConstants.OneD3Plus1)]
        [TestCase(93, 100, CreatureConstants.Character + "[4]", RollConstants.OneD4Plus2)]
        public override void Percentile(int lower, int upper, params string[] typesAndAmounts)
        {
            base.Percentile(lower, upper, typesAndAmounts);
        }
    }
}