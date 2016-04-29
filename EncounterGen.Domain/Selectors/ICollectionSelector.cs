using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors
{
    internal interface ICollectionSelector
    {
        IEnumerable<string> SelectFrom(string tableName, string name);
        string SelectRandomFrom(IEnumerable<string> collection);
    }
}
