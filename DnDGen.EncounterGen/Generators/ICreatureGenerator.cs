using DnDGen.EncounterGen.Models;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Generators
{
    internal interface ICreatureGenerator
    {
        IEnumerable<Creature> GenerateFor(string encounter);
        IEnumerable<Creature> CleanCreatures(IEnumerable<Creature> creatures);
    }
}
