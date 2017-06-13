using EncounterGen.Common;
using EncounterGen.Generators;
using EventGen;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Generators
{
    internal class CreatureGeneratorEventDecorator : ICreatureGenerator
    {
        private readonly ICreatureGenerator internalGenerator;
        private readonly GenEventQueue eventQueue;

        public CreatureGeneratorEventDecorator(ICreatureGenerator internalGenerator, GenEventQueue eventQueue)
        {
            this.internalGenerator = internalGenerator;
            this.eventQueue = eventQueue;
        }

        public IEnumerable<Creature> GenerateFor(EncounterSpecifications encounterSpecifications)
        {
            eventQueue.Enqueue("EncounterGen", $"Beginning generation of creatures for {encounterSpecifications.Description}");
            var creatures = internalGenerator.GenerateFor(encounterSpecifications);
            eventQueue.Enqueue("EncounterGen", $"Completed generation of {creatures.Count()} creatures");

            return creatures;
        }

        public IEnumerable<Creature> CleanCreatures(IEnumerable<Creature> creatures)
        {
            eventQueue.Enqueue("EncounterGen", $"Cleaning {creatures.Count()} creatures");
            var cleanedCreatures = internalGenerator.CleanCreatures(creatures);
            eventQueue.Enqueue("EncounterGen", $"Completed cleaning of {cleanedCreatures.Count()} creatures");

            return cleanedCreatures;
        }
    }
}
