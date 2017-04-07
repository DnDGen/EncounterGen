using EncounterGen.Common;

namespace EncounterGen.Generators
{
    public interface IEncounterGenerator
    {
        Encounter Generate(EncounterSpecifications encounterSpecifications);
    }
}
