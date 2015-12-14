using System;
using System.Collections.Generic;

namespace EncounterGen.Mappers
{
    public interface CollectionMapper
    {
        Dictionary<String, IEnumerable<String>> Map(String tableName);
    }
}
