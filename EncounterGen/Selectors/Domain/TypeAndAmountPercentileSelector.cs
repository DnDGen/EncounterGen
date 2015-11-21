using EncounterGen.Mappers;
using RollGen;
using System;
using System.Collections.Generic;

namespace EncounterGen.Selectors.Domain
{
    public class TypeAndAmountPercentileSelector : ITypeAndAmountPercentileSelector
    {
        private PercentileMapper percentileMapper;
        private IDice dice;

        public TypeAndAmountPercentileSelector(PercentileMapper percentileMapper, IDice dice)
        {
            this.percentileMapper = percentileMapper;
            this.dice = dice;
        }

        public Dictionary<String, Int32> SelectFrom(String tableName)
        {
            var table = percentileMapper.Map(tableName);
            var roll = dice.Roll().Percentile();
            var result = table[roll];
            var typeAndAmountPairs = result.Split(',');
            var typesAndAmounts = new Dictionary<String, Int32>();

            foreach (var pair in typeAndAmountPairs)
            {
                var sections = pair.Split('/');
                typesAndAmounts[sections[0]] = GetAmount(sections[1]);
            }

            return typesAndAmounts;
        }

        private Int32 GetAmount(String amountString)
        {
            var sections = amountString.Split('d', '+');

            if (sections.Length == 1)
                return Convert.ToInt32(sections[0]);

            var bonus = 0;
            if (sections.Length == 3)
                bonus = Convert.ToInt32(sections[2]);

            var quantity = Convert.ToInt32(sections[0]);
            var die = Convert.ToInt32(sections[1]);

            return dice.Roll(quantity).d(die) + bonus;
        }
    }
}
