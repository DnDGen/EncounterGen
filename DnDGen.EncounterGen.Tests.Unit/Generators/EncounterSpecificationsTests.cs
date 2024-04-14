using DnDGen.EncounterGen.Generators;
using NUnit.Framework;
using System;

namespace DnDGen.EncounterGen.Tests.Unit.Generators
{
    [TestFixture]
    public class EncounterSpecificationsTests
    {
        private EncounterSpecifications encounterSpecifications;
        private Random random;

        [SetUp]
        public void Setup()
        {
            encounterSpecifications = new EncounterSpecifications();
            random = new Random();
        }

        [Test]
        public void EncounterSpecificationsInitialized()
        {
            Assert.That(encounterSpecifications.AllowAquatic, Is.False);
            Assert.That(encounterSpecifications.AllowUnderground, Is.False);
            Assert.That(encounterSpecifications.CreatureTypeFilters, Is.Empty);
            Assert.That(encounterSpecifications.Environment, Is.Empty);
            Assert.That(encounterSpecifications.Level, Is.EqualTo(0));
            Assert.That(encounterSpecifications.Temperature, Is.Empty);
            Assert.That(encounterSpecifications.TimeOfDay, Is.Empty);
        }

        [TestCase(EncounterSpecifications.MinimumLevel, 1)]
        [TestCase(EncounterSpecifications.MaximumLevel, 30)]
        public void SpecificationConstant(int constant, int value)
        {
            Assert.That(constant, Is.EqualTo(value));
        }

        [Test]
        public void SpecificationsAreValid()
        {
            encounterSpecifications.Environment = "environment";
            encounterSpecifications.Level = 15;
            encounterSpecifications.Temperature = "temperature";
            encounterSpecifications.TimeOfDay = "time of day";

            Assert.That(encounterSpecifications.IsValid(), Is.True);
        }

        [Test]
        public void SpecificationsAreInvalidIfEnvironmentMissing()
        {
            encounterSpecifications.Level = 15;
            encounterSpecifications.Temperature = "temperature";
            encounterSpecifications.TimeOfDay = "time of day";

            Assert.That(encounterSpecifications.IsValid(), Is.False);
        }

        [Test]
        public void SpecificationsAreInvalidIfTemperatureMissing()
        {
            encounterSpecifications.Environment = "environment";
            encounterSpecifications.Level = 15;
            encounterSpecifications.TimeOfDay = "time of day";

            Assert.That(encounterSpecifications.IsValid(), Is.False);
        }

        [Test]
        public void SpecificationsAreInvalidIfTimeOfDayMissing()
        {
            encounterSpecifications.Environment = "environment";
            encounterSpecifications.Level = 15;
            encounterSpecifications.Temperature = "temperature";

            Assert.That(encounterSpecifications.IsValid(), Is.False);
        }

        [Test]
        public void SpecificationsAreInvalidIfCreatureFiltersAreNull()
        {
            encounterSpecifications.Environment = "environment";
            encounterSpecifications.Level = 15;
            encounterSpecifications.Temperature = "temperature";
            encounterSpecifications.TimeOfDay = "time of day";
            encounterSpecifications.CreatureTypeFilters = null;

            Assert.That(encounterSpecifications.IsValid(), Is.False);
        }

        [Test]
        public void SpecificationsAreInvalidIfLevelIsLessThanMinimumLevel()
        {
            encounterSpecifications.Environment = "environment";
            encounterSpecifications.Level = EncounterSpecifications.MinimumLevel - 1;
            encounterSpecifications.Temperature = "temperature";
            encounterSpecifications.TimeOfDay = "time of day";

            Assert.That(encounterSpecifications.IsValid(), Is.False);
        }

        [Test]
        public void SpecificationsAreInvalidIfLevelIsMoreThanMaximumLevel()
        {
            encounterSpecifications.Environment = "environment";
            encounterSpecifications.Level = EncounterSpecifications.MaximumLevel + 1;
            encounterSpecifications.Temperature = "temperature";
            encounterSpecifications.TimeOfDay = "time of day";

            Assert.That(encounterSpecifications.IsValid(), Is.False);
        }

