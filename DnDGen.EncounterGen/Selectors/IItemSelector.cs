using DnDGen.TreasureGen.Items;

namespace DnDGen.EncounterGen.Selectors
{
    internal interface IItemSelector
    {
        string SelectFrom(Item source);
        Item SelectFrom(string source);
    }
}
