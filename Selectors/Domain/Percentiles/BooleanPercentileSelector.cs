using EncounterGen.Selectors.Percentiles;
using RollGen;

namespace EncounterGen.Selectors.Domain.Percentiles
{
    public class BooleanPercentileSelector : IBooleanPercentileSelector
    {
        private Dice dice;

        public BooleanPercentileSelector(Dice dice)
        {
            this.dice = dice;
        }

        public bool SelectFrom(double trueThreshold)
        {
            var roll = dice.Roll().Percentile();
            return roll <= trueThreshold * 100;
        }
    }
}
