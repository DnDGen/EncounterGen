namespace DnDGen.EncounterGen.Models
{
    public class Creature
    {
        public EncounterCreature Type { get; set; }
        public int Quantity { get; set; }
        public string ChallengeRating { get; set; }

        public Creature()
        {
            Type = new EncounterCreature();
            ChallengeRating = string.Empty;
        }
    }
}
