namespace DnDGen.EncounterGen.Models
{
    public class EncounterCreature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public EncounterCreature SubCreature { get; set; }

        public EncounterCreature()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public static bool AreEqual(EncounterCreature source, EncounterCreature target)
        {
            if (source == null && target == null)
                return true;

            if (source == null ^ target == null)
                return false;

            var areEqual = source.Name == target.Name;
            areEqual &= source.Description == target.Description;
            areEqual &= AreEqual(source.SubCreature, target.SubCreature);

            return areEqual;
        }
    }
}
