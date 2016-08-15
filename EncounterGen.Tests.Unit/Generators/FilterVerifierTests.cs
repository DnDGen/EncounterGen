using EncounterGen.Domain.Generators;
using EncounterGen.Domain.Selectors;
using EncounterGen.Domain.Selectors.Percentiles;
using EncounterGen.Domain.Tables;
using EncounterGen.Generators;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class FilterVerifierTests
    {
        private const int Level = 9266;
        private const string Environment = "environment";
        private const string Temperature = "temperature";
        private const string TimeOfDay = "time of day";
        private const string Filter = "filter";

        private IFilterVerifier filterVerifier;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private Mock<IEncounterCollectionSelector> mockCreatureCollectionSelector;
        private Mock<IRollSelector> mockRollSelector;
        private List<string> filterGroup;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCollectionSelector = new Mock<ICollectionSelector>();
            mockCreatureCollectionSelector = new Mock<IEncounterCollectionSelector>();
            mockRollSelector = new Mock<IRollSelector>();
            filterVerifier = new FilterVerifier(mockTypeAndAmountPercentileSelector.Object, mockCollectionSelector.Object, mockCreatureCollectionSelector.Object, mockRollSelector.Object);

            var levelsAndAmounts = new List<Dictionary<string, string>>();
            levelsAndAmounts.Add(new Dictionary<string, string>());
            levelsAndAmounts.Add(new Dictionary<string, string>());
            levelsAndAmounts.Add(new Dictionary<string, string>());

            levelsAndAmounts[0]["9265"] = ModifierConstants.TwoThirds.ToString();
            levelsAndAmounts[1]["9266"] = ModifierConstants.Same.ToString();
            levelsAndAmounts[2]["9267"] = ModifierConstants.Double.ToString();

            var tableName = string.Format(TableNameConstants.LevelXEncounterLevel, Level);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(levelsAndAmounts);

            filterGroup = new List<string>();
            filterGroup.Add("creature");
            filterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, Filter)).Returns(filterGroup);
        }

        [Test]
        public void NoFiltersIsAlwaysValid()
        {
            var isValid = filterVerifier.FiltersAreValid("bogus environment", 90210, "bogus temperature", "bogus time of day");
            Assert.That(isValid, Is.True);
        }

        [TestCase(Level - 1)]
        [TestCase(Level)]
        [TestCase(Level + 1)]
        public void FilterIsValidIfMatchWithinRangeOfLevels(int passingLevel)
        {
            SetupCreaturesAndAmounts(Level - 2, passingLevel);
            SetupCreaturesAndAmounts(Level - 1, passingLevel);
            SetupCreaturesAndAmounts(Level, passingLevel);
            SetupCreaturesAndAmounts(Level + 1, passingLevel);
            SetupCreaturesAndAmounts(Level + 2, passingLevel);

            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.True);
        }

        private void SetupCreaturesAndAmounts(int setupLevel, int passingLevel, string creatureName = "creature", params string[] additionalCreaturesAndAmounts)
        {
            var encounterWithSome = SetUpEncounter("wrong creature", "some", "other wrong creature", "some");
            var encounterWithATon = SetUpEncounter("wrong creature", "a ton", "other wrong creature", "a ton");
            var encounterWithBarelyAny = SetUpEncounter("wrong creature", "barely any", "other wrong creature", "barely any");

            if (setupLevel == passingLevel)
            {
                encounterWithBarelyAny[creatureName] = "just the right amount";

                for (var i = 0; i < additionalCreaturesAndAmounts.Length; i += 2)
                {
                    encounterWithBarelyAny[additionalCreaturesAndAmounts[i]] = additionalCreaturesAndAmounts[i + 1];
                }
            }

            var creaturesAndAmounts = new List<Dictionary<string, string>>();
            creaturesAndAmounts.Add(encounterWithSome);
            creaturesAndAmounts.Add(encounterWithATon);
            creaturesAndAmounts.Add(encounterWithBarelyAny);

            mockCreatureCollectionSelector.Setup(s => s.SelectAllFrom(setupLevel, Environment, Temperature, TimeOfDay)).Returns(creaturesAndAmounts);
        }

        private Dictionary<string, string> SetUpEncounter(params string[] creaturesAndAmounts)
        {
            var encounter = new Dictionary<string, string>();

            for (var i = 0; i < creaturesAndAmounts.Length; i += 2)
                encounter[creaturesAndAmounts[i]] = creaturesAndAmounts[i + 1];

            return encounter;
        }

        [TestCase(Level - 2)]
        [TestCase(Level + 2)]
        public void FilterIsNotValidIfMatchOutsideRangeOfLevels(int passingLevel)
        {
            SetupCreaturesAndAmounts(Level - 2, passingLevel);
            SetupCreaturesAndAmounts(Level - 1, passingLevel);
            SetupCreaturesAndAmounts(Level, passingLevel);
            SetupCreaturesAndAmounts(Level + 1, passingLevel);
            SetupCreaturesAndAmounts(Level + 2, passingLevel);

            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.False);
        }

        [TestCase(9265)]
        [TestCase(9266)]
        [TestCase(9267)]
        public void FiltersAreValidIfAnyFilterMatchesWithinRangeOfLevels(int passingLevel)
        {
            SetupCreaturesAndAmounts(Level - 2, passingLevel);
            SetupCreaturesAndAmounts(Level - 1, passingLevel);
            SetupCreaturesAndAmounts(Level, passingLevel);
            SetupCreaturesAndAmounts(Level + 1, passingLevel);
            SetupCreaturesAndAmounts(Level + 2, passingLevel);

            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "additional filter")).Returns(additionalFilterGroup);

            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter, "additional filter");
            Assert.That(isValid, Is.True);
        }

        [TestCase(9261)]
        [TestCase(9271)]
        public void FiltersAreNotValidIfMatchOutsideRangeOfLevels(int passingLevel)
        {
            SetupCreaturesAndAmounts(Level - 2, passingLevel);
            SetupCreaturesAndAmounts(Level - 1, passingLevel);
            SetupCreaturesAndAmounts(Level, passingLevel);
            SetupCreaturesAndAmounts(Level + 1, passingLevel);
            SetupCreaturesAndAmounts(Level + 2, passingLevel);

            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "additional filter")).Returns(additionalFilterGroup);

            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter, "additional filter");
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void FiltersAreValidIfAnyCreatureInEncounterMatchesFilter()
        {
            SetupCreaturesAndAmounts(Level, Level, "first creature", "second creature", "second amount");
            filterGroup.Add("second creature");
            mockRollSelector.Setup(s => s.SelectFrom("second amount", ModifierConstants.Same)).Returns("some roll");

            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void FiltersAreNotValidIfAnyCreatureInEncounterMustReroll()
        {
            SetupCreaturesAndAmounts(Level, Level, "first creature", "second creature", "second amount");
            filterGroup.Add("second creature");
            mockRollSelector.Setup(s => s.SelectFrom("second amount", ModifierConstants.Same)).Returns(RollConstants.Reroll);

            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void FiltersAreValidIfCreatureWithDescriptionMatches()
        {
            SetupCreaturesAndAmounts(Level, Level, "creature (description)");
            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void FiltersAreValidIfCreatureWithLevelMatches()
        {
            SetupCreaturesAndAmounts(Level, Level, "creature[600]");
            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void FiltersAreValidIfCreatureWithDescriptionAndLevelMatches()
        {
            SetupCreaturesAndAmounts(Level, Level, "creature (description)[600]");
            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void FiltersAreNotValidIfModifiedRollIsReroll()
        {
            SetupCreaturesAndAmounts(Level, Level);
            mockRollSelector.Setup(s => s.SelectFrom("just the right amount", ModifierConstants.Same)).Returns(RollConstants.Reroll);

            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void FiltersAreValidIfModifiedRollIsNotReroll()
        {
            SetupCreaturesAndAmounts(Level, Level);
            mockRollSelector.Setup(s => s.SelectFrom("just the right amount", ModifierConstants.Same)).Returns("some other roll");

            var isValid = filterVerifier.FiltersAreValid(Environment, Level, Temperature, TimeOfDay, Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterIsValidIfNoFiltersAreProvidedAndNoReroll()
        {
            var encounter = SetUpEncounter("creature", "amount");
            mockRollSelector.Setup(s => s.SelectFrom("amount", 90210)).Returns("some other roll");

            var isValid = filterVerifier.EncounterIsValid(encounter, 90210);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void EncounterIsNotValidIfNoFiltersAreProvidedAndReroll()
        {
            var encounter = SetUpEncounter("creature", "amount");
            mockRollSelector.Setup(s => s.SelectFrom("amount", 90210)).Returns(RollConstants.Reroll);

            var isValid = filterVerifier.EncounterIsValid(encounter, 90210);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterIsNotValidIfCreatureMatchesFilter()
        {
            var encounter = SetUpEncounter("bogus creature", "amount");
            mockRollSelector.Setup(s => s.SelectFrom("amount", 90210)).Returns("some other roll");

            var isValid = filterVerifier.EncounterIsValid(encounter, 90210, Filter);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterIsNotValidIfCreatureMatchesAnyFilter()
        {
            var encounter = SetUpEncounter("bogus creature", "amount");
            mockRollSelector.Setup(s => s.SelectFrom("amount", 90210)).Returns("some other roll");

            var isValid = filterVerifier.EncounterIsValid(encounter, 90210, Filter, "other filter");
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterIsNotValidIfAnyCreatureRequiresReroll()
        {
            var encounter = SetUpEncounter("creature", "amount");
            mockRollSelector.Setup(s => s.SelectFrom("amount", 90210)).Returns(RollConstants.Reroll);

            var isValid = filterVerifier.EncounterIsValid(encounter, 90210, Filter, "other filter");
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void EncounterIsValid()
        {
            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "other filter")).Returns(additionalFilterGroup);

            var encounter = SetUpEncounter("creature", "amount");
            mockRollSelector.Setup(s => s.SelectFrom("amount", ModifierConstants.Same)).Returns("some other roll");

            var isValid = filterVerifier.EncounterIsValid(encounter, 90210, Filter, "other filter");
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void NoFiltersForCreatureIsAlwaysValid()
        {
            var isValid = filterVerifier.CreatureIsValid("bogus creature");
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfNoFiltersAreProvided()
        {
            var isValid = filterVerifier.CreatureIsValid("bogus creature");
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfWithinFilterGroup()
        {
            var isValid = filterVerifier.CreatureIsValid("creature", Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsNotValidIfOutsideFilterGroup()
        {
            var isValid = filterVerifier.CreatureIsValid("wrong creature", Filter);
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void CreatureIsValidIfAnyFilterMatches()
        {
            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "additional filter")).Returns(additionalFilterGroup);

            var isValid = filterVerifier.CreatureIsValid("creature", Filter, "additional filter");
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsNotValidIfNoFilterMatches()
        {
            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "additional filter")).Returns(additionalFilterGroup);

            var isValid = filterVerifier.CreatureIsValid("wrong creature", Filter, "additional filter");
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void CreatureIsValidIfCreatureWithDescriptionMatches()
        {
            var isValid = filterVerifier.CreatureIsValid("creature (description)", Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfCreatureWithLevelMatches()
        {
            var isValid = filterVerifier.CreatureIsValid("creature[600]", Filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfCreatureWithDescriptionAndLevelMatches()
        {
            var isValid = filterVerifier.CreatureIsValid("creature (description)[600]", Filter);
            Assert.That(isValid, Is.True);
        }
    }
}
