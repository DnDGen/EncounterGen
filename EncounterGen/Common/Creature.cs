using System;

namespace EncounterGen.Common
{
    public class Creature
    {
        public String Type { get; set; }
        public Int32 Quantity { get; set; }

        public Creature()
        {
            Type = String.Empty;
        }
    }
}
