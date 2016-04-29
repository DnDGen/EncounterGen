namespace EncounterGen.Domain.Selectors.Percentiles
{
    internal interface IBooleanPercentileSelector
    {
        bool SelectFrom(double trueThreshold);
    }
}
