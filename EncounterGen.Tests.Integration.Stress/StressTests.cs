using Ninject;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace EncounterGen.Tests.Integration.Stress
{
    [TestFixture]
    [Stress]
    public abstract class StressTests : IntegrationTests
    {
        [Inject]
        public Stopwatch Stopwatch { get; set; }

        private const int ConfidentIterations = 1000000;
        private const int TenMinutesInSeconds = 600;
        private const int TwoHoursInSeconds = 3600 * 2;

        private readonly int timeLimitInSeconds;

        private int iterations;

        public StressTests()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            var methods = types.Where(t => t.GetCustomAttributes<StressAttribute>().Any()).SelectMany(t => t.GetMethods());
            var stressTestsCount = methods.Sum(m => m.GetCustomAttributes<TestAttribute>(true).Count());
            var stressTestCasesCount = methods.Sum(m => m.GetCustomAttributes<TestCaseAttribute>().Count());
            var stressTestsTotal = stressTestsCount + stressTestCasesCount;

            var twoHourTimeLimitPerTest = TwoHoursInSeconds / stressTestsTotal;
#if STRESS
            timeLimitInSeconds = Math.Min(twoHourTimeLimitPerTest, TenMinutesInSeconds - 10);
#else
            timeLimitInSeconds = 1;
#endif
        }

        [SetUp]
        public void StressSetup()
        {
            iterations = 0;
            Stopwatch.Start();
        }

        [TearDown]
        public void StressTearDown()
        {
            Stopwatch.Reset();
        }

        protected void Stress(Action makeAssertions)
        {
            do makeAssertions();
            while (TestShouldKeepRunning());

            var message = BuildMessage("Stress test complete");
            Console.WriteLine(message);
        }

        private string BuildMessage(string baseMessage, bool includeIterations = true)
        {
            var message = $"{baseMessage} after {Stopwatch.Elapsed}";

            if (!includeIterations)
                return message;

            var iterationsPerSecond = Math.Round(iterations / Stopwatch.Elapsed.TotalSeconds, 2);
            return $"{message} and {iterations} iterations, or {iterationsPerSecond} iterations/second";
        }

        protected T Generate<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;

            do generatedObject = generate();
            while (isValid(generatedObject) == false && Stopwatch.Elapsed.TotalSeconds < timeLimitInSeconds + 10);

            if (isValid(generatedObject) == false)
            {
                var message = BuildMessage("Failed to generate", false);
                Assert.Fail(message);
            }

            return generatedObject;
        }

        protected T GenerateOrFail<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;

            do generatedObject = generate();
            while (TestShouldKeepRunning() && isValid(generatedObject) == false);

            var message = BuildMessage("Generation complete");
            Console.WriteLine(message);

            if (TestShouldKeepRunning() == false && isValid(generatedObject) == false)
            {
                message = BuildMessage("Failed to generate");
                Assert.Fail(message);
            }

            return generatedObject;
        }

        private bool TestShouldKeepRunning()
        {
            iterations++;
            return Stopwatch.Elapsed.TotalSeconds < timeLimitInSeconds && iterations < ConfidentIterations;
        }
    }
}
