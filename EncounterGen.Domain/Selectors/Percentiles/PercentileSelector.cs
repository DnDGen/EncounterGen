using EncounterGen.Domain.Mappers.Percentiles;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EncounterGen.Domain.Selectors.Percentiles
{
    internal class PercentileSelector : IPercentileSelector
    {
        private PercentileMapper percentileMapper;
        private Dice dice;

        public PercentileSelector(PercentileMapper percentileMapper, Dice dice)
        {
            this.percentileMapper = percentileMapper;
            this.dice = dice;
        }

        public string SelectFrom(string tableName)
        {
            var table = percentileMapper.Map(tableName);
            var roll = dice.Roll().Percentile();

            if (table.ContainsKey(roll) == false)
            {
                var message = string.Format("{0} is not a valid entry in the table {1}", roll, tableName);
                throw new ArgumentException(message);
            }

            return table[roll];
        }

        public IEnumerable<string> SelectAllFrom(string tableName)
        {
            var table = percentileMapper.Map(tableName);
            return table.Values.Distinct();
        }
    }
}
