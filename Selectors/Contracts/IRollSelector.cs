using System;

namespace EncounterGen.Selectors
{
    public interface IRollSelector
    {
        String SelectFrom(String baseRoll, Int32 modifier);
        Double SelectFrom(String roll);
        String SelectRollFrom(String source);
    }
}
