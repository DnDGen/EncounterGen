using EncounterGen.Selectors.Models;
using System;

namespace EncounterGen.Selectors
{
    public interface ITypeAndAmountPercentileSelector
    {
        TypesAndAmountsModel SelectFrom(String tableName);
    }
}
