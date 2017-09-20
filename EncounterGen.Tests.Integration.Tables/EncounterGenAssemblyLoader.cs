using DnDGen.Core.Tables;
using EncounterGen.Domain.Tables;
using System.Reflection;

namespace EncounterGen.Tests.Integration.Tables
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
