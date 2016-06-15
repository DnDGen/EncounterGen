using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors.Percentiles
{
    internal interface IPercentileSelector
    {
        string SelectFrom(string tableName);
        IEnumerable<string> SelectAllFrom(string tableName);
    }
}
