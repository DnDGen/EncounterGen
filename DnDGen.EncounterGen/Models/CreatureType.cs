namespace DnDGen.EncounterGen.Models
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

        public static bool AreEqual(CreatureType source, CreatureType target)
        {
            if (source == null && target == null)
                return true;

            if (source == null ^ target == null)
                return false;

            var areEqual = source.Name == target.Name;
            areEqual &= source.Description == target.Description;
            areEqual &= AreEqual(source.SubType, target.SubType);

            return areEqual;
        }
    }
}
