using DnDGen.Core.Tables;
using DnDGen.EncounterGen.Tables;
using System.Reflection;

namespace DnDGen.EncounterGen.Tests.Integration.Tables
{
    public class EncounterGenAssemblyLoader : AssemblyLoader
    {
        public Assembly GetRunningAssembly()
        {
            var type = typeof(TableNameConstants);
            return type.Assembly;
        }
    }
}
