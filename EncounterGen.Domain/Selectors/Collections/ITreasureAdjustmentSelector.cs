using EncounterGen.Domain.Selectors.Selections;

namespace EncounterGen.Domain.Selectors.Collections
{
    internal interface ITreasureAdjustmentSelector
    {
        TreasureRatesSelection SelectFor(string creature);
    }
}
