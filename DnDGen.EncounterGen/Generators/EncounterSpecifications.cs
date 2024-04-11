using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Generators
{
    public class EncounterSpecifications
    {
        public const int MinimumLevel = 1;
        public const int MaximumLevel = 30;

        public string Environment { get; set; }
        public int Level { get; set; }
        public string TimeOfDay { get; set; }
        public string Temperature { get; set; }
        public bool AllowAquatic { get; set; }
        public bool AllowUnderground { get; set; }
        public IEnumerable<string> CreatureTypeFilters { get; set; }

        public string SpecificEnvironment
        {
            get { return Temperature + Environment; }
        }

        public string Description
        {
            get
            {
                var description = $"Level {Level} {Temperature} {Environment} {TimeOfDay}";

                if (AllowAquatic)
                    description += $", allowing aquatic";

                if (AllowUnderground)
                    description += $", allowing underground";

                if (CreatureTypeFilters.Any())
                    description += $", allowing [{string.Join(", ", CreatureTypeFilters)}]";

                return description;
            }
        }

        public EncounterSpecifications()
        {
            Environment = string.Empty;
            TimeOfDay = string.Empty;
            Temperature = string.Empty;
            CreatureTypeFilters = Enumerable.Empty<string>();
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Environment)
                && !string.IsNullOrEmpty(TimeOfDay)
                && !string.IsNullOrEmpty(Temperature)
                && LevelIsValid(Level)
                && CreatureTypeFilters != null;
        }

        public static bool LevelIsValid(int level)
        {
            return level >= MinimumLevel && level <= MaximumLevel;
        }

        public EncounterSpecifications Clone()
        {
            var clone = new EncounterSpecifications();
            clone.AllowAquatic = AllowAquatic;
            clone.AllowUnderground = AllowUnderground;
            clone.CreatureTypeFilters = CreatureTypeFilters.ToArray();
            clone.Environment = Environment;
            clone.Level = Level;
            clone.Temperature = Temperature;
            clone.TimeOfDay = TimeOfDay;

            return clone;
        }
    }
}
