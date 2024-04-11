using DnDGen.EncounterGen.Models;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Generators
{
    public interface IEncounterVerifier
    {
        bool ValidEncounterExists(EncounterSpecifications encounterSpecifications);
        bool ValidEncounterExists(
            string environment = "",
            string temperature = "",
            string timeOfDay = "",
            int level = 0,
            bool allowAquatic = true,
            bool allowUnderground = true,
            params string[] filters);
        bool EncounterIsValid(IEnumerable<string> creatures, IEnumerable<string> creatureTypeFilters);
        bool EncounterIsValid(Encounter encounter, IEnumerable<string> creatureTypeFilters);
        bool CreatureIsValid(string creatureName, IEnumerable<string> creatureTypeFilters);

        IEnumerable<string> GetValidTemperatues(string environment);
        IEnumerable<string> GetValidTimesOfDay(string environment, string temperature);
        IEnumerable<int> GetValidLevels(string environment, string temperature, string timeOfDay);
        IEnumerable<bool> GetValidAllowAquatic(string environment, string temperature, string timeOfDay, int level);
        IEnumerable<bool> GetValidAllowUnderground(string environment, string temperature, string timeOfDay, int level, bool allowAquatic);
        IEnumerable<string> GetValidFilters(string environment, string temperature, string timeOfDay, int level, bool allowAquatic, bool allowUnderground);
    }
}
