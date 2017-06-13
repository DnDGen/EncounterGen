using EncounterGen.Common;
using System.Collections.Generic;
using TreasureGen;

namespace EncounterGen.Domain.Generators
{
    internal interface IEncounterTreasureGenerator
    {
        IEnumerable<Treasure> GenerateFor(IEnumerable<Creature> creatures, int level);
    }
}
