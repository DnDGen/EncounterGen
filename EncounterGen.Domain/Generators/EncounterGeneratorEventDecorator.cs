using EncounterGen.Common;
using EncounterGen.Generators;
using EventGen;
using System.Linq;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterGeneratorEventDecorator : IEncounterGenerator
    {
        private readonly IEncounterGenerator internalGenerator;
        private readonly GenEventQueue eventQueue;

        public EncounterGeneratorEventDecorator(IEncounterGenerator internalGenerator, GenEventQueue eventQueue)
        {
            this.internalGenerator = internalGenerator;
            this.eventQueue = eventQueue;
        }

        public Encounter Generate(EncounterSpecifications specifications)
        {
            eventQueue.Enqueue("EncounterGen", $"Generating encounter in {specifications.Description}");
            var encounter = internalGenerator.Generate(specifications);

            eventQueue.Enqueue("EncounterGen", $"Generated {encounter.ActualDifficulty} encounter with {encounter.Creatures.Count()} creatures and {encounter.Characters.Count()} characters");

            return encounter;
        }
    }
}
