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
        private const int TravisJobOutputTimeLimit = 60 * 10;
        private const int TravisJobBuildTimeLimit = 60 * 50;

        private readonly int timeLimitInSeconds;

        private int iterations;

        public StressTests()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();

            var methods = types.Where(t => t.GetCustomAttributes<StressAttribute>().Any()).SelectMany(t => t.GetMethods());
            methods = methods.Where(m => m.GetCustomAttributes<IgnoreAttribute>().Any() == false);

            var stressTestsCount = methods.Sum(m => m.GetCustomAttributes<TestAttribute>(true).Count());
            var stressTestCasesCount = methods.Sum(m => m.GetCustomAttributes<TestCaseAttribute>().Count());
            var stressTestsTotal = stressTestsCount + stressTestCasesCount;

            var perTestTimeLimit = TravisJobBuildTimeLimit / stressTestsTotal;

            //INFO: We are taking extra time off of the time limit because sometimes encounter generation can take up to 4 seconds (particularly if characters are involved),
            //and all the stress tests together, with the general overages, make it extend beyond the Travis job time limit.
            perTestTimeLimit -= 1;

            Assert.That(perTestTimeLimit, Is.AtLeast(20));
#if STRESS
            timeLimitInSeconds = Math.Min(perTestTimeLimit, TravisJobOutputTimeLimit - 10);
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

            var message = BuildMessage("Stress test complete", iterations, Stopwatch.Elapsed);
            Console.WriteLine(message);
        }

        private string BuildMessage(string baseMessage, int iterations, TimeSpan timespan)
        {
            var iterationsPerSecond = Math.Round(iterations / timespan.TotalSeconds, 2);
            return $"{baseMessage} after {timespan} and {iterations} iterations, or {iterationsPerSecond} iterations/second";
        }

        protected T Generate<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;
            var attempts = 0;
            var start = Stopwatch.ElapsedTicks;

            do
            {
                generatedObject = generate();
                attempts++;
            }
            while (isValid(generatedObject) == false && Stopwatch.Elapsed.TotalSeconds < timeLimitInSeconds + 1); //INFO: Adding 1 second because we want to account for if we make a new iteration attempt near the time limit

            var finish = Stopwatch.ElapsedTicks;
            var timespan = new TimeSpan(finish - start);

            if (isValid(generatedObject) == false)
            {
                var message = BuildMessage("Failed to generate", attempts, timespan);
                Assert.Fail(message);
            }

            return generatedObject;
        }

        protected T GenerateOrFail<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;

            do generatedObject = generate();
            while (TestShouldKeepRunning() && isValid(generatedObject) == false);

            var message = BuildMessage("Generation complete", iterations, Stopwatch.Elapsed);
            Console.WriteLine(message);

            if (TestShouldKeepRunning() == false && isValid(generatedObject) == false)
            {
                message = BuildMessage("Failed to generate", iterations, Stopwatch.Elapsed);
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
