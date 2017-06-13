using CharacterGen.Characters;
using EncounterGen.Common;
using EventGen;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterCharacterGeneratorEventDecorator : IEncounterCharacterGenerator
    {
        private readonly IEncounterCharacterGenerator internalGenerator;
        private readonly GenEventQueue eventQueue;

        public EncounterCharacterGeneratorEventDecorator(IEncounterCharacterGenerator internalGenerator, GenEventQueue eventQueue)
        {
            this.internalGenerator = internalGenerator;
            this.eventQueue = eventQueue;
        }

        public IEnumerable<Character> GenerateFrom(IEnumerable<Creature> creatures)
        {
            eventQueue.Enqueue("EncounterGen", $"Beginning generation of characters from {creatures.Count()} creatures");
            var characters = internalGenerator.GenerateFrom(creatures);
            eventQueue.Enqueue("EncounterGen", $"Completed generation of {characters.Count()} characters");

            return characters;
        }
    }
}
