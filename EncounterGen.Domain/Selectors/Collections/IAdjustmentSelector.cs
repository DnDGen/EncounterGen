namespace EncounterGen.Domain.Selectors.Collections
{
    internal interface IAdjustmentSelector
    {
        int Select(string tableName, string entry, int index = 0);
        double SelectDouble(string tableName, string entry, int index = 0);
    }
}
