using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors.Percentiles
{
    internal interface ITypeAndAmountPercentileSelector
    {
        Dictionary<string, string> SelectFrom(string tableName);
    }
}
