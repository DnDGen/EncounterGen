namespace EncounterGen.Domain.Selectors
{
    internal static class RegexConstants
    {
        public const string IsMagicPattern = "@.+@";
        public const string ItemBonusPattern = "\\(\\d+\\)";
        public const string ItemTypePattern = "\\[.+\\]";
        public const string SpecialAbilitiesPattern = "\\{.+\\}";
        public const string SpecialAbilitiesBonusPattern = "\\$\\d+\\$";
        public const string TraitPattern = "#.+#";
    }
}
