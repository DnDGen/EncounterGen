using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal interface ICollectionSelector
    {
        IEnumerable<string> SelectFrom(string tableName, string name);
        IEnumerable<string> ExplodeInto(string tableName, string name, string intoTableName);
        T SelectRandomFrom<T>(IEnumerable<T> collection);
        bool IsGroup(string tableName, string name);
    }
}
