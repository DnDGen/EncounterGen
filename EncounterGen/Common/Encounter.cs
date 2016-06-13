using CharacterGen;
using System.Collections.Generic;
using System.Linq;
using TreasureGen;

namespace EncounterGen.Common
{
    public class Encounter
    {
        public IEnumerable<Creature> Creatures { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        public Treasure Treasure { get; set; }

        public Encounter()
        {
            Creatures = Enumerable.Empty<Creature>();
            Characters = Enumerable.Empty<Character>();
            Treasure = new Treasure();
        }
    }
}
