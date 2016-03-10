namespace EncounterGen.Selectors
{
    public interface IRollSelector
    {
        string SelectFrom(string baseRoll, int modifier);
        string SelectFrom(int effectiveLevel, string challengeRating);
    }
}
