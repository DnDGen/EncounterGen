﻿using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Selectors
{
    internal class EncounterFormatter : IEncounterFormatter
    {
        public string BuildCreature(
            string name,
            string description = "",
            string subcreature = "",
            string challengeRating = "",
            string baseRace = "",
            string metarace = "",
            params string[] characterClasses)
        {
            var creature = name;

            if (!string.IsNullOrEmpty(description))
                creature += $"({description})";

            if (!string.IsNullOrEmpty(subcreature))
                creature += $"${subcreature}$";

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
            return SelectCreaturesAndAmountsFrom(rawCreaturesAndAmounts);
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

            return creature[..firstIndex];
        }

        public string SelectSubCreatureFrom(string creature)
        {
            return GetSubstring(creature, '$', '$');
        }

        public Dictionary<string, string> SelectCreaturesAndAmountsFrom(IEnumerable<string> encounterCreatureData)
        {
            return encounterCreatureData.Select(ca => ca.Split('/')).ToDictionary(ca => ca[0], ca => ca[1]);
        }
    }
}
