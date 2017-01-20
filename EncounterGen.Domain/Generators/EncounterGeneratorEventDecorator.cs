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

        public Encounter Generate(string environment, int level, string temperature, string timeOfDay, params string[] creatureTypeFilters)
        {
            eventQueue.Enqueue("EncounterGen", $"Beginning generation of level {level} encounter in {temperature} {environment} {timeOfDay}");
            var encounter = internalGenerator.Generate(environment, level, temperature, timeOfDay, creatureTypeFilters);

            eventQueue.Enqueue("EncounterGen", $"Completed generation of {encounter.ActualDifficulty} encounter with {encounter.Creatures.Count()} creatures and {encounter.Characters.Count()} characters");

            return encounter;
        }
    }
}
