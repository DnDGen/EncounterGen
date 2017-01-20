using EncounterGen.Common;
using EncounterGen.Domain.Selectors.Collections;
using EncounterGen.Domain.Tables;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;

namespace EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public abstract class EncounterGroupsTests : CollectionTests
    {
        [Inject]
        internal IEncounterCollectionSelector EncounterCollectionSelector { get; set; }

        protected override string tableName
        {
            get
            {
                return TableNameConstants.EncounterGroups;
            }
        }

        protected void AssertEncounterGroupEntriesAreComplete()
        {
            //HACK: Night contains everyone, so is effectively an "All" group
            var allCreatures = CollectionSelector.Explode(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night);
            AssertEntriesAreComplete(allCreatures);
        }

        protected IEnumerable<string> GetEncountersFromCreatureGroup(string creatureGroup)
        {
            return CollectionSelector.ExplodeInto(TableNameConstants.CreatureGroups, creatureGroup, TableNameConstants.EncounterGroups);
        }
    }
}
