using EncounterGen.Selectors.Percentiles;
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

        public Dictionary<string, string> SelectFrom(string tableName)
        {
            var result = innerSelector.SelectFrom(tableName);
            var typeAndAmountPairs = result.Split(',');
            var typesAndAmounts = new Dictionary<string, string>();

            foreach (var pair in typeAndAmountPairs)
            {
                var sections = pair.Split('/');
                typesAndAmounts[sections[0]] = sections[1];
            }

            return typesAndAmounts;
        }
    }
}
