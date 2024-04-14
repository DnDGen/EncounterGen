using DnDGen.EncounterGen.Models;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DnDGen.EncounterGen.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DnDGen.EncounterGen.Tests.Integration")]
[assembly: InternalsVisibleTo("DnDGen.EncounterGen.Tests.Integration.IoC")]
[assembly: InternalsVisibleTo("DnDGen.EncounterGen.Tests.Integration.Tables")]
namespace DnDGen.EncounterGen.Generators
{
    public interface IEncounterGenerator
    {
        Encounter Generate(EncounterSpecifications encounterSpecifications);
    }
}
