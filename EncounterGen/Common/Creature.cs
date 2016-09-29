namespace EncounterGen.Common
{
    public class Creature
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string ChallengeRating { get; set; }

        public Creature()
        {
            Name = string.Empty;
            Description = string.Empty;
            ChallengeRating = string.Empty;
        }
    }
}
