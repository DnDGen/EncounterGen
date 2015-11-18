using CharacterGen.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using TreasureGen.Common;

namespace EncounterGen.Common
{
    public class Encounter
    {
        public IEnumerable<String> Creatures { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Treasure> Treasures { get; set; }

        public Encounter()
        {
            Creatures = Enumerable.Empty<String>();
            Characters = Enumerable.Empty<Character>();
            Treasures = Enumerable.Empty<Treasure>();
        }
    }
}
