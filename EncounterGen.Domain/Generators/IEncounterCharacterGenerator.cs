using CharacterGen;
using EncounterGen.Common;
using System.Collections.Generic;

namespace EncounterGen.Domain.Generators
{
    internal interface IEncounterCharacterGenerator
    {
        IEnumerable<Character> GenerateFrom(IEnumerable<Creature> creatures);
    }
}
