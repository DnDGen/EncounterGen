using System;
using System.Collections.Generic;

namespace EncounterGen.Selectors
{
    public interface ITypeAndAmountPercentileSelector
    {
        Dictionary<String, Int32> SelectFrom(String tableName);
    }
}
