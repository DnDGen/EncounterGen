using System;
using System.Collections.Generic;

namespace EncounterGen.Mappers.Domain.Collections
{
    public class CollectionMapperCachingProxy : CollectionMapper
    {
        private CollectionMapper innerMapper;
        private Dictionary<String, Dictionary<String, IEnumerable<String>>> cachedTables;

        public CollectionMapperCachingProxy(CollectionMapper innerMapper)
        {
            this.innerMapper = innerMapper;
            cachedTables = new Dictionary<String, Dictionary<String, IEnumerable<String>>>();
        }

        public Dictionary<String, IEnumerable<String>> Map(String tableName)
        {
            if (cachedTables.ContainsKey(tableName) == false)
                cachedTables[tableName] = innerMapper.Map(tableName);

            return cachedTables[tableName];
        }
    }
}
