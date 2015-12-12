using System;

namespace EncounterGen.Selectors
{
    public interface IAdjustmentSelector
    {
        Int32 SelectFrom(String tableName, String entry);
        Double SelectFrom(String tableName, String entry, Int32 subEntry);
    }
}
