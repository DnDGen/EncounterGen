using EncounterGen.Mappers;
using EncounterGen.Selectors.Percentiles;
using RollGen;
using System;

namespace EncounterGen.Selectors.Domain.Percentiles
{
    public class PercentileSelector : IPercentileSelector
    {
        private PercentileMapper percentileMapper;
        private IDice dice;

        public PercentileSelector(PercentileMapper percentileMapper, IDice dice)
        {
            this.percentileMapper = percentileMapper;
            this.dice = dice;
        }

        public String SelectFrom(String tableName)
        {
            var table = percentileMapper.Map(tableName);
            var roll = dice.Roll().Percentile();

            if (table.ContainsKey(roll) == false)
            {
                var message = String.Format("{0} is not a valid entry in the table {1}", roll, tableName);
                throw new ArgumentException(message);
            }

            return table[roll];
        }
    }
}
