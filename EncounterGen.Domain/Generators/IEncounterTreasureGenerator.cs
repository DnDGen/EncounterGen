using EncounterGen.Common;
using TreasureGen;

namespace EncounterGen.Domain.Generators
{
    internal interface IEncounterTreasureGenerator
    {
        Treasure GenerateFor(Creature creature, int level);
    }
}
