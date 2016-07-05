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

        public abstract void Stress(string stressSubject);

        protected void Stress()
        {
            Stress(MakeAssertions);
        }

        protected abstract void MakeAssertions();

        protected void Stress(Action makeAssertions)
        {
            do makeAssertions();
            while (TestShouldKeepRunning());

            Console.WriteLine($"Stress test complete after {Stopwatch.Elapsed} and {iterations} iterations");
        }

        protected T Generate<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;

            do generatedObject = generate();
            while (isValid(generatedObject) == false && Stopwatch.Elapsed.TotalSeconds < timeLimitInSeconds + 10);

            if (isValid(generatedObject) == false)
                Assert.Fail($"Failed to generate after {Stopwatch.Elapsed}");

            return generatedObject;
        }

        protected T GenerateOrFail<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;

            do generatedObject = generate();
            while (TestShouldKeepRunning() && isValid(generatedObject) == false);

            Console.WriteLine($"Generation complete after {Stopwatch.Elapsed} and {iterations} iterations");

            if (TestShouldKeepRunning() == false && isValid(generatedObject) == false)
                Assert.Fail($"Failed to generate after {Stopwatch.Elapsed} and {iterations} iterations.");

            return generatedObject;
        }

        private bool TestShouldKeepRunning()
        {
            iterations++;
            return Stopwatch.Elapsed.TotalSeconds < timeLimitInSeconds && iterations < ConfidentIterations;
        }
    }
}
