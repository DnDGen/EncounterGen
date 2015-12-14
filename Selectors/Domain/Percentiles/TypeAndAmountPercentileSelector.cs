using EncounterGen.Selectors.Percentiles;
using System;
using System.Collections.Generic;

namespace EncounterGen.Selectors.Domain.Percentiles
{
    public class TypeAndAmountPercentileSelector : ITypeAndAmountPercentileSelector
    {
        private IPercentileSelector innerSelector;

        public TypeAndAmountPercentileSelector(IPercentileSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public Dictionary<String, String> SelectFrom(String tableName)
        {
            var result = innerSelector.SelectFrom(tableName);
            var typeAndAmountPairs = result.Split(',');
            var typesAndAmounts = new Dictionary<String, String>();

            foreach (var pair in typeAndAmountPairs)
            {
                var sections = pair.Split('/');
                typesAndAmounts[sections[0]] = sections[1];
            }

            return typesAndAmounts;
        }
    }
}
