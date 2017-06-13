using EventGen;
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
        [Inject]
        public ClientIDManager ClientIdManager { get; set; }
        [Inject]
        public GenEventQueue EventQueue { get; set; }

        private const int ConfidentIterations = 1000000;
        private const int TravisJobOutputTimeLimit = 60 * 10;
        private const int TravisJobBuildTimeLimit = 60 * 50;

        private readonly int timeLimitInSeconds;

        private int iterations;
        private Guid clientId;
        private DateTime eventCheckpoint;

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
            clientId = Guid.NewGuid();
            ClientIdManager.SetClientID(clientId);

            iterations = 0;
            eventCheckpoint = new DateTime();

            Stopwatch.Start();
        }

        [TearDown]
        public void StressTearDown()
        {
            WriteStressSummary();
            WriteEventSummary();

            Stopwatch.Reset();
        }

        private void WriteStressSummary()
        {
            var message = BuildMessage("Stress test complete");
            Console.WriteLine(message);
        }

        private void WriteEventSummary()
        {
            var events = EventQueue.DequeueAll(clientId);

            //INFO: Get the 10 most recent events for EncounterGen.  We assume the events are ordered chronologically already
            events = events.Where(e => e.Source == "EncounterGen");
            events = events.Reverse();
            events = events.Take(10);
            events = events.Reverse();

            foreach (var genEvent in events)
                Console.WriteLine(GetEventMessage(genEvent));
        }

        private string GetEventMessage(GenEvent genEvent)
        {
            return $"[{genEvent.When.ToLongTimeString()}] {genEvent.Source}: {genEvent.Message}";
        }

        protected void Stress(Action makeAssertions)
        {
            do
            {
                makeAssertions();
                AssertEventSpacing();
            }
            while (TestShouldKeepRunning());
        }

        private void AssertEventSpacing()
        {
            var events = EventQueue.DequeueAll(clientId);

            //INFO: Have to put the events back in the queue for the summary at the end of the test
            foreach (var genEvent in events)
                EventQueue.Enqueue(genEvent);

            Assert.That(events, Is.Ordered.By("When"));

            var newEvents = events.Where(e => e.When > eventCheckpoint).ToArray();

            Assert.That(newEvents, Is.Ordered.By("When"));

            for (var i = 1; i < newEvents.Length; i++)
            {
                var failureMessage = $"{GetEventMessage(newEvents[i - 1])}\n{GetEventMessage(newEvents[i])}";
                Assert.That(newEvents[i].When, Is.EqualTo(newEvents[i - 1].When).Within(1).Seconds, failureMessage);
            }

            if (newEvents.Any())
                eventCheckpoint = newEvents.Last().When;
        }

        private string BuildMessage(string baseMessage)
        {
            var iterationsPerSecond = Math.Round(iterations / Stopwatch.Elapsed.TotalSeconds, 2);
            return $"{baseMessage} after {Stopwatch.Elapsed} and {iterations} iterations, or {iterationsPerSecond} iterations/second";
        }

        protected T Generate<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;

            do
            {
                generatedObject = generate();
                AssertEventSpacing();
            }
            while (!isValid(generatedObject));

            return generatedObject;
        }

        protected T GenerateOrFail<T>(Func<T> generate, Func<T, bool> isValid)
        {
            T generatedObject;

            do
            {
                generatedObject = generate();
                AssertEventSpacing();
            }
            while (TestShouldKeepRunning() && isValid(generatedObject) == false);

            if (TestShouldKeepRunning() == false && isValid(generatedObject) == false)
            {
                var message = BuildMessage("Failed to generate");
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
