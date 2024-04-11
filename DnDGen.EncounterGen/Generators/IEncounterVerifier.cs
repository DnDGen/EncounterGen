using DnDGen.EncounterGen.Models;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Generators
{
    public interface IEncounterVerifier
    {
        bool ValidEncounterExistsAtLevel(EncounterSpecifications encounterSpecifications);
        bool EncounterIsValid(IEnumerable<string> creatures, IEnumerable<string> creatureTypeFilters);
        bool EncounterIsValid(Encounter encounter, IEnumerable<string> creatureTypeFilters);
        bool CreatureIsValid(string creatureName, IEnumerable<string> creatureTypeFilters);
    }
}
