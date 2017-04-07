using EncounterGen.Generators;
using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal interface IEncounterCollectionSelector
    {
        Dictionary<string, string> SelectRandomFrom(EncounterSpecifications encounterSpecifications);
        IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(EncounterSpecifications encounterSpecifications);
    }
}
