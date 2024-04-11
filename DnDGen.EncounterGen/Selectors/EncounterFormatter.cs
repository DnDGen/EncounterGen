using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Selectors
{
    internal class EncounterFormatter : IEncounterFormatter
    {
        public string BuildCreature(string name, string description = "", string subtype = "", string challengeRating = "", string baseRace = "", string metarace = "", params string[] characterClasses)
        {
            var creature = name;

            if (!string.IsNullOrEmpty(description))
                creature += $"({description})";

            if (!string.IsNullOrEmpty(subtype))
                creature += $"${subtype}$";

            if (!string.IsNullOrEmpty(challengeRating))
                creature += $"[{challengeRating}]";

            if (!string.IsNullOrEmpty(baseRace))
                creature += $"{{{baseRace}}}";

            if (!string.IsNullOrEmpty(metarace))
                creature += $"#{metarace}#";

            if (characterClasses.Any())
                creature += $"@{string.Join("&", characterClasses)}@";

            return creature;
        }

        public string BuildEncounter(Dictionary<string, string> creaturesAndAmounts)
        {
            var formattedCreaturesAndAmounts = creaturesAndAmounts.Select(kvp => $"{kvp.Key}/{kvp.Value}");
            return string.Join(",", formattedCreaturesAndAmounts);
        }

        public string SelectBaseRaceFrom(string creature)
        {
            return GetSubstring(creature, '{', '}');
        }

        private string GetSubstring(string source, char start, char end)
        {
            var startIndex = source.IndexOf(start);
            if (startIndex == -1)
                return string.Empty;

            var endIndex = source.LastIndexOf(end);

            return source.Substring(startIndex + 1, endIndex - startIndex - 1);
        }

        public string SelectChallengeRatingFrom(string creature)
        {
            return GetSubstring(creature, '[', ']');
        }

        public IEnumerable<string> SelectCharacterClassesFrom(string creature)
        {
            var substring = GetSubstring(creature, '@', '@');
            return substring.Split('&').Where(c => !string.IsNullOrEmpty(c));
        }

        public Dictionary<string, string> SelectCreaturesAndAmountsFrom(string encounter)
        {
            var rawCreaturesAndAmounts = encounter.Split(',');
            return rawCreaturesAndAmounts.Select(ca => ca.Split('/')).ToDictionary(ca => ca[0], ca => ca[1]);
        }

        public string SelectDescriptionFrom(string creature)
        {
            return GetSubstring(creature, '(', ')');
        }

        public string SelectMetaraceFrom(string creature)
        {
            return GetSubstring(creature, '#', '#');
        }

        public string SelectNameFrom(string creature)
        {
            var firstIndex = creature.IndexOfAny(new[] { '#', '$', '@', '(', '[', '{' });
            if (firstIndex == -1)
                return creature;

            return creature.Substring(0, firstIndex);
        }

        public string SelectSubtypeFrom(string creature)
        {
            return GetSubstring(creature, '$', '$');
        }
    }
}
