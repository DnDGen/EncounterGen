using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors.Percentiles
{
    internal interface IPercentileSelector
    {
        int SelectFrom(string tableName);
        IEnumerable<int> SelectAllFrom(string tableName);
    }
}
