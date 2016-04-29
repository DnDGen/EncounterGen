using System.Collections.Generic;

namespace EncounterGen.Domain.Mappers.Collections
{
    internal class CollectionMapperCachingProxy : CollectionMapper
    {
        private CollectionMapper innerMapper;
        private Dictionary<string, Dictionary<string, IEnumerable<string>>> cachedTables;

        public CollectionMapperCachingProxy(CollectionMapper innerMapper)
        {
            this.innerMapper = innerMapper;
            cachedTables = new Dictionary<string, Dictionary<string, IEnumerable<string>>>();
        }

        public Dictionary<string, IEnumerable<string>> Map(string tableName)
        {
            if (cachedTables.ContainsKey(tableName) == false)
                cachedTables[tableName] = innerMapper.Map(tableName);

            return cachedTables[tableName];
        }
    }
}
