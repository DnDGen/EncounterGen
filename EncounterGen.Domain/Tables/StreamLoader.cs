using System.IO;

namespace EncounterGen.Domain.Tables
{
    internal interface StreamLoader
    {
        Stream LoadFor(string filename);
    }
}
