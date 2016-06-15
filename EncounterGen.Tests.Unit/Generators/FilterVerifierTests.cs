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
        private IFilterVerifier filterVerifier;
        private Mock<ITypeAndAmountPercentileSelector> mockTypeAndAmountPercentileSelector;
        private Mock<ICollectionSelector> mockCollectionSelector;
        private int level;
        private string environment;
        private string filter;
        private List<string> filterGroup;

        [SetUp]
        public void Setup()
        {
            mockTypeAndAmountPercentileSelector = new Mock<ITypeAndAmountPercentileSelector>();
            mockCollectionSelector = new Mock<ICollectionSelector>();
            filterVerifier = new FilterVerifier(mockTypeAndAmountPercentileSelector.Object, mockCollectionSelector.Object);

            level = 9266;
            environment = "environment";
            filter = "filter";

            var levelsAndAmounts = new List<Dictionary<string, string>>();
            levelsAndAmounts.Add(new Dictionary<string, string>());
            levelsAndAmounts.Add(new Dictionary<string, string>());
            levelsAndAmounts.Add(new Dictionary<string, string>());

            levelsAndAmounts[0]["9265"] = "more";
            levelsAndAmounts[1]["9266"] = "same";
            levelsAndAmounts[2]["9267"] = "less";

            var tableName = string.Format(TableNameConstants.LevelXEncounterLevel, level);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(levelsAndAmounts);

            filterGroup = new List<string>();
            filterGroup.Add("creature");
            filterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, filter)).Returns(filterGroup);
        }

        [Test]
        public void NoFiltersIsAlwaysValid()
        {
            var isValid = filterVerifier.FiltersAreValid("bogus environment", 90210);
            Assert.That(isValid, Is.True);
        }

        [TestCase(9265)]
        [TestCase(9266)]
        [TestCase(9267)]
        public void FilterIsValidIfMatchWithinRangeOfLevels(int passingLevel)
        {
            SetupCreaturesAndAmounts(9264, passingLevel);
            SetupCreaturesAndAmounts(9265, passingLevel);
            SetupCreaturesAndAmounts(9266, passingLevel);
            SetupCreaturesAndAmounts(9267, passingLevel);
            SetupCreaturesAndAmounts(9268, passingLevel);

            var isValid = filterVerifier.FiltersAreValid(environment, level, filter);
            Assert.That(isValid, Is.True);
        }

        private void SetupCreaturesAndAmounts(int setupLevel, int passingLevel, string creatureName = "creature")
        {
            var creaturesAndAmounts = new List<Dictionary<string, string>>();
            creaturesAndAmounts.Add(new Dictionary<string, string>());
            creaturesAndAmounts.Add(new Dictionary<string, string>());
            creaturesAndAmounts.Add(new Dictionary<string, string>());

            creaturesAndAmounts[0]["wrong creature"] = "some";
            creaturesAndAmounts[0]["other wrong creature"] = "some";
            creaturesAndAmounts[1]["wrong creature"] = "a ton";
            creaturesAndAmounts[1]["other wrong creature"] = "a ton";
            creaturesAndAmounts[2]["wrong creature"] = "barely any";
            creaturesAndAmounts[2]["other wrong creature"] = "barely any";

            if (setupLevel == passingLevel)
                creaturesAndAmounts[2][creatureName] = "just the right amount";

            var tableName = string.Format(TableNameConstants.LevelXENVIRONMENTEncounters, setupLevel, environment);
            mockTypeAndAmountPercentileSelector.Setup(s => s.SelectAllFrom(tableName)).Returns(creaturesAndAmounts);
        }

        [TestCase(9264)]
        [TestCase(9268)]
        public void FilterIsNotValidIfMatchOutsideRangeOfLevels(int passingLevel)
        {
            SetupCreaturesAndAmounts(9264, passingLevel);
            SetupCreaturesAndAmounts(9265, passingLevel);
            SetupCreaturesAndAmounts(9266, passingLevel);
            SetupCreaturesAndAmounts(9267, passingLevel);
            SetupCreaturesAndAmounts(9268, passingLevel);

            var isValid = filterVerifier.FiltersAreValid(environment, level, filter);
            Assert.That(isValid, Is.False);
        }

        [TestCase(9265)]
        [TestCase(9266)]
        [TestCase(9267)]
        public void FiltersAreValidIfAnyFilterMatchesWithinRangeOfLevels(int passingLevel)
        {
            SetupCreaturesAndAmounts(9264, passingLevel);
            SetupCreaturesAndAmounts(9265, passingLevel);
            SetupCreaturesAndAmounts(9266, passingLevel);
            SetupCreaturesAndAmounts(9267, passingLevel);
            SetupCreaturesAndAmounts(9268, passingLevel);

            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "additional filter")).Returns(additionalFilterGroup);

            var isValid = filterVerifier.FiltersAreValid(environment, level, filter, "additional filter");
            Assert.That(isValid, Is.True);
        }

        [TestCase(9261)]
        [TestCase(9271)]
        public void FiltersAreNotValidIfMatchOutsideRangeOfLevels(int passingLevel)
        {
            SetupCreaturesAndAmounts(9264, passingLevel);
            SetupCreaturesAndAmounts(9265, passingLevel);
            SetupCreaturesAndAmounts(9266, passingLevel);
            SetupCreaturesAndAmounts(9267, passingLevel);
            SetupCreaturesAndAmounts(9268, passingLevel);

            filterGroup.Remove("creature");

            var additionalFilterGroup = new List<string>();
            additionalFilterGroup.Add("creature");
            additionalFilterGroup.Add("other creature");

            mockCollectionSelector.Setup(s => s.SelectFrom(TableNameConstants.CreatureGroups, "additional filter")).Returns(additionalFilterGroup);

            var isValid = filterVerifier.FiltersAreValid(environment, level, filter, "additional filter");
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void FiltersAreValidIfCreatureWithDescriptionMatches()
        {
            SetupCreaturesAndAmounts(9266, level, "creature (description)");
            var isValid = filterVerifier.FiltersAreValid(environment, level, filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void FiltersAreValidIfCreatureWithLevelMatches()
        {
            SetupCreaturesAndAmounts(9266, level, "creature[600]");
            var isValid = filterVerifier.FiltersAreValid(environment, level, filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void FiltersAreValidIfCreatureWithDescriptionAndLevelMatches()
        {
            SetupCreaturesAndAmounts(9266, level, "creature (description)[600]");
            var isValid = filterVerifier.FiltersAreValid(environment, level, filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void NoFiltersForCreatureIsAlwaysValid()
        {
            var isValid = filterVerifier.CreatureIsValid("bogus creature");
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfWithinFilterGroup()
        {
            var isValid = filterVerifier.CreatureIsValid("creature", filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsNotValidIfOutsideFilterGroup()
        {
            var isValid = filterVerifier.CreatureIsValid("wrong creature", filter);
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

            var isValid = filterVerifier.CreatureIsValid("creature", filter, "additional filter");
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

            var isValid = filterVerifier.CreatureIsValid("wrong creature", filter, "additional filter");
            Assert.That(isValid, Is.False);
        }

        [Test]
        public void CreatureIsValidIfCreatureWithDescriptionMatches()
        {
            var isValid = filterVerifier.CreatureIsValid("creature (description)", filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfCreatureWithLevelMatches()
        {
            var isValid = filterVerifier.CreatureIsValid("creature[600]", filter);
            Assert.That(isValid, Is.True);
        }

        [Test]
        public void CreatureIsValidIfCreatureWithDescriptionAndLevelMatches()
        {
            var isValid = filterVerifier.CreatureIsValid("creature (description)[600]", filter);
            Assert.That(isValid, Is.True);
        }
    }
}
