using EncounterGen.Mappers;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Selectors.Domain
{
    public class CollectionSelector : ICollectionSelector
    {
        private CollectionMapper mapper;
        private Dice dice;

        public CollectionSelector(CollectionMapper mapper, Dice dice)
        {
            this.mapper = mapper;
            this.dice = dice;
        }

        public IEnumerable<string> SelectFrom(string tableName, string tableEntry)
        {
            var table = mapper.Map(tableName);

            if (table.ContainsKey(tableEntry) == false)
            {
                var message = string.Format("{0} is not a valid entry in the table {1}", tableEntry, tableName);
                throw new ArgumentException(message);
            }

            return table[tableEntry];
        }

        public string SelectRandomFrom(IEnumerable<string> collection)
        {
            if (collection.Any() == false)
                throw new ArgumentException();

            var index = dice.Roll().d(collection.Count()) - 1;
            return collection.ElementAt(index);
        }
    }
}
