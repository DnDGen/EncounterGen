using EncounterGen.Common;
using System.Collections.Generic;

namespace EncounterGen.Generators
{
    public interface IEncounterVerifier
    {
        int MinimumLevel { get; }
        int MaximumLevel { get; }

        bool ValidEncounterExistsAtLevel(string environment, int level, string temperature, string timeOfDay, params string[] creatureTypeFilters);
        bool EncounterIsValid(IEnumerable<string> creatures, params string[] creatureTypeFilters);
        bool EncounterIsValid(IEnumerable<Creature> creatures, params string[] creatureTypeFilters);
        bool CreatureIsValid(string creatureName, params string[] creatureTypeFilters);
    }
}
