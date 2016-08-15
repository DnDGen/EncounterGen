using EncounterGen.Common;

namespace EncounterGen.Generators
{
    public interface IEncounterGenerator
    {
        Encounter Generate(string environment, int level, string temperature, string timeOfDay, params string[] creatureTypeFilters);
    }
}
