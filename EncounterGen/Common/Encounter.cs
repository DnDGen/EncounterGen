using CharacterGen.Common;
using System.Collections.Generic;
using TreasureGen.Common;

namespace EncounterGen.Common
{
    public class Encounter
    {
        public IEnumerable<Creature> Creatures { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        public Treasure Treasure { get; set; }
    }
}
