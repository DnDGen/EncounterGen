using DnDGen.EncounterGen.Generators;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Selectors.Collections
{
    internal interface IEncounterCollectionSelector
    {
        Dictionary<string, string> SelectRandomFrom(EncounterSpecifications encounterSpecifications);
        IEnumerable<Dictionary<string, string>> SelectAllWeightedFrom(EncounterSpecifications encounterSpecifications);
        IEnumerable<Dictionary<string, string>> SelectPossibleFrom(
            string environment = "",
            string temperature = "",
            string timeOfDay = "",
            int level = 0,
            bool? allowAquatic = null,
            bool? allowUnderground = null,
            params string[] filters);
        IEnumerable<string> SelectPossibleTemperatures(string environment);
        IEnumerable<string> SelectPossibleTimesOfDay(string environment, string temperature);
        IEnumerable<int> SelectPossibleLevels(string environment, string temperature, string timeOfDay);
        IEnumerable<bool> SelectPossibleAllowAquatic(string environment, string temperature, string timeOfDay, int level);
        IEnumerable<bool> SelectPossibleAllowUnderground(string environment, string temperature, string timeOfDay, int level, bool allowAquatic);
        IEnumerable<string> SelectPossibleFilters(string environment, string temperature, string timeOfDay, int level, bool allowAquatic, bool allowUnderground);
    }
}
