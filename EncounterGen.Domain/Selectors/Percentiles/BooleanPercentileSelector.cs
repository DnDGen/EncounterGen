using RollGen;

namespace EncounterGen.Domain.Selectors.Percentiles
{
    internal class BooleanPercentileSelector : IBooleanPercentileSelector
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
