using EncounterGen.Generators;
using EventGen;
using System.Collections.Generic;

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
            eventQueue.Enqueue("EncounterGen", $"Finished selecting encounter table for {encounterSpecifications.Description}");

            return encounterCollection;
        }

        public Dictionary<string, string> SelectRandomFrom(EncounterSpecifications encounterSpecifications)
        {
            eventQueue.Enqueue("EncounterGen", $"Selecting a random encounter from the encounter table for {encounterSpecifications.Description}");
            var encounter = innerSelector.SelectRandomFrom(encounterSpecifications);
            eventQueue.Enqueue("EncounterGen", $"Finished selecting a random encounter from the encounter table for {encounterSpecifications.Description}");

            return encounter;
        }
    }
}
