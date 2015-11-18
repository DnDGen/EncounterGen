using System;
using System.Collections.Generic;

namespace EncounterGen.Selectors.Models
{
    public class TypesAndAmountsModel
    {
        public Dictionary<String, Int32> TypesAndAmounts { get; set; }

        public TypesAndAmountsModel()
        {
            TypesAndAmounts = new Dictionary<String, Int32>();
        }
    }
}
