using DnDGen.EncounterGen.Models;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Generators
{
    internal interface ICreatureGenerator
    {
        IEnumerable<EncounterCreature> GenerateFor(string encounter);
        IEnumerable<EncounterCreature> CleanCreatures(IEnumerable<EncounterCreature> creatures);
    }
}
