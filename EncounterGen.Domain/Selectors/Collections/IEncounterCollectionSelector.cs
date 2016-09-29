using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal interface IEncounterCollectionSelector
    {
        Dictionary<string, string> SelectRandomFrom(int level, string environment, string temperature, string timeOfDay, params string[] creatureTypeFilters);
        IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(int level, string environment, string temperature, string timeOfDay, params string[] creatureTypeFilters);
    }
}
