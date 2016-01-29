namespace EncounterGen.Selectors.Percentiles
{
    public interface IBooleanPercentileSelector
    {
        bool SelectFrom(double trueThreshold);
    }
}
