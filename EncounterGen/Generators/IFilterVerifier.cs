namespace EncounterGen.Generators
{
    public interface IFilterVerifier
    {
        bool FiltersAreValid(string environment, int level, params string[] creatureTypeFilters);
        bool CreatureIsValid(string creatureName, params string[] creatureTypeFilters);
    }
}
