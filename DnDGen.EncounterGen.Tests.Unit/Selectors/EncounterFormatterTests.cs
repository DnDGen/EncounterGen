﻿using DnDGen.EncounterGen.Selectors;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Unit.Selectors
{
    [TestFixture]
    public class EncounterFormatterTests
    {
        private IEncounterFormatter encounterFormatter;

        [SetUp]
        public void Setup()
        {
            encounterFormatter = new EncounterFormatter();
        }

        [Test]
        public void BuildCreature()
        {
            var creature = encounterFormatter.BuildCreature("creature name");
            Assert.That(creature, Is.EqualTo("creature name"));
        }

        [Test]
        public void BuildCreatureWithDescription()
        {
            var creature = encounterFormatter.BuildCreature("creature name", "description");
            Assert.That(creature, Is.EqualTo("creature name(description)"));
        }

        [Test]
        public void BuildCreatureWithSubtype()
        {
            var creature = encounterFormatter.BuildCreature("creature name", subcreature: "subtype");
            Assert.That(creature, Is.EqualTo("creature name$subtype$"));
        }

        [Test]
        public void BuildCreatureWithChallengeRating()
        {
            var creature = encounterFormatter.BuildCreature("creature name", challengeRating: "challenge rating");
            Assert.That(creature, Is.EqualTo("creature name[challenge rating]"));
        }

        [Test]
        public void BuildCreatureWithBaseRace()
        {
            var creature = encounterFormatter.BuildCreature("creature name", baseRace: "base race");
            Assert.That(creature, Is.EqualTo("creature name{base race}"));
        }

        [Test]
        public void BuildCreatureWithMetarace()
        {
            var creature = encounterFormatter.BuildCreature("creature name", metarace: "metarace");
            Assert.That(creature, Is.EqualTo("creature name#metarace#"));
        }

        [Test]
        public void BuildCreatureWithCharacterClass()
        {
            var creature = encounterFormatter.BuildCreature("creature name", characterClasses: new[] { "class" });
            Assert.That(creature, Is.EqualTo("creature name@class@"));
        }

        [Test]
        public void BuildCreatureWithCharacterClasses()
        {
            var creature = encounterFormatter.BuildCreature("creature name", characterClasses: new[] { "class", "other class" });
            Assert.That(creature, Is.EqualTo("creature name@class&other class@"));
        }

        [Test]
        public void BuildCreatureWithEverything()
        {
            var creature = encounterFormatter.BuildCreature("creature name", "description", "subtype", "challenge rating", "base race", "metarace", "class", "other class");
            Assert.That(creature, Is.EqualTo("creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@"));
        }

        [Test]
        public void SelectBaseRace()
        {
            var creature = "creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@";
            var baseRace = encounterFormatter.SelectBaseRaceFrom(creature);
            Assert.That(baseRace, Is.EqualTo("base race"));
        }

        [Test]
        public void SelectNoBaseRace()
        {
            var creature = "creature name(description)$subtype$[challenge rating]#metarace#@class&other class@";
            var baseRace = encounterFormatter.SelectBaseRaceFrom(creature);
            Assert.That(baseRace, Is.Empty);
        }

        [Test]
        public void SelectChallengeRating()
        {
            var creature = "creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@";
            var challengeRating = encounterFormatter.SelectChallengeRatingFrom(creature);
            Assert.That(challengeRating, Is.EqualTo("challenge rating"));
        }

        [Test]
        public void SelectNoChallengeRating()
        {
            var creature = "creature name(description)$subtype${base race}#metarace#@class&other class@";
            var challengeRating = encounterFormatter.SelectChallengeRatingFrom(creature);
            Assert.That(challengeRating, Is.Empty);
        }

        [Test]
        public void SelectCharacterClass()
        {
            var creature = "creature name(description)$subtype$[challenge rating]{base race}#metarace#@class@";
            var characterClasses = encounterFormatter.SelectCharacterClassesFrom(creature);
            Assert.That(characterClasses.Single(), Is.EqualTo("class"));
        }

        [Test]
        public void SelectCharacterClasses()
        {
            var creature = "creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@";
            var characterClasses = encounterFormatter.SelectCharacterClassesFrom(creature);
            Assert.That(characterClasses.First, Is.EqualTo("class"));
            Assert.That(characterClasses.Last, Is.EqualTo("other class"));
            Assert.That(characterClasses.Count, Is.EqualTo(2));
        }

        [Test]
        public void SelectNoCharacterClass()
        {
            var creature = "creature name(description)$subtype$[challenge rating]{base race}#metarace#";
            var characterClasses = encounterFormatter.SelectCharacterClassesFrom(creature);
            Assert.That(characterClasses, Is.Empty);
        }

        [Test]
        public void SelectDescription()
        {
            var creature = "creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@";
            var description = encounterFormatter.SelectDescriptionFrom(creature);
            Assert.That(description, Is.EqualTo("description"));
        }

        [Test]
        public void SelectNoDescription()
        {
            var creature = "creature name$subtype$[challenge rating]{base race}#metarace#@class&other class@";
            var description = encounterFormatter.SelectDescriptionFrom(creature);
            Assert.That(description, Is.Empty);
        }

        [Test]
        public void SelectMetarace()
        {
            var creature = "creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@";
            var metarace = encounterFormatter.SelectMetaraceFrom(creature);
            Assert.That(metarace, Is.EqualTo("metarace"));
        }

        [Test]
        public void SelectNoMetarace()
        {
            var creature = "creature name(description)$subtype$[challenge rating]{base race}@class&other class@";
            var metarace = encounterFormatter.SelectMetaraceFrom(creature);
            Assert.That(metarace, Is.Empty);
        }

        [Test]
        public void SelectName()
        {
            var creature = "creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@";
            var name = encounterFormatter.SelectNameFrom(creature);
            Assert.That(name, Is.EqualTo("creature name"));
        }

        [Test]
        public void SelectSubtype()
        {
            var creature = "creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@";
            var subtype = encounterFormatter.SelectSubCreatureFrom(creature);
            Assert.That(subtype, Is.EqualTo("subtype"));
        }

        [Test]
        public void SelectFurtherSubtype()
        {
            var creature = "creature name(description)$subtype$further subtype$$[challenge rating]{base race}#metarace#@class&other class@";
            var subtype = encounterFormatter.SelectSubCreatureFrom(creature);
            Assert.That(subtype, Is.EqualTo("subtype$further subtype$"));
        }

        [Test]
        public void SelectNoSubtype()
        {
            var creature = "creature name(description)[challenge rating]{base race}#metarace#@class&other class@";
            var subtype = encounterFormatter.SelectSubCreatureFrom(creature);
            Assert.That(subtype, Is.Empty);
        }

        [Test]
        public void SelectCreatureAndAmount_FromEncounterCreatures()
        {
            var encounterCreatures = new[] { "creature/amount" };

            var creaturesAndAmounts = encounterFormatter.SelectCreaturesAndAmountsFrom(encounterCreatures);
            Assert.That(creaturesAndAmounts["creature"], Is.EqualTo("amount"));
            Assert.That(creaturesAndAmounts.Count, Is.EqualTo(1));
        }

        [Test]
        public void SelectCreatureAndAmountWithEverything_FromEncounterCreatures()
        {
            var encounterCreatures = new[] { "creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@/amount" };

            var creaturesAndAmounts = encounterFormatter.SelectCreaturesAndAmountsFrom(encounterCreatures);
            Assert.That(creaturesAndAmounts["creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@"], Is.EqualTo("amount"));
            Assert.That(creaturesAndAmounts.Count, Is.EqualTo(1));
        }

        [Test]
        public void SelectCreaturesAndAmounts_FromEncounterCreatures()
        {
            var encounterCreatures = new[] { "creature/amount", "other creature/other amount" };

            var creaturesAndAmounts = encounterFormatter.SelectCreaturesAndAmountsFrom(encounterCreatures);
            Assert.That(creaturesAndAmounts["creature"], Is.EqualTo("amount"));
            Assert.That(creaturesAndAmounts["other creature"], Is.EqualTo("other amount"));
            Assert.That(creaturesAndAmounts.Count, Is.EqualTo(2));
        }

        [Test]
        public void SelectCreaturesAndAmountsWithEverything_FromEncounterCreatures()
        {
            var encounterCreatures = new[]
            {
                "creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@/amount",
                "other creature/other amount"
            };

            var creaturesAndAmounts = encounterFormatter.SelectCreaturesAndAmountsFrom(encounterCreatures);
            Assert.That(creaturesAndAmounts["creature name(description)$subtype$[challenge rating]{base race}#metarace#@class&other class@"], Is.EqualTo("amount"));
            Assert.That(creaturesAndAmounts["other creature"], Is.EqualTo("other amount"));
            Assert.That(creaturesAndAmounts.Count, Is.EqualTo(2));
        }
    }
}
