using DnDGen.EncounterGen.Selectors.Selections;

namespace DnDGen.EncounterGen.Selectors.Collections
{
    internal interface ITreasureRatesSelector
    {
        TreasureRatesSelection SelectFor(string creature);
    }
}
