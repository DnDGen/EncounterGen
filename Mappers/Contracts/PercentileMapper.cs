using System;
using System.Collections.Generic;

namespace EncounterGen.Mappers
{
    public interface PercentileMapper
    {
        Dictionary<Int32, String> Map(String tableName);
    }
}
