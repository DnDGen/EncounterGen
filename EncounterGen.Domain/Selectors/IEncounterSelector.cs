using System.Collections.Generic;

namespace EncounterGen.Domain.Selectors
{
    internal interface IEncounterSelector
    {
        Dictionary<string, string> SelectCreaturesAndAmountsFrom(string encounter);
        string BuildEncounter(Dictionary<string, string> creaturesAndAmounts);
        string SelectNameFrom(string creature);
        string SelectDescriptionFrom(string creature);
        string SelectSubtypeFrom(string creature);
        string SelectChallengeRatingFrom(string creature);
        string SelectBaseRaceFrom(string creature);
        string SelectMetaraceFrom(string creature);
        IEnumerable<string> SelectCharacterClassesFrom(string creature);
        string BuildCreature(string name, string description = "", string subtype = "", string challengeRating = "", string baseRace = "", string metarace = "", params string[] characterClasses);
    }
}
