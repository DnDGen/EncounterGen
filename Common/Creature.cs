namespace EncounterGen.Common
{
    public class Creature
    {
        public string Type { get; set; }
        public string Subtype { get; set; }
        public int Quantity { get; set; }

        public Creature()
        {
            Type = string.Empty;
            Subtype = string.Empty;
        }
    }
}
