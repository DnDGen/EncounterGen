using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using NUnit.Framework;
using System.Diagnostics;

namespace DnDGen.EncounterGen.Tests.Integration.Generators
{
    [TestFixture]
    internal class EncounterVerifierTests : IntegrationTests
    {
        private IEncounterVerifier encounterVerifier;
        private Stopwatch stopwatch;

        [SetUp]
        public void Setup()
        {
            encounterVerifier = GetNewInstanceOf<IEncounterVerifier>();
            stopwatch = new Stopwatch();
        }

        [TestCase(EnvironmentConstants.Civilized,
            EnvironmentConstants.Temperatures.Temperate,
            EnvironmentConstants.TimesOfDay.Night,
            7, false, true)]
        public void ValidEncounterExists_ReturnsTrue(string environment, string temperature, string timeOfDay, int level, bool allowAquatic, bool allowUnderground)
        {
            var specifications = new EncounterSpecifications
            {
                Environment = environment,
                Temperature = temperature,
                TimeOfDay = timeOfDay,
                Level = level,
                AllowAquatic = allowAquatic,
                AllowUnderground = allowUnderground
            };

            stopwatch.Start();
            var valid = encounterVerifier.ValidEncounterExists(specifications);
            stopwatch.Stop();

            Assert.That(valid, Is.True);
            Assert.That(stopwatch.Elapsed.TotalSeconds, Is.LessThan(1));
        }

        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Aquatic, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Civilized, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Desert, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Forest, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Hills, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Marsh, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Mountain, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Plains, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Cold, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Temperate, EnvironmentConstants.TimesOfDay.Night, true, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, false, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Day, true, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, false, true)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, false)]
        [TestCase(EnvironmentConstants.Underground, EnvironmentConstants.Temperatures.Warm, EnvironmentConstants.TimesOfDay.Night, true, true)]
        public void ValidEncounterExists_ReturnsTrue_ForEnvironment(string environment, string temperature, string timeOfDay, bool allowAquatic, bool allowUnderground)
        {
            var specifications = new EncounterSpecifications
            {
                Environment = environment,
                Temperature = temperature,
                TimeOfDay = timeOfDay,
                Level = 1,
                AllowAquatic = allowAquatic,
                AllowUnderground = allowUnderground
            };

            stopwatch.Start();
            var valid = encounterVerifier.ValidEncounterExists(specifications);
            stopwatch.Stop();

            Assert.That(valid, Is.True);
            Assert.That(stopwatch.Elapsed.TotalSeconds, Is.LessThan(1));
        }

        [TestCase(EncounterSpecifications.MinimumLevel)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        [TestCase(20)]
        [TestCase(21)]
        [TestCase(22)]
        [TestCase(23)]
        [TestCase(24)]
        [TestCase(25)]
        [TestCase(26)]
        [TestCase(27)]
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(EncounterSpecifications.MaximumLevel, false)]
        public void ValidEncounterExists_ReturnsValidity_ForLevel(int level, bool expectedValid = true)
        {
            var specifications = new EncounterSpecifications
            {
                Environment = EnvironmentConstants.Civilized,
                Temperature = EnvironmentConstants.Temperatures.Temperate,
                TimeOfDay = EnvironmentConstants.TimesOfDay.Night,
                Level = level,
                AllowAquatic = true,
                AllowUnderground = true
            };

            stopwatch.Start();
            var valid = encounterVerifier.ValidEncounterExists(specifications);
            stopwatch.Stop();

            Assert.That(valid, Is.EqualTo(expectedValid));
            Assert.That(stopwatch.Elapsed.TotalSeconds, Is.LessThan(1));
        }

        [TestCase(CreatureDataConstants.Types.Aberration, EnvironmentConstants.Civilized, 1, false)]
        [TestCase(CreatureDataConstants.Types.Aberration, EnvironmentConstants.Civilized, 10, false)]
        [TestCase(CreatureDataConstants.Types.Aberration, EnvironmentConstants.Plains, 1, false)]
        [TestCase(CreatureDataConstants.Types.Aberration, EnvironmentConstants.Plains, 10)]
        [TestCase(CreatureDataConstants.Types.Animal)]
        [TestCase(CreatureDataConstants.Types.Construct)]
        [TestCase(CreatureDataConstants.Types.Dragon, EnvironmentConstants.Civilized, 1, false)]
        [TestCase(CreatureDataConstants.Types.Dragon, EnvironmentConstants.Civilized, 10, false)]
        [TestCase(CreatureDataConstants.Types.Dragon, EnvironmentConstants.Plains, 1, false)]
        [TestCase(CreatureDataConstants.Types.Dragon, EnvironmentConstants.Plains, 10, false)]
        [TestCase(CreatureDataConstants.Types.Dragon, EnvironmentConstants.Mountain, 1, false)]
        [TestCase(CreatureDataConstants.Types.Dragon, EnvironmentConstants.Mountain, 10)]
        [TestCase(CreatureDataConstants.Types.Elemental)]
        [TestCase(CreatureDataConstants.Types.Fey, EnvironmentConstants.Civilized, 1, false)]
        [TestCase(CreatureDataConstants.Types.Fey, EnvironmentConstants.Civilized, 10, false)]
        [TestCase(CreatureDataConstants.Types.Fey, EnvironmentConstants.Forest, 1, false)]
        [TestCase(CreatureDataConstants.Types.Fey, EnvironmentConstants.Forest, 10)]
        [TestCase(CreatureDataConstants.Types.Giant, EnvironmentConstants.Civilized, 1, false)]
        [TestCase(CreatureDataConstants.Types.Giant, EnvironmentConstants.Civilized, 10, false)]
        [TestCase(CreatureDataConstants.Types.Giant, EnvironmentConstants.Hills, 1, false)]
        [TestCase(CreatureDataConstants.Types.Giant, EnvironmentConstants.Hills, 10)]
        [TestCase(CreatureDataConstants.Types.Humanoid)]
        [TestCase(CreatureDataConstants.Types.MagicalBeast)]
        [TestCase(CreatureDataConstants.Types.MonstrousHumanoid, EnvironmentConstants.Civilized, 1, false)]
        [TestCase(CreatureDataConstants.Types.MonstrousHumanoid, EnvironmentConstants.Civilized, 10, false)]
        [TestCase(CreatureDataConstants.Types.MonstrousHumanoid, EnvironmentConstants.Mountain, 1, false)]
        [TestCase(CreatureDataConstants.Types.MonstrousHumanoid, EnvironmentConstants.Mountain, 10)]
        [TestCase(CreatureDataConstants.Types.Ooze, EnvironmentConstants.Civilized, 1, false)]
        [TestCase(CreatureDataConstants.Types.Ooze, EnvironmentConstants.Civilized, 10, false)]
        [TestCase(CreatureDataConstants.Types.Ooze, EnvironmentConstants.Plains, 1, false)]
        [TestCase(CreatureDataConstants.Types.Ooze, EnvironmentConstants.Plains, 10, false)]
        [TestCase(CreatureDataConstants.Types.Ooze, EnvironmentConstants.Underground, 10, false)]
        [TestCase(CreatureDataConstants.Types.Ooze, EnvironmentConstants.Underground, 9, false)]
        [TestCase(CreatureDataConstants.Types.Ooze, EnvironmentConstants.Underground, 8, false)]
        [TestCase(CreatureDataConstants.Types.Ooze, EnvironmentConstants.Underground, 7)]
        [TestCase(CreatureDataConstants.Types.Outsider)]
        [TestCase(CreatureDataConstants.Types.Plant)]
        [TestCase(CreatureDataConstants.Types.Undead)]
        [TestCase(CreatureDataConstants.Types.Vermin)]
        public void ValidEncounterExists_ReturnsValidity_ForFilter(string filter, string environment = EnvironmentConstants.Plains, int level = 1, bool expectedValid = true)
        {
            var specifications = new EncounterSpecifications
            {
                Environment = environment,
                Temperature = EnvironmentConstants.Temperatures.Temperate,
                TimeOfDay = EnvironmentConstants.TimesOfDay.Night,
                Level = level,
                AllowAquatic = true,
                AllowUnderground = true,
                CreatureTypeFilters = new[] { filter },
            };

            stopwatch.Start();
            var valid = encounterVerifier.ValidEncounterExists(specifications);
            stopwatch.Stop();

            Assert.That(valid, Is.EqualTo(expectedValid));
            Assert.That(stopwatch.Elapsed.TotalSeconds, Is.LessThan(1));
        }
    }
}
