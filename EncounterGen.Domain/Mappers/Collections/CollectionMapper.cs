using System.Collections.Generic;

namespace EncounterGen.Domain.Mappers.Collections
{
    internal interface CollectionMapper
    {
        Dictionary<string, IEnumerable<string>> Map(string tableName);
    }
}
