using System;

namespace EncounterGen.Common
{
    public class Creature
    {
        public String Name { get; set; }
        public String ChallengeRating { get; set; }

        public Creature()
        {
            Name = String.Empty;
            ChallengeRating = String.Empty;
        }
    }
}
