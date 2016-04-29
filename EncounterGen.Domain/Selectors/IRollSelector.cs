namespace EncounterGen.Domain.Selectors
{
    internal interface IRollSelector
    {
        string SelectFrom(string baseRoll, int modifier);
        string SelectFrom(int effectiveLevel, string challengeRating);
    }
}
