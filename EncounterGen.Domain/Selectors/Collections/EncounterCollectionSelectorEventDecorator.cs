using EncounterGen.Generators;
using EventGen;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal class EncounterCollectionSelectorEventDecorator : IEncounterCollectionSelector
    {
        private readonly IEncounterCollectionSelector innerSelector;
        private readonly GenEventQueue eventQueue;

        public EncounterCollectionSelectorEventDecorator(IEncounterCollectionSelector innerSelector, GenEventQueue eventQueue)
        {
            this.innerSelector = innerSelector;
            this.eventQueue = eventQueue;
        }

        public IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(EncounterSpecifications encounterSpecifications)
        {
            eventQueue.Enqueue("EncounterGen", $"Selecting encounter table for {encounterSpecifications.Description}");
            var encounterCollection = innerSelector.SelectAllWeightedFrom(encounterSpecifications);
            eventQueue.Enqueue("EncounterGen", $"Selected {encounterCollection.Count()} weighted encounters");

            return encounterCollection;
        }

        public Dictionary<string, string> SelectRandomFrom(EncounterSpecifications encounterSpecifications)
        {
            eventQueue.Enqueue("EncounterGen", $"Selecting a random encounter from the encounter table for {encounterSpecifications.Description}");
            var encounter = innerSelector.SelectRandomFrom(encounterSpecifications);
            eventQueue.Enqueue("EncounterGen", $"Selected a random encounter with {encounter.Count} different creatures");

            return encounter;
        }
    }
}
