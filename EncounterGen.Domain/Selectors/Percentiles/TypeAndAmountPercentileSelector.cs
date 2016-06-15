using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors.Percentiles
{
    internal class TypeAndAmountPercentileSelector : ITypeAndAmountPercentileSelector
    {
        private IPercentileSelector innerSelector;

        public TypeAndAmountPercentileSelector(IPercentileSelector innerSelector)
        {
            this.innerSelector = innerSelector;
        }

        public IEnumerable<Dictionary<string, string>> SelectAllFrom(string tableName)
        {
            var results = innerSelector.SelectAllFrom(tableName);
            var allTypesAndAmounts = new List<Dictionary<string, string>>();

            foreach (var result in results)
            {
                var typesAndAmounts = ParseTypesAndAmounts(result);
                allTypesAndAmounts.Add(typesAndAmounts);
            }

            return allTypesAndAmounts;
        }

        public Dictionary<string, string> SelectFrom(string tableName)
        {
            var result = innerSelector.SelectFrom(tableName);
            return ParseTypesAndAmounts(result);
        }

        private Dictionary<string, string> ParseTypesAndAmounts(string result)
        {
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
