using EncounterGen.Common;
using System.Collections.Generic;

namespace EncounterGen.Generators
{
    public interface IEncounterVerifier
    {
        bool ValidEncounterExistsAtLevel(EncounterSpecifications encounterSpecifications);
        bool EncounterIsValid(IEnumerable<string> creatures, IEnumerable<string> creatureTypeFilters);
        bool EncounterIsValid(Encounter encounter, IEnumerable<string> creatureTypeFilters);
        bool CreatureIsValid(string creatureName, IEnumerable<string> creatureTypeFilters);
    }
}
