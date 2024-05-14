using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.RollGen;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures
{
    [TestFixture]
    public class AverageEncounterLevelsTests : CollectionTests
    {
        internal IEncounterLevelSelector encounterLevelSelector;
        internal IChallengeRatingSelector challengeRatingSelector;
        private Dice dice;
        private Dictionary<int, List<string>> encounterLevels;

        protected override string tableName => TableNameConstants.AverageEncounterLevels;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            encounterLevelSelector = GetNewInstanceOf<IEncounterLevelSelector>();
            challengeRatingSelector = GetNewInstanceOf<IChallengeRatingSelector>();
            collectionSelector = GetNewInstanceOf<ICollectionSelector>();
            encounterFormatter = GetNewInstanceOf<IEncounterFormatter>();
            dice = GetNewInstanceOf<Dice>();

            encounterLevels = new Dictionary<int, List<string>>();
            var levels = Enumerable.Range(EncounterSpecifications.MinimumLevel, EncounterSpecifications.MaximumLevel);

            foreach (var level in levels)
            {
                encounterLevels[level] = new List<string>();
            }

            var encounters = EncounterConstants.GetAll();

            foreach (var encounter in encounters)
            {
                var rawCreaturesAndAmounts = collectionSelector.SelectFrom(TableNameConstants.EncounterCreatures, encounter);
                var creaturesAndAmounts = encounterFormatter.SelectCreaturesAndAmountsFrom(rawCreaturesAndAmounts);
                var creatures = new List<EncounterCreature>();

                foreach (var kvp in creaturesAndAmounts)
                {
                    var creatureName = kvp.Key;
                    var amount = kvp.Value;
                    var creature = new EncounterCreature();
                    var averageQuantity = dice.Roll(amount).AsPotentialAverage();

                    //INFO: Using a GUID and not the actual creature name so that characters are computed like other creatures
                    creature.Creature.Name = Guid.NewGuid().ToString();
                    creature.ChallengeRating = challengeRatingSelector.SelectAverageForCreature(creatureName);
                    creature.Quantity = Convert.ToInt32(Math.Round(averageQuantity, MidpointRounding.AwayFromZero));

                    creatures.Add(creature);
                }

                var averageEncounterLevel = encounterLevelSelector.Select(new Encounter
                {
                    Creatures = creatures
                });

                encounterLevels[averageEncounterLevel].Add(encounter);
            }
        }

        [Test]
        public override void EntriesAreComplete()
        {
            var levels = Enumerable.Range(EncounterSpecifications.MinimumLevel, EncounterSpecifications.MaximumLevel).Select(l => l.ToString());
            AssertEntriesAreComplete(levels);
        }

        [TestCase(EncounterSpecifications.MinimumLevel)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        [TestCase(20)]
        [TestCase(21)]
        [TestCase(22)]
        [TestCase(23)]
        [TestCase(24)]
        [TestCase(25)]
        [TestCase(26)]
        [TestCase(27)]
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(EncounterSpecifications.MaximumLevel)]
        public void AverageEncounterLevelGroup(int level)
        {
            Assert.That(table, Contains.Key(level.ToString()));
            Assert.That(table[level.ToString()], Is.EquivalentTo(encounterLevels[level]));
        }
    }
}
