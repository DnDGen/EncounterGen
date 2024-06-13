namespace DnDGen.EncounterGen.Models
{
    public class Creature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Creature SubCreature { get; set; }

        public Creature()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public static bool AreEqual(Creature source, Creature target)
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
