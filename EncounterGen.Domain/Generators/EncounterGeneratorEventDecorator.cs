using EncounterGen.Common;
using EncounterGen.Generators;
using EventGen;
using System.Linq;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterGeneratorEventDecorator : EncounterGen.Generators.IEncounterGenerator
    {
        private readonly EncounterGen.Generators.IEncounterGenerator internalGenerator;
        private readonly GenEventQueue eventQueue;

        public EncounterGeneratorEventDecorator(EncounterGen.Generators.IEncounterGenerator internalGenerator, GenEventQueue eventQueue)
        {
            this.internalGenerator = internalGenerator;
            this.eventQueue = eventQueue;
        }

        public Encounter Generate(EncounterSpecifications specifications)
        {
            eventQueue.Enqueue("EncounterGen", $"Beginning generation of encounter in {specifications.Description}");
            var encounter = internalGenerator.Generate(specifications);

            eventQueue.Enqueue("EncounterGen", $"Completed generation of {encounter.ActualDifficulty} encounter with {encounter.Creatures.Count()} creatures and {encounter.Characters.Count()} characters");

            return encounter;
        }
    }
}
