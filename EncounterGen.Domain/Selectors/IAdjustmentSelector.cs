namespace EncounterGen.Domain.Selectors
{
    internal interface IAdjustmentSelector
    {
        int Select(string tableName, string entry, int index = 0);
        T Select<T>(string tableName, string entry, int index = 0);
    }
}
