namespace DnDGen.EncounterGen.Models
{
    public class EncounterCreature
    {
        public Creature Creature { get; set; }
        public int Quantity { get; set; }
        public string ChallengeRating { get; set; }

        public EncounterCreature()
        {
            Creature = new Creature();
            ChallengeRating = string.Empty;
        }
    }
}
