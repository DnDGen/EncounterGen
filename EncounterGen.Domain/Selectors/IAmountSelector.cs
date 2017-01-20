using EncounterGen.Common;

namespace EncounterGen.Domain.Selectors
{
    internal interface IAmountSelector
    {
        int SelectFrom(string amount);
        int SelectAverageEncounterLevel(string encounter);
        int SelectActualEncounterLevel(Encounter encounter);
    }
}
