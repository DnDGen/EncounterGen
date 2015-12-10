using System;

namespace EncounterGen.Selectors
{
    public interface IRollSelector
    {
        String SelectFrom(String baseRoll, Int32 modifier);
        Int32 SelectFrom(String roll);
        String SelectRollFrom(String source);
    }
}
