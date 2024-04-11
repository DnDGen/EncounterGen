namespace DnDGen.EncounterGen.Models
{
    public class Creature
    {
        public CreatureType Type { get; set; }
        public int Quantity { get; set; }
        public string ChallengeRating { get; set; }

        public Creature()
        {
            Type = new CreatureType();
            ChallengeRating = string.Empty;
        }
    }
}
