using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors.Collections;
using DnDGen.EncounterGen.Tables;
using NUnit.Framework;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Tests.Integration.Tables.Creatures.EncounterGroups
{
    [TestFixture]
    public abstract class EncounterGroupsTests : CollectionTests
    {
        internal IEncounterCollectionSelector encounterCollectionSelector;

        protected override string tableName
        {
            get
            {
                return TableNameConstants.EncounterGroups;
            }
        }

        [SetUp]
        public void EncounterGroupsSetup()
        {
            encounterCollectionSelector = GetNewInstanceOf<IEncounterCollectionSelector>();
        }

        protected void AssertEncounterGroupEntriesAreComplete()
        {
            //HACK: Night contains everyone, so is effectively an "All" group
            var allCreatures = collectionSelector.Explode(TableNameConstants.CreatureGroups, EnvironmentConstants.TimesOfDay.Night);
            AssertEntriesAreComplete(allCreatures);
        }

        protected IEnumerable<string> GetEncountersFromCreatureGroup(string creatureGroup)
        {
            var creatures = collectionSelector.Explode(TableNameConstants.CreatureGroups, creatureGroup);
            var allEncounters = collectionSelector.SelectAllFrom(TableNameConstants.EncounterGroups);
            var encounters = collectionSelector.Flatten(allEncounters, creatures);

            return encounters;
        }
    }
}
