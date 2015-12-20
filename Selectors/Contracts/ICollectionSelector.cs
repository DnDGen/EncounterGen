using System.Collections.Generic;

namespace EncounterGen.Selectors
{
    public interface ICollectionSelector
    {
        IEnumerable<string> SelectFrom(string tableName, string name);
        string SelectRandomFrom(IEnumerable<string> collection);
    }
}
