using EncounterGen.Domain.Tables;
using NUnit.Framework;
using System.Collections.Generic;

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

            for (var i = 24; i > 0; i--)
            {
                var levelEncounters = GetCollection(i.ToString());
                allLevelEncounters.AddRange(levelEncounters);
            }

            return allLevelEncounters;
        }
    }
}
