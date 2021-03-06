﻿using CharacterGen.Characters;
using CharacterGen.Randomizers.Abilities;
using CharacterGen.Randomizers.Alignments;
using CharacterGen.Randomizers.CharacterClasses;
using CharacterGen.Randomizers.Races;
using DnDGen.Core.Generators;
using DnDGen.Core.Selectors.Collections;
using EncounterGen.Common;
using EncounterGen.Domain.Selectors;
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
        private readonly IEncounterFormatter encounterFormatter;
        private readonly JustInTimeFactory justInTimeFactory;
        private readonly ICharacterGenerator characterGenerator;

        public EncounterCharacterGenerator(ICollectionSelector collectionSelector, Dice dice, IEncounterFormatter encounterFormatter, JustInTimeFactory justInTimeFactory, ICharacterGenerator characterGenerator)
        {
            this.collectionSelector = collectionSelector;
            this.dice = dice;
            this.encounterFormatter = encounterFormatter;
            this.justInTimeFactory = justInTimeFactory;
            this.characterGenerator = characterGenerator;
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
            var name = encounterFormatter.SelectNameFrom(creature);
            return name == CreatureConstants.Character;
        }

        private Character GenerateCharacter(Creature creature)
        {
            var characterTemplate = GetCharacterTemplate(creature.Type);

            var setBaseRace = encounterFormatter.SelectBaseRaceFrom(characterTemplate);
            var setMetarace = encounterFormatter.SelectMetaraceFrom(characterTemplate);
            var setLevel = GetCharacterLevel(characterTemplate);
            var setClassName = string.Empty;

            var classes = encounterFormatter.SelectCharacterClassesFrom(characterTemplate);

            if (classes.Any())
                setClassName = collectionSelector.SelectRandomFrom(classes);

            return GenerateCharacter(setLevel, setBaseRace, setMetarace, setClassName);
        }

        private Character GenerateCharacter(int setLevel, string setBaseRace = "", string setMetarace = "", string setClass = "")
        {
            var chosenClassNameRandomizer = justInTimeFactory.Build<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyPlayer);
            var chosenBaseRaceRandomizer = justInTimeFactory.Build<RaceRandomizer>(RaceRandomizerTypeConstants.BaseRace.AnyBase);
            var chosenMetaraceRandomizer = justInTimeFactory.Build<RaceRandomizer>(RaceRandomizerTypeConstants.Metarace.AnyMeta);

            if (setClass == ClassNameRandomizerTypeConstants.AnyNPC)
            {
                chosenClassNameRandomizer = justInTimeFactory.Build<IClassNameRandomizer>(ClassNameRandomizerTypeConstants.AnyNPC);
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

            var alignmentRandomizer = justInTimeFactory.Build<IAlignmentRandomizer>(AlignmentRandomizerTypeConstants.Any);
            var abilitiesRandomizer = justInTimeFactory.Build<IAbilitiesRandomizer>(AbilitiesRandomizerTypeConstants.Raw);
            var setLevelRandomizer = justInTimeFactory.Build<ISetLevelRandomizer>();

            setLevelRandomizer.SetLevel = setLevel;

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
            var challengeRatingRoll = encounterFormatter.SelectChallengeRatingFrom(characterTemplate);

            if (string.IsNullOrEmpty(challengeRatingRoll))
                throw new ArgumentException($"Character level was not provided for a character {characterTemplate}");

            return dice.Roll(challengeRatingRoll).AsSum();
        }
    }
}
