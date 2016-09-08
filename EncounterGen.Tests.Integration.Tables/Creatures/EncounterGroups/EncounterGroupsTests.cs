using EncounterGen.Common;
using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public abstract class EncounterGroupsTests : CollectionTests
    {
        protected override string tableName
        {
            get
            {
                return TableNameConstants.EncounterGroups;
            }
        }

        protected void AssertEncounterGroupEntriesAreComplete()
        {
            var entries = new[]
               {
                string.Empty,
                EnvironmentConstants.Civilized,
                EnvironmentConstants.Desert,
                EnvironmentConstants.Dungeon,
                EnvironmentConstants.Forest,
                EnvironmentConstants.Hills,
                EnvironmentConstants.Marsh,
                EnvironmentConstants.Mountain,
                EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Cold,
                EnvironmentConstants.Temperatures.Temperate,
                EnvironmentConstants.Temperatures.Warm,
                EnvironmentConstants.TimesOfDay.Day,
                EnvironmentConstants.TimesOfDay.Night,
                GroupConstants.Magic,
                GroupConstants.Land,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Dungeon,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Cold + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Dungeon,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Temperate + EnvironmentConstants.Plains,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Desert,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Dungeon,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Forest,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Hills,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Marsh,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Mountain,
                EnvironmentConstants.Temperatures.Warm + EnvironmentConstants.Plains,
                GroupConstants.Dragon,
            };

            var levels = Enumerable.Range(1, 29).Select(lvl => lvl.ToString());
            var allEntries = entries.Union(levels);

            AssertEntriesAreComplete(allEntries);
        }

        protected string FormatEncounter(params string[] typesAndAmounts)
        {
            var formattedTypesAndAmounts = new List<string>();

            if (typesAndAmounts.Length % 2 > 0)
            {
                Assert.Fail($"Collection has an odd number of arguments: {string.Join(";", typesAndAmounts)}");
            }

            for (var i = 0; i < typesAndAmounts.Length; i += 2)
                formattedTypesAndAmounts.Add($"{typesAndAmounts[i]}/{typesAndAmounts[i + 1]}");

            return string.Join(",", formattedTypesAndAmounts);
        }

        protected IEnumerable<string> GetCreaturesWithDescription(string encounter)
        {
            var typesAndAmounts = encounter.Split(',');
            var creatures = new List<string>();

            foreach (var typeAndAmount in typesAndAmounts)
            {
                var creature = typeAndAmount.Split('/', '[')[0];
                creatures.Add(creature);
            }

            return creatures;
        }

        protected string GetCreature(string creature)
        {
            var levelStart = creature.IndexOf('[');
            var descriptionStart = creature.IndexOf('(');

            if (levelStart == -1 && descriptionStart == -1)
                return creature;

            var creatureLength = creature.Length;

            if (levelStart > -1)
            {
                creatureLength = levelStart;
            }
            else if (levelStart == -1)
            {
                creatureLength = descriptionStart - 1;
            }

            return creature.Substring(0, creatureLength);
        }

        protected IEnumerable<string> GetAllLevelEncounters()
        {
            var allLevelEncounters = new List<string>();

            for (var i = 29; i > 0; i--)
            {
                var levelEncounters = GetCollection(i.ToString());
                allLevelEncounters.AddRange(levelEncounters);
            }

            return allLevelEncounters;
        }
    }
}
