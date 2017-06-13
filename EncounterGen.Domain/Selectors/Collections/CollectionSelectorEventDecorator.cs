using EventGen;
using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal class CollectionSelectorEventDecorator : ICollectionSelector
    {
        private readonly ICollectionSelector innerSelector;
        private readonly GenEventQueue eventQueue;

        public CollectionSelectorEventDecorator(ICollectionSelector innerSelector, GenEventQueue eventQueue)
        {
            this.innerSelector = innerSelector;
            this.eventQueue = eventQueue;
        }

        public IEnumerable<string> Explode(string tableName, string name)
        {
            eventQueue.Enqueue("EncounterGen", $"Exploding {name} from {tableName}");
            var collection = innerSelector.Explode(tableName, name);
            eventQueue.Enqueue("EncounterGen", $"Finished exploding {name} from {tableName}");

            return collection;
        }

        public IEnumerable<string> ExplodeInto(string tableName, string name, string intoTableName)
        {
            eventQueue.Enqueue("EncounterGen", $"Exploding {name} into {intoTableName} from {tableName}");
            var collection = innerSelector.ExplodeInto(tableName, name, intoTableName);
            eventQueue.Enqueue("EncounterGen", $"Finished exploding {name} into {intoTableName} from {tableName}");

            return collection;
        }

        public bool IsGroup(string tableName, string name)
        {
            return innerSelector.IsGroup(tableName, name);
        }

        public IEnumerable<string> SelectFrom(string tableName, string name)
        {
            eventQueue.Enqueue("EncounterGen", $"Selecting {name} from {tableName}");
            var collection = innerSelector.SelectFrom(tableName, name);
            eventQueue.Enqueue("EncounterGen", $"Finished selecting {name} from {tableName}");

            return collection;
        }

        public T SelectRandomFrom<T>(IEnumerable<T> collection)
        {
            return innerSelector.SelectRandomFrom(collection);
        }
    }
}
