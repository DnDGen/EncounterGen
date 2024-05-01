using DnDGen.EncounterGen.Models;
using System;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Generators
{
    internal interface ICreatureGenerator
    {
        [Obsolete]
        IEnumerable<Creature> GenerateFor(EncounterSpecifications encounterSpecifications);
        IEnumerable<Creature> GenerateFor(string encounter);
        IEnumerable<Creature> CleanCreatures(IEnumerable<Creature> creatures);
    }
}
