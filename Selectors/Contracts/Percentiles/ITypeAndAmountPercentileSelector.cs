using System;
using System.Collections.Generic;

namespace EncounterGen.Selectors.Percentiles
{
    public interface ITypeAndAmountPercentileSelector
    {
        Dictionary<String, String> SelectFrom(String tableName);
    }
}
