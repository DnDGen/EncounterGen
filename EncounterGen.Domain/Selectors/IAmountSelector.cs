using EncounterGen.Common;
using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors
{
    internal interface IAmountSelector
    {
        int SelectFrom(string amount);
        int SelectAverageEncounterLevel(string encounter);
        int SelectEncounterLevel(IEnumerable<Creature> creatures);
    }
}
