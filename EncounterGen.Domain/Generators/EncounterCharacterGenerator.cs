using CharacterGen.Characters;
using CharacterGen.Randomizers.Abilities;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Collections;
using RollGen;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private RaceRandomizer anyBaseRaceRandomizer;
        private RaceRandomizer anyMetaraceRandomizer;
        private IAbilitiesRandomizer abilitiesRandomizer;
        private ICollectionSelector collectionSelector;
        private ISetMetaraceRandomizer setMetaraceRandomizer;
        private ISetBaseRaceRandomizer setBaseRaceRandomizer;
        private Dice dice;
        private IEncounterSelector encounterSelector;

        public EncounterCharacterGenerator(ICharacterGenerator characterGenerator, IAlignmentRandomizer alignmentRandomizer, IClassNameRandomizer anyPlayerClassNameRandomizer,
            ISetLevelRandomizer setLevelRandomizer, RaceRandomizer anyBaseRaceRandomizer, RaceRandomizer anyMetaraceRandomizer, IAbilitiesRandomizer abilitiesRandomizer,
            ICollectionSelector collectionSelector, ISetMetaraceRandomizer setMetaraceRandomizer, IClassNameRandomizer anyNPCClassNameRandomizer,
            ISetClassNameRandomizer setClassNameRandomizer, Dice dice, IEncounterSelector encounterSelector, ISetBaseRaceRandomizer setBaseRaceRandomizer)
        {
            this.characterGenerator = characterGenerator;
            this.alignmentRandomizer = alignmentRandomizer;
            this.anyPlayerClassNameRandomizer = anyPlayerClassNameRandomizer;
            this.setLevelRandomizer = setLevelRandomizer;
            this.anyBaseRaceRandomizer = anyBaseRaceRandomizer;
            this.anyMetaraceRandomizer = anyMetaraceRandomizer;
            this.abilitiesRandomizer = abilitiesRandomizer;
            this.collectionSelector = collectionSelector;
            this.setMetaraceRandomizer = setMetaraceRandomizer;
            this.anyNPCClassNameRandomizer = anyNPCClassNameRandomizer;
            this.setClassNameRandomizer = setClassNameRandomizer;
            this.dice = dice;
            this.encounterSelector = encounterSelector;
            this.setBaseRaceRandomizer = setBaseRaceRandomizer;
        }

        public IEnumerable<Character> GenerateFrom(IEnumerable<Creature> creatures)
        {
            var characters = new List<Character>();
            var characterCreatures = creatures.Where(c => IsCharacter(c.Type));

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

        private bool IsCharacter(CreatureType creatureType)
        {
            if (IsCharacter(creatureType.Name))
                return true;

            if (creatureType.SubType != null)
                return IsCharacter(creatureType.SubType);

            return false;
        }

        private bool IsCharacter(string creature)
        {
            var name = encounterSelector.SelectNameFrom(creature);
            return name == CreatureConstants.Character;
        }

        private Character GenerateCharacter(Creature creature)
        {
            var characterTemplate = GetCharacterTemplate(creature.Type);

            setBaseRaceRandomizer.SetBaseRace = encounterSelector.SelectBaseRaceFrom(characterTemplate);
            setMetaraceRandomizer.SetMetarace = encounterSelector.SelectMetaraceFrom(characterTemplate);
            setLevelRandomizer.SetLevel = GetCharacterLevel(characterTemplate);
            setLevelRandomizer.AllowAdjustments = string.IsNullOrEmpty(setBaseRaceRandomizer.SetBaseRace) && string.IsNullOrEmpty(setMetaraceRandomizer.SetMetarace);

            var classes = encounterSelector.SelectCharacterClassesFrom(characterTemplate);

            if (classes.Any())
                setClassNameRandomizer.SetClassName = collectionSelector.SelectRandomFrom(classes);
            else
                setClassNameRandomizer.SetClassName = string.Empty;

            return GenerateCharacter();
        }

        private Character GenerateCharacter()
        {
            var chosenClassNameRandomizer = anyPlayerClassNameRandomizer;
            var chosenBaseRaceRandomizer = anyBaseRaceRandomizer;
            var chosenMetaraceRandomizer = anyMetaraceRandomizer;

            if (!string.IsNullOrEmpty(setClassNameRandomizer.SetClassName))
                chosenClassNameRandomizer = setClassNameRandomizer;

            if (setClassNameRandomizer.SetClassName == ClassNameRandomizerTypeConstants.AnyNPC)
                chosenClassNameRandomizer = anyNPCClassNameRandomizer;

            if (!string.IsNullOrEmpty(setBaseRaceRandomizer.SetBaseRace))
                chosenBaseRaceRandomizer = setBaseRaceRandomizer;

            if (!string.IsNullOrEmpty(setMetaraceRandomizer.SetMetarace))
                chosenMetaraceRandomizer = setMetaraceRandomizer;

            return characterGenerator.GenerateWith(alignmentRandomizer, chosenClassNameRandomizer, setLevelRandomizer, chosenBaseRaceRandomizer, chosenMetaraceRandomizer, abilitiesRandomizer);
        }

        private string GetCharacterTemplate(CreatureType creaturetype)
        {
            if (IsCharacter(creaturetype.Name))
                return creaturetype.Name;

            if (creaturetype.SubType != null)
                return GetCharacterTemplate(creaturetype.SubType);

            return string.Empty;
        }

        private int GetCharacterLevel(string characterTemplate)
        {
            var challengeRating = encounterSelector.SelectChallengeRatingFrom(characterTemplate);

            if (string.IsNullOrEmpty(challengeRating))
                throw new ArgumentException($"Character level was not provided for a character {characterTemplate}");

            return dice.Roll(challengeRating).AsSum();
        }
    }
}
