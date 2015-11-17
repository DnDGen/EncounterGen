using EncounterGen.Common;
using System;

namespace EncounterGen.Generators
{
    public interface IEncounterGenerator
    {
        Encounter Generate(String environment, Int32 level);
    }
}
