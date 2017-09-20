using CharacterGen.Domain.IoC;
using DnDGen.Core.IoC;
using EncounterGen.Domain.IoC;
using EventGen;
using EventGen.IoC;
using Ninject;
using NUnit.Framework;
using RollGen.Domain.IoC;
using System;
using System.Linq;
using TreasureGen.Domain.IoC;

namespace EncounterGen.Tests.Integration
{
    [TestFixture]
    public abstract class IntegrationTests
    {
        protected IKernel kernel;
        private TimeSpan eventSpacing;

        [OneTimeSetUp]
        public void IntegrationTestsFixtureSetup()
        {
            kernel = new StandardKernel(new NinjectSettings() { InjectNonPublic = true });

            var rollGenLoader = new RollGenModuleLoader();
            rollGenLoader.LoadModules(kernel);

            var eventGenLoader = new EventGenModuleLoader();
            eventGenLoader.LoadModules(kernel);

            var coreLoader = new CoreModuleLoader();
            coreLoader.LoadModules(kernel);

            var treasureGenLoader = new TreasureGenModuleLoader();
            treasureGenLoader.LoadModules(kernel);

            var characterGenLoader = new CharacterGenModuleLoader();
            characterGenLoader.LoadModules(kernel);

            var encounterGenLoader = new EncounterGenModuleLoader();
            encounterGenLoader.LoadModules(kernel);

            eventSpacing = new TimeSpan(TimeSpan.TicksPerSecond);
        }

        [SetUp]
        public void IntegrationTestsSetup()
        {
            kernel.Inject(this);

            var clientId = Guid.NewGuid();
            var clientIdManager = GetNewInstanceOf<ClientIDManager>();
            clientIdManager.SetClientID(clientId);
        }

        protected T GetNewInstanceOf<T>()
        {
            return kernel.Get<T>();
        }

        protected void AssertEventSpacing()
        {
            var eventQueue = GetNewInstanceOf<GenEventQueue>();
            var dequeuedEvents = eventQueue.DequeueAllForCurrentThread();

            if (!dequeuedEvents.Any())
                return;

            Assert.That(dequeuedEvents, Is.Ordered.By("When"));

            var times = dequeuedEvents.Select(e => e.When);
            var checkpointEvent = dequeuedEvents.First();
            var checkpoint = checkpointEvent.When;
            var finalEvent = dequeuedEvents.Last();
            var finalCheckPoint = finalEvent.When;

            while (finalCheckPoint > checkpoint)
            {
                var maxEventSpacing = checkpoint.Add(eventSpacing);

                var failedEvent = dequeuedEvents.First(e => e.When > checkpoint);
                var failureMessage = $"{GetMessage(checkpointEvent)}\n{GetMessage(failedEvent)}";
                Assert.That(times, Has.Some.InRange(checkpoint.AddTicks(1), maxEventSpacing), failureMessage);

                checkpointEvent = dequeuedEvents.Last(e => e.When <= maxEventSpacing);
                checkpoint = checkpointEvent.When;
            }
        }

        protected string GetMessage(GenEvent genEvent)
        {
            return $"[{genEvent.When.ToLongTimeString()}] {genEvent.Source}: {genEvent.Message}";
        }
    }
}
