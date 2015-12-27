using EncounterGen.Mappers;
using EncounterGen.Selectors.Percentiles;
using RollGen;
using System;

namespace EncounterGen.Selectors.Domain.Percentiles
{
    public class PercentileSelector : IPercentileSelector
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
    }
}
