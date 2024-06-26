﻿using DnDGen.EncounterGen.Tables;
using DnDGen.Infrastructure.Tables;
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
