using System;

namespace EncounterGen.Selectors.Percentiles
{
    public interface IPercentileSelector
    {
        String SelectFrom(String tableName);
    }
}
