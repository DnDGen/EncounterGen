using DnDGen.CharacterGen.Characters;
using DnDGen.CharacterGen.Generators.Characters;
using DnDGen.CharacterGen.Randomizers.Abilities;
using DnDGen.CharacterGen.Randomizers.Alignments;
using DnDGen.CharacterGen.Randomizers.CharacterClasses;
using DnDGen.CharacterGen.Randomizers.Races;
using DnDGen.EncounterGen.Models;
using DnDGen.EncounterGen.Selectors;
using DnDGen.Infrastructure.Generators;
using DnDGen.Infrastructure.Selectors.Collections;
using DnDGen.RollGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Generators
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

        public IEnumerable<Character> GenerateFrom(IEnumerable<EncounterCreature> creatures)
        {
            var characters = new List<Character>();
            var characterCreatures = creatures.Where(c => IsCharacter(c.Creature));

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

        private bool IsCharacter(Creature creature)
        {
            if (IsCharacter(creature.Name))
                return true;

            if (creature.SubCreature != null)
                return IsCharacter(creature.SubCreature);

            return false;
        }

        private bool IsCharacter(string creature)
        {
            var name = encounterFormatter.SelectNameFrom(creature);
            return name == CreatureDataConstants.Character;
        }

        private Character GenerateCharacter(EncounterCreature creature)
        {
            var characterTemplate = GetCharacterTemplate(creature.Creature);

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

        private string GetCharacterTemplate(Creature creature)
        {
            if (IsCharacter(creature.Name))
                return creature.Name;

            if (creature.SubCreature != null)
                return GetCharacterTemplate(creature.SubCreature);

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
