using EncounterGen.Common;

namespace EncounterGen.Domain.Selectors
{
    internal interface IEncounterLevelSelector
    {
        int Select(Encounter encounter);
    }
}
