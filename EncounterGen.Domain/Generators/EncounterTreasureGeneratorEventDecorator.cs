using EncounterGen.Common;
using EventGen;
using System.Collections.Generic;
using System.Linq;
using TreasureGen;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterTreasureGeneratorEventDecorator : IEncounterTreasureGenerator
    {
        private readonly IEncounterTreasureGenerator internalGenerator;
        private readonly GenEventQueue eventQueue;

        public EncounterTreasureGeneratorEventDecorator(IEncounterTreasureGenerator internalGenerator, GenEventQueue eventQueue)
        {
            this.internalGenerator = internalGenerator;
            this.eventQueue = eventQueue;
        }

        public IEnumerable<Treasure> GenerateFor(IEnumerable<Creature> creatures, int level)
        {
            eventQueue.Enqueue("EncounterGen", $"Beginning generation of level {level} treasure for {creatures.Count()} creatures");
            var treasures = internalGenerator.GenerateFor(creatures, level);
            eventQueue.Enqueue("EncounterGen", $"Completed generation of {treasures.Count()} treasures");

            return treasures;
        }
    }
}
