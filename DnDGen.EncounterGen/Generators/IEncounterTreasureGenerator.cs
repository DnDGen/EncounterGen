using DnDGen.EncounterGen.Models;
using DnDGen.TreasureGen;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Generators
{
    internal interface IEncounterTreasureGenerator
    {
        IEnumerable<Treasure> GenerateFor(IEnumerable<Creature> creatures, int level);
    }
}
