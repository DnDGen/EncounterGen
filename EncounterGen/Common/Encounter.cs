using CharacterGen.Characters;
using System.Collections.Generic;
using System.Linq;
using TreasureGen;

namespace EncounterGen.Common
{
    public class Encounter
    {
        public IEnumerable<Creature> Creatures { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Treasure> Treasures { get; set; }
        public int TargetEncounterLevel { get; set; }
        public int AverageEncounterLevel { get; set; }
        public int ActualEncounterLevel { get; set; }

        public string AverageDifficulty
        {
            get { return GetDifficulty(AverageEncounterLevel); }
        }
        public string ActualDifficulty
        {
            get { return GetDifficulty(ActualEncounterLevel); }
        }

        public Encounter()
        {
            Creatures = Enumerable.Empty<Creature>();
            Characters = Enumerable.Empty<Character>();
            Treasures = Enumerable.Empty<Treasure>();
        }

        private string GetDifficulty(int encounterLevel)
        {
            var difference = encounterLevel - TargetEncounterLevel;

            if (difference < -4)
                return DifficultyConstants.VeryEasy;

            if (difference < 0)
                return DifficultyConstants.Easy;

            if (difference == 0)
                return DifficultyConstants.Challenging;

            if (difference < 5)
                return DifficultyConstants.VeryDifficult;

            return DifficultyConstants.Overpowering;
        }
    }
}
