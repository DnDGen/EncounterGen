using EncounterGen.Mappers;
using System;
using System.Collections.Generic;

namespace EncounterGen.Selectors.Domain
{
    public class CollectionSelector : ICollectionSelector
    {
        private CollectionMapper mapper;

        public CollectionSelector(CollectionMapper mapper)
        {
            this.mapper = mapper;
        }

        public IEnumerable<String> SelectFrom(String tableName, String tableEntry)
        {
            var table = mapper.Map(tableName);

            if (table.ContainsKey(tableEntry) == false)
            {
                var message = String.Format("{0} is not a valid entry in the table {1}", tableEntry, tableName);
                throw new ArgumentException(message);
            }

            return table[tableEntry];
        }
    }
}
