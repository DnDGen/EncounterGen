using System;

namespace EncounterGen.Selectors
{
    public interface IRollSelector
    {
        String SelectFrom(String baseRoll, String modifier);
        Int32 SelectFrom(String roll);
    }
}
