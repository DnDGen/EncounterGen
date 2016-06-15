using EncounterGen.Common;

namespace EncounterGen.Generators
{
    public interface IEncounterGenerator
    {
        Encounter Generate(string environment, int level, params string[] creatureTypeFilters);
    }
}
