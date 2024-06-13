using DnDGen.CharacterGen.Characters;
using DnDGen.EncounterGen.Models;
using System.Collections.Generic;

namespace DnDGen.EncounterGen.Generators
{
    internal interface IEncounterCharacterGenerator
    {
        IEnumerable<Character> GenerateFrom(IEnumerable<EncounterCreature> creatures);
    }
}
