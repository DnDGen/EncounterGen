using CharacterGen;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using CharacterGen.Randomizers.Stats;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Tables;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace EncounterGen.Domain.Generators
{
    internal class EncounterCharacterGenerator : IEncounterCharacterGenerator
    {
        private ICharacterGenerator characterGenerator;
        private IAlignmentRandomizer alignmentRandomizer;
        private IClassNameRandomizer anyPlayerClassNameRandomizer;
        private IClassNameRandomizer anyNPCClassNameRandomizer;
        private ISetClassNameRandomizer setClassNameRandomizer;
        private ISetLevelRandomizer setLevelRandomizer;
        private RaceRandomizer baseRaceRandomizer;
        private RaceRandomizer metaraceRandomizer;
        private IStatsRandomizer statsRandomizer;
        private ICollectionSelector collectionSelector;
        private ISetMetaraceRandomizer setMetaraceRandomizer;
        private Regex challengeRatingRegex;
        private Regex setCharacterLevelRegex;
        private Regex subTypeRegex;
        private Dice dice;

        public EncounterCharacterGenerator(ICharacterGenerator characterGenerator, IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer anyPlayerClassNameRandomizer,
            ISetLevelRandomizer setLevelRandomizer, RaceRandomizer baseRaceRandomizer, RaceRandomizer metaraceRandomizer, IStatsRandomizer statsRandomizer,
            ICollectionSelector collectionSelector, ISetMetaraceRandomizer setMetaraceRandomizer, IClassNameRandomizer anyNPCClassNameRandomizer,
            ISetClassNameRandomizer setClassNameRandomizer, Dice dice)
        {
            this.characterGenerator = characterGenerator;
            this.alignmentRandomizer = alignmentRandomizer;
            this.anyPlayerClassNameRandomizer = anyPlayerClassNameRandomizer;
            this.setLevelRandomizer = setLevelRandomizer;
            this.baseRaceRandomizer = baseRaceRandomizer;
            this.metaraceRandomizer = metaraceRandomizer;
            this.statsRandomizer = statsRandomizer;
            this.collectionSelector = collectionSelector;
            this.setMetaraceRandomizer = setMetaraceRandomizer;
            this.anyNPCClassNameRandomizer = anyNPCClassNameRandomizer;
            this.setClassNameRandomizer = setClassNameRandomizer;
            this.dice = dice;

            challengeRatingRegex = new Regex(RegexConstants.ChallengeRatingPattern);
            setCharacterLevelRegex = new Regex(RegexConstants.SetCharacterLevelPattern);
            subTypeRegex = new Regex(RegexConstants.SubTypePattern);
        }

        public IEnumerable<Character> GenerateFrom(IEnumerable<Creature> creatures)
        {
            var characters = new List<Character>();
            var characterCreatures = creatures.Where(c => IsCharacterCreatureType(c.Name) || IsCharacterCreatureType(c.Description));

            foreach (var characterCreature in characterCreatures)
            {
                var characterQuantity = characterCreature.Quantity;

                while (characterQuantity-- > 0)
                {
                    var character = GenerateCharacter(characterCreature);
                    characters.Add(character);
                }
            }

            return characters;
        }

        private bool IsCharacterCreatureType(string fullCreatureType)
        {
            var characterCreatureType = GetCreatureTypeCharacter(fullCreatureType);

            return string.IsNullOrEmpty(characterCreatureType) == false;
        }

        private Character GenerateCharacter(Creature creature)
        {
            var characterCreatureType = GetCharacterCreatureType(creature);

            setLevelRandomizer.SetLevel = GetCharacterLevel(creature.Name);
            setLevelRandomizer.AllowAdjustments = true;

            var undeadNPCCreatures = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UndeadNPC);
            if (undeadNPCCreatures.Contains(characterCreatureType))
            {
                setMetaraceRandomizer.SetMetarace = characterCreatureType;
                setLevelRandomizer.AllowAdjustments = false;

                return characterGenerator.GenerateWith(alignmentRandomizer, anyPlayerClassNameRandomizer, setLevelRandomizer, baseRaceRandomizer, setMetaraceRandomizer, statsRandomizer);
            }

            if (characterCreatureType == CreatureConstants.Character)
                return characterGenerator.GenerateWith(alignmentRandomizer, anyPlayerClassNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer);

            if (characterCreatureType == CreatureConstants.NPC)
                return characterGenerator.GenerateWith(alignmentRandomizer, anyNPCClassNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer);

            setClassNameRandomizer.SetClassName = characterCreatureType;
            return characterGenerator.GenerateWith(alignmentRandomizer, setClassNameRandomizer, setLevelRandomizer, baseRaceRandomizer, metaraceRandomizer, statsRandomizer);
        }

        private string GetCharacterCreatureType(Creature creature)
        {
            var creatureType = GetCreatureTypeCharacter(creature.Name);

            if (string.IsNullOrEmpty(creatureType))
                return GetCreatureTypeCharacter(creature.Description);

            return creatureType;
        }

        private string GetCreatureTypeCharacter(string fullCreatureType)
        {
            var creatureType = GetCreatureType(fullCreatureType);

            var undeadNPCCreatures = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, GroupConstants.UndeadNPC);
            if (undeadNPCCreatures.Contains(creatureType))
                return creatureType;

            var classes = collectionSelector.SelectFrom(TableNameConstants.CreatureGroups, CreatureConstants.Character);
            if (classes.Contains(creatureType))
                return creatureType;

            return string.Empty;
        }

        private string GetCreatureType(string fullCreatureType)
        {
            var creatureType = subTypeRegex.Replace(fullCreatureType, string.Empty);
            creatureType = challengeRatingRegex.Replace(creatureType, string.Empty);

            return creatureType;
        }

        private int GetCharacterLevel(string characterCreatureType)
        {
            var challengeRating = GetSetChallengeRating(characterCreatureType);
            if (string.IsNullOrEmpty(challengeRating))
            {
                var message = string.Format("Character level was not provided for a character creature type \"{0}\"", characterCreatureType);
                throw new ArgumentException(message);
            }

            return dice.Roll(challengeRating);
        }

        private string GetSetChallengeRating(string creatureType)
        {
            var levelMatch = challengeRatingRegex.Match(creatureType);
            if (string.IsNullOrEmpty(levelMatch.Value))
                return string.Empty;

            return levelMatch.Value.Substring(1, levelMatch.Value.Length - 2);
        }
    }
}
