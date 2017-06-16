using CharacterGen.Characters;
using CharacterGen.Randomizers.Abilities;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using EncounterGen.Common;
using EncounterGen.Domain.Generators.Factories;
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
        private readonly ICollectionSelector collectionSelector;
        private readonly Dice dice;
        private readonly IEncounterSelector encounterSelector;
        private readonly JustInTimeFactory justInTimeFactory;

        public EncounterCharacterGenerator(ICollectionSelector collectionSelector, Dice dice, IEncounterSelector encounterSelector, JustInTimeFactory justInTimeFactory)
        {
            this.collectionSelector = collectionSelector;
            this.dice = dice;
            this.encounterSelector = encounterSelector;
            this.justInTimeFactory = justInTimeFactory;
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

            var setBaseRace = encounterSelector.SelectBaseRaceFrom(characterTemplate);
            var setMetarace = encounterSelector.SelectMetaraceFrom(characterTemplate);
            var setLevel = GetCharacterLevel(characterTemplate);
            var setClassName = string.Empty;

            var classes = encounterSelector.SelectCharacterClassesFrom(characterTemplate);

            if (classes.Any())
                setClassName = collectionSelector.SelectRandomFrom(classes);

            return GenerateCharacter(setLevel, setBaseRace, setMetarace, setClassName);
        }

        private Character GenerateCharacter(int setLevel, string setBaseRace = "", string setMetarace = "", string setClass = "")
        {
            var chosenClassNameRandomizer = justInTimeFactory.Build<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyPlayer);
            var chosenBaseRaceRandomizer = justInTimeFactory.Build<RaceRandomizer>(RaceRandomizerTypeConstants.BaseRace.AnyBase);
            var chosenMetaraceRandomizer = justInTimeFactory.Build<RaceRandomizer>(RaceRandomizerTypeConstants.Metarace.AnyMeta);
            var setLevelRandomizer = justInTimeFactory.Build<ISetLevelRandomizer>();

            if (setClass == ClassNameRandomizerTypeConstants.AnyNPC)
            {
                chosenClassNameRandomizer = justInTimeFactory.Build<IClassNameRandomizer>(setClass);
            }
            else if (!string.IsNullOrEmpty(setClass))
            {
                var setClassNameRandomizer = justInTimeFactory.Build<ISetClassNameRandomizer>();
                setClassNameRandomizer.SetClassName = setClass;
                chosenClassNameRandomizer = setClassNameRandomizer;
            }

            if (!string.IsNullOrEmpty(setBaseRace))
            {
                var setBaseRaceRandomizer = justInTimeFactory.Build<ISetBaseRaceRandomizer>();
                setBaseRaceRandomizer.SetBaseRace = setBaseRace;
                chosenBaseRaceRandomizer = setBaseRaceRandomizer;
            }

            if (!string.IsNullOrEmpty(setMetarace))
            {
                var setMetaraceRandomizer = justInTimeFactory.Build<ISetMetaraceRandomizer>();
                setMetaraceRandomizer.SetMetarace = setMetarace;
                chosenMetaraceRandomizer = setMetaraceRandomizer;
            }

            setLevelRandomizer.SetLevel = setLevel;
            setLevelRandomizer.AllowAdjustments = string.IsNullOrEmpty(setBaseRace) && string.IsNullOrEmpty(setMetarace);

            var alignmentRandomizer = justInTimeFactory.Build<IAlignmentRandomizer>(AlignmentRandomizerTypeConstants.Any);
            var characterGenerator = justInTimeFactory.Build<ICharacterGenerator>();
            var abilitiesRandomizer = justInTimeFactory.Build<IAbilitiesRandomizer>(AbilitiesRandomizerTypeConstants.Raw);

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
