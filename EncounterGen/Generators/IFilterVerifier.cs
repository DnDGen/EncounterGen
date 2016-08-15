using System.Collections.Generic;

namespace EncounterGen.Generators
{
    public interface IFilterVerifier
    {
        bool FiltersAreValid(string environment, int level, string temperature, string timeOfDay, params string[] creatureTypeFilters);
        bool EncounterIsValid(Dictionary<string, string> creaturesAndAmounts, int modifier, params string[] creatureTypeFilters);
        bool CreatureIsValid(string creatureName, params string[] creatureTypeFilters);
    }
}
