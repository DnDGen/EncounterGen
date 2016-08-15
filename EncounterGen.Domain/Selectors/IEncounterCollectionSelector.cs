using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors
{
    internal interface IEncounterCollectionSelector
    {
        Dictionary<string, string> SelectFrom(int level, string environment, string temperature, string timeOfDay);
        IEnumerable<Dictionary<string, string>> SelectAllFrom(int level, string environment, string temperature, string timeOfDay);
        IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(int level, string environment, string temperature, string timeOfDay);
    }
}
