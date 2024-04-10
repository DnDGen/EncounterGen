using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors.Collections;
using DnDGen.EncounterGen.Tables;
using Ninject;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
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
            var creatures = CollectionSelector.Explode(TableNameConstants.CreatureGroups, creatureGroup);
            var allEncounters = CollectionSelector.SelectAllFrom(TableNameConstants.EncounterGroups);
            var encounters = CollectionSelector.Flatten(allEncounters, creatures);

            AssertEventSpacing();

            return encounters;
        }
    }
}
