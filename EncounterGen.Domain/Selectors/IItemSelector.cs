using TreasureGen.Items;

namespace EncounterGen.Domain.Selectors
{
    internal interface IItemSelector
    {
        string SelectFrom(Item source);
        Item SelectFrom(string source);
    }
}
