using System;

namespace EncounterGen.Selectors.Percentiles
{
    public interface IBooleanPercentileSelector
    {
        Boolean SelectFrom(Double trueThreshold);
    }
}
