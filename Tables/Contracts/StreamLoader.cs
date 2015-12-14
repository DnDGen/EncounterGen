using System;
using System.IO;

namespace EncounterGen.Tables
{
    public interface StreamLoader
    {
        Stream LoadFor(String filename);
    }
}
