using EncounterGen.Tests.Integration.Common;
using Ninject;
using NUnit.Framework;
using System;
using System.Diagnostics;

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

        private readonly int timeLimitInSeconds;

        private int iterations;

        public StressTests()
        {
#if STRESS
            timeLimitInSeconds = TenMinutesInSeconds - 10;
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

        protected T GenerateOrFail<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;

            do generatedObject = generate();
            while (TestShouldKeepRunning() && isValid(generatedObject) == false);

            Console.WriteLine($"Generation complete after {Stopwatch.Elapsed} and {iterations} iterations");

            if (TestShouldKeepRunning() == false && isValid(generatedObject) == false)
                Assert.Fail("Stress test timed out.");

            return generatedObject;
        }

        private bool TestShouldKeepRunning()
        {
            iterations++;
            return Stopwatch.Elapsed.TotalSeconds < timeLimitInSeconds && iterations < ConfidentIterations;
        }
    }
}
