using System;
using System.Collections.Generic;

namespace EncounterGen.Selectors
{
    public interface ICollectionSelector
    {
        IEnumerable<String> SelectFrom(String tableName, String name);
    }
}
