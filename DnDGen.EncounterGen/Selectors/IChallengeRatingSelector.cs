namespace DnDGen.EncounterGen.Selectors
{
    internal interface IChallengeRatingSelector
    {
        string SelectAverageForCreature(string creature);
        double Select(string challengeRating);
        string Select(double challengeRating);
    }
}
