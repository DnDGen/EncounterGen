namespace EncounterGen.Selectors
{
    public interface IRollSelector
    {
        string SelectFrom(string baseRoll, int modifier);
        double SelectFrom(string roll);
        string SelectRollFrom(string source);
        string SelectFrom(int effectiveLevel, string challengeRating);
    }
}