        [Test]
        public void SpecificationsAreValidIfLevelIsBetweenMinAndMax()
        {
            for (var level = EncounterSpecifications.MinimumLevel; level <= EncounterSpecifications.MaximumLevel; level++)
            {
                encounterSpecifications.Environment = "environment";
                encounterSpecifications.Level = level;
                encounterSpecifications.Temperature = "temperature";
                encounterSpecifications.TimeOfDay = "time of day";

                Assert.That(encounterSpecifications.IsValid(), Is.True, level.ToString());
            }
        }

        [Test]
        public void SpecificationsHaveDescription()
        {
            encounterSpecifications.Environment = "environment";
            encounterSpecifications.Level = 15;
            encounterSpecifications.Temperature = "temperature";
            encounterSpecifications.TimeOfDay = "time of day";

            Assert.That(encounterSpecifications.Description, Is.EqualTo("Level 15 temperature environment time of day"));
        }

        [Test]
        public void SpecificationsHaveFullDescription()
        {
            encounterSpecifications.Environment = "environment";
            encounterSpecifications.Level = 15;
            encounterSpecifications.Temperature = "temperature";
            encounterSpecifications.TimeOfDay = "time of day";
            encounterSpecifications.AllowAquatic = true;
            encounterSpecifications.AllowUnderground = true;
            encounterSpecifications.CreatureTypeFilters = new[] { "filter 1", "filter 2" };

            Assert.That(encounterSpecifications.Description, Is.EqualTo("Level 15 temperature environment time of day, allowing aquatic, allowing underground, allowing [filter 1, filter 2]"));
        }

        [Test]
        public void LevelIsInvalidIfLevelIsLessThanMinimumLevel()
        {
            Assert.That(EncounterSpecifications.LevelIsValid(EncounterSpecifications.MinimumLevel - 1), Is.False);
        }

        [Test]
        public void LevelIsInvalidIfLevelIsMoreThanMaximumLevel()
        {
            Assert.That(EncounterSpecifications.LevelIsValid(EncounterSpecifications.MaximumLevel + 1), Is.False);
        }

        [Test]
        public void LevelIsValidIfLevelIsBetweenMinAndMax()
        {
            for (var level = EncounterSpecifications.MinimumLevel; level <= EncounterSpecifications.MaximumLevel; level++)
            {
                Assert.That(EncounterSpecifications.LevelIsValid(level), Is.True, level.ToString());
            }
        }

        [Test]
        public void CloneSpecifications()
        {
            encounterSpecifications.AllowAquatic = Convert.ToBoolean(random.Next(2));
            encounterSpecifications.AllowUnderground = Convert.ToBoolean(random.Next(2));
            encounterSpecifications.CreatureTypeFilters = new[] { Guid.NewGuid().ToString(), Guid.NewGuid().ToString() };
            encounterSpecifications.Environment = Guid.NewGuid().ToString();
            encounterSpecifications.Level = random.Next();
            encounterSpecifications.Temperature = Guid.NewGuid().ToString();
            encounterSpecifications.TimeOfDay = Guid.NewGuid().ToString();

            var clone = encounterSpecifications.Clone();
            Assert.That(clone, Is.Not.EqualTo(encounterSpecifications));
            Assert.That(clone.AllowAquatic, Is.EqualTo(encounterSpecifications.AllowAquatic));
            Assert.That(clone.AllowUnderground, Is.EqualTo(encounterSpecifications.AllowUnderground));
            Assert.That(clone.Environment, Is.EqualTo(encounterSpecifications.Environment));
            Assert.That(clone.Level, Is.EqualTo(encounterSpecifications.Level));
            Assert.That(clone.Temperature, Is.EqualTo(encounterSpecifications.Temperature));
            Assert.That(clone.TimeOfDay, Is.EqualTo(encounterSpecifications.TimeOfDay));
            Assert.That(clone.CreatureTypeFilters, Is.EquivalentTo(encounterSpecifications.CreatureTypeFilters));
            Assert.That(clone.CreatureTypeFilters, Is.Not.SameAs(encounterSpecifications.CreatureTypeFilters));
        }

        [Test]
        public void SpecificEnvironmentIsTemperatureAndEnvironment()
        {
            encounterSpecifications.Temperature = "temp";
            encounterSpecifications.Environment = "environment";

            Assert.That(encounterSpecifications.SpecificEnvironment, Is.EqualTo("tempenvironment"));
        }
    }
}
