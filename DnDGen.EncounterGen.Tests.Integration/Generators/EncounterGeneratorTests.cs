using DnDGen.EncounterGen.Generators;
using DnDGen.EncounterGen.Models;
using DnDGen.RollGen;
using NUnit.Framework;
using System.Diagnostics;
using System.Linq;

namespace DnDGen.EncounterGen.Tests.Integration.Generators
{
    [TestFixture]
    internal class EncounterGeneratorTests : IntegrationTests
    {
        private IEncounterGenerator encounterGenerator;
        private Dice dice;
        private Stopwatch stopwatch;

        [SetUp]
        public void Setup()
        {
            encounterGenerator = GetNewInstanceOf<IEncounterGenerator>();
            dice = GetNewInstanceOf<Dice>();
            stopwatch = new Stopwatch();
        }

        [TestCase(EnvironmentConstants.Civilized,
            EnvironmentConstants.Temperatures.Temperate,
            EnvironmentConstants.TimesOfDay.Night,
            7, false, true)]
        public void Generate_ReturnsEncounter(string environment, string temperature, string timeOfDay, int level, bool allowAquatic, bool allowUnderground)
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
            var encounter = encounterGenerator.Generate(specifications);
            stopwatch.Stop();

            AssertEncounter(encounter);
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
        public void Generate_ReturnsEncounter_ForEnvironment(string environment, string temperature, string timeOfDay, bool allowAquatic, bool allowUnderground)
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
            var encounter = encounterGenerator.Generate(specifications);
            stopwatch.Stop();

            AssertEncounter(encounter);
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
        [TestCase(EncounterSpecifications.MaximumLevel, Ignore = "There are no level 30 encounters")]
        public void Generate_ReturnsEncounter_ForLevel(int level)
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
            var encounter = encounterGenerator.Generate(specifications);
            stopwatch.Stop();

            AssertEncounter(encounter);
            Assert.That(stopwatch.Elapsed.TotalSeconds, Is.LessThan(1).Or.LessThan(encounter.Characters.Sum(s => s.Class.Level / 10d)));
        }

        [TestCase(CreatureDataConstants.Types.Aberration, EnvironmentConstants.Plains, 10)]
        [TestCase(CreatureDataConstants.Types.Animal)]
        [TestCase(CreatureDataConstants.Types.Construct)]
        [TestCase(CreatureDataConstants.Types.Dragon, EnvironmentConstants.Mountain, 10)]
        [TestCase(CreatureDataConstants.Types.Elemental)]
        [TestCase(CreatureDataConstants.Types.Fey, EnvironmentConstants.Forest, 10)]
        [TestCase(CreatureDataConstants.Types.Giant, EnvironmentConstants.Hills, 10)]
        [TestCase(CreatureDataConstants.Types.Humanoid)]
        [TestCase(CreatureDataConstants.Types.MagicalBeast)]
        [TestCase(CreatureDataConstants.Types.MonstrousHumanoid, EnvironmentConstants.Mountain, 10)]
        [TestCase(CreatureDataConstants.Types.Ooze, EnvironmentConstants.Underground, 7)]
        [TestCase(CreatureDataConstants.Types.Outsider)]
        [TestCase(CreatureDataConstants.Types.Plant)]
        [TestCase(CreatureDataConstants.Types.Undead)]
        [TestCase(CreatureDataConstants.Types.Vermin)]
        public void Generate_ReturnsEncounter_ForFilter(string filter, string environment = EnvironmentConstants.Plains, int level = 1)
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
            var encounter = encounterGenerator.Generate(specifications);
            stopwatch.Stop();

            AssertEncounter(encounter);
            Assert.That(stopwatch.Elapsed.TotalSeconds, Is.LessThan(1));
        }

        private void AssertEncounter(Encounter encounter)
        {
            Assert.That(encounter.Description, Is.Not.Empty);
            Assert.That(encounter.Creatures, Is.Not.Empty);
            Assert.That(encounter.Creatures, Is.All.Not.Null);
            Assert.That(encounter.Characters, Is.Not.Null);
            Assert.That(encounter.Characters, Is.All.Not.Null);

            foreach (var creature in encounter.Creatures)
            {
                AssertCreature(creature.Creature);
                Assert.That(creature.Quantity, Is.Positive);
                Assert.That(creature.ChallengeRating, Is.Not.Empty);
            }

            Assert.That(encounter.Treasures, Is.Not.Null);
            Assert.That(encounter.Treasures, Is.All.Not.Null);
            Assert.That(encounter.Treasures.Select(t => t.IsAny), Is.All.True);

            var totalCreatures = encounter.Creatures.Sum(c => c.Quantity);
            Assert.That(encounter.Characters.Count, Is.LessThanOrEqualTo(totalCreatures));
            Assert.That(encounter.Treasures.Count, Is.LessThanOrEqualTo(encounter.Creatures.Count()));

            Assert.That(encounter.TargetEncounterLevel, Is.Positive);
            Assert.That(encounter.AverageEncounterLevel, Is.Positive);
            Assert.That(encounter.ActualEncounterLevel, Is.Positive);

            Assert.That(encounter.AverageDifficulty, Is.Not.Empty);
            Assert.That(encounter.ActualDifficulty, Is.Not.Empty);
        }

        private void AssertCreature(Creature creature)
        {
            Assert.That(creature.Name, Is.Not.Empty);
            Assert.That(creature.Description, Is.Not.Null);

            Assert.That(dice.ContainsRoll(creature.Name), Is.False);
            Assert.That(dice.ContainsRoll(creature.Description), Is.False);

            if (creature.SubCreature != null)
                AssertCreature(creature.SubCreature);
        }
    }
}
