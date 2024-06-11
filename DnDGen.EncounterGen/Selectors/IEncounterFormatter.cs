using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DnDGen.EncounterGen.Tests.Unit")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
[assembly: InternalsVisibleTo("DnDGen.EncounterGen.Tests.Integration")]
[assembly: InternalsVisibleTo("DnDGen.EncounterGen.Tests.Integration.IoC")]
[assembly: InternalsVisibleTo("DnDGen.EncounterGen.Tests.Integration.Tables")]
namespace DnDGen.EncounterGen.Selectors
{
    internal interface IEncounterFormatter
    {
        Dictionary<string, string> SelectCreaturesAndAmountsFrom(IEnumerable<string> encounterCreatureData);
        string SelectNameFrom(string creature);
        string SelectDescriptionFrom(string creature);
        string SelectSubCreatureFrom(string creature);
        string SelectChallengeRatingFrom(string creature);
        string SelectBaseRaceFrom(string creature);
        string SelectMetaraceFrom(string creature);
        IEnumerable<string> SelectCharacterClassesFrom(string creature);
        string BuildCreature(
            string name,
            string description = "",
            string subcreature = "",
            string challengeRating = "",
            string baseRace = "",
            string metarace = "",
            params string[] characterClasses);
    }
}
