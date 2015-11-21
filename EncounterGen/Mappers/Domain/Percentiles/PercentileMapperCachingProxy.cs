using System;
using System.Collections.Generic;

namespace EncounterGen.Mappers.Domain.Percentiles
{
    public class PercentileMapperCachingProxy : PercentileMapper
    {
        private PercentileMapper innerMapper;
        private Dictionary<String, Dictionary<Int32, String>> cachedTables;

        public PercentileMapperCachingProxy(PercentileMapper innerMapper)
        {
            this.innerMapper = innerMapper;
            cachedTables = new Dictionary<String, Dictionary<Int32, String>>();
        }

        public Dictionary<Int32, String> Map(String tableName)
        {
            if (cachedTables.ContainsKey(tableName) == false)
                cachedTables[tableName] = innerMapper.Map(tableName);

            return cachedTables[tableName];
        }
    }
}
