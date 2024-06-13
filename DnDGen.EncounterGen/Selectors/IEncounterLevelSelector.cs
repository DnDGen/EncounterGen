using DnDGen.EncounterGen.Models;

namespace DnDGen.EncounterGen.Selectors
{
    internal interface IEncounterLevelSelector
    {
        int Select(Encounter encounter);
    }
}
