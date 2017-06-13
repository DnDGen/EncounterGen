using EncounterGen.Common;
using EncounterGen.Generators;
using System.Collections.Generic;

namespace EncounterGen.Domain.Generators
{
    internal interface ICreatureGenerator
    {
        IEnumerable<Creature> GenerateFor(EncounterSpecifications encounterSpecifications);
        IEnumerable<Creature> CleanCreatures(IEnumerable<Creature> creatures);
    }
}
