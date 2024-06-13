using DnDGen.TreasureGen.Items;
using DnDGen.TreasureGen.Items.Magical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DnDGen.EncounterGen.Selectors
{
    internal class ItemSelector : IItemSelector
    {
        private readonly Regex itemTypeRegex;
        private readonly Regex itemBonusRegex;
        private readonly Regex specialAbilityRegex;
        private readonly Regex specialAbilityBonusRegex;
        private readonly Regex traitRegex;
        private readonly Regex isMagicRegex;

        public ItemSelector()
        {
            itemTypeRegex = new Regex(RegexConstants.ItemTypePattern);
            itemBonusRegex = new Regex(RegexConstants.ItemBonusPattern);
            specialAbilityRegex = new Regex(RegexConstants.SpecialAbilitiesPattern);
            specialAbilityBonusRegex = new Regex(RegexConstants.SpecialAbilitiesBonusPattern);
            traitRegex = new Regex(RegexConstants.TraitPattern);
            isMagicRegex = new Regex(RegexConstants.IsMagicPattern);
        }

        public Item SelectFrom(string source)
        {
            var template = new Item();
            template.Name = source;
            template.Name = itemTypeRegex.Replace(template.Name, string.Empty);
            template.Name = itemBonusRegex.Replace(template.Name, string.Empty);
            template.Name = specialAbilityRegex.Replace(template.Name, string.Empty);
            template.Name = traitRegex.Replace(template.Name, string.Empty);
            template.Name = isMagicRegex.Replace(template.Name, string.Empty);

            template.ItemType = GetMatchValue(itemTypeRegex, source, "[", "]");

            if (isMagicRegex.IsMatch(source))
            {
                var rawIsMagic = GetMatchValue(isMagicRegex, source, "@", "@");
                template.IsMagical = Convert.ToBoolean(rawIsMagic);
            }

            if (itemBonusRegex.IsMatch(source))
            {
                var rawBonus = GetMatchValue(itemBonusRegex, source, "(", ")");
                template.Magic.Bonus = Convert.ToInt32(rawBonus);
            }

            if (specialAbilityRegex.IsMatch(source))
            {
                var rawSpecialAbilities = GetMatchValue(specialAbilityRegex, source, "{", "}");
                var specialAbilities = rawSpecialAbilities.Split(',');
                template.Magic.SpecialAbilities = GetSpecialAbilities(specialAbilities);
            }

            if (traitRegex.IsMatch(source))
            {
                var rawTraits = GetMatchValue(traitRegex, source, "#");
                var traits = rawTraits.Split(',');

                foreach (var trait in traits)
                {
                    template.Traits.Add(trait);
                }
            }

            return template;
        }

        private IEnumerable<SpecialAbility> GetSpecialAbilities(IEnumerable<string> abilityTemplates)
        {
            var abilities = new List<SpecialAbility>();

            foreach (var specialAbilityTemplate in abilityTemplates)
            {
                var specialAbility = new SpecialAbility();
                specialAbility.Name = specialAbilityTemplate;
                specialAbility.Name = specialAbilityBonusRegex.Replace(specialAbility.Name, string.Empty);

                if (specialAbilityBonusRegex.IsMatch(specialAbilityTemplate))
                {
                    var rawBonus = GetMatchValue(specialAbilityBonusRegex, specialAbilityTemplate, "$", "$");
                    specialAbility.BonusEquivalent = Convert.ToInt32(rawBonus);
                }

                abilities.Add(specialAbility);
            }

            return abilities;
        }

        private string GetMatchValue(Regex regex, string source, params string[] wrappers)
        {
            var matchValue = regex.Match(source).Value;

            foreach (var wrapper in wrappers)
                matchValue = matchValue.Replace(wrapper, string.Empty);

            return matchValue;
        }

        public string SelectFrom(Item source)
        {
            var template = $"{source.Name}[{source.ItemType}]";

            if (source.Traits.Any())
            {
                var traits = string.Join(",", source.Traits);
                template += $"#{traits}#";
            }

            if (source.Magic.Bonus > 0)
            {
                template += $"({source.Magic.Bonus})";
            }

            if (source.Magic.SpecialAbilities.Any())
            {
                var abilitySummaries = source.Magic.SpecialAbilities.Select(a => GetAbilitySummary(a));
                var summaries = string.Join(",", abilitySummaries);
                template += $"{{{summaries}}}";
            }

            if (source.IsMagical)
            {
                template += $"@{source.IsMagical}@";
            }

            return template;
        }

        private string GetAbilitySummary(SpecialAbility ability)
        {
            var summary = ability.Name;

            if (ability.BonusEquivalent > 0)
                summary += $"${ability.BonusEquivalent}$";

            return summary;
        }
    }
}
