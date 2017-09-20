using EncounterGen.Domain.Selectors.Selections;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal interface ITreasureRatesSelector
    {
        TreasureRatesSelection SelectFor(string creature);
    }
}
