namespace EncounterGen.Common
{
    public class CreatureType
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public CreatureType SubType { get; set; }

        public CreatureType()
        {
            Name = string.Empty;
            Description = string.Empty;
        }
    }
}
