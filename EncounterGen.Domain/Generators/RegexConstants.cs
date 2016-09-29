namespace EncounterGen.Domain.Generators
{
    internal static class RegexConstants
    {
        public const string ChallengeRatingPattern = "\\[[^\\[\\]]+\\]";
        public const string DescriptionPattern = " \\(.+\\)";
        public const string IsMagicPattern = "@.+@";
        public const string ItemBonusPattern = "\\(\\d+\\)";
        public const string ItemTypePattern = "\\[.+\\]";
        public const string SetCharacterLevelPattern = "\\d+";
        public const string SpecialAbilitiesPattern = "\\{.+\\}";
        public const string TraitPattern = "#.+#";
    }
}
