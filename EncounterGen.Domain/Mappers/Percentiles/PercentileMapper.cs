using System.Collections.Generic;

namespace EncounterGen.Domain.Mappers.Percentiles
{
    internal interface PercentileMapper
    {
        Dictionary<int, string> Map(string tableName);
    }
}
